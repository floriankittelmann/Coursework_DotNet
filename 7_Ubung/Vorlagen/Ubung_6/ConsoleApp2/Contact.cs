using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Addressmanagement {

    public class Contact : IComparable<Contact>
    {   
        public String Name;
        public String Kurz;
        public String Standort;
        public String Kategorie;
        public String EMail;
        public String Tel;
        public String DepT;

        public Contact()
        {
            
        }
        public void setInformation(String Name, String Kurz, String Standort, String Kategorie, String EMail, String Tel, String DepT)
        {
            this.Name = Name;
            this.Kurz = Kurz;
            this.Standort = Standort;
            this.Kategorie = Kategorie;
            this.EMail = EMail;
            this.Tel = Tel;
            this.DepT = DepT;
        }

        public string getKurzel()
        {
            return this.Kurz;
        }
        public override String ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (String s in this) { b.Append(s); b.Append(";"); }
            return b.ToString();
        }

        public IEnumerator<String> GetEnumerator()
        {
            yield return this.Name;
            yield return this.Kurz;
            yield return this.Standort;
            yield return this.Kategorie;
            yield return this.EMail;
            yield return this.Tel;
            yield return this.DepT;
        }

        public int CompareTo(Contact other)
        {
            String.Compare(this.Name, other.Name);
            throw new ArgumentException();
        }

        public string convertToVCF()
        {
            string output = "";
            output += "BEGIN:VCARD" + System.Environment.NewLine;
            output += String.Format("N;CHARSET=ISO-8859-1:{0};;;;", this.Name) + System.Environment.NewLine;
            output += String.Format("ORG;CHARSET=ISO-8859-1:{0}", this.DepT) + System.Environment.NewLine;
            output += "X-ABShowAs:COMPANY" + System.Environment.NewLine;
            output += String.Format("ADR;TYPE=work,pref;CHARSET=ISO-8859-1:;/{0}", this.Standort) + System.Environment.NewLine;
            output += "69;Zuerich;ZH;8045;" + System.Environment.NewLine;
            output += "TEL;TYPE=work,voice,pref:+41444610055" + System.Environment.NewLine;
            output += "END:VCARD" + System.Environment.NewLine;
            return output;
        }
    }

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
                contact.setInformation(name, kurz, "", "", "", "", "");
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
    }

}