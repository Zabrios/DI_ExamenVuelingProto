using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.DTO
{
    public class ClientListDTO
    {
        public IEnumerable<ClientDTO> clients { get; set; }
    }
}
