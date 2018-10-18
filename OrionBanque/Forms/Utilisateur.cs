using System;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class Utilisateur : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Classe.Utilisateur uA;

        public Utilisateur(Classe.Utilisateur u)
        {
            uA = u;
            InitializeComponent();
            txtMdp.Text = uA.Mdp;
            txtLogin.Enabled = true;
            txtLogin.Text = uA.Login;
            txtLogin.Enabled = false;
        }

        public Utilisateur()
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

                        this.Close();
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

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
