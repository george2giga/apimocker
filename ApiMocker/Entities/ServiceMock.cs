using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMocker.Entities
{
    public class ServiceMock
    {
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Verb { get; set; }
        [Required]
        public int HttpStatus { get; set; }
        [Required]
        public string ContentType { get; set; }
        public string Content { get; set; }
        public Dictionary<string,string> Headers { get; set; }
    }
}
