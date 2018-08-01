using System;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ExamenVueling.Common.Layer.Log4net
{
    public class LogAdapter : ICustomLogger
    {
        private readonly ILog log;

        public LogAdapter()
        {
            this.log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Debug(object message)
        {
            this.log.Debug(message);
        }

        public void Error(object message)
        {
            this.log.Error(message);
        }
    }
}
