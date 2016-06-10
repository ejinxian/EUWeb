using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.Models
{
   /// <summary>
   /// 栏目
   /// </summary>
   public  class Category
    {
        public Category() { }
        [Key]
        public int CategoryID { get; set; }

        public string CategoryView { get; set; }

        public string ContentOrder { get; set; }

        public string Description { get; set; }

        public string LinkUrl { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyWords { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string OrderField { get; set; }
        public int? PageSize { get; set; }
        public int? ParentId { get; set; }
        public string ParentPath { get; set; }
        public string RecordName { get; set; }
        public string RecordUnit { get; set; }
        public string Type { get; set; }
    }
}
