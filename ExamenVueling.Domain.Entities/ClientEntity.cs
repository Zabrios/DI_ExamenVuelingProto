using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Domain.Entities
{
    public class ClientEntity : IComparer<ClientEntity>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public int Compare(ClientEntity x, ClientEntity y)
        {
            // TODO: Handle x or y being null, or them not having names
            return x.Id.CompareTo(y.Id);
        }
    }
}
