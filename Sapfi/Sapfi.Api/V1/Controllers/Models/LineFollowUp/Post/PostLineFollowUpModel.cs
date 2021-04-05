namespace Sapfi.Api.V1.Controllers.Models.LineFollowUp.Post
{
    public class PostLineFollowUpModel
    {
        public int LineId { get; set; }
        public string DeviceToken { get; set; }
        public int NotifyWhen { get; set; }
    }
}
