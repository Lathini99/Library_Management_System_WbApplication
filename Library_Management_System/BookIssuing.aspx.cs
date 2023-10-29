using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Library_Management_System
{
    public partial class BookIssuing : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        // issue btn
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkBookExist() && checkMemberExist() && checkBooks())
            {

                if (checkIssueEntryExist())
                {
                    Response.Write("<script>alert('This Member already has this book');</script>");
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

                        SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id,member_name,book_id,book_name,issue_date,due_date) values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", connection);

                        cmd.Parameters.AddWithValue("@member_id", memberidtxt.Text.Trim());
                        cmd.Parameters.AddWithValue("@member_name", membernametxt.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_id", bookidtxt.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_name", booknametxt.Text.Trim());
                        cmd.Parameters.AddWithValue("@issue_date", issuedatetxt.Text.Trim());
                        cmd.Parameters.AddWithValue("@due_date", returndatetxt.Text.Trim());

                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("update  book_inventory_tbl set current_stock = current_stock-1 WHERE book_id='" + bookidtxt.Text.Trim() + "'", connection);

                        cmd.ExecuteNonQuery();

                        connection.Close();
                        Response.Write("<script>alert('Book Issued Successfully');</script>");

                        GridView1.DataBind();
                        clearForm();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }

            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID or He get more than 2 books');</script>");
            }
        }
        // return btn
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkBookExist() && checkMemberExist())
            {

                if (checkIssueEntryExist())
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(strconnection);
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }


                        SqlCommand cmd = new SqlCommand("Delete from book_issue_tbl WHERE book_id='" + bookidtxt.Text.Trim() + "' AND member_id='" + memberidtxt.Text.Trim() + "'", connection);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {

                            cmd = new SqlCommand("update book_inventory_tbl set current_stock = current_stock+1 WHERE book_id='" + bookidtxt.Text.Trim() + "'", connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();

                            Response.Write("<script>alert('Book Returned Successfully');</script>");
                            GridView1.DataBind();

                            connection.Close();
                            clearForm();
                        }
                        else
                        {
                            Response.Write("<script>alert('Error - Invalid details');</script>");
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('This Entry does not exist');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }

        }
        // search btn
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand Cmd = new SqlCommand("SELECT book_name from book_inventory_tbl where book_id='" + bookidtxt.Text.Trim() + "';", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    booknametxt.Text = dataTable.Rows[0][0].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

                Cmd = new SqlCommand("SELECT full_name from member_tbl where member_id='" + memberidtxt.Text.Trim() + "';", connection);
                dataAdapter = new SqlDataAdapter(Cmd);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    membernametxt.Text = dataTable.Rows[0][0].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Member ID');</script>");
                }


            }
            catch (Exception ex)
            {

            }
        }

        bool checkBooks()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand Cmd = new SqlCommand("SELECT * from book_issue_tbl where member_id='" + memberidtxt.Text.Trim() + "';", connection);
                SqlDataAdapter DataAdap = new SqlDataAdapter(Cmd);
                DataTable Data_tbl = new DataTable();
                DataAdap.Fill(Data_tbl);
                if (Data_tbl.Rows.Count <= 1)
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
        bool checkMemberExist()
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
        bool checkBookExist()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand Cmd = new SqlCommand("SELECT * from book_inventory_tbl where book_id='" + bookidtxt.Text.Trim() + "' ;", connection); //AND current_stock >0
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
        bool checkIssueEntryExist()
        {
            try
            {
                SqlConnection connection= new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl WHERE member_id='" + memberidtxt.Text.Trim() + "' AND book_id='" + bookidtxt.Text.Trim() + "'", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
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
                return false;
            }

        }
       
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime todayDate = DateTime.Today;
                    if (todayDate > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void clearForm()
        {
            memberidtxt.Text = "";
            bookidtxt.Text = "";
            membernametxt.Text = "";
            booknametxt.Text = "";
            issuedatetxt.Text = "";
            returndatetxt.Text = "";
        }

    }
}