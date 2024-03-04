using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Models.Pages;

[ContentType(
    DisplayName = "About page",
    GUID = "32CAF941-3A4A-4BB2-8252-A1390CDA98D7"
)]
public class AboutPage : SitePageData
{
    [Display(Order = 20, GroupName = SystemTabNames.Content)]
    [Required]
    public virtual XhtmlString? Content { get; set; }

    [Display(Order = 30, GroupName = Globals.GroupNames.Content)]
    [Editable(false)]
    public virtual string? TestProperty { get; set; }
}
