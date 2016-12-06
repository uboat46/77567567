using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    class ConexionBD
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;

        public SqlConnection Connect()
        {
            String pc = "CC201-22";
            String BD = "Data Source="+pc+";Initial Catalog=Users;Persist Security Info=True;User ID=sa;Password=sqladmin";
            con = new SqlConnection(BD);
            try
            {
                con.Open();
                return con;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Boolean Login(String user, String password)
        {
            con = Connect();
            Boolean res = false;
            if (con != null)
            {
                String query = "SELECT Users.passwd FROM Users WHERE Users.username = '" + user + "'";
                cmd = new SqlCommand(query, con);
                try
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr.GetString(0).Equals(password))
                        {
                            res = true;
                        }
                    }
                    dr.Close();
                    con.Close();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
            return res;
        }


        public void TraeUsers(DataGrid dataGrid1)
        {
            con = Connect();
            if (con != null)
            {
                String query = "SELECT Users.* FROM Users";
                cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();
                dataGrid1.ItemsSource = dr;
               

            }
        }
    }
}
