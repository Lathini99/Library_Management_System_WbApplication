<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="Library_Management_System.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div style="background-image: url('images/library.jpg'); background-size: cover; min-height: 100vh; display: flex; align-items: center; justify-content: center; opacity:0.85">
    <div class="container" >
        <div class="row">
            <div class="col-md-6 mx-auto"  >
                <div class="card" style="background: rgb(144, 9, 9, 0.65);">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="images/userimage.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col" style="color: white; font-weight: bold;">
                                <center>
                                    <h3>User Login</h3>
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
                                <div class="col" style="color: white; font-weight: bold;">
                                    <label>User ID : :</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="useridtxt" runat="server" 
                                            placeholder="User ID"></asp:TextBox>
                                    </div>
                                    <label>User Password :</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="pwdtxt" runat="server" 
                                            placeholder="Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                     <div class="form-group">
                                         <asp:Button ID="Button1" style="border-radius: 30px;" class="btn btn-info btn-block btn-lg" runat="server" Text="LOGIN" OnClick="Button1_Click" />
                                    </div>
                                    <div class="form-group">
                                        <a href="UserSignUpPage.aspx">
                                        <input id="Button2" style="border-radius: 30px;" class="btn btn-warning btn-block btn-lg" type="button" value="SIGN UP" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                   
                </div>
                <br>
                 <a href="Homepage.aspx" style="color:azure;"><b>Go to Home Page.</b></a> 
                   <br> <br>
            </div>
        </div>
    </div>
   </div>
</asp:Content>
