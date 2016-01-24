<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="TechonlineFrontend.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<section id="content">
    <div id="breadcrumb-container">
        <div class="container">
		    <ul class="breadcrumb">
			    <li><a href="home.aspx">Home</a></li>
			    <li class="active">Shopping Cart</li>
		    </ul>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-12" runat="server" id="cartInner">
			    <header class="content-title">
				    <h1 class="title">Shopping Cart</h1>
				    <p class="title-desc">Just this week, you can use the free premium delivery.</p>
			    </header>
        	    <div class="xs-margin"></div><!-- space -->
        	    <div class="row">
        					
        		    <div class="col-md-12 table-responsive">
								
        			    <table class="table cart-table">
        			    <thead>
        				    <tr>
							    <th class="table-title">Product Name</th>
							    <th class="table-title">Unit Price</th>
							    <th class="table-title">Quantity</th>
							    <th class="table-title">SubTotal</th>
        				    </tr>
        			    </thead>
					    <tbody ID="tblCart" runat="server"></tbody>
					    </table>
        						
        		    </div><!-- End .col-md-12 -->
        					
        	    </div><!-- End .row -->
        	    <div class="lg-margin"></div><!-- End .space -->
        				
        	    <div class="row">
				    <div class="lg-margin visible-sm visible-xs"></div><!-- space -->
        		    <div class="col-md-4 col-sm-12 col-xs-12 pull-right">
        						
        			    <table class="table total-table">
        				    <tbody>
        					    <tr>
        						    <td class="total-table-title">Subtotal:</td>
        						    <td runat="server" id="subtotal"></td>
        					    </tr>
        					    <tr>
        						    <td class="total-table-title">Shipping:</td>
        						    <td>FREE</td>
        					    </tr>
        					    <tr>
        						    <td class="total-table-title">TAX (0%):</td>
        						    <td>$0.00</td>
        					    </tr>
        				    </tbody>
        				    <tfoot>
        					    <tr>
								    <td>Total:</td>
								    <td runat="server" id="total"></td>
        					    </tr>
        				    </tfoot>
        			    </table>
        			    <div class="md-margin"></div><!-- End .space -->
        			    <a href="Shop.aspx" class="btn btn-custom-2">CONTINUE SHOPPING</a>
        			    <a href="Checkout.aspx" class="btn btn-custom">CHECKOUT</a>
        		    </div><!-- End .col-md-4 -->
        	    </div><!-- End .row -->
            </div><!-- End .col-md-12 -->
        </div><!-- End .row -->
    </div><!-- End .container -->
</section>
</asp:Content>
