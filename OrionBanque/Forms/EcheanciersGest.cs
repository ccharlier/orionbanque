﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace OrionBanque.Forms
{
    public partial class EcheanciersGest : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Int32 idC;
        public EcheanciersGest(Int32 idCompte)
        {
            InitializeComponent();
            idC = idCompte;

            ChargeGrille();
        }

        private void ChargeGrille()
        {
            try
            {
                DataSet ds = Classe.Echeancier.ChargeGrilleEcheance(idC);
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
                Forms.Echeancier ea = new Echeancier(idC, "INSERT");
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
                    Classe.Echeancier.Delete(Int32.Parse(dgvEcheance.SelectedRows[0].Cells["Id"].Value.ToString()));
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
            try
            {
                Forms.Echeancier em = new Echeancier(Int32.Parse(dgvEcheance.SelectedRows[0].Cells["Id"].Value.ToString()), "UPDATE");
                em.ShowDialog();

                ChargeGrille();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KryptonButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 i = Classe.Echeancier.InsereEcheance(txtDateInsereEch.Value, idC);
                MessageBox.Show(i + " Opérations insérées.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargeGrille();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvEcheance_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Forms.Echeancier em = new Echeancier(Int32.Parse(dgvEcheance.SelectedRows[0].Cells["Id"].Value.ToString()), "UPDATE");
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
