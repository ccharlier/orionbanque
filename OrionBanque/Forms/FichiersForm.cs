using OrionBanque.Classe;
using System;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class FichiersForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private bool bMustSave = false;

        public FichiersForm()
        {
            InitializeComponent();
            ChargeGrille();
        }

        public bool BMustSave { get => bMustSave; set => bMustSave = value; }

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
            if (kDgvFichiers.Rows.Count == 0)
            {
                return;
            }

            string chemin = kDgvFichiers.SelectedRows[0].Cells["Chemin"].Value.ToString();
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(chemin, "");
            System.Diagnostics.Process.Start(psi);
        }
    }
}