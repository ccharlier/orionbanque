﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class ModePaiementForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        bool etatNew;

        public ModePaiementForm()
        {
            InitializeComponent();
            cbDebCred.SelectedItem = cbDebCred.Items[0];
            etatNew = false;

            Charge();
        }

        private void Charge()
        {
            ChargeDgv();
            ChargeCompte(cbCompteGestion);
            ChargeCompte(cbCompteDeb);
        }

        private void ChargeDgv()
        {
            dgvModePaiements.DataSource = ModePaiement.ChargeToutDS();
            dgvModePaiements.DataMember = "ModePaiements";
            dgvModePaiements.Columns["Id"].Visible = false;
        }

        private static void ChargeCompte(KryptonComboBox cb)
        {
            cb.DataSource = Compte.ChargeTout();
        }

        private void btnSupModePaiement_Click(object sender, EventArgs e)
        {
            if(dgvModePaiements.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Etes-vous sur de supprimer ce Mode de Paiement ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ModePaiement.Delete(ModePaiement.Charge((int)dgvModePaiements.SelectedRows[0].Cells["Id"].Value));
                    Charge();
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            etatNew = true;
            txtLibelle.Text = string.Empty;
            kCbDiffere.Checked = false;
        }

        private void dgvModePaiements_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvModePaiements.SelectedRows.Count != 0)
            { 
                etatNew = false;
                ModePaiement mp = ModePaiement.Charge((int)dgvModePaiements.SelectedRows[0].Cells["Id"].Value);
                txtLibelle.Text = mp.Libelle;
                cbDebCred.SelectedItem = mp.Type == KEY.MODEPAIEMENTCREDIT ? KEY.MODEPAIEMENTCREDITLIB : KEY.MODEPAIEMENTDEBITLIB;
                kCbDiffere.Checked = mp.Differe;
                if (mp.CompteGestion != null)
                {
                    cbCompteGestion.SelectedValue = mp.CompteGestion.Id;
                }
                if (mp.CompteDebite != null)
                {
                    cbCompteDeb.SelectedValue = mp.CompteDebite.Id;
                }
                kNudPeriodeDebut.Value = Convert.ToDecimal(mp.PerdiodeDebut);
                kCbTypeDiffere.SelectedItem = mp.TypeDiffere;
                kNudDecalage.Value = Convert.ToDecimal(mp.Decalage);
                txtDecaleSamedi.Checked = mp.DecalageSamedi;
                txtDecaleDimanche.Checked = mp.DecalageDimanche;
                txtDecaleJourFerie.Checked = mp.DecalageFerie;

                if (mp.Type == KEY.MODEPAIEMENTCREDIT)
                {
                    kCbDiffere.Enabled = false;
                }
                else
                {
                    kCbDiffere.Enabled = true;
                }
            }
        }

        private void kCbDiffere_CheckedChanged(object sender, EventArgs e)
        {
            kGbOptionsDiffere.Enabled = kCbDiffere.Checked;
        }

        private void cbDebCred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbDebCred.SelectedItem == KEY.MODEPAIEMENTCREDITLIB)
            {
                kCbDiffere.Checked = false;
                kCbDiffere.Enabled = false;
            }
            else
            {
                kCbDiffere.Enabled = true;
            }
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            ModePaiement mp = etatNew ? new ModePaiement() : ModePaiement.Charge((int)dgvModePaiements.SelectedRows[0].Cells["Id"].Value);

            mp.Libelle = txtLibelle.Text;
            mp.Type = (string)cbDebCred.SelectedItem == KEY.MODEPAIEMENTCREDITLIB ? KEY.MODEPAIEMENTCREDIT : KEY.MODEPAIEMENTDEBIT;
            mp.Differe = kCbDiffere.Checked;
            mp.CompteGestion = (Compte)cbCompteGestion.SelectedItem;
            mp.CompteDebite = (Compte)cbCompteDeb.SelectedItem;
            mp.PerdiodeDebut = Convert.ToInt32(kNudPeriodeDebut.Value);
            mp.TypeDiffere = (string)kCbTypeDiffere.SelectedItem;
            mp.Decalage = Convert.ToInt32(kNudDecalage.Value);
            mp.DecalageSamedi = txtDecaleSamedi.Checked;
            mp.DecalageDimanche = txtDecaleDimanche.Checked;
            mp.DecalageFerie = txtDecaleJourFerie.Checked;

            if (etatNew)
            {
                ModePaiement.Sauve(mp);
            }
            else
            {
                ModePaiement.Maj(mp);
            }
        }
    }
}
