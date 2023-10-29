﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfille.aspx.cs" Inherits="Library_Management_System.UserProfille" %>
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
                           <img width="100px" src="images/user.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col" style="color: white; font-weight: bold;">
                        <center>
                           <h4>Your Profile</h4>
                           <span>Account Status - </span>
                           <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Your status"></asp:Label>
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
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="fullnametxt" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>Date of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="dobtxt" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>Contact No.</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="contactnotxt" runat="server" placeholder="Contact No." TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="emailtxt" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>Province</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="provinceddl" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Northern Province" Value="Norhern Province" />
                              <asp:ListItem Text="North Central Province" Value="North Central Province" />
                              <asp:ListItem Text="North Western Province" Value="North Western Province" />
                              <asp:ListItem Text="Central Province" Value="Central Province" />
                              <asp:ListItem Text="Eastern Province" Value="Eastern Province" />
                              <asp:ListItem Text="Western Province" Value="Western Province" />
                              <asp:ListItem Text="Southern Province" Value="Southern Province" />
                              <asp:ListItem Text="Uva Province" Value="Uva Province" />
                              <asp:ListItem Text="Sabaragamuwa Province" Value="Sabaragamuwa Province" />
                           
                           </asp:DropDownList>
                        </div>
                     </div>
                    <div class="col-md-6" style="color: white; font-weight: bold;">
                        <label>District</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="districtddl" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Ampara" Value="Ampara" />
                              <asp:ListItem Text="Anuradhapura" Value="Anuradhapura" />
                              <asp:ListItem Text="Badulla" Value="Badulla" />
                              <asp:ListItem Text="Batticaloa" Value="Batticaloa" />
                              <asp:ListItem Text="Colombo" Value="Colombo" />
                              <asp:ListItem Text="Galle" Value="Galle" />
                              <asp:ListItem Text="Gampaha" Value="Gampaha" />
                              <asp:ListItem Text="Hambantota" Value="Hambantota" />
                              <asp:ListItem Text="Jaffna" Value="Jaffna" />
                              <asp:ListItem Text="Kalutara" Value="Kalutara" />
                              <asp:ListItem Text="Kandy" Value="Kandy" />
                              <asp:ListItem Text="Kegalle" Value="Kegalle" />
                              <asp:ListItem Text="Kilinochchi" Value="Kilinochchi" />
                              <asp:ListItem Text="Kurunegala" Value="Kurunegala" />
                              <asp:ListItem Text="Mannar" Value="Mannar" />
                              <asp:ListItem Text="Matale" Value="Matale" />
                              <asp:ListItem Text="Matara" Value="Matara" />
                              <asp:ListItem Text="Monaragala" Value="Monaragala" />
                              <asp:ListItem Text="Mullaitivu" Value="Mullaitivu" />
                              <asp:ListItem Text="Nuwara Eliya" Value="Nuwara Eliya" />
                              <asp:ListItem Text="Polonnaruwa" Value="Polonnaruwa" />
                              <asp:ListItem Text="Puttalam" Value="Puttalam" />
                              <asp:ListItem Text="Ratnapura" Value="Ratnapura" />
                              <asp:ListItem Text="Trincomalee" Value="Trincomalee" />
                              <asp:ListItem Text="Vavuniya" Value="Vavuniya" />
                           
                           </asp:DropDownList>
                        </div>
                     </div>
                    
                  </div>
                  <div class="row">
                     <div class="col" style="color: white; font-weight: bold;">
                        <label>Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="addresstxt" runat="server" placeholder="Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col" >
                        <center>
                           <span class="badge badge-pill badge-dark">Login Credentials</span>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>User ID</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="memberidtxt" runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>Old Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="oldpwdtxt" runat="server" placeholder=" Old Password"  ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4" style="color: white; font-weight: bold;">
                        <label>New Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="newpwdtxt" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                           </div>
                        </center>
                     </div>
                  </div>
               </div>
            </div>
             <br>
            <a href="homepage.aspx" style="color:azure;"><b>Go to Home Page.</b></a><br><br>
         </div>
         <div class="col-md-7">
            <div class="card" >
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="images/reading.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col" style="color: black; font-weight: bold;">
                        <center>
                           <h4>Your Issued Books</h4>
                           <asp:Label class="badge badge-pill badge-dark" ID="Label2" runat="server" Text="Your books info"></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
    </div>
</asp:Content>
