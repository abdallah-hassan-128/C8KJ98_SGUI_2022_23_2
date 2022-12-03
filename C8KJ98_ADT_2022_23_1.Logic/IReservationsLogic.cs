using C8KJ98_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Logic
{
    public interface IReservationsLogic
    {
        void UpdateReservationDate(int id, DateTime newDate);
        public Reservations AddNewReservation(int fanId, int artistId, DateTime dateTime);
        public void DeleteReservation(int id);
        Reservations GetReservation(int id);
        IEnumerable<Reservations> GetAllReservations();
    }
}
