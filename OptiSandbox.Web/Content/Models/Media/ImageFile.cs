using EPiServer.Framework.DataAnnotations;

namespace OptiSandbox.Web.Content.Models.Media;

[ContentType(
    DisplayName = "Image File",
    Description = "Use this to upload image files.",
    GUID = "042DE0E3-9B52-4951-815E-033299283B13"
)]
[MediaDescriptor(ExtensionString = "png,gif,jpg,jpeg,webp")]
public class ImageFile : ImageData
{
}
