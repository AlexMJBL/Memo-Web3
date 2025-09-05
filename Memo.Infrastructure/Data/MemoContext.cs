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
     
            modelBuilder.Entity<Memo>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Memo>()
                .HasOne(m => m.Compte)
                .WithMany(c => c.Memos)
                .HasForeignKey(m => m.IdCompte)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
