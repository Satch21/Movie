using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movie.Models
{
    public class Film
    {
        [Key]
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public String Titre { get; set; }
        public String Synopsis { get; set; }
        public int? Duree { get; set; }

        public int? AnneeSortie { get; set; }
        public long RealisateurId { get; set; }
        public long GenreId { get; set; }

        public ICollection<Acteur>? Acteurs { get; set; } = [];

        public virtual ICollection<UtilisateurFilmNote>? FilmsNotes { get; set; }

        public Genre? Genre { get; set; }

        public Realisateur? Realisateur { get; set; }



    }
}
