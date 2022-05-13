using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalApp.Models;

namespace MovieRentalApp.Logic
{
    public interface IStaffLogic
    {
        void Create(Staff item);
        void Delete(int id);
        Staff Read(int id);
        IQueryable<Staff> ReadAll();
        void Update(Staff item);
    }
}
