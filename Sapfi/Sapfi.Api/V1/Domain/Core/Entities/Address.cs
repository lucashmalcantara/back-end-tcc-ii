using Sapfi.Api.V1.Domain.Core.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Core.Entities
{
    public class Address : BaseEntity
    {
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string Neighborhood { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public Company Company { get; set; }

        public Address(
            int id,
            DateTime createdAt,
            DateTime? updatedAt,
            bool isDeleted,
            string country,
            string state,
            string city,
            string zipCode,
            string neighborhood,
            string street,
            string number,
            string complement) : base(id, createdAt, updatedAt, isDeleted)
        {
            Country = country;
            State = state;
            City = city;
            ZipCode = zipCode;
            Neighborhood = neighborhood;
            Street = street;
            Number = number;
            Complement = complement;
        }
    }
}
