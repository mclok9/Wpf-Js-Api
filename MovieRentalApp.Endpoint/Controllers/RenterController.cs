using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieRentalApp.Models;
using MovieRentalApp.Logic;
using Microsoft.AspNetCore.SignalR;
using MovieRentalApp.Endpoint.Services;

namespace MovieRentalApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RenterController : ControllerBase
    {
        IRenterLogic logic;
        IHubContext<SignalRHub> hub;

        public RenterController(IRenterLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("RenterCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Renter value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("RenterUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var renterToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("RenterDeleted", renterToDelete);
        }
    }
}
