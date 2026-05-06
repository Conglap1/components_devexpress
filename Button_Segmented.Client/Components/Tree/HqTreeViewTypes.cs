namespace Button_Segmented.Client.Components.Tree;

/// <summary>
/// Data model for a single tree node.
/// </summary>
public class HqTreeNode
{
    public string Key { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public bool IsDisabled { get; set; }
    public string? IconCssClass { get; set; }
    public List<HqTreeNode>? Children { get; set; }

    /// <summary>Whether this node is enabled (inverse of IsDisabled, used by DxTreeView mapping).</summary>
    [System.Text.Json.Serialization.JsonIgnore]
    public bool IsEnabled => !IsDisabled;

    /// <summary>Whether this node has child nodes.</summary>
    [System.Text.Json.Serialization.JsonIgnore]
    public bool IsParent => Children is { Count: > 0 };
}

/// <summary>
/// Controls which optional elements are shown in each tree item row.
/// </summary>
public enum HqTreeIconMode
{
    /// <summary>No icon column — just expand + (checkbox) + text.</summary>
    None,

    /// <summary>Folder/folder-open icon shown before text.</summary>
    Folder,

    /// <summary>Custom icon via <see cref="HqTreeNode.IconCssClass"/>.</summary>
    Custom
}
