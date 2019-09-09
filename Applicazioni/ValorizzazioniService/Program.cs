using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ValorizzazioniService.Properties;

namespace ValorizzazioniService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            ValorizzazioniService valorizzazioniService = new ValorizzazioniService();

            if (Settings.Default.StartAsApplication)
            {
                valorizzazioniService.OnStartAsApplication();
            }
            else
            {
                ServiceBase[] servicesToRun = new ServiceBase[] { valorizzazioniService };
                ServiceBase.Run(servicesToRun);
            }
        }
    }
}
