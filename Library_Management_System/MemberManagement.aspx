<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MemberManagement.aspx.cs" Inherits="Library_Management_System.MemberManagement" %>
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
    <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card" style="background: rgb(144, 9, 9, 0.65);">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="images/member.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col" style="color: white; font-weight: bold;">
                        <center>
                           <h4>Member Details</h4>
                        </center>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <hr style="border-top: 3px solid #000000;">
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-3" style="color: white; font-weight: bold;">
                        <label>Member ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="memberidtxt" runat="server" placeholder="Member ID"></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click1"><i class="fas fa-check-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="fullnametxt" runat="server" placeholder="Full Name"  ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5" style="color: white; font-weight: bold;">
                        <label>Account Status</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control mr-1" ID="statustxt" runat="server" placeholder="Active/Deactivate" ></asp:TextBox>
                              <asp:LinkButton class="btn btn-success mr-1" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                             
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-3" style="color: white; font-weight: bold;">
                        <label>DOB</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="dobtxt" runat="server" placeholder="DOB" ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="contactnotxt" runat="server" placeholder="Contact No" ReadOnly="true" ></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5" style="color: white; font-weight: bold;">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="emailtxt" runat="server" placeholder="Email ID" ReadOnly="true" ></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>Province</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="provincetxt" runat="server" placeholder="State" ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>District</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="districttxt" runat="server" placeholder="City" ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                     
                  </div>
                  <div class="row">
                     <div class="col-12" style="color: white; font-weight: bold;">
                        <label>Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="addresstxt" runat="server" placeholder="Full Postal Address" TextMode="MultiLine" Rows="2"  ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-8 mx-auto">
                        <asp:Button ID="Button2" style="border-radius: 10px;" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete User Permanently" OnClick="Button2_Click" />
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
                     <div class="col" style="font-weight: bold;">
                        <center>
                           <h4>Member List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr style="border-top: 3px solid #000000;">
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lmsDBConnectionString %>" SelectCommand="SELECT * FROM [member_tbl]"></asp:SqlDataSource>

                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" />
                                <asp:BoundField DataField="full_name" HeaderText="Full Name" SortExpression="full_name" />
                                <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                <asp:BoundField DataField="contact_no" HeaderText="Contact No." SortExpression="contact_no" />
                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         
         </div>
   </div>
    </div>
</asp:Content>
