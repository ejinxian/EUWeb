using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.Models
{
    /// <summary>
    /// 附件
    /// </summary>
    public class Attachment
    {
        [Key]
        public int AttachmentID { get; set; }
        public string Extension { get; set; }
        public string FilePath { get; set; }
        public int ModelID { get; set; }

        public string Owner { get; set; }
        public string Type { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
