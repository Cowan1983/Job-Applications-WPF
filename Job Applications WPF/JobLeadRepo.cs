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


                try
                {
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
                catch
                {
                    throw;
                }

            }
        }

        public List<Broker> GetBrokerGridDatasource()
        {

            using (var ctx = new JobLeadContext())
            {

                try
                {
                    List<Broker> allBrokers = ctx.Brokers
                                                .Include("Brokers")
                                                .Include("Contacts")
                                                .Include("Contacts.Name")
                                                .Include("Address")
                                                .OrderBy(m => m.Name)
                                                .ToList<Broker>();

                    return allBrokers;

                }
                catch
                {
                    throw;
                }

            }

        }

        public Broker GetBroker(int thisBrokerID)
        {
            using (var ctx = new JobLeadContext())
            {
                Broker thisBroker = ctx.Brokers
                    .Include("Address")
                    .Include("Contacts.Address")
                    .Include("Contacts.Name")
                    .Include("Contacts.ContactNotes")
                    .Include("Brokers")
                    .Include("BrokerNotes")
                    .Where(m => m.BrokerID == thisBrokerID)
                    .FirstOrDefault<Broker>();

                return thisBroker;
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
            //As there may be some Job Leads that do not have an agency (a direct application to an employer), we need to add in a "non-null" check.
            //If we do not have this, then this lamda will generate a null error.
            currentJobLeadList = currentJobLeadList.Where(m => m.AgencyBroker != null && regEx.IsMatch(m.AgencyBroker.Name));

            return currentJobLeadList;

        }

        public IEnumerable<JobLead> FilterByEmployer(IEnumerable<JobLead> currentJobLeadList, string filterString)
        {

            Regex regEx = new Regex("(?i)" + filterString);
            //As many Job Leads will not (initally) have an employer, we need to add in a "non-null" check.
            //If we do not have this, then this lamda will generate a null error.
            currentJobLeadList = currentJobLeadList.Where(m => m.EmployerBroker != null && regEx.IsMatch(m.EmployerBroker.Name));

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

        #region SaveFunctions

        public void SaveJobLead(JobLead myJobLead)
        {
            //We will do this within a single Context
            using (var ctx = new JobLeadContext())
            {

                //If we have a JobLeadID of 0 (zero), then this is a new job.
                if (myJobLead.JobLeadID == 0)
                {

                    var contextJobLeadEntity = ctx.JobLeads.Include("AgencyBroker").Include("AgencyContact").Include("EmployerBroker").Include("EmployerBroker").Where(s => s.JobLeadID == myJobLead.JobLeadID).FirstOrDefault<JobLead>();

                    if (myJobLead.AgencyBrokerID != 0)
                    {
                        var newBrokerEntity = ctx.Brokers.Where(s => s.BrokerID == myJobLead.AgencyBrokerID).FirstOrDefault<Broker>();
                        myJobLead.AgencyBroker = newBrokerEntity;
                    }

                    if (myJobLead.EmployerBrokerID != 0)
                    {
                        var newBrokerEntity = ctx.Brokers.Where(s => s.BrokerID == myJobLead.EmployerBrokerID).FirstOrDefault<Broker>();
                        myJobLead.EmployerBroker = newBrokerEntity;
                    }

                    if (myJobLead.AgencyContactID != 0)
                    {
                        var newContactEntity = ctx.Contacts.Where(s => s.ContactID == myJobLead.AgencyContactID).FirstOrDefault<Contact>();
                        myJobLead.AgencyContact = newContactEntity;
                    }

                    if (myJobLead.EmployerContactID != 0)
                    {
                        var newContactEntity = ctx.Contacts.Where(s => s.ContactID == myJobLead.EmployerContactID).FirstOrDefault<Contact>();
                        myJobLead.EmployerContact = newContactEntity;
                    }

                    //Now to iterate through the JobLeadNotes and add in any new ones
                    List<Note> contextNotesList = new List<Note>();
                    foreach (Note thisNote in myJobLead.JobLeadNotes)
                    {
                        //Get the context version of the current note
                        if (thisNote.NoteID != 0)
                        {
                            var newNoteEntity = ctx.Notes.Where(s => s.NoteID == thisNote.NoteID).FirstOrDefault<Note>();
                            contextNotesList.Add(newNoteEntity);
                        }

                    }

                    if (myJobLead.JobLeadNotes.Count() != 0)
                    {
                        myJobLead.JobLeadNotes = contextNotesList;
                    }

                    //Add it to the context.
                    ctx.JobLeads.Add((JobLead)myJobLead);

                }
                else //Otherwise we update the existing one.
                {
                    //First, get the whole job lead entity
                    var contextJobLeadEntity = ctx.JobLeads.Include("AgencyBroker").Include("AgencyContact").Include("EmployerBroker").Include("EmployerBroker").Where(s => s.JobLeadID == myJobLead.JobLeadID).FirstOrDefault<JobLead>();

                    //Set all the JobLead entity level values.
                    contextJobLeadEntity.Status = myJobLead.Status;
                    contextJobLeadEntity.JobTitle = myJobLead.JobTitle;
                    contextJobLeadEntity.Source = myJobLead.Source;
                    contextJobLeadEntity.CVOrApplicationLocation = myJobLead.CVOrApplicationLocation;
                    contextJobLeadEntity.CoverLetterLocation = myJobLead.CoverLetterLocation;
                    contextJobLeadEntity.Ref_One = myJobLead.Ref_One;
                    contextJobLeadEntity.Ref_Two = myJobLead.Ref_Two;
                    contextJobLeadEntity.Ref_Three = myJobLead.Ref_Three;
                    contextJobLeadEntity.JobLeadImage = myJobLead.JobLeadImage;

                    //Now we attach the AgentBroker, AgentContact, EmployerBroker and EmployerContact sub entities

                    if (myJobLead.AgencyBrokerID != 0)
                    {
                        var newBrokerEntity = ctx.Brokers.Where(s => s.BrokerID == myJobLead.AgencyBrokerID).FirstOrDefault<Broker>();
                        contextJobLeadEntity.AgencyBroker = newBrokerEntity;
                    }

                    if (myJobLead.EmployerBrokerID != 0)
                    {
                        var newBrokerEntity = ctx.Brokers.Where(s => s.BrokerID == myJobLead.EmployerBrokerID).FirstOrDefault<Broker>();
                        contextJobLeadEntity.EmployerBroker = newBrokerEntity;
                    }

                    if (myJobLead.AgencyContactID != 0)
                    {
                        var newContactEntity = ctx.Contacts.Where(s => s.ContactID == myJobLead.AgencyContactID).FirstOrDefault<Contact>();
                        contextJobLeadEntity.AgencyContact = newContactEntity;
                    }

                    if (myJobLead.EmployerContactID != 0)
                    {
                        var newContactEntity = ctx.Contacts.Where(s => s.ContactID == myJobLead.EmployerContactID).FirstOrDefault<Contact>();
                        contextJobLeadEntity.EmployerContact = newContactEntity;
                    }

                    //Now to iterate through the JobLeadNotes and add in any new ones
                    foreach (Note thisNote in myJobLead.JobLeadNotes)
                    {
                        //Get the context version of the current note
                        var newNoteEntity = ctx.Notes.Where(s => s.NoteID == thisNote.NoteID).FirstOrDefault<Note>();

                        //See if it is already attached to the context version of this job lead
                        if (!contextJobLeadEntity.JobLeadNotes.Contains(newNoteEntity))
                        {
                            contextJobLeadEntity.JobLeadNotes.Add(newNoteEntity);
                        }
                    }
                }

                //Finally, we save the changes to the changes made in the context.
                ctx.SaveChanges();

            }
        }

        #endregion


    }
}
