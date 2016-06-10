using EU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.DAL
{
    /// <summary>
    /// 公共模型仓储
    /// <remarks>
    /// </remarks>
    /// </summary>
    public class CommonModelRepository : BaseRepository<CommonModel>, InterfaceCommonModel
    {

    }
    public class CategoryRepository : BaseRepository<Category>, InterfaceCategory
    {
    }
    public class ArticleRepository : BaseRepository<Article>, InterfaceArticle
    {
    }
    public class AttachmentRepository : BaseRepository<Attachment>, InterfaceAttachment
    {
    }
}
