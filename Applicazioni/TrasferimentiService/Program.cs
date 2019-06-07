using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using TrasferimentiService.Properties;

namespace TrasferimentiService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            TrasferimentiService trasferimentiService = new TrasferimentiService();

            if (Settings.Default.StartAsApplication)
            {
                trasferimentiService.OnStartAsApplication();
            }
            else
            {
                ServiceBase[] servicesToRun = new ServiceBase[] { trasferimentiService };
                ServiceBase.Run(servicesToRun);
            }

        }
    }
}
