using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Movie.Domain.Mapper;

namespace Movie.Domain.Models
{
    public partial class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MovieTypes> MovieTypes { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Tokens> Tokens { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.ApplyConfiguration(new MoviesConfiguration());
            modelBuilder.ApplyConfiguration(new MovieTypesConfiguration());
            modelBuilder.ApplyConfiguration(new TokensConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());





        }
    }
}
