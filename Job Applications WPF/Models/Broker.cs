using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_Applications_WPF
{
    public class Broker
    {
        //A broker will have a list of contacts
        public List<Contact> Contacts { get; set; } = new List<Contact>();


        //If this is an Agency broker, this will be the list of employers they work with.
        //If this is an Employer broker, this will be the list of agencies they work with
        public List<Broker> Brokers { get; set; } = new List<Broker>();
        
        //This list seems to be required for EF to behave?
        //public List<JobLead> JobLeads { get; set; }

        [Key]
        public int BrokerID { get; set; }

        //A simple boolean to say if this broker is an agency (otherwise it is an employer)
        public bool IsAgency { get; set; }
        //public bool IsEmployer { get; set; }
        public string Name { get; set; }

        //public Address Address { get; set; }
        public int? AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address Address { get; set; }

        public string LandLineTelNo { get; set; }
        public string Website { get; set; }

    }
}
