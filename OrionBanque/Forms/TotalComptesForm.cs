using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class TotalComptesForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Utilisateur uA;
        private bool estConstructeur = true;
        public bool cont = false;

        public TotalComptesForm(Utilisateur u)
        {
            InitializeComponent();
            uA = u;

            ChargeCompte();
            ChargeGrille();
            estConstructeur = false;
        }

        private void ChargeCompte()
        {
            List<Compte> lc = Compte.ChargeTout(uA);
            kLBCompte.ListBox.DataSource = lc;
            kLBCompte.ListBox.ValueMember = "Id";
            kLBCompte.ListBox.DisplayMember = "Libelle";

            for(var i=0; i<kLBCompte.Items.Count; i++)
            {
                kLBCompte.SetItemChecked(i, ((Compte)kLBCompte.Items[i]).EstDansTotalCompte ?? true);
            }
        }

        private void ChargeGrille()
        {
            try
            {
                kDgvTotalCompte.DataSource = null;

                DataSet ds = Compte.DataSetTotalComptes(uA);
                kDgvTotalCompte.DataSource = ds;
                kDgvTotalCompte.DataMember = "TotalComptes";
                kDgvTotalCompte.Columns["Pointé"].DefaultCellStyle.Format = "c";
                kDgvTotalCompte.Columns["Pointé"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                kDgvTotalCompte.Columns["A venir"].DefaultCellStyle.Format = "c";
                kDgvTotalCompte.Columns["A venir"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                kDgvTotalCompte.Columns["Solde"].DefaultCellStyle.Format = "c";
                kDgvTotalCompte.Columns["Solde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kDgvTotalCompte_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                e.CellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
            }
            if(e.RowIndex == kDgvTotalCompte.Rows.Count-1)
            {
                e.CellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
            }
            try
            {
                double num = double.Parse(e.Value.ToString());
                if(num < 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            { }
        }

        private void kLBCompte_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!estConstructeur)
            {
                Compte c = (Compte)kLBCompte.Items[e.Index];
                c.EstDansTotalCompte = e.NewValue == CheckState.Checked ? true : false;
                Compte.Maj(c);
                ChargeGrille();
                cont = true;
            }
        }
    }
}
