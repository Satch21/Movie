using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Movie.Models;

namespace Movie.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options)
    {
    }

    public DbSet<Film> Films { get; set; } = null!;

    public DbSet<Acteur> Acteurs { get; set; } = null!;

    public DbSet<Genre> Genres { get; set; } = null!;

    public DbSet<Profil> Profils { get; set; } = null!;

    public DbSet<Realisateur> Realisateurs { get; set; } = null!;

    public DbSet<Utilisateur> Utilisateurs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Utilisateur>(entity =>
        {
            entity.HasIndex(e => e.Email).IsUnique();
        });

        builder.Entity<Profil>()
               .HasMany(e => e.Utilisateurs)
               .WithOne(e => e.Profil)
               .HasForeignKey(e => e.ProfilId);


        builder.Entity<Genre>()
               .HasMany(e => e.Films)
               .WithOne(e => e.Genre)
               .HasForeignKey(e => e.GenreId);


        builder.Entity<Realisateur>()
            .HasMany(e => e.Films)
            .WithOne(e => e.Realisateur)
            .HasForeignKey(e => e.RealisateurId);


        builder.Entity<Film>(entity =>
        {
            entity.HasIndex(e => e.Titre).IsUnique();
        });


        builder.Entity<Film>()
           .HasMany(e => e.Acteurs)
           .WithMany(e => e.Films)
           .UsingEntity(
               "FilmActeur",
               l => l.HasOne(typeof(Acteur)).WithMany().HasForeignKey("ActeurId").HasPrincipalKey(nameof(Acteur.Id)),
               r => r.HasOne(typeof(Film)).WithMany().HasForeignKey("FilmId").HasPrincipalKey(nameof(Film.Id)),
               j => j.HasKey("ActeurId", "FilmId"));



        builder.Entity<UtilisateurFilmNote>()
                 .HasKey(ufn => new { ufn.FilmId, ufn.UtilisateurId });

        builder.Entity<UtilisateurFilmNote>()
            .HasOne(r => r.Utilisateur)
            .WithMany(t => t.FilmsNotes)
            .HasForeignKey(f => f.UtilisateurId);

        builder.Entity<UtilisateurFilmNote>()
            .HasOne(r => r.Film)
            .WithMany(t => t.FilmsNotes)
            .HasForeignKey(f => f.FilmId);
    }
   
}