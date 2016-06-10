using EU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUWeb.Models
{
    /// <summary>
    /// 视图模型
    /// </summary>
    public class CommonModelViewModel
    {
        public int ModelID { get; set; }

        /// <summary>
        /// 栏目ID
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 模型名称
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 录入者
        /// </summary>
        public string Inputer { get; set; }

        /// <summary>
        /// 点击
        /// </summary>
        public int Hits { get; set; }

        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 状态文字
        /// </summary>
        public string StatusString { get { return EU.Models.CommonModel.StatusList[Status].ToString(); } }

        /// <summary>
        /// 首页图片
        /// </summary>
        public string DefaultPicUrl { get; set; }

        //public virtual Category Category { get; set; }
    }
}
