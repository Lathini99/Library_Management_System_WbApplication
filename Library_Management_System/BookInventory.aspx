<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookInventory.aspx.cs" Inherits="Library_Management_System.BookInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });

       function readURL(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();

               reader.onload = function (e) {
                   $('#imgview').attr('src', e.target.result);
               };

               reader.readAsDataURL(input.files[0]);
           }
       }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('images/library.jpg'); background-size: cover; min-height: 100vh; display: flex; align-items: center; justify-content: center; opacity:0.85">
        
     <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card" style="background: rgb(144, 9, 9, 0.65);">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img id="imgview" Height="150px" width="100px" src="books_images/books1.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col" style="color: white; font-weight: bold;">
                        <center>
                           <h4>Book Details</h4>
                        </center>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <hr style="border-top: 3px solid #000000;">
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload" runat="server" />
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-3" style="color: white; font-weight: bold;">
                        <label>Book ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="bookidtxt" runat="server" placeholder="Book ID"></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-9" style="color: white; font-weight: bold;">
                        <label>Book Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="booknametxt" runat="server" placeholder="Book Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Language</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="languageDDL" runat="server">
                              <asp:ListItem Text="Select one" Value="Select one" />
                              <asp:ListItem Text="English" Value="English" />
                              <asp:ListItem Text="Hindi" Value="Hindi" />
                              <asp:ListItem Text="Sinhala" Value="Sinhala" />
                              <asp:ListItem Text="French" Value="French" />
                              <asp:ListItem Text="German" Value="German" />
                              <asp:ListItem Text="Tamil" Value="Tamil" />
                           </asp:DropDownList>
                        </div>
                        <label>Publisher Name</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="publisherDDL" runat="server">
                              <asp:ListItem Text="Select one" Value="Select one" />
                              <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                              <asp:ListItem Text="Publisher 2" Value="Publisher 2" />
                              <asp:ListItem Text="Susara" Value="Susara" />
                              <asp:ListItem Text="Epa" Value="Epa" />
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Author Name</label>
                        <div class="form-group">

                           <asp:DropDownList class="form-control" ID="authorDDL" runat="server">
                              <asp:ListItem Text="Select one" Value="Select one" />
                              <asp:ListItem Text="a1" Value="a1" />
                              <asp:ListItem Text="a2" Value="a2" />
                              <asp:ListItem Text="Charles Dickens" Value="Charles Dickens" />
                              <asp:ListItem Text="Sujeewa Prasanna" Value="Sujeewa Prasanna" />
                                  <asp:ListItem Text="Ellie Terry" Value="Elli Terry" />
                           </asp:DropDownList>
                        </div>
                        <label>Publish Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="publishdatetxt" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Genre</label>
                        <div class="form-group">
                           <asp:ListBox CssClass="form-control" ID="genreLB" runat="server" SelectionMode="Multiple" Rows="5">
                              <asp:ListItem Text="Action" Value="Action" />
                              <asp:ListItem Text="Adventure" Value="Adventure" />
                              <asp:ListItem Text="Comic Book" Value="Comic Book" />
                              <asp:ListItem Text="Self Help" Value="Self Help" />
                              <asp:ListItem Text="Motivation" Value="Motivation" />
                              <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                              <asp:ListItem Text="Wellness" Value="Wellness" />
                              <asp:ListItem Text="Crime" Value="Crime" />
                              <asp:ListItem Text="Drama" Value="Drama" />
                              <asp:ListItem Text="Fantasy" Value="Fantasy" />
                              <asp:ListItem Text="Horror" Value="Horror" />
                              <asp:ListItem Text="Poetry" Value="Poetry" />
                              <asp:ListItem Text="Personal Development" Value="Personal Development" />
                              <asp:ListItem Text="Romance" Value="Romance" />
                              <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                              <asp:ListItem Text="Suspense" Value="Suspense" />
                              <asp:ListItem Text="Thriller" Value="Thriller" />
                              <asp:ListItem Text="Art" Value="Art" />
                              <asp:ListItem Text="Autobiography" Value="Autobiography" />
                              <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                              <asp:ListItem Text="Health" Value="Health" />
                              <asp:ListItem Text="History" Value="History" />
                              <asp:ListItem Text="Math" Value="Math" />
                              <asp:ListItem Text="Textbook" Value="Textbook" />
                              <asp:ListItem Text="Science" Value="Science" />
                              <asp:ListItem Text="Travel" Value="Travel" />
                           </asp:ListBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Edition</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="editiontxt" runat="server" placeholder="Edition"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Book Price(per unit)</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="bookpricetxt" runat="server" placeholder="Book Cost(per unit)" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Pages</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="pagestxt" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Actual Stock</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="actualstocktxt" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Current Stock</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="currentstocktxt" runat="server" placeholder="Cuurent Stock" TextMode="Number" ></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Issued Books</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="issuedbookstxt" runat="server" placeholder="Issued Books" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-12" style="color: white; font-weight: bold;">
                        <label>Book Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="bookdescriptiontxt" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button1" style="border-radius: 30px;" class="btn btn-lg btn-block btn-success " runat="server" Text="Add" OnClick="Button1_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" style="border-radius: 30px;" class="btn btn-lg btn-block btn-warning button-rounded" runat="server" Text="Update" OnClick="Button3_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button2" style="border-radius: 30px;" class="btn btn-lg btn-block btn-danger button-rounded" runat="server" Text="Delete" OnClick="Button2_Click" />
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx" style="color:azure;"><b>Go to Home Page.</b></a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card" >
               <div class="card-body">
                  <div class="row">
                     <div class="col" style= "font-weight: bold;">
                        <center>
                            
                           <h4>Book Inventory List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lmsDBConnectionString %>" SelectCommand="SELECT * FROM [book_inventory_tbl]"></asp:SqlDataSource>
                     <div class="col">
                        <hr style="border-top: 3px solid #000000;">
                     </div>
                  </div>
                  <div class="row">
                     <div class="col" >
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="book_id" HeaderText="Book ID" ReadOnly="True" SortExpression="book_id" >
                                
                                <ItemStyle Font-Bold="True" />
                                </asp:BoundField>
                                
                                <asp:TemplateField>

                                    <ItemTemplate>
                                      <div class="container-fluid">
                                       <div class="row">
                                          <div class="col-lg-10">
                                             <div class="row">
                                                <div class="col-12">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   <span>Author : </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;</span>Genre : </span>
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                   &nbsp;| 
                                                   <span>
                                                      Language :<span>&nbsp;</span>
                                                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                                   </span>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   Publisher :
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                   &nbsp;| Publish Date :
                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                   &nbsp;| Pages :
                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                   &nbsp;| Edition :
                                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   Price :
                                                   <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_price") %>'></asp:Label>
                                                   &nbsp;| Actual Stock :
                                                   <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                   &nbsp;| Available Stock :
                                                   <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   Description :
                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>
                                                </div>
                                             </div>
                                          </div>
                                          <div class="col-lg-2">
                                             <asp:Image class="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                         </div>
                                       </div>
                                    </div>
                                  </ItemTemplate>

                                </asp:TemplateField>
                                
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
    </div>
</asp:Content>
