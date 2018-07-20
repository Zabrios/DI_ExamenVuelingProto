using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenVueling.Application.Services.Contracts;
using ExamenVueling.Application.DTO;
using AutoMapper;
using ExamenVueling.Common.Layer;
using ExamenVueling.Domain.Entities;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Infrastructure.Repository.Repository;

namespace ExamenVueling.Application.Services
{
    public class ClientService : IClientService<ClientDTO>
    {
        private readonly IClientRepository<ClientEntity> clientRepository;
        private static IMapper mapper;
        public ClientService() : this(new ClientRepository()) { }

        public ClientService(ClientRepository cRepository)
        {
            this.clientRepository = cRepository;
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<ClientDTO, ClientEntity>());
            mapper = config.CreateMapper();
        }

        public List<ClientDTO> Add(List<ClientDTO> model)
        {
            try
            {
                List<ClientEntity> clientsEntity = mapper.Map<List<ClientDTO>, List<ClientEntity>>(model);
                clientRepository.Add(clientsEntity);
            }
            catch (VuelingException ex)
            {
                throw ex;
            }

            return model;
        }

        public ClientDTO GetById(Guid id)
        {
            try
            {
                var clientRepo = clientRepository.GetById(id);
                return new ClientDTO
                {
                    Id = clientRepo.Id,
                    Name = clientRepo.Name,
                    Email = clientRepo.Email,
                    Role = clientRepo.Role
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ClientDTO GetByName(string name)
        {
            try
            {
                var clientRepo = clientRepository.GetByName(name);
                return new ClientDTO
                {
                    Id = clientRepo.Id,
                    Name = clientRepo.Name,
                    Email = clientRepo.Email,
                    Role = clientRepo.Role
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ClientDTO GetUserByPolicyNumber(Guid policyNumber)
        {
            throw new NotImplementedException();
        }
    }
}
