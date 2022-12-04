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
    public class ArtistsController: ControllerBase
    {
        IArtistsLogic AL;
        public ArtistsController(IArtistsLogic aL)
        {
            AL = aL;
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



        // DELETE /artists/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AL.DeleteArtist(id);
        }
    }
}
