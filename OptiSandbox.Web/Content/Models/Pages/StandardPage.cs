using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Web.Content.Models.Pages;

[ContentType(DisplayName = "Standard page", GUID = "1853482B-F3AE-48DB-A33E-8D8934335A43")]
public class StandardPage : SitePageData
{
    [CultureSpecific]
    [Display(Name = "Main body", GroupName = SystemTabNames.Content, Order = 100)]
    public virtual XhtmlString? MainBody { get; set; }
}
