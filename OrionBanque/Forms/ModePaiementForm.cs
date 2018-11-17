using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class ModePaiementForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public ModePaiementForm()
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
                List<ModePaiement> lmp = ModePaiement.ChargeTout();
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
                ModePaiement mp = ModePaiement.Charge((int)cbModePaiement.SelectedValue);
                mp.Libelle = txtLibelleMod.Text.Trim();
                if (cbDebCredMod.SelectedItem.ToString() == KEY.MODEPAIEMENT_DEBIT_LIB)
                {
                    mp.Type = KEY.MODEPAIEMENT_DEBIT;
                }

                if (cbDebCredMod.SelectedItem.ToString() == KEY.MODEPAIEMENT_CREDIT_LIB)
                {
                    mp.Type = KEY.MODEPAIEMENT_CREDIT;
                }

                ModePaiement.Maj(mp);

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
                ModePaiement mp = ModePaiement.Charge((int)cbModePaiement.SelectedValue);
                txtLibelleMod.Text = mp.Libelle;
                if (mp.Type == KEY.MODEPAIEMENT_CREDIT)
                {
                    cbDebCredMod.SelectedItem = KEY.MODEPAIEMENT_CREDIT_LIB;
                }

                if (mp.Type == KEY.MODEPAIEMENT_DEBIT)
                {
                    cbDebCredMod.SelectedItem = KEY.MODEPAIEMENT_DEBIT_LIB;
                }

                if (mp.Id > 8)
                {
                    btnSupCat.Enabled = true;
                }
                else
                {
                    btnSupCat.Enabled = false;
                }
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
                        ModePaiement.Delete(ModePaiement.Charge((int)cbModePaiement.SelectedValue));
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
                ModePaiement mp = new ModePaiement
                {
                    Libelle = txtLibelleAdd.Text.Trim()
                };
                if (cbDebCredAdd.SelectedItem.ToString() == KEY.MODEPAIEMENT_DEBIT_LIB)
                {
                    mp.Type = KEY.MODEPAIEMENT_DEBIT;
                }

                if (cbDebCredAdd.SelectedItem.ToString() == KEY.MODEPAIEMENT_CREDIT_LIB)
                {
                    mp.Type = KEY.MODEPAIEMENT_CREDIT;
                }

                ModePaiement.Sauve(mp);

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
