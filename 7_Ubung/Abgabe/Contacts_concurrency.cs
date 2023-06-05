using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

namespace Addressmanagement
{
    public class Contacts<T> : LinkedList<T> where T : Contact, new()
    {
        private List<Thread> listOfThreads;
        public void readCsv(String fullpath)
        {
            FileStream s = new FileStream(fullpath, FileMode.Open);
            StreamReader r = new StreamReader(s);
            string line = null;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
                string[] contactInput = line.Split(";");
                string name = contactInput[0];
                string kurz = contactInput[1];
                T contact = new T();
                contact.setFirstnameAndKurzel(name, kurz);
                this.AddLast(contact);
            }
            r.Close();
        }

        public void writeCsv(String fullpath)
        {
            FileStream s = new FileStream(fullpath, FileMode.Create);
            StreamWriter w = new StreamWriter(s);

            bool isFirstLine = true;
            foreach (Contact contact in this)
            {
                if (isFirstLine){
                    w.WriteLine(contact.getTitleLine());
                    isFirstLine = false;
                }
                w.WriteLine(contact);
            }
            w.Close();
        }

        public void writeVCF(String path)
        {
            foreach (T contact in this)
            {
                FileStream s = new FileStream(path + contact.getKurzel() + ".vcf", FileMode.Create);
                StreamWriter w = new StreamWriter(s);
                string vcfformat = contact.convertToVCF();
                w.WriteLine(vcfformat);
                w.Close();
            }
        }

        public void crawlForInformation()
        {
            int i = 1;
            this.listOfThreads = new List<Thread>();
            foreach (T contact in this){
                if (i < 10) {
                    Thread t = new Thread(new ParameterizedThreadStart(this.informationCrawlThread));
                    t.Start(contact);
                    listOfThreads.Add(t);
                    i++;
                } else {
                    this.waitingForAllThreadEnding();
                    i = 0;
                }
            }
            this.waitingForAllThreadEnding();
        }

        public void waitingForAllThreadEnding()
        {
            foreach (Thread myThread in listOfThreads) {
                myThread.Join();
            }
        }

        public void informationCrawlThread(object myObject)
        {
            T contact = (T)myObject;
            WebResponse contentOfWebpage = this.requestContantOfEmployeeWebpage(contact.getKurzel());
            if (contentOfWebpage != null) {
                Dictionary<string, string> contactInformationWebpage;
                contactInformationWebpage = this.getInformationOfWebpage(contentOfWebpage);
                this.saveWebpageInformationToContact(contactInformationWebpage, contact);
            }
        }

        private void saveWebpageInformationToContact(Dictionary<string, string> contactInformationWebpage, T contact)
        {
            string firstname = "";
            string lastname = "";
            string department = "";
            string street = "";
            string plz = "";
            string city = "";
            string email = "";

            if (contactInformationWebpage.ContainsKey("firstname")) {
                firstname = contactInformationWebpage["firstname"];
            }
            if (contactInformationWebpage.ContainsKey("lastname")) {
                lastname = contactInformationWebpage["lastname"];
            }
            if (contactInformationWebpage.ContainsKey("department")) {
                department = contactInformationWebpage["department"];
            }
            if (contactInformationWebpage.ContainsKey("street")) {
                street = contactInformationWebpage["street"];
            }
            if (contactInformationWebpage.ContainsKey("postalCode")) {
                plz = contactInformationWebpage["postalCode"];
            }
            if (contactInformationWebpage.ContainsKey("city")) {
                city = contactInformationWebpage["city"];
            }
            if (contactInformationWebpage.ContainsKey("email")) {
                email = contactInformationWebpage["email"];
            }
            string name = firstname + " " + lastname;
            string standort = street + ";" + plz + " " + city;
            contact.setFullInformation(name, contact.getKurzel(), standort, "", email, "", department);
        }
        private WebResponse requestContantOfEmployeeWebpage(String kurzel)
        {
            String webPageUrl = "https://www.zhaw.ch/de/ueber-uns/person/" + kurzel + "/";
            WebRequest rq = WebRequest.Create(webPageUrl);
            WebResponse rsp = null;
            try { 
                rsp = rq.GetResponse();
            } catch(WebException e) {
                Console.WriteLine("Folgender Pfad konnte nicht abgerufen werden: " + webPageUrl);
            }
            return rsp;
        }

        private Dictionary<string, string> getInformationOfWebpage(WebResponse content)
        {
            Dictionary<string, string> argumentsToCheck = new Dictionary<string, string>();
            argumentsToCheck.Add("firstname", "gsaentity_person_firstname");
            argumentsToCheck.Add("lastname", "gsaentity_person_lastname");
            argumentsToCheck.Add("department", "gsaentity_person_addressdepartment");
            argumentsToCheck.Add("street", "gsaentity_person_addressstreet");
            argumentsToCheck.Add("postalCode", "gsaentity_person_addresspostalcode");
            argumentsToCheck.Add("city", "gsaentity_person_addresspostaltown");
            argumentsToCheck.Add("email", "gsaentity_person_email");

            Dictionary<string, string> outputinformation = new Dictionary<string, string>();
            StreamReader reader = new StreamReader(content.GetResponseStream());
            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
            {
                outputinformation = this.checkLineForInformation(line, argumentsToCheck, outputinformation);
            }

            return outputinformation;
        }
        
        private Dictionary<string, string> checkLineForInformation(string line, Dictionary<string, string> argumentsToCheck, Dictionary<string, string> contactInformation)
        {
            foreach (KeyValuePair<string, string> entry in argumentsToCheck) {
                if (line.Contains(entry.Value)) {
                    string firstCut = line.Split("content=\"")[1];
                    string information = firstCut.Split("\"")[0];
                    contactInformation.Add(entry.Key, information);
                }
            }
            return contactInformation;
        }

    }
}
