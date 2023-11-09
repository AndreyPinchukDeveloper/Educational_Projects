using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceAPI.IntegrationTests.Controllers
{
    [TestFixture]
    public class DeliveryControllerTest
    {
        [Test]
        public async Task CheckStatus_SendRequest_ShouldReturnOk()
        {
            //Arrange

            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
            HttpClient httpClient = webHost.CreateClient();

            //Act

            HttpResponseMessage responce = await httpClient.GetAsync("api/delivery/check-status");

            //Assert

            Assert.AreEqual(HttpStatusCode.OK, responce.StatusCode);
        }
    }
}
