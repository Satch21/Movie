﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movie.Models;

#nullable disable

namespace Movie.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20240726192818_initialcreate")]
    partial class initialcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Movie.Models.Acteur", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Acteurs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Nom = "Pitt",
                            Prenom = "Brad",
                            Uuid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = 2L,
                            Nom = "DiCaprio",
                            Prenom = "Leonardo",
                            Uuid = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Movie.Models.Film", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("AnneeSortie")
                        .HasColumnType("int");

                    b.Property<int?>("Duree")
                        .HasColumnType("int");

                    b.Property<long>("GenreId")
                        .HasColumnType("bigint");

                    b.Property<long>("RealisateurId")
                        .HasColumnType("bigint");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("RealisateurId");

                    b.HasIndex("Titre")
                        .IsUnique();

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AnneeSortie = 2019,
                            Duree = 161,
                            GenreId = 1L,
                            RealisateurId = 1L,
                            Synopsis = "En 1969, la star de télévision Rick Dalton et le cascadeur Cliff Booth, sa doublure de longue date, poursuivent leurs carrières au sein d’une industrie qu’ils ne reconnaissent plus. ",
                            Titre = "Once upon a time in Hollywood",
                            Uuid = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Movie.Models.FilmActeur", b =>
                {
                    b.Property<long>("FilmId")
                        .HasColumnType("bigint");

                    b.Property<long>("ActeurId")
                        .HasColumnType("bigint");

                    b.HasKey("FilmId", "ActeurId");

                    b.HasIndex("ActeurId");

                    b.ToTable("FilmActeur");
                });

            modelBuilder.Entity("Movie.Models.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Label = "Action",
                            Uuid = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Movie.Models.Profil", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Profils");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Label = "Admin",
                            Uuid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = 2L,
                            Label = "Contributeur",
                            Uuid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = 3L,
                            Label = "Observateur",
                            Uuid = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Movie.Models.Realisateur", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Realisateurs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Nom = "Tarantino",
                            Prenom = "Quentin",
                            Uuid = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Movie.Models.Utilisateur", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProfilId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ProfilId");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("Movie.Models.UtilisateurFilmNote", b =>
                {
                    b.Property<long>("FilmId")
                        .HasColumnType("bigint");

                    b.Property<long>("UtilisateurId")
                        .HasColumnType("bigint");

                    b.Property<int>("Note")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "UtilisateurId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("UtilisateurFilmNote");
                });

            modelBuilder.Entity("Movie.Models.Film", b =>
                {
                    b.HasOne("Movie.Models.Genre", "Genre")
                        .WithMany("Films")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movie.Models.Realisateur", "Realisateur")
                        .WithMany("Films")
                        .HasForeignKey("RealisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Realisateur");
                });

            modelBuilder.Entity("Movie.Models.FilmActeur", b =>
                {
                    b.HasOne("Movie.Models.Acteur", "Acteur")
                        .WithMany("Films")
                        .HasForeignKey("ActeurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movie.Models.Film", "Film")
                        .WithMany("Acteurs")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acteur");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("Movie.Models.Utilisateur", b =>
                {
                    b.HasOne("Movie.Models.Profil", "Profil")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("ProfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profil");
                });

            modelBuilder.Entity("Movie.Models.UtilisateurFilmNote", b =>
                {
                    b.HasOne("Movie.Models.Film", "Film")
                        .WithMany("FilmsNotes")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movie.Models.Utilisateur", "Utilisateur")
                        .WithMany("FilmsNotes")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("Movie.Models.Acteur", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("Movie.Models.Film", b =>
                {
                    b.Navigation("Acteurs");

                    b.Navigation("FilmsNotes");
                });

            modelBuilder.Entity("Movie.Models.Genre", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("Movie.Models.Profil", b =>
                {
                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("Movie.Models.Realisateur", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("Movie.Models.Utilisateur", b =>
                {
                    b.Navigation("FilmsNotes");
                });
#pragma warning restore 612, 618
        }
    }
}