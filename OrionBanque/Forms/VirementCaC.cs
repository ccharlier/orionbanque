using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class VirementCaC : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Classe.Utilisateur uA;

        public VirementCaC(Classe.Utilisateur uP)
        {
            uA = uP;
            InitializeComponent();
            ChargeComboCompte();
            RemplisCategories();
        }

        private void ChargeComboCompte()
        {
            try
            {
                List<Classe.Compte> lc = Classe.Compte.ChargeTout(uA);
                cbCompteOri.DisplayMember = "libelle";
                cbCompteOri.ValueMember = "id";
                cbCompteOri.DataSource = lc;

                List<Classe.Compte> lc2 = Classe.Compte.ChargeTout(uA);
                cbCompteDest.DisplayMember = "libelle";
                cbCompteDest.ValueMember = "id";
                cbCompteDest.DataSource = lc2;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemplisCategories()
        {
            try
            {
                List<Classe.Categorie> lc = Classe.Categorie.ChargeToutIdent();
                txtCategorie.DisplayMember = "Libelle";
                txtCategorie.ValueMember = "Id";
                txtCategorie.DataSource = lc;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if(cbCompteOri.SelectedValue.Equals(cbCompteDest.SelectedValue))
            {
                MessageBox.Show("Veuillez sélectionner des comptes différents", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Classe.Operation op1 = new OrionBanque.Classe.Operation
            {
                Date = txtDateMvt.Value,
                Categorie = Classe.Categorie.Charge(Int32.Parse(txtCategorie.SelectedValue.ToString())),
                Compte = Classe.Compte.Charge(Int32.Parse(cbCompteOri.SelectedValue.ToString())),
                ModePaiement = Classe.ModePaiement.Charge(4),
                Libelle = txtLibelle.Text,
                Montant = Double.Parse(txtMontant.Value.ToString()),
                Tiers = string.Empty
            };
            Classe.Operation.Sauve(op1);

            op1.Compte = Classe.Compte.Charge(Int32.Parse(cbCompteDest.SelectedValue.ToString()));
            op1.ModePaiement = Classe.ModePaiement.Charge(5);
            Classe.Operation.Sauve(op1);

            this.Close();
         }

        private void CbCompteOri_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTotOri.Text = String.Format("{0,12:0,0.00}", Classe.Operation.CalculSoldOpePoint(Int32.Parse(cbCompteOri.SelectedValue.ToString()))) + " €";
        }

        private void CbCompteDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTotDest.Text = String.Format("{0,12:0,0.00}", Classe.Operation.CalculSoldOpePoint(Int32.Parse(cbCompteDest.SelectedValue.ToString()))) + " €";
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            if(((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Forms.Categories fm = new Forms.Categories();
                fm.ShowDialog();
                RemplisCategories();
            }
        }
    }
}
