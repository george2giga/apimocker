using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiMocker.Core;
using ApiMocker.Repositories;
using Moq;
using Xunit;

namespace ApiMocker.Tests.Core
{
    public class RequestMockerTests
    {

        private readonly Mock<IFileRepository> _fileRepository;
        private readonly RequestMocker _requestMocker;

        public RequestMockerTests()
        {
            _fileRepository = new Mock<IFileRepository>();
            _requestMocker = new RequestMocker(_fileRepository.Object);
        }

        [Fact]
        public void Is_Match_Should_Return_Url_Using_WildCard()
        {
            var urls = new List<string>()
            {
                "https://stackoverflow.com/questions/22669350/liststring-contains-with-wildcards-c-sharp",
                "https://stackoverflow.com/questions/22669350/ltstring-contains-with-wildcards-c-sharp",
                "https://stackoverflow.com/questions/22669350/woeksfsd",
                "https://google.com/questions/22669350/woeksfsd",
                "https://google.com/sdfsdfsf",
                "https://bing.com/sdfsdfsf"
            };

            var match = "https://stackoverflow.com/questions/*";

            var results = urls.Where(s => _requestMocker.IsMatch(s,match));

            Assert.Equal(3, results.Count()) ;
        }

        [Fact]
        public void Is_Match_Should_Return_Url_Using_WildCard_Short_Url()
        {
            var urls = new List<string>()
            {
                "https://localhost:2345/patient/patient_no/17832",
                "https://google.com/questions/22669350/woeksfsd",
                "https://google.com/sdfsdfsf",
                "https://bing.com/sdfsdfsf"
            };

            var match = "https://localhost:2345/patient/patient_no/*";

            var results = urls.Where(s => _requestMocker.IsMatch(s, match));

            Assert.Equal(1, results.Count());
        }

        [Fact]
        public void Is_Match_Should_Return_Url_With_Multiple_Wildcards()
        {
            //guidelineinstances/d00a2834-3968-4741-a13d-3553984bf1be/?userName=AB%20Application
            var urls = new List<string>()
            {
                "/guidelineinstances/d00a2834-3968-4741-a13d-3553984bf1be/?userName=AB%20Application",
                "/guidelineinstance/d00a2834-3968-4741-a13d-3553984bf1be/?userName=AB%20Application",
            };

            var match = "/guidelineinstances/*/*";

            var results = urls.Where(s => _requestMocker.IsMatch(s, match));

            Assert.Equal(1, results.Count());
        }
    }
}
