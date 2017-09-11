using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                                            .Include("AgencyBroker.Contacts.ContactNotes")
                                            .Include("EmployerBroker")
                                            .Include("EmployerBroker.Brokers")
                                            .Include("EmployerBroker.Address")
                                            .Include("EmployerBroker.Contacts.Address")
                                            .Include("EmployerBroker.Contacts.Name")
                                            .Include("EmployerBroker.Contacts.ContactNotes")
                                            .Include("JobLeadNotes")
                                            .OrderByDescending(m => m.JobLeadID)
                                            .ToList<JobLead>();

                return allJobLeads;

            }
        }

        public List<Broker> GetBrokerGridDatasource()
        {

            using (var ctx = new JobLeadContext())
            {
                List<Broker> allBrokers = ctx.Brokers
                                            .Include("Brokers")
                                            .Include("Contacts")
                                            .Include("Address")
                                            .OrderBy(m => m.Name)
                                            .ToList<Broker>();

                return allBrokers;

            }

        }

        #region JobLead Filter Functions

        public IEnumerable<JobLead> FilterByJobTitle(IEnumerable<JobLead> currentJobLeadList, string filterString)
        {

            Regex regEx = new Regex("(?i)" + filterString);
            currentJobLeadList = currentJobLeadList.Where(m => regEx.IsMatch(m.JobTitle));

            return currentJobLeadList;
        }

        public IEnumerable<JobLead> FilterByJobReferenace(IEnumerable<JobLead> currentJobLeadList, string filterString)
        {

            Regex regEx = new Regex("(?i)" + filterString);
            currentJobLeadList = currentJobLeadList.Where(m => regEx.IsMatch(m.Ref_One) || regEx.IsMatch(m.Ref_Two) || regEx.IsMatch(m.Ref_Three));

            return currentJobLeadList;

        }

        public IEnumerable<JobLead> FilterByAgency(IEnumerable<JobLead> currentJobLeadList, string filterString)
        {

            Regex regEx = new Regex("(?i)" + filterString);            
            currentJobLeadList = currentJobLeadList.Where(m => regEx.IsMatch(m.AgencyBroker.Name));            

            return currentJobLeadList;

        }

        public IEnumerable<JobLead> FilterByEmployer(IEnumerable<JobLead> currentJobLeadList, string filterString)
        {

            Regex regEx = new Regex("(?i)" + filterString);
            currentJobLeadList = currentJobLeadList.Where(m => regEx.IsMatch(m.EmployerBroker.Name));

            return currentJobLeadList;

        }

        public IEnumerable<JobLead> FilterByDate(IEnumerable<JobLead> currentJobLeadList, DateTime startDate, DateTime endDate)
        {
            //Add 24 to the end date as it will be 00:00:00 on that day.
            //If the start and end days are the same, we would get nothing returned.
            endDate = endDate.AddHours(23).AddMinutes(59).AddSeconds(59);

            currentJobLeadList = currentJobLeadList.Where(m => m.Date > startDate && m.Date < endDate);

            return currentJobLeadList;

        }

        #endregion

    }
}
