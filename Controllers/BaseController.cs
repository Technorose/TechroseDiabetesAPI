using Microsoft.AspNetCore.Mvc;

namespace TechroseDemo
{
    public partial class BaseController(IRepo p_IRepo, IConfiguration p_Configuration, IGoogleCloudStorage p_GoogleCloudStorage) : ControllerBase
    {
        private readonly IRepo repoInterface = p_IRepo;
        private readonly IConfiguration configuration = p_Configuration;
        private readonly IGoogleCloudStorage googleCloudStorage = p_GoogleCloudStorage;
    }
}
