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
            Classe.Sql.InitialiseBD(Classe.KEY.DIRECTORY_PATH);
            Forms.Connexion fc = new Forms.Connexion();
            fc.ShowDialog();
            if(fc.cont)
            {
                Application.Run(new MainForm(fc.uA));
            }
        }
    }
}
