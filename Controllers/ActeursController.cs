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
    public class ActeursController : ControllerBase
    {
        private readonly MovieContext _context;

        public ActeursController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Acteurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acteur>>> GetActeurs()
        {
            return await _context.Acteurs.ToListAsync();
        }

        // GET: api/Acteurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acteur>> GetActeur(long id)
        {
            var acteur = await _context.Acteurs.FindAsync(id);

            if (acteur == null)
            {
                return NotFound();
            }

            return acteur;
        }

        // PUT: api/Acteurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActeur(long id, Acteur acteur)
        {
            if (id != acteur.Id)
            {
                return BadRequest();
            }

            _context.Entry(acteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActeurExists(id))
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

        // POST: api/Acteurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acteur>> PostActeur(Acteur acteur)
        {
            _context.Acteurs.Add(acteur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActeur", new { id = acteur.Id }, acteur);
        }

        // DELETE: api/Acteurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActeur(long id)
        {
            var acteur = await _context.Acteurs.FindAsync(id);
            if (acteur == null)
            {
                return NotFound();
            }

            _context.Acteurs.Remove(acteur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActeurExists(long id)
        {
            return _context.Acteurs.Any(e => e.Id == id);
        }
    }
}
