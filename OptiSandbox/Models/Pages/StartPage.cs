using System.ComponentModel.DataAnnotations;
using EPiServer.SpecializedProperties;
using OptiSandbox.Models.Blocks;

namespace OptiSandbox.Models.Pages;

[ContentType(
    DisplayName = "Start page",
    GUID = "923B78B0-82DE-4AD4-8957-690ED4D54232",
    Description = "The start page."
)]
public class StartPage : SitePageData
{
    [Display(
        Name = "Banners",
        Order = 20,
        GroupName = Globals.GroupNames.Content
    )]
    [AllowedTypes([typeof(BannerBlock)])]
    [Required]
    public virtual ContentArea? Banners { get; set; }

    [Display(GroupName = Globals.GroupNames.SiteSettings, Order = 30)]
    public virtual LinkItemCollection? FooterLinks { get; set; }
}
