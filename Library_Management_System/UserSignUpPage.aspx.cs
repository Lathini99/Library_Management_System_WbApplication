using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class UserSignUpPage : System.Web.UI.Page
    {
        string strconnection= ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // sign up button process
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkUserExists())
            {
                Response.Write("<script>alert('User is Already Exist with this User ID, try other ID');</script>");
            }
            else {
                try
                {
                    SqlConnection connection = new SqlConnection(strconnection);
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO member_tbl(full_name,dob,contact_no,email,province,district,address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@province,@district,@address,@member_id,@password,@account_status)", connection);
                    cmd.Parameters.AddWithValue("@full_name", fullnametxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", dobtxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact_no", contactnotxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", emailtxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@province", provinceDDL.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@district", districtDDL.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", addresstxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_id", memberidtxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", pwdtxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@account_status", "Pending");
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    clearForm();
                    Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
        bool checkUserExists()
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
        void clearForm()
        {
            memberidtxt.Text = "";
            fullnametxt.Text = "";
            
            dobtxt.Text = "";
            contactnotxt.Text = "";
            emailtxt.Text = "";
            provinceDDL.SelectedIndex = 0; // Assuming 0 represents the default option
            districtDDL.SelectedIndex = 0;
            //provinceDDL.Text = "";
            //districtDDL.Text = "";
            addresstxt.Text = "";
            pwdtxt.Text = "";

        }
    }
}