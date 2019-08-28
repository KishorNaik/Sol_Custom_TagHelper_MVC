using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Sol_Custom_TagHelper.Models;

namespace Sol_Custom_TagHelper.Helper
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("asp-progressbar-modelexpression")]
    public class ProgressBarModelExpressionTagHelper : TagHelper
    {
        #region Declaration
        private const String ProgressValueAttributeName = "for-value";
        private const String ProgressMinAttributeName = "for-min";
        private const String ProgressMaxAttributeName = "for-max";

        private readonly IHtmlHelper htmlHelper = null;
        #endregion

        #region Constructor
        public ProgressBarModelExpressionTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }
        #endregion 

        #region Property
        [HtmlAttributeName(ProgressValueAttributeName)]
        public ModelExpression ProgressBarValue { get; set; }

        [HtmlAttributeName(ProgressMinAttributeName)]
        public ModelExpression ProgressBarMin { get; set; }

        [HtmlAttributeName(ProgressMaxAttributeName)]
        public ModelExpression ProgressBarMax { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            var progressBarModelObj = new ProgressBarModel()
            {
                ProgressBarValue = (int) this.ProgressBarValue.Model,
                ProgressBarMin = (int) this.ProgressBarMin.Model,
                ProgressBarMax = (int)this.ProgressBarMax.Model
            };

            var content = await htmlHelper.PartialAsync("~/Views/Shared/_ProgressBarControl.cshtml", progressBarModelObj);

            output.Content.SetHtmlContent(content);

            //return base.ProcessAsync(context, output);
        }
    }
}
