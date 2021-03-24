namespace Sapfi.Api.V1.Domain.Core.Dtos.Notification.Create
{
    public class CreateNotificationDto
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string DeviceToken { get; set; }
    }
}
