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
    public class PolicyHttpApiController
    {
        static HttpClient client;
        static PolicyHttpApiController()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://www.mocky.io")
            };
        }

        public static async Task<List<PolicyDTO>> GetCall()
        {
            IEnumerable<PolicyDTO> policiesFullList = new List<PolicyDTO>();
            PolicyListDTO policiesListJson = null;
            try
            {
                HttpResponseMessage response = client.GetAsync("/v2/580891a4100000e8242b75c5").Result;
                if (response.IsSuccessStatusCode)
                {
                    var policyJsonString = await response.Content.ReadAsStringAsync();
                    policiesListJson = JsonConvert.DeserializeObject<PolicyListDTO>(policyJsonString);
                    policiesFullList = policiesListJson.Policies;
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
            return policiesFullList.ToList();
        }
    }
}
