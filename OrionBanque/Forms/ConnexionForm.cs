using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class ConnexionForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public Utilisateur uA;
        public bool cont = false;
        public bool activSauv = false;

        public ConnexionForm()
        {
            InitializeComponent();
            ChargeListe();
        }

        private void ChargeListe()
        {
            List<string> lf = Outils.GestionFichier.ChargeListeFichier();
            kLbFile.Items.Clear();
            kLbFile.Items.AddRange(lf.ToArray());

            bool en = kLbFile.SelectedItems.Count != 0;

            btnAddCompte.Enabled = en;
            OK.Enabled = en;
            txtLogin.Enabled = en;
            txtMdp.Enabled = en;
            kBtnTrashRefFileOB.Enabled = en;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                // Est-ce que le formulaire de connexion est bien rempli
                if (ValideForm())
                {
                    Utilisateur u = Utilisateur.Charge(txtLogin.Text.Trim());
                    // Est-ce que l'utilisateur existe
                    if (!u.Id.Equals(0))
                    {
                        // Est-ce que le mot de passe saisi est correct
                        if (!u.Mdp.Equals(txtMdp.Text.Trim()))
                        {
                            throw new Exception("Mauvais Login/Mot de passe.");
                        }
                        else
                        {
                            uA = u;
                            cont = true;
                            List<string> nbE = Echeancier.InsereEcheanceOpenFile(uA);
                            if(nbE.Count != 0)
                            {
                                MessageBox.Show("Opérations insérées à l'ouverture du fichier : " + Environment.NewLine + string.Join(Environment.NewLine, nbE.ToArray()), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                activSauv = true;
                            }
                            Close();
                        }
                    }
                    else
                    {
                        throw new Exception("Mauvais Login/Mot de passe.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValideForm()
        {
            bool retour = false;
            if (txtLogin.Text.Trim() != string.Empty && txtMdp.Text.Trim() != string.Empty)
            {
                retour = true;
            }
            else
            {
                MessageBox.Show("Merci de remplir tous les champs.");
            }

            return retour;
        }

        private void BtnAddCompte_Click(object sender, EventArgs e)
        {
            UtilisateurForm ua = new UtilisateurForm();
            ua.ShowDialog();

            // S'il existe un utilisateur, la création ne sera possible que si on est connecté
            if (Utilisateur.ChargeTout().Count != 0)
            {
                btnAddCompte.Visible = false;
            }
        }

        private void kBtnOuvrirFichierCompteOB_Click(object sender, EventArgs e)
        {
            if(OFDOrionBanque.ShowDialog() == DialogResult.OK)
            {
                if(File.Exists(OFDOrionBanque.FileName))
                {
                    if(kLbFile.Items.Contains(OFDOrionBanque.FileName))
                    {
                        kLbFile.SelectedItem = OFDOrionBanque.FileName;
                    }
                    else
                    {
                        Outils.GestionFichier.SauveListeFichier(OFDOrionBanque.FileName);
                        ChargeListe();
                        kLbFile.SelectedItem = OFDOrionBanque.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("Le fichier sélectionné n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void kLbFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Outils.GestionFichier.Charge(kLbFile.SelectedItem.ToString());

                bool en = kLbFile.SelectedItems.Count != 0;

                btnAddCompte.Enabled = en;
                OK.Enabled = en;
                txtLogin.Enabled = en;
                txtMdp.Enabled = en;
                
                
                if (Utilisateur.ChargeTout().Count != 0)
                {
                    btnAddCompte.Visible = false;
                }
                else
                {
                    btnAddCompte.Visible = true;
                }
                kBtnTrashRefFileOB.Enabled = true;
            }
            catch(Exception ex)
            {
                btnAddCompte.Enabled = false;
                OK.Enabled = false;
                txtLogin.Enabled = false;
                txtMdp.Enabled = false;
                kBtnTrashRefFileOB.Enabled = true;
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK);
            }
        }

        private void kBtnCreerFichierCompteOB_Click(object sender, EventArgs e)
        {
            if(FBDOrionBanque.ShowDialog() == DialogResult.OK)
            {
                if(Directory.Exists(FBDOrionBanque.SelectedPath))
                {
                    string fileName = FBDOrionBanque.SelectedPath + @"\orionbanque.obq";
                    CallContext.SetData(KEY.CLE_FICHIER, fileName);
                    Sql.InitialiseBD();

                    Outils.GestionFichier.SauveListeFichier(fileName);
                    ChargeListe();
                    kLbFile.SelectedItem = fileName;
                }
            }
        }

        private void kBtnTrashRefFileOB_Click(object sender, EventArgs e)
        {
            List<string> lf = Outils.GestionFichier.ChargeListeFichier();
            lf.Remove(kLbFile.SelectedItem.ToString());
            Outils.GestionFichier.SauveListeFichier(lf);
            ChargeListe();
        }
    }
}
