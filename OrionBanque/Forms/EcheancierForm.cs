using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class EcheancierForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Utilisateur uA;
        private Echeancier eA;
        private bool cont = false;

        public bool Cont { get => cont; set => cont = value; }

        public EcheancierForm(Echeancier e, Utilisateur u, string mode)
        {
            InitializeComponent();
            uA = u;
            eA = e;
            txtProchaine.CalendarTodayDate = DateTime.Now;
            txtDateFin.CalendarTodayDate = DateTime.Now;
            RemplisCb();
            if (string.Equals(mode, KEY.MODEUPDATE, StringComparison.CurrentCulture))
            {
                ChargeForm();
            }
        }

        private void ChargeForm()
        {
            cbCompte.SelectedValue = eA.Compte.Id;
            if (eA.DateFin == null)
            {
                txtIllimite.Checked = true;
            }
            else
            {
                txtIllimite.Checked = false;
                txtDateFin.Value = eA.DateFin.Value;
            }
            txtCategorie.SelectedValue = eA.Categorie.Id;
            txtModePaiement.SelectedValue = eA.ModePaiement.Id;
            txtLibelle.Text = eA.Libelle;
            txtMontant.Value = new decimal(eA.Montant);
            txtTiers.Text = eA.Tiers;
            if (eA.TypeRepete == KEY.ECHEANCIERJOUR)
            {
                txtTypeRepete.Text = KEY.ECHEANCIERJOURLIB;
            }

            if (eA.TypeRepete == KEY.ECHEANCIERMOIS)
            {
                txtTypeRepete.Text = KEY.ECHEANCIERMOISLIB;
            }

            if (eA.TypeRepete == KEY.ECHEANCIERANNEE)
            {
                txtTypeRepete.Text = KEY.ECHEANCIERANNEELIB;
            }

            txtRepete.Value = new decimal(eA.Repete);
            txtProchaine.Value = eA.Prochaine;
            txtInsererOuvertureFichier.Checked = eA.InsererOuvertureFichier ?? false;
            txtDecaleSamedi.Checked = eA.DecaleSamedi ?? false;
            txtDecaleDimanche.Checked = eA.DecaleSamedi ?? false;
            txtDecaleJourFerie.Checked = eA.DecaleJourFerie ?? false;
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
            List<Compte> lc = Compte.ChargeTout(uA);
            cbCompte.DisplayMember = "Libelle";
            cbCompte.ValueMember = "Id";

            cbCompte.DataSource = lc;
        }

        private void RemplisModePaiements()
        {
            List<ModePaiement> lmp = ModePaiement.ChargeTout();
            txtModePaiement.DisplayMember = "Libelle";
            txtModePaiement.ValueMember = "Id";
            txtModePaiement.DataSource = lmp;
        }

        private void RemplisCategories()
        {
            List<Categorie> lc = Categorie.ChargeToutIdent();
            txtCategorie.DisplayMember = "LibelleIdent";
            txtCategorie.ValueMember = "Id";
            txtCategorie.DataSource = lc;
        }

        private void RemplisTiers()
        {
            txtTiers.DataSource = Tiers.ChargeTout();
        }

        private void OK_Click(object sender, EventArgs eventA)
        {
            if (txtIllimite.Checked)
            {
                eA.DateFin = null;
            }
            else
            {
                eA.DateFin = txtDateFin.Value.Date;
            }

            eA.Compte = Compte.Charge((int)cbCompte.SelectedValue);
            eA.Categorie = Categorie.Charge((int)txtCategorie.SelectedValue);
            eA.ModePaiement = ModePaiement.Charge((int)txtModePaiement.SelectedValue);
            eA.Libelle = txtLibelle.Text;
            eA.Montant = double.Parse(txtMontant.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture);
            eA.Tiers = txtTiers.Text;

            if (txtTypeRepete.Text == KEY.ECHEANCIERJOURLIB)
            {
                eA.TypeRepete = KEY.ECHEANCIERJOUR;
            }

            if (txtTypeRepete.Text == KEY.ECHEANCIERMOISLIB)
            {
                eA.TypeRepete = KEY.ECHEANCIERMOIS;
            }

            if (txtTypeRepete.Text == KEY.ECHEANCIERANNEELIB)
            {
                eA.TypeRepete = KEY.ECHEANCIERANNEE;
            }

            eA.Repete = int.Parse(txtRepete.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture);
            eA.Prochaine = txtProchaine.Value.Date;
            eA.InsererOuvertureFichier = txtInsererOuvertureFichier.Checked;
            eA.DecaleSamedi = txtDecaleSamedi.Checked;
            eA.DecaleDimanche = txtDecaleDimanche.Checked;
            eA.DecaleJourFerie = txtDecaleJourFerie.Checked;
            cont = true;

            if (eA.Id != 0)
            {
                Echeancier.Maj(eA);
            }
            else
            {
                Echeancier.Sauve(eA);
            }

            Close();
        }

        private void TxtIlimete_CheckedChanged(object sender, EventArgs e)
        {
            if (txtIllimite.Checked)
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

        private void txtMontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }
        }
    }
}
