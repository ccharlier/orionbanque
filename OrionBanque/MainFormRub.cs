﻿using System;
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

        public MainFormRub(Utilisateur u, Boolean activeSauvegarde=false)
        {
            uA = u;
            InitializeComponent();

            ApresConnexion();
            txtFiltreDate.CalendarTodayDate = DateTime.Now;
            txtOperationDate.CalendarTodayDate = DateTime.Now;
            ActiveSauvegarde(activeSauvegarde);
        }

        #region Echéancier
        private void KRBtnOperationEcheancier_Click(object sender, EventArgs e)
        {
            LanceGestionEcheancier();
        }

        private void LanceGestionEcheancier()
        {
            if(TestPasDeCompte())
            { 
                new EcheanciersGestForm(uA).ShowDialog();
                ChargesIndicateurs(GetCompteCourant());
                ChargeOperations(GetCompteCourant());
                ActiveSauvegarde();
            }
        }
        #endregion

        #region Utilisateurs
        private void KRBtnConfEditUser_Click(object sender, EventArgs e)
        {
            new UtilisateurForm(uA).ShowDialog();
            ActiveSauvegarde();
        }
        #endregion

        #region Comptes
        private bool TestPasDeCompte()
        {
            if (cbCompte.Items.Count == 0)
            {
                Log.Logger.Warn(KEY.ERREURPASDECOMPTECREE);
                MessageBox.Show(KEY.ERREURPASDECOMPTECREE, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private Compte GetCompteCourant()
        {
            return Compte.Charge((int)cbCompte.SelectedValue);
        }

        private static void ChangeCouleur(Label l, double montant)
        {
            l.ForeColor = montant > 0 ? Color.DarkGreen : Color.Red;
        }

        private void ChangeAlerte(PictureBox picbox, double montant, double seuil)
        {
            if (montant <= seuil)
            {
                picbox.Visible = true;
                toolTipG.SetToolTip(picbox, "Attention, seuil d'alerte (" + seuil + " €)" + " atteint ou dépassé : " + Math.Round(montant, 2) + " €");
            }
            else
            {
                picbox.Visible = false;
            }
        }

        private void ChargesIndicateurs(Compte c)
        {
            double soldOpePoint = c.SoldeOperationPointee();
            double aVenir = c.AVenir();
            double soldFinal = soldOpePoint + aVenir;

            lblSoldPoint.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,12:0,0.00}", soldOpePoint) + " €";
            lblAVenir.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,12:0,0.00}", aVenir) + " €";
            lblSoldFinal.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0,12:0,0.00}", soldFinal) + " €";

            ChargeGraph(c);
            ChangeCouleur(lblSoldPoint, soldOpePoint);
            ChangeCouleur(lblAVenir, aVenir);
            ChangeCouleur(lblSoldFinal, soldFinal);
            ChangeAlerte(pb, soldOpePoint, c.SeuilAlerte);
            ChangeAlerte(pbSoldeFinal, soldFinal, c.SeuilAlerteFinal);
        }

        private void ChargeComboCompte()
        {
            cbCompte.DataSource = Compte.ChargeTout(uA);
            RemplisCb();
        }

        private void CbCompte_SelectedIndexChanged(object sender, EventArgs e)
        {
            Compte c = GetCompteCourant();
            if (string.IsNullOrEmpty(c.TypEvol))
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
                    case KEY.COMPTEVISU1MOIS:
                        max = max.AddMonths(1);
                        break;
                    case KEY.COMPTEVISU3MOIS:
                        max = max.AddMonths(1);
                        min = min.AddMonths(-2);
                        break;
                    case KEY.COMPTEVISU6MOIS:
                        max = max.AddMonths(1);
                        min = min.AddMonths(-5);
                        break;
                    case KEY.COMPTEVISU1AN:
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

        private void KRBtnCompteAdd_Click(object sender, EventArgs e)
        {
            CompteForm ca = new CompteForm(uA);
            ca.ShowDialog();
            if (ca.Cont)
            {
                ActiveSauvegarde();
                ChargeComboCompte();
            }
        }

        private void KRBtnCompteEdit_Click(object sender, EventArgs e)
        {
            if (TestPasDeCompte())
            {
                CompteForm cm = new CompteForm(GetCompteCourant());
                cm.ShowDialog();
                if (cm.Cont)
                {
                    ChargeComboCompte();
                    ActiveSauvegarde();
                }
            }
        }

        private void KRBtnCompteDelete_Click(object sender, EventArgs e)
        {
            if (TestPasDeCompte())
            {
                if (MessageBox.Show(KEY.ALERTESUPPRESSIONCOMPTE, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Compte.Delete(GetCompteCourant());
                    dgvOperations.DataSource = null;
                    lblSoldPoint.Text = new double().ToString("#0.00", System.Globalization.CultureInfo.CurrentCulture) + " €";
                    lblAVenir.Text = new double().ToString("#0.00", System.Globalization.CultureInfo.CurrentCulture) + " €";
                    lblSoldFinal.Text = new double().ToString("#0.00", System.Globalization.CultureInfo.CurrentCulture) + " €";
                    ChargeComboCompte();
                    ActiveSauvegarde();
                }
            }
        }

        private void KRBtnCompteTotCompte_Click(object sender, EventArgs e)
        {
            TotalComptesForm f = new TotalComptesForm(uA);
            f.ShowDialog();
            if (f.Cont)
            {
                ActiveSauvegarde();
            }
        }

        private void KRQATBSaveAs_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string fildest = folderBrowserDialog.SelectedPath + @"\" + KEY.FILENAME;
                File.Copy((string)CallContext.GetData(KEY.CLEFICHIER), fildest, true);
                MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, KEY.ALERTEENREGISTREMENT, fildest), "Opération Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

        private void DgvOperations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == dgvOperations.Columns["Montant Débit"].Index || e.ColumnIndex == dgvOperations.Columns["Montant Crédit"].Index) && e.Value != null)
            {
                DataGridViewCell cell = dgvOperations.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Solde : " + dgvOperations.Rows[e.RowIndex].Cells["Solde"].Value.ToString();
            }
        }

        private void DgvOperations_DoubleClick(object sender, EventArgs e)
        {
            OuvreFormOperation(Operation.Charge(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString(), System.Globalization.CultureInfo.CurrentCulture)), KEY.MODEUPDATE);
        }

        private void KRBtnOperationEdit_Click(object sender, EventArgs e)
        {
            OuvreFormOperation(Operation.Charge(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString(), System.Globalization.CultureInfo.CurrentCulture)), KEY.MODEUPDATE);
        }

        private void KRBtnOperationDelete_Click(object sender, EventArgs e)
        {
            SupprimerOperation();
        }

        private void SupprimerOperation()
        {
            if (dgvOperations.SelectedRows.Count > 0)
            {
                string text = dgvOperations.SelectedRows.Count == 1 ? KEY.ALERTESUPPRESSIONOPERATION : KEY.ALERTESUPPRESSIONOPERATIONS;
                if (MessageBox.Show(text, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvOperations.SelectedRows)
                    {
                        Operation OpeASup = Operation.Charge((int)row.Cells["Id"].Value);

                        //Contrôle si Operation Liee est un transfert
                        if (OpeASup.TypeLien == KEY.TYPELIENOPERATIONTRANSFERT)
                        {
                            Operation OpeLiee = Operation.Charge(OpeASup.IdOperationLiee);
                            if (MessageBox.Show("Souhaitez-vous également supprimer l'opération liée réglée par " + OpeLiee.ModePaiement.Libelle + " le " + OpeLiee.Date.ToShortDateString() + " du compte " + OpeLiee.Compte.Libelle + " ?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                Operation.Delete(OpeLiee);
                            }
                        }
                        Operation.Delete(OpeASup);
                        dgvOperations.Rows.RemoveAt(row.Index);
                    }
                    ChargesIndicateurs(GetCompteCourant());
                    ActiveSauvegarde();
                }
            }
        }

        private void LanceFiltreOperation()
        {
            if (txtFiltreModePaiement.SelectedValue != null)
            {
                DataSet ds = Operation
                    .ChargeGrilleOperationFiltre(GetCompteCourant(),
                                kFiltreDate.Checked, cbFiltreDate.SelectedItem.ToString(), txtFiltreDate.Value,
                                kFiltreModePaiement.Checked, ModePaiement.Charge((int)txtFiltreModePaiement.SelectedValue),
                                kFiltreTiers.Checked, txtFiltreTiers.Text,
                                kFiltreCategorie.Checked, Categorie.Charge((int)txtFiltreCategorie.SelectedValue),
                                kFiltreMontant.Checked, cbFiltreMontant.SelectedItem.ToString(), double.Parse(txtFiltreMontant.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture),
                                txtFiltrePointe.Checked);
                dgvOperations.DataSource = ds;
                dgvOperations.DataMember = "Operations";
                dgvOperations.Sort(dgvOperations.Columns["ordre"], System.ComponentModel.ListSortDirection.Descending);
            }
        }

        private void OuvreFormOperation(Operation o, string mode)
        {
            if (TestPasDeCompte())
            {
                OperationForm om = new OperationForm(o, GetCompteCourant(), mode);
                om.ShowDialog();
                if (om.Cont)
                {
                    ChargeOperations(GetCompteCourant());
                    ChargesIndicateurs(GetCompteCourant());
                    ActiveSauvegarde();
                }
                RemplisCb();
            }
        }

        private void KRBtnOperationAdd_Click(object sender, EventArgs e)
        {
            OuvreFormOperation(new Operation(), KEY.MODEINSERT);
        }

        private void AjouterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OuvreFormOperation(new Operation(), KEY.MODEINSERT);
        }

        private void ModifierToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OuvreFormOperation(Operation.Charge(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString(), System.Globalization.CultureInfo.CurrentCulture)), KEY.MODEUPDATE);
        }

        private void SupprimerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SupprimerOperation();
        }

        private void KRBtnOperationVirCaC_Click(object sender, EventArgs e)
        {
            if (TestPasDeCompte())
            {
                new VirementCaCForm(uA).ShowDialog();
                Compte c = GetCompteCourant();
                ChargesIndicateurs(c);
                ChargeOperations(c);
                ActiveSauvegarde();
                RemplisCb();
            }
        }

        private void KRBtnOperationPointe_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvOperations.SelectedRows)
            {
                Operation otemp = Operation.Charge((int)row.Cells["Id"].Value);
                if (otemp.DatePointage is null)
                {
                    otemp.DatePointage = DateTime.Now;
                    Operation.Maj(otemp);
                    row.Cells["DatePointage"].Value = DateTime.Now;

                    //Contrôle si Operation Liee est un transfert
                    if (otemp.TypeLien == KEY.TYPELIENOPERATIONTRANSFERT)
                    {
                        Operation OpeLiee = Operation.Charge(otemp.IdOperationLiee);
                        if (MessageBox.Show("Souhaitez-vous également pointer l'opération liée réglée par " + OpeLiee.ModePaiement.Libelle + " le " + OpeLiee.Date.ToShortDateString() + " du compte " + OpeLiee.Compte.Libelle + " ?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            OpeLiee.DatePointage = DateTime.Now;
                            Operation.Maj(OpeLiee);
                        }
                    }
                }
            }
            if (dgvOperations.SelectedRows.Count != 0)
            {
                ChargesIndicateurs(GetCompteCourant());
                ActiveSauvegarde();
            }
        }

        private void KRBtnOperationMajGrp_Click(object sender, EventArgs e)
        {
            if (TestPasDeCompte())
            {
                OperationMajGroupeForm OMG = new OperationMajGroupeForm(GetCompteCourant());
                OMG.ShowDialog();

                if (OMG.Cont)
                {
                    ActiveSauvegarde();
                }
            }
        }

        private void DgvOperations_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            tsNbLigne.Text = ": " + dgvOperations.Rows.Count;
        }

        private void TxtFiltrePointe_CheckedChanged(object sender, EventArgs e)
        {
            LanceFiltreOperation();
        }
        
        private void KFiltreModePaiement_Click(object sender, EventArgs e)
        {
            LanceFiltreOperation();
        }

        private void KFiltreTiers_Click(object sender, EventArgs e)
        {
            LanceFiltreOperation();
        }

        private void KFiltreCategorie_Click(object sender, EventArgs e)
        {
            LanceFiltreOperation();
        }

        private void KFiltreMontant_Click(object sender, EventArgs e)
        {
            LanceFiltreOperation();
        }

        private void KFiltreDate_Click(object sender, EventArgs e)
        {
            LanceFiltreOperation();
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Outils.GestionFichier.ExportCSV(folderBrowserDialog.SelectedPath + @"\" + GetCompteCourant().Libelle + ".csv", ((DataSet)dgvOperations.DataSource).Tables["Operations"]);
            }
        }

        private void KCMJson_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string filedest = folderBrowserDialog.SelectedPath + @"\" + KEY.FILENAME + ".json";
                Outils.GestionFichier.ExportJson(filedest);
                MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, KEY.ALERTEENREGISTREMENT, filedest), "Opération Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void KCMXml_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string filedest = folderBrowserDialog.SelectedPath + @"\" + KEY.FILENAME + ".xml";
                Outils.GestionFichier.ExportXml(filedest);
                MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, KEY.ALERTEENREGISTREMENT, filedest), "Opération Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void KCMFichierBP_Click(object sender, EventArgs e)
        {
            ImportFichierCSV ifCSV = new ImportFichierCSV(uA);
            ifCSV.ShowDialog();
            if (ifCSV.Cont)
            {
                ChargeComboCompte();
                ActiveSauvegarde();
            }
        }

        private void DgvOperations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOperations.SelectedRows.Count != 0)
            {
                Operation o = Operation.Charge(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString(), System.Globalization.CultureInfo.CurrentCulture));

                txtOperationDate.Value = o.Date;
                txtOperationCategorie.SelectedValue = o.Categorie.Id;
                txtOperationLibelle.Text = o.Libelle;
                txtOperationTiers.Text = o.Tiers;
                txtOperationModePaiement.SelectedValue = o.ModePaiement.Id;
                txtOperationMontant.Value = new decimal(o.Montant);
                txtOperationPointage.Checked = o.DatePointage == null ? false : true;
            }
        }

        private void TxtFiltreMontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }

            if (e.KeyChar == Convert.ToChar(Keys.Return, System.Globalization.CultureInfo.CurrentCulture) && ((KryptonNumericUpDown)sender).Name == "txtOperationMontant")
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
                Montant = double.Parse(txtOperationMontant.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture),
                DatePointage = txtOperationPointage.Checked ? (DateTime?)DateTime.Now : null
            };

            return Operation.Sauve(o);
        }

        private Operation ModifieOperation(Compte c)
        {
            Operation o = Operation.Charge(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString(), System.Globalization.CultureInfo.CurrentCulture));
            o.Compte = c;
            o.Date = txtOperationDate.Value;
            o.Categorie = Categorie.Charge((int)txtOperationCategorie.SelectedValue);
            o.Libelle = txtOperationLibelle.Text;
            o.Tiers = txtOperationTiers.Text;
            o.ModePaiement = ModePaiement.Charge((int)txtOperationModePaiement.SelectedValue);
            o.Montant = double.Parse(txtOperationMontant.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture);
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

        private void BtnOperationValide_MouseDown(object sender, MouseEventArgs e)
        {
            Operation o = e.Button == MouseButtons.Right ? ModifieOperation(GetCompteCourant()) : CreateOperation(GetCompteCourant());
            ChargesIndicateurs(GetCompteCourant());
            ChargeOperations(GetCompteCourant());
            SelectRowOperation(o.Id);
            ActiveSauvegarde();
            ActiveControl = txtOperationDate;
        }

        private void BtnOperationValide_Click(object sender, EventArgs e)
        {
            Operation o = CreateOperation(GetCompteCourant());
            ChargesIndicateurs(GetCompteCourant());
            ChargeOperations(GetCompteCourant());
            SelectRowOperation(o.Id);
            ActiveSauvegarde();
            ActiveControl = txtOperationDate;
        }
        #endregion

        #region ComboBox
        private void KRBtnConfMdP_Click(object sender, EventArgs e)
        {
            new ModePaiementForm().ShowDialog();
            ActiveSauvegarde();
            RemplisModePaiements();
        }

        private void KRBtnConfCategorie_Click(object sender, EventArgs e)
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
            txtFiltreModePaiement.DataSource = ModePaiement.ChargeTout();
            txtOperationModePaiement.DataSource = ModePaiement.ChargeTout();
        }

        private void RemplisCategories()
        {
            txtFiltreCategorie.DataSource = Categorie.ChargeToutIdent();
            txtOperationCategorie.DataSource = Categorie.ChargeToutIdent();
        }

        private void RemplisTiers()
        {
            if (TestPasDeCompte())
            {
                txtFiltreTiers.DataSource = null;
                txtOperationTiers.DataSource = null;
                txtFiltreTiers.DataSource = Tiers.ChargeTout();
                txtOperationTiers.DataSource = Tiers.ChargeTout();
            }
        }

        private void KRBtnConfTiers_Click(object sender, EventArgs e)
        {
            GestTiersForm gtf = new GestTiersForm(uA);
            gtf.ShowDialog();
            if (gtf.BMustSave)
            {
                ActiveSauvegarde();
            }
            RemplisTiers();
        }
        #endregion

        #region Graphique
        private void KRBtnCompteGraph_Click(object sender, EventArgs e)
        {
            if (TestPasDeCompte())
            {
                new ChartForm(GetCompteCourant()).ShowDialog();
            }
        }

        private void BtnValidDateEvol_Click_1(object sender, EventArgs e)
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

        #region Gestion Config Général
        private void AppliqueConfig()
        {
            OB ob = (OB)CallContext.GetData(KEY.OB);
            kRGBtnPredictTiers.Checked = ob.PredictTiers ?? true;
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
            RemplisTiers();
        }

        private void SauveTheme(string theme)
        {
            OB ob = (OB)CallContext.GetData(KEY.OB);
            ob.Theme = theme;
            CallContext.SetData(KEY.OB, ob);
            ActiveSauvegarde();
            AppliqueConfig();
        }

        private void KRBtnConfThemeOffice2010Bleu_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteOffice2010Blue");
        }

        private void KRBtnConfThemeOffice2010Noir_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteOffice2010Black");
        }

        private void KRBtnConfThemeOffice2010Argent_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteOffice2010Silver");
        }

        private void KRBtnConfThemeSparkleBleu_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteSparkleBlue");
        }

        private void KRBtnConfThemeSparkleViolet_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteSparklePurple");
        }

        private void KRBtnConfThemeSparkleOrange_Click(object sender, EventArgs e)
        {
            SauveTheme("kryptonPaletteSparkleOrange");
        }

        private void KRGBtnPredictTiers_Click(object sender, EventArgs e)
        {
            OB ob = (OB)CallContext.GetData(KEY.OB);
            ob.PredictTiers = kRGBtnPredictTiers.Checked;
            CallContext.SetData(KEY.OB, ob);
            ActiveSauvegarde();
            AppliqueConfig();
        }
        #endregion

        #region Sauvegarde
        private void KRQATBSave_Click(object sender, EventArgs e)
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
            ChargeComboCompte();
            AppliqueConfig();
            tsDateJour.Text = " : " + DateTime.Now.Day.ToString("00", System.Globalization.CultureInfo.CurrentCulture) + "/" + DateTime.Now.Month.ToString("00", System.Globalization.CultureInfo.CurrentCulture) + "/" + DateTime.Now.Year;
            tsUser.Text = " : " + uA.Login;
            cbFiltreDate.SelectedItem = cbFiltreDate.Items[0];
            cbFiltreMontant.SelectedItem = cbFiltreMontant.Items[0];
        }

        private void BtnSpecAbout_Click(object sender, EventArgs e)
        {
            new AboutBoxForm().ShowDialog();
        }

        private void KCMChgFichier_Click(object sender, EventArgs e)
        {
            ConnexionForm c = new ConnexionForm();
            c.ShowDialog();
            if (c.Cont)
            {
                uA = c.UA;
                ApresConnexion();
            }
        }

        private void KCMQuitter_Click(object sender, EventArgs e)
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

        private void KRBtnOperationFileView_Click(object sender, EventArgs e)
        {
            new FichiersForm().ShowDialog();
        }
    }
}
