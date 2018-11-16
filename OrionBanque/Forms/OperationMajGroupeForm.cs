using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class OperationMajGroupeForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Int32 idC = 0;

        public OperationMajGroupeForm(Int32 idP)
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
                List<Classe.Categorie> lc = Classe.Categorie.ChargeToutIdent();
                txtCategorieOri.DisplayMember = "Libelle";
                txtCategorieOri.ValueMember = "Id";
                txtCategorieOri.DataSource = lc;

                List<Classe.Categorie> lc2 = Classe.Categorie.ChargeToutIdent();
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
            Classe.Compte c = Classe.Compte.Charge(idC);
            string text = String.Format("Etes-vous sure de vouloir transférer toutes les opérations du compte \"{0}\" de \"{1}\" vers \"{2}\"", c.Libelle, txtCategorieOri.Text, txtCategorieDest.Text );
            if(MessageBox.Show(text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Classe.Operation.MajCategorieOperations(idC, (Int32)txtCategorieOri.SelectedValue, (Int32)txtCategorieDest.SelectedValue);
            }
        }
    }
}
