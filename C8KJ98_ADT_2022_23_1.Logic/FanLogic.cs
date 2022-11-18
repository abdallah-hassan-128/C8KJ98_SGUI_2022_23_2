﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C8KJ98_ADT_2022_23_1.Models;
using C8KJ98_ADT_2022_23_1.Repository;

namespace C8KJ98_ADT_2022_23_1.Logic
{
   public class FanLogic : IFanLogic
    {
        private readonly IReservationsRepository _ReservationsRepository;
        private readonly IFansRepository _FansRepository;
        private readonly IReservationsServicesRepository _ReservationsServicesConnectionRepository;
        public FanLogic(IReservationsRepository reservationsRepo, IFansRepository fansRepo, IReservationsServicesRepository reservationsServicesConnectionRepo)
        {
            _ReservationsRepository = reservationsRepo;
            _FansRepository = fansRepo;
            _ReservationsServicesConnectionRepository = reservationsServicesConnectionRepo;
        }
        public void UpdateCity(int id, string newCity)
        {
            this._FansRepository.UpdateCity(id, newCity);
        }
        public void UpdateEmail(int id, string newEmail)
        {
            this._FansRepository.UpdateEmail(id, newEmail);
        }
        public void UpdatePhone(int id, int NewPhoneNumber)
        {
            this._FansRepository.UpdatePhone(id, NewPhoneNumber);
        }
        public void UpdateOrderDate(int id, DateTime newDate)
        {
            this._ReservationsRepository.UpdateDate(id, newDate);
        }
        public Fans AddNewFan(string city, string email, string name, int phoneNumber)
        {
            Fans NewFan = new Fans() { City = city, Email = email, Name = name, PhoneNumber = phoneNumber };
            this._FansRepository.Add(NewFan);
            return NewFan;
        }
        public void DeleteFan(int id)
        {
            Fans FanToDelete = this._FansRepository.GetOne(id);
            if (FanToDelete != null)
            {
                this._FansRepository.Delete(FanToDelete);
            }
        }
        public Reservations AddNewReservation(int fanId, int artistId, DateTime dateTime)
        {
            Reservations ReservationToAdd = new Reservations() { FanId = fanId, ArtistId = artistId, DateTime = dateTime };
            this._ReservationsRepository.Add(ReservationToAdd);
            return ReservationToAdd;
        }
        public void DeleteReservation(int id)
        {
            Reservations ReservationToDelete = this._ReservationsRepository.GetOne(id);
            if (ReservationToDelete != null)
            {
                this._ReservationsRepository.Delete(ReservationToDelete);
            }
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

    }
}
