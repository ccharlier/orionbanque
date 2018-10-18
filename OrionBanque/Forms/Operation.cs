using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class Operation : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        Classe.Operation O;
        private Int32 idC = 0;
        public bool cont = false;
        private bool PointageModif = false;

        public Operation(Int32 id, string mode)
        {
            InitializeComponent();
            
            if (mode.Equals("INSERT"))
            {
                idC = id;
            }
            else if(mode.Equals("UPDATE"))
            {
                O = Classe.Operation.Charge(id);
                idC = O.IdCompte;
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
                    txtCategorie.SelectedValue = O.IdCategorie;
                    txtLibelle.Text = O.Libelle;
                    txtModePaiement.SelectedValue = O.IdModePaiement;
                    txtMontant.Value = new Decimal(O.Montant);
                    if (O.DatePointage != null)
                        txtPointage.Checked = true;
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
                List<Classe.ModePaiement> lmp = Classe.ModePaiement.ChargeTout();
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
                List<Classe.Categorie> lc = Classe.Categorie.ChargeToutIdent();
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
                List<String> ls = Classe.Operation.ChargeToutTiers(idC);
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
                    O.IdCategorie = (Int32)txtCategorie.SelectedValue;
                    O.IdModePaiement = (Int32)txtModePaiement.SelectedValue;
                    O.Libelle = txtLibelle.Text;
                    O.Montant = Double.Parse(txtMontant.Value.ToString());
                    O.Tiers = txtTiers.Text;
                    if (txtPointage.Checked && PointageModif)
                        O.DatePointage = DateTime.Now;
                    if (!txtPointage.Checked)
                        O.DatePointage = null;

                    Classe.Operation.Maj(O);
                    cont = true;
                    this.Close();
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
                    Classe.Operation o = new OrionBanque.Classe.Operation
                    {
                        Date = txtDateMvt.Value,
                        IdCategorie = (Int32)txtCategorie.SelectedValue,
                        IdCompte = idC,
                        IdModePaiement = (Int32)txtModePaiement.SelectedValue,
                        Libelle = txtLibelle.Text,
                        Montant = Double.Parse(txtMontant.Value.ToString()),
                        Tiers = txtTiers.Text
                    };
                    if (txtPointage.Checked && PointageModif)
                        o.DatePointage = DateTime.Now;
                    if (!txtPointage.Checked)
                        o.DatePointage = null;

                    Classe.Operation.Sauve(o);
                    cont = true;
                    this.Close();
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
                Forms.ModePaiement fm = new ModePaiement();
                fm.ShowDialog();
                RemplisModePaiements();
            }
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Forms.Categories fm = new Forms.Categories();
                fm.ShowDialog();
                RemplisCategories();
            }
        }

        private void TxtModePaiement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtModePaiement.SelectedValue.ToString() == "8")
            {
                txtLibelle.Text = "n°" + Classe.Operation.ChercheChequeSuivant(idC);
            }
        }
    }
}
