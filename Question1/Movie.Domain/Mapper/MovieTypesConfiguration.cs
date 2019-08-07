using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Domain.Mapper
{
    public class MovieTypesConfiguration : IEntityTypeConfiguration<Models.MovieTypes>
    {
        public virtual void Configure(EntityTypeBuilder<Models.MovieTypes> builder)
        {
            builder.ToTable("MovieTypes", "mov");

            builder.HasIndex(e => e.Name)
                .HasName("IX_MovieTypes")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.DtCreated).HasColumnType("datetime");
            builder.Property(e => e.DtModified).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.MovieTypesCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieTypes_CreatedBy");

            builder.HasOne(d => d.ModifiedByNavigation)
                .WithMany(p => p.MovieTypesModifiedByNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK_MovieTypes_ModifiedBy");
        }
    }
}
