using AutoMapper;

namespace TechroseDemo
{
    public partial class BaseRepo(ApiDbContext apiDbContext, IMapper mapper, IGoogleCloudStorage p_googleCloudStorage) : IRepo
    {
        private readonly ApiDbContext DatabaseContext = apiDbContext;
        private readonly IMapper Mapper = mapper;
        private readonly IGoogleCloudStorage googleCloudStorage = p_googleCloudStorage;
    }
}
