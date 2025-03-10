using EPiServer.Shell.ObjectEditing;

namespace OptiSandbox.Web.Commerce.Catalog.SelectionFactories;

public class VersionSelectionFactory : ISelectionFactory
{
    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        return
        [
            new SelectItem
            {
                Value = 1,
                Text = "Basic"
            },
            new SelectItem
            {
                Value = 2,
                Text = "Extended"
            }
        ];
    }
}
