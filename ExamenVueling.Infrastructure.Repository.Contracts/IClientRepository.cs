using ExamenVueling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Infrastructure.Repository.Contracts
{
    public interface IClientRepository : IRepository<ClientEntity>
    {
        //List<T> GetAll();
        ClientEntity GetById(Guid id);
        ClientEntity GetByName(string name);
        ClientEntity GetUserByPolicyNumber(Guid policyNumber);
    }
}
