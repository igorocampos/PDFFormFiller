using PDFFormFiller.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PDFFormFiller.Data
{
    public static class DatabaseHelper
    {
        public static IHost CreateDatabase<T>(this IHost webHost) where T : DbContext
        {
            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;

            // According to https://github.com/peter-evans/docker-compose-healthcheck/issues/3#issuecomment-329037485
            // docker-compose stopped accepting a health contidion in `depends_on` from v3 and above.
            // we are making a resilient application here, trying to reconect 3 times with 5 seconds interval
            Exception lastException = null;
            for (int count = 0; count < 3; count++)
            {
                try
                {
                    var db = services.GetRequiredService<T>();
                    db.Database.Migrate();
                    return webHost;
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }
                Thread.Sleep(5000);
            }

            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(lastException, "Database Creation/Migrations failed!");

            return webHost;
        }

        private static Random random = new Random();
        public static DBContext Seed(this DBContext dbContext, int recordCount)
        {
            //Load context with N recipes with random values
            for (int i = 1; i <= recordCount; i++)
            {
                dbContext.FieldNaming.Add(new FieldNaming
                {
                    ModelFieldName = string.Join(' ', RandomStrings(1)),
                    Page = random.Next(1, 13),
                    PdfFieldName = string.Join(' ', RandomStrings(2))
                });
            }

            dbContext.SaveChanges();
            return dbContext;
        }

        public static IEnumerable<string> RandomStrings(int count)
        {
            for (int i = 0; i < count; i++)
            {
                //Generate a random 11 characters name
                yield return Path.GetRandomFileName();
            }
        }
    }
}
