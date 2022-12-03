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
        void UpdateServiceCost(int serviceId, int cost);
        public Services AddNewService(string name, int price, int rating);
        public void DeleteService(int id);
    }
}
