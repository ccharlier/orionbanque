using OrionBanque.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class FichiersForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Utilisateur uA;
        public bool bMustSave = false;

        public FichiersForm()
        {
            InitializeComponent();
            ChargeGrille();
        }

        private void ChargeGrille()
        {
            kDgvFichiers.DataSource = Fichier.DataSet();
            kDgvFichiers.DataMember = "Fichiers";
            kDgvFichiers.Columns["Id"].Visible = false;
            kDgvFichiers.Columns["Type"].Visible = false;
            kDgvFichiers.Columns["Chemin"].Visible = false;
        }

        private void kDgvFichiers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (kDgvFichiers.Rows.Count == 0)
                {
                    return;
                }

                string chemin = kDgvFichiers.SelectedRows[0].Cells["Chemin"].Value.ToString();
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(chemin, "");
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}