using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Job_Applications_WPF
{
    public class Address
    {

        [Key]
        public int AddressID { get; set; }

        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string BodyText { get; set; }

        //public List<Broker> Brokers { get; set; }
        //public List<Contact> Contacts { get; set; }

        //Constructor that takes all the address
        public Address(string myBodyText, string myCity, string myRegion, string myCountry, string myPostcode)
        {
            BodyText = myBodyText;
            City = myCity;
            Region = myRegion;
            Country = myCountry;
            Postcode = myPostcode;
        }

        public Address()
        {
        }

    }
}
