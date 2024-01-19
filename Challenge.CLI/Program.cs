using ChallengeApi.DataContect;
using ChallengeApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChallengeCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if the correct number of command-line arguments is provided
            if (args.Length != 1 || !int.TryParse(args[0], out int numberOfRows))
            {
                Console.WriteLine("Usage: ChallengeCLI <number_of_rows>");
                return;
            }

            // Build configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Configure DbContext with connection string
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            // Create and use an instance of AppDbContext
            using var dbContext = new AppDbContext(optionsBuilder.Options);

            // Insert seed data into the Trade table
            InsertSeedData(dbContext, numberOfRows);

            Console.WriteLine($"{numberOfRows} rows of seed data inserted into the Trade table.");
        }

        private static void InsertSeedData(AppDbContext dbContext, int numberOfRows)
        {
            Random random = new Random();

            // Fetch existing instrument IDs from the Instrument table
            var instrumentIds = dbContext.Instruments.Select(i => i.Id).ToList();

            // Generate seed data and insert into the Trade table
            for (int i = 0; i < numberOfRows; i++)
            {
                // Choose a random instrument ID from the existing IDs
                var instrumentId = instrumentIds[random.Next(instrumentIds.Count)];

                // Create a new Trade object with random data
                var trade = new Trade
                {
                    InstrumentId = instrumentId,
                    DateEn = DateTime.Now.AddDays(-random.Next(1, 365)),
                    Open = (decimal)random.NextDouble() * 100,
                    High = (decimal)random.NextDouble() * 100,
                    Low = (decimal)random.NextDouble() * 100,
                    Close = (decimal)random.NextDouble() * 100
                };

                // Add the trade to the DbContext
                dbContext.Trades.Add(trade);
            }

            // Save changes to the database
            dbContext.SaveChanges();
        }
    }
}
