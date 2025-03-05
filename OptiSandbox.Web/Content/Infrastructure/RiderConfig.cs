using JetBrains.Annotations;

[assembly: AspMvcViewLocationFormat("/Content/Views/{1}/{0}.cshtml")]
[assembly: AspMvcViewLocationFormat("/Content/Views/Shared/{0}.cshtml")]

[assembly: AspMvcAreaPartialViewLocationFormat("/Content/Views/{1}/{0}.cshtml")]
[assembly: AspMvcAreaPartialViewLocationFormat("/Content/Views/Shared/{0}.cshtml")]
