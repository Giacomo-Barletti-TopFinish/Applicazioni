using Applicazioni.Common;
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
using ValorizzazioniService.Managers;
using ValorizzazioniService.Properties;

namespace ValorizzazioniService
{
    public partial class ValorizzazioniService : BaseService
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

        public ValorizzazioniService()
        {
            InitializeComponent();
        }
       
        protected override void AsyncOperationCallback(Object stateInfo)
        {
            if (IsAsync)
                return;

            IsAsync = true;
            try
            {
                using (ValorizzazioniServiceManager mng = new ValorizzazioniServiceManager())
                {
                    LogHelper.LogInfo("Inizio attivita");
                    mng.DoIt();
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
                LogHelper.LogInfo("#### VALORIZZAZIONE SERVICE IN FASE DI AVVIO ####");
                LogHelper.LogInfo(string.Format("PERIOD IMPOSTATO {0} SECONDI", Settings.Default.Period));

                _tmrAsync = new Timer(new TimerCallback(AsyncOperationCallback), null, 5000, Settings.Default.Period * 1000);
                LogHelper.LogInfo("#### VALORIZZAZIONE SERVICE AVVIATO ####");
            }
            catch (Exception ex)
            {
                LogHelper.LogError("Errore in OnStart", ex);
            }
        }

        protected override void OnStop()
        {
            LogHelper.LogInfo("#### VALORIZZAZIONE SERVICE FERMATO ####");
        }
    }
}
