using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreSplash.Entity;

namespace NetCoreSplash.APImenta.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
            
        }

        public Context()
        {
        }

        public DbSet<NetCoreSplash.Entity.Menu> Menu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>(menu =>
            {
                menu.ToTable("Menu");

                menu.HasKey(k => k.Id);

                menu.Property(k => k.Id)
                    .ValueGeneratedOnAdd().UseIdentityColumn();

                menu.Property(x => x.Controller)
                    .IsRequired()
                    .HasMaxLength(50);

                menu.Property(x => x.Action)
                    .IsRequired()
                    .HasMaxLength(50);

                menu.Property(x => x.Label)
                    .IsRequired()
                    .HasMaxLength(50);

                menu.Property(x => x.ClassCss)                    
                    .HasMaxLength(255);

                menu.Property(x => x.Area)                    
                    .HasMaxLength(50);

                menu.Property(x => x.IdMenu);

                menu.HasMany(k => k.Itens)
                    .WithOne()
                    .HasForeignKey(k => k.IdMenu)
                    .HasPrincipalKey(k => k.Id);
            });

        }

    }
}
