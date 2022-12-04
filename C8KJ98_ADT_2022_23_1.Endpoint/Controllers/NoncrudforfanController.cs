using C8KJ98_ADT_2022_23_1.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NoncrudforfanController : ControllerBase 
    {
        IFansLogic FL;

        public NoncrudforfanController(IFansLogic fL)
        {
            FL = fL;
        }
        // GET: Noncrudforfan/Best
        [HttpGet]
        public List<KeyValuePair<int, int>> Best()
        {
            return FL.BestFan();
        }

        // GET: Noncrudforfan/worse
        [HttpGet]
        public List<KeyValuePair<int, int>> Worse()
        {
            return FL.WorstFan();
        }

        // GET: Noncrudforfan/Reservationsum
        [HttpGet("{id}")]
        public int Reservationsum(int id)
        {
            return FL.ReservationsNumber(id);
        }
    }
}
