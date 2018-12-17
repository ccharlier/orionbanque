namespace OrionBanque.Forms
{
    partial class OperationForm
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
            this.txtPointage = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.Fermer = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.OK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddFichier = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btlDeleteFile = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtDateMvt = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.txtMontant = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.dgvFichiers = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtLibelle = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kLblHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtModePaiement = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtCategorie = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtTiers = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.OFDImport = new System.Windows.Forms.OpenFileDialog();
            this.kBtnValidStayOpen = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichiers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModePaiement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiers)).BeginInit();
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
            // txtPointage
            // 
            this.txtPointage.CheckPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.txtPointage.Location = new System.Drawing.Point(256, 278);
            this.txtPointage.Name = "txtPointage";
            this.txtPointage.Size = new System.Drawing.Size(123, 20);
            this.txtPointage.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtPointage, "Cocher pour pointer l\'Opération");
            this.txtPointage.Values.Text = "Opération Pointée";
            this.txtPointage.CheckedChanged += new System.EventHandler(this.TxtPointage_CheckedChanged);
            // 
            // Fermer
            // 
            this.Fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Fermer.Location = new System.Drawing.Point(17, 467);
            this.Fermer.Name = "Fermer";
            this.Fermer.Size = new System.Drawing.Size(23, 24);
            this.Fermer.TabIndex = 10;
            this.toolTip1.SetToolTip(this.Fermer, "Fermer la fenêtre sans enregistrer");
            this.Fermer.Values.Image = global::OrionBanque.Properties.Resources.cross1;
            this.Fermer.Values.Text = "";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(356, 467);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(23, 24);
            this.OK.TabIndex = 11;
            this.toolTip1.SetToolTip(this.OK, "Valider l\'opération courante");
            this.OK.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.OK.Values.Text = "";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // btnAddFichier
            // 
            this.btnAddFichier.Location = new System.Drawing.Point(356, 318);
            this.btnAddFichier.Name = "btnAddFichier";
            this.btnAddFichier.Size = new System.Drawing.Size(23, 23);
            this.btnAddFichier.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnAddFichier, "Ajouter un Fichier lié à l\'Opération");
            this.btnAddFichier.Values.Image = global::OrionBanque.Properties.Resources.page_add;
            this.btnAddFichier.Values.Text = "";
            this.btnAddFichier.Click += new System.EventHandler(this.btnAddFichier_Click);
            // 
            // btlDeleteFile
            // 
            this.btlDeleteFile.Location = new System.Drawing.Point(356, 368);
            this.btlDeleteFile.Name = "btlDeleteFile";
            this.btlDeleteFile.Size = new System.Drawing.Size(23, 23);
            this.btlDeleteFile.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btlDeleteFile, "Supprimer le Fichier lié à l\'Opération");
            this.btlDeleteFile.Values.Image = global::OrionBanque.Properties.Resources.page_delete;
            this.btlDeleteFile.Values.Text = "";
            this.btlDeleteFile.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::OrionBanque.Properties.Resources.calendar_2;
            this.pictureBox1.Location = new System.Drawing.Point(17, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Date de l\'Opération");
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::OrionBanque.Properties.Resources.creditcards;
            this.pictureBox2.Location = new System.Drawing.Point(17, 131);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "Clique Droit => Accèder à la gestion");
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::OrionBanque.Properties.Resources.chart_organisation1;
            this.pictureBox6.Location = new System.Drawing.Point(17, 99);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.TabIndex = 32;
            this.pictureBox6.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox6, "Clique Droit => Accèder à la gestion");
            this.pictureBox6.Click += new System.EventHandler(this.PictureBox6_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::OrionBanque.Properties.Resources.money1;
            this.pictureBox3.Location = new System.Drawing.Point(17, 243);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox3, "Montant de l\'Opération");
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::OrionBanque.Properties.Resources.comment1;
            this.pictureBox4.Location = new System.Drawing.Point(17, 206);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 30;
            this.pictureBox4.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox4, "Libellé de l\'Opération");
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::OrionBanque.Properties.Resources.user_business;
            this.pictureBox5.Location = new System.Drawing.Point(17, 168);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.TabIndex = 31;
            this.pictureBox5.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox5, "Tiers de l\'Opération");
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kBtnValidStayOpen);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Controls.Add(this.txtPointage);
            this.kryptonPanel1.Controls.Add(this.btlDeleteFile);
            this.kryptonPanel1.Controls.Add(this.txtDateMvt);
            this.kryptonPanel1.Controls.Add(this.txtMontant);
            this.kryptonPanel1.Controls.Add(this.dgvFichiers);
            this.kryptonPanel1.Controls.Add(this.txtLibelle);
            this.kryptonPanel1.Controls.Add(this.btnAddFichier);
            this.kryptonPanel1.Controls.Add(this.pictureBox2);
            this.kryptonPanel1.Controls.Add(this.kLblHeader);
            this.kryptonPanel1.Controls.Add(this.pictureBox6);
            this.kryptonPanel1.Controls.Add(this.OK);
            this.kryptonPanel1.Controls.Add(this.txtModePaiement);
            this.kryptonPanel1.Controls.Add(this.Fermer);
            this.kryptonPanel1.Controls.Add(this.pictureBox3);
            this.kryptonPanel1.Controls.Add(this.txtCategorie);
            this.kryptonPanel1.Controls.Add(this.txtTiers);
            this.kryptonPanel1.Controls.Add(this.pictureBox5);
            this.kryptonPanel1.Controls.Add(this.pictureBox4);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(401, 523);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // txtDateMvt
            // 
            this.txtDateMvt.Location = new System.Drawing.Point(39, 57);
            this.txtDateMvt.Name = "txtDateMvt";
            this.txtDateMvt.Size = new System.Drawing.Size(340, 21);
            this.txtDateMvt.TabIndex = 1;
            // 
            // txtMontant
            // 
            this.txtMontant.DecimalPlaces = 2;
            this.txtMontant.Location = new System.Drawing.Point(39, 237);
            this.txtMontant.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(340, 22);
            this.txtMontant.TabIndex = 6;
            this.txtMontant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontant_KeyPress);
            // 
            // dgvFichiers
            // 
            this.dgvFichiers.AllowUserToAddRows = false;
            this.dgvFichiers.AllowUserToDeleteRows = false;
            this.dgvFichiers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFichiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFichiers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvFichiers.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.dgvFichiers.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvFichiers.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvFichiers.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvFichiers.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvFichiers.Location = new System.Drawing.Point(17, 318);
            this.dgvFichiers.MultiSelect = false;
            this.dgvFichiers.Name = "dgvFichiers";
            this.dgvFichiers.ReadOnly = true;
            this.dgvFichiers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFichiers.Size = new System.Drawing.Size(333, 143);
            this.dgvFichiers.TabIndex = 0;
            this.dgvFichiers.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFichiers_CellMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supprimerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 26);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.table_row_delete;
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.supprimerToolStripMenuItem.Text = "&Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // txtLibelle
            // 
            this.txtLibelle.Location = new System.Drawing.Point(39, 199);
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(339, 23);
            this.txtLibelle.TabIndex = 5;
            // 
            // kLblHeader
            // 
            this.kLblHeader.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.kLblHeader.Location = new System.Drawing.Point(163, 9);
            this.kLblHeader.Name = "kLblHeader";
            this.kLblHeader.Size = new System.Drawing.Size(100, 29);
            this.kLblHeader.TabIndex = 0;
            this.kLblHeader.Values.Text = "Opération";
            // 
            // txtModePaiement
            // 
            this.txtModePaiement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtModePaiement.DropDownWidth = 185;
            this.txtModePaiement.Location = new System.Drawing.Point(39, 127);
            this.txtModePaiement.Name = "txtModePaiement";
            this.txtModePaiement.Size = new System.Drawing.Size(340, 21);
            this.txtModePaiement.TabIndex = 3;
            this.txtModePaiement.SelectedIndexChanged += new System.EventHandler(this.TxtModePaiement_SelectedIndexChanged);
            // 
            // txtCategorie
            // 
            this.txtCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCategorie.DropDownWidth = 166;
            this.txtCategorie.Location = new System.Drawing.Point(39, 94);
            this.txtCategorie.Name = "txtCategorie";
            this.txtCategorie.Size = new System.Drawing.Size(339, 21);
            this.txtCategorie.TabIndex = 2;
            // 
            // txtTiers
            // 
            this.txtTiers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTiers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtTiers.DropDownWidth = 166;
            this.txtTiers.Location = new System.Drawing.Point(39, 163);
            this.txtTiers.Name = "txtTiers";
            this.txtTiers.Size = new System.Drawing.Size(340, 21);
            this.txtTiers.TabIndex = 4;
            // 
            // OFDImport
            // 
            this.OFDImport.Title = "Fichier d\'Opérations à importer";
            // 
            // kBtnValidStayOpen
            // 
            this.kBtnValidStayOpen.Location = new System.Drawing.Point(119, 467);
            this.kBtnValidStayOpen.Name = "kBtnValidStayOpen";
            this.kBtnValidStayOpen.Size = new System.Drawing.Size(231, 24);
            this.kBtnValidStayOpen.TabIndex = 33;
            this.toolTip1.SetToolTip(this.kBtnValidStayOpen, "Valider l\'opération courante et en saisir une nouvelle");
            this.kBtnValidStayOpen.Values.Text = "Valider et saisir une nouvelle Opération";
            this.kBtnValidStayOpen.Click += new System.EventHandler(this.kBtnValidStayOpen_Click);
            // 
            // OperationForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Fermer;
            this.ClientSize = new System.Drawing.Size(401, 523);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opération";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichiers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtModePaiement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtDateMvt;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtTiers;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtMontant;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLibelle;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtModePaiement;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtCategorie;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Fermer;
        private ComponentFactory.Krypton.Toolkit.KryptonButton OK;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox txtPointage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kLblHeader;
        private System.Windows.Forms.OpenFileDialog OFDImport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvFichiers;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddFichier;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btlDeleteFile;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnValidStayOpen;
    }
}