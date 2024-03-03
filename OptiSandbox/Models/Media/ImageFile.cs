using EPiServer.Framework.DataAnnotations;

namespace OptiSandbox.Models.Media;

[ContentType(GUID = "54B1231E-6DA8-4222-990D-1DCBB5B77B68")]
[MediaDescriptor(ExtensionString = "jpg,jpeg,png")]
public class ImageFile : ImageData
{
}
