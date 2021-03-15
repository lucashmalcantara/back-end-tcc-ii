using Sapfi.Api.V1.Domain.Core.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Core.Entities
{
    public class Address : BaseEntity
    {
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Neighborhood { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }

        public Address(
            int id,
            DateTime createdAt,
            DateTime? updateAt,
            bool isDeleted,
            string country, 
            string state, 
            string city, 
            string postalCode, 
            string neighborhood, 
            string street, 
            string number, 
            string complement)
            : base(id, createdAt, updateAt, isDeleted)
        {
            Country = country;
            State = state;
            City = city;
            PostalCode = postalCode;
            Neighborhood = neighborhood;
            Street = street;
            Number = number;
            Complement = complement;
        }
    }
}
