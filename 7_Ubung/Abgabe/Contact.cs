using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;

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
        
        public override String ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (String s in GetEnumerator()) { b.Append(s); b.Append(";"); }
            return b.ToString();
        }

        public String getTitleLine(){
            StringBuilder b = new StringBuilder();
            foreach (String s in GetFieldNames()) { b.Append(s); b.Append(";"); }
            return b.ToString();
        }

        public IEnumerable<String> GetEnumerator()
        {
            FieldInfo[] infos = this.GetType().GetFields();
            var array = new List<String>();
            foreach(FieldInfo info in infos){
                array.Add((string)info.GetValue(this));
            }
            return array;
        }

        public IEnumerable<String> GetFieldNames()
        {
            FieldInfo[] infos = this.GetType().GetFields();
            var array = new List<String>();
            foreach (FieldInfo info in infos){
                array.Add(info.Name);
            }
            return array;
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

        public void setFullInformation(String Name, String Kurz, String Standort, String Kategorie, String EMail, String Tel, String DepT)
        {
            this.Name = Name;
            this.Kurz = Kurz;
            this.Standort = Standort;
            this.Kategorie = Kategorie;
            this.EMail = EMail;
            this.Tel = Tel;
            this.DepT = DepT;
        }

        public void setFirstnameAndKurzel(String Name, String Kurz)
        {
            this.Name = Name;
            this.Kurz = Kurz;
            this.Standort = "";
            this.Kategorie = "";
            this.EMail = "";
            this.Tel = "";
            this.DepT = "";
        }

        public string getKurzel()
        {
            return this.Kurz;
        }

        public string getName()
        {
            return this.Name;
        }
    }

}