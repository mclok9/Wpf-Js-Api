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
    }
}
