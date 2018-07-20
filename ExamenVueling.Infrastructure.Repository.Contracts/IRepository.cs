using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Infrastructure.Repository.Contracts
{
    public interface IRepository<T>
    {
        List<T> Add(List<T> model);
    }
}
