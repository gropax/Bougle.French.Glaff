using Bougle.French.Glaff.Storage;
using System;
using System.Linq;

namespace Bougle.French.Glaff.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataSource = args.Single();
            var dbContext = new GlaffDbContext($@"Data Source={dataSource}");

            bool d = dbContext.Database.EnsureDeleted();
            bool c = dbContext.Database.EnsureCreated();
        }
    }
}
