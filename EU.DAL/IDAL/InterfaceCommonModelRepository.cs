using EU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.DAL
{

    //public interface InterfaceCommonModelRepository : InterfaceBaseRepository<CommonModel>
    //{
    //}
    public interface InterfaceCommonModel : InterfaceBaseRepository<CommonModel>
    {
    }
    public interface InterfaceCategory : InterfaceBaseRepository<Category>
    {
    }
    public interface InterfaceArticle : InterfaceBaseRepository<Article>
    {
    }
    public interface InterfaceAttachment : InterfaceBaseRepository<Attachment>
    {
    }
}
