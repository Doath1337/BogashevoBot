using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace testbot2
{

    class DataBase
    {
        SqlConnection connect = new SqlConnection(@"Data Sourse= DESKTOP-EP7F3E9; Initial Catalog =TeoreticalTest;Integrated Secururity = True");

        public void openConnection()
        {
            if(connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }
            
        }
        public void closeConnection()
        {
            if (connect.State == System.Data.ConnectionState.Open)
            {
                connect.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return connect;
        }
    }
}
