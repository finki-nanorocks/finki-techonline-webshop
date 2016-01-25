<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="TechonlineFrontend.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="content">


     <div id="breadcrumb-container">
        <div class="container">
            <ul class="breadcrumb">
	            <li><a href="home.aspx">Home</a></li>
	            <li class="active">Shop</li>
            </ul>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-12">
        			
        					
        		    <div class="col-md-9 col-sm-8 col-xs-12 main-content">
        				 <div class="displaymsgs" runat="server" id="displaymsgs"></div>		
        			    <div class="md-margin"></div><!-- .space -->
        			    <div ID="divProductsContainer" runat="server" class="category-item-container"></div><!-- End .category-item-container -->
        		    </div><!-- End .col-md-9 -->
        					
        		    <aside class="col-md-3 col-sm-4 col-xs-12 sidebar">
        			    <div class="widget">
        				    <div class="panel-group custom-accordion sm-accordion" id="category-filter">
        					    <div class="panel">
								    <div class="accordion-header">
									    <div class="accordion-title"><span>Brand</span></div><!-- End .accordion-title -->
						    <a class="accordion-btn opened"  data-toggle="collapse" data-target="#category-list-2"></a>
								    </div><!-- End .accordion-header -->
								
							    <div id="category-list-2" class="collapse in">
								    <div class="panel-body">
								    <ul id="brands" runat="server" class="category-filter-list jscrollpane">

								    </ul>
								    </div><!-- End .panel-body -->
							    </div><!-- #collapse -->
							    </div><!-- End .panel -->
        		    </aside><!-- End .col-md-3 -->
        				
        				
            </div><!-- End .col-md-12 -->
        </div><!-- End .row -->
    </div><!-- End .container -->
</section>
</asp:Content>
