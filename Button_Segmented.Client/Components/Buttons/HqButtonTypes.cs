namespace Button_Segmented.Client.Components.Buttons;

public enum HqButtonVariant {
    Primary,
    Secondary,
    Outline,
    Ghost
}

public enum HqButtonSize {
    Md,
    Sm,
    Xs
}

public enum HqButtonShape {
    RoundedMedium,
    RoundedFull,
    None
}

public enum HqButtonVisualState {
    Enabled,
    Hover,
    Pressed,
    Disabled
}

public sealed class HqSegmentedItem {
    public string Text { get; set; } = string.Empty;
    public string? IconCssClass { get; set; }
    public string? LeadingIconCssClass { get; set; }
    public string? TrailingIconCssClass { get; set; }
    public bool Disabled { get; set; }
}
