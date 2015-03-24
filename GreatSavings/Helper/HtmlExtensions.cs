using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreatSavings.Helper
{
    public static class HtmlExtensions
    {
        private static GreatSavingsEntities db = new GreatSavingsEntities();

        public static MvcHtmlString CustomImage<TModel>(this HtmlHelper<TModel> htmlHelper, string src, string alt, int width, int height)
        {       
                var imageTag = new TagBuilder("image");
                imageTag.MergeAttribute("src", src);
                imageTag.MergeAttribute("alt", alt);
                imageTag.MergeAttribute("width", width.ToString());
                imageTag.MergeAttribute("height", height.ToString());                   
                   
                return MvcHtmlString.Create(imageTag.ToString(TagRenderMode.SelfClosing));           
        }

        public static MvcHtmlString ProductCategories(this HtmlHelper htmlHelper, int productId, string productName)
        {
            try
            {
                var results = db.GetProductSubscByCategory(productId);
                var ul = new TagBuilder("ul");
                var div_widget_inner = new TagBuilder("div");
                var div_widget_caption = new TagBuilder("div");

                div_widget_inner.MergeAttribute("class", "widget-inner");
                div_widget_caption.MergeAttribute("class", "widget-caption");
                div_widget_caption.InnerHtml = string.Format("<h4>{0} Categories</h4>", productName);

                ul.AddCssClass("list-group");

                foreach (var item in results)
                {
                    TagBuilder li = new TagBuilder("li");
                    TagBuilder span = new TagBuilder("span");
                    TagBuilder a = new TagBuilder("a");

                    span.MergeAttribute("class", "badge");
                    span.InnerHtml=item.Total.ToString();
                    a.InnerHtml =item.Category;
                    a.MergeAttribute("href", "/Product/DisplayProducts/" +1 );
                    li.InnerHtml = a.ToString() + span.ToString();
                    li.MergeAttribute("class", "list-group-item");
                    ul.InnerHtml += li.ToString(TagRenderMode.Normal);
                }

                div_widget_inner.InnerHtml = div_widget_caption.ToString();
                div_widget_inner.InnerHtml += ul.ToString();

                return MvcHtmlString.Create(div_widget_inner.ToString());
            }
            catch(Exception ex)
            {
               return MvcHtmlString.Create("");
            }
        }

        public static MvcHtmlString CategoryDropDown(this HtmlHelper htmlHelper, int productId)
        {
            try
            {
                var results = db.GetProductSubscByCategory(productId);
                var dropDownButton = new TagBuilder("button");
                var ul = new TagBuilder("ul");

                dropDownButton.MergeAttribute("class", "btn btn-default dropdown-toggle");
                dropDownButton.MergeAttribute("data-toggle", "dropdown");
                dropDownButton.InnerHtml = "Categories <span class='fa fa-angle-down pull-right'></span>";

                ul.AddCssClass("dropdown-menu dd-custom dd-widget");
                ul.MergeAttribute("role", "menu");

                foreach (var item in results)
                {
                    TagBuilder li = new TagBuilder("li");
                    TagBuilder a = new TagBuilder("a");
                    TagBuilder i = new TagBuilder("i");
                    
                    a.InnerHtml = item.Category;
                    a.MergeAttribute("href", "#");
                    li.InnerHtml = a.ToString();
                    ul.InnerHtml += li.ToString(TagRenderMode.Normal);
                }

                string render = dropDownButton.ToString();
                render += ul.ToString();

                return MvcHtmlString.Create(render);
            }
            catch (Exception ex)
            {
                return MvcHtmlString.Create("");
            }
        }
        public static MvcHtmlString LocationDropDown(this HtmlHelper htmlHelper, int productId)
        {
            try
            {
                var results = db.States;
                var dropDownButton = new TagBuilder("button");
                var ul = new TagBuilder("ul");

                dropDownButton.MergeAttribute("class", "btn btn-default dropdown-toggle");
                dropDownButton.MergeAttribute("data-toggle", "dropdown");
                dropDownButton.InnerHtml = "Location <span class='fa fa-angle-down pull-right'></span>";

                ul.AddCssClass("dropdown-menu dd-custom dd-widget");
                ul.MergeAttribute("role", "menu");

                foreach (var item in results)
                {
                    TagBuilder li = new TagBuilder("li");
                    TagBuilder a = new TagBuilder("a");
                    TagBuilder i = new TagBuilder("i");

                    a.InnerHtml = item.StateName;
                    a.MergeAttribute("href", "#");
                    li.InnerHtml = a.ToString();
                    ul.InnerHtml += li.ToString(TagRenderMode.Normal);
                }

                string render = dropDownButton.ToString();
                render += ul.ToString();

                return MvcHtmlString.Create(render);
            }
            catch (Exception ex)
            {
                return MvcHtmlString.Create("");
            }
        }

    }
}