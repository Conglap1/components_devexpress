namespace Button_Segmented.Client.Components.Dialog;

public enum HqDialogSize
{
    Sm,
    Md,
    Lg,
    Xl
}

/// <summary>Semantic intent — controls prefix-icon colour and optional accent styling.</summary>
public enum HqDialogIntent
{
    /// <summary>Default (no intent override). Icon uses --color-positive (green).</summary>
    None,
    /// <summary>Informational. Icon uses --color-useful (blue).</summary>
    Info,
    /// <summary>Success / positive action confirmed. Icon uses --color-positive (green).</summary>
    Success,
    /// <summary>Caution / non-destructive risk. Icon uses --color-yellow-60 (amber).</summary>
    Warning,
    /// <summary>Destructive / irreversible action. Icon uses --color-red-60 (red).</summary>
    Danger,
}
