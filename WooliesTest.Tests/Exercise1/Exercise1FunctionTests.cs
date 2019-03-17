using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace WooliesTest.Tests
{
    public class Exercise1FunctionTests
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async void Exercise1Function_should_return_name_and_token()
        {
            // Arrange
            var request = TestFactory.CreateHttpRequest();

            // Act
            var response = (OkObjectResult)await Exercise1Function.Run(request, logger);

            // Assert
            Assert.Equal("{ name = Sajan Suwal, token = b44529c0-0806-4810-b2d6-fa0adc2021d7 }", response.Value.ToString());
        }
    }
}