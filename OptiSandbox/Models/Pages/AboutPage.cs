using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Models.Pages;

[ContentType(
    DisplayName = "About page",
    GUID = "32CAF941-3A4A-4BB2-8252-A1390CDA98D7"
)]
public class AboutPage : SitePageData
{
    [Display(Order = 20, GroupName = SystemTabNames.Content)]
    [UIHint(UIHint.Textarea)]
    [Required]
    public virtual string? Content { get; set; }
}
