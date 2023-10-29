using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class userlogin : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // login button event
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand Cmd = new SqlCommand("select * from member_tbl where member_id='" + useridtxt.Text.Trim() + "' AND password='" + pwdtxt.Text.Trim() + "'", connection);
                SqlDataReader DataReader = Cmd.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        Response.Write("<script>alert('Login Successfully');</script>");
                        Session["userid"]= DataReader.GetValue(7).ToString();
                        Session["fullname"] = DataReader.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = DataReader.GetValue(9).ToString();
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