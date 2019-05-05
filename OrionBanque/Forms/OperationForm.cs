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
        private bool cont = false;
        private bool PointageModif = false;
        private string mode = string.Empty;

        public bool Cont { get => cont; set => cont = value; }

        public OperationForm(Operation oP, Compte cP, string modeP)
        {
            InitializeComponent();
            txtDateMvt.CalendarTodayDate = DateTime.Now;
            compte = cP;
            mode = modeP;
            RemplisCb();

            if (string.Equals(mode, KEY.MODEINSERT, StringComparison.CurrentCulture))
            {
                O = new Operation();
                dgvFichiers.Enabled = false;
                btnAddFichier.Enabled = false;
            }
            else if(string.Equals(mode,KEY.MODEUPDATE, StringComparison.CurrentCulture))
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

        private void OK_Click(object sender, EventArgs e)
        {
            Sauvegarde();
            Close();
        }

        private void Sauvegarde()
        {
            if (O.Id != 0)
            {
                O.Date = txtDateMvt.Value;
                O.Categorie = Categorie.Charge((int)txtCategorie.SelectedValue);
                O.ModePaiement = ModePaiement.Charge((int)txtModePaiement.SelectedValue);
                O.Libelle = txtLibelle.Text;
                O.Montant = double.Parse(txtMontant.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture);
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
            else
            {
                Operation o = new Operation
                {
                    Date = txtDateMvt.Value,
                    Categorie = Categorie.Charge((int)txtCategorie.SelectedValue),
                    Compte = compte,
                    ModePaiement = ModePaiement.Charge((int)txtModePaiement.SelectedValue),
                    Libelle = txtLibelle.Text,
                    Montant = double.Parse(txtMontant.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture),
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
            if(txtModePaiement.SelectedValue.ToString() == "8" && mode != KEY.MODEUPDATE)
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
                    string dirFileOpe = Path.GetDirectoryName((string)CallContext.GetData(KEY.CLEFICHIER)) + @"\" + KEY.FILEOPERATIONPATH;
                    f.InitialName = Path.GetFileName(OFDImport.FileName);
                    f.Date = DateTime.Now;
                    f.Chemin = dirFileOpe + g.ToString() + Path.GetExtension(OFDImport.FileName);
                    f.Type = KEY.TYPEFICHIERFILE;
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
            if (dgvFichiers.Rows.Count == 0)
            {
                return;
            }

            string chemin = dgvFichiers.SelectedRows[0].Cells["Chemin"].Value.ToString();
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(chemin, "");
            System.Diagnostics.Process.Start(psi);
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
            mode = KEY.MODEINSERT;
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
