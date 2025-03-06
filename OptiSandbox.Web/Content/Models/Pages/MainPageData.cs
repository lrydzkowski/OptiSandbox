using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Web.Content.Models.Pages;

public class MainPageData : SitePageData
{
    [CultureSpecific]
    [Display(Name = "Main menu label", GroupName = SystemTabNames.Content, Order = 200)]
    public virtual string? MainMenuLabel { get; set; }
}
