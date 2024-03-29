﻿using System.ComponentModel.DataAnnotations;

namespace OptiSandbox.Models;

public class SitePageData : PageData
{
    [Display(
        Name = "Main title",
        Order = 10,
        GroupName = Globals.GroupNames.Content
    )]
    [CultureSpecific]
    [Required]
    public virtual string? MainTitle { get; set; }

    [Display(
        GroupName = SystemTabNames.Settings,
        Order = 10
    )]
    [CultureSpecific]
    public virtual bool HideSiteHeader { get; set; }

    [Display(
        GroupName = SystemTabNames.Settings,
        Order = 20
    )]
    [CultureSpecific]
    public virtual bool HideSiteFooter { get; set; }
}
