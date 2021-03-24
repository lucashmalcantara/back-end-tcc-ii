namespace Sapfi.Api.V1.Domain.Core.Dtos.LineFollowUp.Create
{
    public class CreateLineFollowUp
    {
        public int LineId { get; set; }
        public string DeviceToken { get; set; }
        public int NotifyWhen { get; set; }
    }
}
