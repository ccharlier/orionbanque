using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class TotalComptesForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        Classe.Utilisateur uA;

        public TotalComptesForm(Classe.Utilisateur u)
        {
            InitializeComponent();
            uA = u;

            ChargeGrille();
        }

        private void ChargeGrille()
        {
            try
            {
                DataSet ds = Classe.Compte.DataSetTotalComptes(uA);
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
            catch(Exception ex)
            { }
        }
    }
}
