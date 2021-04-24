namespace Sapfi.Api.V1.Domain.Models.LineState.Update
{
    public class LineModel
    {
        public int NumberOfTickets { get; private set; }
        public int WaitingTime { get; private set; }

        public LineModel(int numberOfTickets, int waitingTime)
        {
            NumberOfTickets = numberOfTickets;
            WaitingTime = waitingTime;
        }
        private LineModel() { }
    }
}
