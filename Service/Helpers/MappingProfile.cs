using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Students;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Group
            CreateMap<Group, GroupDTO>().ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.StudentGroups.Count));
            CreateMap<GroupCreateDTO, Group>();
            CreateMap<GroupEditDTO, Group>();

            //Student
            CreateMap<Student, STudentDTO>();/*.ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.StudentGroups));*/
            CreateMap<StudentCreateDTO, Student>();
            CreateMap<StudentEditDTO, Student>();
            CreateMap<StudentGroup, StudentGroupsDTO>().ReverseMap();

        }
    }
}
