using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Models.Blocks;

namespace OptiSandbox.Components;

public class BannerBlockViewComponent : BlockComponent<BannerBlock>
{
    protected override IViewComponentResult InvokeComponent(BannerBlock currentContent)
    {
        return View(currentContent);
    }
}
