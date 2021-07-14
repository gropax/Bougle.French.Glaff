using Bougle.French.Glaff.Storage;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Bougle.French.Glaff.Cmd
{
    class Program
    {
        public class Options
        {
            [Value(0, MetaName = "output", HelpText = "Output database file path.")]
            public string DbPath { get; set; }

            [Value(1, MetaName = "lexicon", HelpText = "Glàff main lexicon file path.")]
            public string LexiconPath { get; set; }

            [Value(2, MetaName = "oldies", HelpText = "Glàff oldies lexicon file path.")]
            public string OldiesPath { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }

        private const int BATCH_SIZE = 50000;

        static void RunOptions(Options opts)
        {
            Console.WriteLine($"Initializing Sqlite database [{opts.DbPath}]...");

            var dbContext = new GlaffDbContext($@"Data Source={opts.DbPath}");

            bool d = dbContext.Database.EnsureDeleted();
            bool c = dbContext.Database.EnsureCreated();

            Console.WriteLine($"Sqlite database successfully created...");


            if (!string.IsNullOrWhiteSpace(opts.LexiconPath))
            {
                if (!File.Exists(opts.LexiconPath))
                {
                    Console.WriteLine($"Glàff main lexicon file not found [{opts.LexiconPath}].");
                    Environment.Exit(1);
                }

                Console.WriteLine($"Loading entries from Glàff main lexicon...");

                int done = 0;
                foreach (var batch in ParseMainLexicon(opts.LexiconPath).Batch(BATCH_SIZE))
                {
                    dbContext.AddRange(batch);
                    dbContext.SaveChanges();

                    done += batch.Length;

                    if (done % 1000 == 0)
                        Console.WriteLine($"Loaded {done} entries from Glàff main lexicon.");
                }
            }

            if (!string.IsNullOrWhiteSpace(opts.OldiesPath))
            {
                if (!File.Exists(opts.OldiesPath))
                {
                    Console.WriteLine($"Glàff oldies lexicon file not found [{opts.OldiesPath}].");
                    Environment.Exit(1);
                }

                Console.WriteLine($"Loading entries from Glàff oldies lexicon...");

                int done = 0;
                foreach (var batch in ParseOldiesLexicon(opts.OldiesPath).Batch(BATCH_SIZE))
                {
                    dbContext.AddRange(batch);
                    dbContext.SaveChanges();

                    done += batch.Length;

                    if (done % 1000 == 0)
                        Console.WriteLine($"Loaded {done} entries from Glàff oldies lexicon.");
                }
            }
        }

        private static void LoadMainLexicon(GlaffDbContext dbContext, string lexiconPath)
        {
        }

        private static IEnumerable<GlaffEntry> ParseMainLexicon(string path)
        {
            const int BufferSize = 128;
            using (var fileStream = File.OpenRead(path))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] columns = line.Split('|');

                    yield return new GlaffEntry()
                    {
                        OldFashioned = false,
                        GraphicalForm = columns[0],
                        MorphoSyntax = columns[1],
                        Lemma = columns[2],
                        ApiPronunciations = columns[3],
                        SampaPronunciations = columns[4],
                        FrantexAbsoluteFormFrequency = ParseDouble(columns[5]),
                        FrantexRelativeFormFrequency = ParseDouble(columns[6]),
                        FrantexAbsoluteLemmaFrequency = ParseDouble(columns[7]),
                        FrantexRelativeLemmaFrequency = ParseDouble(columns[8]),
                        LM10AbsoluteFormFrequency = ParseDouble(columns[9]),
                        LM10RelativeFormFrequency = ParseDouble(columns[10]),
                        LM10AbsoluteLemmaFrequency = ParseDouble(columns[11]),
                        LM10RelativeLemmaFrequency = ParseDouble(columns[12]),
                        FrWacAbsoluteFormFrequency = ParseDouble(columns[13]),
                        FrWacRelativeFormFrequency = ParseDouble(columns[14]),
                        FrWacAbsoluteLemmaFrequency = ParseDouble(columns[15]),
                        FrWacRelativeLemmaFrequency = ParseDouble(columns[16]),
                    };
                }
            }
        }

        private static double ParseDouble(string str) => double.Parse(str, CultureInfo.InvariantCulture);

        private static IEnumerable<GlaffEntry> ParseOldiesLexicon(string path)
        {
            const int BufferSize = 128;
            using (var fileStream = File.OpenRead(path))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] columns = line.Split('|');

                    yield return new GlaffEntry()
                    {
                        OldFashioned = true,
                        GraphicalForm = columns[0],
                        MorphoSyntax = columns[1],
                        Lemma = columns[2],
                        ApiPronunciations = columns.Length > 3 ? columns[3] : null,
                    };
                }
            }
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
          //handle errors
        }
    }

    public static class Extensions
    {
        public static IEnumerable<TSource[]> Batch<TSource>(this IEnumerable<TSource> source, int size)
        {
            TSource[] bucket = null;
            var count = 0;

            foreach (var item in source)
            {
                if (bucket == null)
                    bucket = new TSource[size];

                bucket[count++] = item;
                if (count != size)
                    continue;

                yield return bucket;

                bucket = null;
                count = 0;
            }

            if (bucket != null && count > 0)
                yield return bucket.Take(count).ToArray();
        }
    }
}
