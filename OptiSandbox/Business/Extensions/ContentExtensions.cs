using EPiServer.Filters;
using EPiServer.Framework.Web;
using EPiServer.ServiceLocation;

namespace OptiSandbox.Business.Extensions;

public static class ContentExtensions
{
    public static IEnumerable<T> FilterForDisplay<T>(
        this IEnumerable<T> contents,
        bool requirePageTemplate = false,
        bool requireVisibleInMenu = false
    )
        where T : IContent
    {
        FilterAccess accessFilter = new();
        FilterPublished publishedFilter = new();
        contents = contents.Where(x => !publishedFilter.ShouldFilter(x) && !accessFilter.ShouldFilter(x));
        if (requirePageTemplate)
        {
            FilterTemplate templateFilter = ServiceLocator.Current.GetInstance<FilterTemplate>();
            templateFilter.TemplateTypeCategories = TemplateTypeCategories.Request;
            contents = contents.Where(x => !templateFilter.ShouldFilter(x));
        }

        if (requireVisibleInMenu)
        {
            contents = contents.Where(x => VisibleInMenu(x));
        }

        return contents;
    }

    private static bool VisibleInMenu(IContent content)
    {
        if (content is not PageData page)
        {
            return true;
        }

        return page.VisibleInMenu;
    }
}
