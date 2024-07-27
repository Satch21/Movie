using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly MovieContext _context;

        public UtilisateursController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            return await _context.Utilisateurs.Include(u => u.Profil).Include(u => u.FilmsNotes).ToListAsync();
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(long id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur(long id, Utilisateur utilisateur)
        {
            try
            {
                if (utilisateur.FilmsNotes != null)
                {
                    List<UtilisateurFilmNote> dbUtilisateurFilmNotesToInsert;
                    dbUtilisateurFilmNotesToInsert = new List<UtilisateurFilmNote>();
                    Utilisateur utilisateurDb = _context.Utilisateurs.Where(u => u.Id == id).First();

                    foreach (var noteSent in utilisateur.FilmsNotes)
                    {
                        dbUtilisateurFilmNotesToInsert.Add(new UtilisateurFilmNote() { FilmId = id, UtilisateurId = id, Note = noteSent.Note });
                    }

                    
                    //Récupération des notes de l'utilisateur courant 
                    List<UtilisateurFilmNote> UtilisateurFilmNotesDb = _context.Set<UtilisateurFilmNote>().Where(u => u.UtilisateurId == id).ToList();

                    //Suppression des notes pour les films et l'utilisateur par rapport aux données envoyées dans la requête
                    foreach (var utilisateurFilmNoteInDb in UtilisateurFilmNotesDb)
                    {
                        foreach (var noteSent in utilisateur.FilmsNotes)
                        {
                            if(noteSent.FilmId == utilisateurFilmNoteInDb.FilmId)
                            {
                                _context.Set<UtilisateurFilmNote>().Remove(utilisateurFilmNoteInDb);
                            }
                        }
                    }

                    _context.SaveChanges();

                    //Ajout des notes envoyées dans la requête
                    foreach (var utilisateurFilmNote in dbUtilisateurFilmNotesToInsert)
                    {
                        utilisateurDb.FilmsNotes?.Add(utilisateurFilmNote);
                        _context.SaveChanges();
                    }

                    _context.Entry(utilisateurDb).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return CreatedAtAction("GetUtilisateur", new { id = utilisateur.Id }, utilisateur);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateurExists(id))
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

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {

            List<UtilisateurFilmNote> UtilisateursFilmsNotes;
            UtilisateursFilmsNotes = new List<UtilisateurFilmNote>();

            if(utilisateur.FilmsNotes != null)
            {
                foreach (var filmNotes in utilisateur.FilmsNotes)
                {
                    UtilisateursFilmsNotes.Add(new UtilisateurFilmNote() { FilmId = filmNotes.FilmId, Note = filmNotes.Note });
                }
                utilisateur.FilmsNotes.Clear();
            }

            _context.Utilisateurs.Add(utilisateur);

            _context.SaveChanges();

            if (utilisateur.FilmsNotes != null)
            {
                foreach (var filmNotes in UtilisateursFilmsNotes)
                {
                    filmNotes.UtilisateurId = utilisateur.Id;
                    utilisateur.FilmsNotes.Add(filmNotes);
                }
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUtilisateur", new { id = utilisateur.Id }, utilisateur);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(long id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            _context.Utilisateurs.Remove(utilisateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilisateurExists(long id)
        {
            return _context.Utilisateurs.Any(e => e.Id == id);
        }

    }
}
