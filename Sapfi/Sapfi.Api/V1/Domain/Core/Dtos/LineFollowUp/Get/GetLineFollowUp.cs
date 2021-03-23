namespace Sapfi.Api.V1.Domain.Core.Dtos.LineFollowUp.Get
{
    public class GetLineFollowUp
    {
        public int LineId { get; set; }
        public string DeviceToken { get; set; }
        public int NotifyWhen { get; set; }
    }
}
