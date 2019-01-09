using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMocker.Repositories
{
    public class FileRepository : IFileRepository
    {
        public async Task<string> GetFileContent(string fullFilePath)
        {
            string content;
            using (var reader = File.OpenText(fullFilePath))
            {
                content = await reader.ReadToEndAsync();
            }

            return content;
        }
    }
}
