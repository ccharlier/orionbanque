using OrionBanque.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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
        string alerteSuppressionOperations = "Etes-vous sur de vouloir supprimer les Opérations sélectionnées ?";
        string alerteSuppressionOperation = "Etes-vous sur de vouloir supprimer l'Opérations sélectionnée ?";
        string erreurPasDeCompteCree = "Vous devez d'abord créer un compte pour accéder à cette fonctionnalité.";
        #endregion

        public MainForm(Utilisateur u)
        {
            uA = u;
            InitializeComponent();
            tsDateJour.Text = " : " + DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year;

            ApresConnexion();
        }

        #region Echéancier
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
                    throw new Exception(erreurPasDeCompteCree);
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
        #endregion

        #region Utilisateurs
        private void TsModUser_Click(object sender, EventArgs e)
        {
            UtilisateurForm um = new UtilisateurForm(uA);
            um.ShowDialog();
            tsSave.Enabled = true;
        }
        #endregion

        #region Comptes
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

                if (soldOpePoint > 0)
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
                    toolTipG.SetToolTip(pb, "Attention, seuil d'alerte (" + c.SeuilAlerte + " €)" + " atteint ou dépassé : " + Math.Round(soldOpePoint, 2) + " €");
                }
                else
                {
                    pb.Visible = false;
                }

                if (soldFinal <= c.SeuilAlerteFinal)
                {
                    pbSoldeFinal.Visible = true;
                    toolTipG.SetToolTip(pbSoldeFinal, "Attention, seuil d'alerte (" + c.SeuilAlerteFinal + " €)" + " atteint ou dépassé : " + Math.Round(soldFinal, 2) + " €");
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
                double dTemp = Operation.SoldeCompteAt(dMin, c) + c.SoldeInitial;
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
                    throw new Exception(erreurPasDeCompteCree);
                }

                CompteForm cm = new CompteForm(Compte.Charge((int)cbCompte.SelectedValue));
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
                    throw new Exception(erreurPasDeCompteCree);
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

        private void totalDesComptesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalComptesForm f = new TotalComptesForm(uA);
            f.ShowDialog();
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
                    throw new Exception(erreurPasDeCompteCree);
                }

                OperationForm om = new OperationForm(Operation.Charge(int.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString())), Compte.Charge((int)cbCompte.SelectedValue), KEY.MODE_UPDATE);
                om.ShowDialog();

                if(om.cont)
                {
                    Compte c = Compte.Charge((int)cbCompte.SelectedValue);
                    ChargeOperations(c);
                    ChargesIndicateurs(c);

                    tsSave.Enabled = true;
                }
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
                string text = dgvOperations.SelectedRows.Count == 1 ? alerteSuppressionOperation : alerteSuppressionOperations;
                if (MessageBox.Show(text, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataGridViewSelectedRowCollection liste = dgvOperations.SelectedRows;
                        foreach (DataGridViewRow row in liste)
                        {
                            Operation otemp = Operation.Charge((int)row.Cells["Id"].Value);
                            Operation.Delete(otemp);
                            dgvOperations.Rows.RemoveAt(row.Index);
                        }
                        ChargesIndicateurs(Compte.Charge((int)cbCompte.SelectedValue));
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
                        .ChargeGrilleOperationFiltre(Compte.Charge((int)cbCompte.SelectedValue),
                                    bDate, cbFiltreDate.SelectedItem.ToString(), txtFiltreDate.Value,
                                    bModePaiement, ModePaiement.Charge((int)txtFiltreModePaiement.SelectedValue),
                                    bTiers, txtFiltreTiers.Text,
                                    bCategorie, Categorie.Charge((int)txtFiltreCategorie.SelectedValue),
                                    bMontant, cbFiltreMontant.SelectedItem.ToString(), double.Parse(txtFiltreMontant.Value.ToString()),
                                    bPointe);
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

        private void AjouterOperation()
        {
            try
            {
                if(cbCompte.Items.Count == 0)
                {
                    throw new Exception(erreurPasDeCompteCree);
                }

                OperationForm of = new OperationForm(new Operation(), Compte.Charge((int)cbCompte.SelectedValue), "INSERT");
                of.ShowDialog();

                if(of.cont)
                {
                    Compte c = Compte.Charge((int)cbCompte.SelectedValue);
                    ChargesIndicateurs(c);
                    ChargeOperations(c);
                    tsSave.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjouterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AjouterOperation();
        }

        private void TsAjoutOperation_Click(object sender, EventArgs e)
        {
            AjouterOperation();
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
                    throw new Exception(erreurPasDeCompteCree);
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

        private void pointerLesOpérationsSélectionnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LancePointage();
        }

        private void LancePointage()
        {
            DataGridViewSelectedRowCollection liste = dgvOperations.SelectedRows;
            foreach(DataGridViewRow row in liste)
            {
                Operation otemp = Operation.Charge((int)row.Cells["Id"].Value);
                if(otemp.DatePointage is null)
                { 
                    otemp.DatePointage = DateTime.Now;
                    Operation.Maj(otemp);
                    row.Cells["DatePointage"].Value = DateTime.Now;
                }
                
            }
            if(liste.Count != 0)
            {
                //ChargeOperations(Compte.Charge((int)cbCompte.SelectedValue));
                ChargesIndicateurs(Compte.Charge((int)cbCompte.SelectedValue));
                tsSave.Enabled = true;
            }
        }

        private void GestionOpérationsEnGroupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCompte.Items.Count == 0)
                {
                    throw new Exception(erreurPasDeCompteCree);
                }

                OperationMajGroupeForm OMG = new OperationMajGroupeForm(Compte.Charge((int)cbCompte.SelectedValue));
                OMG.ShowDialog();

                if (OMG.cont)
                {
                    tsSave.Enabled = true;
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
                if (o.DatePointage != null)
                {
                    txtOperationPointage.Checked = true;
                }
                else
                {
                    txtOperationPointage.Checked = false;
                }
            }
        }

        private void txtFiltreMontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }
        }

        private void btnOperationValide_MouseDown(object sender, MouseEventArgs e)
        {
            Compte c = Compte.Charge((int)cbCompte.SelectedValue);
            if (e.Button == MouseButtons.Right)
            {
                // Mise à jour de l'Opération sélectionnée 
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
                    if(o.DatePointage is null)
                    {
                        o.DatePointage = DateTime.Now;
                    }
                }
                else
                {
                    o.DatePointage = null;
                }
                Operation.Maj(o);
            }
            if (e.Button == MouseButtons.Left)
            {
                // Création d'une Opération tel que saisie
                Operation o = new Operation();
                o.Compte = c;
                o.Date = txtOperationDate.Value;
                o.Categorie = Categorie.Charge((int)txtOperationCategorie.SelectedValue);
                o.Libelle = txtOperationLibelle.Text;
                o.Tiers = txtOperationTiers.Text;
                o.ModePaiement = ModePaiement.Charge((int)txtOperationModePaiement.SelectedValue);
                o.Montant = double.Parse(txtOperationMontant.Value.ToString());
                if (txtOperationPointage.Checked)
                {
                    o.DatePointage = DateTime.Now;
                }
                else
                {
                    o.DatePointage = null;
                }
                Operation.Sauve(o);
            }
            
            ChargesIndicateurs(c);
            ChargeOperations(c);
            tsSave.Enabled = true;

            this.ActiveControl = txtOperationDate;
        }
        #endregion

        #region CB
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

                List<ModePaiement> lmp2 = ModePaiement.ChargeTout();
                txtOperationModePaiement.DisplayMember = "Libelle";
                txtOperationModePaiement.ValueMember = "Id";
                txtOperationModePaiement.DataSource = lmp;
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

                List<Categorie> lc2 = Categorie.ChargeToutIdent();
                txtOperationCategorie.DisplayMember = "LibelleIdent";
                txtOperationCategorie.ValueMember = "Id";
                txtOperationCategorie.DataSource = lc2;
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
                    txtFiltreTiers.DataSource = Operation.ChargeToutTiers(uA);
                    txtOperationTiers.DataSource = Operation.ChargeToutTiers(uA);
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
                    throw new Exception(erreurPasDeCompteCree);
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
                g = new GraphiqueForm(choix, Compte.Charge((int)cbCompte.SelectedValue));
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

        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tsSave.Enabled)
            {
                if (MessageBox.Show("Souhaitez-vous sauvegarder avant de quitter ?", "Sauvegarde", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Outils.GestionFichier.Sauvegarde();
                }
            }
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            LanceSauvegarde();
        }

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanceSauvegarde();
        }

        private void LanceSauvegarde()
        {
            Outils.GestionFichier.Sauvegarde();
            tsSave.Enabled = false;
        }
    }
}