<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="TechonlineFrontend.MyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<section id="content">
    <div id="breadcrumb-container">
        <div class="container">
            <ul class="breadcrumb">
	            <li><a href="home.aspx">Home</a></li>
	            <li class="active">My Account</li>
            </ul>
        </div>
    </div>

    <div class="container">
    <div class="row">
          <div class="col-sm-12">
              <h1>Change Account Password</h1>
              <p>Here you can change your account password</p>
              <div class="passwordStatus" runat="server" id="passwordStatus"></div>
              <form action="" method="post">
                    <div class="input-group input-group-sm">
                        <span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Email</span></span>
                        <input type="text" placeholder="Email" class="form-control">
                    </div>
                     <div class="input-group input-group-sm">
                        <span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Old password</span></span>
                        <input type="text" placeholder="Old Password" class="form-control">
                    </div>
                     <div class="input-group input-group-sm">
                        <span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">New password</span></span>
                        <input type="text" placeholder="New Password" class="form-control">
                    </div>
                    <div class="input-group input-group-sm">
                        <span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Confirm New password</span></span>
                        <input type="text" placeholder="Confirm New Password" class="form-control">
                    </div>
                    <input type="submit" class="btn btn-info" name="submitted" value="1"/>
              </form>
          </div>
    </div>
    </div>
</section>
</asp:Content>
