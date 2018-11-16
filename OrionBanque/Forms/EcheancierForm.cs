using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class EcheancierForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Classe.Utilisateur uA;
        private Classe.Echeancier eA;
        public bool cont = false;

        public EcheancierForm(Classe.Echeancier e, Classe.Utilisateur u, string mode)
        {
            InitializeComponent();
            uA = u;
            eA = e;
            RemplisCb();
            if (mode.Equals("UPDATE"))
            {
                ChargeForm();
            }
        }

        private void ChargeForm()
        {
            try
            {
                cbCompte.SelectedValue = eA.Compte.Id;
                if (eA.DateFin == null)
                {
                    txtIllimete.Checked = true;
                }
                else
                {
                    txtIllimete.Checked = false;
                    txtDateFin.Value = eA.DateFin.Value;
                }
                txtCategorie.SelectedValue = eA.Categorie.Id;
                txtModePaiement.SelectedValue = eA.ModePaiement.Id;
                txtLibelle.Text = eA.Libelle;
                txtMontant.Value = new decimal(eA.Montant);
                txtTiers.Text = eA.Tiers;
                if (eA.TypeRepete == Classe.KEY.ECHEANCIER_JOUR)
                {
                    txtTypeRepete.Text = "Jour(s)";
                }

                if (eA.TypeRepete == Classe.KEY.ECHEANCIER_MOIS)
                {
                    txtTypeRepete.Text = "Mois";
                }

                if (eA.TypeRepete == Classe.KEY.ECHEANCIER_ANNEE)
                {
                    txtTypeRepete.Text = "Année(s)";
                }

                txtRepete.Value = new decimal(eA.Repete);
                txtProchaine.Value = eA.Prochaine;
                txtInsererOuvertureFichier.Checked = eA.InsererOuvertureFichier ?? false;
                txtDecaleSamedi.Checked = eA.DecaleSamedi ?? false;
                txtDecaleDimanche.Checked = eA.DecaleSamedi ?? false;
                txtDecaleJourFerie.Checked = eA.DecaleJourFerie ?? false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemplisCb()
        {
            ChargeComboCompte();
            RemplisModePaiements();
            RemplisTiers();
            RemplisCategories();
        }

        private void ChargeComboCompte()
        {
            try
            {
                List<Classe.Compte> lc = Classe.Compte.ChargeTout(uA);
                cbCompte.DisplayMember = "Libelle";
                cbCompte.ValueMember = "Id";

                cbCompte.DataSource = lc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtCategorie.DisplayMember = "LibelleIdent";
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
                List<string> ls = Classe.Operation.ChargeToutTiers((int)cbCompte.SelectedValue);
                txtTiers.DataSource = ls;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OK_Click(object sender, EventArgs eventA)
        {
            try
            {
                if (txtIllimete.Checked)
                {
                    eA.DateFin = null;
                }
                else
                {
                    eA.DateFin = txtDateFin.Value.Date;
                }

                eA.Compte = Classe.Compte.Charge((int)cbCompte.SelectedValue);
                eA.Categorie = Classe.Categorie.Charge((int)txtCategorie.SelectedValue);
                eA.ModePaiement = Classe.ModePaiement.Charge((int)txtModePaiement.SelectedValue);
                eA.Libelle = txtLibelle.Text;
                eA.Montant = double.Parse(txtMontant.Value.ToString());
                eA.Tiers = txtTiers.Text;

                if (txtTypeRepete.Text == "Jour(s)")
                {
                    eA.TypeRepete = Classe.KEY.ECHEANCIER_JOUR;
                }

                if (txtTypeRepete.Text == "Mois")
                {
                    eA.TypeRepete = Classe.KEY.ECHEANCIER_MOIS;
                }

                if (txtTypeRepete.Text == "Année(s)")
                {
                    eA.TypeRepete = Classe.KEY.ECHEANCIER_ANNEE;
                }

                eA.Repete = int.Parse(txtRepete.Value.ToString());
                eA.Prochaine = txtProchaine.Value.Date;
                eA.InsererOuvertureFichier = txtInsererOuvertureFichier.Checked;
                eA.DecaleSamedi = txtDecaleSamedi.Checked;
                eA.DecaleDimanche = txtDecaleDimanche.Checked;
                eA.DecaleJourFerie = txtDecaleJourFerie.Checked;
                cont = true;

                if (eA.Id != 0)
                {
                    Classe.Echeancier.Maj(eA);
                }
                else
                {
                    Classe.Echeancier.Sauve(eA);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtIlimete_CheckedChanged(object sender, EventArgs e)
        {
            if (txtIllimete.Checked)
            {
                txtDateFin.Enabled = false;
            }
            else
            {
                txtDateFin.Enabled = true;
            }
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            if(((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                CategoriesForm fm = new CategoriesForm();
                fm.ShowDialog();
                RemplisCategories();
            }
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
    }
}
