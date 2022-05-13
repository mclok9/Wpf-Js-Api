﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieRentalApp.Models;
using MovieRentalApp.Logic;

namespace MovieRentalApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RenterController : ControllerBase
    {
        IRenterLogic logic;

        public RenterController(IRenterLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Renter> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Renter Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Renter value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Renter value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
