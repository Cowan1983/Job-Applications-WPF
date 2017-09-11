using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_Applications_WPF
{
    public class Contact
    {

        public string EMail { get; set; }

        [Key]
        public int ContactID { get; set; }

        public int? BrokerID { get; set; }
        [ForeignKey("BrokerID")]
        public Broker Broker { get; set; }

        public int? NameID { get; set; }
        [ForeignKey("NameID")]
        public Name Name { get; set; }

        public int? AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address Address { get; set; }

        public string Position { get; set; }
        public string MobileTelNo { get; set; }
        public string LandLineTelNo { get; set; }

        //public List<JobLead> JobLeads { get; set; }
        //public List<Broker> Brokers { get; set; }

        public List<Note> ContactNotes { get; set; } = new List<Note>(); 

        //Default constructor
        public Contact() { }

        //Full constructor
        public Contact(Name myName, Address myAddress, string myPosition, string myEmail, string myMobileNo, string myLandLineNo)
        {
            Name = myName;
            Address = myAddress;
            Position = myPosition;
            EMail = myEmail;
            MobileTelNo = myMobileNo;
            LandLineTelNo = myLandLineNo;

            //NameID = myName.NameID;
            //AddressID = myAddress.AddressID;
        }

        //Constructor that takes only a name and address
        public Contact(Name myName, Address myAddress)
            : this(myName, myAddress, "", "", "", "")
        {
        }

    }
}
