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
    public class RealisateursController : ControllerBase
    {
        private readonly MovieContext _context;

        public RealisateursController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Realisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Realisateur>>> GetRealisateurs()
        {
            return await _context.Realisateurs.ToListAsync();
        }

        // GET: api/Realisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Realisateur>> GetRealisateur(long id)
        {
            var realisateur = await _context.Realisateurs.FindAsync(id);

            if (realisateur == null)
            {
                return NotFound();
            }

            return realisateur;
        }

        // PUT: api/Realisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRealisateur(long id, Realisateur realisateur)
        {
            if (id != realisateur.Id)
            {
                return BadRequest();
            }

            _context.Entry(realisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealisateurExists(id))
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

        // POST: api/Realisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Realisateur>> PostRealisateur(Realisateur realisateur)
        {
            _context.Realisateurs.Add(realisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRealisateur", new { id = realisateur.Id }, realisateur);
        }

        // DELETE: api/Realisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealisateur(long id)
        {
            var realisateur = await _context.Realisateurs.FindAsync(id);
            if (realisateur == null)
            {
                return NotFound();
            }

            _context.Realisateurs.Remove(realisateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RealisateurExists(long id)
        {
            return _context.Realisateurs.Any(e => e.Id == id);
        }
    }
}
