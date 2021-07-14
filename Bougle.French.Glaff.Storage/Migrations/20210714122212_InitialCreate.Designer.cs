﻿// <auto-generated />
using Bougle.French.Glaff.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bougle.French.Glaff.Storage.Migrations
{
    [DbContext(typeof(GlaffDbContext))]
    [Migration("20210714122212_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("Bougle.French.Glaff.Storage.GlaffEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApiPronunciations")
                        .HasColumnType("TEXT");

                    b.Property<double>("FrWacAbsoluteFormFrequency")
                        .HasColumnType("REAL");

                    b.Property<double>("FrWacAbsoluteLemmaFrequency")
                        .HasColumnType("REAL");

                    b.Property<double>("FrWacRelativeFormFrequency")
                        .HasColumnType("REAL");

                    b.Property<double>("FrWacRelativeLemmaFrequency")
                        .HasColumnType("REAL");

                    b.Property<double>("FrantexAbsoluteFormFrequency")
                        .HasColumnType("REAL");

                    b.Property<double>("FrantexAbsoluteLemmaFrequency")
                        .HasColumnType("REAL");

                    b.Property<double>("FrantexRelativeFormFrequency")
                        .HasColumnType("REAL");

                    b.Property<double>("FrantexRelativeLemmaFrequency")
                        .HasColumnType("REAL");

                    b.Property<string>("GraphicalForm")
                        .HasColumnType("TEXT");

                    b.Property<double>("LM10AbsoluteFormFrequency")
                        .HasColumnType("REAL");

                    b.Property<double>("LM10AbsoluteLemmaFrequency")
                        .HasColumnType("REAL");

                    b.Property<double>("LM10RelativeFormFrequency")
                        .HasColumnType("REAL");

                    b.Property<double>("LM10RelativeLemmaFrequency")
                        .HasColumnType("REAL");

                    b.Property<string>("Lemma")
                        .HasColumnType("TEXT");

                    b.Property<string>("MorphoSyntax")
                        .HasColumnType("TEXT");

                    b.Property<bool>("OldFashioned")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SampaPronunciations")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}