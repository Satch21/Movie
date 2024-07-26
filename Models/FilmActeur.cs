using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movie.Models
{
    public class FilmActeur
    {
        [Key]
        public long FilmId { get; set; }
        [Key]
        public long ActeurId { get; set; }
        [JsonIgnore]
        public Film? Film { get; set; }

        [JsonIgnore]
        public Acteur? Acteur { get; set; }
    }
}
