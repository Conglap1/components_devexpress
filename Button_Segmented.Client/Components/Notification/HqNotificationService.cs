using DevExpress.Blazor;

namespace Button_Segmented.Client.Components.Notification;

/// <summary>
/// Service để trigger HqNotification toast.
/// Wrap IToastNotificationService của DevExpress — DX xử lý positioning, animation, auto-dismiss.
/// </summary>
public class HqNotificationService
{
    private readonly IToastNotificationService _dx;

    public HqNotificationService(IToastNotificationService dx)
    {
        _dx = dx;
    }

    public void Show(string heading,
                     HqNotificationType type = HqNotificationType.Default,
                     string? description = null,
                     int durationMs = 4000)
    {
        _dx.ShowToast(new ToastOptions
        {
            Title     = heading,
            Text      = description,
            CssClass  = $"hq-notif hq-notif--{type.ToString().ToLowerInvariant()}",
            ShowIcon  = true,
            IconCssClass = GetIconClass(type),
            DisplayTime  = durationMs > 0
                           ? TimeSpan.FromMilliseconds(durationMs)
                           : TimeSpan.Zero
        });
    }

    private static string GetIconClass(HqNotificationType type) => type switch
    {
        HqNotificationType.Positive  => "fa-solid fa-circle-check",
        HqNotificationType.Stressful => "fa-solid fa-circle-exclamation",
        HqNotificationType.Careful   => "fa-solid fa-triangle-exclamation",
        HqNotificationType.Useful    => "fa-solid fa-circle-info",
        _                            => "fa-regular fa-bell"
    };
}
