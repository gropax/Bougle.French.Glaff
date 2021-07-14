using Microsoft.EntityFrameworkCore;
using System;

namespace Bougle.French.Glaff.Storage
{
    public class GlaffEntry
    {
        public int Id { get; set; }
        public string GraphicalForm { get; set; }
        public string MorphoSyntax { get; set; }
        public string Lemma { get; set; }
        public string ApiPronunciations { get; set; }
        public string SampaPronunciations { get; set; }
        public double FrantexAbsoluteFormFrequency { get; set; }
        public double FrantexRelativeFormFrequency { get; set; }
        public double FrantexAbsoluteLemmaFrequency { get; set; }
        public double FrantexRelativeLemmaFrequency { get; set; }
        public double LM10AbsoluteFormFrequency { get; set; }
        public double LM10RelativeFormFrequency { get; set; }
        public double LM10AbsoluteLemmaFrequency { get; set; }
        public double LM10RelativeLemmaFrequency { get; set; }
        public double FrWacAbsoluteFormFrequency { get; set; }
        public double FrWacRelativeFormFrequency { get; set; }
        public double FrWacAbsoluteLemmaFrequency { get; set; }
        public double FrWacRelativeLemmaFrequency { get; set; }
    }


    public class GlaffDbContext : DbContext
    {
        private string _connectionString;

        public GlaffDbContext() { }
        public GlaffDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(_connectionString);

        public DbSet<GlaffEntry> Entries { get; set; }
    }
}
