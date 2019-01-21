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

        public List<Broker> AgencyBrokers { get; set; }
        public List<Broker> EmployerBrokers { get; set; }

        public JobLead SelectedJobLead { get; set; }

        //public ICommand OpenJobLeadCommand { get; set; }

        public ICommand ExpandSearchCommand { get; set; }

        public ICommand DoSearchCommand { get; set; }

        public ICommand ShowAllLeadsCommand { get; set; }

        public ICommand ClearSearchAgencyCommand { get; set; }

        public ICommand ClearSearchEmployerCommand { get; set; }

        //A boolean flag to say if the search criteria are should be expanded.
        public bool SearchVisible { get; set; } = false;

        public string SearchJobTitle { get; set; }

        public string SearchAgencyName { get; set; }

        public string SearchEmployerName { get; set; }

        public string SearchReferenceValue { get; set; }

        public DateTime SearchStartDate { get; set; } =  DateTime.Today;
        public DateTime SearchEndDate { get; set; } = DateTime.Today;

        public bool SearchDateActive { get; set; } = true;
        public bool SearchJobTitleActive { get; set; } = true;
        public bool SearchJobRefereneceActive { get; set; } = true;
        public bool SearchAgencyNameActive { get; set; } = true;
        public bool SearchEmployerNameActive { get; set; } = true;


        public JobLeadsViewModel()
        {
            JobLeadRepo thisJobLeadRepo = new JobLeadRepo();

            try
            {


                JobGridData = thisJobLeadRepo.GetJobLeadGridDatasource();

                AgencyBrokers = thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == true).ToList();
                EmployerBrokers = thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == false).ToList();
            }
            catch(Exception ex)
            {

            }

            //OpenJobLeadCommand = new RelayCommand(OpenJobLead);

            ExpandSearchCommand = new RelayCommand(ExpandSearch);

            DoSearchCommand = new RelayCommand(DoSearch);

            ShowAllLeadsCommand = new RelayCommand(ShowAllLeads);

            ClearSearchAgencyCommand = new RelayCommand(ClearSearchAgencyValue);

            ClearSearchEmployerCommand = new RelayCommand(ClearSearchEmployerValue);

        }

        //public void OpenJobLead()
        //{
        //    //if(SelectedJobLeadID != null)
        //    if (SelectedJobLead != null)
        //    {
        //        var message = string.Format("{0} Selected", SelectedJobLead.JobLeadID);
        //        System.Windows.MessageBox.Show(message);

        //        //Take the selected job lead and add a tab to the main window to show the deatils.
        //        //MainWindowViewModel.Instance.Tabs.Add(new TabItem { Header="Job Lead", Type= TabItem.TabItemType.JobLeadDisplay, ViewModel= new SingleJobLeadViewModel { JobLead = SelectedJobLead } });
                

        //    }

        //}

        public void ExpandSearch()
        {
            SearchVisible ^= true;
        }

        public void DoSearch()
        { 

            //First, cast the List<JobLead> to an IEnumerable<JobLead>
            //as that is what the .Where(...) functions will work with
            //IEnumerable<JobLead> filteredJobLeads = JobGridData;
            JobLeadRepo thisJobLeadRepo = new JobLeadRepo();
            IEnumerable<JobLead> filteredJobLeads = thisJobLeadRepo.GetJobLeadGridDatasource();
            

            if(SearchJobTitleActive)
            {
                filteredJobLeads = thisJobLeadRepo.FilterByJobTitle(filteredJobLeads, SearchJobTitle);
            }

            if (SearchJobRefereneceActive)
            {
                filteredJobLeads = thisJobLeadRepo.FilterByJobReferenace(filteredJobLeads, SearchReferenceValue);
            }

            if(SearchAgencyNameActive)
            {
                filteredJobLeads = thisJobLeadRepo.FilterByAgency(filteredJobLeads, SearchAgencyName);
            }

            if(SearchEmployerNameActive)
            {
                filteredJobLeads = thisJobLeadRepo.FilterByEmployer(filteredJobLeads, SearchEmployerName);
            }
            
            if (SearchDateActive)
            {
                filteredJobLeads = thisJobLeadRepo.FilterByDate(filteredJobLeads, SearchStartDate, SearchEndDate);
            }

            //Finally, cast the IEnumerable<JobLead> back to a List<JobLead>
            JobGridData = filteredJobLeads.ToList();            

        }

        public void ShowAllLeads()
        {

            SearchDateActive = true;
            SearchJobTitleActive = true;
            SearchJobRefereneceActive = true;
            SearchAgencyNameActive = true;
            SearchEmployerNameActive = true;

            SearchAgencyName = "";
            SearchEmployerName = "";
            SearchEndDate = DateTime.Today;
            SearchStartDate = DateTime.Today;
            SearchJobTitle = "";
            SearchReferenceValue = "";

            JobLeadRepo thisJobLeadRepo = new JobLeadRepo();
            JobGridData = thisJobLeadRepo.GetJobLeadGridDatasource();
        }

        public void ClearSearchAgencyValue()
        {
            SearchAgencyName = "";
        }

        public void ClearSearchEmployerValue()
        {
            SearchEmployerName = "";
        }
    }
}
