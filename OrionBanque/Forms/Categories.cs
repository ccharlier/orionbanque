using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class Categories : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        #region Variable de Texte
        string alerteSuppressionCategorie = "Etes-vous sur de supprimer cette Catégorie ?";
        #endregion

        public Categories()
        {
            InitializeComponent();
            ChargeCombo();
        }

        private void ChargeCombo()
        {
            tvCategorie.Nodes.Clear();
            try
            {
                List<Classe.Categorie> lc = Classe.Categorie.ChargeTout();
                List<Classe.Categorie> lct = new List<OrionBanque.Classe.Categorie>();
                foreach (Classe.Categorie c in lc)
                {
                    if (c.CategorieParent.Id.Equals(0))
                    {
                        lct.Add(c);
                        TreeNode tn = new TreeNode(c.Libelle)
                        {
                            Name = c.Id.ToString()
                        };
                        foreach (Classe.Categorie ctemp in lc)
                        {
                            if (ctemp.CategorieParent.Id == c.Id)
                            {
                                TreeNode tne = new TreeNode(ctemp.Libelle)
                                {
                                    Name = ctemp.Id.ToString()
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSupCat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(alerteSuppressionCategorie, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Classe.Categorie.Delete(Int32.Parse(tvCategorie.SelectedNode.Name));
                    ChargeCombo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSauvCat_Click(object sender, EventArgs e)
        {
            try
            {
                Classe.Categorie c = new Classe.Categorie
                {
                    Libelle = txtLibelleAdd.Text.Trim()
                };
                if (kryptonCheckBox1.Checked)
                {
                    c.CategorieParent = Classe.Categorie.Charge((Int32)cbCategorieParent.SelectedValue);
                }
                else
                {
                    c.CategorieParent = new Classe.Categorie();
                }

                Classe.Categorie.Sauve(c);

                ChargeCombo();

                txtLibelleAdd.Text = string.Empty;
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
                Classe.Categorie c = Classe.Categorie.Charge(Int32.Parse(tvCategorie.SelectedNode.Name));
                c.Libelle = txtLibelleMod.Text.Trim();
                if (kryptonCheckBox2.Checked)
                {
                    c.CategorieParent = Classe.Categorie.Charge((Int32)cbModCatPa.SelectedValue);
                }
                else
                {
                    c.CategorieParent = new Classe.Categorie();
                }

                Classe.Categorie.Maj(c);

                ChargeCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KryptonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            cbCategorieParent.Enabled = kryptonCheckBox1.Checked;
        }

        private void KryptonCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            cbModCatPa.Enabled = kryptonCheckBox2.Checked;
        }

        private void TvCategorie_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                Classe.Categorie c = Classe.Categorie.Charge(Int32.Parse(tvCategorie.SelectedNode.Name));
                txtLibelleMod.Text = c.Libelle;
                if (c.CategorieParent.Id.Equals(0))
                {
                    kryptonCheckBox2.Checked = false;
                }
                else
                {
                    kryptonCheckBox2.Checked = true;
                    cbModCatPa.SelectedValue = c.CategorieParent.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
