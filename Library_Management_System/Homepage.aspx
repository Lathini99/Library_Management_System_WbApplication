<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Library_Management_System.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
      <img src="images/lms_banner.jpg" width="1900px"  class="img-fluid"/>
   </section>
   <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                  <h2>Our Process</h2>
                  <p><b>We have a Simple 3 Step Process</b></p>
               </center>
            </div>
         </div>
         <div class="row">
              <div class="col-md-4">
               <center>
                  <img width="150px" src="images/sign-up.png" />
                  <h4>Sign Up</h4>
                  <p class="text-justify">The sign-up process is the initial step for users to gain access to the library's digital resources and services. 
                      New patrons create an account by providing their personal information, 
                      such as name, contact details, and possibly a username and password.
                      This step enables users to log in securely and manage their interactions with the library, including borrowing 
                      and returning books, tracking reading history, and more.</p>
               </center>
            </div>
            
            <div class="col-md-4">
               <center>
                  <img width="150px" src="images/search-online.png"/>
                  <h4>Search Books</h4>
                  <p class="text-justify">The search books process allows users to explore the library's collection of 
                      books and other materials. Using a user-friendly search interface, patrons can enter keywords, titles, 
                      authors, or categories to find relevant materials. The system then presents a list of matching items, 
                      complete with availability status and location details. This feature streamlines the discovery of desired 
                      resources and enhances the overall browsing experience.</p>
               </center>
            </div>
           <%--  <div class="col-md-3">
               <center>
                  <img width="150px" src="images/defaulters-list.png"/>
                  <h4>Defaulter List</h4>
                  <p class="text-justify">Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Lorem ipsum dolor. reprehenderit</p>
               </center>
            </div>--%>
             <div class="col-md-4">
               <center>
                  <img width="150px" src="images/library.png"/>
                  <h4>Visit Us</h4>
                  <p class="text-justify">This process involves physically coming to the library location. Patrons can use this 
                      process to access resources that may not be available digitally or to engage in activities like reading, studying, 
                      attending events, or borrowing physical items. During the visit, library staff may assist with inquiries, provide guidance,
                      and ensure a comfortable environment for users to make the most of their time at the library.</p>
               </center>
            </div>
         </div>
      </div>
   </section>
   <section>
      <img src="images/library-banner.png" width="1900px"  class="img-fluid"/>
   </section>
   
</asp:Content>
