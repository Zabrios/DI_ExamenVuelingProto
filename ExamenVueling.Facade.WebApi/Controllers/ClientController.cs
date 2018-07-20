using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExamenVueling.Application.Services.Contracts;
using ExamenVueling.Application.Services;
using ExamenVueling.Application.DTO;
using System.Web.Http.Description;

namespace ExamenVueling.Facade.WebApi.Controllers
{
    public class ClientController : ApiController
    {
        public readonly IClientService<ClientDTO> iService;
        public ClientController() : this(new ClientService()) { }
        public ClientController(ClientService clientService)
        {
            this.iService = clientService;
        }
        // GET: api/Client
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Client/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Client
        [HttpPost]
        [ResponseType(typeof(ClientDTO))]
        public IHttpActionResult Post([FromBody]List<ClientDTO> data)
        {
            data = ClientHttpApiController.GetCall().Result;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                List<ClientDTO> clientsInserted =
                        iService.Add(data);
            }
            catch (Exception)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi",
                    new { id = data.First().Id }, data);
        }

        // PUT: api/Client/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
        }
    }
}
