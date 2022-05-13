using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalApp.Models;
using MovieRentalApp.Repository;

namespace MovieRentalApp.Logic
{
    public class MovieLogic : IMovieLogic
    {
        IRepository<Movie> repo;

        public MovieLogic(IRepository<Movie> repo)
        {
            this.repo = repo;
        }

        public void Create(Movie item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Movie Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Movie> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Movie item)
        {
            this.repo.Update(item);
        }
    }
}
