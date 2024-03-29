﻿using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using OptiSandbox.Business.SelectionFactories;
using OptiSandbox.Business.SelectionQueries;

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

    [Display(Name = "", Order = 200, GroupName = Globals.GroupNames.Testing)]
    [UIHint("aboutpage")]
    public virtual ContentReference? OtherPageReference { get; set; }

    [Display(Name = "", Order = 210, GroupName = Globals.GroupNames.Testing)]
    public virtual ContentArea? ContentAreaProperty { get; set; }

    [Display(Name = "", Order = 220, GroupName = Globals.GroupNames.Testing)]
    public virtual ContentReference? ContentReferenceProperty { get; set; }

    [Display(Name = "", Order = 230, GroupName = Globals.GroupNames.Testing)]
    public virtual IList<ContentReference>? ContentReferenceListProperty { get; set; }

    [Display(Name = "", Order = 240, GroupName = Globals.GroupNames.Testing)]
    [SelectOne(SelectionFactoryType = typeof(TestSelectionFactory))]
    public virtual string? SingleValue { get; set; }

    [Display(Name = "", Order = 250, GroupName = Globals.GroupNames.Testing)]
    [SelectMany(SelectionFactoryType = typeof(TestSelectionFactory))]
    public virtual IList<string>? MultipleValues { get; set; }

    [Display(Name = "", Order = 260, GroupName = Globals.GroupNames.Testing)]
    [AutoSuggestSelection(typeof(TestSelectionQuery), AllowCustomValues = true)]
    public virtual string? TestSelectionProperty { get; set; }
}
