using EU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.BLL
{
    /// <summary>
    /// 栏目接口
    /// </summary>
    public interface InterfaceCategoryService: InterfaceBaseService<Category>
    {

    }
    public interface InterfaceArticleService : InterfaceBaseService<Article>
    {

    }
    public interface InterfaceAttachmentService : InterfaceBaseService<Attachment>
    {
        /// <summary>
        ///  查找附件列表
        /// </summary>
        /// <param name="modelID">公共模型ID</param>
        /// <param name="owner">所有者</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        IQueryable<Models.Attachment> FindList(Nullable<int> modelID, string owner, string type);
        /// <summary>
        /// 查找附件列表
        /// </summary>
        /// <param name="modelID">公共模型ID</param>
        /// <param name="owner">所有者</param>
        /// <param name="type">所有者</param>
        /// <param name="withModelIDNull">包含ModelID为Null的</param>
        /// <returns></returns>
        IQueryable<Models.Attachment> FindList(int modelID, string owner, string type, bool withModelIDNull);
    }
    public interface InterfaceCommonModelService : InterfaceBaseService<CommonModel>
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="entitys">数据实体集</param>
        /// <param name="roderCode">排序代码[默认：ID降序]</param>
        /// <returns></returns>
        IQueryable<CommonModel> Order(IQueryable<CommonModel> entitys, int roderCode);

        /// <summary>
        /// 查询分页数据列表
        /// </summary>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="model">模型【All全部】</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="title">标题【不使用设置空字符串】</param>
        /// <param name="categoryID">栏目ID【不使用设0】</param>
        /// <param name="inputer">用户名【不使用设置空字符串】</param>
        /// <param name="fromDate">起始日期【可为null】</param>
        /// <param name="toDate">截止日期【可为null】</param>
        /// <param name="orderCode">排序码</param>
        /// <returns>分页数据列表</returns>
        IQueryable<CommonModel> FindPageList(out int totalRecord, int pageIndex, int pageSize, string model, string title, int categoryID, string inputer, Nullable<DateTime> fromDate, Nullable<DateTime> toDate, int orderCode);
    }
}
