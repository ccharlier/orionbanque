using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrionBanque.Classe;

namespace OrionBanque.Forms
{
    public partial class VirementCaCForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Utilisateur uA;

        public VirementCaCForm(Utilisateur uP)
        {
            uA = uP;
            InitializeComponent();
            ChargeComboCompte();
            RemplisCategories();
            txtDateMvt.CalendarTodayDate = DateTime.Now;
        }

        private void ChargeComboCompte()
        {
            try
            {
                List<Compte> lc = Compte.ChargeTout(uA);
                cbCompteOri.DisplayMember = "libelle";
                cbCompteOri.ValueMember = "id";
                cbCompteOri.DataSource = lc;

                List<Compte> lc2 = Compte.ChargeTout(uA);
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
                List<Categorie> lc = Categorie.ChargeToutIdent();
                txtCategorie.DisplayMember = "LibelleIdent";
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
            Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if(cbCompteOri.SelectedValue.Equals(cbCompteDest.SelectedValue))
            {
                MessageBox.Show("Veuillez sélectionner des comptes différents", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Operation op1 = new Operation
            {
                Date = txtDateMvt.Value.Date,
                Categorie = Categorie.Charge(int.Parse(txtCategorie.SelectedValue.ToString())),
                Compte = Compte.Charge(int.Parse(cbCompteOri.SelectedValue.ToString())),
                ModePaiement = ModePaiement.Charge(4),
                Libelle = txtLibelle.Text,
                Montant = double.Parse(txtMontant.Value.ToString()),
                Tiers = string.Empty,
                TypeLien = KEY.TYPE_LIEN_OPERATION_TRANSFERT
            };
            op1 = Operation.Sauve(op1);
            
            Operation op2 = new Operation
            {
                Date = txtDateMvt.Value.Date,
                Categorie = Categorie.Charge(int.Parse(txtCategorie.SelectedValue.ToString())),
                Compte = Compte.Charge(int.Parse(cbCompteDest.SelectedValue.ToString())),
                ModePaiement = ModePaiement.Charge(5),
                Libelle = txtLibelle.Text,
                Montant = double.Parse(txtMontant.Value.ToString()),
                Tiers = string.Empty,
                TypeLien = KEY.TYPE_LIEN_OPERATION_TRANSFERT,
                IdOperationLiee = op1.Id
            };
            op2 = Operation.Sauve(op2);
            op1.IdOperationLiee = op2.Id;
            op1 = Operation.Maj(op1);

            Close();
         }

        private void CbCompteOri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Compte c = Compte.Charge((int)cbCompteOri.SelectedValue);
            lblTotOri.Text = string.Format("{0,12:0,0.00}", c.SoldeOperationPointee()) + " €";
        }

        private void CbCompteDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            Compte c = Compte.Charge((int)cbCompteDest.SelectedValue);
            lblTotDest.Text = string.Format("{0,12:0,0.00}", c.SoldeOperationPointee()) + " €";
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            if(((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                CategoriesForm fm = new CategoriesForm();
                fm.ShowDialog();
                RemplisCategories();
            }
        }
    }
}
