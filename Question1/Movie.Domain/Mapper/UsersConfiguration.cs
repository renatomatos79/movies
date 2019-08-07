using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Domain.Mapper
{
    public class UsersConfiguration : IEntityTypeConfiguration<Models.Users>
    {
        public virtual void Configure(EntityTypeBuilder<Models.Users> builder)
        {
            builder.ToTable("Users", "usr");

            builder.HasIndex(e => e.Login)
                .HasName("IX_Users")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.DtCreated).HasColumnType("datetime");
            builder.Property(e => e.DtModified).HasColumnType("datetime");

            builder.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Saltkey)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedByNavigation)
                .WithMany(p => p.InverseModifiedByNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK_Users_ModifiedBy");
        }
    }
}
