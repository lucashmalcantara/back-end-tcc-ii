namespace Sapfi.Api.V1.Application.Models.Company.Get
{
    public class GetCompanyModel
    {
        public int Id { get; set; }
        public string TradingName { get; set; }
        public GetCompanyAddressModel Address { get; set; }
    }
}
