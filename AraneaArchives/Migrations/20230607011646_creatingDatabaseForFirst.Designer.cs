﻿// <auto-generated />
using AraneaArchives.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AraneaArchives.Migrations
{
    [DbContext(typeof(AraneaArchivesContext))]
    [Migration("20230607011646_creatingDatabaseForFirst")]
    partial class creatingDatabaseForFirst
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AraneaArchives.Models.Directory", b =>
                {
                    b.Property<int>("DirectoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DirectoryId"));

                    b.Property<string>("DirectoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DirectoryId");

                    b.ToTable("Directory");
                });

            modelBuilder.Entity("AraneaArchives.Models.Notes", b =>
                {
                    b.Property<int>("NotesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotesId"));

                    b.Property<int>("DirectoryId")
                        .HasColumnType("int");

                    b.Property<string>("NoteContents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotesId");

                    b.HasIndex("DirectoryId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("AraneaArchives.Models.Notes", b =>
                {
                    b.HasOne("AraneaArchives.Models.Directory", "Directorys")
                        .WithMany("Notes")
                        .HasForeignKey("DirectoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Directorys");
                });

            modelBuilder.Entity("AraneaArchives.Models.Directory", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
