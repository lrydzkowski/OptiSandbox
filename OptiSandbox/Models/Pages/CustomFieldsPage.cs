using System.ComponentModel.DataAnnotations;
using EPiServer.Framework.Blobs;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace OptiSandbox.Models.Pages;

[ContentType(
    DisplayName = "Custom fields page",
    GUID = "6F07006B-7989-4BE8-AE12-B318D7D50C53",
    Description = "A page with custom fields."
)]
public class CustomFieldsPage : SitePageData
{
    [Display(Name = "Range integer", Order = 100, GroupName = Globals.GroupNames.Testing)]
    public virtual int? RangeInteger { get; set; }

    [Display(Name = "Range double", Order = 110, GroupName = Globals.GroupNames.Testing)]
    public virtual double? RangeDouble { get; set; }

    [Display(Name = "Page type", Order = 120, GroupName = Globals.GroupNames.Testing)]
    public virtual PageType? PageType { get; set; }

    [Display(Name = "Page Reference", Order = 140, GroupName = Globals.GroupNames.Testing)]
    public virtual PageReference? PageReference { get; set; }

    [Display(Name = "Image", Order = 150, GroupName = Globals.GroupNames.Testing)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference? Image { get; set; }

    [Display(Name = "Video", Order = 160, GroupName = Globals.GroupNames.Testing)]
    [UIHint(UIHint.Video)]
    public virtual ContentReference? Video { get; set; }

    //[Display(Name = "Image2", Order = 170, GroupName = Globals.GroupNames.Testing)]
    //[UIHint(UIHint.Image)]
    //public virtual Url? Image2 { get; set; }

    [Display(Name = "Link Item Collection", Order = 180, GroupName = Globals.GroupNames.Testing)]
    public virtual LinkItemCollection? LinkItemCollection { get; set; }

    [Display(Name = "Link Item", Order = 190, GroupName = Globals.GroupNames.Testing)]
    public virtual LinkItem? LinkItem { get; set; }
}
