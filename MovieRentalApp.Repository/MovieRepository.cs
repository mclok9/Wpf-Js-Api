using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalApp.Models;

namespace MovieRentalApp.Repository
{
    public class MovieRepository : Repository<Movie>, IRepository<Movie>
    {
        public MovieRepository(MovieRentalDbContext ctx) : base(ctx)
        {

        }

        public override Movie Read(int id)
        {
            return ctx.Movies.FirstOrDefault(t => t.MovieId == id);
        }

        public override void Update(Movie item)
        {
            var old = Read(item.MovieId);
            
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

                foreach (var rent in this.ctx.Set<Rent>())
                {
                    if (id == rent.RentId)
                    {
                        this.ctx.Set<Rent>().Remove(rent);
                    }
                }

                
                    this.ctx.Set<Movie>().Remove(entity);
                    this.ctx.SaveChanges();
            }
        }
    }
}
