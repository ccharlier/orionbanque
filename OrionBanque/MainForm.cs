using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            tsDate.Text = DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year;

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
                double soldOpePoint = Classe.Operation.CalculSoldOpePoint(c.Id);
                double aVenir = Classe.Operation.CalculAVenir(c.Id);
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
                } else
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

            } catch(Exception ex)
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
        }

        private void TsGestionModePaiement_Click(object sender, EventArgs e)
        {
            Forms.ModePaiement mp = new Forms.ModePaiement();
            mp.ShowDialog();
        }

        private void CatégoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Categories c = new Forms.Categories();
            c.ShowDialog();
        }

        private void TsGestionCategories_Click(object sender, EventArgs e)
        {
            Forms.Categories c = new Forms.Categories();
            c.ShowDialog();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCompte.Items.Count == 0)
                    throw new Exception(erreurPasDeCompteCreer);

                Forms.EcheanciersGest ec = new Forms.EcheanciersGest((Int32)cbCompte.SelectedValue);
                ec.ShowDialog();

                Classe.Compte c = Classe.Compte.Charge((Int32)cbCompte.SelectedValue);
                ChargesIndicateurs(c);
                ChargeOperations(c);
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
        }

        private void TsModUser_Click(object sender, EventArgs e)
        {
            Forms.Utilisateur um = new Forms.Utilisateur(uA);
            um.ShowDialog();
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
                List<Classe.Compte> lc = Classe.Compte.ChargeTout(uA.Id);
                cbCompte.DisplayMember = "libelle";
                cbCompte.ValueMember = "id";
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
                        case "1 mois": max = max.AddMonths(1); break;
                        case "3 mois": max = max.AddMonths(1); min = min.AddMonths(-2); break;
                        case "6 mois": max = max.AddMonths(1); min = min.AddMonths(-5); break;
                        case "1 an": max = max.AddMonths(1); min = min.AddMonths(-11); break;
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
            } while (dMin <= dMax);

            
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
            xGraph.Size = new Size(this.xGraph.Size.Width - 5, this.xGraph.Size.Height - 5);

            // Calculate the Axis Scale Ranges
            xGraph.AxisChange();
        }

        private void AjouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Compte ca = new Forms.Compte(uA);
            ca.ShowDialog();
            if(ca.cont)
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
                DataSet ds = Classe.Operation.ChargeGrilleOperation((Int32)cbCompte.SelectedValue);
                dgvOperations.DataSource = ds;
                dgvOperations.DataMember = "Operations";
                dgvOperations.Columns[0].Visible = false;
                dgvOperations.Columns[6].DefaultCellStyle.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    throw new Exception(erreurPasDeCompteCreer);

                Forms.Operation om = new Forms.Operation(Int32.Parse(dgvOperations.SelectedRows[0].Cells[0].Value.ToString()), "UPDATE");
                om.ShowDialog();

                Classe.Compte c = Classe.Compte.Charge((Int32)cbCompte.SelectedValue);
                ChargeOperations(c);
                ChargesIndicateurs(c);
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
                txtFiltreCategorie.DisplayMember = "Libelle";
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
                    g = new OrionBanque.Forms.Graphique("tiers", (Int32)cbCompte.SelectedValue);
                    g.ShowDialog();
                }
                if (tsGraphChoix.SelectedItem.ToString() == "Par Catégories")
                {
                    g = new OrionBanque.Forms.Graphique("categories", (Int32)cbCompte.SelectedValue);
                    g.ShowDialog();
                }
                if (tsGraphChoix.SelectedItem.ToString() == "Par Tiers Dissociés")
                {
                    g = new OrionBanque.Forms.Graphique("tiersDC", (Int32)cbCompte.SelectedValue);
                    g.ShowDialog();
                }
                if (tsGraphChoix.SelectedItem.ToString() == "Par Catégories Dissociées")
                {
                    g = new OrionBanque.Forms.Graphique("categoriesDC", (Int32)cbCompte.SelectedValue);
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
                    string filori = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\orionbanque.s3db";
                    string fildest = folderBrowserDialog.SelectedPath + @"orionbanque.s3db";
                    System.IO.File.Copy(filori, fildest, true);
                    MessageBox.Show(String.Format(alerteEnregistrement, fildest), "Opération Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                    throw new Exception(erreurPasDeCompteCreer);

                Forms.OperationMajGroupe OMG = new Forms.OperationMajGroupe((Int32)cbCompte.SelectedValue);
                OMG.ShowDialog();
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
                //Date;ModeDePaiement;PaiementDebitOuCredit;Tiers;Libelle;Categories;Montant;DatePointage
                if (System.IO.File.Exists(OFDImport.FileName))
                {
                    Outils.ImportBP.Lance(OFDImport.FileName, Classe.Compte.Charge((int)cbCompte.SelectedValue));
                    ChargeComboCompte();
                }
                this.Cursor = Cursors.Default;
            }
        }
    }
}