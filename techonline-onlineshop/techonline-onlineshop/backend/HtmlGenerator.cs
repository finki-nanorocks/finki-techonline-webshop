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
        public static string NEWCartDropdownItemHTML(List<CartItem> CartItems)
        {
            string html = "";
            int count = 0;
            foreach (CartItem item in CartItems)
            {
                count++;
                html += "<li class='item clearfix'>";
                html += "<a href = '/home.aspx?deleteCartItem=" + item.product.id + "' title='Delete item' class='delete-item'><i class='fa fa-times'></i></a>";
                html += "<figure><a href ='/product?id=" + item.product.id + "'><img src='images/products/thumbnails/shoe1.jpg' alt='shoe 1'></a></figure>";
                html += "<div class='dropdown-cart-details'>";
                html += "<p class='item-name'><a href='/product?id=" + item.product.id + "'>" + item.product.name + "</a></p>";
                html += "<p>" + item.quantity + "x <span class='item-price'>$" + item.product.price + "</span></p></div></li>";          
            }
            return html;
        }

        public static string NEWCartItemsHTML(List<CartItem> CartItems)
        {
            string html = "";
            foreach (CartItem item in CartItems)
            {
                html += "<tr>";
                html += "<td class='item-name-col'>";
                html += "<figure>";
                html += "<a href='#'><img src='images/products/"+ item.product.id +".png'></a>";
                html += "</figure>";
                html += "<header class='item-name'><a href='#'>" + item.product.cat_name + " " + item.product.name + "</a></header>";
                html += "<ul>";
                html += "<li>HDD:" + item.product.getHdd() +  "</li>";
                html += "<li>CPU:" + item.product.getCpu() + "</li>";
                html += "<li>RAM:" + item.product.getRam() + "</li>";
                html += "</ul>";
                html += "</td>";
                html += "<td class='item-code'>MP125984154</td>";
                html += "<td class='item-price-col'><span class='item-price-special'>" + item.product.price + "</span></td>";
                html += "<td>";
                html += "<div class='custom-quantity-input'>";
                html += "<input type='text' name='quantity' value='" + item.quantity + "'>";
                html += "<a href='#' onclick='return false;' class='quantity-btn quantity-input-up'><i class='fa fa-angle-up'></i></a>";
                html += "<a href='#' onclick='return false;' class='quantity-btn quantity-input-down'><i class='fa fa-angle-down'></i></a>";
                html += "</div>";
                html += "</td>";
                html += "<td class='item-total-col'><span class='item-price-special'>" + item.product.price + "</span>";
                html += "<a href='#' class='close-button'></a>";
                html += "</td>";
                html += "</tr>";
            }
            return html;
        }

        public static string success(String msg)
        {
            return "<div class='alert alert-success fade in'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong>" + msg + "</div>";
        }
    }
}