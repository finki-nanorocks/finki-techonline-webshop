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
         <div class="col-sm-4 col-xs-12">
             <h3 id="accountName" style="text-align:center" runat="server"></h3>
            <img src="images/placeholder.png" width="100%"/>
         </div>
          <div class="col-sm-8 col-xs-12">
              <h1>Change Account Password</h1>
              <p>Here you can change your account password</p>
              <div class="passwordStatus" runat="server" id="passwordStatus"></div>
              <form runat="server" id='cpform' action="" method="post">
                    <div class="input-group input-group-sm">
                        <span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Email</span></span>
                        <input type="text" disabled placeholder="Email" name="useremail" id="useremail" runat="server" class="form-control"/>
                    </div>
                     <div class="input-group input-group-sm">
                        <span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Old password</span></span>
                        <input type="password" required placeholder="Old Password" id="useroldpass" name="useroldpass" class="form-control"/>
                    </div>
                     <div class="input-group input-group-sm">
                        <span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">New password</span></span>
                        <input type="password" required placeholder="New Password" id="usernewpass" name="usernewpass" class="form-control"/>
                    </div>
                    <div class="input-group input-group-sm">
                        <span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Confirm password</span></span>
                        <input type="password" required placeholder="Confirm Password" id="userconfirmpass" name="userconfirmpass" class="form-control"/>
                    </div>
                    <input type="hidden" name="user_email" id="user_email" runat="server"/>
                    <input type="submit" class="btn btn-info" name="submitted" value="Change"/>
              </form>
          </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <h1>Previous Purchases</h1>
			<div class="table-responsive">
           		<table class="table cart-table">
        		<thead>
        			<tr>
                        <th class="table-title">Order #</th>
						<th class="table-title">Product Name</th>
						<th class="table-title">Product Price</th>
						<th class="table-title">Quantity</th>
						<th class="table-title">SubTotal</th>
                        <th class="table-title">Date</th>
        			</tr>
        		</thead>
				<tbody ID="tblPreviousPurchases" runat="server"></tbody>
				</table>	
			</div><!-- End .table-reponsive-->
        </div>
    </div>
    </div>
</section>
</asp:Content>
