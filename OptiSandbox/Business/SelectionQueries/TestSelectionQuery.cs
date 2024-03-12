using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;

namespace OptiSandbox.Business.SelectionQueries;

[ServiceConfiguration(typeof(ISelectionQuery))]
public class TestSelectionQuery : ISelectionQuery
{
    private readonly SelectItem[] _items;

    public TestSelectionQuery()
    {
        _items =
        [
            new SelectItem
            {
                Text = "",
                Value = ""
            },
            new SelectItem
            {
                Text = "Text1",
                Value = "1"
            },
            new SelectItem
            {
                Text = "Text2",
                Value = "2"
            }
        ];
    }

    public IEnumerable<ISelectItem> GetItems(string query)
    {
        return _items.Where(i => i.Text.StartsWith(query, StringComparison.OrdinalIgnoreCase));
    }

    public ISelectItem? GetItemByValue(string value)
    {
        return _items.FirstOrDefault(i => i.Value.Equals(value));
    }
}
