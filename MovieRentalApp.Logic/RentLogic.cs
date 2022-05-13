using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalApp.Models;
using MovieRentalApp.Repository;

namespace MovieRentalApp.Logic
{
    public class RentLogic : IRentLogic
    {
        IRepository<Rent> repo;

        public RentLogic(IRepository<Rent> repo)
        {
            this.repo = repo;
        }

        public void Create(Rent item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Rent Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Rent> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Rent item)
        {
            this.repo.Update(item);
        }
    }
}
