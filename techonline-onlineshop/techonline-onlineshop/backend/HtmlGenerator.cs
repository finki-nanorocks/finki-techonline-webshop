using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using techonline_onlineshop;

namespace TechonlineAPI
{
    public class HtmlGenerator
    {
        public static string addCartDropdownItem(List<CartItem> CartItems)
        {
            string html = "";
            foreach (CartItem item in CartItems)
            {
                html += "<li class='item clearfix'>";
                html += "<a href = '/?deleteCartItem=" + item.id + "' title='Delete item' class='delete-item'><i class='fa fa-times'></i></a>";
                html += "<figure><a href ='/product?id=" + item.product.id + "'><img src='images/products/thumbnails/shoe1.jpg' alt='shoe 1'></a></figure>";
                html += "<div class='dropdown-cart-details'>";
                html += "<p class='item-name'><a href='/product?id=" + item.product.id + "'>" + item.product.Name + "</a></p>";
                html += "<p>" + item.quantity + "x <span class='item-price'>$" + item.product.Price + "</span></p></div></li>";          
            }
            return html;
        }
    }
}