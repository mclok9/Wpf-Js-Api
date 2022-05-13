using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalApp.Models;
using MovieRentalApp.Repository;

namespace MovieRentalApp.Logic
{
    public class RenterLogic : IRenterLogic
    {
        IRepository<Renter> repo;

        public RenterLogic(IRepository<Renter> repo)
        {
            this.repo = repo;
        }

        public void Create(Renter item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Renter Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Renter> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Renter item)
        {
            this.repo.Update(item);
        }
    }
}
