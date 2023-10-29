<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookIssuing.aspx.cs" Inherits="Library_Management_System.BookIssuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
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
                           <img width="100px" src="images/userimage.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col" style="color: white; font-weight: bold;">
                        <center>
                           <h4>Book Issuing</h4>
                        </center>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <hr style="border-top: 3px solid #000000;">
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>Member ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="memberidtxt" runat="server" placeholder="Member ID"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>Book ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="bookidtxt" runat="server" placeholder="Book ID"></asp:TextBox>
                              <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>Member Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="membernametxt" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>Book Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="booknametxt" runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>Issue Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="issuedatetxt" runat="server" placeholder="Start Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>Return Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="returndatetxt" runat="server" placeholder="End Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-6" >
                        <asp:Button ID="Button2" style="border-radius: 30px;" class="btn btn-lg btn-block btn-primary" runat="server" Text="Issue" OnClick="Button2_Click" />
                     </div>
                     <div class="col-6">
                        <asp:Button ID="Button4" style="border-radius: 30px;" class="btn btn-lg btn-block btn-success" runat="server" Text="Return" OnClick="Button4_Click" />
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
                     <div class="col" style="color: black; font-weight: bold;">
                        <center>
                           <h4>Issued Book List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr style="border-top: 3px solid #000000;">
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:lmsDBConnectionString %>' SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" />
                                <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name" />
                                <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                <asp:BoundField DataField="due_date" HeaderText="Due/Return Date" SortExpression="due_date" />
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
