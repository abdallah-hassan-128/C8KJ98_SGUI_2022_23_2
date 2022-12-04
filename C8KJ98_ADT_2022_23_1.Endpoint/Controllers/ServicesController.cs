﻿using C8KJ98_ADT_2022_23_1.Logic;
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
    public class ServicesController:ControllerBase
    {
        IServicesLogic SL;
        public ServicesController(IServicesLogic sL)
        {
            SL = sL;
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



        // DELETE /Services/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SL.DeleteService(id);
        }
    }
}