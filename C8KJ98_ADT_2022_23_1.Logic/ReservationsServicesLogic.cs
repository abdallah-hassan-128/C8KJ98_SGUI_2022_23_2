using C8KJ98_ADT_2022_23_1.Models;
using C8KJ98_ADT_2022_23_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Logic
{
    public class ReservationsServicesLogic:IReservationsServicesLogic
    {
        private readonly IReservationsServicesRepository _ReservationsServicesConnectionRepository;

        public ReservationsServicesLogic(IReservationsServicesRepository reservationsServicesConnectionRepository)
        {
            _ReservationsServicesConnectionRepository = reservationsServicesConnectionRepository;
        }

        public ReservationsServices AddNewConnection(int reservationId, int serviceId)
        {
            ReservationsServices ConnectionToAdd = new ReservationsServices() { ReservationId = reservationId, ServiceId = serviceId };
            this._ReservationsServicesConnectionRepository.Add(ConnectionToAdd);
            return ConnectionToAdd;
        }
        public void DeleteConnection(int id)
        {
            ReservationsServices ConnectionToDelete = this._ReservationsServicesConnectionRepository.GetOne(id);
            if (ConnectionToDelete != null)
            {
                this._ReservationsServicesConnectionRepository.Delete(ConnectionToDelete);
            }
        }
        public IEnumerable<ReservationsServices> GetAllConnections()
        {
            return this._ReservationsServicesConnectionRepository.GetAll();
        }
        public ReservationsServices GetConnection(int id)
        {
            ReservationsServices ReservationsServicesToReturn = this._ReservationsServicesConnectionRepository.GetOne(id);
            if (ReservationsServicesToReturn != null)
            {
                return ReservationsServicesToReturn;
            }
            else
            {
                throw new Exception("This ID can't be found on our ReservationsServicesDatabase.");
            }
        }
    }
}
