using CQRS.Infrastructure.DbModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Context
{
    [ExcludeFromCodeCoverage]
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }


        public DbSet<ScheduleDbModel> Schedules { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

                optionsBuilder
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
//                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            }
        }
    }
}
