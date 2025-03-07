using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace OptiSandbox.Web.Content.Models.Pages;

[ContentType(DisplayName = "About page", GUID = "797FC29E-5770-4DEE-945F-430E52C05EC4")]
public class AboutPage : MainPageData
{
    [Display(Name = "Title", GroupName = SystemTabNames.Content, Order = 100)]
    [CultureSpecific]
    public virtual string? Title { get; set; }

    [Display(Name = "Subtitle", GroupName = SystemTabNames.Content, Order = 200)]
    [CultureSpecific]
    public virtual string? Subtitle { get; set; }

    [Display(Name = "Person image", GroupName = SystemTabNames.Content, Order = 300)]
    [CultureSpecific]
    [UIHint(UIHint.Image)]
    public virtual ContentReference? PersonImage { get; set; }

    [Display(Name = "Content", GroupName = SystemTabNames.Content, Order = 400)]
    [CultureSpecific]
    public virtual XhtmlString? Content { get; set; }
}
