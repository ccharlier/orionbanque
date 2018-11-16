using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class OperationForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        Operation O;
        private int idC = 0;
        public bool cont = false;
        private bool PointageModif = false;

        public OperationForm(int id, string mode)
        {
            InitializeComponent();
            
            if (mode.Equals(KEY.MODE_INSERT))
            {
                idC = id;
            }
            else if(mode.Equals(KEY.MODE_UPDATE))
            {
                O = Operation.Charge(id);
                idC = O.Compte.Id;
            }
            RemplisCb();
        }

        private void RemplisCb()
        {
            RemplisCategories();
            RemplisModePaiements();
            RemplisTiers();
            ChargeForm();
        }

        private void ChargeForm()
        {
            if (O != null)
            {
                try
                {
                    txtDateMvt.Value = O.Date;
                    txtCategorie.SelectedValue = O.Categorie.Id;
                    txtLibelle.Text = O.Libelle;
                    txtModePaiement.SelectedValue = O.ModePaiement.Id;
                    txtMontant.Value = new decimal(O.Montant);
                    if (O.DatePointage != null)
                    {
                        txtPointage.Checked = true;
                    }

                    txtTiers.Text = O.Tiers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RemplisModePaiements()
        {
            try
            {
                List<ModePaiement> lmp = ModePaiement.ChargeTout();
                txtModePaiement.DisplayMember = "Libelle";
                txtModePaiement.ValueMember = "Id";
                txtModePaiement.DataSource = lmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemplisCategories()
        {
            try
            {
                List<Categorie> lc = Categorie.ChargeToutIdent();
                txtCategorie.DisplayMember = "Libelle";
                txtCategorie.ValueMember = "Id";
                txtCategorie.DataSource = lc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemplisTiers()
        {
            try
            {
                List<string> ls = Operation.ChargeToutTiers(idC);
                txtTiers.DataSource = ls;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (O != null)
            {
                try
                {
                    O.Date = txtDateMvt.Value;
                    O.Categorie = Categorie.Charge((int)txtCategorie.SelectedValue);
                    O.ModePaiement = ModePaiement.Charge((int)txtModePaiement.SelectedValue);
                    O.Libelle = txtLibelle.Text;
                    O.Montant = double.Parse(txtMontant.Value.ToString());
                    O.Tiers = txtTiers.Text;
                    if (txtPointage.Checked && PointageModif)
                    {
                        O.DatePointage = DateTime.Now;
                    }

                    if (!txtPointage.Checked)
                    {
                        O.DatePointage = null;
                    }

                    Operation.Maj(O);
                    cont = true;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    Operation o = new Operation
                    {
                        Date = txtDateMvt.Value,
                        Categorie = Categorie.Charge((int)txtCategorie.SelectedValue),
                        Compte = Compte.Charge(idC),
                        ModePaiement = ModePaiement.Charge((int)txtModePaiement.SelectedValue),
                        Libelle = txtLibelle.Text,
                        Montant = double.Parse(txtMontant.Value.ToString()),
                        Tiers = txtTiers.Text
                    };
                    if (txtPointage.Checked && PointageModif)
                    {
                        o.DatePointage = DateTime.Now;
                    }

                    if (!txtPointage.Checked)
                    {
                        o.DatePointage = null;
                    }

                    Operation.Sauve(o);
                    cont = true;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtPointage_CheckedChanged(object sender, EventArgs e)
        {
            PointageModif = true;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if(((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                ModePaiementForm fm = new ModePaiementForm();
                fm.ShowDialog();
                RemplisModePaiements();
            }
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                CategoriesForm fm = new CategoriesForm();
                fm.ShowDialog();
                RemplisCategories();
            }
        }

        private void TxtModePaiement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtModePaiement.SelectedValue.ToString() == "8")
            {
                txtLibelle.Text = "n°" + Operation.ChercheChequeSuivant(idC);
            }
        }
    }
}
