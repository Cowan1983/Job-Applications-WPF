using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Job_Applications_WPF
{
    class JobLeadItemViewModel : BaseViewModel
    {

        public string JobTitle { get; set; }

        public string Ref_One { get; set; }

        public int JobID { get; set; }

        public ICommand OpenJobLeadCommand { get; set; }

        public JobLeadItemViewModel()
        {
            OpenJobLeadCommand = new RelayCommand(OpenJobLead);
        }

        public void OpenJobLead()
        {
            MessageBox.Show("Asked for Job Lead " + JobID);
        }

    }
}
