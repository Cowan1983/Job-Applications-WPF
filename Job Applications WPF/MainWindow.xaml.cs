using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Job_Applications_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //RunTestData();
        }

        private JobLeadContext AttachContacts(JobLeadContext myJobLeadContext, List<Contact> myContactsList)
        {

            foreach(Contact thisContact in myContactsList)
            {
                myJobLeadContext.Contacts.Attach(thisContact);
            }

            return myJobLeadContext;

        }

        private void RunTestData()
        {
            
            
            //using (var ctx = new JobLeadContext())
            //{
                //12 Names
                Name name_01 = new Name("Mr", "Andrew", "John", "McDonald");
                Name name_02 = new Name("Professor", "William", "Henry", "Maitland");
                Name name_03 = new Name("Miss", "Fiona", "Shirley", "Edwards");
                Name name_04 = new Name("Mr", "Brian", "Ian", "Jones");
                Name name_05 = new Name("Dr", "Mary", "Edith", "Fforbes");
                Name name_06 = new Name("Miss", "July", "Margret", "Denby");
                Name name_07 = new Name("Mr", "Oliver", "Peter", "Henrikson");
                Name name_08 = new Name("Ms", "Audrey", "Louise", "Monks");
                Name name_09 = new Name("Mr", "Malcolm", "Frank", "Noble");
                Name name_10 = new Name("Miss", "Edith", "Veronica", "Simons");
                Name name_11 = new Name("Dr", "James", "Scott");
                Name name_12 = new Name("Professor", "Kate", "Leslie", "Brown");

            using (var ctx = new JobLeadContext())
            {
                ctx.Names.Add(name_01);
                    ctx.Names.Add(name_02);
                    ctx.Names.Add(name_03);
                    ctx.Names.Add(name_04);
                    ctx.Names.Add(name_05);
                    ctx.Names.Add(name_06);
                    ctx.Names.Add(name_07);
                    ctx.Names.Add(name_08);
                    ctx.Names.Add(name_09);
                    ctx.Names.Add(name_10);
                    ctx.Names.Add(name_11);
                    ctx.Names.Add(name_12);

                    ctx.SaveChanges();
                }

                //8 Addresses
                Address address_01 = new Address("38/2 Prince Regent Street,\nLeith", "Edinburgh", "Lothian", "UK", "EH6 4AT");
                Address address_02 = new Address("Suite 5,\n2Commercial Street,\nLeith", "Edinburgh", "Lothan", "Scotland", "EH6 6JA");
                Address address_03 = new Address("4 Kittle Yards,\nCausewayside,\nNewington", "Edinburgh", "Lothian", "Britain", "EH9 1PJ");
                Address address_04 = new Address("23/23a Dalmeny Street", "Edinburgh", "East Lothian", "UK", "EH6 8PJ");
                Address address_05 = new Address("113 West Regent Street", "Glasgow", "Strathclyde", "Scotland", "G2 2RU");
                Address address_06 = new Address("7 Castle Street", "Edinburgh", "Lothian", "UK", "EH2 3AP");
                Address address_07 = new Address("9 Colme Street", "Edinburgh", "West Lothian", "Britain", "EH3 6AA");
                Address address_08 = new Address("17A South Gyle Crescent", "Edinburgh", "Scotland", "Mid Lothian", "EH12 9FL");

                using (var ctx = new JobLeadContext())
                {
                    ctx.Addresses.Add(address_01);
                    ctx.Addresses.Add(address_02);
                    ctx.Addresses.Add(address_03);
                    ctx.Addresses.Add(address_04);
                    ctx.Addresses.Add(address_05);
                    ctx.Addresses.Add(address_06);
                    ctx.Addresses.Add(address_07);
                    ctx.Addresses.Add(address_08);

                    ctx.SaveChanges();
                }

                //12 Contacts
                Contact contact_01 = new Contact(name_01, address_01, "Associate", "A.J.McDonald@there.com", "077739614", "0131 652 7359");
                Contact contact_02 = new Contact(name_02, address_02, "Department Head", "WilliamHMaitland@edin.ac,uk", "", "0131 391 2519");
                Contact contact_03 = new Contact(name_03, address_03, "Recruiter", "EdwardsFS@ouside.co.uk", "077183962", "0131 724 2975");
                Contact contact_04 = new Contact(name_04, address_04, "Manager", "BIJ@where.com", "077163615", "0131 272 4725");
                Contact contact_05 = new Contact(name_05, address_05, "Development Director", "M.Fforbes@wherever.co.uk", "077253951", "0141 263 2748");
                Contact contact_06 = new Contact(name_06, address_06, "HR Director", "Denby.July@elsewhere.com", "077451835", "0131 263 1462");
                Contact contact_07 = new Contact(name_07, address_07, "Placement Officer", "Oliver.Henrikson@newplace.co.uk", "", "");
                Contact contact_08 = new Contact(name_08, address_08, "Consultant", "AudreyMonks@whoknows.co.uk", "077253194", "");
                Contact contact_09 = new Contact(name_09, address_04, "Lead Recruiter", "MFN@where.com", "077451736", "0131 272 4720");
                Contact contact_10 = new Contact(name_10, address_07);
                Contact contact_11 = new Contact(name_11, address_04, ".NET Recruiter", "JLS@where.com", "077369643", "0131 272 4722");
                Contact contact_12 = new Contact(name_12, address_05, "Team Leader", "K.Brown@wherever.co.uk", "077254951", "0141 263 2724");

                using (var ctx = new JobLeadContext())
                {
                ctx.Names.Attach(contact_01.Name);
                ctx.Addresses.Attach(contact_01.Address);
                ctx.Contacts.Add(contact_01);
                ctx.Names.Attach(contact_02.Name);
                ctx.Addresses.Attach(contact_02.Address);
                ctx.Contacts.Add(contact_02);
                ctx.Names.Attach(contact_03.Name);
                ctx.Addresses.Attach(contact_03.Address);
                ctx.Contacts.Add(contact_03);
                ctx.Names.Attach(contact_04.Name);
                ctx.Addresses.Attach(contact_04.Address);
                ctx.Contacts.Add(contact_04);
                ctx.Names.Attach(contact_05.Name);
                ctx.Addresses.Attach(contact_05.Address);
                ctx.Contacts.Add(contact_05);
                ctx.Names.Attach(contact_06.Name);
                ctx.Addresses.Attach(contact_06.Address);
                ctx.Contacts.Add(contact_06);
                ctx.Names.Attach(contact_07.Name);
                ctx.Addresses.Attach(contact_07.Address);
                ctx.Contacts.Add(contact_07);
                ctx.Names.Attach(contact_08.Name);
                ctx.Addresses.Attach(contact_08.Address);
                ctx.Contacts.Add(contact_08);
                ctx.Names.Attach(contact_09.Name);
                ctx.Addresses.Attach(contact_09.Address);
                ctx.Contacts.Add(contact_09);
                ctx.Names.Attach(contact_10.Name);
                ctx.Addresses.Attach(contact_10.Address);
                ctx.Contacts.Add(contact_10);
                ctx.Names.Attach(contact_11.Name);
                ctx.Addresses.Attach(contact_11.Address);
                ctx.Contacts.Add(contact_11);
                ctx.Names.Attach(contact_12.Name);
                ctx.Addresses.Attach(contact_12.Address);
                ctx.Contacts.Add(contact_12);

                    ctx.SaveChanges();

                }

                //2 Employer Brokers
                Broker employerBroker_01 = new Broker();
                employerBroker_01.IsAgency = false;
                employerBroker_01.Name = "Bleeding Edge Development.";
                employerBroker_01.Address = address_02;
                //employerBroker_01.AddressID = address_02.AddressID;
                employerBroker_01.LandLineTelNo = "0131 391 2500";
                employerBroker_01.Website = @"www.NewOps.co.uk";
                employerBroker_01.Contacts.Add(contact_02);

                Broker employerBroker_02 = new Broker();
                employerBroker_02.IsAgency = false;
                employerBroker_02.Name = "Blue Sky Solutions.";
                employerBroker_02.Address = address_05;
                //employerBroker_02.AddressID = address_05.AddressID;
                employerBroker_02.LandLineTelNo = "0141 263 2700";
                employerBroker_02.Website = @"www.BlueSkySolutions.com";
                employerBroker_02.Contacts.Add(contact_05);
                employerBroker_02.Contacts.Add(contact_12);

                //4 Agency Brokers
                Broker agencyBroker_01 = new Broker();
                agencyBroker_01.IsAgency = true;
                agencyBroker_01.Name = "New Doors.";
                agencyBroker_01.Address = address_01;
                //agencyBroker_01.AddressID = address_01.AddressID;
                agencyBroker_01.LandLineTelNo = "0131 652 7300";
                agencyBroker_01.Website = @"www.NewDoorsLtd.co.uk";
                agencyBroker_01.Contacts.Add(contact_01);

                Broker agencyBroker_02 = new Broker();
                agencyBroker_02.IsAgency = true;
                agencyBroker_02.Name = "First Chance.";
                agencyBroker_02.Address = address_03;
                //agencyBroker_02.AddressID = address_03.AddressID;
                agencyBroker_02.LandLineTelNo = "0131 724 2900";
                agencyBroker_02.Website = @"www.FirstChance.co.uk";
                agencyBroker_02.Contacts.Add(contact_03);

                Broker agencyBroker_03 = new Broker();
                agencyBroker_03.IsAgency = true;
                agencyBroker_03.Name = "Finnly & Associates.";
                agencyBroker_03.Address = address_04;
                //agencyBroker_03.AddressID = address_04.AddressID;
                agencyBroker_03.LandLineTelNo = "0131 272 4700";
                agencyBroker_03.Website = @"www.FinnlyAndAssociates.com";
                agencyBroker_03.Contacts.Add(contact_04);
                agencyBroker_03.Contacts.Add(contact_09);
                agencyBroker_03.Contacts.Add(contact_11);

                Broker agencyBroker_04 = new Broker();
                agencyBroker_04.IsAgency = true;
                agencyBroker_04.Name = "IT Solutions Limited.";
                agencyBroker_04.Address = address_06;
                //agencyBroker_04.AddressID = address_06.AddressID;
                agencyBroker_04.LandLineTelNo = "0131 263 1462";
                agencyBroker_04.Website = @"www.ITSolutionsLtd.co.uk";
                agencyBroker_04.Contacts.Add(contact_06);

                //As we are connecting brokers to brokers, we could not join them until after they have all been created.
                employerBroker_01.Brokers.Add(agencyBroker_01);
                employerBroker_01.Brokers.Add(agencyBroker_03);

                employerBroker_02.Brokers.Add(agencyBroker_02);
                employerBroker_02.Brokers.Add(agencyBroker_03);
                employerBroker_02.Brokers.Add(agencyBroker_04);

                agencyBroker_01.Brokers.Add(employerBroker_01);

                agencyBroker_02.Brokers.Add(employerBroker_02);

                agencyBroker_03.Brokers.Add(employerBroker_01);
                agencyBroker_03.Brokers.Add(employerBroker_02);

                agencyBroker_04.Brokers.Add(employerBroker_02);

                using (var ctx = new JobLeadContext())
                {
                employerBroker_01.Contacts.ForEach(x => ctx.Contacts.Attach(x));
                ctx.Addresses.Attach(employerBroker_01.Address);
                employerBroker_02.Contacts.ForEach(x => ctx.Contacts.Attach(x));
                ctx.Addresses.Attach(employerBroker_02.Address);
                agencyBroker_01.Contacts.ForEach(x => ctx.Contacts.Attach(x));
                ctx.Addresses.Attach(agencyBroker_01.Address);
                agencyBroker_02.Contacts.ForEach(x => ctx.Contacts.Attach(x));
                ctx.Addresses.Attach(agencyBroker_02.Address);
                agencyBroker_03.Contacts.ForEach(x => ctx.Contacts.Attach(x));
                ctx.Addresses.Attach(agencyBroker_03.Address);
                agencyBroker_04.Contacts.ForEach(x => ctx.Contacts.Attach(x));
                ctx.Addresses.Attach(agencyBroker_04.Address);

                //In reality, we will also need to "Attach" any associated Broker(s).
                //We don't (can't?) do it here as all the Brokers will be in the
                //Context before we save.

                ctx.Brokers.Add(employerBroker_01);
                
                ctx.Brokers.Add(employerBroker_02);
                
                ctx.Brokers.Add(agencyBroker_01);
                
                ctx.Brokers.Add(agencyBroker_02);
                
                ctx.Brokers.Add(agencyBroker_03);
                
                ctx.Brokers.Add(agencyBroker_04);


                ctx.SaveChanges();

                }

            Note jobNote_01 = new Note("First Job Note");
            Note jobNote_02 = new Note("Second Job Note");
            Note jobNote_03 = new Note("Third Job Note");
            Note jobNote_04 = new Note("Fourth Job Note");
            Note jobNote_05 = new Note("Fith Job Note");
            Note jobNote_06 = new Note("Sixth Job Note");

            using (var ctx = new JobLeadContext())
            {
                ctx.Notes.Add(jobNote_01);
                ctx.Notes.Add(jobNote_02);
                ctx.Notes.Add(jobNote_03);
                ctx.Notes.Add(jobNote_04);
                ctx.Notes.Add(jobNote_05);
                ctx.Notes.Add(jobNote_06);

                ctx.SaveChanges();
            }


            //2 Job Leads
            JobLead jobLead_01 = new JobLead();
                jobLead_01.JobTitle = ".NET Software Engineer";
                jobLead_01.AgencyBroker = agencyBroker_01;
                //jobLead_01.AgencyBrokerID = agencyBroker_01.BrokerID;
                jobLead_01.AgencyContact = contact_01;
                //jobLead_01.AgencyContactID = contact_01.ContactID;
                jobLead_01.EmployerBroker = employerBroker_01;
                //jobLead_01.EmployerBrokerID = employerBroker_01.BrokerID;
                jobLead_01.EmployerContact = contact_02;
                //jobLead_01.EmployerContactID = contact_02.ContactID;
                jobLead_01.CoverLetterLocation = @"C:\Jobs\Applications\JobLeadOneCover.doc";
                jobLead_01.CVOrApplicationLocation = @"C:\Jobs\CV\CV.Doc";
                jobLead_01.Ref_One = @"Job01\0023";
                jobLead_01.Ref_Two = @"ABC-xyz-123";
                jobLead_01.Ref_Three = @"JobOne Ref 3";
                jobLead_01.Source = @"www.JobsNow.co.uk\002345\abc.aspx";
                jobLead_01.Status = "Open";
                jobLead_01.JobLeadNotes.Add(jobNote_01);
                jobLead_01.JobLeadNotes.Add(jobNote_04);


                JobLead jobLead_02 = new JobLead();
                jobLead_02.JobTitle = "C# Developer";
                jobLead_02.AgencyBroker = agencyBroker_03;
                //jobLead_02.AgencyBrokerID = agencyBroker_03.BrokerID;
                jobLead_02.AgencyContact = contact_09;
                //jobLead_02.AgencyContactID = contact_09.ContactID;
                jobLead_02.EmployerBroker = employerBroker_02;
                //jobLead_02.EmployerBrokerID = employerBroker_02.BrokerID;
                jobLead_02.EmployerContact = contact_05;
                //jobLead_02.EmployerContactID = contact_05.ContactID;
                jobLead_02.CoverLetterLocation = @"C:\Jobs\Applications\JobLeadTwoCover.doc";
                jobLead_02.CVOrApplicationLocation = @"C:\Jobs\Applications\JobLeadTwoApplication.doc";
                jobLead_02.Ref_One = @"Job Two Ref One";
                jobLead_02.Ref_Two = @"JKL\004\TRW\09-34";
                jobLead_02.Ref_Three = @"Job34-0034";
                jobLead_02.Source = @"www.jobFinder.com\flax0034\job23.aspx";
                jobLead_02.Status = "Suspended";
                jobLead_02.JobLeadNotes.Add(jobNote_02);

                using (var ctx = new JobLeadContext())
                {
                ctx.Contacts.Attach(jobLead_01.AgencyContact);
                ctx.Contacts.Attach(jobLead_01.EmployerContact);
                ctx.Brokers.Attach(jobLead_01.AgencyBroker);
                ctx.Brokers.Attach(jobLead_01.EmployerBroker);
                ctx.Notes.Attach(jobNote_01);
                ctx.Notes.Attach(jobNote_04);
                ctx.JobLeads.Add(jobLead_01);

                ctx.Contacts.Attach(jobLead_02.AgencyContact);
                ctx.Contacts.Attach(jobLead_02.EmployerContact);
                ctx.Brokers.Attach(jobLead_02.AgencyBroker);
                ctx.Brokers.Attach(jobLead_02.EmployerBroker);
                ctx.Notes.Attach(jobNote_02);
                ctx.JobLeads.Add(jobLead_02);

                    ctx.SaveChanges();
                }

                JobLead currentJobLead;

                using (var ctx = new JobLeadContext())
                {
                    //currentJobLead = ctx.JobLeads.Include("AgencyContact").Where(s => s.JobLeadID == 1).FirstOrDefault<JobLead>();
                    currentJobLead = ctx.JobLeads.Where(s => s.JobLeadID == 1).FirstOrDefault<JobLead>();
                }

                if (currentJobLead != null)
                {
                    currentJobLead.JobTitle = "Changed Title";
                    currentJobLead.AgencyContact = contact_11;
                    currentJobLead.AgencyContactID = contact_11.ContactID;
                }

                using (var ctx = new JobLeadContext())
                {
                    ctx.Entry(currentJobLead).State = System.Data.Entity.EntityState.Modified;

                    //ctx.Contacts.Attach(currentJobLead.AgencyContact);
                    //ctx.Contacts.Attach(currentJobLead.EmployerContact);
                    //ctx.Brokers.Attach(currentJobLead.AgencyBroker);
                    //ctx.Brokers.Attach(currentJobLead.EmployerBroker);

                    ctx.SaveChanges();

                }

                using (var ctx = new JobLeadContext())
                {
                    currentJobLead = ctx.JobLeads.Include("AgencyContact").Where(s => s.JobLeadID == 1).FirstOrDefault<JobLead>();
                    //currentJobLead = ctx.JobLeads.Where(s => s.JobLeadID == 1).FirstOrDefault<JobLead>();
                }

                JobLead jobLead_03 = new JobLead();
                jobLead_03.JobTitle = "New C# Developer";
                jobLead_03.AgencyBroker = agencyBroker_01;
                //jobLead_03.AgencyBrokerID = agencyBroker_01.BrokerID;
                jobLead_03.AgencyContact = contact_02;
                //jobLead_03.AgencyContactID = contact_02.ContactID;
                jobLead_03.EmployerBroker = employerBroker_02;
                //jobLead_03.EmployerBrokerID = employerBroker_02.BrokerID;
                jobLead_03.EmployerContact = contact_09;
                //jobLead_03.EmployerContactID = contact_09.ContactID;
                jobLead_03.CoverLetterLocation = @"C:\Jobs\Applications\JobLeadThreeCover.doc";
                jobLead_03.CVOrApplicationLocation = @"C:\Jobs\Applications\JobLeadThreeApplication.doc";
                jobLead_03.Ref_One = @"Job Three Ref One";
                jobLead_03.Ref_Two = @"JKL\012\TRW\09-23";
                jobLead_03.Ref_Three = @"Job09-0023";
                jobLead_03.Source = @"www.jobFinder.com\flax0034\job090023.aspx";
                jobLead_03.Status = "Closed";
                jobLead_03.JobLeadNotes.Add(jobNote_03);
                jobLead_03.JobLeadNotes.Add(jobNote_05);
                jobLead_03.JobLeadNotes.Add(jobNote_06);


            using (var ctx = new JobLeadContext())
                {

                ctx.Contacts.Attach(jobLead_03.AgencyContact);
                ctx.Contacts.Attach(jobLead_03.EmployerContact);
                ctx.Brokers.Attach(jobLead_03.AgencyBroker);
                ctx.Brokers.Attach(jobLead_03.EmployerBroker);
                ctx.Notes.Attach(jobNote_03);
                ctx.Notes.Attach(jobNote_05);
                ctx.Notes.Attach(jobNote_06);

                ctx.JobLeads.Add(jobLead_03);

                    ctx.SaveChanges();
                }
            //}

            JobLead thisJobLead;

            using (var ctx = new JobLeadContext())
            {                
                thisJobLead = ctx.JobLeads.Where(s => s.JobLeadID == 1).FirstOrDefault<JobLead>();
                thisJobLead = ctx.JobLeads.Where(s => s.JobLeadID == 3).FirstOrDefault<JobLead>();
            }

            

        }
        
    }
}
