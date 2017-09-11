using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Job_Applications_WPF
{
    public class Name
    {

        [Key]
        public int NameID { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }

        //Darn it! I don't know why I want a list of Contacts.
        //Perhaps it was some kind of foreign key thing.
        //public List<Contact> Contacts { get; set; }

        //Construtor that takes title, first, middle and last name
        public Name(string myTitle, string myFirstName, string myMiddleName, string mySurname)
        {
            Title = myTitle;
            FirstName = myFirstName;
            MiddleName = myMiddleName;
            Surname = mySurname;
        }

        //Constructor that takes title, first and last name
        //Just call the constructor that takes a middle name and pass an empty string for the middle name
        public Name(string myTitle, string myFirstName, string mySurname)
            : this(myTitle, myFirstName, "", mySurname)
        {
        }

        //Default constructor
        public Name() { }

        public string FullName
        {
            get
            {
                //Construct a name string, allowing for the middle name to be missing
                return Title + " " + FirstName + " " + (MiddleName != "" ? (MiddleName + " ") : "") + Surname;
            }
        }

    }
}
