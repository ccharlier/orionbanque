using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class Echeancier : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Int32 idC;
        private Classe.Echeancier ec;
        public bool cont = false;

        public Echeancier(Int32 idEch, string mode)
        {
            InitializeComponent();
            RemplisCb();
            if (mode.Equals("UPDATE"))
            {
                ec = Classe.Echeancier.Charge(idEch);
                idC = ec.IdCompte;
                ChargeForm();
            }
            else if (mode.Equals("INSERT"))
            {
                idC = idEch;
            }
        }

        private void ChargeForm()
        {
            try
            {
                if (ec.DateFin == null)
                    txtIllimete.Checked = true;
                else
                {
                    txtIllimete.Checked = false;
                    txtDateFin.Value = ec.DateFin.Value;
                }
                txtCategorie.SelectedValue = ec.IdCategorie;
                txtModePaiement.SelectedValue = ec.IdModePaiement;
                txtLibelle.Text = ec.Libelle;
                txtMontant.Value = new Decimal(ec.Montant);
                txtTiers.Text = ec.Tiers;
                if (ec.TypeRepete == "J")
                    txtTypeRepete.Text = "Jour(s)";
                if (ec.TypeRepete == "M")
                    txtTypeRepete.Text = "Mois";
                if (ec.TypeRepete == "A")
                    txtTypeRepete.Text = "Année(s)";
                txtRepete.Value = new Decimal(ec.Repete);
                txtProchaine.Value = ec.Prochaine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemplisCb()
        {
            RemplisModePaiements();
            RemplisTiers();
            RemplisCategories();
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

        private void OK_Click(object sender, EventArgs eventA)
        {
            if (ec != null)
            {
                try
                {
                    ec = Classe.Echeancier.Charge(ec.Id);
                    if (txtIllimete.Checked)
                        ec.DateFin = null;
                    else
                        ec.DateFin = txtDateFin.Value;
                    ec.IdCategorie = (Int32)txtCategorie.SelectedValue;
                    ec.IdModePaiement = (Int32)txtModePaiement.SelectedValue;
                    ec.Libelle = txtLibelle.Text;
                    ec.Montant = Double.Parse(txtMontant.Value.ToString());
                    ec.Tiers = txtTiers.Text;
                    if (txtTypeRepete.Text == "Jour(s)")
                        ec.TypeRepete = "J";
                    if (txtTypeRepete.Text == "Mois")
                        ec.TypeRepete = "M";
                    if (txtTypeRepete.Text == "Année(s)")
                        ec.TypeRepete = "A";
                    ec.Repete = Int32.Parse(txtRepete.Value.ToString());
                    ec.Prochaine = txtProchaine.Value;

                    Classe.Echeancier.Maj(ec);
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
                    Classe.Echeancier e = new Classe.Echeancier();
                    if (txtIllimete.Checked)
                        e.DateFin = null;
                    else
                        e.DateFin = txtDateFin.Value;
                    e.IdCategorie = (Int32)txtCategorie.SelectedValue;
                    e.IdCompte = idC;
                    e.IdModePaiement = (Int32)txtModePaiement.SelectedValue;
                    e.Libelle = txtLibelle.Text;
                    e.Montant = Double.Parse(txtMontant.Value.ToString());
                    e.Tiers = txtTiers.Text;
                    if (txtTypeRepete.Text == "Jour(s)")
                        e.TypeRepete = "J";
                    if (txtTypeRepete.Text == "Mois")
                        e.TypeRepete = "M";
                    if (txtTypeRepete.Text == "Année(s)")
                        e.TypeRepete = "A";
                    e.Repete = Int32.Parse(txtRepete.Value.ToString());
                    e.Prochaine = txtProchaine.Value;

                    Classe.Echeancier.Sauve(e);
                    cont = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtIlimete_CheckedChanged(object sender, EventArgs e)
        {
            if (txtIllimete.Checked)
                txtDateFin.Enabled = false;
            else
                txtDateFin.Enabled = true;
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            if(((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Forms.Categories fm = new Forms.Categories();
                fm.ShowDialog();
                RemplisCategories();
            }
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
    }
}
