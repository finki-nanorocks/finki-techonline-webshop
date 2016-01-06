<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="TechonlineFrontend._404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<section id="content" class="no-content">
    <div class="lg-margin"></div><!-- Space -->
    <div class="container">
        <div class="row">
            <div class="col-md-12">
        	    <div class="no-content-comment">
                    <h2>404</h2>
                    <h3>It's not my fault buddy! <br> I think you got lost.</h3>
                </div><!-- End .no-content-comment -->
            </div><!-- End .col-md-12 -->
        </div><!-- End .row -->
    </div><!-- End .container -->
</section>

<script>
$(function() {

    // Simple Animation for 404 text

        var container = $('.no-content-comment'),
            title = container.find('h2'),
            titleText = title.text(),
            message = container.find('h3'),
            messageText = message.text(),
            titleTextLen = titleText.length,
            messageTextLen = messageText.length,
            titleNew = '',
            messageNew = '',
            time = 50;

               
        function iterate(len, text, newVar, target) {
            for (var i=0 ; i < len; i++) {
                if (text[i] == '!') { // ! important for line breaks
                    newVar += '<span>'+text[i]+'<br></span>' 
                } else {
                    newVar += '<span>'+text[i]+'</span>';
                }
            }
            target.html(newVar);
        }


        iterate(titleTextLen, titleText, titleNew, title);

        iterate(messageTextLen, messageText, messageNew, message);


    $(window).on('load', function () {
                
        container.find('span').each(function () {
            time +=80;
            $(this).delay(200).animate({opacity: 1}, time);
        });
                
    });
            
    	
});
</script>
</asp:Content>
