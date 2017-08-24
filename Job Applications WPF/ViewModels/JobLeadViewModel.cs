using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

        public JobLeadsViewModel()
        {
            JobLeadRepo thisJobLeadRepo = new JobLeadRepo();             
            JobGridData = thisJobLeadRepo.GetJobLeadGridDatasource();

            OpenJobLeadCommand = new RelayCommand(OpenJobLead);

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
    }
}
