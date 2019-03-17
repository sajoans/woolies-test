using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WooliesTest.Exercise2;
using Xunit;

namespace WooliesTest.Tests
{
    public class Exercise2FunctionTests
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async void Exercise2Function_should_bad_request_response_for_Invalid_sortOption()
        {
            // Arrange
            var request = TestFactory.CreateHttpRequest("sortOption", "invalidOption");

            // Act
            var response = (BadRequestResult)await Exercise2Function.Run(request, logger);

            // Assert
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void Exercise2Function_should_return_OK_status_for_Valid_sortOption_param()
        {
            // Arrange
            var request = TestFactory.CreateHttpRequest("sortOption", "High");

            // Act
            var response = (OkObjectResult)await Exercise2Function.Run(request, logger);

            // Assert
            Assert.Equal(200, response.StatusCode);
        }
    }
}