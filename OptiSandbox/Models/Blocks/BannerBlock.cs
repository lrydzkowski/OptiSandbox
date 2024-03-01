using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Models.Blocks;

[SiteContentType(GUID = "88AF97AA-87E2-4136-A998-6A0DF6839253")]
public class BannerBlock : SiteBlockData
{
    [Display(Order = 10, GroupName = SystemTabNames.Content)]
    [Required]
    public virtual string? Title { get; set; }

    [Display(Order = 20, GroupName = SystemTabNames.Content)]
    [UIHint(UIHint.Textarea)]
    [Required]
    public virtual string? Content { get; set; }
}
