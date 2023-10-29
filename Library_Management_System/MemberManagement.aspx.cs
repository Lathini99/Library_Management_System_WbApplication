using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;

namespace Library_Management_System
{
    public partial class MemberManagement : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //Search btn
        
        //Active btn

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateAccountStatus();
           

        }
        /* Pending btn
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateAccountStatus("Pending");
        }
        // Deactivate btn
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateAccountStatus("Deactivate");
        }*/

        protected void LinkButton4_Click1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand Cmd = new SqlCommand("SELECT * from member_tbl where member_id='" + memberidtxt.Text.Trim() + "';", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    fullnametxt.Text = dataTable.Rows[0][0].ToString();
                    statustxt.Text = dataTable.Rows[0][9].ToString();
                    dobtxt.Text = dataTable.Rows[0][1].ToString();
                    contactnotxt.Text = dataTable.Rows[0][2].ToString();
                    emailtxt.Text = dataTable.Rows[0][3].ToString();
                    provincetxt.Text = dataTable.Rows[0][4].ToString();
                    districttxt.Text = dataTable.Rows[0][5].ToString();
                    addresstxt.Text = dataTable.Rows[0][6].ToString();
                    
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

        /*protected void LinkButton4_Click1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from member_table where member_id='" + memberidtxt.Text.Trim() + "'", con);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        fullnametxt.Text = dataReader.GetValue(0).ToString();
                        statustxt.Text = dataReader.GetValue(9).ToString();
                        dobtxt.Text = dataReader.GetValue(1).ToString();
                        contactnotxt.Text = dataReader.GetValue(2).ToString();
                        emailtxt.Text = dataReader.GetValue(3).ToString();
                        provincetxt.Text = dataReader.GetValue(4).ToString();
                        districttxt.Text = dataReader.GetValue(5).ToString();
                        addresstxt.Text = dataReader.GetValue(6).ToString();


                    }

                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
           
        }*/

        /*void searchMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from member_table where member_id='" + memberidtxt.Text.Trim() + "'", con);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        fullnametxt.Text = dataReader.GetValue(0).ToString();
                        statustxt.Text = dataReader.GetValue(9).ToString();
                        dobtxt.Text = dataReader.GetValue(1).ToString();
                        contactnotxt.Text = dataReader.GetValue(2).ToString();
                        emailtxt.Text = dataReader.GetValue(3).ToString();
                        provincetxt.Text = dataReader.GetValue(4).ToString();
                        districttxt.Text = dataReader.GetValue(5).ToString();
                        addresstxt.Text = dataReader.GetValue(6).ToString();
                     

                    }

                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }*/

        void updateAccountStatus()
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(strconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand Cmd = new SqlCommand("UPDATE member_tbl SET account_status=@account_status WHERE member_id='"  +memberidtxt.Text.Trim() + "'", connection);

                    Cmd.Parameters.AddWithValue("@account_status", statustxt.Text.Trim());

                    Cmd.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("<script>alert('Account status updated');</script>");
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
                Response.Write("<script>alert('Member does not exist');</script>");
            }
            /*if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strconnection);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_table SET account_status='" + status + "' WHERE member_id='" + memberidtxt.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Account Status Updated');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }*/

        }
        bool checkMemberExists()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand Cmd = new SqlCommand("SELECT * from member_tbl where member_id='" + memberidtxt.Text.Trim() + "';", connection);
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
        //delete user btn
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(strconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand Cmd = new SqlCommand("DELETE from member_tbl WHERE member_id='" + memberidtxt.Text.Trim() + "'", connection);

                    Cmd.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("<script>alert('Member Deleted Successfully');</script>");
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
                Response.Write("<script>alert('Member does not exist');</script>");
            }

        }
        void clearForm()
        {
            memberidtxt.Text = "";
            fullnametxt.Text = "";
            statustxt.Text = "";
            dobtxt.Text = "";
            contactnotxt.Text = "";
            emailtxt.Text = "";
            provincetxt.Text = "";
            districttxt.Text = "";
            addresstxt.Text = "";

        }

       
    }
}
