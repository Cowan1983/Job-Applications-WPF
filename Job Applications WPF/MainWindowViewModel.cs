using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Job_Applications_WPF
{
    public class MainWindowViewModel : BaseViewModel
    {

        //private static MainWindowViewModel _instance = new MainWindowViewModel();
        private static MainWindowViewModel _instance;
        public static MainWindowViewModel Instance { get { return _instance; } }

        public ObservableCollection<TabItem> Tabs { get; set; }

        public ICommand AddTabCommand { get; set; }

        public ICommand AddExistingJobCommand { get; set; }

        public ICommand AddNewJobCommand { get; set; }

        //public ICommand RemoveTabCommand { get; set; }

        public int SelectedTabIndex { get; set; } = 1;

        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<TabItem>();

            Tabs.Add(new TabItem { Header = "Job Leads", Type = TabItem.TabItemType.JobLeadGrid, ViewModel = new JobLeadsViewModel()});

            AddTabCommand = new RelayCommand(AddNewTab);
            AddExistingJobCommand = new RelayParameterizedCommand((parameter) => AddExistingJob(parameter));
            AddNewJobCommand = new RelayCommand(AddNewJob);
            //RemoveTabCommand = new RelayCommand(RemoveTab);

            _instance = this;
        }

        public void AddNewTab(string header, TabItem.TabItemType type, BaseViewModel viewModel)
        {
            //Tabs.Add(new TabItem { Header = header, Type = type, ViewModel = viewModel });
        }

        public void AddNewTab()
        {
            Tabs.Add(new TabItem { Header = "Job Leads Again", Type = TabItem.TabItemType.JobLeadGrid, ViewModel = new JobLeadsViewModel() });
        }

        public void AddExistingJob(object existingJob)
        {
            if(existingJob is JobLead jobToShow)
            {
                Tabs.Add(new TabItem { Header = jobToShow.JobTitle, Type = TabItem.TabItemType.JobLeadDisplay, ViewModel = new SingleJobLeadViewModel(jobToShow) });
                //Set the selected tab to be the last one added
                SelectedTabIndex = Tabs.Count - 1;
            }
            
        }

        public void AddNewJob()
        {
            Tabs.Add(new TabItem { Header = "New Job Lead", Type = TabItem.TabItemType.JobLeadDisplay, ViewModel = new SingleJobLeadViewModel() });
            //Set the selected tab to be the last one added
            SelectedTabIndex = Tabs.Count - 1;
        }

        public void RemoveTab()
        {            
            
            //The tab we are removing is the currently selected tab.
            Tabs.RemoveAt(SelectedTabIndex);

        }

    }
}
