using C8KJ98_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Logic
{
    public interface IServicesLogic
    {
        Services GetService(int id);
        IEnumerable<Services> GetAllServices();
        void UpdateServiceCost(Services serv);
        public Services AddNewService(Services serv);
        public void DeleteService(int id);
    }
}
