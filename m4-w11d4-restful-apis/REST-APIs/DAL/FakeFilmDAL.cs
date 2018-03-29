using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REST_APIs.Models;

namespace REST_APIs.DAL
{
    public class FakeFilmDAL : IFilmDAL
    {
        private static IList<Film> films = new List<Film>()
        {
            new Film() { Id = Guid.NewGuid(), Title = "Star Wars: A New Home", Description = "A boy befiends a bearded hermit and hangs out with two robots.", ImdbId = "tt0076759", Rating = "PG", YearReleased = 1977},
            new Film() { Id = Guid.NewGuid(), Title = "The Little Mermaid", Description = "A half-fish, half-woman sells her vocal chords for some random guy.", ImdbId = "tt0097757", Rating = "G", YearReleased = 1989},
            new Film() { Id = Guid.NewGuid(), Title = "The Lion King", Description = "Hamlet with Lions, but better...and with singing.", ImdbId = "tt0110357", Rating = "G", YearReleased = 1994},
            new Film() { Id = Guid.NewGuid(), Title = "X-Men", Description = "Patrick Stewart sets up a school for dangerous adolescents where none of the staff have any actual teaching qualifications.", ImdbId = "tt0120903", Rating = "PG-13", YearReleased = 2000},

        };

        public void AddFilm(Film film)
        {
            film.Id = Guid.NewGuid();
            films.Add(film);
        }

        public void DeleteFilm(Guid id)
        {
            var selectedFilm = films.FirstOrDefault(f => f.Id == id);
            if (selectedFilm != null)
            {
                films.Remove(selectedFilm);
            }
        }

        public Film GetFilm(Guid id)
        {
            return films.FirstOrDefault(f => f.Id == id);
        }

        public IList<Film> GetFilms()
        {
            return films.ToList();
        }

        public void UpdateFilm(Film film)
        {
            var filmToUpdate = films.FirstOrDefault(f => f.Id == film.Id);

            if (filmToUpdate != null)
            {
                filmToUpdate.Title = film.Title;
                filmToUpdate.ImdbId = film.ImdbId;
                filmToUpdate.Rating = film.Rating;
                filmToUpdate.YearReleased = film.YearReleased;
                filmToUpdate.Description = film.Description;
            }
        }
    }
}