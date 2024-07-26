//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Movie.Models;

//namespace Movie.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FilmActeursController : ControllerBase
//    {
//        private readonly MovieContext _context;

//        public FilmActeursController(MovieContext context)
//        {
//            _context = context;
//        }

//        // GET: api/FilmActeurs
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<FilmActeur>>> GetFilmActeur()
//        {
//            return await _context.FilmActeur.ToListAsync();
//        }

//        // GET: api/FilmActeurs/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<FilmActeur>> GetFilmActeur(long id)
//        {
//            var filmActeur = await _context.FilmActeur.FindAsync(id);

//            if (filmActeur == null)
//            {
//                return NotFound();
//            }

//            return filmActeur;
//        }

//        // PUT: api/FilmActeurs/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutFilmActeur(long id, FilmActeur filmActeur)
//        {
//            if (id != filmActeur.FilmId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(filmActeur).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!FilmActeurExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/FilmActeurs
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<FilmActeur>> PostFilmActeur(FilmActeur filmActeur)
//        {

//            var Film = _context.Films.First(i => i.Id == filmActeur.FilmId);
//            var Acteur = _context.Acteurs.First(i => i.Id == filmActeur.ActeurId);
            
//            //TODO gérer si film ou acteur non existant

//            var FilmActeur = new FilmActeur
//            {
//                FilmId = Film.Id,
//                ActeurId = Acteur.Id
//            };


//            _context.SaveChanges();

//            try
//            {
//                _context.FilmActeur.Add(filmActeur);
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateException)
//            {
//                if (FilmActeurExists(filmActeur.FilmId))
//                {
//                    return Conflict();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtAction("GetFilmActeur", new { id = filmActeur.FilmId }, filmActeur);

//        }

//        // DELETE: api/FilmActeurs/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteFilmActeur(long id)
//        {
//            var filmActeur = await _context.FilmActeur.FindAsync(id);
//            if (filmActeur == null)
//            {
//                return NotFound();
//            }

//            _context.FilmActeur.Remove(filmActeur);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool FilmActeurExists(long id)
//        {
//            return _context.FilmActeur.Any(e => e.FilmId == id);
//        }
//    }
//}
