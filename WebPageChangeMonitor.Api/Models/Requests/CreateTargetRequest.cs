﻿using System;
using System.ComponentModel.DataAnnotations;
using WebPageChangeMonitor.Common.Attributes;
using WebPageChangeMonitor.Models.Consts;

namespace WebPageChangeMonitor.Api.Models.Requests;

public class CreateTargetRequest
{
    [Required]
    public Guid ResourceId { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(20)]
    public string DisplayName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string Description { get; set; }

    // todo test
    [Required]
    [Url]
    public string Url { get; set; }

    [Required]
    [QuartzCronExpression]
    public string CronSchedule { get; set; }

    [Required]
    [EnumDataType(typeof(ChangeType))]
    public ChangeType ChangeType { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(20)]
    public string HtmlTag { get; set; }

    [Required]
    [EnumDataType(typeof(SelectorType))]
    public SelectorType SelectorType { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(50)]
    public string SelectorValue { get; set; }

    [StringLength(100, MinimumLength = 1)]
    public string ExpectedValue { get; set; } 
}
