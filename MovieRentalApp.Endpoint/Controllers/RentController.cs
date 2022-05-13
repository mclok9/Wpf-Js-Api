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
    public class RentController : ControllerBase
    {
        IRentLogic logic;
        IHubContext<SignalRHub> hub;

        public RentController(IRentLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Rent> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Rent Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Rent value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("RentCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Rent value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("RentUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rentToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("RentDeleted", rentToDelete);
        }
    }
}
