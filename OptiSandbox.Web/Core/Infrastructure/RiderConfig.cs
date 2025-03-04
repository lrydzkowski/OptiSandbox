using JetBrains.Annotations;

[assembly: AspMvcViewLocationFormat("/Core/Views/{1}/{0}.cshtml")]
[assembly: AspMvcViewLocationFormat("/Core/Views/Shared/{0}.cshtml")]

[assembly: AspMvcAreaPartialViewLocationFormat("/Core/Views/{1}/{0}.cshtml")]
[assembly: AspMvcAreaPartialViewLocationFormat("/Core/Views/Shared/{0}.cshtml")]
