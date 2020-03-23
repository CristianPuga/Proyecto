using GestampPrueba2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GestmapPrueba2.Test
{
  public class AuthControllerTest
    {
        HttpClient client;

        public AuthControllerTest()
        {
            this.client = new HttpClient();

        }

        [Fact]
        public async Task TestAuthorized_WhenCalled_WithCorrectUser()
        {
            var data = JsonConvert.SerializeObject(new
            {
                nombreUsuario = "pugaman",
                contrasena = "1234"
            });

            Console.WriteLine(data.Length);


            HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/token", new StringContent(data.ToString(), Encoding.UTF8, "application/json"));

            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);
            // Act
            var result = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<Prueba>(result);
            Assert.NotNull(user.Token);

        }


        [Fact]
        public async Task TestUnAuthorized_WhenCalled_WithIncorrectUser()
        {

            var data = JsonConvert.SerializeObject(new
            {
                nombreUsuario = "pepitos",
                contrasena = "1234"
            });


            HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/token", new StringContent(data.ToString(), Encoding.UTF8, "application/json"));
            // Act

            Assert.Equal((int)HttpStatusCode.NotFound, (int)response.StatusCode);
        }
  }
}
