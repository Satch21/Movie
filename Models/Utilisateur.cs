using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Movie.Models
{
    public class Utilisateur
    {
        [Key]
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }

        [EmailAddress]
        [EmailUniqueValidator]
        public String Email { get; set; }
        public long ProfilId { get; set; }
        public Profil? Profil { get; set; }

        public virtual ICollection<UtilisateurFilmNote>? FilmsNotes { get; set; }
    }
}
