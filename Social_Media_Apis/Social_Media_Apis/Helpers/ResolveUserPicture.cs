using AutoMapper;
using Core.Entities;
using Social_Media_Apis.Dtos;

namespace Social_Media_Apis.Helpers
{
    public class ResolveUserPicture : IValueResolver<UserEntity, UserDto, string>
    {
        private readonly IConfiguration configuration;

        public ResolveUserPicture(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(UserEntity source, UserDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProfilePicture))
            {
                return $"{configuration["BaseUrl"]}{source.ProfilePicture}";
            }
            return string.Empty;
        }
    }
}
