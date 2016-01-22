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
        public static string NEWCartDropdownItemHTML(List<CartItem> CartItems, HttpContext context)
        {
            string html = "";
            int count = 0;
            foreach (CartItem item in CartItems)
            {
                count++;
                html += "<li class='item clearfix'>";
                html += "<a href = '/home.aspx?deleteCartItem=" + item.product.id + "' title='Delete item' class='delete-item'><i class='fa fa-times'></i></a>";
                html += "<figure><a href ='/product?id=" + item.product.id + "'><img src='" + TOS.Instance.getFullProductImagePath(item.product.image_path, context) + "' alt='shoe 1'></a></figure>";
                html += "<div class='dropdown-cart-details'>";
                html += "<p class='item-name'><a href='/product?id=" + item.product.id + "'>" + item.product.name + "</a></p>";
                html += "<p>" + item.quantity + "x <span class='item-price'>$" + item.product.price + "</span></p></div></li>";          
            }
            return html;
        }

        public static string NEWCartItemsHTML(List<CartItem> CartItems, HttpContext context)
        {
            string html = "";
            foreach (CartItem item in CartItems)
            {
                html += "<tr>";
                html += "<td class='item-name-col'>";
                html += "<figure>";
                html += "<a href='#'><img src='" + TOS.Instance.getFullProductImagePath(item.product.image_path, context) + "'></a>";
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

        public static string NEWShopContents(List<Product> all, HttpContext context)
        {
            String html = "<div class='row'>";
            for (int i = 0, j = 0; i < all.Count; i++)
            {
                j++;
                if (j == 0) { }
                html += "<div class='col-sm-4'>";
                html += "<div class='item item-hover'>";
                html += "<div class='item-image-wrapper'>";
                html += "<figure class='item-image-container'><a href='product.html'><img class='item-image' alt='item1' src='" + TOS.Instance.getFullProductImagePath(all[i].image_path, context) + "'></a></figure>";
                html += "<div class='item-price-container'><span class='item-price'>$" + Convert.ToString(all[i].price) + "</span></div>";
                html += "</div>";
                html += "<div class='item-meta-container'>";
                html += "<h3 class='item-name'><a href='product.html'>" + Convert.ToString(all[i].name) + "</a></h3>";
                html += "<div class='item-action'>";
                html += "<a class='item-add-btn' href='?add_to_cart=" + all[i].id + "'><span class='icon-cart-text'>Add to Cart</span></a>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
                if (j == 3)
                {
                    html += "</div><div class='row'>";
                    j = 0;
                }
            }
            html += "</div>"; //close oepend row
            return html;
        }

        public static string success(String msg)
        {
            return "<div class='alert alert-success fade in'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> " + msg + "</div>";
        }
    }
}