using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movie.Models
{
    public class UtilisateurFilmNote
    {
        [JsonIgnore]
        public Film? Film { get; set; }

        [JsonIgnore]
        public Utilisateur? Utilisateur { get; set; }

        public long FilmId { get; set; }
        public long UtilisateurId { get; set; }

        [Range(0, 5)]
        public int Note { get; set; }

    }
}
