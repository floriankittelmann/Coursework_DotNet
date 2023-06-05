using System;
using Addressmanagement;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact firstContact = new Contact();
            firstContact.setInformation("Florian Kittelmann", "kitteflo", "Zürich", "IT", "kitteflo@students.zhaw.ch", "078 822 29 95", "Physics");
            Console.WriteLine(firstContact);

            string path = @"c:\Users\Flori\Documents\Studium\ZHAW_B_DotNet_Technologien_1\Übungen\6_Ubung\Vorlagen\";
            Contacts<Contact> addressbook = new Contacts<Contact>();
            addressbook.readCsv(path + "test.csv");
            addressbook.writeCsv(path + "testWrite.csv");
            addressbook.writeVCF(path);
            Console.WriteLine("finished");
        }
    }
}
