using AutoMapper;
using Domain.Entities.TodoList;
using WebApi.Dto;

namespace WebApi.Mappings
{
    public class WebApiMappings : Profile
    {
        public WebApiMappings()
        {
            CreateMap<TodoListEntity, TodoListBriefDto>()
                .ForMember(x => x.Id, x => x.MapFrom(e => e.Id))
                .ForMember(x => x.Title, x => x.MapFrom(e => e.Title));
        }
    }
}
