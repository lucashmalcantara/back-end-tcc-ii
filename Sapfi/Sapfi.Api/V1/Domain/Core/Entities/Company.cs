using Sapfi.Api.V1.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Sapfi.Api.V1.Domain.Core.Entities
{
    public class Company : BaseEntity
    {
        public string ApiToken { get; private set; }
        public string Document { get; private set; }
        public string Name { get; private set; }
        public string TradingName { get; private set; }
        public Address Address { get; set; }

        public Company(
            int id,
            DateTime createdAt,
            DateTime? updatedAt,
            bool isDeleted,
            string apiToken,
            string document,
            string name,
            string tradingName)
            : base(id, createdAt, updatedAt, isDeleted)
        {
            ApiToken = apiToken;
            Document = document;
            Name = name;
            TradingName = tradingName;
        }
    }
}
