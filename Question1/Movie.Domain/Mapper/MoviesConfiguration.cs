using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Domain.Mapper
{
    public class MoviesConfiguration : IEntityTypeConfiguration<Models.Movies>
    {
        public virtual void Configure(EntityTypeBuilder<Models.Movies> builder)
        {
            builder.ToTable("Movies", "mov");

            builder.HasIndex(e => e.ImdbId)
                .HasName("IX_Movies")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.DtCreated).HasColumnType("datetime");
            builder.Property(e => e.DtModified).HasColumnType("datetime");
            builder.Property(e => e.MovieTypeId).HasColumnName("MovieTypeID");
            builder.Property(e => e.ImdbId)
                .IsRequired()
                .HasColumnName("imdbID")
                .HasMaxLength(40)
                .IsUnicode(false);            

            builder.Property(e => e.Poster)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(125)
                .IsUnicode(false);

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.MoviesCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movies_Users");

            builder.HasOne(d => d.ModifiedByNavigation)
                .WithMany(p => p.MoviesModifiedByNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK_Movies_Users1");

            builder.HasOne(d => d.MovieType)
                .WithMany(p => p.Movies)
                .HasForeignKey(d => d.MovieTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movies_MovieTypes");
        }
    }
}
