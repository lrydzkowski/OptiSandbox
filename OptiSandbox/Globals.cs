using System.ComponentModel.DataAnnotations;

namespace OptiSandbox;

public static class Globals
{
    [GroupDefinitions]
    public static class GroupNames
    {
        [Display(Name = "Default", Order = 10)]
        public const string Default = "Default";

        [Display(Name = SystemTabNames.Content, Order = 20)]
        public const string Content = SystemTabNames.Content;

        [Display(Name = "SiteSettings", Order = 30)]
        public const string SiteSettings = "SiteSettings";

        [Display(Name = "Specialized", Order = 40)]
        public const string Specialized = "Specialized";
    }
}
