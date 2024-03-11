using EPiServer.Shell.ObjectEditing;

namespace OptiSandbox.Business.SelectionFactories;

public class TestSelectionFactory : ISelectionFactory
{
    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        return new ISelectItem[]
        {
            new SelectItem()
            {
                Text = "Text1", Value = "Value1"
            },
            new SelectItem()
            {
                Text = "Text2", Value = "Value2"
            },
            new SelectItem()
            {
                Text = "Text3", Value = "Value3"
            }
        };
    }
}
