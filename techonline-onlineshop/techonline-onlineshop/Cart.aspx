<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="techonline_onlineshop.Cart" %>
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
            <div class="col-md-12">
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
							    <th class="table-title">Product Code</th>
							    <th class="table-title">Unit Price</th>
							    <th class="table-title">Quantity</th>
							    <th class="table-title">SubTotal</th>
        				    </tr>
        			    </thead>
					    <tbody>
						    <tr>
							    <td class="item-name-col">
								    <figure>
									    <a href="#"><img src="images/products/compare1.jpg" alt="Lowlands Lace Blouse"></a>
								    </figure>
								    <header class="item-name"><a href="#">Lowlands Lace Blouse</a></header>
								    <ul>
									    <li>Color: White</li>
									    <li>Size: SM</li>
								    </ul>
							    </td>
							    <td class="item-code">MP125984154</td>
							    <td class="item-price-col"><span class="item-price-special">$1175</span></td>
							    <td>
								    <div class="custom-quantity-input">
									    <input type="text" name="quantity" value="1">
									    <a href="#" onclick="return false;" class="quantity-btn quantity-input-up"><i class="fa fa-angle-up"></i></a>
									    <a href="#" onclick="return false;" class="quantity-btn quantity-input-down"><i class="fa fa-angle-down"></i></a>
								    </div>
							    </td>
							    <td class="item-total-col"><span class="item-price-special">$1175</span>
							    <a href="#" class="close-button"></a>
							    </td>
						    </tr>
						    <tr>
							    <td class="item-name-col">
								    <figure>
									    <a href="#"><img src="images/products/compare2.jpg" alt="Samsung Galaxy Ace"></a>
								    </figure>
								    <header class="item-name"><a href="#">Samsung Galaxy Ace</a></header>
								    <ul>
									    <li>Color: Black</li>
									    <li>Size: XL</li>
								    </ul>
							    </td>
							    <td class="item-code">MP125984154</td>
							    <td class="item-price-col"><span class="item-price-special">$1475</span></td>
							    <td>
								    <div class="custom-quantity-input">
									    <input type="text" name="quantity" value="1">
									    <a href="#" onclick="return false;" class="quantity-btn quantity-input-up"><i class="fa fa-angle-up"></i></a>
									    <a href="#" onclick="return false;" class="quantity-btn quantity-input-down"><i class="fa fa-angle-down"></i></a>
								    </div>
							    </td>
							    <td class="item-total-col"><span class="item-price-special">$1475</span>
							    <a href="#" class="close-button"></a>
							    </td>
						    </tr>
						    <tr>
							    <td class="item-name-col">
								    <figure>
									    <a href="#"><img src="images/products/compare3.jpg" alt="Iphone Case Cover Original"></a>
								    </figure>
								    <header class="item-name"><a href="#">Iphone Case Cover Original</a></header>
								    <ul>
									    <li>Color: White</li>
									    <li>Size: SM</li>
								    </ul>
							    </td>
							    <td class="item-code">MP125984154</td>
							    <td class="item-price-col"><span class="item-price-special">$399</span></td>
							    <td>
								    <div class="custom-quantity-input">
									    <input type="text" name="quantity" value="3">
									    <a href="#" onclick="return false;" class="quantity-btn quantity-input-up"><i class="fa fa-angle-up"></i></a>
									    <a href="#" onclick="return false;" class="quantity-btn quantity-input-down"><i class="fa fa-angle-down"></i></a>
								    </div>
							    </td>
							    <td class="item-total-col"><span class="item-price-special">$1197</span>
							    <a href="#" class="close-button"></a>
							    </td>
						    </tr>
					    </tbody>
					    </table>
        						
        		    </div><!-- End .col-md-12 -->
        					
        	    </div><!-- End .row -->
        	    <div class="lg-margin"></div><!-- End .space -->
        				
        	    <div class="row">
        		    <div class="col-md-8 col-sm-12 col-xs-12">
        						
        			    <div class="tab-container left clearfix">
        					    <ul class="nav-tabs">
								    <li class="active"><a href="#shipping" data-toggle="tab">Shipping &amp; Taxes</a></li>
								    <li><a href="#discount" data-toggle="tab">Discount Code</a></li>
								    <li><a href="#gift" data-toggle="tab">Gift voucher </a></li>
										  
							    </ul>
        					    <div class="tab-content clearfix">
        						    <div class="tab-pane active" id="shipping">
        										
        							    <form action="#" id="shipping-form">
        								    <p>Enter your destination to get a shipping estimate.</p>
                                            <div class="xs-margin"></div>
										    <div class="form-group">
											    <label for="select-country" class="control-label">Country&#42;</label>
											    <div class="input-container">
                                                    <select name="select-country" class="form-control" id="select-country">
                                                        <option value="Italy">Italy</option>
                                                        <option value="France">France</option>
                                                        <option value="Spain">Spain</option>
                                                        <option value="Brazil">Brazil</option>
                                                    </select>
                                                </div><!-- End .select-container -->
										    </div><!-- End .form-group -->
										    <div class="sm-margin"></div>
										    <div class="form-group">
                                                <label for="select-state" class="control-label">Regison&amp;State&#42;</label>
                                                <div class="input-container">
                                                    <select name="select-state" class="form-control" id="select-state">
                                                        <option value="Italy">Italy</option>
                                                        <option value="France">France</option>
                                                        <option value="Spain">Spain</option>
                                                        <option value="Brazil">Brazil</option>
                                                    </select>
                                                </div><!-- End .select-container -->
                                            </div><!-- End .form-group -->
        								    <div class="sm-margin"></div>
        							    <div class="form-group">
										    <label for="select-country" class="control-label"  >Post Code&#42;</label>
										    <div class="input-container">
                                                <input type="text" required class="form-control" placeholder="Your fax">
                                            </div>
									    </div><!-- End .form-group -->
        							    <div class="sm-margin"></div>
        							    <p class="text-right">
        								    <input type="submit" class="btn btn-custom-2" value="GET QUOTES">
        							    </p>
        							    </form>
        										
        						    </div><!-- End .tab-pane -->
        									
        						    <div class="tab-pane" id="discount">
        							    <p>Enter your discount coupon code here.</p>
        							    <form action="#">
        								    <div class="input-group">
											    <input type="text" required class="form-control" placeholder="Coupon code">
														
										    </div><!-- End .input-group -->	
        							    <input type="submit" class="btn btn-custom-2" value="APPLY COUPON">
        							    </form>
        						    </div><!-- End .tab-pane -->
        									
        						    <div class="tab-pane" id="gift">
        							    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sequi dignissimos nostrum debitis optio molestiae in quam dicta labore obcaecati ullam necessitatibus animi deleniti minima dolor suscipit nobis est excepturi inventore.</p>
        						    </div><!-- End .tab-pane -->
        									
        					    </div><!-- End .tab-content -->
        			    </div><!-- End .tab-container -->
        						
        		    </div><!-- End .col-md-8 -->
				    <div class="lg-margin visible-sm visible-xs"></div><!-- space -->
        		    <div class="col-md-4 col-sm-12 col-xs-12">
        						
        			    <table class="table total-table">
        				    <tbody>
        					    <tr>
        						    <td class="total-table-title">Subtotal:</td>
        						    <td>$434.50</td>
        					    </tr>
        					    <tr>
        						    <td class="total-table-title">Shipping:</td>
        						    <td>$6.00</td>
        					    </tr>
        					    <tr>
        						    <td class="total-table-title">TAX (0%):</td>
        						    <td>$0.00</td>
        					    </tr>
        				    </tbody>
        				    <tfoot>
        					    <tr>
								    <td>Total:</td>
								    <td>$440.50</td>
        					    </tr>
        				    </tfoot>
        			    </table>
        			    <div class="md-margin"></div><!-- End .space -->
        			    <a href="#" class="btn btn-custom-2">CONTINUE SHOPPING</a>
        			    <a href="#" class="btn btn-custom">CHECKOUT</a>
        		    </div><!-- End .col-md-4 -->
        	    </div><!-- End .row -->
            </div><!-- End .col-md-12 -->
        </div><!-- End .row -->
    </div><!-- End .container -->
</section>
</asp:Content>
