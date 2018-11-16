using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class UtilisateurForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Classe.Utilisateur uA;

        public UtilisateurForm(Classe.Utilisateur u)
        {
            uA = u;
            InitializeComponent();
            txtMdp.Text = uA.Mdp;
            txtLogin.Enabled = true;
            txtLogin.Text = uA.Login;
            txtLogin.Enabled = false;
        }

        public UtilisateurForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (ValideForm())
            {
                if (uA != null)
                {
                    try
                    {
                        uA.Mdp = txtMdp.Text.Trim();
                        Classe.Utilisateur.Maj(uA);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        Classe.Utilisateur u = new Classe.Utilisateur
                        {
                            Login = txtLogin.Text.Trim(),
                            Mdp = txtMdp.Text.Trim()
                        };
                        Classe.Utilisateur.Sauve(u);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                Outils.GestionFichier.Sauvegarde(Classe.KEY.FILE_PATH, ob);

                Close();
            }
        }

        private bool ValideForm()
        {
            bool retour = false;
            if (txtMdp.Text.Trim() != string.Empty)
            {
                retour = true;
            }
            else
                MessageBox.Show("Merci de remplir tous les champs.");

            return retour;
        }

        private void ChkPwd_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPwd.Checked)
                showPwd.Text = txtMdp.Text;
            else
                showPwd.Text = string.Empty;
        }
    }
}
