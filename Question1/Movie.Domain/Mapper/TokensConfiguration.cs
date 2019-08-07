using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Domain.Mapper
{
    public class TokensConfiguration : IEntityTypeConfiguration<Models.Tokens>
    {
        public virtual void Configure(EntityTypeBuilder<Models.Tokens> builder)
        {
            builder.HasKey(e => e.Token);

            builder.ToTable("Tokens", "usr");

            builder.Property(e => e.Token)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedNever();

            builder.Property(e => e.DtCreated).HasColumnType("datetime");

            builder.Property(e => e.DtExpiration).HasColumnType("datetime");

            builder.Property(e => e.UserId).HasColumnName("UserID");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Tokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tokens_Users");
        }
    }
}
