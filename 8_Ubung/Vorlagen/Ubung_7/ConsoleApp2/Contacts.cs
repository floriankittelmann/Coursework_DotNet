using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Collections;

namespace Addressmanagement
{
    public class Contacts<T> : LinkedList<T> where T : Contact, new()
    {
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

            foreach (Contact contact in this)
            {
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
            foreach (T contact in this)
            {
                WebResponse contentOfWebpage = this.requestContantOfEmployeeWebpage(contact.getKurzel());
                Dictionary<string, string> contactInformationWebpage;
                contactInformationWebpage = this.getInformationOfWebpage(contentOfWebpage);
                this.saveWebpageInformationToContact(contactInformationWebpage, contact);
            }
        }

        private void saveWebpageInformationToContact(Dictionary<string, string> contactInformationWebpage, T contact)
        {
            string firstname = contactInformationWebpage["firstname"];
            string lastname = contactInformationWebpage["lastname"];
            string name = firstname + " " + lastname;

            string department = contactInformationWebpage["department"];
            string street = contactInformationWebpage["street"];
            string plz = contactInformationWebpage["postalCode"];
            string city = contactInformationWebpage["city"];

            string standort = street + ";" + plz + " " + city;
            string email = contactInformationWebpage["email"];
            contact.setFullInformation(name, contact.getKurzel(), standort, "", email, "", department);
        }
        private WebResponse requestContantOfEmployeeWebpage(String kurzel)
        {
            String webPageUrl = "https://www.zhaw.ch/de/ueber-uns/person/" + kurzel + "/";
            WebRequest rq = WebRequest.Create(webPageUrl);
            WebResponse rsp = rq.GetResponse();
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
            foreach (KeyValuePair<string, string> entry in argumentsToCheck)
            {
                if (line.Contains(entry.Value))
                {
                    string firstCut = line.Split("content=\"")[1];
                    string information = firstCut.Split("\"")[0];
                    contactInformation.Add(entry.Key, information);
                }
            }
            return contactInformation;
        }

    }
}
