using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace OrionBanque.Forms
{
    public partial class EcheanciersGest : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Classe.Utilisateur uA;

        public EcheanciersGest(Classe.Utilisateur u)
        {
            InitializeComponent();
            uA = u;

            ChargeGrille();
        }

        private void ChargeGrille()
        {
            try
            {
                DataSet ds = Classe.Echeancier.ChargeGrilleEcheance(uA);
                dgvEcheance.DataSource = ds;
                dgvEcheance.DataMember = "echeancier";
                dgvEcheance.Columns["Id"].Visible = false;
                dgvEcheance.Columns["ModePaiementType"].Visible = false;
                dgvEcheance.Columns["Montant Débit"].DefaultCellStyle.Format = "c";
                dgvEcheance.Columns["Montant Débit"].DefaultCellStyle.ForeColor = Color.Red;
                dgvEcheance.Columns["Montant Crédit"].DefaultCellStyle.Format = "c";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Echeancier ea = new Echeancier(new Classe.Echeancier(), uA, "INSERT");
                ea.ShowDialog();

                ChargeGrille();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KryptonButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Etes-vous sur de supprimer cette échéance ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Classe.Echeancier.Delete(int.Parse(dgvEcheance.SelectedRows[0].Cells["Id"].Value.ToString()));
                    ChargeGrille();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void KryptonButton2_Click(object sender, EventArgs e)
        {
            LanceMajEcheance();
        }

        private void KryptonButton4_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> nbE = Classe.Echeancier.InsereEcheanceFromGest(txtDateInsereEch.Value, uA);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvEcheance_DoubleClick(object sender, EventArgs e)
        {
            LanceMajEcheance();
        }

        private void LanceMajEcheance()
        {
            try
            {
                Echeancier em = new Echeancier(Classe.Echeancier.Charge(int.Parse(dgvEcheance.SelectedRows[0].Cells["Id"].Value.ToString())), uA, "UPDATE");
                em.ShowDialog();

                ChargeGrille();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
