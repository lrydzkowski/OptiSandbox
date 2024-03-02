using EPiServer.ServiceLocation;
using EPiServer.Web;
using OptiSandbox.Models;
using OptiSandbox.Models.Pages;

namespace OptiSandbox.Business;

[ServiceConfiguration]
public class PageViewContextFactory
{
    private readonly IContentLoader _contentLoader;

    public PageViewContextFactory(IContentLoader contentLoader)
    {
        _contentLoader = contentLoader;
    }

    public virtual LayoutViewModel CreateLayoutViewModel(ContentReference currentContentLink)
    {
        ContentReference? startPageContentLink = SiteDefinition.Current.StartPage;
        if (currentContentLink.CompareToIgnoreWorkID(startPageContentLink))
        {
            startPageContentLink = currentContentLink;
        }

        StartPage? startPage = _contentLoader.Get<StartPage>(startPageContentLink);
        LayoutViewModel layoutViewModel = new()
        {
            FooterLinks = startPage.FooterLinks
        };

        return layoutViewModel;
    }
}
