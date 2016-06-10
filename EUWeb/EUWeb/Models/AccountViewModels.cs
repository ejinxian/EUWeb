using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EUWeb.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "代码")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "记住此浏览器?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "电子邮件")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }


        [Required(ErrorMessage ="必填")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "显示名")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        //[Required(ErrorMessage = "必填")]
        //[Display(Name = "密码")]
        //[StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        ///// <summary>
        ///// 确认密码
        ///// </summary>
        //[Required(ErrorMessage = "必填")]
        //[Compare("Password", ErrorMessage = "两次输入的密码不一致")]
        //[Display(Name = "确认密码")]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }

        ///// <summary>
        ///// 邮箱
        ///// </summary>
        //[Required(ErrorMessage = "必填")]
        //[Display(Name = "邮箱")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "Email格式不正确")]
        //public string Email { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "验证码不正确")]
        [Display(Name = "验证码")]
        public string VerificationCode { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }
    }
}
