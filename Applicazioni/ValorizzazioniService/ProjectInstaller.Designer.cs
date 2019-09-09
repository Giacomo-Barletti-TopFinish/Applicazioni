namespace ValorizzazioniService
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
            this.valorizzazioniServiceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.valorizzazioniServiceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // valorizzazioniServiceProcessInstaller1
            // 
            this.valorizzazioniServiceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.valorizzazioniServiceProcessInstaller1.Password = null;
            this.valorizzazioniServiceProcessInstaller1.Username = null;
            // 
            // valorizzazioniServiceInstaller1
            // 
            this.valorizzazioniServiceInstaller1.Description = "Servizio valorizzazione magazzini";
            this.valorizzazioniServiceInstaller1.DisplayName = "ValorizzazioniService";
            this.valorizzazioniServiceInstaller1.ServiceName = "ValorizzazioniService";
            this.valorizzazioniServiceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.valorizzazioniServiceProcessInstaller1,
            this.valorizzazioniServiceInstaller1});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller valorizzazioniServiceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller valorizzazioniServiceInstaller1;
    }
}