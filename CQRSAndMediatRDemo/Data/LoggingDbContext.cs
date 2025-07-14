using CQRSAndMediatRDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Data
{
    public class LoggingDbContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public LoggingDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("LoggingConnection"));
        }
       // public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options) { }

        public DbSet<RequestLog> RequestLogs { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
    }
}
