using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.Models
{
    /// <summary>
    /// 文章
    /// </summary>
   public  class Article
    {
        [Key]
        public int ArticleID { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Intro { get; set; }
        public int ModelID { get; set; }

        public string Source { get; set; }

        //public int State { get; set; }
        [ForeignKey("ModelID")]
        public virtual CommonModel CommonModel { get; set; }

    }
}
