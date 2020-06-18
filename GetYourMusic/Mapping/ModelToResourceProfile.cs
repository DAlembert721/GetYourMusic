using AutoMapper;
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Resources;
using GetYourMusic.Extensions;
using GetYourMusic.Domain.Models.UserProfileSystem;
using GetYourMusic.Domain.Models.Locations;
using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Resources.ContractResources;

namespace GetYourMusic.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {

            CreateMap<Search, SearchResource>();
            CreateMap<Musician, MusicianResource>()
                .ForMember(src => src.District,
                opt => opt.MapFrom(src => src.District.Name));
            CreateMap<Musician, MusicianResource>()
                .ForMember(src => src.Age,
                opt => opt.MapFrom(src => src.BirthDate.GetAgeByBirthDate()));
            CreateMap<Organizer, OrganizerResource>()
                .ForMember(src => src.District,
                opt => opt.MapFrom(src => src.District.Name));
            CreateMap<Organizer, OrganizerResource>()
                .ForMember(src => src.Age,
                opt => opt.MapFrom(src => src.BirthDate.GetAgeByBirthDate()));

            CreateMap<Contract, BaseContractResourse>()
                .ForMember(src => src.State,
                opt => opt.MapFrom(src => src.ContractState.Description));

            CreateMap<Contract, MusiciansContractResource>()
                .ForMember(src => src.State,
                opt => opt.MapFrom(src => src.ContractState.Description));

            CreateMap<Contract, OrganizersContractResource>()
                .ForMember(src => src.State,
                opt => opt.MapFrom(src => src.ContractState.Description));
            CreateMap<Genre, GenreResource>();
            CreateMap<Instrument, InstrumentResource>();
            CreateMap<Region, RegionResource>();
            CreateMap<City, CityResource>()
                .ForMember(src => src.Region,
                opt => opt.MapFrom(src => src.Region.Name));
            CreateMap<District, DistrictResource>()
                .ForMember(src => src.City,
                opt => opt.MapFrom(src => src.City.Name));
            CreateMap<Account, AccountResource>()
                .ForMember(src => src.District,
                opt => opt.MapFrom(src => src.District.Name)); ;
            CreateMap<User, UserResource>();
            CreateMap<Publication, PublicationResource>();
            CreateMap<Comment, CommentResource>();
            CreateMap<Qualification, QualificationResource>()
                .ForMember(src => src.Musician,
                opt => opt.MapFrom(src => src.Musician.FirstName))
                .ForMember(src => src.Organizer,
                opt => opt.MapFrom(src => src.Organizer.FirstName))
                .ForMember(src => src.Contract,
                opt => opt.MapFrom(src => src.Contract.Name));
        }
    }
}
