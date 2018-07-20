using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Contracts
{
    public interface IPolicyService<T> : IAddService<T>
    {
        List<T> GetPoliciesByUserName(string name);
        //List<T> GetAll();
    }
}
