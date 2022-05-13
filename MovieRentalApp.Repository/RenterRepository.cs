using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalApp.Models;

namespace MovieRentalApp.Repository
{
    public class RenterRepository : Repository<Renter>, IRepository<Renter>
    {
        public RenterRepository(MovieRentalDbContext ctx) : base(ctx)
        {

        }

        public override Renter Read(int id)
        {
            return ctx.Renters.FirstOrDefault(t => t.RenterId == id);
        }

        public override void Update(Renter item)
        {
            var old = Read(item.RenterId);

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
