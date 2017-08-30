using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Job_Applications_WPF
{
    public class JobLeadsViewModel : BaseViewModel
    {
        //public object JobGridData { get; set;}
        public List<JobLead> JobGridData { get; set; }

        public JobLead SelectedJobLead { get; set; }

        public ICommand OpenJobLeadCommand { get; set; }

        public ICommand ExpandSearchCommand { get; set; }

        public ICommand DoSearchCommand { get; set; }

        //A boolean flag to say if the search criteria are should be expanded.
        public bool SearchVisible { get; set; } = false;

        public JobLeadsViewModel()
        {
            JobLeadRepo thisJobLeadRepo = new JobLeadRepo();             
            JobGridData = thisJobLeadRepo.GetJobLeadGridDatasource();

            /*
            //Experimental post filtering data.

            //First, cast the List<JobLead> to an IEnumerable<JobLead>
            //as that is what the .Where(...) functions will work with
            IEnumerable<JobLead> filteredJobLeads = JobGridData;

            //filteredJobLeads = filteredJobLeads.Where(m => m.AgencyBrokerID == 7);

            //A "like" operator
            //Regex regEx = new Regex("(?i)c#"); //The (?i) makes the pattern non case sensitive
            //filteredJobLeads = filteredJobLeads.Where(m => regEx.IsMatch(m.JobTitle));

            Regex regEx = new Regex("(?i)edge");
            filteredJobLeads = filteredJobLeads.Where(m => regEx.IsMatch(m.EmployerBroker.Name));

            Regex regEx2 = new Regex("(?i)ware");
            filteredJobLeads = filteredJobLeads.Where(m => regEx2.IsMatch(m.JobTitle));

            //Finally, cast the IEnumerable<JobLead> back to a List<JobLead>
            JobGridData = filteredJobLeads.ToList();
            
            //End of experimental post filtering
            */

            OpenJobLeadCommand = new RelayCommand(OpenJobLead);

            ExpandSearchCommand = new RelayCommand(ExpandSearch);

            DoSearchCommand = new RelayCommand(DoSearch);

        }

        public void OpenJobLead()
        {
            //if(SelectedJobLeadID != null)
            if (SelectedJobLead != null)
            {
                var message = string.Format("{0} Selected", SelectedJobLead.JobLeadID);
                System.Windows.MessageBox.Show(message);
            }
        }

        public void ExpandSearch()
        {
            SearchVisible ^= true;
        }

        public void DoSearch()
        {

        }
    }
}
