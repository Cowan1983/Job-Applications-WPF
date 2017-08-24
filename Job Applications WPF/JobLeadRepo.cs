using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Applications_WPF
{
    class JobLeadRepo
    {

        //public object GetJobLeadGridDatasource()
        public List<JobLead> GetJobLeadGridDatasource()
        {
            using (var ctx = new JobLeadContext())
            {
                //var allLeadsTable = from m in ctx.JobLeads
                //                    orderby m.JobLeadID descending
                //                    select new { m.JobLeadID, m.JobTitle, m.Date, m.Ref_One, m.Ref_Two, m.Ref_Three, Employer = m.EmployerBroker.Name, Agency = m.AgencyBroker.Name, Contact = m.AgencyContact.Name.FirstName + " " + m.AgencyContact.Name.Surname };

                //return allLeadsTable.ToList();

                List<JobLead> allJobLeads = ctx.JobLeads
                                            .Include("AgencyBroker")
                                            .Include("AgencyBroker.Brokers")
                                            .Include("AgencyBroker.Address")
                                            .Include("AgencyBroker.Contacts.Address")
                                            .Include("AgencyBroker.Contacts.Name")
                                            .Include("EmployerBroker")
                                            .Include("EmployerBroker.Brokers")
                                            .Include("EmployerBroker.Address")
                                            .Include("EmployerBroker.Contacts.Address")
                                            .Include("EmployerBroker.Contacts.Name") 
                                            .OrderByDescending(m => m.JobLeadID )
                                            .ToList<JobLead>();

                return allJobLeads;

            }
        }

    }
}
