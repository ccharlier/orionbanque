using System;
using System.Windows.Forms;

namespace OrionBanque
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!System.IO.Directory.Exists(Classe.KEY.DIRECTORY_PATH))
            {
                System.IO.Directory.CreateDirectory(Classe.KEY.DIRECTORY_PATH);
            }
            Forms.ConnexionForm fc = new Forms.ConnexionForm();
            fc.ShowDialog();
            if(fc.cont)
            {
                MainForm mf = new MainForm(fc.uA);
                mf.tsSave.Enabled = fc.activSauv;
                Application.Run(mf);
            }
        }
    }
}
