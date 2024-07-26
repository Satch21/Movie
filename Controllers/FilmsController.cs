using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly MovieContext _context;

        public FilmsController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Films
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetFilms()
        {
            return await _context.Films.Include(a=>a.Acteurs).ToListAsync();
        }

        // GET: api/Films/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(long id)
        {
            var film = await _context.Films.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            return film;
        }

        // PUT: api/Films/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(long id, Film film)
        {
            try
            {
                if (film.Acteurs != null)
                {
                    List<FilmActeur> dbActeurs;
                    dbActeurs = new List<FilmActeur>();
                    foreach (var acteurSent in film.Acteurs)
                    {
                        dbActeurs.Add(new FilmActeur() { FilmId = id, ActeurId = acteurSent.ActeurId });
                    }

                    Film filmDb = _context.Films.Where(f => f.Id == id).First();

                    var FilmActeurs = _context.Set<FilmActeur>().Where(a => a.FilmId == id).ToList();

                    foreach (var filmActeur in FilmActeurs)
                    {
                        _context.Set<FilmActeur>().Remove(filmActeur);
                    }
                    _context.SaveChanges();

                    foreach (var acteur in dbActeurs)
                    {
                        filmDb.Acteurs?.Add(acteur);
                        _context.SaveChanges();
                    }
                    _context.Entry(filmDb).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return CreatedAtAction("GetFilm", new { id = film.Id }, film);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Films
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Film>> PostFilm(Film film)
        {

            List<FilmActeur> dbActeurs;
            List<UtilisateurFilmNote> UtilisateursFilmsNotes;
            dbActeurs = new List<FilmActeur>();
            UtilisateursFilmsNotes = new List<UtilisateurFilmNote>();




            if (film.FilmsNotes != null)
            {
                foreach (var filmNotes in film.FilmsNotes)
                {
                    var utilisateur = _context.Utilisateurs.Where(u => u.Id == filmNotes.UtilisateurId).First();
                    filmNotes.Utilisateur = utilisateur;
                }
            }


            _context.Films.Add(film);

            _context.SaveChanges();

            if (film.Acteurs != null)
            {
                foreach (var acteurSent in film.Acteurs)
                {
                    dbActeurs.Add(new FilmActeur() { FilmId = film.Id, ActeurId = acteurSent.ActeurId });
                }

                film.Acteurs = [];
                film.Acteurs = dbActeurs;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.Id }, film);
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(long id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmExists(long id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}
