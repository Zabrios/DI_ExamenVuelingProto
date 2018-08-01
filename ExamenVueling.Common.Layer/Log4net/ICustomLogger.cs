using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Common.Layer.Log4net
{
    public interface ICustomLogger
    {
        void Debug(Object message);
        void Error(Object message);
    }
}
