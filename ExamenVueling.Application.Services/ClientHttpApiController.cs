using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExamenVueling.Application.DTO;
using Newtonsoft.Json;

namespace ExamenVueling.Application.Services
{
    public static class ClientHttpApiController
    {
        static HttpClient client;
        static ClientHttpApiController()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://www.mocky.io")
            };
        }

        public static async Task<List<ClientDTO>> GetCall()
        {
            IEnumerable<ClientDTO> listaClientes = new List<ClientDTO>();
            ClientListDTO client_test = null;
            try
            {
                HttpResponseMessage response = client.GetAsync("/v2/5808862710000087232b75ac").Result;
                if (response.IsSuccessStatusCode)
                {
                    var clientJsonString = await response.Content.ReadAsStringAsync();
                    client_test = JsonConvert.DeserializeObject<ClientListDTO>(clientJsonString);
                    listaClientes = client_test.clients;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //catch (ArgumentNullException ex)
            //{
            //    throw new VuelingException(Resources.ArgumentNull, ex);
            //}
            //catch (HttpRequestException ex)
            //{
            //    throw new VuelingException(Resources.HttpReq, ex);
            //}
            return listaClientes.ToList();
        }
    }
}
