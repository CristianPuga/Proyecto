﻿using GestampPrueba2.Controllers;
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
        IPersonasRepository _service;
        //private readonly Mock<PersonasServiceFake> _mockRepo;
        HttpClient client;
        public PersonasControllerTest()
        {
           // _mockRepo = new Mock<PersonasServiceFake>();
            _service = new PersonasServiceFake();
            _controller = new Personas3Controller(_service);
            client = new HttpClient();
        }

       [Fact]
        public void GetById_WhenCalled_WithCorrectId()
        {
            // Act
            var id = 3;

            var okResult = _controller.GetPersonas3(id);

            // Assert
            Assert.Equal(id, okResult.Id);
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
        public async Task GetPersona_HigherThan()
        {
           
            HttpResponseMessage response = await ExecuteHttpGetPersonas();
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
        }


        [Fact]
        public async Task GetUsuariosId_WhenCalled_CorrectID()
        {
            int id = 1;

            HttpResponseMessage response = await ExecuteHttpGetPersonasById(id);
            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<Personas3>(result);
            Assert.Equal(1, user.Id);
        }


        private async Task<HttpResponseMessage> ExecuteHttpGetPersonas()
        {
            string token = await GetToken();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5000/personas");
            return response;
        }

        private async Task<HttpResponseMessage> ExecuteHttpGetPersonasById(int id)
        {
            string token = await GetToken();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync($"http://localhost:5000/personas/{id}");
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
