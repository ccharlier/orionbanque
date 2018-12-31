using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using OrionBanque.Classe;
using OrionBanque.Forms;
using Operation = OrionBanque.Classe.Operation;

namespace OrionBanque
{
    public partial class MainFormRub : KryptonForm
    {
        Utilisateur uA;

        public MainFormRub(Utilisateur u)
        {
            uA = u;
            InitializeComponent();

            ApresConnexion();
            txtFiltreDate.CalendarTodayDate = DateTime.Now;
            txtOperationDate.CalendarTodayDate = DateTime.Now;
        }

        #region Echéancier
        private void kRBtnOperationEcheancier_Click(object sender, EventArgs e)
        {
            LanceGestionEcheancier();
        }

        private void LanceGestionEcheancier()
        {
            try
            {
                TestPasDeCompte();
                new EcheanciersGestForm(uA).ShowDialog();
                ChargesIndicateurs(GetCompteCourant());
                ChargeOperations(GetCompteCourant());
                ActiveSauvegarde();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Utilisateurs
        private void kRBtnConfEditUser_Click(object sender, EventArgs e)
        {
            new UtilisateurForm(uA).ShowDialog();
            ActiveSauvegarde();
        }
        #endregion

        #region Comptes
        private void TestPasDeCompte()
        {
            if (cbCompte.Items.Count == 0)
            {
                throw new Exception(KEY.ERREUR_PAS_DE_COMPTE_CREE);
            }
        }

        private Compte GetCompteCourant()
        {
            return Compte.Charge((int)cbCompte.SelectedValue);
        }

        private void ChangeCouleur(Label l, double montant)
        {
            l.ForeColor = montant > 0 ? Color.DarkGreen : Color.Red;
        }

        private void ChangeAlerte(PictureBox picbox, double montant, double seuil)
        {
            if (montant <= seuil)
            {
                picbox.Visible = true;
                toolTipG.SetToolTip(pb, "Attention, seuil d'alerte (" + seuil + " €)" + " atteint ou dépassé : " + Math.Round(montant, 2) + " €");
            }
            else
            {
                picbox.Visible = false;
            }
        }

        private void ChargesIndicateurs(Compte c)
        {
            try
            {
                double soldOpePoint = c.SoldeOperationPointee();
                double aVenir = c.AVenir();
                double soldFinal = soldOpePoint + aVenir;

                lblSoldPoint.Text = string.Format("{0,12:0,0.00}", soldOpePoint) + " €";
                lblAVenir.Text = string.Format("{0,12:0,0.00}", aVenir) + " €";
                lblSoldFinal.Text = string.Format("{0,12:0,0.00}", soldFinal) + " €";

                ChargeGraph(c);
                ChangeCouleur(lblSoldPoint, soldOpePoint);
                ChangeCouleur(lblAVenir, aVenir);
                ChangeCouleur(lblSoldFinal, soldFinal);
                ChangeAlerte(pb, soldOpePoint, c.SeuilAlerte);
                ChangeAlerte(pb, soldFinal, c.SeuilAlerteFinal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargeComboCompte()
        {
            try
            {
                cbCompte.DataSource = Compte.ChargeTout(uA);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RemplisCb();
        }

        private void CbCompte_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Compte c = GetCompteCourant();
                if (c.TypEvol.Equals(string.Empty))
                {
                    txtEvolSoldeMin.Value = c.MinGraphSold;
                    txtEvolSoldMax.Value = c.MaxGraphSold;
                }
                else
                {
                    DateTime min = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime max = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    switch (c.TypEvol)
                    {
                        case KEY.COMPTE_VISU_1MOIS:
                            max = max.AddMonths(1);
                            break;
                        case KEY.COMPTE_VISU_3MOIS:
                            max = max.AddMonths(1);
                            min = min.AddMonths(-2);
                            break;
                        case KEY.COMPTE_VISU_6MOIS:
                            max = max.AddMonths(1);
                            min = min.AddMonths(-5);
                            break;
                        case KEY.COMPTE_VISU_1AN:
                            max = max.AddMonths(1);
                            min = min.AddMonths(-11);
                            break;
                    }
                    txtEvolSoldeMin.Value = min;
                    txtEvolSoldMax.Value = max;
                }
                ChargeOperations(c);
                ChargesIndicateurs(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kRBtnCompteAdd_Click(object sender, EventArgs e)
        {
            CompteForm ca = new CompteForm(uA);
            ca.ShowDialog();
            if (ca.cont)
            {
                ActiveSauvegarde();
                ChargeComboCompte();
            }
        }

        private void kRBtnCompteEdit_Click(object sender, EventArgs e)
        {
            try
            {
                TestPasDeCompte();
                CompteForm cm = new CompteForm(GetCompteCourant());
                cm.ShowDialog();
                if (cm.cont)
                {
                    ChargeComboCompte();
                    ActiveSauvegarde();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kRBtnCompteDelete_Click(object sender, EventArgs e)
        {
            try
            {
                TestPasDeCompte();
                if (MessageBox.Show(KEY.ALERTE_SUPPRESSION_COMPTE, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Compte.Delete(GetCompteCourant());
                    dgvOperations.DataSource = null;
                    lblSoldPoint.Text = new double().ToString("#0.00") + " €";
                    lblAVenir.Text = new double().ToString("#0.00") + " €";
                    lblSoldFinal.Text = new double().ToString("#0.00") + " €";
                    ChargeComboCompte();
                    ActiveSauvegarde();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kRBtnCompteTotCompte_Click(object sender, EventArgs e)
        {
            TotalComptesForm f = new TotalComptesForm(uA);
            f.ShowDialog();
            if (f.cont)
            {
                ActiveSauvegarde();
            }

        }

        private void kRQATBSaveAs_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fildest = folderBrowserDialog.SelectedPath + @"\" + KEY.FILE_NAME;
                    File.Copy((string)CallContext.GetData(KEY.CLE_FICHIER), fildest, true);
                    MessageBox.Show(string.Format(KEY.ALERTE_ENREGISTREMENT, fildest), "Opération Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
            }
        }
        #endregion

        #region Operations
        private void ChargeOperations(Compte c)
        {
            kFiltreDate.Checked = false;
            kFiltreModePaiement.Checked = false;
            kFiltreTiers.Checked = false;
            kFiltreCategorie.Checked = false;
            kFiltreMontant.Checked = false;
            txtFiltrePointe.Checked = false;
            try
            {
                dgvOperations.DataSource = Operation.ChargeGrilleOperation(c);
                dgvOperations.DataMember = "Operations";
                dgvOperations.Columns["Id"].Visible = false;
                dgvOperations.Columns["ModePaiementType"].Visible = false;
                dgvOperations.Columns["Montant Débit"].DefaultCellStyle.Format = "c";
                dgvOperations.Columns["Montant Débit"].DefaultCellStyle.ForeColor = Color.Red;
                dgvOperations.Columns["Montant Débit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOperations.Columns["Montant Crédit"].DefaultCellStyle.Format = "c";
                dgvOperations.Columns["Montant Crédit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOperations.Columns["DatePointage"].DefaultCellStyle.Format = "d";
                dgvOperations.Columns["DatePointage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvOperations.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvOperations.Columns["Solde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOperations.Sort(dgvOperations.Columns["ordre"], System.ComponentModel.ListSortDirection.Descending);
                dgvOperations.Columns["ordre"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOperations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == dgvOperations.Columns["Montant Débit"].Index || e.ColumnIndex == dgvOperations.Columns["Montant Crédit"].Index) && e.Value != null)
            {
                DataGridViewCell cell = dgvOperations.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Solde : " + dgvOperations.Rows[e.RowIndex].Cells["Solde"].Value.ToString();
            }
        }

        private void DgvOperations_DoubleClick(object sender, EventArgs e)
        {
            OuvreFormOperation(Operation.Charge(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString())), KEY.MODE_UPDATE);
        }

        private void kRBtnOperationEdit_Click(object sender, EventArgs e)
        {
            OuvreFormOperation(Operation.Charge(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString())), KEY.MODE_UPDATE);
        }

        private void kRBtnOperationDelete_Click(object sender, EventArgs e)
        {
            SupprimerOperation();
        }

        private void SupprimerOperation()
        {
            if (dgvOperations.SelectedRows.Count > 0)
            {
                string text = dgvOperations.SelectedRows.Count == 1 ? KEY.ALERTE_SUPPRESSION_OPERATION : KEY.ALERTE_SUPPRESSION_OPERATIONS;
                if (MessageBox.Show(text, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvOperations.SelectedRows)
                        {
                            Operation.Delete(Operation.Charge((int)row.Cells["Id"].Value));
                            dgvOperations.Rows.RemoveAt(row.Index);
                        }
                        ChargesIndicateurs(GetCompteCourant());
                        ActiveSauvegarde();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LanceFiltreOperation()
        {
            if (txtFiltreModePaiement.SelectedValue != null)
            {
                try
                {
                    DataSet ds = Operation
                        .ChargeGrilleOperationFiltre(GetCompteCourant(),
                                    kFiltreDate.Checked, cbFiltreDate.SelectedItem.ToString(), txtFiltreDate.Value,
                                    kFiltreModePaiement.Checked, ModePaiement.Charge((int)txtFiltreModePaiement.SelectedValue),
                                    kFiltreTiers.Checked, txtFiltreTiers.Text,
                                    kFiltreCategorie.Checked, Categorie.Charge((int)txtFiltreCategorie.SelectedValue),
                                    kFiltreMontant.Checked, cbFiltreMontant.SelectedItem.ToString(), double.Parse(txtFiltreMontant.Value.ToString()),
                                    txtFiltrePointe.Checked);
                    dgvOperations.DataSource = ds;
                    dgvOperations.DataMember = "Operations";
                    dgvOperations.Sort(dgvOperations.Columns["ordre"], System.ComponentModel.ListSortDirection.Descending);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OuvreFormOperation(Operation o, string mode)
        {
            try
            {
                TestPasDeCompte();
                OperationForm om = new OperationForm(o, GetCompteCourant(), mode);
                om.ShowDialog();
                if (om.cont)
                {
                    ChargeOperations(GetCompteCourant());
                    ChargesIndicateurs(GetCompteCourant());
                    ActiveSauvegarde();
                }
                RemplisCb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kRBtnOperationAdd_Click(object sender, EventArgs e)
        {
            OuvreFormOperation(new Operation(), KEY.MODE_INSERT);
        }

        private void ajouterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OuvreFormOperation(new Operation(), KEY.MODE_INSERT);
        }

        private void modifierToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OuvreFormOperation(Operation.Charge(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString())), KEY.MODE_UPDATE);
        }

        private void supprimerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SupprimerOperation();
        }

        private void kRBtnOperationVirCaC_Click(object sender, EventArgs e)
        {
            try
            {
                TestPasDeCompte();
                new VirementCaCForm(uA).ShowDialog();
                Compte c = GetCompteCourant();
                ChargesIndicateurs(c);
                ChargeOperations(c);
                ActiveSauvegarde();
                RemplisCb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kRBtnOperationPointe_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvOperations.SelectedRows)
            {
                Operation otemp = Operation.Charge((int)row.Cells["Id"].Value);
                if (otemp.DatePointage is null)
                {
                    otemp.DatePointage = DateTime.Now;
                    Operation.Maj(otemp);
                    row.Cells["DatePointage"].Value = DateTime.Now;
                }
            }
            if (dgvOperations.SelectedRows.Count != 0)
            {
                ChargesIndicateurs(GetCompteCourant());
                ActiveSauvegarde();
            }
        }

        private void kRBtnOperationMajGrp_Click(object sender, EventArgs e)
        {
            try
            {
                TestPasDeCompte();
                OperationMajGroupeForm OMG = new OperationMajGroupeForm(GetCompteCourant());
                OMG.ShowDialog();

                if (OMG.cont)
                {
                    ActiveSauvegarde();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOperations_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            tsNbLigne.Text = ": " + dgvOperations.Rows.Count;
        }

        private void TxtFiltrePointe_CheckedChanged(object sender, EventArgs e)
        {
            LanceFiltreOperation();
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Outils.GestionFichier.ExportCSV(folderBrowserDialog.SelectedPath + @"\" + GetCompteCourant().Libelle + ".csv", ((DataSet)dgvOperations.DataSource).Tables["Operations"]);
            }
        }

        private void kCMJson_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filedest = folderBrowserDialog.SelectedPath + @"\" + KEY.FILE_NAME + ".json";
                    Outils.GestionFichier.ExportJson(filedest);
                    MessageBox.Show(string.Format(KEY.ALERTE_ENREGISTREMENT, filedest), "Opération Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void kCMXml_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filedest = folderBrowserDialog.SelectedPath + @"\" + KEY.FILE_NAME + ".xml";
                    Outils.GestionFichier.ExportXml(filedest);
                    MessageBox.Show(string.Format(KEY.ALERTE_ENREGISTREMENT, filedest), "Opération Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void kCMFichierBP_Click(object sender, EventArgs e)
        {
            ImportFichierCSV ifCSV = new ImportFichierCSV(uA);
            ifCSV.ShowDialog();
            if (ifCSV.cont)
            {
                ChargeComboCompte();
                ActiveSauvegarde();
            }
        }

        private void dgvOperations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOperations.SelectedRows.Count != 0)
            {
                Operation o = Operation.Charge(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString()));

                txtOperationDate.Value = o.Date;
                txtOperationCategorie.SelectedValue = o.Categorie.Id;
                txtOperationLibelle.Text = o.Libelle;
                txtOperationTiers.Text = o.Tiers;
                txtOperationModePaiement.SelectedValue = o.ModePaiement.Id;
                txtOperationMontant.Value = new decimal(o.Montant);
                txtOperationPointage.Checked = o.DatePointage == null ? false : true;
            }
        }

        private void txtFiltreMontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }

            if (e.KeyChar == Convert.ToChar(Keys.Return) && ((KryptonNumericUpDown)sender).Name == "txtOperationMontant")
            {
                Compte c = GetCompteCourant();
                Operation o = CreateOperation(c);
                ChargesIndicateurs(c);
                ChargeOperations(c);
                SelectRowOperation(o.Id);
                kRQATBSave.Enabled = true;
                ActiveControl = txtOperationDate;
            }
        }

        private void SelectRowOperation(int Id)
        {
            dgvOperations.Rows[0].Selected = false;
            foreach (DataGridViewRow row in dgvOperations.Rows)
            {
                if (((int)row.Cells["Id"].Value) == Id)
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private Operation CreateOperation(Compte c)
        {
            Operation o = new Operation
            {
                Compte = c,
                Date = txtOperationDate.Value,
                Categorie = Categorie.Charge((int)txtOperationCategorie.SelectedValue),
                Libelle = txtOperationLibelle.Text,
                Tiers = txtOperationTiers.Text,
                ModePaiement = ModePaiement.Charge((int)txtOperationModePaiement.SelectedValue),
                Montant = double.Parse(txtOperationMontant.Value.ToString()),
                DatePointage = txtOperationPointage.Checked ? (DateTime?)DateTime.Now : null
            };

            return Operation.Sauve(o);
        }

        private Operation ModifieOperation(Compte c)
        {
            Operation o = Operation.Charge(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString()));
            o.Compte = c;
            o.Date = txtOperationDate.Value;
            o.Categorie = Categorie.Charge((int)txtOperationCategorie.SelectedValue);
            o.Libelle = txtOperationLibelle.Text;
            o.Tiers = txtOperationTiers.Text;
            o.ModePaiement = ModePaiement.Charge((int)txtOperationModePaiement.SelectedValue);
            o.Montant = double.Parse(txtOperationMontant.Value.ToString());
            if (txtOperationPointage.Checked)
            {
                if (o.DatePointage is null)
                {
                    o.DatePointage = DateTime.Now;
                }
            }
            else
            {
                o.DatePointage = null;
            }
            return Operation.Maj(o);
        }

        private void btnOperationValide_MouseDown(object sender, MouseEventArgs e)
        {
            Operation o = e.Button == MouseButtons.Right ? ModifieOperation(GetCompteCourant()) : CreateOperation(GetCompteCourant());
            ChargesIndicateurs(GetCompteCourant());
            ChargeOperations(GetCompteCourant());
            SelectRowOperation(o.Id);
            ActiveSauvegarde();
            ActiveControl = txtOperationDate;
        }

        private void btnOperationValide_Click(object sender, EventArgs e)
        {
            Operation o = CreateOperation(GetCompteCourant());
            ChargesIndicateurs(GetCompteCourant());
            ChargeOperations(GetCompteCourant());
            SelectRowOperation(o.Id);
            ActiveSauvegarde();
            ActiveControl = txtOperationDate;
        }

        private void KFiltreDate_Click(object sender, EventArgs e)
        {
            LanceFiltreOperation();
        }
        #endregion

        #region CB
        private void kRBtnConfMdP_Click(object sender, EventArgs e)
        {
            new ModePaiementForm().ShowDialog();
            ActiveSauvegarde();
            RemplisModePaiements();
        }

        private void kRBtnConfCategorie_Click(object sender, EventArgs e)
        {
            new CategoriesForm().ShowDialog();
            ActiveSauvegarde();
            RemplisCategories();
        }

        private void RemplisCb()
        {
            RemplisCategories();
            RemplisModePaiements();
            RemplisTiers();
        }

        private void RemplisModePaiements()
        {
            try
            {
                txtFiltreModePaiement.DataSource = ModePaiement.ChargeTout();
                txtOperationModePaiement.DataSource = ModePaiement.ChargeTout();
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
                txtFiltreCategorie.DataSource = Categorie.ChargeToutIdent();
                txtOperationCategorie.DataSource = Categorie.ChargeToutIdent();
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
                TestPasDeCompte();
                txtFiltreTiers.DataSource = Tiers.ChargeTout();
                txtOperationTiers.DataSource = Tiers.ChargeTout();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kRBtnConfTiers_Click(object sender, EventArgs e)
        {
            GestTiersForm gtf = new GestTiersForm(uA);
            gtf.ShowDialog();
            if (gtf.bMustSave)
            {
                ActiveSauvegarde();
            }
            RemplisTiers();
        }
        #endregion

        #region Graphique
        private void kRBtnCompteGraph_Click(object sender, EventArgs e)
        {
            try
            {
                TestPasDeCompte();
                new ChartForm(GetCompteCourant()).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnValidDateEvol_Click_1(object sender, EventArgs e)
        {
            ChargeGraph(GetCompteCourant());
        }

        private void ChargeGraph(Compte c)
        {
            int i = 0;
            DateTime dMin = txtEvolSoldeMin.Value;
            List<double> ld = new List<double>();
            List<DateTime> ldt = new List<DateTime>();

            graph.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            graph.Series[0].Points.Clear();
            do
            {
                ldt.Add(dMin);
                ld.Add(Operation.SoldeCompteAt(dMin, c) + c.SoldeInitial);
                dMin = dMin.AddDays(1.0);
            }
            while (dMin <= txtEvolSoldMax.Value);

            foreach (DateTime xdt in ldt)
            {
                graph.Series[0].Points.AddXY(xdt.ToOADate(), ld[i]);
                i++;
            }
        }
        #endregion

        #region Gestion du Thème
        private void AppliqueTheme()
        {
            OB ob = (OB)CallContext.GetData(KEY.OB);
            switch (ob.Theme)
            {
                case "kryptonPaletteOffice2010Black":
                    kManager.GlobalPalette = kryptonPaletteOffice2010Black;
                    break;
                case "kryptonPaletteOffice2010Blue":
                    kManager.GlobalPalette = kryptonPaletteOffice2010Blue;
                    break;
                case "kryptonPaletteOffice2010Silver":
                    kManager.GlobalPalette = kryptonPaletteOffice2010Silver;
                    break;
                case "kryptonPaletteSparkleBlue":
                    kManager.GlobalPalette = kryptonPaletteSparkleBlue;
                    break;
                case "kryptonPaletteSparkleOrange":
                    kManager.GlobalPalette = kryptonPaletteSparkleOrange;
                    break;
                case "kryptonPaletteSparklePurple":
                    kManager.GlobalPalette = kryptonPaletteSparklePurple;
                    break;
                default:
                    kManager.GlobalPalette = kryptonPaletteOffice2010Silver;
                    break;
            }
        }

        private void SauveTheme(string theme)
        {
            OB ob = (OB)CallContext.GetData(KEY.OB);
            ob.Theme = theme;
            CallContext.SetData(KEY.OB, ob);
            ActiveSauvegarde();
            AppliqueTheme();
        }

        private void kRBtnConfThemeOffice2010Bleu_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteOffice2010Blue");
        }

        private void kRBtnConfThemeOffice2010Noir_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteOffice2010Black");
        }

        private void kRBtnConfThemeOffice2010Argent_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteOffice2010Silver");
        }

        private void kRBtnConfThemeSparkleBleu_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteSparkleBlue");
        }

        private void kRBtnConfThemeSparkleViolet_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteSparklePurple");
        }

        private void kRBtnConfThemeSparkleOrange_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteSparkleOrange");
        }
        #endregion

        #region Sauvegarde
        private void kRQATBSave_Click(object sender, EventArgs e)
        {
            LanceSauvegarde();
        }

        private void LanceSauvegarde()
        {
            Outils.GestionFichier.Sauvegarde();
            ActiveSauvegarde(false);
        }

        private void ActiveSauvegarde(bool etat = true)
        {
            kRQATBSave.Enabled = etat;
        }
        #endregion

        private void ApresConnexion()
        {
            AppliqueTheme();
            ChargeComboCompte();

            tsDateJour.Text = " : " + DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year;
            tsUser.Text = " : " + uA.Login;
            cbFiltreDate.SelectedItem = cbFiltreDate.Items[0];
            cbFiltreMontant.SelectedItem = cbFiltreMontant.Items[0];
        }

        private void btnSpecAbout_Click(object sender, EventArgs e)
        {
            new AboutBoxForm().ShowDialog();
        }

        private void kCMChgFichier_Click(object sender, EventArgs e)
        {
            ConnexionForm c = new ConnexionForm();
            c.ShowDialog();
            if (c.cont)
            {
                uA = c.uA;
                ApresConnexion();
            }
        }

        private void kCMQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kRQATBSave.Enabled)
            {
                if (MessageBox.Show("Souhaitez-vous sauvegarder avant de quitter ?", "Sauvegarde", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Outils.GestionFichier.Sauvegarde();
                }
            }
        }

        private void kRBtnOperationFileView_Click(object sender, EventArgs e)
        {
            new FichiersForm().ShowDialog();
        }
    }
}
