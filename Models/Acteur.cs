using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movie.Models
{
    public class Acteur
    {
        [Key]
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }

        [JsonIgnore]
        public ICollection<FilmActeur>? Films { get; set; } = [];
    }
}
