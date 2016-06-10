using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUWeb.Areas.Member.Models
{
    public class AttachmentManagerViewModel
    {
        public bool is_dir { get; set; }
        public bool has_file { get; set; }
        public int filesize { get; set; }
        public bool is_photo { get; set; }
        public string filetype { get; set; }
        public string filename { get; set; }
        public string datetime { get; set; }
    }
}
