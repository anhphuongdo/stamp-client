using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BIT_STAMP.Models;

namespace BIT_STAMP.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration _config;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Us> Us { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Talkshow> Talkshows { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<UserGroupRelationship> Relationships { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string ConnectionStrings = _config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            optionsBuilder.UseSqlServer(ConnectionStrings);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}