using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Contracts
{
    public interface IClientService<T>
    {
        //List<T> GetAll();
        T GetById(Guid id);
        T GetByName(string name);
        T GetUserByPolicyNumber(Guid policyNumber);
    }
}
