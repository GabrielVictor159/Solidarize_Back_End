using FluentValidation.Results;
using FluentValidator;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Infraestructure.Services;

public class NotificationService : INotificationService
{
    public List<Notification> Notifications { get; set; } = new();
    public bool HasNotifications => Notifications.Any();
    public void AddNotification(string key, string message)
        => Notifications.Add(new Notification(key, message));
    public void AddNotifications(ValidationResult? validationResult)
        => validationResult?.Errors.ToList().ForEach(error => AddNotification(error.ErrorCode, error.ErrorMessage));
}
