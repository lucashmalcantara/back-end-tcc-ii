﻿using AutoMapper;
using Sapfi.Api.V1.Application.Models.Company.Get;
using Sapfi.Api.V1.Application.Models.Line.Get;
using Sapfi.Api.V1.Application.Models.LineState.Post;
using Sapfi.Api.V1.Application.Models.Ticket.Get;
using Sapfi.Api.V1.Application.Models.TicketFollowUp.Post;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Models.LineState.Update;
using Sapfi.Api.V1.Domain.Models.TicketFollowUp.Create;

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
            CreateMap<Ticket, GetTicketModel>();
            CreateMap<Company, GetCompanyModel>();
            CreateMap<Address, GetCompanyAddressModel>();
            CreateMap<PostTicketFollowUpModel, TicketFollowUpModel>();
        }
    }
}
