using EU.BLL;
using EU.Models;
using EUWeb.Models;
using Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EUWeb.Controllers
{
    public class UserController : Controller
    {


        #region 属性
        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }
        #endregion
        UserService userService = new UserService();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
        /// <summary>
        /// 显示资料
        /// </summary>
        /// <returns></returns>
        public ActionResult Details()
        {
            return View(userService.Find(User.Identity.Name));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult VerificationCode()
        {
            string verificationCode = Security.CreateVerificationText(6);
            Bitmap _img = Security.CreateVerificationImage(verificationCode, 160, 30);
            _img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            TempData["VerificationCode"] = verificationCode.ToUpper();
            return null;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="returnUrl">返回Url</param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl)
        {
            return View();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            //if (ModelState.IsValid)
            //{
                var _user = userService.Find(loginViewModel.UserName);
                if (_user == null) ModelState.AddModelError("UserName", "用户名不存在");
                else if (_user.Password == Security.Sha256(loginViewModel.Password))
                {
                    _user.LoginTime = System.DateTime.Now;
                    _user.LoginIP = Request.UserHostAddress;
                    var _identity = userService.CreateIdentity(_user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = loginViewModel.RememberMe }, _identity);
                // return RedirectToAction("Index", "Home");
                return RedirectToAction("Details", "User");
            }
                else ModelState.AddModelError("Password", "密码错误");
            //}
            return View();
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {           
            if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() != register.VerificationCode.ToUpper())
            {
                ModelState.AddModelError("VerificationCode", "验证码不正确");
                return View(register);
            }
            if (ModelState.IsValid)
            {

                if (userService.Exist(register.UserName))
                {
                    ModelState.AddModelError("UserName", "用户名已存在");
                } else {
                    Random rd = new Random();
                    int num = rd.Next(100000, 1000000);
                    User _user = new User() {
                       UserName = register.UserName,
                       //默认用户组代码写这里
                       DisplayName = register.DisplayName,
                       Password = Security.Sha256(register.Password),
                       //邮箱验证与邮箱唯一性问题
                       Email = register.Email,
                       //用户状态问题
                       Status = 0,
                       RegistrationTime = System.DateTime.Now
                    };
                    _user = userService.Add(_user);
                    if (_user.UserID > 0)
                    {
                        var _identity = userService.CreateIdentity(_user,DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignIn(_identity);
                        return RedirectToAction("Index","Home");
                        //return Content("注册成功！");
                        //AuthenticationManager.SignIn();
                    } else {
                        ModelState.AddModelError("", "注册失败！");
                    }
                }
            }
            return View(register);
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect(Url.Content("~/"));
        }
        /// <summary>
        /// 菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult Menu()
        {
            return View();
        }
        /// <summary>
        /// 修改资料
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Modify()
        {

            var _user = userService.Find(User.Identity.Name);
            if (_user == null) ModelState.AddModelError("", "用户不存在");
            else
            {
                if (TryUpdateModel(_user, new string[] { "DisplayName", "Email" }))
                {
                    if (ModelState.IsValid)
                    {
                        if (userService.Update(_user)) ModelState.AddModelError("", "修改成功！");
                        else ModelState.AddModelError("", "无需要修改的资料");
                    }
                }
                else ModelState.AddModelError("", "更新模型数据失败");
            }
            return View("Details", _user);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ChangePassword() {
            return View();
        }

        /// <summary>
        /// 更新密码到数据库
        /// </summary>
        /// <param name="passwordViewModel"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ChangePassword(ChangePasswordViewModel passwordViewModel)
        {
            if (ModelState.IsValid)
            {
                var _user = userService.Find(User.Identity.Name);
                if (_user.Password == Security.Sha256(passwordViewModel.OldPassword))
                {
                    _user.Password = Security.Sha256(passwordViewModel.NewPassword);
                    if (userService.Update(_user))
                    {
                        ModelState.AddModelError("", "修改密码成功");
                    } else{
                        ModelState.AddModelError("", "修改密码失败");
                    }
                }
                else ModelState.AddModelError("", "原密码错误");
            }
            return View(passwordViewModel);
        }
    }
}
