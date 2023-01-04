using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirstDataApp.Models;

public partial class UsersContext : DbContext
{
    public UsersContext()
    {
    }

    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-2IU1DLL\\MSSQLSERVER01; Initial Catalog=Users; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC275FF06CEA");

            entity.ToTable("User");

            entity.HasIndex(e => e.Mail, "UQ__User__2724B2D1170BBC17").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ__User__5C7E359E02B8831B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(55);
            entity.Property(e => e.LastName).HasMaxLength(55);
            entity.Property(e => e.Mail).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
