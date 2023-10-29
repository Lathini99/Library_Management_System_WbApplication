using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // admin login btn event
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand Cmd = new SqlCommand("select * from admin_login_tbl where username='" + usernametxt.Text.Trim() + "' AND password='" + pwdtxt.Text.Trim() + "'", connection);
                SqlDataReader DataReader = Cmd.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        Response.Write("<script>alert('" + DataReader.GetValue(0).ToString() + "');</script>");
                        Session["userid"] = DataReader.GetValue(0).ToString();
                        Session["fullname"] = DataReader.GetValue(2).ToString();
                        Session["role"] = "admin";
                       
                    }
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Invalid credentials');</script>");
            }

        }
    }
}