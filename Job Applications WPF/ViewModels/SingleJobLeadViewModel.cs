using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Job_Applications_WPF
{
    class SingleJobLeadViewModel : BaseViewModel
    {

        public JobLead JobLead { get; set; }

        //public ObservableCollection<Broker> AgencyBrokers
        //{
        //    get
        //    {
        //        SetupBrokerDropdownLists();
        //        return AgencyBrokers;
        //    }
        //    set { }
        //}

        //public ObservableCollection<Broker> EmployerBrokers
        //{
        //    get
        //    {
        //        SetupBrokerDropdownLists();
        //        return EmployerBrokers;
        //    }
        //    set { }
        //}

        public ObservableCollection<Broker> EmployerBrokers { get; set; }
        public ObservableCollection<Broker> AgencyBrokers { get; set; }
        public ObservableCollection<Contact> AgencyContacts { get; set; }
        public ObservableCollection<Contact> EmployerContacts { get; set; }

        public ICommand SaveAndUpdateJobLeadCommand { get; set; }
        public ICommand CancelAndCloseJobLeadCommand { get; set; }


        //private ICollectionView employerBrokersView;
        //private ObservableCollection<Broker> employerBrokers;
        //public ObservableCollection<Broker> EmployerBrokers
        //{
        //    get
        //    {
        //        return employerBrokers;
        //    }
        //}

        //private ICollectionView agencyBrokersView;
        //private ObservableCollection<Broker> agencyBrokers;
        //public ObservableCollection<Broker> AgencyBrokers
        //{
        //    get
        //    {
        //        return agencyBrokers;
        //    }
        //}

        //public Broker SelectedAgency { get; set; }
        //public Broker SelectedEmployer { get; set; }

        private Broker selectedAgency;
        public Broker SelectedAgency
        {
            get
            {
                return selectedAgency;
            }
            set
            {
                selectedAgency = value;
                //SetupBrokerDropdownLists();
                SetupAgencyDropdownLists();
            }
        }

        private Broker selectedEmployer;
        public Broker SelectedEmployer
        {
            get
            {
                return selectedEmployer;
            }
            set
            {
                selectedEmployer = value;
                //SetupBrokerDropdownLists();
                SetupEmployerDropdownList();
            }
        }

        public Contact SelectedAgencyContact { get; set; }
        public Contact SelectedEmployerContact { get; set; }

        public SingleJobLeadViewModel() : this(new JobLead())
        {
            /*
            JobLead = new JobLead();                      

            SetupBrokerDropdownLists();
            */


            //AgencyBrokers = new ObservableCollection<Broker>();
            //EmployerBrokers = new ObservableCollection<Broker>();  

            //JobLeadRepo thisJobLeadRepo = new JobLeadRepo();

            //AgencyBrokers = new ObservableCollection<Broker>(thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == true).ToList());
            //EmployerBrokers = new ObservableCollection<Broker>(thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == false).ToList());
        }

        public SingleJobLeadViewModel(JobLead myJobLead)
        {
            JobLead = myJobLead;

            //EmployerBrokers = new ObservableCollection<Broker>();
            //EmployerBrokers.Add(JobLead.EmployerBroker);

            //SelectedAgency = JobLead.AgencyBroker;
            //SelectedEmployer = JobLead.EmployerBroker;
            selectedAgency = JobLead.AgencyBroker;
            selectedEmployer = JobLead.EmployerBroker;
            SelectedAgencyContact = JobLead.AgencyContact;
            SelectedEmployerContact = JobLead.EmployerContact;

            SaveAndUpdateJobLeadCommand = new RelayCommand(SaveJobLead);
            CancelAndCloseJobLeadCommand = new RelayCommand(CloseJobLead);

            //SetupBrokerDropdownLists();
            SetupAgencyDropdownLists();
            SetupEmployerDropdownList();

        }


        private void CloseJobLead()
        {
            //Just remove the tab with this job lead 
            MainWindowViewModel.Instance.RemoveTab();
        }

        private void SaveJobLead()
        {
            JobLead.AgencyBrokerID = selectedAgency == null ? (int?)null : selectedAgency.BrokerID;
            JobLead.EmployerBrokerID = selectedEmployer == null ? (int?)null : selectedEmployer.BrokerID;
            JobLead.AgencyContactID = SelectedAgencyContact == null ? (int?)null : SelectedAgencyContact.ContactID;
            JobLead.EmployerContactID = SelectedEmployerContact == null ? (int?)null : SelectedEmployerContact.ContactID;

            JobLeadRepo thisJobLeadRepo = new JobLeadRepo();
            thisJobLeadRepo.SaveJobLead(JobLead);

            //Remove the tab with this job lead.
            MainWindowViewModel.Instance.RemoveTab();

        }

        private void SetupAgencyDropdownLists()
        {
            //This is all interdependent on if there is a selected agency and/or employer. And a selected agency contact

            //NOTE: WHEN WE ARE FILTERING THE LIST, WE WILL BE REMOVING FROM THE EXISTING LIST, NOT CLEARING AND REPOPULATING
            //IF WE DID THAT, THE Selection_Changed EVEN WILL BE TRIGGERED AGAIN.

            //1
            //If we have a selected agency, the drop down list has one entry.
            //Set up the agency contact list to show the contacts for this agency
            if(selectedAgency != null)
            {
                //If the AgencyBrokers list has not been set up (if this is an existing job), we just add this one agency to
                //the list
                if (AgencyBrokers == null)
                {
                    AgencyBrokers = new ObservableCollection<Broker>();
                    AgencyBrokers.Add(selectedAgency);
                }
                else
                if ((AgencyBrokers.Contains(selectedAgency)) && (AgencyBrokers.Count > 1))
                {

                    ////Remove all other agency brokers from the list
                    //foreach(Broker thisAgencyBroker in AgencyBrokers)
                    //{
                    //    if(thisAgencyBroker != selectedAgency)
                    //    {
                    //        AgencyBrokers.Remove(thisAgencyBroker);
                    //    }
                    //}

                    while (AgencyBrokers.Count > 1)
                    {
                        int existingIndex = AgencyBrokers.IndexOf(selectedAgency);
                        if(existingIndex>0)
                        {
                            AgencyBrokers.RemoveAt(0);
                        }
                        else
                        {
                            AgencyBrokers.RemoveAt(1);
                        }
                    }
                    
                }

                SetupEmployerDropdownList();

                //Populate the Agency Contacts list
                AgencyContacts = new ObservableCollection<Contact>(selectedAgency.Contacts.ToList());

                //Our work is done. Exit the function
                return;
            }

            //2
            //If we have a selected employer, but not a selected agency the list has the agencies associated with that employer
            if(selectedEmployer != null)
            {
                AgencyBrokers = new ObservableCollection<Broker>(selectedEmployer.Brokers.ToList());
                
                //Our work is done. Exit the function.
                return;
            }

            //3
            //If we have neither a selected agency or employer, list all the agencies.
            JobLeadRepo thisJobLeadRepo = new JobLeadRepo();
            AgencyBrokers = new ObservableCollection<Broker>(thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == true).ToList());


        }

        private void SetupEmployerDropdownList()
        {
            //This is all interdependent on if there is a selected agency and/or employer. And a selected employer contact

            //1
            //If we have a selected emplyer, the drop down list has one entry.
            //Set up the employer contact list to show the contacts for this employer
            if(selectedEmployer != null)
            {
                //If the EmployerBrokers list has not been set up (if this is an existing job), we just add this one employer to
                //the list
                if (EmployerBrokers == null)
                {
                    EmployerBrokers = new ObservableCollection<Broker>();
                    EmployerBrokers.Add(selectedEmployer);
                }
                else
                if ((EmployerBrokers.Contains(selectedEmployer)) && (EmployerBrokers.Count > 1))
                {

                    //Remove all other employers from the list
                    //foreach (Broker thisEmployerBroker in EmployerBrokers)
                    //{
                    //    if(thisEmployerBroker != selectedEmployer)
                    //    {
                    //        EmployerBrokers.Remove(thisEmployerBroker);
                    //    }
                    //}

                    while (EmployerBrokers.Count > 1)
                    {
                        int existingIndex = EmployerBrokers.IndexOf(selectedEmployer);
                        if (existingIndex > 0)
                        {
                            EmployerBrokers.RemoveAt(0);
                        }
                        else
                        {
                            EmployerBrokers.RemoveAt(1);
                        }
                    }

                }

                //Populate the Employer Contacts list
                EmployerContacts = new ObservableCollection<Contact>(selectedEmployer.Contacts.ToList());

                //Our work is done. Exit the function.
                return;
            }

            //2
            //If we have a selected agency, but not a selected employer the list has the employers associated with that agency
            if(selectedAgency != null)
            {
                EmployerBrokers = new ObservableCollection<Broker>(selectedAgency.Brokers.ToList());

                //Our work is done. Exit the function.
                return;
            }

            //3
            //If we have neither a selected agency or employer, list all the employers. 
            JobLeadRepo thisJobLeadRepo = new JobLeadRepo();
            EmployerBrokers = new ObservableCollection<Broker>(thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == false).ToList());

        }

        private void SetupBrokerDropdownLists()
        {

            JobLeadRepo thisJobLeadRepo = new JobLeadRepo();

            //If both lists are empty, we have a new job lead, so initialise both list will all the brokers
            //If either, or both, are populated, we are working with existing data
            if((AgencyBrokers == null) && (EmployerBrokers == null))
            {
                AgencyBrokers = new ObservableCollection<Broker>(thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == true).ToList());
                EmployerBrokers = new ObservableCollection<Broker>(thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == false).ToList());
            }

            //The basic premiss is this.
            //We DO NOT create a newObservableCollection<Broker> if we have a selected item in that list that is in the list - we just remove all the others - If we create a new list, we don't, we trigger another SelectionChanged event as the item disappears
            //We filter a list based on the the selected item in the other list.

            if(selectedAgency != null)
            {
                //Filter the Agency list down to one entry

                //Filter the Employer list down to the associated employers

            }

            if(selectedEmployer != null)
            {
                //Filter the Employer list down to one entry

                //Filter the Agency list down to the associated agencies

            }



            #region Non-working CollectionView use
            //if(agencyBrokers == null)
            //{
            //    agencyBrokers = new ObservableCollection<Broker>(thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == true).ToList());
            //    agencyBrokersView = CollectionViewSource.GetDefaultView(agencyBrokers);
            //}

            //if (employerBrokers == null)
            //{
            //    employerBrokers = new ObservableCollection<Broker>(thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == false).ToList());
            //    employerBrokersView = CollectionViewSource.GetDefaultView(employerBrokers);
            //}

            ////Do we have a selected agency?
            ////Yes, we need to filter the Employer collection and make this the only entry in the Agency collection
            //if(selectedAgency != null)
            //{
            //    agencyBrokersView.Filter = item =>
            //    {
            //        Broker f = item as Broker;
            //        if (f.BrokerID == selectedAgency.BrokerID) return true;
            //        return false;
            //    };
            //    //agencyBrokers = (ObservableCollection<Broker>)agencyBrokersView;
            //    //agencyBrokers = (ObservableCollection<Broker>)agencyBrokersView.Cast<Broker>();
            //    agencyBrokers = agencyBrokersView
            //}
            #endregion

            #region Old (working - kind of) Code
            /*
            if (selectedAgency == null)
            {
                if (selectedEmployer == null)
                {
                    AgencyBrokers = new ObservableCollection<Broker>(thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == true).ToList());
                    EmployerBrokers = new ObservableCollection<Broker>(thisJobLeadRepo.GetBrokerGridDatasource().Where(m => m.IsAgency == false).ToList());

                }
                else
                {
                    AgencyBrokers = new ObservableCollection<Broker>(selectedEmployer.Brokers.ToList());

                    if (!EmployerBrokers.Contains(selectedEmployer))
                    {
                        EmployerBrokers = new ObservableCollection<Broker>();
                        EmployerBrokers.Add(selectedEmployer);
                    }
                }
            }
            else
            {
                if (!AgencyBrokers.Contains(selectedAgency))
                {
                    AgencyBrokers = new ObservableCollection<Broker>();
                    AgencyBrokers.Add(selectedAgency);
                }

                if (JobLead.EmployerBroker == null)
                {
                    EmployerBrokers = new ObservableCollection<Broker>(selectedAgency.Brokers.ToList());
                }
                else
                {
                    if (!EmployerBrokers.Contains(selectedEmployer))
                    {
                        EmployerBrokers = new ObservableCollection<Broker>();
                        EmployerBrokers.Add(selectedEmployer);
                    }
                }
            }
            */
            #endregion

        }

    }
}
