using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Web.Content.Models.Pages;

public abstract class SitePageData : PageData
{
    [Display(Name = "Enable breadcrumbs", GroupName = SystemTabNames.Content, Order = 100)]
    [CultureSpecific]
    public virtual bool EnableBreadcrumbs { get; set; }
}
