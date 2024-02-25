using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Models.Pages;

[ContentType(
    DisplayName = "Start page",
    GUID = "923B78B0-82DE-4AD4-8957-690ED4D54232",
    Description = "The start page."
)]
public class StartPage : SitePageData
{
    [Display(
        Name = "Main title",
        Order = 10,
        GroupName = Globals.GroupNames.Content
    )]
    [Required]
    public virtual string? MainTitle { get; set; }
}
