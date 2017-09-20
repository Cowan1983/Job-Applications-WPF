using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Applications_WPF
{
    public class MainWindowViewModel : BaseViewModel
    {

        public ObservableCollection<TabItem> Tabs { get; set; }

        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<TabItem>();

            //By default add a JobLeadListControl to the tab control
            Tabs.Add(new TabItem { Header = "Job Leads", Type = TabItem.TabItemType.JobLeadGrid, ViewModel = new JobLeadsViewModel() });

            //TO DO - ADD BROKER AND CONTACT LIST CONTROLS

        }


        public void AddNewTab()
        {

        }

        public void RemoveTab()
        {

        }

    }
}
