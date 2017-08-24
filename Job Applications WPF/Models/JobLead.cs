using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_Applications_WPF
{
    public class JobLead
    {
        //ID for Entity Framework to know the record by
        public int JobLeadID { get; set; }

        public string JobTitle { get; set; }
        public string Source { get; set; }

        //[ForeignKey ("Contact")]
        public int? AgencyContactID { get; set; }
        [ForeignKey("AgencyContactID")]
        public Contact AgencyContact { get; set; }

        //[ForeignKey("Contact")]
        public int? EmployerContactID { get; set; }
        [ForeignKey("EmployerContactID")]
        public Contact EmployerContact { get; set; }

        //[ForeignKey("Broker")]
        public int? AgencyBrokerID { get; set; }
        [ForeignKey("AgencyBrokerID")]
        public Broker AgencyBroker { get; set; }

        //[ForeignKey("Broker")]
        public int? EmployerBrokerID { get; set; }
        [ForeignKey("EmployerBrokerID")]
        public Broker EmployerBroker { get; set; }

        public DateTime Date { get; set; }
        public string CVOrApplicationLocation { get; set; }
        public string CoverLetterLocation { get; set; }
        public string Ref_One { get; set; }
        public string Ref_Two { get; set; }
        public string Ref_Three { get; set; }


        public JobLead()
        {
            Date = DateTime.Now;
        }

    }
}
