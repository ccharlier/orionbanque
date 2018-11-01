using System;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class Connexion : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public Classe.Utilisateur uA;
        public bool cont = false;

        public Connexion()
        {
            InitializeComponent();

            // S'il existe un utilisateur, la création ne sera possible que si on est connecté
            if (Classe.Utilisateur.ChargeTout().Count != 0)
            {
                btnAddCompte.Visible = false;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (ValideForm())
            {
                try
                {
                    Classe.Utilisateur u = Classe.Utilisateur.Charge(txtLogin.Text.Trim());
                    if (!u.Id.Equals(0))
                    {
                        if (!u.Mdp.Equals(txtMdp.Text.Trim()))
                            MessageBox.Show("Mauvais Login/Mot de passe.");
                        else
                        {
                            uA = u;
                            cont = true;
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mauvais Login/Mot de passe.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                MessageBox.Show("Merci de remplir tous les champs.");

            return retour;
        }

        private void BtnAddCompte_Click(object sender, EventArgs e)
        {
            Forms.Utilisateur ua = new Forms.Utilisateur();
            ua.ShowDialog();

            // S'il existe un utilisateur, la création ne sera possible que si on est connecté
            if (Classe.Utilisateur.ChargeTout().Count != 0)
            {
                btnAddCompte.Visible = false;
            }
        }
    }
}
