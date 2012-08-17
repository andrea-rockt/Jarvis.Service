namespace Jarvis.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.jarvisServiceHostProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.jarvisServiceHostInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // jarvisServiceHostProcessInstaller1
            // 
            this.jarvisServiceHostProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.jarvisServiceHostProcessInstaller1.Password = null;
            this.jarvisServiceHostProcessInstaller1.Username = null;
            // 
            // jarvisServiceHostInstaller
            // 
            this.jarvisServiceHostInstaller.DisplayName = "Jarvis Your Personal Butler";
            this.jarvisServiceHostInstaller.ServiceName = "JarvisService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.jarvisServiceHostProcessInstaller1,
            this.jarvisServiceHostInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller jarvisServiceHostProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller jarvisServiceHostInstaller;
    }
}