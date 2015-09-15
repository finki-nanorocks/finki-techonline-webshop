<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="techonline_onlineshop.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <section id="content">
    <div id="category-breadcrumb">
        <div class="container">
		    <ul class="breadcrumb">
			    <li><a href="home.aspx">Home</a></li>
			    <li><a href="#">Electronics</a></li>
			    <li class="active">Mobile</li>
		    </ul>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
        				
        	    <div class="row">
        					
        		    <div class="col-md-9 col-sm-8 col-xs-12 main-content">
        						
        			    <div class="category-toolbar clearfix">
						    <div class="toolbox-filter clearfix">
									
							    <div class="sort-box">
								    <span class="separator">sort by:</span>
								    <div class="btn-group select-dropdown">
									    <button type="button" class="btn select-btn">Position</button>
									    <button type="button" class="btn dropdown-toggle" data-toggle="dropdown">
										    <i class="fa fa-angle-down"></i>
									    </button>
									    <ul class="dropdown-menu" role="menu">
										    <li><a href="#">Date</a></li>
										    <li><a href="#">Name</a></li>
									    </ul>
								    </div>
							    </div>
										
							    <div class="view-box">
								    <a href="category.html" class="active icon-button icon-grid"><i class="fa fa-th-large"></i></a>
								    <a href="category-list.html" class="icon-button icon-list"><i class="fa fa-th-list"></i></a>
							    </div><!-- End .view-box -->
										
						    </div><!-- End .toolbox-filter -->
						    <div class="toolbox-pagination clearfix">
							    <ul class="pagination">
								    <li class="active"><a href="#">1</a></li>
								    <li><a href="#">2</a></li>
								    <li><a href="#">3</a></li>
								    <li><a href="#">4</a></li>
								    <li><a href="#">5</a></li>
								    <li><a href="#"><i class="fa fa-angle-right"></i></a></li>
							    </ul>
							    <div class="view-count-box">
								    <span class="separator">view:</span>
								    <div class="btn-group select-dropdown">
									    <button type="button" class="btn select-btn">10</button>
									    <button type="button" class="btn dropdown-toggle" data-toggle="dropdown">
										    <i class="fa fa-angle-down"></i>
									    </button>
									    <ul class="dropdown-menu" role="menu">
										    <li><a href="#">15</a></li>
										    <li><a href="#">30</a></li>
									    </ul>
								    </div>
							    </div><!-- End .view-count-box -->
										
						        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                                        <asp:BoundField DataField="product" HeaderText="product" SortExpression="product" />
                                        <asp:BoundField DataField="manifacture" HeaderText="manifacture" SortExpression="manifacture" />
                                        <asp:BoundField DataField="model" HeaderText="model" SortExpression="model" />
                                        <asp:BoundField DataField="cpu" HeaderText="cpu" SortExpression="cpu" />
                                        <asp:BoundField DataField="ram" HeaderText="ram" SortExpression="ram" />
                                        <asp:BoundField DataField="hdd" HeaderText="hdd" SortExpression="hdd" />
                                        <asp:BoundField DataField="gpu" HeaderText="gpu" SortExpression="gpu" />
                                        <asp:BoundField DataField="os" HeaderText="os" SortExpression="os" />
                                        <asp:BoundField DataField="more_info" HeaderText="more_info" SortExpression="more_info" />
                                        <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                                        <asp:BoundField DataField="image_path" HeaderText="image_path" SortExpression="image_path" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_techonlineGNMLConnectionString1 %>" ProviderName="<%$ ConnectionStrings:db_techonlineGNMLConnectionString1.ProviderName %>" SelectCommand="SELECT [id], [product], [manifacture], [model], [cpu], [ram], [hdd], [gpu], [os], [more_info], [price], [image_path] FROM [products_info]"></asp:SqlDataSource>
										
						    </div><!-- End .toolbox-pagination -->
        							
        							
        			    </div><!-- End .category-toolbar -->
        			    <div class="md-margin"></div><!-- .space -->
        			    <div ID="divProductsContainer" runat="server" class="category-item-container"></div><!-- End .category-item-container -->
        						
        			    <div class="pagination-container clearfix">
        				    <div class="pull-right">
							    <ul class="pagination">
								    <li class="active"><a href="#">1</a></li>
								    <li><a href="#">2</a></li>
								    <li><a href="#">3</a></li>
								    <li><a href="#">4</a></li>
								    <li><a href="#">5</a></li>
								    <li><a href="#"><i class="fa fa-angle-right"></i></a></li>
								    </ul>
        				    </div><!-- End .pull-right -->
        							
        				    <div class="pull-right view-count-box hidden-xs">
							    <span class="separator">view:</span>
							    <div class="btn-group select-dropdown">
								    <button type="button" class="btn select-btn">10</button>
								    <button type="button" class="btn dropdown-toggle" data-toggle="dropdown">
									    <i class="fa fa-angle-down"></i>
								    </button>
								    <ul class="dropdown-menu" role="menu">
									    <li><a href="#">15</a></li>
									    <li><a href="#">30</a></li>
								    </ul>
							    </div>
						    </div>
        			    </div><!-- End pagination-container -->
							
        						
        		    </div><!-- End .col-md-9 -->
        					
        		    <aside class="col-md-3 col-sm-4 col-xs-12 sidebar">
        			    <div class="widget">
        				    <div class="panel-group custom-accordion sm-accordion" id="category-filter">
							    <div class="panel">
								    <div class="accordion-header">
									    <div class="accordion-title"><span>Category</span></div><!-- End .accordion-title -->
						    <a class="accordion-btn opened"  data-toggle="collapse" data-target="#category-list-1"></a>
								    </div><!-- End .accordion-header -->
								
							    <div id="category-list-1" class="collapse in">
								    <div class="panel-body">
									    <ul class="category-filter-list jscrollpane">
										    <li><a href="#">Mobile Phones (341)</a></li>
										    <li><a href="#">Smartphones (55)</a></li>
										    <li><a href="#">Communicators (24)</a></li>
										    <li><a href="#">CDMA Phones (14)</a></li>
										    <li><a href="#">Accessories (83)</a></li>
										    <li><a href="#">Chargers (8)</a></li>
										    <li><a href="#">Memory Cards (6)</a></li>
										    <li><a href="#">Protectors (12)</a></li>
										    <li><a href="#">ravelsim (5)</a></li>
										    <li><a href="#">CDMA Phones (14)</a></li>
										    <li><a href="#">Accessories (83)</a></li>
										    <li><a href="#">Chargers (8)</a></li>
										    <li><a href="#">Memory Cards (6)</a></li>
										    <li><a href="#">Protectors (12)</a></li>
										    <li><a href="#">ravelsim (5)</a></li>
										    <li><a href="#">CDMA Phones (14)</a></li>
										    <li><a href="#">Accessories (83)</a></li>
										    <li><a href="#">Chargers (8)</a></li>
										    <li><a href="#">Memory Cards (6)</a></li>
										    <li><a href="#">Protectors (12)</a></li>
										    <li><a href="#">ravelsim (5)</a></li>
									    </ul>
								    </div><!-- End .panel-body -->
							    </div><!-- #collapse -->
							    </div><!-- End .panel -->
        								
        					    <div class="panel">
								    <div class="accordion-header">
									    <div class="accordion-title"><span>Brand</span></div><!-- End .accordion-title -->
						    <a class="accordion-btn opened"  data-toggle="collapse" data-target="#category-list-2"></a>
								    </div><!-- End .accordion-header -->
								
							    <div id="category-list-2" class="collapse in">
								    <div class="panel-body">
								    <ul class="category-filter-list jscrollpane">
									    <li><a href="#">Samsung (50)</a></li>
									    <li><a href="#">Apple (80)</a></li>
									    <li><a href="#">HTC (20)</a></li>
									    <li><a href="#">Motoroloa (20)</a></li>
									    <li><a href="#">Nokia (11)</a></li>
								    </ul>
								    </div><!-- End .panel-body -->
							    </div><!-- #collapse -->
							    </div><!-- End .panel -->
        		    </aside><!-- End .col-md-3 -->
        	    </div><!-- End .row -->
        				
        				
            </div><!-- End .col-md-12 -->
        </div><!-- End .row -->
    </div><!-- End .container -->
</section>
</form>
</asp:Content>
