using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class OperationForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        Operation O;
        private Compte compte;
        public bool cont = false;
        private bool PointageModif = false;
        private string mode = string.Empty;

        public OperationForm(Operation oP, Compte cP, string modeP)
        {
            InitializeComponent();

            compte = cP;
            mode = modeP;
            RemplisCb();

            if (mode.Equals(KEY.MODE_INSERT))
            {
                O = new Operation();
                dgvFichiers.Enabled = false;
                btnAddFichier.Enabled = false;
            }
            else if(mode.Equals(KEY.MODE_UPDATE))
            {
                O = oP;
                ChargeDgv();
                ChargeForm();
            }
        }

        private void ChargeDgv()
        {
            dgvFichiers.DataSource = Fichier.ToDataSet(Fichier.ChargeTout(O));
            dgvFichiers.DataMember = "Fichiers";
            dgvFichiers.Columns["Id"].Visible = false;
            dgvFichiers.Columns["Type"].Visible = false;
            dgvFichiers.Columns["Chemin"].Visible = false;
        }

        private void RemplisCb()
        {
            RemplisCategories();
            RemplisModePaiements();
            RemplisTiers();
        }

        private void ChargeForm()
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
                txtTiers.DataSource = Tiers.ChargeTout();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Sauvegarde();
            Close();
        }

        private void Sauvegarde()
        {
            if (O.Id != 0)
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
                        Compte = compte,
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
            if(txtModePaiement.SelectedValue.ToString() == "8" && mode != KEY.MODE_UPDATE)
            {
                txtLibelle.Text = "n°" + Operation.ChercheChequeSuivant(compte);
            }
        }

        private void btnAddFichier_Click(object sender, EventArgs e)
        {
            if (OFDImport.ShowDialog() == DialogResult.OK)
            {
                // Vérification de l'existence du même fichier en cible
                Guid g = Guid.NewGuid();
                Fichier f = new Fichier();
                
                if (File.Exists(OFDImport.FileName))
                {
                    string dirFileOpe = Path.GetDirectoryName((string)CallContext.GetData(KEY.CLE_FICHIER)) + @"\" + KEY.FILE_OPERATION_PATH;
                    f.InitialName = Path.GetFileName(OFDImport.FileName);
                    f.Date = DateTime.Now;
                    f.Chemin = dirFileOpe + g.ToString() + Path.GetExtension(OFDImport.FileName);
                    f.Type = KEY.TYPE_FICHIER_FILE;
                    f.Operation = O;

                    Fichier.Sauve(f);

                    if(!Directory.Exists(Path.GetDirectoryName(f.Chemin)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.Chemin));
                    }

                    File.Copy(OFDImport.FileName, f.Chemin);

                    ChargeDgv();
                }
            }
        }

        private void dgvFichiers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvFichiers.Rows.Count == 0)
                {
                    return;
                }

                string chemin = dgvFichiers.SelectedRows[0].Cells["Chemin"].Value.ToString();
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(chemin, "");
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvFichiers.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Etes-vous certain de vouloir supprimer ce fichier (Fichier importé) ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string chemin = (string)dgvFichiers.SelectedRows[0].Cells["Chemin"].Value;
                    int id = (int)dgvFichiers.SelectedRows[0].Cells["Id"].Value;

                    Fichier.Delete(Fichier.Charge(id));
                    File.Delete(chemin);

                    ChargeDgv();
                }
            }
        }

        private void txtMontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }
        }

        private void kBtnValidStayOpen_Click(object sender, EventArgs e)
        {
            Sauvegarde();
            mode = KEY.MODE_INSERT;
            O = new Operation();

            txtLibelle.Text = string.Empty;
            txtMontant.Value = new decimal(0.0);
            txtTiers.Text = string.Empty;
            ActiveControl = txtDateMvt;
            dgvFichiers.DataSource = null;
            dgvFichiers.Enabled = false;
            btnAddFichier.Enabled = false;
        }
    }
}
