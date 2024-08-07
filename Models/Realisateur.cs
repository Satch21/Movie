﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movie.Models
{
    public class Realisateur
    {
        [Key]
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }

        [JsonIgnore]
        public ICollection<Film>? Films { get;  } = new List<Film>();
    }
}
