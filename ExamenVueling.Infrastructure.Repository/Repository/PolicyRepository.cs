using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Domain.Entities;

namespace ExamenVueling.Infrastructure.Repository.Repository
{
    public class PolicyRepository : IRepository<PolicyEntity>, IPolicyRepository<PolicyEntity>
    {
        public List<PolicyEntity> Add(List<PolicyEntity> model)
        {
            throw new NotImplementedException();
        }

        public List<PolicyEntity> GetPoliciesByUserName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
