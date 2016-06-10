namespace EUWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class vw_sec_user : DbContext
    {
        public vw_sec_user()
            : base("name=yyerp")
        {
        }

        public virtual DbSet<cus_dealer> cus_dealer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cus_dealer>()
                .Property(e => e.DealerName)
                .IsUnicode(false);

            modelBuilder.Entity<cus_dealer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<cus_dealer>()
                .Property(e => e.Pwd)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<EUWeb.Models.bas_city> bas_city { get; set; }
    }
}
