using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using OptiSandbox.Web.Content.Models;

namespace OptiSandbox.Web.Content.EditorDescriptors;

[EditorDescriptorRegistration(
    TargetType = typeof(DateTime),
    UIHint = SiteUiHints.DateOnly
)]
[EditorDescriptorRegistration(
    TargetType = typeof(DateTime?),
    UIHint = SiteUiHints.DateOnly
)]
public class DateOnlyEditorDescriptor : EditorDescriptor
{
    public override void ModifyMetadata(
        ExtendedMetadata metadata,
        IEnumerable<Attribute> attributes
    )
    {
        ClientEditingClass = "dijit/form/DateTextBox";
        base.ModifyMetadata(metadata, attributes);
    }
}
