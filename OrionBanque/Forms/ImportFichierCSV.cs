using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class ImportFichierCSV : KryptonForm
    {
        private Utilisateur uA;
        private bool cont = false;

        public bool Cont { get => cont; set => cont = value; }

        public ImportFichierCSV(Utilisateur u)
        {
            uA = u;
            InitializeComponent();
            ChargeComboCompte();
        }

        private void ChargeComboCompte()
        {
            cbCompte.DataSource = Compte.ChargeTout(uA);
        }

        private void btnSpecParcourir_Click(object sender, EventArgs e)
        {
            if(ODFImport.ShowDialog() == DialogResult.OK)
            {
                kTbFileNameImport.ReadOnly = false;
                kTbFileNameImport.Text = ODFImport.FileName;
                kTbFileNameImport.ReadOnly = true;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Compte cT = Compte.Charge((int)cbCompte.SelectedValue);
            Cursor = Cursors.WaitCursor;
            if (File.Exists(ODFImport.FileName))
            {
                Outils.ImportBP.Lance(Path.GetDirectoryName(ODFImport.FileName), Path.GetFileNameWithoutExtension(ODFImport.FileName), ODFImport.FileName, cT);
            }
            Cursor = Cursors.Default;
            Cont = true;
            Close();
        }
    }
}
