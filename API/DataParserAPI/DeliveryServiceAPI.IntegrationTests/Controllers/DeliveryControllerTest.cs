using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Services.Tests.Intefaces;

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

        [Test]
        public async Task SendOrder_FreeCourierAvailable_ShouldReturnNotFound()
        {
            //Arrange

            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var orderService = services.SingleOrDefault(d => d.ServiceType == typeof(IOrderService));

                    services.Remove(orderService);

                    var mockService = new Mock<IOrderService>();
                    mockService.Setup(_ => _.IsFreeCourierAvailable()).Returns(() => false);
                    services.AddTransient(_=> mockService.Object);//подмена сервиса
                });
            });
            HttpClient httpClient = webHost.CreateClient();

            //Act

            HttpResponseMessage responce = await httpClient.PostAsync("api/delivery/send-order", null);

            //Assert

            Assert.AreEqual(HttpStatusCode.NotFound, responce.StatusCode);
        }
    }
}
