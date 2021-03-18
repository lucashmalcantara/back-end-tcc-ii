using Sapfi.Api.V1.Domain.Core.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Core.Entities
{
    public class Company : BaseEntity
    {
        public string ApiToken { get; private set; }
        public string Document { get; private set; }
        public string Name { get; private set; }
        public string TradingName { get; private set; }
        public Address Address { get; private set; }

        public Company(
            int id,
            DateTime createdAt,
            DateTime? updateAt,
            bool isDeleted,
            string apiToken,
            string document,
            string name,
            string tradingName,
            Address address)
            : base(id, createdAt, updateAt, isDeleted)
        {
            ApiToken = apiToken;
            Document = document;
            Name = name;
            TradingName = tradingName;
            Address = address;
        }
    }
}
