using Sapfi.Api.V1.Domain.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Entities
{
    public class Company : IEntity
    {
        public int Id => throw new NotImplementedException();

        public DateTime CreatedAt => throw new NotImplementedException();

        public DateTime? UpdatedAt => throw new NotImplementedException();

        public bool IsDeleted => throw new NotImplementedException();
    }
}
