using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Web.Content.Models.Pages;

public class MainPageData : PageData, ISitePage
{
    [CultureSpecific]
    [Display(Name = "Main menu label", GroupName = SystemTabNames.Content, Order = 200)]
    public virtual string? MainMenuLabel { get; set; }

    [Display(Name = "Enable breadcrumbs", GroupName = SystemTabNames.Content, Order = 100)]
    [CultureSpecific]
    public virtual bool EnableBreadcrumbs { get; set; }
}
