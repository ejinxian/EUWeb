using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.DAL
{
    /// <summary>
    /// 简单工厂
    /// </summary>
    public static class RepositoryFactory
    {
        /// <summary>
        /// 用户存储
        /// </summary>
        public static InterfaceUserRepository UserRepository { get { return new UserRepository(); } }

        /// <summary>
        /// 栏目
        /// </summary>
        public static InterfaceCategory CategoryRepository { get { return new CategoryRepository(); } }

        public static InterfaceArticle ArticleRepository { get { return new ArticleRepository(); } }
        public static InterfaceAttachment AttachmentRepository { get { return new AttachmentRepository(); } }
        public static InterfaceCommonModel CommonModelRepository { get { return new CommonModelRepository(); } }
    }
}
