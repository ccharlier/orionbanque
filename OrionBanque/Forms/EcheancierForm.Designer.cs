﻿namespace OrionBanque.Forms
{
    partial class EcheancierForm
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.cbCompte = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtProchaine = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.txtDecaleJourFerie = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDecaleDimanche = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.txtDecaleSamedi = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.txtInsererOuvertureFichier = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.txtIllimite = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtRepete = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtTypeRepete = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDateFin = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.Fermer = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.OK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtCategorie = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtTiers = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtMontant = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtLibelle = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtModePaiement = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeRepete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModePaiement)).BeginInit();
            this.SuspendLayout();
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::OrionBanque.Properties.Resources.calendar_2;
            this.pictureBox1.Location = new System.Drawing.Point(11, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Date de l\'Opération");
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::OrionBanque.Properties.Resources.chart_organisation1;
            this.pictureBox6.Location = new System.Drawing.Point(11, 141);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.TabIndex = 32;
            this.pictureBox6.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox6, "Clique Droit => Accèder à la gestion");
            this.pictureBox6.Click += new System.EventHandler(this.PictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::OrionBanque.Properties.Resources.user_business;
            this.pictureBox5.Location = new System.Drawing.Point(11, 114);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.TabIndex = 31;
            this.pictureBox5.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox5, "Tiers de l\'Opération");
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::OrionBanque.Properties.Resources.comment1;
            this.pictureBox4.Location = new System.Drawing.Point(205, 115);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 30;
            this.pictureBox4.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox4, "Libellé de l\'Opération");
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::OrionBanque.Properties.Resources.money1;
            this.pictureBox3.Location = new System.Drawing.Point(205, 141);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox3, "Montant de l\'Opération");
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::OrionBanque.Properties.Resources.creditcards;
            this.pictureBox2.Location = new System.Drawing.Point(205, 88);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "Clique Droit => Accèder à la gestion");
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::OrionBanque.Properties.Resources.money_euro;
            this.pictureBox7.Location = new System.Drawing.Point(11, 56);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(16, 16);
            this.pictureBox7.TabIndex = 53;
            this.pictureBox7.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox7, "Clique Droit => Accèder à la gestion");
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pictureBox7);
            this.kryptonPanel1.Controls.Add(this.cbCompte);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Controls.Add(this.txtProchaine);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Controls.Add(this.Fermer);
            this.kryptonPanel1.Controls.Add(this.OK);
            this.kryptonPanel1.Controls.Add(this.txtCategorie);
            this.kryptonPanel1.Controls.Add(this.txtTiers);
            this.kryptonPanel1.Controls.Add(this.txtMontant);
            this.kryptonPanel1.Controls.Add(this.txtLibelle);
            this.kryptonPanel1.Controls.Add(this.txtModePaiement);
            this.kryptonPanel1.Controls.Add(this.pictureBox6);
            this.kryptonPanel1.Controls.Add(this.pictureBox5);
            this.kryptonPanel1.Controls.Add(this.pictureBox4);
            this.kryptonPanel1.Controls.Add(this.pictureBox3);
            this.kryptonPanel1.Controls.Add(this.pictureBox2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(424, 374);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // cbCompte
            // 
            this.cbCompte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCompte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompte.DropDownWidth = 121;
            this.cbCompte.Location = new System.Drawing.Point(33, 55);
            this.cbCompte.Name = "cbCompte";
            this.cbCompte.Size = new System.Drawing.Size(379, 21);
            this.cbCompte.TabIndex = 1;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.kryptonLabel3.Location = new System.Drawing.Point(161, 12);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(93, 29);
            this.kryptonLabel3.TabIndex = 51;
            this.kryptonLabel3.Values.Text = "Echéance";
            // 
            // txtProchaine
            // 
            this.txtProchaine.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtProchaine.Location = new System.Drawing.Point(33, 85);
            this.txtProchaine.Name = "txtProchaine";
            this.txtProchaine.Size = new System.Drawing.Size(166, 21);
            this.txtProchaine.TabIndex = 2;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(11, 166);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtDecaleJourFerie);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtDecaleDimanche);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtDecaleSamedi);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtInsererOuvertureFichier);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtIllimite);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtRepete);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtTypeRepete);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtDateFin);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(401, 165);
            this.kryptonGroupBox1.TabIndex = 42;
            this.kryptonGroupBox1.Values.Heading = "Echéances";
            // 
            // txtDecaleJourFerie
            // 
            this.txtDecaleJourFerie.Checked = true;
            this.txtDecaleJourFerie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.txtDecaleJourFerie.Location = new System.Drawing.Point(246, 109);
            this.txtDecaleJourFerie.Name = "txtDecaleJourFerie";
            this.txtDecaleJourFerie.Size = new System.Drawing.Size(76, 20);
            this.txtDecaleJourFerie.TabIndex = 15;
            this.txtDecaleJourFerie.Values.Text = "Jour Férié";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(29, 83);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(208, 20);
            this.kryptonLabel4.TabIndex = 50;
            this.kryptonLabel4.Values.Text = "Décaler l\'échéance si elle tombe un :";
            // 
            // txtDecaleDimanche
            // 
            this.txtDecaleDimanche.Checked = true;
            this.txtDecaleDimanche.CheckState = System.Windows.Forms.CheckState.Checked;
            this.txtDecaleDimanche.Location = new System.Drawing.Point(162, 109);
            this.txtDecaleDimanche.Name = "txtDecaleDimanche";
            this.txtDecaleDimanche.Size = new System.Drawing.Size(78, 20);
            this.txtDecaleDimanche.TabIndex = 14;
            this.txtDecaleDimanche.Values.Text = "Dimanche";
            // 
            // txtDecaleSamedi
            // 
            this.txtDecaleSamedi.Checked = true;
            this.txtDecaleSamedi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.txtDecaleSamedi.Location = new System.Drawing.Point(81, 109);
            this.txtDecaleSamedi.Name = "txtDecaleSamedi";
            this.txtDecaleSamedi.Size = new System.Drawing.Size(64, 20);
            this.txtDecaleSamedi.TabIndex = 13;
            this.txtDecaleSamedi.Values.Text = "Samedi";
            // 
            // txtInsererOuvertureFichier
            // 
            this.txtInsererOuvertureFichier.Checked = true;
            this.txtInsererOuvertureFichier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.txtInsererOuvertureFichier.Location = new System.Drawing.Point(15, 57);
            this.txtInsererOuvertureFichier.Name = "txtInsererOuvertureFichier";
            this.txtInsererOuvertureFichier.Size = new System.Drawing.Size(187, 20);
            this.txtInsererOuvertureFichier.TabIndex = 12;
            this.txtInsererOuvertureFichier.Values.Text = "Insérer à l\'ouverture du fichier";
            // 
            // txtIllimite
            // 
            this.txtIllimite.Checked = true;
            this.txtIllimite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.txtIllimite.Location = new System.Drawing.Point(15, 5);
            this.txtIllimite.Name = "txtIllimite";
            this.txtIllimite.Size = new System.Drawing.Size(60, 20);
            this.txtIllimite.TabIndex = 8;
            this.txtIllimite.Values.Text = "Illimité";
            this.txtIllimite.CheckedChanged += new System.EventHandler(this.TxtIlimete_CheckedChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(81, 29);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel2.TabIndex = 45;
            this.kryptonLabel2.Values.Text = "Tous les  :";
            // 
            // txtRepete
            // 
            this.txtRepete.Location = new System.Drawing.Point(156, 30);
            this.txtRepete.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtRepete.Name = "txtRepete";
            this.txtRepete.Size = new System.Drawing.Size(46, 22);
            this.txtRepete.TabIndex = 10;
            this.txtRepete.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTypeRepete
            // 
            this.txtTypeRepete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTypeRepete.DropDownWidth = 166;
            this.txtTypeRepete.Items.AddRange(new object[] {
            "Jour(s)",
            "Mois",
            "Année(s)"});
            this.txtTypeRepete.Location = new System.Drawing.Point(214, 30);
            this.txtTypeRepete.Name = "txtTypeRepete";
            this.txtTypeRepete.Size = new System.Drawing.Size(180, 21);
            this.txtTypeRepete.TabIndex = 11;
            this.txtTypeRepete.Text = "Mois";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(81, 5);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(129, 20);
            this.kryptonLabel1.TabIndex = 35;
            this.kryptonLabel1.Values.ExtraText = "(incluse) :";
            this.kryptonLabel1.Values.Text = "Date de Fin";
            // 
            // txtDateFin
            // 
            this.txtDateFin.Enabled = false;
            this.txtDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateFin.Location = new System.Drawing.Point(214, 3);
            this.txtDateFin.Name = "txtDateFin";
            this.txtDateFin.Size = new System.Drawing.Size(180, 21);
            this.txtDateFin.TabIndex = 9;
            // 
            // Fermer
            // 
            this.Fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Fermer.Location = new System.Drawing.Point(227, 340);
            this.Fermer.Name = "Fermer";
            this.Fermer.Size = new System.Drawing.Size(23, 23);
            this.Fermer.TabIndex = 16;
            this.Fermer.Values.Image = global::OrionBanque.Properties.Resources.cross1;
            this.Fermer.Values.Text = "";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(384, 337);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(23, 23);
            this.OK.TabIndex = 17;
            this.OK.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.OK.Values.Text = "";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // txtCategorie
            // 
            this.txtCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCategorie.DropDownWidth = 166;
            this.txtCategorie.Location = new System.Drawing.Point(33, 139);
            this.txtCategorie.Name = "txtCategorie";
            this.txtCategorie.Size = new System.Drawing.Size(166, 21);
            this.txtCategorie.TabIndex = 6;
            // 
            // txtTiers
            // 
            this.txtTiers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTiers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtTiers.DropDownWidth = 166;
            this.txtTiers.Location = new System.Drawing.Point(33, 112);
            this.txtTiers.Name = "txtTiers";
            this.txtTiers.Size = new System.Drawing.Size(166, 21);
            this.txtTiers.TabIndex = 4;
            // 
            // txtMontant
            // 
            this.txtMontant.DecimalPlaces = 2;
            this.txtMontant.Location = new System.Drawing.Point(227, 138);
            this.txtMontant.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(185, 22);
            this.txtMontant.TabIndex = 7;
            this.txtMontant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontant_KeyPress);
            // 
            // txtLibelle
            // 
            this.txtLibelle.Location = new System.Drawing.Point(227, 112);
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(185, 23);
            this.txtLibelle.TabIndex = 5;
            // 
            // txtModePaiement
            // 
            this.txtModePaiement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtModePaiement.DropDownWidth = 185;
            this.txtModePaiement.Location = new System.Drawing.Point(227, 85);
            this.txtModePaiement.Name = "txtModePaiement";
            this.txtModePaiement.Size = new System.Drawing.Size(185, 21);
            this.txtModePaiement.TabIndex = 3;
            // 
            // EcheancierForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Fermer;
            this.ClientSize = new System.Drawing.Size(424, 374);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcheancierForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Echéance";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeRepete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModePaiement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtTiers;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtMontant;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLibelle;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtModePaiement;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtCategorie;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Fermer;
        private ComponentFactory.Krypton.Toolkit.KryptonButton OK;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtDateFin;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtRepete;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtTypeRepete;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox txtIllimite;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtProchaine;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.PictureBox pictureBox7;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbCompte;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox txtDecaleDimanche;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox txtDecaleSamedi;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox txtInsererOuvertureFichier;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox txtDecaleJourFerie;
    }
}