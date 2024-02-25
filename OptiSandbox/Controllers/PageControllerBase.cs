using EPiServer.Web.Mvc;
using OptiSandbox.Business;
using OptiSandbox.Models;

namespace OptiSandbox.Controllers;

public abstract class PageControllerBase<T> : PageController<T>, IModifyLayout where T : SitePageData
{
    public virtual void ModifyLayout(LayoutViewModel layoutModel)
    {
        if (PageContext.Page is SitePageData page)
        {
            layoutModel.HideHeader = page.HideSiteHeader;
            layoutModel.HideFooter = page.HideSiteFooter;
        }
    }
}
