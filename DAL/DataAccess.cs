using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DataAccess
    {

        string strConn = "Server=DESKTOP-J5V8AIP;Database=CSDL_QLSP;user id=sa;pwd=123";
        protected SqlConnection Conn = null;
        public void OpenConnection()
        {
            if (Conn == null)
            {
                Conn = new SqlConnection(strConn);
            }
            if(Conn.State== ConnectionState.Closed)
            {
                Conn.Open();
            } 
        }
        public void ClosedConnection()
        {
            if (Conn!=null&&Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }

        }
    }
}
