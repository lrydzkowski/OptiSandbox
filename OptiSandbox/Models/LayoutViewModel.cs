using EPiServer.SpecializedProperties;

namespace OptiSandbox.Models;

public class LayoutViewModel
{
    public bool HideHeader { get; set; }

    public bool HideFooter { get; set; }

    public virtual LinkItemCollection? FooterLinks { get; set; }
}
