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
    public class StaffController : ControllerBase
    {
        IStaffLogic logic;
        IHubContext<SignalRHub> hub;

        public StaffController(IStaffLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Staff> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Staff Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Staff value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("StaffCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Staff value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("StaffUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var staffToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("StaffDeleted", staffToDelete);
        }
    }
}
