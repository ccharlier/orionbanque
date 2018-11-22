using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class OperationMajGroupeForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Compte cA;
        public bool cont = false;

        public OperationMajGroupeForm(Compte c)
        {
            cA = c;
            InitializeComponent();
            RemplisCb();
        }

        private void RemplisCb()
        {
            RemplisCategories();
            RemplisTiers();
        }

        private void RemplisCategories()
        {
            try
            {
                List<Categorie> lc = Categorie.ChargeToutIdent();
                txtCategorieOri.DisplayMember = "LibelleIdent";
                txtCategorieOri.ValueMember = "Id";
                txtCategorieOri.DataSource = lc;

                List<Categorie> lc2 = Categorie.ChargeToutIdent();
                txtCategorieDest.DisplayMember = "LibelleIdent";
                txtCategorieDest.ValueMember = "Id";
                txtCategorieDest.DataSource = lc2;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemplisTiers()
        {
            try
            {
                kCbTiersDe.DataSource = Operation.ChargeToutTiers(cA.Utilisateur);
                kCbTiersVers.DataSource = Operation.ChargeToutTiers(cA.Utilisateur);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnValidCat_Click(object sender, EventArgs e)
        {
            string text = string.Format("Etes-vous sure de vouloir transférer toutes les opérations du compte \"{0}\" de \"{1}\" vers \"{2}\"", cA.Libelle, txtCategorieOri.Text, txtCategorieDest.Text);
            if (MessageBox.Show(text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int nb = Operation.MajCategorieOperations(cA, Categorie.Charge((int)txtCategorieOri.SelectedValue), Categorie.Charge((int)txtCategorieDest.SelectedValue));
                MessageBox.Show(nb + " Opération(s) mise(s) à jour.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cont = true;
            }
        }

        private void kBtnValidTiers_Click(object sender, EventArgs e)
        {
            string text = string.Format("Etes-vous sure de vouloir transférer toutes les opérations du compte \"{0}\" de \"{1}\" vers \"{2}\"", cA.Libelle, kCbTiersDe.Text, kCbTiersVers.Text);
            if (MessageBox.Show(text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int nb = Operation.MajTiersOperations(cA, kCbTiersDe.Text, kCbTiersVers.Text);
                MessageBox.Show(nb + " Opération(s) mise(s) à jour.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cont = true;
            }
        }
    }
}
