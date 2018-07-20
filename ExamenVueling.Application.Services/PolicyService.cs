using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenVueling.Application.DTO;
using AutoMapper;
using ExamenVueling.Common.Layer;
using ExamenVueling.Domain.Entities;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Infrastructure.Repository.Repository;
using ExamenVueling.Application.Services.Contracts;

namespace ExamenVueling.Application.Services
{
    public class PolicyService : IPolicyService<PolicyDTO>
    {
        private readonly IPolicyRepository<PolicyEntity> policyRepository;
        private static IMapper mapper;
        public PolicyService() : this(new PolicyRepository()) { }
        public PolicyService(PolicyRepository pRepository)
        {
            this.policyRepository = pRepository;
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<PolicyDTO, PolicyEntity>());
            mapper = config.CreateMapper();
        }

        public List<PolicyDTO> Add(List<PolicyDTO> model)
        {
            try
            {
                List<PolicyEntity> policiesEntity = mapper.Map<List<PolicyDTO>, List<PolicyEntity>>(model);
                policyRepository.Add(policiesEntity);
            }
            catch (VuelingException ex)
            {
                throw ex;
            }

            return model;
        }

        public List<PolicyDTO> GetPoliciesByUserName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
