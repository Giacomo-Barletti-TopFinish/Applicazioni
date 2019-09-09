using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicazioni.Common
{
    public class BaseService : ServiceBase
    {
        private object _syncRoot = new object();

        private Timer _tmrAsync;
        private bool _isAsync = false;

        protected bool IsAsync
        {
            get
            {
                lock (_syncRoot)
                    return _isAsync;
            }
            set
            {
                lock (_syncRoot)
                    _isAsync = value;
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _tmrAsync = new Timer(new TimerCallback(AsyncOperationCallback), null, 5000, 60 * 1000);
                LogHelper.LogInfo("#### SERVICE AVVIATO ####");
            }
            catch (Exception ex)
            {
                LogHelper.LogError("Errore in OnStart", ex);
            }
        }

        protected override void OnStop()
        {
            LogHelper.LogInfo("#### SERVICE FERMATO ####");
        }
        protected virtual void AsyncOperationCallback(Object stateInfo)
        {
            IsAsync = false;
        }

        public void OnStartAsApplication()
        {
            OnStart(new string[] { });
            Thread.Sleep(Timeout.Infinite);
        }
    }

    public class LogHelper
    {
        private static readonly ILog _log = LogManager.GetLogger((typeof(BaseService)));

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
