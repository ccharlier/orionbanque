using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class OperationMajGroupeForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private int idC = 0;

        public OperationMajGroupeForm(int idP)
        {
            idC = idP;
            InitializeComponent();
            RemplisCb();
        }

        private void RemplisCb()
        {
            RemplisCategories();
        }

        private void RemplisCategories()
        {
            try
            {
                List<Categorie> lc = Categorie.ChargeToutIdent();
                txtCategorieOri.DisplayMember = "Libelle";
                txtCategorieOri.ValueMember = "Id";
                txtCategorieOri.DataSource = lc;

                List<Categorie> lc2 = Categorie.ChargeToutIdent();
                txtCategorieDest.DisplayMember = "Libelle";
                txtCategorieDest.ValueMember = "Id";
                txtCategorieDest.DataSource = lc2;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnValidCat_Click(object sender, EventArgs e)
        {
            Compte c = Compte.Charge(idC);
            string text = string.Format("Etes-vous sure de vouloir transférer toutes les opérations du compte \"{0}\" de \"{1}\" vers \"{2}\"", c.Libelle, txtCategorieOri.Text, txtCategorieDest.Text );
            if(MessageBox.Show(text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Operation.MajCategorieOperations(idC, (int)txtCategorieOri.SelectedValue, (int)txtCategorieDest.SelectedValue);
            }
        }
    }
}
