using EU.DAL;
using EU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.BLL
{
    /// <summary>
    /// 栏目
    /// </summary>
    public class CategoryService: BaseService<Category>, InterfaceCategoryService
    {
       
        public CategoryService() : base(RepositoryFactory.CategoryRepository) { }
    }
    /// <summary>
    /// 文章
    /// </summary>
    public class ArticleService : BaseService<Article>, InterfaceArticleService
    {

        public ArticleService() : base(RepositoryFactory.ArticleRepository) { }
    }
    /// <summary>
    /// 附件
    /// </summary>
    public class AttachmentService : BaseService<Attachment>, InterfaceAttachmentService
    {

        public AttachmentService() : base(RepositoryFactory.AttachmentRepository) { }

        public IQueryable<Attachment> FindList(Nullable<int> modelID, string owner, string type)
        {
            var _attachemts = CurrentRepository.Entities.Where(a => a.ModelID == modelID);
            if (!string.IsNullOrEmpty(owner)) _attachemts = _attachemts.Where(a => a.Owner == owner);
            if (!string.IsNullOrEmpty(type)) _attachemts = _attachemts.Where(a => a.Type == type);
            return _attachemts;
        }

        public IQueryable<Attachment> FindList(int modelID, string owner, string type, bool withModelIDNull)
        {
            var _attachemts = CurrentRepository.Entities;
            if (withModelIDNull) _attachemts = _attachemts.Where(a => a.ModelID == modelID || a.ModelID == null);
            else _attachemts = _attachemts.Where(a => a.ModelID == modelID);
            if (!string.IsNullOrEmpty(owner)) _attachemts = _attachemts.Where(a => a.Owner == owner);
            if (!string.IsNullOrEmpty(type)) _attachemts = _attachemts.Where(a => a.Type == type);
            return _attachemts;
        }
    }
    /// <summary>
    /// 公共
    /// </summary>
    public class CommonModelService : BaseService<CommonModel>, InterfaceCommonModelService
    {

        public CommonModelService() : base(RepositoryFactory.CommonModelRepository) { }

        public IQueryable<CommonModel> FindPageList(out int totalRecord, int pageIndex, int pageSize, string model, string title, int categoryID, string inputer, Nullable<DateTime> fromDate, Nullable<DateTime> toDate, int orderCode)
        {
            //获取实体列表
            IQueryable<CommonModel> _commonModels = CurrentRepository.Entities;
            if (model == null || model != "All") _commonModels = _commonModels.Where(cm => cm.Model == model);
            if (!string.IsNullOrEmpty(title)) _commonModels = _commonModels.Where(cm => cm.Title.Contains(title));
            if (categoryID > 0) _commonModels = _commonModels.Where(cm => cm.CategoryID == categoryID);
            if (!string.IsNullOrEmpty(inputer)) _commonModels = _commonModels.Where(cm => cm.Inputer == inputer);
            if (fromDate != null) _commonModels = _commonModels.Where(cm => cm.ReleaseDate >= fromDate);
            if (toDate != null) _commonModels = _commonModels.Where(cm => cm.ReleaseDate <= toDate);
            _commonModels = Order(_commonModels, orderCode);
            totalRecord = _commonModels.Count();
            return PageList(_commonModels, pageIndex, pageSize).AsQueryable();
        }

        public IQueryable<CommonModel> Order(IQueryable<CommonModel> entitys, int orderCode)
        {
            switch (orderCode)
            {
                //默认排序
                default:
                    entitys = entitys.OrderByDescending(cm => cm.ReleaseDate);
                    break;
            }
            return entitys;
        }
        public IQueryable<CommonModel> PageList(IQueryable<CommonModel> _commonModels, int pageIndex, int pageSize)
        {
            return _commonModels;
        }
    }    
}
