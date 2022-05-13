using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalApp.Models;

namespace MovieRentalApp.Logic
{
    public interface IRentLogic
    {
        void Create(Rent item);
        void Delete(int id);
        Rent Read(int id);
        IQueryable<Rent> ReadAll();
        void Update(Rent item);
    }
}
