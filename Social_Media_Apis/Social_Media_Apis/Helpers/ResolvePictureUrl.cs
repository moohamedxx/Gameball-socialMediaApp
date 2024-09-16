using AutoMapper;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Social_Media_Apis.Dtos;

namespace Social_Media_Apis.Helpers
{
    public class ResolvePictureUrl : IValueResolver<PostEntity, PostDto, string>
    {
        private readonly IConfiguration configuration;

        public ResolvePictureUrl(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(PostEntity source, PostDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{configuration["BaseUrl"]}{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
