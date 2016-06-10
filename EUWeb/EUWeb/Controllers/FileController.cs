
using EUWeb.Models.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EUWeb.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ReadFile()
        {
            var _uploadConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~").GetSection("UploadConfig") as UploadConfig;
            //文件最大限制
            int _maxSize = _uploadConfig.MaxSize;
            //文件路径
            string _fileParth = _uploadConfig.Path;
            string _dirName;
            //允许上传的类型
            Hashtable extTable = new Hashtable();
            extTable.Add("image", _uploadConfig.ImageExt);
            extTable.Add("flash", _uploadConfig.FileExt);
            extTable.Add("media", _uploadConfig.MediaExt);
            extTable.Add("file", _uploadConfig.FileExt);
            return View();
        }
        public ActionResult WriteFile()
        {
            var _uploadConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~").GetSection("UploadConfig") as UploadConfig;
            //文件最大限制
            int _maxSize = _uploadConfig.MaxSize;
            _uploadConfig.FileExt = "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2";
            _uploadConfig.FlashExt = "swf,flv";
            _uploadConfig.ImageExt = "gif,jpg,jpeg,png,bmp";
            _uploadConfig.MediaExt = "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb";
            _uploadConfig.Path = "Upload";
            _uploadConfig.CurrentConfiguration.Save();
            return View();
        }
    }
}