using GestampPrueba.Application.Services;
using GestampPrueba2.Controllers;
using GestampPrueba2.Infrastructure;
using GestampPrueba2.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Remove_NotExistingID_ReturnsNotFoundResponse()
        {
            // Arrange
            var id = 112;

            // Act
            var badResponse = _controller.DeletePersonas3(id);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
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
            Personas3 nameMissingItem = new Personas3()
            {
                Id = 1,
                Nombre = "Guinness Original 6 Pack",
                Apellido = "hola"
            };
            _controller.ModelState.AddModelError("Edad", "Required");

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
                Id = 4,
                Nombre = "Guinness Original 6 Pack",
                Apellido = "hola",
                Edad = 15
                
            };

            // Act
            var createdResponse = _controller.PostPersonas3(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var id = 1;

            // Act
            var okResponse = _controller.DeletePersonas3(id);

            // Assert
            Assert.Equal(2, _service.GetAll().Count());
        }

        [Fact]
        public void Check_Get_Number_In_Age()
        {
            int id = 3;
            int edad = 50;

            var okResult = _controller.GetPersonas3(id).Result as ObjectResult;
            Assert.IsType<Personas3>(okResult.Value);
            Assert.Equal(edad, (okResult.Value as Personas3).Edad);
        }

       /* [Fact]
        public void PutUser_With_Correct_Params()
        {
            int id = 4;

            Personas3 testItem = new Personas3()
            {
                Id = 4,
                Nombre = "Pepito Guacamole",
                Apellido = "hola",
                Edad = 100

            };

            // Act
            var createdResponse = _controller.PutPersonas3(id, testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }*/
    }
}
