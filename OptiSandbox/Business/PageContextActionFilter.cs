using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OptiSandbox.Models;

namespace OptiSandbox.Business;

[ServiceConfiguration]
public class PageContextActionFilter : IResultFilter
{
    private readonly PageViewContextFactory _contextFactory;

    public PageContextActionFilter(PageViewContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        Controller? controller = context.Controller as Controller;
        object? viewModel = controller?.ViewData.Model;

        if (viewModel is IPageViewModel<SitePageData> model)
        {
            ContentReference? currentContentLink = context.HttpContext.GetContentLink();
            LayoutViewModel layoutModel = model.Layout ?? _contextFactory.CreateLayoutViewModel(currentContentLink);
            if (context.Controller is IModifyLayout layoutController)
            {
                layoutController.ModifyLayout(layoutModel);
            }

            model.Layout = layoutModel;
        }
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
    }
}
