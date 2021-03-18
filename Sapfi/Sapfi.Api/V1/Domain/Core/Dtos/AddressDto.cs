namespace Sapfi.Api.V1.Domain.Core.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Neighborhood { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
    }
}
