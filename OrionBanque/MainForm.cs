using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using ZedGraph;

namespace OrionBanque
{
    public partial class MainForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        Classe.Utilisateur uA;

        #region Variable de Texte
        string alerteEnregistrement = "Fichier Sauvegardé sous {0}";
        string alerteSuppressionCompte = "Etes-vous sur de supprimer ce Compte ? (plus aucun accès aux comptes ne sera possible)";
        string alerteSuppressionOperation = "Etes-vous sur de supprimer cette Opération ?";
        string alerteSuppressionUtilisateur = "Etes-vous sur de supprimer cet Utilisateur ? (plus aucun accès aux comptes ne sera possible)";
        
        string erreurPasDeCompteCreer = "Vous devez d'abord créer un compte pour accéder à cette fonctionnalité.";
        #endregion

        public MainForm(Classe.Utilisateur u)
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
            Forms.AboutBox f = new Forms.AboutBox();
            f.ShowDialog();
        }
 
        private void TsBtnConnection_Click(object sender, EventArgs e)
        {
            Forms.Connexion c = new Forms.Connexion();
            c.ShowDialog();
            if (c.cont)
            {
                uA = c.uA;
                ApresConnexion();
            }
        }

        private void ChargesIndicateurs(Classe.Compte c)
        {
            try
            {
                double soldOpePoint = Classe.Operation.CalculSoldOpePoint(c);
                double aVenir = Classe.Operation.CalculAVenir(c);
                double soldFinal = soldOpePoint + aVenir;

                lblSoldPoint.Text = String.Format("{0,12:0,0.00}", soldOpePoint) + " €";
                lblAVenir.Text = String.Format("{0,12:0,0.00}", aVenir) + " €";
                lblSoldFinal.Text = String.Format("{0,12:0,0.00}", soldFinal) + " €";

                ChargeGraph(Classe.Compte.Charge((Int32)cbCompte.SelectedValue));

                if(soldOpePoint > 0)
                    lblSoldPoint.ForeColor = Color.DarkGreen;
                else
                    lblSoldPoint.ForeColor = Color.Red;

                if(aVenir > 0)
                    lblAVenir.ForeColor = Color.DarkGreen;
                else
                    lblAVenir.ForeColor = Color.Red;

                if(soldFinal > 0)
                    lblSoldFinal.ForeColor = Color.DarkGreen;
                else
                    lblSoldFinal.ForeColor = Color.Red;

                if(soldOpePoint <= c.SeuilAlerte)
                {
                    pb.Visible = true;
                    this.toolTipG.SetToolTip(this.pb, "Attention, seuil d'alerte (" + c.SeuilAlerte + " €)" + " atteint ou dépassé : " + Math.Round(soldOpePoint,2) + " €");
                }
                else
                {
                    pb.Visible = false;
                }

                if(soldFinal <= c.SeuilAlerteFinal)
                {
                    pbSoldeFinal.Visible = true;
                    this.toolTipG.SetToolTip(this.pbSoldeFinal, "Attention, seuil d'alerte (" + c.SeuilAlerteFinal + " €)" + " atteint ou dépassé : " + Math.Round(soldFinal,2) + " €");
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
            Forms.ModePaiement mp = new Forms.ModePaiement();
            mp.ShowDialog();
            tsSave.Enabled = true;
        }

        private void TsGestionModePaiement_Click(object sender, EventArgs e)
        {
            Forms.ModePaiement mp = new Forms.ModePaiement();
            mp.ShowDialog();
            tsSave.Enabled = true;
        }

        private void CatégoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Categories c = new Forms.Categories();
            c.ShowDialog();
            tsSave.Enabled = true;
        }

        private void TsGestionCategories_Click(object sender, EventArgs e)
        {
            Forms.Categories c = new Forms.Categories();
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

                Forms.EcheanciersGest ec = new Forms.EcheanciersGest(uA);
                ec.ShowDialog();

                Classe.Compte c = Classe.Compte.Charge((Int32)cbCompte.SelectedValue);
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
            Forms.Utilisateur ua = new Forms.Utilisateur();
            ua.ShowDialog();
            tsSave.Enabled = true;
        }

        private void TsModUser_Click(object sender, EventArgs e)
        {
            Forms.Utilisateur um = new Forms.Utilisateur(uA);
            um.ShowDialog();
            tsSave.Enabled = true;
        }

        private void TsSupUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(alerteSuppressionUtilisateur, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Classe.Utilisateur.Delete(uA);
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
                List<Classe.Compte> lc = Classe.Compte.ChargeTout(uA);
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
                Classe.Compte c = Classe.Compte.Charge((Int32)cbCompte.SelectedValue);
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
                        case Classe.KEY.COMPTE_VISU_1MOIS:
                            max = max.AddMonths(1);
                            break;
                        case Classe.KEY.COMPTE_VISU_3MOIS:
                            max = max.AddMonths(1);
                            min = min.AddMonths(-2);
                            break;
                        case Classe.KEY.COMPTE_VISU_6MOIS:
                            max = max.AddMonths(1);
                            min = min.AddMonths(-5);
                            break;
                        case Classe.KEY.COMPTE_VISU_1AN:
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

        private void ChargeGraph(Classe.Compte c)
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
                double dTemp = Classe.Operation.SoldeCompteAt(dMin, c.Id) + c.SoldeInitial;
                ldt.Add(dMin);
                ld.Add(dTemp);
                if (dTemp < dYMini)
                    dYMini = dTemp;
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
                double x = (double)new XDate(xdt.Year, xdt.Month, xdt.Day);
                double y = ld[i];
                i++;
                list.Add(x, y);
            }

            LineItem myCurve = myPane.AddCurve(string.Empty, list, Color.Red, SymbolType.None);

            // Set the XAxis to date type
            myPane.XAxis.Type = AxisType.Date;
            if (dYMini > 0)
                myPane.YAxis.Scale.Min = 0.0;

            myCurve.Line.Fill = new Fill(Color.White, Color.SteelBlue, 45.0f);

            xGraph.GraphPane = myPane;

            // Leave a small margin around the outside of the control
            xGraph.Size = new Size(xGraph.Size.Width - 5, xGraph.Size.Height - 5);

            // Calculate the Axis Scale Ranges
            xGraph.AxisChange();
        }

        private void AjouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Compte ca = new Forms.Compte(uA);
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
                    throw new Exception(erreurPasDeCompteCreer);

                Forms.Compte cm = new Forms.Compte((int)cbCompte.SelectedValue);
                cm.ShowDialog();
                if (cm.cont)
                    ChargeComboCompte();

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
                    throw new Exception(erreurPasDeCompteCreer);

                if (MessageBox.Show(alerteSuppressionCompte, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Classe.Compte.Delete((Int32)cbCompte.SelectedValue);
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
        private void ChargeOperations(Classe.Compte c)
        {
            kFiltreDate.Checked = false;
            kFiltreModePaiement.Checked = false;
            kFiltreTiers.Checked = false;
            kFiltreCategorie.Checked = false;
            kFiltreMontant.Checked = false;

            try
            {
                dgvOperations.DataSource = Classe.Operation.ChargeGrilleOperation((Int32)cbCompte.SelectedValue);
                dgvOperations.DataMember = "Operations";
                dgvOperations.Columns["Id"].Visible = false;
                dgvOperations.Columns["ModePaiementType"].Visible = false;
                dgvOperations.Columns["Montant Débit"].DefaultCellStyle.Format = "c";
                dgvOperations.Columns["Montant Débit"].DefaultCellStyle.ForeColor = Color.Red;
                dgvOperations.Columns["Montant Crédit"].DefaultCellStyle.Format = "c";
                dgvOperations.Columns["DatePointage"].DefaultCellStyle.Format = "d";
                dgvOperations.Columns["DatePointage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvOperations.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOperations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*foreach (DataGridViewRow r in dgvOperations.Rows)
            {
                if (Convert.ToString(r.Cells["ModePaiementType"].Value) == Classe.KEY.MODEPAIEMENT_DEBIT)
                {
                    r.Cells["Montant"].Style.ForeColor = Color.Red;
                    r.Cells["Montant"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    r.Cells["Montant"].Style.ForeColor = Color.Black;
                    r.Cells["Montant"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }*/
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
                    throw new Exception(erreurPasDeCompteCreer);

                Forms.Operation om = new Forms.Operation(Int32.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString()), "UPDATE");
                om.ShowDialog();

                Classe.Compte c = Classe.Compte.Charge((Int32)cbCompte.SelectedValue);
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
                        Classe.Operation.Delete(Int32.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString()));
                        Classe.Compte c = Classe.Compte.Charge((Int32)cbCompte.SelectedValue);
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
                bDate = true;
            if (kFiltreModePaiement.Checked)
                bModePaiement = true;
            if (kFiltreTiers.Checked)
                bTiers = true;
            if (kFiltreCategorie.Checked)
                bCategorie = true;
            if (kFiltreMontant.Checked)
                bMontant = true;
            if(txtFiltrePointe.Checked)
                bPointe = true;
            if (txtFiltreModePaiement.SelectedValue != null)
            {
                try
                {
                    DataSet ds = Classe
                        .Operation
                        .ChargeGrilleOperationFiltre((Int32)cbCompte.SelectedValue,
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
                    throw new Exception(erreurPasDeCompteCreer);

                Forms.Operation oa = new Forms.Operation((Int32)cbCompte.SelectedValue, "INSERT");
                oa.ShowDialog();

                Classe.Compte c = Classe.Compte.Charge((Int32)cbCompte.SelectedValue);
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
            try
            {
                if(cbCompte.Items.Count == 0)
                    throw new Exception(erreurPasDeCompteCreer);

                Forms.VirementCaC oa = new Forms.VirementCaC(uA);
                oa.ShowDialog();

                Classe.Compte c = Classe.Compte.Charge((Int32)cbCompte.SelectedValue);
                ChargesIndicateurs(c);
                ChargeOperations(c);

                tsSave.Enabled = true;
            }
            catch(Exception ex)
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
                List<Classe.ModePaiement> lmp = Classe.ModePaiement.ChargeTout();
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
                List<Classe.Categorie> lc = Classe.Categorie.ChargeToutIdent();
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
                    List<String> ls = Classe.Operation.ChargeToutTiers((Int32)cbCompte.SelectedValue);
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
                    throw new Exception(erreurPasDeCompteCreer);

                Forms.Graphique g;
                if (tsGraphChoix.SelectedItem.ToString() == "Par Tiers")
                {
                    g = new Forms.Graphique("tiers", (Int32)cbCompte.SelectedValue);
                    g.ShowDialog();
                }
                if (tsGraphChoix.SelectedItem.ToString() == "Par Catégories")
                {
                    g = new Forms.Graphique("categories", (Int32)cbCompte.SelectedValue);
                    g.ShowDialog();
                }
                if (tsGraphChoix.SelectedItem.ToString() == "Par Tiers Dissociés")
                {
                    g = new Forms.Graphique("tiersDC", (Int32)cbCompte.SelectedValue);
                    g.ShowDialog();
                }
                if (tsGraphChoix.SelectedItem.ToString() == "Par Catégories Dissociées")
                {
                    g = new Forms.Graphique("categoriesDC", (Int32)cbCompte.SelectedValue);
                    g.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnValidDateEvol_Click(object sender, EventArgs e)
        {
            ChargeGraph(Classe.Compte.Charge((Int32)cbCompte.SelectedValue));
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
                    // TODO: Enregistrer sous MainForm
                    /*string filori = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\orionbanque.s3db";
                    string fildest = folderBrowserDialog.SelectedPath + @"orionbanque.s3db";
                    File.Copy(filori, fildest, true);
                    MessageBox.Show(String.Format(alerteEnregistrement, fildest), "Opération Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);*/
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

                Forms.OperationMajGroupe OMG = new Forms.OperationMajGroupe((Int32)cbCompte.SelectedValue);
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
                this.Cursor = Cursors.WaitCursor;
                // Date;ModeDePaiement;PaiementDebitOuCredit;Tiers;Libelle;Categories;Montant;DatePointage
                if (File.Exists(OFDImport.FileName))
                {
                    Classe.Compte cT = new Classe.Compte
                    {
                        Libelle = Path.GetFileNameWithoutExtension(OFDImport.FileName),
                        SoldeInitial = 0.0,
                        Utilisateur = Classe.Utilisateur.Charge(uA.Id),
                        Banque = string.Empty,
                        Guichet = string.Empty,
                        NoCompte = string.Empty,
                        Clef = string.Empty,
                        MinGraphSold = DateTime.Now,
                        MaxGraphSold = DateTime.Now,
                        SeuilAlerte = 0.0,
                        SeuilAlerteFinal = 0.0,
                        TypEvol = Classe.KEY.COMPTE_VISU_6MOIS
                    };
                    cT = Classe.Compte.Sauve(cT);

                    Outils.ImportBP.Lance(Path.GetDirectoryName(OFDImport.FileName), Path.GetFileNameWithoutExtension(OFDImport.FileName), OFDImport.FileName, cT);
                    ChargeComboCompte();

                    tsSave.Enabled = true;
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tsSave.Enabled)
            {
                if (MessageBox.Show("Souhaitez-vous sauvegarder avant de quitter ?", "Sauvegarde", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                    Outils.GestionFichier.Sauvegarde(
                        Classe.KEY.FILE_PATH,
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
            Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
            Outils.GestionFichier.Sauvegarde(Classe.KEY.FILE_PATH, ob);
            tsSave.Enabled = false;
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Classe.Compte c = Classe.Compte.Charge((int)cbCompte.SelectedValue);
                Outils.GestionFichier.ExportCSV(folderBrowserDialog.SelectedPath + @"\" + c.Libelle + ".csv", ((DataSet)dgvOperations.DataSource).Tables["Operations"]);
            }
        }
    }
}