using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Infrastructure.Repository.Contracts
{
    public interface IPolicyRepository<T> : IRepository<T>
    {
        List<T> GetPoliciesByUserName(string name);
    }
}
