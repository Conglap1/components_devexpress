namespace Button_Segmented.Client.Components.ProgressBar;

public enum HqProgressCircleType {
    Label,
    Icon
}

public enum HqProgressCircleSize {
    Sm,
    Md,
    Lg,
    Xl
}

/// <summary>Status color for progress bar components.</summary>
public enum HqProgressStatus
{
    /// <summary>Neutral gray — no threshold breached.</summary>
    Default,
    /// <summary>Red — below target (stressful).</summary>
    Stressful,
    /// <summary>Yellow — approaching target (careful).</summary>
    Careful,
    /// <summary>Green — on or above target (positive).</summary>
    Positive
}

/// <summary>Size variants for the linear progress bar.</summary>
public enum HqProgressLineSize
{
    Md,
    Sm
}

/// <summary>Display type for the KPI progress widget.</summary>
public enum HqProgressKpiType
{
    Circle,
    Line
}
