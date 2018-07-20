using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ExamenVueling.Application.Services.Contracts;
using ExamenVueling.Application.Services;
using ExamenVueling.Application.DTO;
using System.Web.Http.Description;

namespace ExamenVueling.Facade.WebApi.Controllers
{
    public class PolicyController : ApiController
    {
        public readonly IPolicyService<PolicyDTO> iService;
        public PolicyController() : this(new PolicyService()) { }
        public PolicyController(PolicyService pService)
        {
            this.iService = pService;
        }

        // POST: api/Policy
        [HttpPost]
        [ResponseType(typeof(PolicyDTO))]
        public IHttpActionResult Post([FromBody]List<PolicyDTO> data)
        {
            data = PolicyHttpApiController.GetCall().Result;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                List<PolicyDTO> clientsInserted =
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