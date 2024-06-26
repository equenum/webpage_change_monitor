﻿namespace WebPageChangeMonitor.Models.Options;

// implement validation
public class Target
{
    // required, not null, empty or whitespace
    public string Id { get; set; }

    // not empty or whitespace
    public string DisplayName { get; set; }

    // not empty or whitespace
    public string Description { get; set; }

    // todo make the type Uri?
    // required, not null or whitespace
    public string Url { get; set; }

    // required, not null, empty or whitespace
    // validate the cron itself?
    // add default value
    public string CronSchedule { get; set; }

    // required, not null or whitespace
    public TargetType Type { get; set; }

    // required, not null or whitespace
    public string HtmlTag { get; set; }

    // optional
    public Selector Selector { get; set; }

    // only supposed to have value when target type is ValueCheck
    // not null or whitespace
    public string ExpectedValue { get; set; } 
}
