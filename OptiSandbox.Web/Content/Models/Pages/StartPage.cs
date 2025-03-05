using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Web.Content.Models.Pages;

[ContentType(DisplayName = "Start page", GUID = "2DBB49EF-446C-43DD-AC23-9932D0BFF9A0")]
public class StartPage : SitePageData
{
    [CultureSpecific]
    [Display(Name = "Main body", GroupName = SystemTabNames.Content, Order = 100)]
    public virtual XhtmlString? MainBody { get; set; }
}
