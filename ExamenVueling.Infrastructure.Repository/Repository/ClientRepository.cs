using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Domain.Entities;

namespace ExamenVueling.Infrastructure.Repository.Repository
{
    public class ClientRepository : IRepository<ClientEntity>, IClientRepository<ClientEntity>
    {
        public List<ClientEntity> Add(List<ClientEntity> model)
        {
            throw new NotImplementedException();
        }

        public ClientEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ClientEntity GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public ClientEntity GetUserByPolicyNumber(Guid policyNumber)
        {
            throw new NotImplementedException();
        }
    }
}
