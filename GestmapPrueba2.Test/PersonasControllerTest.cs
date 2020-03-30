using GestampPrueba.Application.Services;
using GestampPrueba2.Controllers;
using GestampPrueba2.Infrastructure;
using GestampPrueba2.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GestmapPrueba2.Test
{
   public class PersonasControllerTest
    {
        Personas3Controller _controller;
        IPersonasService _service;
        HttpClient client;
        public PersonasControllerTest()
        {
            _service = new PersonasServiceFake();
            _controller = new Personas3Controller(_service);
            client = new HttpClient();
        }

       [Fact]
        public void GetById_WhenCalled_WithCorrectId()
        {
            // Act
            int id = 3;

            var okResult = _controller.GetPersonas3(id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Remove_WhenCalled_WithCorrectId()
        {
            // Act
            int id = 1;

            // Act
            var okResponse = _controller.DeletePersonas3(id);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetPersonas3();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetPersonas3().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Personas3>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            int id = 10;
            // Act
            var notFoundResult = _controller.GetPersonas3(id);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            int id = 1;

            // Act
            var okResult = _controller.GetPersonas3(id).Result as OkObjectResult;

            // Assert
            Assert.IsType<Personas3>(okResult.Value);
            Assert.Equal(id, (okResult.Value as Personas3).Id);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Personas3()
            {
                Nombre = "Guinness Original 6 Pack",
                Apellido = "Guinness",
                Edad = 15
            };
            _controller.ModelState.AddModelError("Nombre", "Required");

            // Act
            var badResponse = _controller.PostPersonas3(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Personas3 testItem = new Personas3()
            {
               // Nombre = "Guinness Original 6 Pack",
                Apellido = "Guinness",
                Edad = 15
            };

            // Act
            var createdResponse = _controller.PostPersonas3(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        public async Task<string> GetToken()
        {
            var data = JsonConvert.SerializeObject(new
            {
                nombreUsuario = "pugaman",
                contrasena = "1234"
            });

            HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/token", new StringContent(data, Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<Prueba>(result);
            return user.Token;
        }
    }
}
