namespace Sapfi.Api.V1.Domain.Core.Dtos.Company.Get
{
    public class GetCompanyDto
    {
        public int Id { get; set; }
        public string TradingName { get; set; }
        public GetCompanyAddressDto Address { get; set; }
    }
}
