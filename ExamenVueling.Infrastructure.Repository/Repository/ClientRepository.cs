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
    public class ClientRepository : IClientRepository
    {
        public FileManager fManager;
        //public ClientRepository()
        //{
        //    //this.fManager = new ClientsFileManager();
        //}
        public ClientRepository(FileManager fileManager)
        {
            this.fManager = fileManager;
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
                var jsonData = fManager.RetrieveData();
                var clientList = JsonConvert.DeserializeObject<List<ClientEntity>>(jsonData);
                var clientSelected = clientList.Select(list => list).First(cl => cl.Id == id);
                return clientSelected;
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
            try
            {
                var policyManager = new PolicyRepository();
                var jsonDataPolicies = policyManager.fManager.RetrieveData();
                var policyList = JsonConvert.DeserializeObject<List<PolicyEntity>>(jsonDataPolicies);
                var policySelected = policyList.Select(list => list).First(pl => pl.Id == policyNumber);
                var clientFromPolicy = GetById(policySelected.ClientId);
                return clientFromPolicy;
            }
            catch (Exception ex)
            {
                throw new VuelingException("placeholder", ex);
            }
        }
    }
}
