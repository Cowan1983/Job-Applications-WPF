using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Applications_WPF
{
    class JobLeadListViewModel : BaseViewModel
    {

        /// <summary>
        /// The list of JobLead items in the list.
        /// </summary>
        public List<JobLeadItemViewModel> Items { get; set; }

        public JobLeadListViewModel()
        {
            Items = new List<JobLeadItemViewModel>()
            {
                new JobLeadItemViewModel()
                {
                    JobTitle = "New Job Title",
                    Ref_One = "aaa_bbb_ccc",
                    JobID = 1
                },

                new JobLeadItemViewModel()
                {
                    JobTitle = "Another New Job",
                    Ref_One = "eee_fff_ggg",
                    JobID = 2
                }

            };
        }

    }
}
