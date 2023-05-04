using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //  CreateMap<UserDTO, UserDomain>().ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName)).ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, AddRegionRequestDto>().ReverseMap();
            CreateMap<Region, UpdateRegionRequestDto>().ReverseMap();
            CreateMap<AddWalkRequestDto,Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty,DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
            

        }

    }

    //public class UserDTO
    //{
    //    public string FullName{ get; set; }
    //}

    //public class UserDomain
    //{
    //    public string Name { get; set; }
    //}
}
