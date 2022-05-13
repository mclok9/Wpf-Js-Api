using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieRentalApp.Models;
using MovieRentalApp.Logic;
using MovieRentalApp.Endpoint.Services;
using Microsoft.AspNetCore.SignalR;

namespace MovieRentalApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMovieLogic logic;
        IHubContext<SignalRHub> hub;

        public MovieController(IMovieLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Movie> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Movie Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Movie value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("MovieCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Movie value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("MovieUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var movieToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("MovieDeleted", movieToDelete);
        }
    }
}
