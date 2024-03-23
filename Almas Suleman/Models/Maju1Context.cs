using System;
using System.Collections.Generic;
using Almas_Suleman.Models;
using Microsoft.EntityFrameworkCore;

namespace Almas_Suleman;

public partial class Maju1Context : DbContext
{
    public Maju1Context()
    {
    }

    public Maju1Context(DbContextOptions<Maju1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SJ-PC\\SQLEXPRESS;\nDatabase=maju_1;Trusted_Connection=True;trustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07C922F740");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.Contact)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CONTACT");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Semester)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SEMESTER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
