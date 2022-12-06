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
        protected  IReservationsServicesRepository _ReservationsServicesConnectionRepository;

        public ReservationsServicesLogic(IReservationsServicesRepository reservationsServicesConnectionRepository)
        {
            _ReservationsServicesConnectionRepository = reservationsServicesConnectionRepository;
        }

        public ReservationsServices AddNewConnection(ReservationsServices reserserv)
        {
            this._ReservationsServicesConnectionRepository.Add(reserserv);
            return reserserv;
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
