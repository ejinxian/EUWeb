using EU.DAL;
using EU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace EU.BLL
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    public class UserService: BaseService<User>, InterfaceUserService
    {
        public UserService():base(RepositoryFactory.UserRepository)
        {

        }


        public bool Exist(string userName)
        {
            return CurrentRepository.Exist(u => u.UserName == userName);
        }

        public User Find(string userName)
        {
            return CurrentRepository.Find(u => u.UserName == userName);
        }

        public User Find(int userID)
        {
            return CurrentRepository.Find(u => u.UserID == userID);
        }

        public IQueryable<User> FindPageList(int pageIndex, int pageSize, out int totalRecord, int order)
        {
            //switch(order)
            //{
            //    case 0: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.UserID);
            //    case 1: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, false, u => u.UserID);
            //    case 2: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.RegistrationTime);
            //    case 3: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, false, u => u.RegistrationTime);
            //    case 4: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.LoginTime);
            //    case 5: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, false, u => u.LoginTime);
            //    default: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.UserID);
            //}
            bool _isAsc = true;
            string _orderName = string.Empty;
            switch (order)
            {
                case 0:
                    _isAsc = true;
                    _orderName = "UserID";
                    break;
                case 1:
                    _isAsc = false;
                    _orderName = "UserID";
                    break;
                case 2:
                    _isAsc = true;
                    _orderName = "RegistrationTime";
                    break;
                case 3:
                    _isAsc = false;
                    _orderName = "RegistrationTime";
                    break;
                case 4:
                    _isAsc = true;
                    _orderName = "LoginTime";
                    break;
                case 5:
                    _isAsc = false;
                    _orderName = "LoginTime";
                    break;
                default:
                    _isAsc = false;
                    _orderName = "UserID";
                    break;
            }
            return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true,_isAsc, _orderName);

        }
        /// <summary>
        /// 访问请求身份的用户数据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="authenticationType"></param>
        /// <returns></returns>

        public ClaimsIdentity CreateIdentity(User user, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            _identity.AddClaim(new Claim("DisplayName", user.DisplayName));
            return _identity;
        }
    }
}
