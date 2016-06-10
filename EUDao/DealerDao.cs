using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUDao
{

    public static class DealerDao
    {      
        public static DataTable GetDataTable() {
            Helpers.MySqlHelper mySql = new Helpers.MySqlHelper("");
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM `cus_dealer`";
            MySqlParameter[] myArr = new MySqlParameter[] { };
            return mySql.ExecuteDataTable(sql, myArr);
        }
    }
}
