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
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Client/5
        [HttpGet]
        [Route("api/Client/GetById/{id}")]
        public IHttpActionResult GetById(string id)
        {
            ClientDTO clientReturned = null;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                clientReturned = iService.GetById(Guid.Parse(id));
                return Ok(clientReturned);
                //return CreatedAtRoute("DefaultApi",
                //    new { id = clientReturned.Id }, clientReturned);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return Request.CreateResponse(HttpStatusCode.OK, clientReturned);
            //return null;
        }

        // GET: api/Client/5
        [HttpGet]
        [Route("api/Client/GetByName/{name}")]
        public IHttpActionResult GetByName(string name)
        {
            ClientDTO clientReturned = null;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                clientReturned = iService.GetByName(name);
                return Ok(clientReturned);
                //return CreatedAtRoute("DefaultApi",
                //    new { id = clientReturned.Id }, clientReturned);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return Request.CreateResponse(HttpStatusCode.OK, clientReturned);
            //return null;
        }

        // GET: api/Client/5
        [HttpGet]
        [Route("api/Client/GetByPolicy/{policyNumber}")]
        public IHttpActionResult GetByPolicy(Guid policyNumber)
        {
            ClientDTO clientReturned = null;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                clientReturned = iService.GetUserByPolicyNumber(policyNumber);
                return Ok(clientReturned);
                //return CreatedAtRoute("DefaultApi",
                //    new { id = clientReturned.Id }, clientReturned);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return Request.CreateResponse(HttpStatusCode.OK, clientReturned);
            //return null;
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
    }
}
