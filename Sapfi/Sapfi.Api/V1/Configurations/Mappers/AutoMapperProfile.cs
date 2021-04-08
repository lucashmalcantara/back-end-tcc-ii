using AutoMapper;
using Sapfi.Api.V1.Controllers.Models.CalledTicket.Get;
using Sapfi.Api.V1.Controllers.Models.Line.Get;
using Sapfi.Api.V1.Domain.Core.Entities;

namespace Sapfi.Api.V1.Configurations.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CalledTicket, GetCalledTicketModel>();
            CreateMap<Line, GetLineModel>();
        }
    }
}
