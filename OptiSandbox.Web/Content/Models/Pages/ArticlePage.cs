using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Web.Content.Models.Pages;

[ContentType(DisplayName = "Article page", GUID = "B67A175B-BA19-4970-AC2F-FA1BE0741133")]
public class ArticlePage : PageData, ISitePage
{
    [Display(Name = "Title", Order = 100)]
    [CultureSpecific]
    public virtual string? Title { get; set; }

    [Display(Name = "Published at", Order = 200)]
    [CultureSpecific]
    [UIHint(SiteUiHints.DateOnly)]
    public virtual DateTime? PublishedAt { get; set; }

    [Display(Name = "Author", Order = 300)]
    [CultureSpecific]
    public virtual string? Author { get; set; }

    [Display(Name = "Content", Order = 400)]
    [CultureSpecific]
    public virtual XhtmlString? Content { get; set; }

    [Display(Name = "Enable breadcrumbs", GroupName = SystemTabNames.Content, Order = 100)]
    [CultureSpecific]
    public virtual bool EnableBreadcrumbs { get; set; }
}
