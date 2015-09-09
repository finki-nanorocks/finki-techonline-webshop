<%@ Page Title="" Language="C#" MasterPageFile="~/indexMaster.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="techonline_onlineshop.contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="contact-container">
        <div id="customer-support">
            <div>CUSTOMER SUPPORT</div>
            <div class="contact-text">
                <a href="@mailto:customer-support@techonline.com">customer-support@techonline.com</a><br />
                For item inquiries, order questions and general customer service. Emailing is best, but if you prefer to call:  +3896126060.
            </div><br />
           <div>RETURNS/EXCHANGES</div>
            <div class="contact-text">
                <a href="@mailto:returns@techonline.com">returns@techonline.com</a><br />
              If you need to make a return or exchange, please first go to the terms page for more information. Please do email us if
you require an exchange so we can put your exchange on hold for you.    
            </div><br />
                <div>DEVELOPMENT &amp; MAINTENANCE</div>
            <div class="contact-text">
                <a href="@mailto:contact@gnm-solutions.com">contact@gnm-solutions.com</a><br />
           If you'd like us to review your designs for possible addition to our collection, please email your lookbook and/or photos,
pricing, and distribution summary to the above address. Please know that we'd love to respond to every inquiry but unfortunately
we get so many a day that we don’t have the time. We will respond if we have interest.
            </div><br />
              <div>PRESS &amp; MEDIA</div>
            <div class="contact-text">
                <a href="@mailto:pr@techonline.com">pr@techonline.com</a><br />
             If you'd like to feature Bona Drag or an item we carry in an editorial, please contact us for more information.
            </div><br />
            <div>
              FOLLOW US:
            </div>
            <div>
                <section>
                    <a href="www.facebook.com" ><img  src="img/facebook.png" class="media"/></a>
                    <a href="www.twitter.com"><img  src="img/twitter.png" class="media"/></a>
                    <a href="www.googleplus.com"><img  src="img/google-plus.png" class="media"/></a>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
