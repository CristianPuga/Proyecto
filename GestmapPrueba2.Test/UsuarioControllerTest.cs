using AutoMapper;
using GestampPrueba.Application;
using GestampPrueba.Application.DTOs;
using GestampPrueba2.Controllers;
using GestampPrueba2.Models;
using Microsoft.AspNetCore.Mvc;
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
   public class UsuarioControllerTest
    {
        HttpClient client;
        Usuarios2Controller _controller;
        IUsuariosService _service;
        private readonly IMapper _mapper;
        public UsuarioControllerTest()
        {
            _mapper = Setup.MapperConfig();
            _service = new UsuariosServiceFake(_mapper);
            _controller = new Usuarios2Controller(_service);
            client = new HttpClient();
        }

        [Fact]
        public void Remove_NotExistingID_ReturnsNotFoundResponse()
        {
            // Arrange
            var id = 112;

            // Act
            var badResponse = _controller.DeleteUsuarios2(id);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void GetById_WhenCalled_WithCorrectId()
        {
            // Act
            int id = 3;

            var okResult = _controller.GetUsuarios2(id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Remove_WhenCalled_WithCorrectId()
        {
            // Act
            int id = 1;

            // Act
            var okResponse = _controller.DeleteUsuarios2(id);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetUsuarios2();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetUsuarios2().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<UsuariosDTO>>(okResult.Value);
            Assert.Equal(4, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            int id = 10;
            // Act
            var notFoundResult = _controller.GetUsuarios2(id);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            int id = 1;

            // Act
            var okResult = _controller.GetUsuarios2(id).Result as OkObjectResult;

            // Assert
            Assert.IsType<UsuariosDetailsDTO>(okResult.Value);
            Assert.Equal(id, (okResult.Value as UsuariosDetailsDTO).Id);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            UsuariosPostDTO nameMissingItem = new UsuariosPostDTO()
            {
                Id = 1,
                NombreUsuario = "Guinness Original 6 Pack",
                Contrasena = "hola",
            };
            _controller.ModelState.AddModelError("Email", "Required");

            // Act
            var badResponse = _controller.PostUsuario(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            UsuariosPostDTO testItem = new UsuariosPostDTO()
            {
                Id = 5,
                NombreUsuario = "Guinness Original 6 Pack",
                Contrasena = "hola",
                Email = "hola@gmail.com",
                Img = "hola",
                Activo = true

            };

            // Act
            var createdResponse = _controller.PostUsuario(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var id = 1;

            // Act
            var okResponse = _controller.DeleteUsuarios2(id);

            // Assert
            Assert.Equal(3, _service.GetAll().Count());
        }

        [Fact]
        public void Check_Get_Number_In_Age()
        {
            int id = 3;
            var email = "David@gmail.com";

            var okResult = _controller.GetUsuarios2(id).Result as ObjectResult;
            Assert.IsType<UsuariosDetailsDTO>(okResult.Value);
            Assert.Equal(email, (okResult.Value as UsuariosDetailsDTO).Email);
        }












        [Fact]
        public async void GetUsuarios_WhenCalled_WithOut_Token()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:5000/usuarios");
            Assert.Equal((int)HttpStatusCode.Unauthorized, (int)response.StatusCode);

        }

        [Fact]
        public async Task GetNotFound_WhenCalled_IncorrectUser()
        {
            var data = JsonConvert.SerializeObject(new
            {
                nombreUsuario = "pugaman123",
                contrasena = "1234"
            });
            Console.WriteLine(data);
            HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/token", new StringContent(data.ToString(), Encoding.UTF8, "application/json"));
            Assert.Equal((int)HttpStatusCode.NotFound, (int)response.StatusCode);
        }


       [Fact]
        public async Task GetUsuariosId_WhenCalled_CorrectUser()
        {
            int id = 1;

            HttpResponseMessage response = await ExecuteHttpGetUsuarios(id);
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<Prueba>(result);
            Assert.Equal(1, user.Id);

        }

        [Fact]
        public async Task GetAllUsuarios_WhenCalled_With_Token()
        {
            string token = await GetToken();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5000/usuarios");
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
        }

        private async Task<HttpResponseMessage> ExecuteHttpGetUsuarios(int id)
        {
            string token = await GetToken();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5000/usuarios/{id}");
            return response;
        }

        [Fact]
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
