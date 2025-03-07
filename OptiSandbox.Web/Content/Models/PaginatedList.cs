namespace OptiSandbox.Web.Content.Models;

public class PaginatedList<T>
{
    public List<T> Data { get; init; } = [];

    public int Count { get; set; } = 0;

    public int PageSize { get; set; } = 0;
}
