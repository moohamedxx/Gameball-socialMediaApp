using AutoMapper;
using Core.Entities;
using Social_Media_Apis.Dtos;

namespace Social_Media_Apis.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PostEntity, PostDto>()
                .ForMember(p => p.UserName, o => o.MapFrom(p => p.User.Name))
                .ForMember(p => p.PictureUrl, o => o.MapFrom<ResolvePictureUrl>());
            CreateMap<UserEntity, UserDto>().ForMember(p => p.ProfilePicture, o => o.MapFrom<ResolveUserPicture>());

        }
    }
}
