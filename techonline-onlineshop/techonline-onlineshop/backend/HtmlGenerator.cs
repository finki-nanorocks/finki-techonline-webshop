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
                html += "<p class='item-name'><a href='/product?id=" + item.product.id + "'>" + item.product.Model + "</a></p>";
                html += "<p>" + item.quantity + "x <span class='item-price'>$" + item.product.Price + "</span></p></div></li>";          
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
                html += "<header class='item-name'><a href='#'>" + item.product.Type + " " + item.product.Model + "</a></header>";
                html += "<ul>";
                html += "<li>HDD:" + item.product.Hdd + "</li>";
                html += "<li>CPU:" + item.product.Cpu + "</li>";
                html += "<li>RAM:" + item.product.Ram  + "</li>";
                html += "<li>OS:" + item.product.OS + "</li>";
                html += "</ul>";
                html += "</td>";
                html += "<td class='item-code'>MP125984154</td>";
                html += "<td class='item-price-col'><span class='item-price-special'>" + item.product.Price + "</span></td>";
                html += "<td>";
                html += "<div class='custom-quantity-input'>";
                html += "<input type='text' name='quantity' value='" + item.quantity + "'>";
                html += "<a href='#' onclick='return false;' class='quantity-btn quantity-input-up'><i class='fa fa-angle-up'></i></a>";
                html += "<a href='#' onclick='return false;' class='quantity-btn quantity-input-down'><i class='fa fa-angle-down'></i></a>";
                html += "</div>";
                html += "</td>";
                html += "<td class='item-total-col'><span class='item-price-special'>" + item.product.Price + "</span>";
                html += "<a href='#' class='close-button'></a>";
                html += "</td>";
                html += "</tr>";
            }
            return html;
        }

        public static string NEWProductsPageItems(List<Product> allProducts)
        {
            const int columns = 4;
            string html = "<div class='row'>";
            int count = 1;
            foreach(Product p in allProducts)
            {
                html += "<div class='col-md-4 col-sm-6 col-xs-12'>";
                html += "<div class='item'>";
                html += "<div class='item-image-container'>";
                html += "<figure>";
                html += "<a href='product.html'>";
                html += "<img src='images/products/item1.jpg' alt='item1' class='item-image'>";
                html += "<img src='images/products/item1-hover.jpg' alt='item1  Hover' class='item-image-hover'>";
                html += "</a>";
                html += "</figure>";
                html += "<div class='item-price-container'>";
                html += "<span class='old-price'>$210<span class='sub-price'>.99</span></span>";
                html += "<span class='item-price'>$165<span class='sub-price'>.99</span></span>";
                html += "</div>";
                html += "<span class='new-rect'>New</span>";
                html += "<span class='discount-rect'>-15%</span>";
                html += " </div><!-- End .item-image -->";
                html += "h3 class='item-name'><a href='product.html'>Phasellus consequat</a></h3>";
                html += "<div class='item-action'>";
                html += "<a href='#' class='item-add-btn'>";
                html += "<span class='icon-cart-text'>Add to Cart</span>";
                html += "</a>";
                html += "<div class='item-action-inner'>";
                html += "<a href='#' class='icon-button icon-compare'>Checkout</a>";
                html += "</div><!-- End .item-action-inner -->";
                html += "</div><!-- End .item-action -->";
                html += "</div><!-- End .item-meta-container -->";
                html += "</div><!-- End .item -->";
                html += "</div><!-- End .col-md-4 -->";
                count++;
                if(count == columns || (Math.Abs(allProducts.Count - count) >= 0))
                {
                    html += "</div><div class='row'>";
                    count = 0;
                }
            }

            return html;
        }
    }
}