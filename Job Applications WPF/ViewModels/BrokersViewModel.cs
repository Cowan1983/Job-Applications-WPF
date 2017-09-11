using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Applications_WPF
{ 
    public class BrokersViewModel : BaseViewModel
    {
        public List<Broker> BrokerGridData { get; set; }

        public Broker SelectedBroker { get; set; }

        public BrokersViewModel()
        {
            JobLeadRepo thisJobLeadRepo = new JobLeadRepo();
            BrokerGridData = thisJobLeadRepo.GetBrokerGridDatasource();
        }
    }
}
