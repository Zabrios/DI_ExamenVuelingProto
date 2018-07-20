using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Domain.Entities;
using ExamenVueling.Common.Layer;
using Newtonsoft.Json;

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
            try
            {
                //var guidTest = Guid.Parse(id.ToString());
                //string email = "thelmablankenship@quotezart.com";
                var jsonData = fManager.RetrieveData();
                var clientList = JsonConvert.DeserializeObject<List<ClientEntity>>(jsonData);
                var clientSelected = clientList.Select(list => list).First(cl => cl.Id == id);

                //var clientSelected = clientList.Select(list => list).First(cl => cl.Id == id);
                return clientSelected;
                //throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new VuelingException("placeholder", ex);
            }
        }

        public ClientEntity GetByName(string name)
        {
            try
            {
                var jsonData = fManager.RetrieveData();
                var clientList = JsonConvert.DeserializeObject<List<ClientEntity>>(jsonData);
                var clientSelected = clientList.Select(list => list).First(cl => cl.Name == name);
                return clientSelected;
            }
            catch (Exception ex)
            {
                throw new VuelingException("placeholder", ex);
            }
        }

        public ClientEntity GetUserByPolicyNumber(Guid policyNumber)
        {
            throw new NotImplementedException();
        }
    }
}
