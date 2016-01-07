<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="TechonlineFrontend.registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration-techonline</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="forms_all/formoid1/formoid-solid-dark.css" type="text/css" />
    <script type="text/javascript" src="forms_all/formoid1/jquery.min.js"></script>
    <style>
          .hidden{
              display:none;
          }
          #registerStatus{
              margin-bottom:20px;
              margin-top:15px;
          }
    </style>
</head>
<body>
    
    <img src="images/logo.jpg" alt="logo"  style="width:250px;display:block;margin:auto; margin-bottom:30px;margin-top:30px;"/>
  
        
    <form runat="server" class="formoid-solid-dark" style="background-color:#FFFFFF;font-size:14px;font-family:'Roboto',Arial,Helvetica,sans-serif;color:#34495E;max-width:480px;min-width:150px" method="post">
        <div class="title"><h2>Registration...</h2></div>
         <div runat="server" id="actionStatus" class="hidden">
           <!-- <a aria-hidden="true" data-dismiss="alert" class="close" type="button">×</a> -->
        </div>
	    <div class="element-input"><label class="title"></label><div class="item-cont"><asp:TextBox runat="server" placeholder="FirstName" ID="regfirstname" class="large"></asp:TextBox><span class="icon-place"></span></div></div>
	    <div class="element-input"><label class="title"></label><div class="item-cont"><asp:TextBox runat="server" placeholder="LastName" ID="reglastname" class="large"></asp:TextBox><span class="icon-place"></span></div></div>
        <div class="element-input"><label class="title"></label><div class="item-cont"><asp:TextBox runat="server" placeholder="e-mail" ID="regemail" class="large"></asp:TextBox><span class="icon-place"></span></div></div>
	    <div class="element-password"><label class="title"></label><div class="item-cont"><input type="password" runat="server" placeholder="password" ID="regpass" class="large"/><span class="icon-place"></span></div></div>

        <div class="submit">
            <asp:Button ID="LoginBtn" type="submit" Text="Login" runat="server" OnClick="Log_Click"/>
            <asp:Button ID="Registerid" type="submit" Text="Register" runat="server" OnClick="Registerid_Click"/>
        </div>
 
    </form>
</body>
</html>
