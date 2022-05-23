using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApp.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected MovieRentalDbContext ctx;

        public Repository(MovieRentalDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public abstract void Delete(int id);

        public abstract T Read(int id);
        public abstract void Update(T item);
    }
}
