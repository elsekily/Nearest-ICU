using AutoMapper;
using Hospital.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API
            CreateMap<Entities.Models.Hospital, HospitalResource>()
                .ForMember(hr => hr.AddedBy, opt => opt.MapFrom(h => h.User.UserName));

            //API to Domain
            CreateMap<HospitalSaveResource, Entities.Models.Hospital>()
                .ForMember(h => h.Id, opt => opt.Ignore())
                .ForMember(h => h.User, opt => opt.Ignore());
        }
    }
}
