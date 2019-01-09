using System.Threading.Tasks;

namespace ApiMocker.Repositories
{
    public interface IFileRepository
    {
        Task<string> GetFileContent(string fullFilePath);
    }
}