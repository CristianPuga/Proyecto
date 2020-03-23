using GestampPrueba2.Models;
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
   public class UsuarioControllerTest
    {
        HttpClient client;

        public UsuarioControllerTest()
        {
            client = new HttpClient();
        }

        [Fact]
        public async Task GetUnauthorized_WhenCalled_WithoutToken()
        {
            var data = JsonConvert.SerializeObject(new
            {
                nombreUsuario = "pugaman1212",
                contrasena = "1234"
            });
            Console.WriteLine(data);
            HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/token", new StringContent(data.ToString(), Encoding.UTF8, "application/json"));
            Assert.Equal((int)HttpStatusCode.NotFound, (int)response.StatusCode);
        }
/*
        private async Task<HttpResponseMessage> ExecuteHttpGetUser(string data)
        {
            string token = await GetToken();
            Console.WriteLine("UsuarioController");
            Console.WriteLine(data);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5000/usuarios");
            return response;
        }

        private async Task<string> GetToken()
        {
            Console.WriteLine("Metodo getToken");
            var data = JsonConvert.SerializeObject(new
            {
                nombreUsuario = "Puga",
                contrasena = "12345678"
            });


            HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/token", new StringContent(data.ToString(), Encoding.UTF8, "application/json"));

            // Act
            var result = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<Usuarios2>(result);
            return result;
        }*/
    }
}
