using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalApp.Models;

namespace MovieRentalApp.Logic
{
    public interface IRenterLogic
    {
        void Create(Renter item);
        void Delete(int id);
        Renter Read(int id);
        IQueryable<Renter> ReadAll();
        void Update(Renter item);
    }
}
