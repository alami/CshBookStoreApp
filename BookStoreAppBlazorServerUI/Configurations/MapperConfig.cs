using AutoMapper;
using BookStoreAppBlazorServerUI.Services.Base;

namespace BookStoreAppBlazorServerUI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorReadOnlyDto, AuthorUpdateDto>().ReverseMap();

        }
    }
}
