using EPiServer.ServiceLocation;
using OptiSandbox.Models;

namespace OptiSandbox.Business;

[ServiceConfiguration]
public class PageViewContextFactory
{
    public virtual LayoutViewModel CreateLayoutViewModel()
    {
        return new LayoutViewModel();
    }
}
