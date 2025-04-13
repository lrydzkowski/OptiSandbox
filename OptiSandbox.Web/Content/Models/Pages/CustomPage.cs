using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Web.Content.Models.Pages;

[ContentType(DisplayName = "Custom page", GUID = "76CCA01A-511A-4463-A685-B7C3CAFE1E5A")]
public class CustomPage : PageData
{
    [Display(Name = "Title", GroupName = SystemTabNames.Content, Order = 100)]
    [CultureSpecific]
    public virtual string? Title { get; set; }

    [Display(Name = "Tab1Path", GroupName = SystemTabNames.Content, Order = 200)]
    [CultureSpecific]
    public virtual string? Tab1Path { get; set; }

    [Display(Name = "Tab2Path", GroupName = SystemTabNames.Content, Order = 300)]
    [CultureSpecific]
    public virtual string? Tab2Path { get; set; }
}
