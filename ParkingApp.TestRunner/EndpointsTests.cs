using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ParkingApp.Tests
{
    [TestFixture]
    public class EndpointsTests
    {
        int x = 999;
        int y = 999;
        RestClient _client;
        RestRequest _request;
        string baseUrl;
        string itemUrl;

        [SetUp]
        public void SetUp()
        {
            //var enumerableConfig = AppConfig.GetNetCoreConfig().AsEnumerable();
            //var enumerator = enumerableConfig.GetEnumerator();

            //baseUrl = enumerator.Current.Value;
            //enumerator.MoveNext();
            //itemUrl = enumerator.Current.Value;

            baseUrl = AppConfig.GetNetCoreConfig().GetConnectionString("base");
            itemUrl = AppConfig.GetNetCoreConfig().GetConnectionString("item");

        }
        [Test]
        public void Delete_EndpointReturnsOkWhenCalledByCoordinates()
        {
            // Arrange
            StatusAfterCreateAndPostSlot();                             //*********************** PLUS JEDEN
            // Act
            var response = StatusAfterDeleteSlot();                     //*********************** MINUS JEDEN

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response);
        }
        [Test]
        public void Delete_AfterCallingSecondCallReturnsNotFound()
        {
            // Arrange
            StatusAfterCreateAndPostSlot();                             //*********************** PLUS JEDEN
            // Act
            StatusAfterDeleteSlot();                                    //*********************** MINUS JEDEN
            var response = StatusAfterDeleteSlot();                     //*********************** MINUS JEDEN


            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response);
        }

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

        [Test]
        public void Patch_EndpointReturnsOkWhencalled()
        {
            // Arrange
            StatusAfterCreateAndPostSlot();                             //*********************** PLUS JEDEN
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
            StatusAfterDeleteSlot();                                    //*********************** MINUS JEDEN

            // Act
            var response = StatusAfterCreateAndPostSlot();              //*********************** PLUS JEDEN
            StatusAfterDeleteSlot();                                    //*********************** MINUS JEDEN

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response);
        }

        [Test]
        public void Post_EndpointReturnsBadRequestAtActionWhenOccupiedCoordinatesSelected()
        {
            // Arrange

            // Act
            var response = StatusAfterCreateAndPostSlot();              //*********************** PLUS JEDEN
            StatusAfterDeleteSlot();                                    //*********************** MINUS JEDEN

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response);
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