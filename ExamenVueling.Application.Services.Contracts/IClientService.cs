using ExamenVueling.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Contracts
{
    public interface IClientService : IAddService<ClientDTO> /*where T : ClientDTO*/
    {
        //List<T> GetAll();
        ClientDTO GetById(Guid id);
        ClientDTO GetByName(string name);
        ClientDTO GetUserByPolicyNumber(Guid policyNumber);
    }
}
