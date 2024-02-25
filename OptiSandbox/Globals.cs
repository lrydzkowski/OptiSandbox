using System.ComponentModel.DataAnnotations;

namespace OptiSandbox;

public class Globals
{
    [GroupDefinitions]
    public static class GroupNames
    {
        [Display(Name = "Default", Order = 10)]
        public const string Default = "Default";

        [Display(Name = SystemTabNames.Content, Order = 20)]
        public const string Content = SystemTabNames.Content;
    }
}
