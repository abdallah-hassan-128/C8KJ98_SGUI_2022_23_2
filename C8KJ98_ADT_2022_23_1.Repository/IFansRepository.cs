using C8KJ98_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Repository
{
    public interface IFansRepository:IRepository<Fans>
    {
        void UpdateCity(int id, string newcity);
        
    }
}
