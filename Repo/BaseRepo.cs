using AutoMapper;

namespace TechroseDemo
{
    public partial class BaseRepo(ApiDbContext apiDbContext, IMapper mapper) : IRepo
    {
        private readonly ApiDbContext DatabaseContext = apiDbContext;
        private readonly IMapper Mapper = mapper;
    }
}
