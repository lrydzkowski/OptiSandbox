namespace OptiSandbox.Web.Content.Extensions;

internal static class ContentLoaderExtensions
{
    public static IContent? GetAncestorOrSelf(
        this IContentLoader contentLoader,
        IContent content,
        Func<IContent, IContent?, bool> predicate,
        int maxLevel = int.MaxValue
    )
    {
        IContent contentPivot = content;
        for (int i = 0; i < maxLevel; i++)
        {
            IContent? parent = ContentReference.IsNullOrEmpty(contentPivot.ParentLink)
                ? null
                : contentLoader.Get<IContent>(contentPivot.ParentLink);
            if (predicate.Invoke(contentPivot, parent))
            {
                return contentPivot;
            }

            if (parent is null)
            {
                return null;
            }

            contentPivot = parent;
        }

        return null;
    }
}
