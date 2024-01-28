using AutoMapper;
using BookStoreAppBlazorServerUI.Services.Base;

namespace BookStoreAppBlazorServerUI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorDetailsDto, AuthorUpdateDto>().ReverseMap();
            //CreateMap<AuthorReadOnlyDto, AuthorUpdateDto>().ReverseMap();
            //CreateMap<AuthorDetailsDto, Author>().ReverseMap();

        }
    }
}
