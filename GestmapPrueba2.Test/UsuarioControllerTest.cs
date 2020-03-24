using GestampPrueba2.Models;
using Newtonsoft.Json;
using System;
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
            HttpResponseMessage response = await client.GetAsync("http://localhost:5000/usuarios");
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
