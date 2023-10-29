using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class PublisherManagement : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //Add btn
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                Response.Write("<script>alert('Publisher with this ID already Exist. You cannot add another Publisher with the same Publisher ID');</script>");
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
                    SqlCommand Cmd = new SqlCommand("INSERT INTO publisher_tbl(publisher_id,publisher_name) values(@publisher_id,@publisher_name)", connection);

                    Cmd.Parameters.AddWithValue("@publisher_id", publisheridtxt.Text.Trim());
                    Cmd.Parameters.AddWithValue("@publisher_name", publishernametxt.Text.Trim());

                    Cmd.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("<script>alert('Publisher added Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }
        }
        //Update btn
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(strconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand Cmd = new SqlCommand("UPDATE publisher_tbl SET publisher_name=@publisher_name WHERE publisher_id='" + publisheridtxt.Text.Trim() + "'", connection);

                    Cmd.Parameters.AddWithValue("@publisher_name", publishernametxt.Text.Trim());

                    Cmd.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("<script>alert('Publisher Updated Successfully');</script>");
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
                Response.Write("<script>alert('Publisher does not exist');</script>");
            }
        }
        //Delete btn
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(strconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand Cmd = new SqlCommand("DELETE from publisher_tbl WHERE publisher_id='" + publisheridtxt.Text.Trim() + "'", connection);

                    Cmd.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("<script>alert('Publisher Deleted Successfully');</script>");
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
                Response.Write("<script>alert('Publisher does not exist');</script>");
            }
        }
        //Go btn
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand Cmd = new SqlCommand("SELECT * from publisher_tbl where publisher_id='" + publisheridtxt.Text.Trim() + "';", connection);
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    publishernametxt.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }
        bool checkPublisherExists()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand Cmd = new SqlCommand("SELECT * from publisher_tbl where publisher_id='" + publisheridtxt.Text.Trim() + "';", connection);
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
            publisheridtxt.Text = "";
            publishernametxt.Text = "";
        }

    }
}