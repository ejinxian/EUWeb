namespace EUWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("yyerp.bas_city")]
    public partial class bas_city
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityId { get; set; }

        public int? ProvinceId { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        public int Disabled { get; set; }
    }
}
