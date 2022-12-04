﻿using C8KJ98_ADT_2022_23_1.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NoncrudforartistController: ControllerBase
    {
        IArtistsLogic AL;

        public NoncrudforartistController(IArtistsLogic aL)
        {
            AL = aL;
        }
        // GET: Noncrudforartist/Artistsearnings
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> Artistsearnings()
        {
            return AL.ArtistEarnings();
        }

        // GET: Noncrudforartist/MostPaid
        [HttpGet]
        public List<KeyValuePair<string, int>> MostPaid()
        {
            return AL.MostPaidArtist();
        }

        // GET: Noncrudforartist/LessPaid
        [HttpGet]
        public List<KeyValuePair<string, int>> LessPaid()
        {
            return AL.LessPaidArtist();
        }
    }
}
