using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Applications_WPF
{
    public class TabItem
    {

        /// <summary>
        /// An enum for the different user controls to be shown in a tab
        /// </summary>
        public enum TabItemType { JobLeadGrid, AgencyGrid, ContactGrid, JobLeadDisplay};

        /// <summary>
        /// The text to be shown in the Tab header
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// The type of user control to use for the tab content
        /// </summary>
        public TabItemType Type { get; set; }

        /// <summary>
        /// The instance of the appropriate ViewModel to use for populating the View
        /// </summary>
        public BaseViewModel ViewModel { get; set; }

    }
}
