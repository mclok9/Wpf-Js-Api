using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalApp.Models;

namespace MovieRentalApp.Repository
{
    public class RentRepository : Repository<Rent>, IRepository<Rent>
    {
        public RentRepository(MovieRentalDbContext ctx) : base(ctx)
        {

        }

        public override Rent Read(int id)
        {
            return ctx.Rents.FirstOrDefault(t => t.RentId == id);
        }

        public override void Update(Rent item)
        {
            var old = Read(item.RentId);

            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }

            ctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            var entity = this.Read(id);
            if (entity != null)
            {
                this.ctx.Set<Rent>().Remove(entity);
                this.ctx.SaveChanges();

                /*Renter deletedOneRenter;
                Movie deletedOneMovie = new Movie();
                Staff deletedOneStaff;


                foreach (var item in this.ctx.Set<Renter>())
                {
                    if (entity.RentId == item.RentId)
                    {
                        deletedOneRenter = item;
                        this.ctx.Set<Renter>().Remove(deletedOneRenter);
                        this.ctx.SaveChanges();
                    }
                }

                foreach (var item in this.ctx.Set<Movie>())
                {
                    if (entity.RentId == item.RentId)
                    {
                        deletedOneMovie = item;
                        this.ctx.Set<Movie>().Remove(deletedOneMovie);
                        this.ctx.SaveChanges();
                    }
                }

                foreach (var item in this.ctx.Set<Staff>())
                {
                    if (deletedOneMovie.MovieId == item.MovieId)
                    {
                        deletedOneStaff = item;
                        this.ctx.Set<Staff>().Remove(deletedOneStaff);
                        this.ctx.SaveChanges();
                    }
                }*/
            }
            
        }
    }
}
