namespace Sapfi.Api.V1.Domain.Core.Dtos.Company.Get
{
    public class GetCompanyAddressDto
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
    }
}
