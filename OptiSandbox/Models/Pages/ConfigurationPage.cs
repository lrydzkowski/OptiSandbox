using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Models.Pages;

[SiteContentType(
    DisplayName = "Configuration",
    GUID = "D49CA589-8BA0-4BD7-B5F9-75AF758C5548",
    GroupName = Globals.GroupNames.Specialized
)]
public class ConfigurationPage : PageData
{
    [Display(Order = 20, GroupName = SystemTabNames.Content)]
    [Required]
    public virtual PageReference? OtherPagesRoot { get; set; }
}
