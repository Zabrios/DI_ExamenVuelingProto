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
            IEnumerable<ClientDTO> clientsFullList = new List<ClientDTO>();
            ClientListDTO clientsListJson = null;
            try
            {
                HttpResponseMessage response = client.GetAsync("/v2/5808862710000087232b75ac").Result;
                if (response.IsSuccessStatusCode)
                {
                    var clientJsonString = await response.Content.ReadAsStringAsync();
                    clientsListJson = JsonConvert.DeserializeObject<ClientListDTO>(clientJsonString);
                    clientsFullList = clientsListJson.clients;
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
            return clientsFullList.ToList();
        }
    }
}
