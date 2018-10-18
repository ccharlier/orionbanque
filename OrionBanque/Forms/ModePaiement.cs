using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class ModePaiement : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public ModePaiement()
        {
            InitializeComponent();
            cbDebCredAdd.SelectedItem = cbDebCredAdd.Items[0];
            cbDebCredMod.SelectedItem = cbDebCredMod.Items[0];

            ChargeCombo();
        }

        private void ChargeCombo()
        {
            try
            {
                List<Classe.ModePaiement> lmp = Classe.ModePaiement.ChargeTout();
                cbModePaiement.DisplayMember = "libelle";
                cbModePaiement.ValueMember = "id";
                cbModePaiement.DataSource = lmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnValidMod_Click(object sender, EventArgs e)
        {
            try
            {
                Classe.ModePaiement mp = Classe.ModePaiement.Charge((Int32)cbModePaiement.SelectedValue);
                mp.Libelle = txtLibelleMod.Text.Trim();
                if (cbDebCredMod.SelectedItem.ToString() == "Débit")
                    mp.Type = "D";
                if (cbDebCredMod.SelectedItem.ToString() == "Crédit")
                    mp.Type = "C";

                Classe.ModePaiement.Maj(mp);

                ChargeCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbModePaiement_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Classe.ModePaiement mp = Classe.ModePaiement.Charge((Int32)cbModePaiement.SelectedValue);
                txtLibelleMod.Text = mp.Libelle;
                if (mp.Type == "C")
                    cbDebCredMod.SelectedItem = "Crédit";
                if (mp.Type == "D")
                    cbDebCredMod.SelectedItem = "Débit";
                if(mp.Id > 8)
                    btnSupCat.Enabled = true;
                else
                    btnSupCat.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSupCat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Etes-vous sur de supprimer ce Mode de Paiement ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(!cbModePaiement.SelectedValue.ToString().Contains("Virement"))
                {
                    try
                    {
                        Classe.ModePaiement.Delete((Int32)cbModePaiement.SelectedValue);
                        ChargeCombo();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Impossible de supprimer le mode de paiement 'Virement'.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Classe.ModePaiement mp = new OrionBanque.Classe.ModePaiement
                {
                    Libelle = txtLibelleAdd.Text.Trim()
                };
                if (cbDebCredAdd.SelectedItem.ToString() == "Débit")
                    mp.Type = "D";
                if (cbDebCredAdd.SelectedItem.ToString() == "Crédit")
                    mp.Type = "C";

                Classe.ModePaiement.Sauve(mp);

                ChargeCombo();

                txtLibelleAdd.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
