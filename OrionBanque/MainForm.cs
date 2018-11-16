using OrionBanque.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using ZedGraph;
using OrionBanque.Classe;

namespace OrionBanque
{
    public partial class MainForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        Utilisateur uA;

        #region Variable de Texte
        string alerteEnregistrement = "Fichier Sauvegardé sous {0}";
        string alerteSuppressionCompte = "Etes-vous sur de supprimer ce Compte ? (plus aucun accès aux comptes ne sera possible)";
        string alerteSuppressionOperation = "Etes-vous sur de supprimer cette Opération ?";
        string alerteSuppressionUtilisateur = "Etes-vous sur de supprimer cet Utilisateur ? (plus aucun accès aux comptes ne sera possible)";
        string erreurPasDeCompteCreer = "Vous devez d'abord créer un compte pour accéder à cette fonctionnalité.";
        #endregion

        public MainForm(Utilisateur u)
        {
            uA = u;
            InitializeComponent();
            tsDate.Text = ": " + DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year;

            ApresConnexion();
        }

        private void ApresConnexion()
        {
            tsUser.Text = " : " + uA.Login;

            ChargeComboCompte();

            tsGraphChoix.SelectedItem = tsGraphChoix.Items[0];
            cbFiltreDate.SelectedItem = cbFiltreDate.Items[0];
            cbFiltreMontant.SelectedItem = cbFiltreMontant.Items[0];
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxForm f = new AboutBoxForm();
            f.ShowDialog();
        }
 
        private void TsBtnConnection_Click(object sender, EventArgs e)
        {
            ConnexionForm c = new ConnexionForm();
            c.ShowDialog();
            if (c.cont)
            {
                uA = c.uA;
                ApresConnexion();
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

                ChargeGraph(Compte.Charge((int)cbCompte.SelectedValue));

                if(soldOpePoint > 0)
                {
                    lblSoldPoint.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblSoldPoint.ForeColor = Color.Red;
                }

                if (aVenir > 0)
                {
                    lblAVenir.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblAVenir.ForeColor = Color.Red;
                }

                if (soldFinal > 0)
                {
                    lblSoldFinal.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblSoldFinal.ForeColor = Color.Red;
                }

                if (soldOpePoint <= c.SeuilAlerte)
                {
                    pb.Visible = true;
                    toolTipG.SetToolTip(pb, "Attention, seuil d'alerte (" + c.SeuilAlerte + " €)" + " atteint ou dépassé : " + Math.Round(soldOpePoint,2) + " €");
                }
                else
                {
                    pb.Visible = false;
                }

                if(soldFinal <= c.SeuilAlerteFinal)
                {
                    pbSoldeFinal.Visible = true;
                    toolTipG.SetToolTip(pbSoldeFinal, "Attention, seuil d'alerte (" + c.SeuilAlerteFinal + " €)" + " atteint ou dépassé : " + Math.Round(soldFinal,2) + " €");
                }
                else
                {
                    pbSoldeFinal.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ModeDePaiementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModePaiementForm mp = new ModePaiementForm();
            mp.ShowDialog();
            tsSave.Enabled = true;
        }

        private void TsGestionModePaiement_Click(object sender, EventArgs e)
        {
            ModePaiementForm mp = new ModePaiementForm();
            mp.ShowDialog();
            tsSave.Enabled = true;
        }

        private void CatégoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriesForm c = new CategoriesForm();
            c.ShowDialog();
            tsSave.Enabled = true;
        }

        private void TsGestionCategories_Click(object sender, EventArgs e)
        {
            CategoriesForm c = new CategoriesForm();
            c.ShowDialog();
            tsSave.Enabled = true;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            LanceGestionEcheancier();
        }

        private void gérerLécchéancierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanceGestionEcheancier();
        }

        private void LanceGestionEcheancier()
        {
            try
            {
                if (cbCompte.Items.Count == 0)
                {
                    throw new Exception(erreurPasDeCompteCreer);
                }

                EcheanciersGestForm ec = new EcheanciersGestForm(uA);
                ec.ShowDialog();

                Compte c = Compte.Charge((int)cbCompte.SelectedValue);
                ChargesIndicateurs(c);
                ChargeOperations(c);

                tsSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Utilisateurs
        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            UtilisateurForm ua = new UtilisateurForm();
            ua.ShowDialog();
            tsSave.Enabled = true;
        }

        private void TsModUser_Click(object sender, EventArgs e)
        {
            UtilisateurForm um = new UtilisateurForm(uA);
            um.ShowDialog();
            tsSave.Enabled = true;
        }

        private void TsSupUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(alerteSuppressionUtilisateur, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Utilisateur.Delete(uA);
                    tsSupUser.Enabled = false;
                    tsModUser.Enabled = false;
                    tsmConfiguration.Enabled = false;
                    tsUser.Text = " : ";
                    tsSave.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Comptes
        private void ChargeComboCompte()
        {
            try
            {
                List<Compte> lc = Compte.ChargeTout(uA);
                cbCompte.DisplayMember = "Libelle";
                cbCompte.ValueMember = "Id";

                cbCompte.DataSource = lc;
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
                Compte c = Compte.Charge((int)cbCompte.SelectedValue);
                if(c.TypEvol.Equals(string.Empty))
                {
                    txtEvolSoldeMin.Value = c.MinGraphSold;
                    txtEvolSoldMax.Value = c.MaxGraphSold;
                }
                else
                {
                    DateTime min = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime max = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    switch(c.TypEvol)
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
            finally
            {
                tsNbLigne.Text = ": " + dgvOperations.Rows.Count;
            }
        }

        private void ChargeGraph(Compte c)
        {
            double dYMini = 9999999999.99;
            xGraph.MasterPane = new MasterPane();
            xGraph.Invalidate();

            GraphPane myPane = new GraphPane();

            DateTime dMin = txtEvolSoldeMin.Value;
            DateTime dMax = txtEvolSoldMax.Value;

            List<double> ld = new List<double>();
            List<DateTime> ldt = new List<DateTime>();

            do
            {
                double dTemp = Operation.SoldeCompteAt(dMin, c.Id) + c.SoldeInitial;
                ldt.Add(dMin);
                ld.Add(dTemp);
                if (dTemp < dYMini)
                {
                    dYMini = dTemp;
                }

                dMin = dMin.AddDays(1.0);
            }
            while (dMin <= dMax);

            myPane.Title.IsVisible = true;
            myPane.Title.Text = "Evolution du solde";

            myPane.Fill = new Fill(Color.White, Color.Goldenrod, 45.0f);

            // Make up some data points based on the Sine function
            PointPairList list = new PointPairList();

            int i = 0;
            foreach (DateTime xdt in ldt)
            {
                double x = new XDate(xdt.Year, xdt.Month, xdt.Day);
                double y = ld[i];
                i++;
                list.Add(x, y);
            }

            LineItem myCurve = myPane.AddCurve(string.Empty, list, Color.Red, SymbolType.None);

            // Set the XAxis to date type
            myPane.XAxis.Type = AxisType.Date;
            if (dYMini > 0)
            {
                myPane.YAxis.Scale.Min = 0.0;
            }

            myCurve.Line.Fill = new Fill(Color.White, Color.SteelBlue, 45.0f);

            xGraph.GraphPane = myPane;

            // Leave a small margin around the outside of the control
            xGraph.Size = new Size(xGraph.Size.Width - 5, xGraph.Size.Height - 5);

            // Calculate the Axis Scale Ranges
            xGraph.AxisChange();
        }

        private void AjouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompteForm ca = new CompteForm(uA);
            ca.ShowDialog();
            tsSave.Enabled = true;
            if (ca.cont)
            {
                ChargeComboCompte();
            }
        }

        private void ModifierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCompte.Items.Count == 0)
                {
                    throw new Exception(erreurPasDeCompteCreer);
                }

                CompteForm cm = new CompteForm((int)cbCompte.SelectedValue);
                cm.ShowDialog();
                if (cm.cont)
                {
                    ChargeComboCompte();
                }

                tsSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SupprimerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCompte.Items.Count == 0)
                {
                    throw new Exception(erreurPasDeCompteCreer);
                }

                if (MessageBox.Show(alerteSuppressionCompte, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Compte.Delete((int)cbCompte.SelectedValue);
                    ChargeComboCompte();
                    lblSoldPoint.Text = new double().ToString("#0.00");
                    lblAVenir.Text = new double().ToString("#0.00");
                    lblSoldFinal.Text = new double().ToString("#0.00");
                    tsSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            try
            {
                dgvOperations.DataSource = Operation.ChargeGrilleOperation((int)cbCompte.SelectedValue);
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
                dgvOperations.Columns["Solde"].Visible = false;
                dgvOperations.Sort(dgvOperations.Columns["Date"], System.ComponentModel.ListSortDirection.Descending);
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
            ModifierOperation();
        }

        private void ModifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierOperation();
        }

        private void ModifierOperation()
        {
            try
            {
                if (cbCompte.Items.Count == 0)
                {
                    throw new Exception(erreurPasDeCompteCreer);
                }

                OperationForm om = new OperationForm(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString()), KEY.MODE_UPDATE);
                om.ShowDialog();

                Compte c = Compte.Charge((int)cbCompte.SelectedValue);
                ChargeOperations(c);
                ChargesIndicateurs(c);

                tsSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SupprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupprimerOperation();
        }

        private void SupprimerOperation()
        {
            if (dgvOperations.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(alerteSuppressionOperation, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Operation.Delete(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString()));
                        Compte c = Compte.Charge((int)cbCompte.SelectedValue);
                        ChargeOperations(c);
                        ChargesIndicateurs(c);

                        tsSave.Enabled = true;
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
            bool bDate = false, bModePaiement = false, bTiers = false, bCategorie = false, bMontant = false, bPointe = false;
            if (kFiltreDate.Checked)
            {
                bDate = true;
            }

            if (kFiltreModePaiement.Checked)
            {
                bModePaiement = true;
            }

            if (kFiltreTiers.Checked)
            {
                bTiers = true;
            }

            if (kFiltreCategorie.Checked)
            {
                bCategorie = true;
            }

            if (kFiltreMontant.Checked)
            {
                bMontant = true;
            }

            if (txtFiltrePointe.Checked)
            {
                bPointe = true;
            }

            if (txtFiltreModePaiement.SelectedValue != null)
            {
                try
                {
                    DataSet ds = Operation
                        .ChargeGrilleOperationFiltre((int)cbCompte.SelectedValue,
                                    bDate, cbFiltreDate.SelectedItem.ToString(), txtFiltreDate.Value,
                                    bModePaiement, txtFiltreModePaiement.SelectedValue.ToString(),
                                    bTiers, txtFiltreTiers.Text,
                                    bCategorie, txtFiltreCategorie.SelectedValue.ToString(),
                                    bMontant, cbFiltreMontant.SelectedItem.ToString(), double.Parse(txtFiltreMontant.Value.ToString()),
                                    bPointe);
                    dgvOperations.DataSource = ds;
                    dgvOperations.DataMember = "Operations";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AjouterOperation()
        {
            try
            {
                if(cbCompte.Items.Count == 0)
                {
                    throw new Exception(erreurPasDeCompteCreer);
                }

                OperationForm oa = new OperationForm((int)cbCompte.SelectedValue, "INSERT");
                oa.ShowDialog();

                Compte c = Compte.Charge((int)cbCompte.SelectedValue);
                ChargesIndicateurs(c);
                ChargeOperations(c);

                tsSave.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjouterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AjouterOperation();
        }

        private void ModifierToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModifierOperation();
        }

        private void SupprimerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SupprimerOperation();
        }

        private void TsVirementCaC_Click(object sender, EventArgs e)
        {
            LanceVirementCompteACompte();
        }

        private void virementCompteÀCompteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanceVirementCompteACompte();
        }

        private void LanceVirementCompteACompte()
        {
            try
            {
                if (cbCompte.Items.Count == 0)
                {
                    throw new Exception(erreurPasDeCompteCreer);
                }

                VirementCaCForm oa = new VirementCaCForm(uA);
                oa.ShowDialog();

                Compte c = Compte.Charge((int)cbCompte.SelectedValue);
                ChargesIndicateurs(c);
                ChargeOperations(c);

                tsSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CB
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
                List<ModePaiement> lmp = ModePaiement.ChargeTout();
                txtFiltreModePaiement.DisplayMember = "Libelle";
                txtFiltreModePaiement.ValueMember = "Id";
                txtFiltreModePaiement.DataSource = lmp;
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
                txtFiltreCategorie.DisplayMember = "LibelleIdent";
                txtFiltreCategorie.ValueMember = "Id";
                txtFiltreCategorie.DataSource = lc;
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
                if (cbCompte.SelectedValue != null)
                {
                    List<string> ls = Operation.ChargeToutTiers((int)cbCompte.SelectedValue);
                    txtFiltreTiers.DataSource = ls;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Grtaphique Evolution Solde
        private void TsMontreGraph_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCompte.Items.Count == 0)
                {
                    throw new Exception(erreurPasDeCompteCreer);
                }

                GraphiqueForm g;
                string choix = KEY.GRAPH_TIERS;
                switch (tsGraphChoix.SelectedItem.ToString())
                {
                    case KEY.GRAPH_TIERS_LIB:
                        choix = KEY.GRAPH_TIERS;
                        break;
                    case KEY.GRAPH_CATEGORIES_LIB:
                        choix = KEY.GRAPH_CATEGORIES;
                        break;
                    case KEY.GRAPH_TIERS_DC_LIB:
                        choix = KEY.GRAPH_TIERS_DC;
                        break;
                    case KEY.GRAPH_CATEGORIES_DC_LIB:
                        choix = KEY.GRAPH_CATEGORIES_DC;
                        break;
                }
                g = new GraphiqueForm(choix, (int)cbCompte.SelectedValue);
                g.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnValidDateEvol_Click(object sender, EventArgs e)
        {
            ChargeGraph(Compte.Charge((int)cbCompte.SelectedValue));
        }

        private void KFiltreDate_Click(object sender, EventArgs e)
        {
            LanceFiltreOperation();
        }
        #endregion

        private void EnregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filori = KEY.FILE_PATH;
                    string fildest = folderBrowserDialog.SelectedPath + @"\" + KEY.FILE_NAME;
                    File.Copy(filori, fildest, true);
                    MessageBox.Show(string.Format(alerteEnregistrement, fildest), "Opération Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void TsAjoutOperation_Click(object sender, EventArgs e)
        {
            AjouterOperation();
        }

        private void AjouterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AjouterOperation();
        }

        private void TxtFiltrePointe_CheckedChanged(object sender, EventArgs e)
        {
            LanceFiltreOperation();
        }

        private void GestionOpérationsEnGroupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCompte.Items.Count == 0)
                {
                    throw new Exception(erreurPasDeCompteCreer);
                }

                OperationMajGroupeForm OMG = new OperationMajGroupeForm((int)cbCompte.SelectedValue);
                OMG.ShowDialog();

                tsSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void unFichierCSVBPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OFDImport.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                // Date;ModeDePaiement;PaiementDebitOuCredit;Tiers;Libelle;Categories;Montant;DatePointage
                if (File.Exists(OFDImport.FileName))
                {
                    Compte cT = new Compte
                    {
                        Libelle = Path.GetFileNameWithoutExtension(OFDImport.FileName),
                        SoldeInitial = 0.0,
                        Utilisateur = Utilisateur.Charge(uA.Id),
                        Banque = string.Empty,
                        Guichet = string.Empty,
                        NoCompte = string.Empty,
                        Clef = string.Empty,
                        MinGraphSold = DateTime.Now,
                        MaxGraphSold = DateTime.Now,
                        SeuilAlerte = 0.0,
                        SeuilAlerteFinal = 0.0,
                        TypEvol = KEY.COMPTE_VISU_6MOIS
                    };
                    cT = Compte.Sauve(cT);

                    Outils.ImportBP.Lance(Path.GetDirectoryName(OFDImport.FileName), Path.GetFileNameWithoutExtension(OFDImport.FileName), OFDImport.FileName, cT);
                    ChargeComboCompte();

                    tsSave.Enabled = true;
                }
                Cursor = Cursors.Default;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tsSave.Enabled)
            {
                if (MessageBox.Show("Souhaitez-vous sauvegarder avant de quitter ?", "Sauvegarde", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OB ob = (OB)CallContext.GetData(KEY.OB);
                    Outils.GestionFichier.Sauvegarde(
                        KEY.FILE_PATH,
                        ob
                    );
                }
            }
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            LanceSauvegarde();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                LanceSauvegarde();
            }
        }

        private void LanceSauvegarde()
        {
            OB ob = (OB)CallContext.GetData(KEY.OB);
            Outils.GestionFichier.Sauvegarde(KEY.FILE_PATH, ob);
            tsSave.Enabled = false;
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Compte c = Compte.Charge((int)cbCompte.SelectedValue);
                Outils.GestionFichier.ExportCSV(folderBrowserDialog.SelectedPath + @"\" + c.Libelle + ".csv", ((DataSet)dgvOperations.DataSource).Tables["Operations"]);
            }
        }

        private void fichierJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filedest = folderBrowserDialog.SelectedPath + @"\" + Classe.KEY.FILE_NAME + ".json";
                    Outils.GestionFichier.ExportJson(filedest);
                    MessageBox.Show(string.Format(alerteEnregistrement, filedest), "Opération Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void fichierXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filedest = folderBrowserDialog.SelectedPath + @"\" + KEY.FILE_NAME + ".xml";
                    Outils.GestionFichier.ExportXml(filedest);
                    MessageBox.Show(string.Format(alerteEnregistrement, filedest), "Opération Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void totalDesComptesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalComptesForm f = new TotalComptesForm(uA);
            f.ShowDialog();
        }
    }
}