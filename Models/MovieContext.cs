using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Movie.Models;
using System.Linq;

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


        builder.Entity<FilmActeur>()
             .HasKey(ufn => new { ufn.FilmId, ufn.ActeurId });

        builder.Entity<FilmActeur>()
            .HasOne(r => r.Film)
            .WithMany(t => t.Acteurs)
            .HasForeignKey(f => f.FilmId);

        builder.Entity<FilmActeur>()
            .HasOne(r => r.Acteur)
            .WithMany(t => t.Films)
            .HasForeignKey(f => f.ActeurId);


        builder.Entity<Genre>().HasData(
          new Genre { Id = 1, Label = "Action" });

        builder.Entity<Realisateur>().HasData(
          new Realisateur { Id = 1, Nom = "Tarantino", Prenom = "Quentin" });

        builder.Entity<Acteur>().HasData(
            new Acteur { Id = 1, Nom = "Pitt", Prenom = "Brad" });

        builder.Entity<Acteur>().HasData(
            new Acteur { Id = 2, Nom = "DiCaprio", Prenom = "Leonardo" });

        builder.Entity<Profil>().HasData(
           new Profil { Id = 1, Label = "Admin" });

        builder.Entity<Profil>().HasData(
            new Profil { Id = 2, Label = "Contributeur" });

        builder.Entity<Profil>().HasData(
            new Profil { Id = 3, Label = "Observateur" });

        builder.Entity<Film>(b =>
        {
            b.HasData(new Film
            {
                Id = 1,
                Titre = "Once upon a time in Hollywood",
                Synopsis = "En 1969, la star de télévision Rick Dalton et le cascadeur Cliff Booth, sa doublure de longue date, poursuivent leurs carrières au sein d’une industrie qu’ils ne reconnaissent plus. ",
                Duree = 161,
                AnneeSortie = 2019,
                GenreId = 1,
                RealisateurId = 1
            });
        });
        
    }

}