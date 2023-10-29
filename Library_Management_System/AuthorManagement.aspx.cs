using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Library_Management_System
{
    public partial class AuthorManagement : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
             GridView1.DataBind();
        }
        //add btn event
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                Response.Write("<script>alert('Author with this ID already Exist. You cannot add another Author with the same Author ID');</script>");
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(strconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    SqlCommand Cmd = new SqlCommand("INSERT INTO author_tbl(author_id,author_name) values(@author_id,@author_name)", connection);

                    Cmd.Parameters.AddWithValue("@author_id", authoridtxt.Text.Trim());
                    Cmd.Parameters.AddWithValue("@author_name", authornametxt.Text.Trim());

                    Cmd.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("<script>alert('Author added Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }
        }
        //update btn
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(strconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand Cmd = new SqlCommand("UPDATE author_tbl SET author_name=@author_name WHERE author_id='" + authoridtxt.Text.Trim() + "'", connection);

                    Cmd.Parameters.AddWithValue("@author_name", authornametxt.Text.Trim());

                    Cmd.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("<script>alert('Author Updated Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Author does not exist');</script>");
            }
        }
        // delete btn
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(strconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand Cmd = new SqlCommand("DELETE from author_tbl WHERE author_id='" + authoridtxt.Text.Trim() + "'", connection);

                    Cmd.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("<script>alert('Author Deleted Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Author does not exist');</script>");
            }

        }

        //go btn
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand Cmd = new SqlCommand("SELECT * from author_tbl where author_id='" + authoridtxt.Text.Trim() + "';", connection);
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    authornametxt.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        bool checkAuthorExists()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand Cmd = new SqlCommand("SELECT * from author_tbl where author_id='" + authoridtxt.Text.Trim() + "';", connection);
                SqlDataAdapter DataAdap = new SqlDataAdapter(Cmd);
                DataTable Data_tbl = new DataTable();
                DataAdap.Fill(Data_tbl);
                if (Data_tbl.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void clearForm()
        {
            authoridtxt.Text = "";
            authornametxt.Text = "";
        }

       
    }
}