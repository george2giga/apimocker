using System.Collections.Generic;

namespace ApiMocker.Entities
{
    public interface IServiceMock
    {
        string Name { get; set; }
        string Url { get; set; }
        string Verb { get; set; }
        int HttpStatus { get; set; }
        string ContentType { get; set; }
        string MockFile { get; set; }
        string Content { get; set; }
        Dictionary<string, string> Headers { get; set; }
    }
}