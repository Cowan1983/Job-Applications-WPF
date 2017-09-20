using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Applications_WPF
{
    /// <summary>
    /// The class for defining a tab item.
    /// </summary>
    public class TabItem
    {

        public enum TabItemType { JobLeadGrid, AgencyGrid, ContactGrid}

        /// <summary>
        /// The header for the tab in the tab control
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// The type type of user control to use for the tab content
        /// TO DO - PROBABLY SHOULD BE AN Enum
        /// </summary>
        public TabItemType Type { get; set; }

        /// <summary>
        /// The instance of the appropriate ViewModel to use for populating the View
        /// </summary>
        public BaseViewModel ViewModel { get; set; }

    }
}
