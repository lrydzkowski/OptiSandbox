using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Web.Content.Models.Pages;

[ContentType(DisplayName = "Article page", GUID = "B67A175B-BA19-4970-AC2F-FA1BE0741133")]
public class ArticlePage : SitePageData
{
    [Display(Name = "Title", Order = 100)]
    public virtual string? Title { get; set; }

    [Display(Name = "Content", Order = 200)]
    public virtual XhtmlString? Content { get; set; }
}
