using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoApp.ApplicationCore.Entities;

namespace MemoApp.Infrastructure.Data
{
    public class MemoContext : DbContext
    {
        public MemoContext(DbContextOptions<MemoContext> options) : base(options)
        {
        }

        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Memo> Memos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Memo>(entity =>
            {
                entity.Property(m => m.Id)
                .ValueGeneratedOnAdd();

                entity.Property(m => m.Titre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(m => m.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(m => m.DateCreation)
                    .IsRequired();

                entity.Property(m => m.IdCompte)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(m => m.Compte)
                    .WithMany(c => c.Memos)
                    .HasForeignKey(m => m.IdCompte)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Compte>(entity =>
            {
                entity.Property(m => m.Id)
                .ValueGeneratedOnAdd();

                entity.Property(c => c.NomUtilisateur)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(c => c.MotDePasse)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(c => c.DateCreation)
                    .IsRequired();

            });


        }
    }
}
