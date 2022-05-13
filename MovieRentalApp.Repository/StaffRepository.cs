using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalApp.Models;

namespace MovieRentalApp.Repository
{
    public class StaffRepository : Repository<Staff>, IRepository<Staff>
    {
        public StaffRepository(MovieRentalDbContext ctx) : base(ctx)
        {

        }

        public override Staff Read(int id)
        {
            return ctx.Staffs.FirstOrDefault(t => t.StaffId == id);
        }

        public override void Update(Staff item)
        {
            var old = Read(item.StaffId);

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
