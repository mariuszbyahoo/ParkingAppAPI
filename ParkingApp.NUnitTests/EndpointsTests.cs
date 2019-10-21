using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ParkingApp.NUnitTests
{
    public class EndpointsTests
    {
        private WebApplicationFactory<ParkingApp.API.Startup> _factory;
        string baseUrl;
        int x;
        int y;
        HttpClient client;

        [SetUp]
        public void Setup()
        {
            x = 0;
            y = 0;
            this._factory = new WebApplicationFactory<ParkingApp.API.Startup>();
            this.baseUrl = "http://localhost:5000/api/Slots";
            client = _factory.CreateClient();

        }

        [Test]
        public void GetRequestReturnsOkWhenCalled()
        {
            // Arrange
            
            
            // Act

            var response = client.GetAsync(baseUrl);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
        }

        [Test]
        public void Post_EndpointReturnsCreatedAtActionWhenUnoccupiedCoordinatesSelected()
        {
            // Arrange
            var jsonText = generateJsonSlot(x, y);

            // Act
            using (var client = _factory.CreateClient())
            {
                var httpContent = new StringContent(jsonText);
                httpContent.Headers.ContentType =
                    new MediaTypeHeaderValue("application/json");

                var response = client.PostAsync(baseUrl, httpContent);

                // Assert
                Assert.AreEqual(HttpStatusCode.Created, response.Result.StatusCode);
            }
        }

        [Test]
        public void Patch_EndpointReturnsOkWhencalled()
        {
            // Arrange
            HttpStatusCode response;
            var patchUrl = $"{baseUrl}/{x}/{y}";

            // Act
            response = client.PatchAsync(patchUrl, null).Result.StatusCode;
            //client.PatchAsync(url, null);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response);
        }

        [Test]
        public void Delete_EndpointReturnsOkWhenCalledByCoordinates()
        {
            // Arrange
            var deleteUrl = $"{baseUrl}/{x}/{y}";

            // Act
            var response = client.DeleteAsync(deleteUrl);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
        }

        // Helpers below:

        private string generateJsonSlot(int x, int y)
        {
            JObject jObject =
                new JObject(
                    new JProperty("posX", x),
                    new JProperty("posY", y),
                    new JProperty("IsOccupied", false));

            return jObject.ToString();
        }
    }
}