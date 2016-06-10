using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUWeb.Models.Config
{
    /// <summary>
    /// 上传设置
    /// </summary>
   public class UploadConfig:ConfigurationSection
    {
        private static ConfigurationProperty _property = new ConfigurationProperty(string.Empty, typeof(KeyValueElementCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
        /// <summary>
        /// 配置列表
        /// </summary>
        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        private KeyValueElementCollection KeyValues
        {
            get { return (KeyValueElementCollection)base[_property]; }
            set { base[_property] = value; }
        }
        /// <summary>
        /// 最大大小
        /// </summary>
        public int MaxSize
        {
            get
            {
                int _value = 0;
                if (KeyValues["MaxSize"] != null) int.TryParse(KeyValues["MaxSize"].Value, out _value);
                return _value;
            }
            set
            {
                if (KeyValues["MaxSize"] == null) KeyValues["MaxSize"] = new KeyValueElement() { Key = "MaxSize", Value = value.ToString() };
                else KeyValues["MaxSize"].Value = value.ToString();
            }
        }
        /// <summary>
        /// 上传目录
        /// 为应用程序目录起的文件夹名，前面不带~/
        /// </summary>
        public string Path
        {
            get
            {
                if (KeyValues["Path"] == null) return "Upload";
                return KeyValues["Path"].Value;
            }
            set
            {
                if (KeyValues["Path"] == null) KeyValues["Path"] = new KeyValueElement() { Key = "Path", Value = value };
                else KeyValues["Path"].Value = value;
            }
        }
        /// <summary>
        /// 允许上传的图片类型文件扩展，多个用“,”隔开
        /// </summary>
        public string ImageExt
        {
            get
            {
                if (KeyValues["ImageExt"] == null) return string.Empty;
                return KeyValues["ImageExt"].Value;
            }
            set
            {
                if (KeyValues["ImageExt"] == null) KeyValues["ImageExt"] = new KeyValueElement() { Key = "ImageExt", Value = value };
                else KeyValues["ImageExt"].Value = value;
            }
        }
        /// <summary>
        /// 允许上传的Flash类型文件扩展，多个用“,”隔开
        /// </summary>
        public string FlashExt
        {
            get
            {
                if (KeyValues["FlashExt"] == null) return string.Empty;
                return KeyValues["FlashExt"].Value;
            }
            set
            {
                if (KeyValues["FlashExt"] == null) KeyValues["FlashExt"] = new KeyValueElement() { Key = "FlashExt", Value = value };
                else KeyValues["FlashExt"].Value = value;
            }
        }
        /// <summary>
        /// 允许上传的媒体类型文件扩展，多个用“,”隔开
        /// </summary>
        public string MediaExt
        {
            get
            {
                if (KeyValues["MediaExt"] == null) return string.Empty;
                return KeyValues["MediaExt"].Value;
            }
            set
            {
                if (KeyValues["MediaExt"] == null) KeyValues["MediaExt"] = new KeyValueElement() { Key = "MediaExt", Value = value };
                else KeyValues["MediaExt"].Value = value;
            }
        }
        /// <summary>
        /// 允许上传的文件类型文件扩展，多个用“,”隔开
        /// </summary>
        public string FileExt
        {
            get
            {
                if (KeyValues["FileExt"] == null) return string.Empty;
                return KeyValues["FileExt"].Value;
            }
            set
            {
                if (KeyValues["FileExt"] == null) KeyValues["FileExt"] = new KeyValueElement() { Key = "FileExt", Value = value };
                else KeyValues["FileExt"].Value = value;
            }
        }
        public void ReadFile()
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
        }
        public void WriteFile()
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
        }

    }
}
