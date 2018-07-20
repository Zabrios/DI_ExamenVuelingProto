using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Domain.Entities;
using ExamenVueling.Common.Layer;

namespace ExamenVueling.Infrastructure.Repository.Repository
{
    public class PolicyRepository : IPolicyRepository<PolicyEntity>
    {
        public FileManager fManager;
        public PolicyRepository()
        {
            this.fManager = new PoliciesFileManager();
        }
        public List<PolicyEntity> Add(List<PolicyEntity> model)
        {
            try
            {
                return fManager.ProcessData(model);
            }
            catch (Exception ex)
            {
                throw new VuelingException("placeholder", ex);
            }
        }

        public List<PolicyEntity> GetPoliciesByUserName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
