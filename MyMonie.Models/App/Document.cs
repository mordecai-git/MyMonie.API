// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using System.ComponentModel.DataAnnotations;

namespace MyMonie.Models.App;
public class Document : BaseAppModel
{
    [MaxLength(255)]
    [Required]
    public string Name { get; set; }

    [StringLength(25)]
    [Required]
    public string Type { get; set; }

    [MaxLength(255)]
    public required string Url { get; set; }

    [MaxLength(255)]
    public required string ThumbnailUrl { get; set; }

    [MaxLength(50)] public string VideoId { get; set; }
    public short VideoDuration { get; set; }
}
