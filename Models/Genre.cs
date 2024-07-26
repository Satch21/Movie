using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movie.Models
{
    public class Genre
    {
        [Key]
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public String Label { get; set; }

        [JsonIgnore]
        public ICollection<Film>? Films { get; } = new List<Film>();
    }
}
