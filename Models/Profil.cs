using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movie.Models
{
    public class Profil 
    {
        [Key]
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public String Label { get; set; }

        [JsonIgnore]
        public ICollection<Utilisateur>? Utilisateurs { get; } = new List<Utilisateur>();
    }
}
