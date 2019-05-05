using System;
using OrionBanque.Classe;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class CategoriesForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        #region Variable de Texte
        string alerteSuppressionCategorie = "Etes-vous sur de supprimer cette Catégorie ?";
        #endregion

        public CategoriesForm()
        {
            InitializeComponent();
            ChargeCombo();
        }

        private void ChargeCombo()
        {
            tvCategorie.Nodes.Clear();
            
                List<Categorie> lc = Categorie.ChargeTout();
                List<Categorie> lct = new List<Categorie>();
                foreach (Categorie c in lc)
                {
                    if (c.CategorieParent.Id.Equals(0))
                    {
                        lct.Add(c);
                        TreeNode tn = new TreeNode(c.Libelle)
                        {
                            Name = c.Id.ToString(System.Globalization.CultureInfo.CurrentCulture)
                        };
                        foreach (Categorie ctemp in lc)
                        {
                            if (ctemp.CategorieParent.Id == c.Id)
                            {
                                TreeNode tne = new TreeNode(ctemp.Libelle)
                                {
                                    Name = ctemp.Id.ToString(System.Globalization.CultureInfo.CurrentCulture)
                                };
                                tn.Nodes.Add(tne);
                            }
                        }

                        tvCategorie.Nodes.Add(tn);
                    }
                }

                cbCategorieParent.DisplayMember = "libelle";
                cbCategorieParent.ValueMember = "id";
                cbCategorieParent.DataSource = lct;

                cbModCatPa.DisplayMember = "libelle";
                cbModCatPa.ValueMember = "id";
                cbModCatPa.DataSource = lct;
        }

        private void BtnSupCat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(alerteSuppressionCategorie, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Categorie.Delete(Categorie.Charge(int.Parse(tvCategorie.SelectedNode.Name, System.Globalization.CultureInfo.CurrentCulture)));
                ChargeCombo();
            }
        }

        private void BtnSauvCat_Click(object sender, EventArgs e)
        {
            Categorie c = new Categorie
            {
                Libelle = txtLibelleAdd.Text.Trim()
            };
            if (kCkbCategorieParentAjout.Checked)
            {
                c.CategorieParent = Categorie.Charge((int)cbCategorieParent.SelectedValue);
            }
            else
            {
                c.CategorieParent = new Categorie();
            }

            Categorie.Sauve(c);
            ChargeCombo();
            txtLibelleAdd.Text = string.Empty;
        }

        private void BtnValidMod_Click(object sender, EventArgs e)
        {
            Categorie c = Categorie.Charge(int.Parse(tvCategorie.SelectedNode.Name, System.Globalization.CultureInfo.CurrentCulture));
            c.Libelle = txtLibelleMod.Text.Trim();
            if (kCkbCategorieParentMajSup.Checked)
            {
                c.CategorieParent = Categorie.Charge((int)cbModCatPa.SelectedValue);
            }
            else
            {
                c.CategorieParent = new Categorie();
            }

            Categorie.Maj(c);

            ChargeCombo();
        }

        private void KryptonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            cbCategorieParent.Enabled = kCkbCategorieParentAjout.Checked;
        }

        private void KryptonCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            cbModCatPa.Enabled = kCkbCategorieParentMajSup.Checked;
        }

        private void TvCategorie_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Categorie c = Categorie.Charge(int.Parse(tvCategorie.SelectedNode.Name, System.Globalization.CultureInfo.CurrentCulture));
            txtLibelleMod.Text = c.Libelle;
            if (c.CategorieParent.Id.Equals(0))
            {
                kCkbCategorieParentMajSup.Checked = false;
            }
            else
            {
                kCkbCategorieParentMajSup.Checked = true;
                cbModCatPa.SelectedValue = c.CategorieParent.Id;
            }
        }
    }
}
