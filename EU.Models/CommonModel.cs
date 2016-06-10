using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.Models
{
    /// <summary>
    /// 公共部分，像文章，咨询甚至产品
    /// </summary>
    public  class CommonModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string DefaultPicUrl { get; set; }
        public int Hits { get; set; }

        public string Inputer { get; set; }
        public string Model { get; set; }
        public int ModelID { get; set; }

        public DateTime ReleaseDate { get; set; }
        public int Status { get; set; }
        public static string StatusList { get; set; }
        public string Title { get; set; }

        //public virtual Category Category { get; set; }
    }
}
