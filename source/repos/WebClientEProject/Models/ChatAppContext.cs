using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebClient.Models
{
    public partial class ChatAppContext : DbContext
    {
        public ChatAppContext()
        {
        }

        public ChatAppContext(DbContextOptions<ChatAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FriendRequest> FriendRequests { get; set; } = null!;
        public virtual DbSet<Messager> Messagers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NKT20\\SQLEXPRESS;Initial Catalog=ChatApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendRequest>(entity =>
            {
                entity.ToTable("friendRequest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Receiver).HasColumnName("receiver");

                entity.Property(e => e.Sender).HasColumnName("sender");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.ReceiverNavigation)
                    .WithMany(p => p.FriendRequestReceiverNavigations)
                    .HasForeignKey(d => d.Receiver)
                    .HasConstraintName("FK__friendReq__recei__412EB0B6");

                entity.HasOne(d => d.SenderNavigation)
                    .WithMany(p => p.FriendRequestSenderNavigations)
                    .HasForeignKey(d => d.Sender)
                    .HasConstraintName("FK__friendReq__sende__403A8C7D");
            });

            modelBuilder.Entity<Messager>(entity =>
            {
                entity.ToTable("messagers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Enclose)
                    .HasMaxLength(1)
                    .HasColumnName("enclose");

                entity.Property(e => e.IsRead)
                    .HasColumnName("isRead")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Receiver).HasColumnName("receiver");

                entity.Property(e => e.Sender).HasColumnName("sender");

                entity.Property(e => e.Timestemp)
                    .HasColumnType("datetime")
                    .HasColumnName("timestemp")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ReceiverNavigation)
                    .WithMany(p => p.MessagerReceiverNavigations)
                    .HasForeignKey(d => d.Receiver)
                    .HasConstraintName("FK__messagers__recei__3D5E1FD2");

                entity.HasOne(d => d.SenderNavigation)
                    .WithMany(p => p.MessagerSenderNavigations)
                    .HasForeignKey(d => d.Sender)
                    .HasConstraintName("FK__messagers__sende__3C69FB99");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Phone, "UQ__Users__B43B145F1ADD3409")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Avata)
                    .IsUnicode(false)
                    .HasColumnName("avata");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Education)
                    .IsUnicode(false)
                    .HasColumnName("education");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("((5))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
