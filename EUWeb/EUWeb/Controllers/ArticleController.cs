using EU.BLL;
using EU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EUWeb.Controllers
{
    /// <summary>
    /// 文章
    /// </summary>
    //[Authorize]
    public class ArticleController : Controller
    {
        private InterfaceArticleService articleService;
        private InterfaceCommonModelService commonModelService;
        public ArticleController() {
            articleService = new ArticleService();
            commonModelService = new CommonModelService();
        }
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <returns>视图页面</returns>
        //[ValidateInput(false)]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Add(Article article)
        {
            if (ModelState.IsValid)
            {
                CommonModel commonModel = new CommonModel();
                commonModel.Hits = 0;
                commonModel.Inputer = User.Identity.Name;
                commonModel.Model = "Article";
                commonModel.ReleaseDate = System.DateTime.Now;
                commonModel.Status = 99;
                article.CommonModel = commonModel;
                article = articleService.Add(article);
                if (article.ArticleID > 0)
                {
                    //附件处理
                    InterfaceAttachmentService _attachmentService = new AttachmentService();
                    //查询相关附件
                    var _attachments = _attachmentService.FindList(null, User.Identity.Name, string.Empty).ToList();
                    //遍历附件
                    foreach (var _att in _attachments)
                    {
                        var _filePath = Url.Content(_att.FilePath);
                        //文章首页图片或内容中使用了该附件则更改ModelID为文章保存后的ModelID
                        if ((article.CommonModel.DefaultPicUrl != null && article.CommonModel.DefaultPicUrl.IndexOf(_filePath) >= 0) || article.Content.IndexOf(_filePath) > 0)
                        {
                            _att.ModelID = article.ModelID;
                            _attachmentService.Update(_att);
                        }
                        //未使用改附件则删除附件和数据库中的记录
                        else
                        {
                            System.IO.File.Delete(Server.MapPath(_att.FilePath));
                            _attachmentService.Delete(_att);
                        }
                    }
                    //return View("AddSucess", article);
                }
            }
            return View();
        }
        /// <summary>
        /// 文章列表Json【注意权限问题，普通人员是否可以访问？】
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="input">录入</param>
        /// <param name="category">栏目</param>
        /// <param name="fromDate">日期起</param>
        /// <param name="toDate">日期止</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页记录</param>
        /// <returns></returns>
        public ActionResult JsonList(string title, string input, Nullable<int> category, Nullable<DateTime> fromDate, Nullable<DateTime> toDate, int pageIndex = 1, int pageSize = 20)
        {
            if (category == null) category = 0;
            int _total;
            var _rows = commonModelService.FindPageList(out _total, pageIndex, pageSize, "Article", title, (int)category, input, fromDate, toDate, 0).Select(
                cm => new EUWeb.Models.CommonModelViewModel()
                {
                    CategoryID = cm.CategoryID,
                    CategoryName = "123",//cm.Category.Name,
                    DefaultPicUrl = cm.DefaultPicUrl,
                    Hits = cm.Hits,
                    Inputer = cm.Inputer,
                    Model = cm.Model,
                    ModelID = cm.ModelID,
                    ReleaseDate = cm.ReleaseDate,
                    Status = cm.Status,
                    Title = cm.Title
                });
            return Json(new { total = _total, rows = _rows.ToList() });
        }
        /// <summary>
        /// 全部文章
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
    }
}