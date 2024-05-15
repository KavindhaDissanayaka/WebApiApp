using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiApp.Models
{
    public partial class WebApiTrainingContext : DbContext
    {
        public WebApiTrainingContext()
        {
        }

        public WebApiTrainingContext(DbContextOptions<WebApiTrainingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<University> Universities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KAVINDA-MIS\\SQLEXPRESS;Database=WebApiTraining;User ID=sa;Password=ksd1234;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UniversityId).HasColumnName("UniversityID");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("FK__Student__Univers__398D8EEE");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.ToTable("University");

                entity.Property(e => e.UniversityId).HasColumnName("UniversityID");

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
