using System.Threading.Tasks;
using ApiMocker.Entities;

namespace ApiMocker.Repositories
{
    public interface IApiMockerConfigRepository
    {
        Task<ApplicationSettings> Get(ApplicationSettings applicationSettings);
    }
}