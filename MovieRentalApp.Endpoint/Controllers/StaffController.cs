using Microsoft.AspNetCore.Mvc;
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
    public class StaffController : ControllerBase
    {
        IStaffLogic logic;

        public StaffController(IStaffLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Staff value)
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
