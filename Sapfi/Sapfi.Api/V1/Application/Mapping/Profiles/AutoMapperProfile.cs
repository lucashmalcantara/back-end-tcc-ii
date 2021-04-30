using AutoMapper;
using Sapfi.Api.V1.Application.Models.Company.Get;
using Sapfi.Api.V1.Application.Models.Line.Get;
using Sapfi.Api.V1.Application.Models.LineFollowUp.Post;
using Sapfi.Api.V1.Application.Models.LineState.Post;
using Sapfi.Api.V1.Application.Models.Ticket.Get;
using Sapfi.Api.V1.Application.Models.TicketFollowUp.Post;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Models.LineState.Update;

namespace Sapfi.Api.V1.Application.Mapping.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Line, GetLineModel>();
            CreateMap<PostLineStateModel, LineStateModel>();
            CreateMap<PostLineStateLineModel, LineModel>();
            CreateMap<PostLineStateTicketModel, TicketModel>();
            CreateMap<Ticket, GetTicketModel>()
                .ForMember(t => t.CompanyTradingName, o => o.MapFrom(t => t.Company.TradingName));
            CreateMap<Ticket, GetCalledTicketModel>();
            CreateMap<Company, GetCompanyModel>();
            CreateMap<Address, GetCompanyAddressModel>();
            CreateMap<PostTicketFollowUpModel, TicketFollowUp>().ConstructUsing(t => new TicketFollowUp(default, default, default, default, t.TicketId, t.DeviceToken, default));
            CreateMap<PostLineFollowUpModel, LineFollowUp>().ConstructUsing(l => new LineFollowUp(default, default, default, default, l.LineId, l.DeviceToken, l.NotifyWhen, default));
        }
    }
}
