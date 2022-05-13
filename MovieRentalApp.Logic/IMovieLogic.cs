using System;
using System.Linq;
using MovieRentalApp.Models;

namespace MovieRentalApp.Logic
{
    public interface IMovieLogic
    {
        void Create(Movie item);
        void Delete(int id);
        Movie Read(int id);
        IQueryable<Movie> ReadAll();
        void Update(Movie item);
    }
}
