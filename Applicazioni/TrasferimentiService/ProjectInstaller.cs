﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace TrasferimentiService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void trasferimentiServiceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        private void trasferimentiServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController(this.trasferimentiServiceInstaller.ServiceName))
            {
                sc.Start();
            }
        }
    }
}
