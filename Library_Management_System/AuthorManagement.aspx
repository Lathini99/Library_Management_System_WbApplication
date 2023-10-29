<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuthorManagement.aspx.cs" Inherits="Library_Management_System.AuthorManagement" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
      $(document).ready(function () {
      
          //$(document).ready(function () {
              //$('.table').DataTable();
         // });
      
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
          //$('.table1').DataTable();
      });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('images/library.jpg'); background-size: cover; min-height: 100vh; display: flex; align-items: center; justify-content: center; opacity:0.85">
    <div class="container">
        <div class="row">
            <div class="col-md-5">

                <div class="card" style="background: rgb(144, 9, 9, 0.65);">
                    <div class="card-body">

                        <div class="row">
                            <div class="col" style="color: white; font-weight: bold;">
                                <center>
                                        <h4>Author Details</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px" src="images/Authoricon.png" />
                                       
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr style="border-top: 3px solid #000000;">
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4" style="color: white; font-weight: bold;">
                                <label>Author ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="authoridtxt" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8" style="color: white; font-weight: bold;">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="authornametxt" runat="server" placeholder="Author Name"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
                            </div>
                        </div>


                    </div>
                </div>
                <br>
                <a href="homepage.aspx" style="color:azure;"><b>Go to Home Page.</b></a><br>
                <br>
            </div>

            <div class="col-md-7">

                <div class="card" >
                    <div class="card-body">



                        <div class="row">
                            <div class="col" style="font-weight: bold;">
                                <center>
                                        <h4>Author List</h4>
                                    </center>
                            </div>
                        </div>

                       

                        <div class="row">
                            <div class="col">
                                <hr style="border-top: 3px solid #000000;">
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lmsDBConnectionString %>" SelectCommand="SELECT * FROM [author_tbl]"></asp:SqlDataSource>
                            <div class="col">

                               <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                   <Columns>
                                       <asp:BoundField DataField="author_id" HeaderText="Author Id" ReadOnly="True" SortExpression="author_id" />
                                       <asp:BoundField DataField="author_name" HeaderText="Author Name" SortExpression="author_name" />
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
