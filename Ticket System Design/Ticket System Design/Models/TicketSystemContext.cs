using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ticket_System_Design.Models
{
    public partial class TicketSystemContext : DbContext
    {
        public TicketSystemContext()
        {
        }

        public TicketSystemContext(DbContextOptions<TicketSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TicketSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ticket");

                entity.Property(e => e.AlertLevel)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Priority)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TicketDescription).IsRequired();

                entity.Property(e => e.TicketId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TicketID");

                entity.Property(e => e.TicketStatus)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TicketSummary).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
