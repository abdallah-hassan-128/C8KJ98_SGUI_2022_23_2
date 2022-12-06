using C8KJ98_ADT_2022_23_1.Logic;
using C8KJ98_ADT_2022_23_1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationsServicesController:ControllerBase
    {
        IReservationsServicesLogic RSL;

        public ReservationsServicesController(IReservationsServicesLogic rSL)
        {
            RSL = rSL;
        }
        // GET: /ReservationsServices
        [HttpGet]
        public IEnumerable<ReservationsServices> Get()
        {
            return RSL.GetAllConnections();
        }


        // GET /ReservationsServices/5
        [HttpGet("{id}")]
        public ReservationsServices Get(int id)
        {
            return RSL.GetConnection(id); ;
        }

        // POST /reservationsservices
        [HttpPost]
        public void Post([FromBody] ReservationsServices value)
        {
            RSL.AddNewConnection(value);
        }

        // DELETE /ReservationsServices/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RSL.DeleteConnection(id);
        }
    }
}
