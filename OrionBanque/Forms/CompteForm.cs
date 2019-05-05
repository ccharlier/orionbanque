using System;
using System.Windows.Forms;
using System.Collections.Generic;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class CompteForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Compte cA;
        private Utilisateur uA;
        private bool cont = false;

        public bool Cont { get => cont; set => cont = value; }

        public CompteForm(Compte cP)
        {
            InitializeComponent();
            cA = cP;
            txtLibelle.Text = cA.Libelle;
            txtSoldeInitial.Value = new decimal(cA.SoldeInitial);
            kBanque.Text = cA.Banque;
            kGuichet.Text = cA.Guichet;
            kCompte.Text = cA.NoCompte;
            kClef.Text = cA.Clef;
            txtEvolSoldeMin.Value = cA.MinGraphSold;
            txtEvolSoldMax.Value = cA.MaxGraphSold;
            txtEvolSoldeMin.CalendarTodayDate = DateTime.Now;
            txtEvolSoldMax.CalendarTodayDate = DateTime.Now;
            txtSeuilAlerte.Value = new decimal(cA.SeuilAlerte);
            txtSeuilAlerteFinal.Value = new decimal(cA.SeuilAlerteFinal);
            cbEvolType.Text = cA.TypEvol;
            txtEstDansTotalCompte.Checked = cA.EstDansTotalCompte ?? true;

            if (string.IsNullOrEmpty(cA.TypEvol))
            {
                kRBtnParDate.Checked = true;
            }
            else
            {
                kRBtnAutre.Checked = true;
            }
            DataGridViewComboBoxColumn dgvPaiement = (DataGridViewComboBoxColumn)dgvOperations.Columns["Paiement"];
            List<ModePaiement> lmp = ModePaiement.ChargeTout();
            dgvPaiement.DisplayMember = "Libelle";
            dgvPaiement.ValueMember = "Id";
            dgvPaiement.DataSource = lmp;

            DataGridViewComboBoxColumn dgvCategorie = (DataGridViewComboBoxColumn)dgvOperations.Columns["Categorie"];
            List<Categorie> lmc = Classe.Categorie.ChargeTout();
            dgvCategorie.DisplayMember = "Libelle";
            dgvCategorie.ValueMember = "Id";
            dgvCategorie.DataSource = lmc;
        }

        public CompteForm(Utilisateur u)
        {
            uA = u;
            InitializeComponent();
            kRBtnParDate.Checked = true;

            tabControl1.TabPages.RemoveByKey("tabPage3");
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if(ValideForm())
            {
                if (cA != null)
                {
                    cA.Libelle = txtLibelle.Text.Trim();
                    cA.SoldeInitial = double.Parse(txtSoldeInitial.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture);
                    cA.Banque = kBanque.Text;
                    cA.Guichet = kGuichet.Text;
                    cA.NoCompte = kCompte.Text;
                    cA.Clef = kClef.Text;
                    cA.MinGraphSold = txtEvolSoldeMin.Value;
                    cA.MaxGraphSold = txtEvolSoldMax.Value;
                    cA.SeuilAlerte = double.Parse(txtSeuilAlerte.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture);
                    cA.SeuilAlerteFinal = double.Parse(txtSeuilAlerteFinal.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture);
                    cA.EstDansTotalCompte = txtEstDansTotalCompte.Checked;
                    if (kRBtnAutre.Checked)
                    {
                        cA.TypEvol = cbEvolType.Text;
                    }
                    else
                    {
                        cA.TypEvol = string.Empty;
                    }

                    Compte.Maj(cA);
                    cont = true;
                    Close();
                }
                else if (uA != null)
                {
                    Compte c = new Compte
                    {
                        Libelle = txtLibelle.Text.Trim(),
                        SoldeInitial = double.Parse(txtSoldeInitial.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture),
                        Utilisateur = Utilisateur.Charge(uA.Id),
                        Banque = kBanque.Text,
                        Guichet = kGuichet.Text,
                        NoCompte = kCompte.Text,
                        Clef = kClef.Text,
                        MinGraphSold = txtEvolSoldeMin.Value,
                        MaxGraphSold = txtEvolSoldMax.Value,
                        SeuilAlerte = double.Parse(txtSeuilAlerte.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture),
                        SeuilAlerteFinal = double.Parse(txtSeuilAlerteFinal.Value.ToString(System.Globalization.CultureInfo.CurrentCulture), System.Globalization.CultureInfo.CurrentCulture),
                        EstDansTotalCompte = txtEstDansTotalCompte.Checked
                    };
                    if (kRBtnAutre.Checked)
                    {
                        c.TypEvol = cbEvolType.Text;
                    }
                    else
                    {
                        c.TypEvol = string.Empty;
                    }

                    Compte.Sauve(c);
                    cont = true;
                    Close();
                }
            }
        }

        private bool ValideForm()
        {
            bool retour = false;
            // Libelle du compte obligatoire
            if(!string.IsNullOrEmpty(txtLibelle.Text.Trim()))
            {
                // Controle de la clé RIB ?
                if(!string.IsNullOrEmpty(kBanque.Text.Trim()) && !string.IsNullOrEmpty(kGuichet.Text.Trim()) && !string.IsNullOrEmpty(kCompte.Text.Trim()))
                {
                    if(string.Equals(Outils.RIB.DonneCleRIB(kBanque.Text, kGuichet.Text, kCompte.Text), kClef.Text.Trim(), StringComparison.CurrentCulture))
                    {
                        retour = true;
                    }
                    else
                    {
                        MessageBox.Show("Attention clé RIB fournie (" + kClef.Text + ") non Valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    retour = true;
                }
            }
            else
                MessageBox.Show("Merci de remplir le champ Libelle.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return retour;
        }

        private void KryptonRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CheckEvol();
        }

        private void CheckEvol()
        {
            txtEvolSoldeMin.Enabled = kRBtnParDate.Checked;
            txtEvolSoldMax.Enabled = kRBtnParDate.Checked;
            cbEvolType.Enabled = kRBtnAutre.Checked;
        }

        private void KryptonRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CheckEvol();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            if(OFDImport.ShowDialog() == DialogResult.OK)
            {
                //Date;ModeDePaiement;PaiementDebitOuCredit;Tiers;Libelle;Categories;Montant;DatePointage
                if(System.IO.File.Exists(OFDImport.FileName))
                {
                    //Outils.ImportBP.lance(OFDImport.FileName, cA);

                    System.IO.StreamReader sr;

                    sr = new System.IO.StreamReader(OFDImport.FileName);
                    string contenu;
                    while ((contenu = sr.ReadLine()) != null)
                    {
                        string[] t = contenu.Split(';');
                        dgvOperations.Rows.Add(t[0], t[1], t[2], t[3], t[4], t[5], t[6], t[7]);
                    }
                    sr.Close();
                } 
            }
        }

        private void KryptonButton1_Click(object sender, EventArgs e)
        {
            AideForm ai = new AideForm(OrionAide.TitreImport, OrionAide.TextImport);
            ai.ShowDialog();
        }

        private void DgvOperations_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string p = string.Empty; 
        }

        private void Montant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }
        }
    }
}
