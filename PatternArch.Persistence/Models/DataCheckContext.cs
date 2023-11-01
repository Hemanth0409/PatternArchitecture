using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PatternArch.Persistence.Models;

public partial class DataCheckContext : DbContext
{
    public DataCheckContext()
    {
    }

    public DataCheckContext(DbContextOptions<DataCheckContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserDeta__3214EC077D1FD521");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.UserName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    internal IEnumerable<object> AsEnumerable()
    {
        throw new NotImplementedException();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
