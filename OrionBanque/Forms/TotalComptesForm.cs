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
            ChargeCbTotalCompte();
            estConstructeur = false;
        }

        private void ChargeCbTotalCompte()
        {
            kCbListTotalCompte.DataSource = TotalCompte.ChargeTout();
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

                if(kCbListTotalCompte.SelectedValue != null)
                { 
                    DataSet ds = Compte.DataSetTotalComptes(TotalCompte.Charge((int)kCbListTotalCompte.SelectedValue));
                    kDgvTotalCompte.DataSource = ds;
                    kDgvTotalCompte.DataMember = "TotalComptes";
                    kDgvTotalCompte.Columns["Pointé"].DefaultCellStyle.Format = "c";
                    kDgvTotalCompte.Columns["Pointé"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    kDgvTotalCompte.Columns["A venir"].DefaultCellStyle.Format = "c";
                    kDgvTotalCompte.Columns["A venir"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    kDgvTotalCompte.Columns["Solde"].DefaultCellStyle.Format = "c";
                    kDgvTotalCompte.Columns["Solde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
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
                TotalCompte tc = TotalCompte.Charge((int)kCbListTotalCompte.SelectedValue);
                Compte c = (Compte)kLBCompte.Items[e.Index];
                if(e.NewValue == CheckState.Checked)
                {
                    tc.Comptes.Add(c);
                }
                else
                {
                    tc.Comptes.Remove(c);
                }
                TotalCompte.Maj(tc);
                ChargeGrille();
                cont = true;
            }
        }

        private void btnSpecTtCpteAjout_Click(object sender, EventArgs e)
        {
            string ret = ComponentFactory.Krypton.Toolkit.KryptonInputBox.Show("Entrer le nom du nouveau paramétrage", "Nouveau", "Vue_1");
            if(!ret.Equals(string.Empty))
            {
                TotalCompte tc = new TotalCompte();
                tc.Libelle = ret;

                TotalCompte.Sauve(tc);
                ChargeCbTotalCompte();
                ChargeGrille();
                cont = true;
            }
        }

        private void btnSpecTtCpteSupprime_Click(object sender, EventArgs e)
        {
            if(ComponentFactory.Krypton.Toolkit.KryptonTaskDialog.Show("Confirmation", "Etes-vous certain de supprimer ce paramétrage ?", "", MessageBoxIcon.Question, ComponentFactory.Krypton.Toolkit.TaskDialogButtons.Yes|ComponentFactory.Krypton.Toolkit.TaskDialogButtons.No) == DialogResult.Yes)
            {
                TotalCompte.Delete(TotalCompte.Charge((int)kCbListTotalCompte.SelectedValue));
                ChargeCbTotalCompte();
                ChargeGrille();
                cont = true;
            }
        }

        private void kCbListTotalCompte_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool[] temp = new bool[kLBCompte.Items.Count];
            TotalCompte tc = TotalCompte.Charge((int)kCbListTotalCompte.SelectedValue);

            for (int i = 0;i<kLBCompte.Items.Count;i++)
            {
                Compte c = (Compte)kLBCompte.Items[i];
                foreach(Compte ct in tc.Comptes)
                {
                    if(ct.Id == c.Id)
                    {
                        temp[i] = true;
                        break;
                    }
                    else
                    {
                        temp[i] = false;
                    }
                }
            }
            estConstructeur = true;
            for (int i=0;i<temp.Length;i++)
            {
                kLBCompte.SetItemChecked(i, temp[i]);
            }
            estConstructeur = false;
            ChargeGrille();
        }
    }
}
