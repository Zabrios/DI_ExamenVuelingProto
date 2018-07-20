using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Infrastructure.Repository.Contracts
{
    public interface IClientRepository<T> : IRepository<T>
    {
        //List<T> GetAll();
        T GetById(Guid id);
        T GetByName(string name);
        T GetUserByPolicyNumber(Guid policyNumber);
    }
}
