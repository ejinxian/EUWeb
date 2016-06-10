using EU.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EU.DAL
{
    /// <summary>
    /// 简单工厂
    /// </summary>
   public class ContextFactory
    {
        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static DALDbContext GetCurrentContext()
        {
            DALDbContext _nContext = CallContext.GetData("DALDbContext") as DALDbContext;
            if (_nContext == null)
            {
                _nContext = new DALDbContext();
                CallContext.SetData("DALDbContext", _nContext);
            }
            return _nContext;
        }
    }
}
