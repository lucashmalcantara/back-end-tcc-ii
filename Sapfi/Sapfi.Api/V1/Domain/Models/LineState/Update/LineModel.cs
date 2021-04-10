namespace Sapfi.Api.V1.Domain.Models.LineState.Update
{
    public class LineModel
    {
        public int QuantityOfTicket { get; private set; }
        public int WaitingTime { get; private set; }

        public LineModel(int quantityOfTicket, int waitingTime)
        {
            QuantityOfTicket = quantityOfTicket;
            WaitingTime = waitingTime;
        }
        private LineModel() { }
    }
}
