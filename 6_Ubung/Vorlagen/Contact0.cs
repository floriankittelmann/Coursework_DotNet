public class Contact : IComparable<Contact>
    {
        public String Name;
        public String Kurz;
        public String Standort;
        public String Kategorie;
        public String EMail;
        public String Tel;
        public String DepT;
        public override String ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (String s in this) { b.Append(s); b.Append(";"); }
            return b.ToString();
        }

        public IEnumerator<String> GetEnumerator()
        {
            // TODO: implementiere Iteartor �ber alle Felder
            throw new NotImplementedException();
        }

        public Contact(/* TODO: Parameter f�r Konstruktor */ )
        {
            // TODO: setze Felder in Contact
            throw new NotImplementedException();
        }

        public int CompareTo(Contact other)
        {
            // TODO: Vergleiche Nachname, Name
            throw new NotImplementedException();
        }
    }
}