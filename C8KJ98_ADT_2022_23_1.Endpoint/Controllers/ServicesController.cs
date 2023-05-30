using C8KJ98_ADT_2022_23_1.Logic;
using C8KJ98_ADT_2022_23_1.Models;
using C8KJ98_ADT_2022_23_1.Endpoint.services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace C8KJ98_ADT_2022_23_1.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServicesController:ControllerBase
    {
        IServicesLogic SL;
        IHubContext<SignalRHub> hub;

        public ServicesController(IServicesLogic sL, IHubContext<SignalRHub> hub)
        {
            SL = sL;
            this.hub = hub;

        }
        // GET: /Services
        [HttpGet]
        public IEnumerable<Services> Get()
        {
            return SL.GetAllServices();
        }


        // GET /services/5
        [HttpGet("{id}")]
        public Services Get(int id)
        {
            return SL.GetService(id);
        }

        // POST /services
        [HttpPost]
        public void Post([FromBody] Services value)
        {
            SL.AddNewService(value);
            this.hub.Clients.All.SendAsync("ServiceCreated", value);

        }


        // PUT /services
        [HttpPut]
        public void Put([FromBody] Services value)
        {
            SL.UpdateServiceCost(value);
            this.hub.Clients.All.SendAsync("ServiceUpdated", value);

        }



        // DELETE /Services/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var artistToDelete = this.SL.GetService(id);
            SL.DeleteService(id);
            this.hub.Clients.All.SendAsync("ServiceDeleted", artistToDelete);


        }
    }
}
