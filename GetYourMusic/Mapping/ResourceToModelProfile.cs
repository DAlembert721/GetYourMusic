using AutoMapper;
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Models.UserProfileSystem;
using GetYourMusic.Resources;
using GetYourMusic.Resources.ContractSaveResources;
using GetYourMusic.Test;

namespace GetYourMusic.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveSearchResource, Search>();
            CreateMap<SaveMusicianResource, Musician>();
            CreateMap<SaveOrganizerResource, Organizer>();
            CreateMap<SaveContractResource, Contract>();
            CreateMap<SaveAccountResource, AccountFactory>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveMusicianResource, MusicianResource>();
            CreateMap<SaveOrganizerResource, OrganizerResource>();
            CreateMap<SavePublicationResource, Publication>();
            CreateMap<SaveCommentResource, Comment>();
            CreateMap<SaveQualificationResource, Qualification>();
        }
    }
}
