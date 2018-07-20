using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Domain.Entities;
using ExamenVueling.Common.Layer;

namespace ExamenVueling.Infrastructure.Repository.Repository
{
    public class ClientRepository : IRepository<ClientEntity>, IClientRepository<ClientEntity>
    {
        private FileManager fManager;
        public ClientRepository()
        {
            this.fManager = new ClientsFileManager();
        }
        public List<ClientEntity> Add(List<ClientEntity> model)
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
