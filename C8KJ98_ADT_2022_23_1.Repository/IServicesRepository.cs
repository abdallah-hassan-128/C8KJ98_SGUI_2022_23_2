using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C8KJ98_ADT_2022_23_1.Models;

namespace C8KJ98_ADT_2022_23_1.Repository
{
    public interface IServicesRepository : IRepository<Services>
    {
        void UpdatePrice(int id, int newPrice);
        void UpdateName(int id, string newName);
        void UpdateRating(int id, int newRating);

    }
}
