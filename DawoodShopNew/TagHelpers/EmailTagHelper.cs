using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DawoodShopNew.TagHelpers
{
    public class EmailTagHelper:TagHelper
    {
        public string?Adress { get; set; }
        public string? Contact { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href","mailto:"+Adress);
            output.Content.SetContent(Contact);
        }
    }
}
