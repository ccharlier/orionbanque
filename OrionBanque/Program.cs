using System;
using System.Collections.Generic;
using System.Linq;
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
            Classe.Sql.InitialiseBD(System.IO.Path.GetDirectoryName(Classe.KEY.BINARY_PATH_COMPLETE));
            Forms.Connexion fc = new Forms.Connexion();
            fc.ShowDialog();
            if(fc.cont)
            {
                Application.Run(new MainForm(fc.uA));
            }
        }
    }
}
