using AutoMapper;

namespace TechroseDemo
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserModel, UserModelDto>();
            CreateMap<UserNutritionBaseModel, UserNutritionModel>()
                .ForMember(dest => dest.Portion, opt =>
                {
                    opt.MapFrom(src => src.Portion.Equals(int.MinValue) || src.Portion.Equals(0) ? 1 : src.Portion);
                });
        }
    }
}
