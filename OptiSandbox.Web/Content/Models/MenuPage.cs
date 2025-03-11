namespace OptiSandbox.Web.Content.Models;

public class MenuPage
{
    public string Label { get; set; } = "";

    public ContentReference? PageReference { get; set; }

    public bool IsSelected { get; set; }
}
