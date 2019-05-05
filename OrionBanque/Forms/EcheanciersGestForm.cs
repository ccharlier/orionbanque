using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class EcheanciersGestForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Utilisateur uA;

        public EcheanciersGestForm(Utilisateur u)
        {
            InitializeComponent();
            uA = u;
            txtDateInsereEch.CalendarTodayDate = DateTime.Now;
            ChargeGrille();
        }

        private void ChargeGrille()
        {
            DataSet ds = Echeancier.ChargeGrilleEcheance(uA);
            dgvEcheance.DataSource = ds;
            dgvEcheance.DataMember = "echeancier";
            dgvEcheance.Columns["Id"].Visible = false;
            dgvEcheance.Columns["ModePaiementType"].Visible = false;
            dgvEcheance.Columns["Montant Débit"].DefaultCellStyle.Format = "c";
            dgvEcheance.Columns["Montant Débit"].DefaultCellStyle.ForeColor = Color.Red;
            dgvEcheance.Columns["Montant Débit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEcheance.Columns["Montant Crédit"].DefaultCellStyle.Format = "c";
            dgvEcheance.Columns["Montant Crédit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void KryptonButton1_Click(object sender, EventArgs e)
        {
            EcheancierForm ea = new EcheancierForm(new Echeancier(), uA, "INSERT");
            ea.ShowDialog();

            ChargeGrille();
        }

        private void KryptonButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Etes-vous sur de supprimer cette échéance ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Echeancier.Delete(Echeancier.Charge((int)dgvEcheance.SelectedRows[0].Cells["Id"].Value));
                ChargeGrille();
            }
        }

        private void KryptonButton2_Click(object sender, EventArgs e)
        {
            LanceMajEcheance();
        }

        private void KryptonButton4_Click(object sender, EventArgs e)
        {
            List<string> nbE = Echeancier.InsereEcheanceFromGest(txtDateInsereEch.Value, uA);
            if (nbE.Count != 0)
            {
                MessageBox.Show("Opérations insérées : " + Environment.NewLine + string.Join(Environment.NewLine, nbE.ToArray()), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("0 Opération insérée.");
            }
            ChargeGrille();
        }

        private void DgvEcheance_DoubleClick(object sender, EventArgs e)
        {
            LanceMajEcheance();
        }

        private void LanceMajEcheance()
        {
            EcheancierForm em = new EcheancierForm(Echeancier.Charge(int.Parse(dgvEcheance.SelectedRows[0].Cells["Id"].Value.ToString(), System.Globalization.CultureInfo.CurrentCulture)), uA, "UPDATE");
            em.ShowDialog();

            ChargeGrille();
        }

        private void AjouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KryptonButton1_Click(sender, e);
        }

        private void ModifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KryptonButton2_Click(sender, e);
        }

        private void SupprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KryptonButton3_Click(sender, e);
        }
    }
}
