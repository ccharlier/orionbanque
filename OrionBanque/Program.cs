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
            if (!System.IO.Directory.Exists(Classe.KEY.DIRECTORYPATH))
            {
                System.IO.Directory.CreateDirectory(Classe.KEY.DIRECTORYPATH);
            }
            Forms.ConnexionForm fc = new Forms.ConnexionForm();
            fc.ShowDialog();
            if(fc.Cont)
            {
                MainFormRub mf = new MainFormRub(fc.UA, fc.ActivSauv);
                Application.Run(mf);
            }
        }
    }
}
