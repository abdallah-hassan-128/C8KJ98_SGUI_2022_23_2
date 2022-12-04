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
    public class ReservationsController: ControllerBase
    {
        IReservationsLogic RL;

        public ReservationsController(IReservationsLogic rL)
        {
            RL = rL;
        }

        // GET: /reservations
        [HttpGet]
        public IEnumerable<Reservations> Get()
        {
            return RL.GetAllReservations();
        }


        // GET /reservations/5
        [HttpGet("{id}")]
        public Reservations Get(int id)
        {
            return RL.GetReservation(id);
        }



        // DELETE /reservations/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RL.DeleteReservation(id);
        }
    }
}
