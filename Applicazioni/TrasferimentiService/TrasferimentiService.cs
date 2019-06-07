using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrasferimentiService.Helpers;
using TrasferimentiService.Managers;
using TrasferimentiService.Properties;

namespace TrasferimentiService
{
    public partial class TrasferimentiService : ServiceBase
    {
        private object _syncRoot = new object();

        private Timer _tmrAsync;
        private bool _isAsync = false;

        private bool IsAsync
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
        public TrasferimentiService()
        {
            InitializeComponent();
        }

        private void AsyncOperationCallback(Object stateInfo)
        {
            if (IsAsync)
                return;

            IsAsync = true;
            try
            {
                using (TrasferimentiServiceManager tsm = new TrasferimentiServiceManager())
                {
                    LogHelper.LogInfo("Inizio attivita");
                    tsm.DoIt();
                    LogHelper.LogInfo("Fine attivita");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogError("Errore in AsyncOperationCallback", ex);
            }
            finally
            {
                IsAsync = false;
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                LogHelper.LogInfo("#### TRASFERIMENTI SERVICE IN FASE DI AVVIO ####");
                _tmrAsync = new Timer(new TimerCallback(AsyncOperationCallback), null,5000, Settings.Default.Period * 1000);
                LogHelper.LogInfo("#### TRASFERIMENTI SERVICE AVVIATO ####");
            }
            catch (Exception ex)
            {
                LogHelper.LogError("Errore in OnStart", ex);
            }
        }

        protected override void OnStop()
        {
            LogHelper.LogInfo("#### SPC ASYNC OPERATION SERVICE FERMATO ####");
        }
        internal void OnStartAsApplication()
        {
            OnStart(new string[] { });
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
