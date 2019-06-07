namespace TrasferimentiService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trasferimentiServiceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.trasferimentiServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // trasferimentiServiceProcessInstaller1
            // 
            this.trasferimentiServiceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.trasferimentiServiceProcessInstaller1.Password = null;
            this.trasferimentiServiceProcessInstaller1.Username = null;
            // 
            // trasferimentiServiceInstaller
            // 
            this.trasferimentiServiceInstaller.Description = "Servizio allineamento trasferimenti";
            this.trasferimentiServiceInstaller.DisplayName = "TrasferimentiService";
            this.trasferimentiServiceInstaller.ServiceName = "TrasferimentiService";
            this.trasferimentiServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.trasferimentiServiceProcessInstaller1,
            this.trasferimentiServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller trasferimentiServiceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller trasferimentiServiceInstaller;
    }
}