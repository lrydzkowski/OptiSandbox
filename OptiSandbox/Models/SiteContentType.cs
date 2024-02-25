namespace OptiSandbox.Models;

public class SiteContentType : ContentTypeAttribute
{
    public SiteContentType()
    {
        GroupName = Globals.GroupNames.Default;
    }
}
