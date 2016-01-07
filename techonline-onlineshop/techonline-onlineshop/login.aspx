<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TechonlineFrontend.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
	<title>Login - Texhonline</title>
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
<body class="blurBg-false" style="background-color:#fff">
<!-- Start Formoid form-->
    <img src="images/logo.jpg" alt="logo"  style="width:250px;display:block;margin:auto; margin-bottom:30px;margin-top:30px;"/>
 <form runat="server" class="formoid-solid-dark" style="background-color:#FFFFFF;font-size:14px;font-family:'Roboto',Arial,Helvetica,sans-serif;color:#34495E;max-width:480px;min-width:150px" method="post">
    <div class="title"><h2>Login</h2></div>
    <div runat="server" id="actionStatus" class="hidden">
        <!-- <a aria-hidden="true" data-dismiss="alert" class="close" type="button">×</a> -->
    </div>

	<div class="element-input"><label class="title"></label><div class="item-cont"><asp:TextBox runat="server" placeholder="e-mail" ID="loginemail" class="large"></asp:TextBox><span class="icon-place"></span></div></div>
	<div class="element-password"><label class="title"></label><div class="item-cont"><asp:TextBox runat="server" placeholder="password" ID="loginpassword" class="large"></asp:TextBox><span class="icon-place"></span></div></div>
	<div ><label class="title"></label><div class="item-cont"><asp:Label runat="server" placeholder="" ID="TextBox1" class="large"></asp:Label><span class="icon-place"></span></div></div><br />
     <div class="element-checkbox"><label class="title"></label><div class="column column1"><label><input type="checkbox" name="checkbox[]" value="remember me" /><span>remember me</span></label></div><span class="clearfix"></span>
    </div>
    <div class="submit">
        <asp:Button ID="Register" type="submit" Text="Register" runat="server" OnClick="Reg_Click"/>
        <asp:Button ID="LoginSing" type="submit" Text="SingIn" runat="server" OnClick="LoginSing_Click"/>
    </div>
    </form>
</body>
</html>
