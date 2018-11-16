using System;
using System.Collections.Generic;
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

            // S'il existe un utilisateur, la création ne sera possible que si on est connecté
            if (Utilisateur.ChargeTout().Count != 0)
            {
                btnAddCompte.Visible = false;
            }
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

        private void kBtnSupprimeFichier_Click(object sender, EventArgs e)
        {
            Outils.GestionFichier.Delete(KEY.FILE_PATH);
            Sql.InitialiseBD(System.IO.Path.GetDirectoryName(KEY.FILE_PATH));
            btnAddCompte.Visible = true;
            kBtnSupprimeFichier.Visible = false;
        }
    }
}
