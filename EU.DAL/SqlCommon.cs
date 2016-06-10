using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.DAL
{
    /// <summary>
    /// 执行SQL语句
    /// </summary>
   public static class SqlCommon
    {
        public static DataTable GetDataTable()
        {
            Helpers.MySqlHelper mySql = new Helpers.MySqlHelper("");
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM `cus_dealer`";
            MySqlParameter[] myArr = new MySqlParameter[] { };
            return mySql.ExecuteDataTable(sql, myArr);
        }
    }
}
