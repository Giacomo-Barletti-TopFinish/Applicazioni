using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrasferimentiService.Helpers
{
    class LogHelper
    {
        private static readonly ILog _log = LogManager.GetLogger((typeof(Program)));

        public static void LogInfo(object message)
        {
            _log.Info(message);
        }

        public static void LogWarning(object message)
        {
            _log.Warn(message);
        }

        public static void LogError(object message)
        {
            _log.Error(message);
        }

        public static void LogError(object message, Exception exception)
        {
            _log.Error(message, exception);
        }
    }
}
