using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return await _context.Films
                    .Include(u => u.Acteurs)
                    .Include(u => u.Genre)
                    .Include(u => u.Realisateur)
                    .ToListAsync();
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
            if (id != film.Id)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            List<Acteur> dbActeurs;
            dbActeurs = new List<Acteur>();
            foreach (var acteurSent in film.Acteurs)
            {
                dbActeurs.Add(_context.Acteurs.Where(a => a.Id == acteurSent.Id).First());
            }

            film.Acteurs = [];
            film.Acteurs = dbActeurs;
            _context.Films.Add(film);
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
