namespace OrionBanque.Forms
{
    partial class ModePaiementForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kCbDiffere = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnSupModePaiement = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dgvModePaiements = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnValid = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kLblHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbDebCred = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kGbOptionsDiffere = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kNudPeriodeDebut = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtDecaleJourFerie = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.txtDecaleDimanche = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.txtDecaleSamedi = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kNudDecalage = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kCbTypeDiffere = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbCompteDeb = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbCompteGestion = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtLibelle = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModePaiements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDebCred)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kGbOptionsDiffere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kGbOptionsDiffere.Panel)).BeginInit();
            this.kGbOptionsDiffere.Panel.SuspendLayout();
            this.kGbOptionsDiffere.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kCbTypeDiffere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompteDeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompteGestion)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnAdd);
            this.kryptonPanel1.Controls.Add(this.kCbDiffere);
            this.kryptonPanel1.Controls.Add(this.btnSupModePaiement);
            this.kryptonPanel1.Controls.Add(this.dgvModePaiements);
            this.kryptonPanel1.Controls.Add(this.btnValid);
            this.kryptonPanel1.Controls.Add(this.kLblHeader);
            this.kryptonPanel1.Controls.Add(this.cbDebCred);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kGbOptionsDiffere);
            this.kryptonPanel1.Controls.Add(this.txtLibelle);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(760, 350);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(277, 47);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnAdd, "Ajouter un mode de paiement");
            this.btnAdd.Values.Image = global::OrionBanque.Properties.Resources.add1;
            this.btnAdd.Values.Text = "";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // kCbDiffere
            // 
            this.kCbDiffere.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kCbDiffere.Location = new System.Drawing.Point(586, 79);
            this.kCbDiffere.Name = "kCbDiffere";
            this.kCbDiffere.Size = new System.Drawing.Size(60, 20);
            this.kCbDiffere.TabIndex = 32;
            this.kCbDiffere.Values.Text = "Différé";
            this.kCbDiffere.CheckedChanged += new System.EventHandler(this.kCbDiffere_CheckedChanged);
            // 
            // btnSupModePaiement
            // 
            this.btnSupModePaiement.Location = new System.Drawing.Point(277, 79);
            this.btnSupModePaiement.Name = "btnSupModePaiement";
            this.btnSupModePaiement.Size = new System.Drawing.Size(23, 23);
            this.btnSupModePaiement.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnSupModePaiement, "Supprimer le mode de paiement");
            this.btnSupModePaiement.Values.Image = global::OrionBanque.Properties.Resources.bin_closed;
            this.btnSupModePaiement.Values.Text = "";
            this.btnSupModePaiement.Click += new System.EventHandler(this.btnSupModePaiement_Click);
            // 
            // dgvModePaiements
            // 
            this.dgvModePaiements.AllowUserToAddRows = false;
            this.dgvModePaiements.AllowUserToDeleteRows = false;
            this.dgvModePaiements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModePaiements.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.dgvModePaiements.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvModePaiements.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvModePaiements.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvModePaiements.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvModePaiements.Location = new System.Drawing.Point(12, 47);
            this.dgvModePaiements.Name = "dgvModePaiements";
            this.dgvModePaiements.ReadOnly = true;
            this.dgvModePaiements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModePaiements.Size = new System.Drawing.Size(250, 288);
            this.dgvModePaiements.TabIndex = 31;
            this.dgvModePaiements.SelectionChanged += new System.EventHandler(this.dgvModePaiements_SelectionChanged);
            // 
            // btnValid
            // 
            this.btnValid.Location = new System.Drawing.Point(715, 79);
            this.btnValid.Name = "btnValid";
            this.btnValid.Size = new System.Drawing.Size(23, 23);
            this.btnValid.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnValid, "Valider les changements");
            this.btnValid.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.btnValid.Values.Text = "";
            this.btnValid.Click += new System.EventHandler(this.btnValid_Click);
            // 
            // kLblHeader
            // 
            this.kLblHeader.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.kLblHeader.Location = new System.Drawing.Point(47, 12);
            this.kLblHeader.Name = "kLblHeader";
            this.kLblHeader.Size = new System.Drawing.Size(177, 29);
            this.kLblHeader.TabIndex = 30;
            this.kLblHeader.Values.Text = "Mode de Paiement";
            // 
            // cbDebCred
            // 
            this.cbDebCred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDebCred.DropDownWidth = 171;
            this.cbDebCred.Items.AddRange(new object[] {
            "Débit",
            "Crédit"});
            this.cbDebCred.Location = new System.Drawing.Point(375, 78);
            this.cbDebCred.Name = "cbDebCred";
            this.cbDebCred.Size = new System.Drawing.Size(205, 21);
            this.cbDebCred.TabIndex = 3;
            this.cbDebCred.SelectedIndexChanged += new System.EventHandler(this.cbDebCred_SelectedIndexChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(320, 78);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel2.TabIndex = 17;
            this.kryptonLabel2.Values.Text = "Mode :";
            // 
            // kGbOptionsDiffere
            // 
            this.kGbOptionsDiffere.Enabled = false;
            this.kGbOptionsDiffere.Location = new System.Drawing.Point(317, 114);
            this.kGbOptionsDiffere.Name = "kGbOptionsDiffere";
            // 
            // kGbOptionsDiffere.Panel
            // 
            this.kGbOptionsDiffere.Panel.Controls.Add(this.kryptonLabel10);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.kryptonLabel9);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.kryptonLabel8);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.kryptonLabel7);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.kNudPeriodeDebut);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.txtDecaleJourFerie);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.txtDecaleDimanche);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.txtDecaleSamedi);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.kryptonLabel6);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.kNudDecalage);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.kCbTypeDiffere);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.kryptonLabel5);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.kryptonLabel4);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.cbCompteDeb);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.kryptonLabel1);
            this.kGbOptionsDiffere.Panel.Controls.Add(this.cbCompteGestion);
            this.kGbOptionsDiffere.Size = new System.Drawing.Size(421, 192);
            this.kGbOptionsDiffere.TabIndex = 23;
            this.kGbOptionsDiffere.Values.Heading = "Options du différé";
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel10.Location = new System.Drawing.Point(373, 100);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(23, 20);
            this.kryptonLabel10.TabIndex = 52;
            this.kryptonLabel10.Values.Text = "jrs";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel9.Location = new System.Drawing.Point(308, 98);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(19, 20);
            this.kryptonLabel9.TabIndex = 51;
            this.kryptonLabel9.Values.Text = "+";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel8.Location = new System.Drawing.Point(209, 71);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel8.TabIndex = 50;
            this.kryptonLabel8.Values.Text = "du mois";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel7.Location = new System.Drawing.Point(25, 71);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(116, 20);
            this.kryptonLabel7.TabIndex = 49;
            this.kryptonLabel7.Values.Text = "Période débute le  :";
            // 
            // kNudPeriodeDebut
            // 
            this.kNudPeriodeDebut.Location = new System.Drawing.Point(147, 71);
            this.kNudPeriodeDebut.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.kNudPeriodeDebut.Name = "kNudPeriodeDebut";
            this.kNudPeriodeDebut.Size = new System.Drawing.Size(56, 22);
            this.kNudPeriodeDebut.TabIndex = 48;
            // 
            // txtDecaleJourFerie
            // 
            this.txtDecaleJourFerie.Checked = true;
            this.txtDecaleJourFerie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.txtDecaleJourFerie.Location = new System.Drawing.Point(312, 126);
            this.txtDecaleJourFerie.Name = "txtDecaleJourFerie";
            this.txtDecaleJourFerie.Size = new System.Drawing.Size(76, 20);
            this.txtDecaleJourFerie.TabIndex = 47;
            this.txtDecaleJourFerie.Values.Text = "Jour Férié";
            // 
            // txtDecaleDimanche
            // 
            this.txtDecaleDimanche.Checked = true;
            this.txtDecaleDimanche.CheckState = System.Windows.Forms.CheckState.Checked;
            this.txtDecaleDimanche.Location = new System.Drawing.Point(222, 126);
            this.txtDecaleDimanche.Name = "txtDecaleDimanche";
            this.txtDecaleDimanche.Size = new System.Drawing.Size(78, 20);
            this.txtDecaleDimanche.TabIndex = 46;
            this.txtDecaleDimanche.Values.Text = "Dimanche";
            // 
            // txtDecaleSamedi
            // 
            this.txtDecaleSamedi.Checked = true;
            this.txtDecaleSamedi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.txtDecaleSamedi.Location = new System.Drawing.Point(147, 126);
            this.txtDecaleSamedi.Name = "txtDecaleSamedi";
            this.txtDecaleSamedi.Size = new System.Drawing.Size(64, 20);
            this.txtDecaleSamedi.TabIndex = 45;
            this.txtDecaleSamedi.Values.Text = "Samedi";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel6.Location = new System.Drawing.Point(72, 126);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(69, 20);
            this.kryptonLabel6.TabIndex = 44;
            this.kryptonLabel6.Values.Text = "Décaler si :";
            // 
            // kNudDecalage
            // 
            this.kNudDecalage.Location = new System.Drawing.Point(332, 98);
            this.kNudDecalage.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.kNudDecalage.Name = "kNudDecalage";
            this.kNudDecalage.Size = new System.Drawing.Size(41, 22);
            this.kNudDecalage.TabIndex = 43;
            // 
            // kCbTypeDiffere
            // 
            this.kCbTypeDiffere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kCbTypeDiffere.DropDownWidth = 121;
            this.kCbTypeDiffere.Items.AddRange(new object[] {
            "fin de mois",
            "30 jrs fin de mois",
            "60 jrs fin de mois"});
            this.kCbTypeDiffere.Location = new System.Drawing.Point(147, 99);
            this.kCbTypeDiffere.Name = "kCbTypeDiffere";
            this.kCbTypeDiffere.Size = new System.Drawing.Size(159, 21);
            this.kCbTypeDiffere.TabIndex = 42;
            this.kCbTypeDiffere.Text = "fin de mois";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel5.Location = new System.Drawing.Point(88, 100);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel5.TabIndex = 41;
            this.kryptonLabel5.Values.Text = "Différé :";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel4.Location = new System.Drawing.Point(28, 45);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(113, 20);
            this.kryptonLabel4.TabIndex = 39;
            this.kryptonLabel4.Values.Text = "Compte à Débiter :";
            // 
            // cbCompteDeb
            // 
            this.cbCompteDeb.DisplayMember = "Libelle";
            this.cbCompteDeb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompteDeb.DropDownWidth = 121;
            this.cbCompteDeb.Location = new System.Drawing.Point(147, 44);
            this.cbCompteDeb.Name = "cbCompteDeb";
            this.cbCompteDeb.Size = new System.Drawing.Size(241, 21);
            this.cbCompteDeb.TabIndex = 40;
            this.cbCompteDeb.ValueMember = "Id";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(19, 17);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(122, 20);
            this.kryptonLabel1.TabIndex = 33;
            this.kryptonLabel1.Values.Text = "Compte de Gestion :";
            // 
            // cbCompteGestion
            // 
            this.cbCompteGestion.DisplayMember = "Libelle";
            this.cbCompteGestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompteGestion.DropDownWidth = 121;
            this.cbCompteGestion.Location = new System.Drawing.Point(147, 17);
            this.cbCompteGestion.Name = "cbCompteGestion";
            this.cbCompteGestion.Size = new System.Drawing.Size(241, 21);
            this.cbCompteGestion.TabIndex = 38;
            this.cbCompteGestion.ValueMember = "Id";
            // 
            // txtLibelle
            // 
            this.txtLibelle.Location = new System.Drawing.Point(375, 47);
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(205, 23);
            this.txtLibelle.TabIndex = 2;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel3.Location = new System.Drawing.Point(317, 47);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel3.TabIndex = 18;
            this.kryptonLabel3.Values.Text = "Libelle :";
            // 
            // ModePaiementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 350);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModePaiementForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mode de Paiement";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModePaiements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDebCred)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kGbOptionsDiffere.Panel)).EndInit();
            this.kGbOptionsDiffere.Panel.ResumeLayout(false);
            this.kGbOptionsDiffere.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kGbOptionsDiffere)).EndInit();
            this.kGbOptionsDiffere.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kCbTypeDiffere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompteDeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompteGestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kGbOptionsDiffere;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLibelle;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbDebCred;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSupModePaiement;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnValid;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAdd;
        private System.Windows.Forms.ToolTip toolTip1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kLblHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvModePaiements;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kCbDiffere;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kNudDecalage;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kCbTypeDiffere;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbCompteDeb;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbCompteGestion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kNudPeriodeDebut;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox txtDecaleJourFerie;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox txtDecaleDimanche;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox txtDecaleSamedi;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
    }
}