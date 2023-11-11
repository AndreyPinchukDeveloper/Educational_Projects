using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Data.Models;
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

            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                    services.Remove(dbContextDescriptor);
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("delivery.db");
                    });
                });
            });

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
                    var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                    services.Remove(dbContextDescriptor);
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("delivery.db");
                    });

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

        /// <summary>
        /// Replace database
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetOrderCount_SendRequest_ShouldReturnCount()
        {
            //Arrange

            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                    services.Remove(dbContextDescriptor);
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("delivery.db");
                    });
                });
            });
            ApplicationDbContext dbContext = webHost.Services.CreateScope().ServiceProvider.GetService<ApplicationDbContext>();
            List<Order> orders = new () { new Order(),  new Order(), new Order() };
            await dbContext.Orders.AddRangeAsync(orders);
            await dbContext.SaveChangesAsync();
            HttpClient httpClient = webHost.CreateClient();
            //Act

            HttpResponseMessage responce = await httpClient.GetAsync("api/delivery/GetOrderCount");

            //Assert

            Assert.AreEqual(HttpStatusCode.OK, responce.StatusCode);
            int ordersCount = int.Parse(await responce.Content.ReadAsStringAsync());
            Assert.AreEqual(orders.Count, ordersCount);

        }
    }
}
