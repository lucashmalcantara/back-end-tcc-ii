using AutoMapper;
using Sapfi.Api.V1.Application.Models.CalledTicket.Get;
using Sapfi.Api.V1.Application.Models.Company.Get;
using Sapfi.Api.V1.Application.Models.Line.Get;
using Sapfi.Api.V1.Application.Models.LineState.Post;
using Sapfi.Api.V1.Application.Models.Ticket.Get;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Models.LineState.Update;

namespace Sapfi.Api.V1.Application.Mapping.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CalledTicket, GetCalledTicketModel>();
            CreateMap<Line, GetLineModel>();
            CreateMap<PostLineStateModel, LineStateModel>();
            CreateMap<PostLineStateCalledTicketModel, CalledTicketModel>();
            CreateMap<PostLineStateLineModel, LineModel>();
            CreateMap<PostLineStateTicketModel, TicketModel>();
            CreateMap<Ticket, GetTicketModel>();
            CreateMap<Company, GetCompanyModel>();
            CreateMap<Address, GetCompanyAddressModel>();
        }
    }
}
