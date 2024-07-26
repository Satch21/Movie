using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class UtilisateurFilmNote
    {
        public Film Film { get; set; }
        public Utilisateur Utilisateur { get; set; }

        [Range(0, 5)]
        public int Note { get; set; }

    }
}
