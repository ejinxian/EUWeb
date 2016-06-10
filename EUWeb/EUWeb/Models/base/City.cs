using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EUWeb.Models
{


public partial class City : DbContext
{
    public City()
        : base("name=City")
    {
    }

    public virtual DbSet<bas_city> bas_city { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<bas_city>()
            .Property(e => e.Code)
            .IsUnicode(false);

        modelBuilder.Entity<bas_city>()
            .Property(e => e.CityName)
            .IsUnicode(false);
    }
}
}
