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
    public class ArtistsController: ControllerBase
    {
        IArtistsLogic AL;
        IHubContext<SignalRHub> hub;
        public ArtistsController(IArtistsLogic aL, IHubContext<SignalRHub> hub)

        {
            AL = aL;
            this.hub = hub;

        }

        // GET: /artists
        [HttpGet]
        public IEnumerable<Artists> Get()
        {
            return AL.GetAllArtists();
        }

        // GET /artists/5
        [HttpGet("{id}")]
        public Artists Get(int id)
        {
            return AL.GetArtist(id);
        }

        // POST /artists
        [HttpPost]
        public void Post([FromBody] Artists value)
        {
            AL.AddNewArtist(value);
            this.hub.Clients.All.SendAsync("ArtistCreated", value);

        }


        // PUT /artists
        [HttpPut]
        public void Put([FromBody] Artists value)
        {
            AL.UpdateArtistCost(value);
            this.hub.Clients.All.SendAsync("ArtistUpdated", value);

        }


        // DELETE /artists/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var artistToDelete = this.AL.GetArtist(id);
            AL.DeleteArtist(id);
            this.hub.Clients.All.SendAsync("ArtistDeleted", artistToDelete);


        }
    }
}






