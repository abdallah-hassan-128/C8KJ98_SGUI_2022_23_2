using C8KJ98_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Logic
{
    public interface IReservationsServicesLogic
    {
        public ReservationsServices AddNewConnection(ReservationsServices reservserv);
        public void DeleteConnection(int id);
        public ReservationsServices GetConnection(int id);
        public IEnumerable<ReservationsServices> GetAllConnections();

    }
}
