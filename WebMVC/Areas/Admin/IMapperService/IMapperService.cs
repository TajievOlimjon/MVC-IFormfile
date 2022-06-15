using AutoMapper;
using WebMVC.Areas.Admin.ModelDTO;
using WebMVC.Areas.Admin.Models;

namespace WebMVC.Areas.Admin.IMapperService
{
    public class IMapperService:Profile
    {
        public IMapperService()
        {
            CreateMap<TeacherDTO, Teacher>();
        }
    }
}
