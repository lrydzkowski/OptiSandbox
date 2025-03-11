namespace OptiSandbox.Web.Content.Models;

public class Article
{
    public string Title { get; set; } = "";

    public DateTimeOffset CreatedAt { get; set; }

    public string Url { get; set; } = "";
}
