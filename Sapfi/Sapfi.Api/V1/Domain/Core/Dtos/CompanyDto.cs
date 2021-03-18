namespace Sapfi.Api.V1.Domain.Core.Dtos
{
    public class CompanyDto
    {
        public int Id { get; private set; }
        public string TradingName { get; private set; }
        public AddressDto Address { get; private set; }
    }
}
