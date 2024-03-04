using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using OptiSandbox.Business.Configuration;
using OptiSandbox.Models.Pages;

namespace OptiSandbox.Business.Descriptors;

[EditorDescriptorRegistration(TargetType = typeof(ContentReference), UIHint = "aboutpage")]
public class OtherPageReferenceEditorDescriptor : ContentReferenceEditorDescriptor<AboutPage>
{
    private readonly IDynamicConfiguration _configuration;

    public OtherPageReferenceEditorDescriptor(IDynamicConfiguration configuration)
    {
        _configuration = configuration;
    }

    public override IEnumerable<ContentReference> Roots
    {
        get
        {
            if (_configuration.OtherPagesRoot == null)
            {
                return Array.Empty<ContentReference>();
            }

            return new[]
            {
                _configuration.OtherPagesRoot
            };
        }
    }
}
