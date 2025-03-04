using JetBrains.Annotations;

[assembly: AspMvcViewLocationFormat("/Features/Articles/Views/{1}/{0}.cshtml")]
[assembly: AspMvcViewLocationFormat("/Features/Articles/Views/Shared/{0}.cshtml")]

[assembly: AspMvcAreaPartialViewLocationFormat("/Features/Articles/Views/{1}/{0}.cshtml")]
[assembly: AspMvcAreaPartialViewLocationFormat("/Features/Articles/Views/Shared/{0}.cshtml")]
