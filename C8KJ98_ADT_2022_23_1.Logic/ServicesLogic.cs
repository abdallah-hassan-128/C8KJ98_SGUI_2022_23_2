﻿using C8KJ98_ADT_2022_23_1.Models;
using C8KJ98_ADT_2022_23_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Logic
{
    public class ServicesLogic:IServicesLogic
    {
        protected  IServicesRepository _ServicesRepository;

        public ServicesLogic(IServicesRepository servicesRepository)
        {
            _ServicesRepository = servicesRepository;
        }

        public void UpdateServiceCost(Services serv)
        {
            this._ServicesRepository.UpdatePrice(serv.Id, serv.Price);
        }
        public IEnumerable<Services> GetAllServices()
        {
            return this._ServicesRepository.GetAll();
        }
        public Services GetService(int id)
        {
            Services ServiceToReturn = this._ServicesRepository.GetOne(id);
            if (ServiceToReturn != null)
            {
                return ServiceToReturn;
            }
            else
            {
                throw new Exception("This ID can't be found on our ServicesDatabase.");
            }
        }

        public Services AddNewService(Services serv)
        {
            if (serv.Name == null)
            {
                throw new ArgumentException("ERROR : Please provide a Name");
            }
            else
            {
                this._ServicesRepository.Add(serv);
                return serv;
            }

        }
        public void DeleteService(int id)
        {
            Services ServiceToDelete = this._ServicesRepository.GetOne(id);
            if (ServiceToDelete != null)
            {
                this._ServicesRepository.Delete(ServiceToDelete);
            }
            else
            {
                throw new Exception("This ID can't be found on our ServicesDatabase.");
            }
        }
    }
}
