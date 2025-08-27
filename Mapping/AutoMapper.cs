using AutoMapper;
using TaskManger.DTOs;
using TaskManger.Models;
using static TaskManger.Models.@enum;

namespace TaskManger.Mapping
{
    public class AutoMapper: Profile
    {
        public AutoMapper() 
        {
            CreateMap<CreateTask, Items>()
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (Priority)src.Priority));

            CreateMap<UpdateTask, Items>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Items, ReadTask>()
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (int)src.Priority));
        }
    }
}
