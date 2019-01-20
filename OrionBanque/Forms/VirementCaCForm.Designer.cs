namespace OrionBanque.Forms
{
    partial class VirementCaCForm
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
            if(disposing && (components != null))
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.txtDateMvt = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.Fermer = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.OK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtCategorie = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtMontant = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtLibelle = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.pBDestination = new System.Windows.Forms.PictureBox();
            this.pBOrigine = new System.Windows.Forms.PictureBox();
            this.lblTotDest = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblTotOri = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbCompteOri = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbCompteDest = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBOrigine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompteOri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompteDest)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pictureBox3);
            this.kryptonPanel1.Controls.Add(this.pictureBox4);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Controls.Add(this.pictureBox6);
            this.kryptonPanel1.Controls.Add(this.txtDateMvt);
            this.kryptonPanel1.Controls.Add(this.Fermer);
            this.kryptonPanel1.Controls.Add(this.OK);
            this.kryptonPanel1.Controls.Add(this.txtCategorie);
            this.kryptonPanel1.Controls.Add(this.txtMontant);
            this.kryptonPanel1.Controls.Add(this.txtLibelle);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(464, 192);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::OrionBanque.Properties.Resources.money1;
            this.pictureBox3.Location = new System.Drawing.Point(226, 139);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 55;
            this.pictureBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox3, "Montant de l\'Opération");
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::OrionBanque.Properties.Resources.comment1;
            this.pictureBox4.Location = new System.Drawing.Point(226, 111);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 54;
            this.pictureBox4.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox4, "Libellé de l\'Opération");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::OrionBanque.Properties.Resources.calendar_2;
            this.pictureBox1.Location = new System.Drawing.Point(32, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Date de l\'Opération");
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::OrionBanque.Properties.Resources.chart_organisation1;
            this.pictureBox6.Location = new System.Drawing.Point(32, 139);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.TabIndex = 52;
            this.pictureBox6.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox6, "Clique Droit => Accèder à la gestion");
            this.pictureBox6.Click += new System.EventHandler(this.PictureBox6_Click);
            // 
            // txtDateMvt
            // 
            this.txtDateMvt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateMvt.Location = new System.Drawing.Point(54, 106);
            this.txtDateMvt.Name = "txtDateMvt";
            this.txtDateMvt.Size = new System.Drawing.Size(164, 21);
            this.txtDateMvt.TabIndex = 3;
            // 
            // Fermer
            // 
            this.Fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Fermer.Location = new System.Drawing.Point(248, 161);
            this.Fermer.Name = "Fermer";
            this.Fermer.Size = new System.Drawing.Size(23, 23);
            this.Fermer.TabIndex = 7;
            this.toolTip1.SetToolTip(this.Fermer, "Fermer le fenêtre de virement sans valider");
            this.Fermer.Values.Image = global::OrionBanque.Properties.Resources.cross1;
            this.Fermer.Values.Text = "";
            this.Fermer.Click += new System.EventHandler(this.Fermer_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(410, 161);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(23, 23);
            this.OK.TabIndex = 8;
            this.toolTip1.SetToolTip(this.OK, "Valider le virement de compte à compte");
            this.OK.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.OK.Values.Text = "";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // txtCategorie
            // 
            this.txtCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCategorie.DropDownWidth = 166;
            this.txtCategorie.Location = new System.Drawing.Point(54, 134);
            this.txtCategorie.Name = "txtCategorie";
            this.txtCategorie.Size = new System.Drawing.Size(166, 21);
            this.txtCategorie.TabIndex = 5;
            // 
            // txtMontant
            // 
            this.txtMontant.DecimalPlaces = 2;
            this.txtMontant.Location = new System.Drawing.Point(248, 133);
            this.txtMontant.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(185, 22);
            this.txtMontant.TabIndex = 6;
            // 
            // txtLibelle
            // 
            this.txtLibelle.Location = new System.Drawing.Point(248, 107);
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(185, 23);
            this.txtLibelle.TabIndex = 4;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.pBDestination);
            this.kryptonGroupBox1.Panel.Controls.Add(this.pBOrigine);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lblTotDest);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lblTotOri);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cbCompteOri);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cbCompteDest);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(440, 89);
            this.kryptonGroupBox1.TabIndex = 12;
            this.kryptonGroupBox1.Values.Heading = "Comptes";
            // 
            // pBDestination
            // 
            this.pBDestination.BackColor = System.Drawing.Color.Transparent;
            this.pBDestination.Image = global::OrionBanque.Properties.Resources.lightbulb;
            this.pBDestination.Location = new System.Drawing.Point(315, 33);
            this.pBDestination.Name = "pBDestination";
            this.pBDestination.Size = new System.Drawing.Size(16, 16);
            this.pBDestination.TabIndex = 57;
            this.pBDestination.TabStop = false;
            this.toolTip1.SetToolTip(this.pBDestination, "Solde Pointé du Compte Destination");
            // 
            // pBOrigine
            // 
            this.pBOrigine.BackColor = System.Drawing.Color.Transparent;
            this.pBOrigine.Image = global::OrionBanque.Properties.Resources.lightbulb;
            this.pBOrigine.Location = new System.Drawing.Point(315, 5);
            this.pBOrigine.Name = "pBOrigine";
            this.pBOrigine.Size = new System.Drawing.Size(16, 16);
            this.pBOrigine.TabIndex = 56;
            this.pBOrigine.TabStop = false;
            this.toolTip1.SetToolTip(this.pBOrigine, "Solde Pointé du Compte Origine");
            // 
            // lblTotDest
            // 
            this.lblTotDest.Location = new System.Drawing.Point(343, 32);
            this.lblTotDest.Name = "lblTotDest";
            this.lblTotDest.Size = new System.Drawing.Size(40, 20);
            this.lblTotDest.TabIndex = 13;
            this.lblTotDest.Values.Text = "00.00";
            // 
            // lblTotOri
            // 
            this.lblTotOri.Location = new System.Drawing.Point(343, 5);
            this.lblTotOri.Name = "lblTotOri";
            this.lblTotOri.Size = new System.Drawing.Size(40, 20);
            this.lblTotOri.TabIndex = 12;
            this.lblTotOri.Values.Text = "00.00";
            // 
            // cbCompteOri
            // 
            this.cbCompteOri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompteOri.DropDownWidth = 121;
            this.cbCompteOri.Location = new System.Drawing.Point(145, 3);
            this.cbCompteOri.Name = "cbCompteOri";
            this.cbCompteOri.Size = new System.Drawing.Size(164, 21);
            this.cbCompteOri.TabIndex = 1;
            this.cbCompteOri.SelectedIndexChanged += new System.EventHandler(this.CbCompteOri_SelectedIndexChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(10, 32);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(137, 20);
            this.kryptonLabel2.TabIndex = 11;
            this.kryptonLabel2.Values.Text = "Compte de Destination";
            // 
            // cbCompteDest
            // 
            this.cbCompteDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompteDest.DropDownWidth = 121;
            this.cbCompteDest.Location = new System.Drawing.Point(145, 30);
            this.cbCompteDest.Name = "cbCompteDest";
            this.cbCompteDest.Size = new System.Drawing.Size(164, 21);
            this.cbCompteDest.TabIndex = 2;
            this.cbCompteDest.SelectedIndexChanged += new System.EventHandler(this.CbCompteDest_SelectedIndexChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(37, 5);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(108, 20);
            this.kryptonLabel1.TabIndex = 10;
            this.kryptonLabel1.Values.Text = "Compte d\'Origine";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 20;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Aide";
            // 
            // VirementCaCForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Fermer;
            this.ClientSize = new System.Drawing.Size(464, 192);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VirementCaCForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Virement de Compte à Compte";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBOrigine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompteOri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompteDest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbCompteOri;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbCompteDest;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotDest;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotOri;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtCategorie;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtMontant;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLibelle;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Fermer;
        private ComponentFactory.Krypton.Toolkit.KryptonButton OK;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtDateMvt;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pBDestination;
        private System.Windows.Forms.PictureBox pBOrigine;
    }
}