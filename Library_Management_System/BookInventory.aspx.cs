using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Library_Management_System
{
    public partial class BookInventory : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            getAuthorPublisherValues();
            GridView1.DataBind();
        }
        //search btn
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_inventory_tbl WHERE book_id='" + bookidtxt.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    booknametxt.Text = dt.Rows[0]["book_name"].ToString();
                    publishdatetxt.Text = dt.Rows[0]["publish_date"].ToString();
                  
                    editiontxt.Text = dt.Rows[0]["edition"].ToString();
                    bookpricetxt.Text = dt.Rows[0]["book_price"].ToString().Trim();
                    pagestxt.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    actualstocktxt.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    currentstocktxt.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    
                    bookdescriptiontxt.Text = dt.Rows[0]["book_description"].ToString();
                    issuedbookstxt.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    languageDDL.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    publisherDDL.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    authorDDL.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    genreLB.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < genreLB.Items.Count; j++)
                        {
                            if (genreLB.Items[j].ToString() == genre[i])
                            {
                                genreLB.Items[j].Selected = true;

                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }
        //add btn
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkBookExists())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
            }
            else
            {
                try
                {
                    string genres = "";
                    foreach (int i in genreLB.GetSelectedIndices())
                    {
                        genres = genres + genreLB.Items[i] + ",";
                    }
                    // genres = Adventure,Self Help,
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/book_inventory/books1.png";
                    string filename = Path.GetFileName(FileUpload.PostedFile.FileName);
                    FileUpload.SaveAs(Server.MapPath("books_images/" + filename));
                    filepath = "~/books_images/" + filename;


                    SqlConnection connection = new SqlConnection(strconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO book_inventory_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_price,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_price,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", connection);

                    cmd.Parameters.AddWithValue("@book_id", bookidtxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", booknametxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", authorDDL.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", publisherDDL.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", publishdatetxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", languageDDL.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", editiontxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_price", bookpricetxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", pagestxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", bookdescriptiontxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actualstocktxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", currentstocktxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("<script>alert('Book added successfully.');</script>");
                    GridView1.DataBind();
                    clearForm();
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
            if (checkBookExists())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(actualstocktxt.Text.Trim());
                    int current_stock = Convert.ToInt32(currentstocktxt.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            currentstocktxt.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in genreLB.GetSelectedIndices())
                    {
                        genres = genres + genreLB.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/books_images/books1";
                    string filename = Path.GetFileName(FileUpload.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload.SaveAs(Server.MapPath("books_images/" + filename));
                        filepath = "~/books_images/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strconnection);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_inventory_tbl set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_price=@book_price, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + bookidtxt.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", booknametxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", authorDDL.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", publisherDDL.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date",publishdatetxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", languageDDL.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", editiontxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_price", bookpricetxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", pagestxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", bookdescriptiontxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully');</script>");
                    clearForm();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }

        }
        //delete btn
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkBookExists())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(strconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from book_inventory_tbl WHERE book_id='" + bookidtxt.Text.Trim() + "'", connection);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");
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
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }

        void getAuthorPublisherValues()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name from author_tbal;", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                authorDDL.DataSource = dataTable;
                authorDDL.DataValueField = "author_name";
                authorDDL.DataBind();

                cmd = new SqlCommand("SELECT publisher_name from publisher_tbal;", connection);
                dataAdapter = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                publisherDDL.DataSource = dataTable;
                publisherDDL.DataValueField = "publisher_name";
                publisherDDL.DataBind();

            }
            catch (Exception ex)
            {

            }
        }
        bool checkBookExists()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_inventory_tbl where book_id='" + bookidtxt.Text.Trim() + "' OR book_name='" + booknametxt.Text.Trim() + "';", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
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
            booknametxt.Text = "";
            bookidtxt.Text = "";
            //authorDDL.Text = "";
            authorDDL.SelectedIndex = 0;
            //publisherDDL.Text = "";
            publisherDDL.SelectedIndex = 0;
            publishdatetxt.Text = "";
            languageDDL.SelectedIndex = 0;
            editiontxt.Text = "";
            bookpricetxt.Text = "";
            pagestxt.Text = "";
            bookdescriptiontxt.Text = "";
          
            currentstocktxt.Text = "";
            actualstocktxt.Text = "";
            issuedbookstxt.Text = "";
            //genreLB.Text = "";
            genreLB.SelectedIndex = -1;

        }

    }
}