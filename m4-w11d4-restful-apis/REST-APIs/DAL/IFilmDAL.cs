using REST_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_APIs.DAL
{
    public interface IFilmDAL
    {
        IList<Film> GetFilms();
        Film GetFilm(Guid id);

        void AddFilm(Film film);
        void UpdateFilm(Film film);

        void DeleteFilm(Guid id);

    }
}
