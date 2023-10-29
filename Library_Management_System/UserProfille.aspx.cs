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
    public partial class UserProfille : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"].ToString() == "" || Session["userid"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        //update btn
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["userid"].ToString() == "" || Session["userid"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                string password = "";
                if (newpwdtxt.Text.Trim() == "")
                {
                    password = oldpwdtxt.Text.Trim();
                }
                else
                {
                    password = newpwdtxt.Text.Trim();
                }
                try
                {
                    SqlConnection con = new SqlConnection(strconnection);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }


                    SqlCommand cmd = new SqlCommand("update member_tbl set full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, province=@province, district=@district, address=@address, password=@password, account_status=@account_status WHERE member_id='" + Session["userid"].ToString().Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@full_name", fullnametxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", dobtxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact_no", contactnotxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", emailtxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@province", provinceddl.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@district", districtddl.SelectedItem.Value);
                  
                    cmd.Parameters.AddWithValue("@address", addresstxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@account_status", "Pending");

                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                    {

                        Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                        getUserPersonalDetails();
                        getUserBookData();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invaid entry');</script>");
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }

        }



        void getUserBookData()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tbl where member_id='" + Session["userid"].ToString() + "';", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_tbl where member_id='" + Session["userid"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                fullnametxt.Text = dt.Rows[0]["full_name"].ToString();
                dobtxt.Text = dt.Rows[0]["dob"].ToString();
                contactnotxt.Text = dt.Rows[0]["contact_no"].ToString();
                emailtxt.Text = dt.Rows[0]["email"].ToString();
                provinceddl.SelectedValue = dt.Rows[0]["province"].ToString().Trim();
                districtddl.SelectedValue = dt.Rows[0]["district"].ToString().Trim();  
                addresstxt.Text = dt.Rows[0]["address"].ToString();
                memberidtxt.Text = dt.Rows[0]["member_id"].ToString();
                oldpwdtxt.Text = dt.Rows[0]["password"].ToString();

                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "Active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "Pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "Deactivate")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    
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
    }
}