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

        public static MvcHtmlString ProductCategories(this HtmlHelper htmlHelper, int productId)
        {
            var results = db.GetProductSubscByCategory(productId);
            var ul = new TagBuilder("ul");

            foreach (var item in results)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder span = new TagBuilder("span");
                TagBuilder a = new TagBuilder("a");

                span.MergeAttribute("class", "badge");
                span.SetInnerText(item.Column1.ToString());
                a.MergeAttribute("href", "/Product/DisplayProducts/{{item.Id}}");
                    li.SetInnerText(String.Format("{0} {1}", _firstname.Compile()(item), _lastname.Compile()(item)));
                    ul.InnerHtml += li.ToString(TagRenderMode.Normal);

                //<li class="list-group-item">
                //                        <span class="badge">2</span>
                //                        <a href="http://demo.powerthemes.club/themes/couponer/code_category/computers/"> Computers </a>
                //                      </li>
            }
            //imageTag.MergeAttribute("src", src);
            //imageTag.MergeAttribute("alt", alt);
            //imageTag.MergeAttribute("width", width.ToString());
            //imageTag.MergeAttribute("height", height.ToString());

            return MvcHtmlString.Create(ul.ToString(TagRenderMode.SelfClosing));    
        }
    }
}