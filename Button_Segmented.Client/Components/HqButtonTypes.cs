namespace Button_Segmented.Client.Components;

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

public enum HqBadgeDotSize {
    Md,
    Lg
}

public enum HqBadgeDotColor {
    Navy,
    Red,
    Green,
    Blue,
    Yellow,
    Orange,
    Pink,
    Purple,
    Sky,
    Brown,
    Grey
}

public enum HqBadgeVariant {
    Dot,
    Counter,
    InfoCounter,
    InfoRequire
}

public enum HqBadgeCounterType {
    SingleDigit,
    MultipleDigit
}

public enum HqBadgeInfoCounterType {
    Current,
    Selected,
    Available,
    Important
}

public enum HqBadgeInfoRequireType {
    Require,
    Done
}

public enum HqTextFieldState {
    Enabled,
    Focused,
    Filled,
    Error,
    Disabled
}

public enum HqTextFieldSize {
    Md,
    Sm
}

public enum HqTextAreaState {
    Enabled,
    Focused,
    Filled,
    Error,
    Disabled
}

public sealed class HqSegmentedItem {
    public string Text { get; set; } = string.Empty;
    public string? IconCssClass { get; set; }
    public string? LeadingIconCssClass { get; set; }
    public string? TrailingIconCssClass { get; set; }
    public bool Disabled { get; set; }
}
