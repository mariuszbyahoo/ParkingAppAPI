using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
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
        string itemUrl;
        int x;
        int y;
        RestClient _client;
        RestRequest _request;

        [SetUp]
        public void Setup()
        {
            x = 999;
            y = 999;
            this._factory = new WebApplicationFactory<ParkingApp.API.Startup>();
            this.baseUrl = "http://localhost:5000/api/Slots";
            this.itemUrl = $"http://localhost:5000/api/Slots/{x}/{y}";
        }

        [Test]
        public void Delete_EndpointReturnsOkWhenCalledByCoordinates()
        {
            // Arrange
            var prepare = StatusAfterCreateAndPostSlot();       //*********************** PLUS JEDEN
            // Act
            var response = StatusAfterDeleteSlot();             //*********************** MINUS JEDEN

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response);
        }

        //          DWA DODAJE JEDNO ODEJMUJE RAZEM ZOSTAJE JEDNO

        [Test]
        public void GetRequestReturnsOkWhenCalled()
        {
            // Arrange
            this._client = new RestClient(baseUrl);
            _request = new RestRequest(Method.GET);

            // Act
            var response = _client.Execute(_request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        //          NIC NIE MODYFIKUJE

        [Test]
        public void Patch_EndpointReturnsOkWhencalled()
        {
            // Arrange
            StatusAfterCreateAndPostSlot();     //*********************** PLUS JEDEN
            this._client = new RestClient(itemUrl);
            _request = new RestRequest(Method.PATCH);

            // Act
            var response = _client.Execute(_request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [Test]
        public void Post_EndpointReturnsCreatedAtActionWhenUnoccupiedCoordinatesSelected()
        {
            // Arrange
            StatusAfterDeleteSlot();            //*********************** MINUS JEDEN

            // Act
            var response = StatusAfterCreateAndPostSlot();//*********************** PLUS JEDEN
            StatusAfterDeleteSlot();            //*********************** MINUS JEDEN

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response);
        }

        
        //*******************************************Helpers below:***********************************************************

        private JObject GenerateJObject()
        {
            JObject jObject =
                new JObject(
                    new JProperty("posX", x),
                    new JProperty("posY", y),
                    new JProperty("IsOccupied", false));

            return jObject;
        }

        private HttpStatusCode StatusAfterCreateAndPostSlot()
        {
            _client = new RestClient(baseUrl);
            _request = new RestRequest(Method.POST);
            _request.AddParameter(
                "application/json", GenerateJObject(), 
                ParameterType.RequestBody);

            return _client.Execute(_request).StatusCode;

        }

        private HttpStatusCode StatusAfterDeleteSlot()
        {
            _client = new RestClient(itemUrl);
            _request = new RestRequest(Method.DELETE);
            return _client.Execute(_request).StatusCode;
        }
    }
}