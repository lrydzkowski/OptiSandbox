using System.ComponentModel.DataAnnotations;
using OptiSandbox.Web.Features.Articles.Models;

namespace OptiSandbox.Web.Core.Models.Pages;

[ContentType(DisplayName = "Start page", GUID = "2DBB49EF-446C-43DD-AC23-9932D0BFF9A0")]
public class StartPage : SitePageData
{
    [CultureSpecific]
    [Display(Name = "Main body", GroupName = SystemTabNames.Content, Order = 100)]
    public virtual XhtmlString? MainBody { get; set; }

    [Display(Name = "Articles", GroupName = SystemTabNames.Content, Order = 200)]
    [AllowedTypes(typeof(ArticlePage))]
    public virtual ContentArea? Articles { get; set; }
}
