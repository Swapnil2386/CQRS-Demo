using CQRSAndMediatRDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<StudentDetails> Students { get; set; }
        public DbSet<TeacherDetails> Teachers { get; set; }
        public DbSet<ClassDetails> Classes { get; set; }
        public DbSet<ClassTeacherMapping> ClassTeacherMappings { get; set; }
        public DbSet<JwtToken> JwtTokens { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassTeacherMapping>()
           .HasKey(ct => ct.Id);

            modelBuilder.Entity<ClassTeacherMapping>()
                .HasOne(ct => ct.Class)
                .WithMany(c => c.ClassTeacherMappings)
                .HasForeignKey(ct => ct.ClassId);

           
        }
    }

}
