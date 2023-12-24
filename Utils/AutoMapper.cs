using AutoMapper;

namespace TechroseDemo
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserModel, UserModelDto>();
        }
    }
}
