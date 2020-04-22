using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreSplash.App.Models;
using System.Collections.Generic;
using System.Text;

namespace NetCoreSplash.App.Helpers
{
    public static class HtmlHelperExtensions 
    {
        public static HtmlString NetCoreSplashMessage(this IHtmlHelper helper, string message)
        {
            return new HtmlString($"<span>{message}<span>");
        }

        public static HtmlString RenderMenu(this IHtmlHelper helper, List<MenuViewModel> menu = null)
        {
            StringBuilder menuDefault = new StringBuilder();

            if (menu != null && menu.Count > 0)
            {
                foreach (var item in menu)
                {
                    menuDefault.Append("<li class=\"nav-item\">");
                    menuDefault.Append(string.Format("   <a class=\"nav-link text-dark {0}\" asp-area=\"{1}\" asp-controller=\"{2}\" asp-action=\"{3}\">{4}</a>",item.ClassCss, item.Area, item.Controller, item.Action, item.Label));
                    menuDefault.Append("</li>");
                }
            }
            else 
            {
                menuDefault.Append("<li class=\"nav-item\">");
                menuDefault.Append("   <a class=\"nav-link text-dark\" asp-area=\"\" asp-controller=\"Home\" asp-action=\"Index\">Home</a>");
                menuDefault.Append("</li>");
                menuDefault.Append("<li class=\"nav-item\">");
                menuDefault.Append("    <a class=\"nav-link text-dark\" asp-area=\"\" asp-controller=\"Home\" asp-action=\"Privacy\">Privacy</a>");
                menuDefault.Append("</li>");
            }

            return new HtmlString(menuDefault.ToString());
        }


    }
}
