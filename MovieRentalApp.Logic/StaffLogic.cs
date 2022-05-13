using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalApp.Models;
using MovieRentalApp.Repository;

namespace MovieRentalApp.Logic
{
    public class StaffLogic : IStaffLogic
    {
        IRepository<Staff> repo;

        public StaffLogic(IRepository<Staff> repo)
        {
            this.repo = repo;
        }

        public void Create(Staff item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Staff Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Staff> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Staff item)
        {
            this.repo.Update(item);
        }
    }
}
