namespace TechroseDemo
{
    public partial class BaseRepo(ApiDbContext apiDbContext) : IRepo
    {
        private readonly ApiDbContext _apiDbContext = apiDbContext;
    }
}
