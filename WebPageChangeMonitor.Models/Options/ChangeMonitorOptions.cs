﻿namespace WebPageChangeMonitor.Models.Options;

public class ChangeMonitorOptions
{
    public const string SectionName = "ChangeMonitor";

    public int DefaultResourcePageSize { get; init; }
    public int DefaultTargetPageSize { get; init; }
    public int DefaultTargetSnapshotPageSize { get; init; }
    public bool AreNotificationsEnabled { get; init; }
    public JobRetryOptions JobRetry { get; set; }
}
