using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;

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
        private int EnumoratorIndex = 0;

        public Contact()
        {
            
        }
        
        public override String ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (String s in this) { b.Append(s); b.Append(";"); }
            return b.ToString();
        }

        public IEnumerator<String> GetEnumerator()
        {
            Type tp = this.GetType();
            FieldInfo[] f = tp.GetFields();
            String output = (String)f.GetValue(EnumoratorIndex);
            if (EnumoratorIndex <= 6) {
                EnumoratorIndex++;
            } else {
                EnumoratorIndex = 0;
            }
            yield return output;
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