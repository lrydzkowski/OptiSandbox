using EPiServer.Framework.DataAnnotations;

namespace OptiSandbox.Models.Media;

[ContentType(GUID = "F527B86D-0D2D-4AF0-9067-9934FA5B8EF8")]
[MediaDescriptor(ExtensionString = "mp4")]
public class VideoFile : VideoData
{
}
