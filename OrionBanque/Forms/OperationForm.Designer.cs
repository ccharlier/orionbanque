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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtCategorie = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtTiers = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtMontant = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtDateMvt = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.txtLibelle = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtModePaiement = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tabFichier = new System.Windows.Forms.TabPage();
            this.kPanelFichier = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgvFichiers = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kLblHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.OFDImport = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModePaiement)).BeginInit();
            this.tabFichier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kPanelFichier)).BeginInit();
            this.kPanelFichier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichiers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.txtPointage.Location = new System.Drawing.Point(119, 45);
            this.txtPointage.Name = "txtPointage";
            this.txtPointage.Size = new System.Drawing.Size(123, 20);
            this.txtPointage.TabIndex = 45;
            this.toolTip1.SetToolTip(this.txtPointage, "Cocher pour pointer l\'Opération");
            this.txtPointage.Values.Text = "Opération Pointée";
            this.txtPointage.CheckedChanged += new System.EventHandler(this.TxtPointage_CheckedChanged);
            // 
            // Fermer
            // 
            this.Fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Fermer.Location = new System.Drawing.Point(340, 287);
            this.Fermer.Name = "Fermer";
            this.Fermer.Size = new System.Drawing.Size(23, 23);
            this.Fermer.TabIndex = 40;
            this.toolTip1.SetToolTip(this.Fermer, "Fermer la fenêtre sans enregistrer");
            this.Fermer.Values.Image = global::OrionBanque.Properties.Resources.cross1;
            this.Fermer.Values.Text = "";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(502, 287);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(23, 23);
            this.OK.TabIndex = 41;
            this.toolTip1.SetToolTip(this.OK, "Valider l\'opération courante");
            this.OK.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.OK.Values.Text = "";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // btnAddFichier
            // 
            this.btnAddFichier.Location = new System.Drawing.Point(472, 3);
            this.btnAddFichier.Name = "btnAddFichier";
            this.btnAddFichier.Size = new System.Drawing.Size(31, 25);
            this.btnAddFichier.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnAddFichier, "Ajouter un Fichier lié à l\'Opération");
            this.btnAddFichier.Values.Image = global::OrionBanque.Properties.Resources.page_add;
            this.btnAddFichier.Values.Text = "";
            this.btnAddFichier.Click += new System.EventHandler(this.btnAddFichier_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::OrionBanque.Properties.Resources.calendar_2;
            this.pictureBox1.Location = new System.Drawing.Point(248, 48);
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
            this.pictureBox2.Location = new System.Drawing.Point(248, 75);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "Clique Droit => Accèder à la gestion");
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::OrionBanque.Properties.Resources.money1;
            this.pictureBox3.Location = new System.Drawing.Point(248, 128);
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
            this.pictureBox4.Location = new System.Drawing.Point(248, 102);
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
            this.pictureBox5.Location = new System.Drawing.Point(54, 101);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.TabIndex = 31;
            this.pictureBox5.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox5, "Tiers de l\'Opération");
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::OrionBanque.Properties.Resources.chart_organisation1;
            this.pictureBox6.Location = new System.Drawing.Point(54, 128);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.TabIndex = 32;
            this.pictureBox6.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox6, "Clique Droit => Accèder à la gestion");
            this.pictureBox6.Click += new System.EventHandler(this.PictureBox6_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tabControl1);
            this.kryptonPanel1.Controls.Add(this.kLblHeader);
            this.kryptonPanel1.Controls.Add(this.OK);
            this.kryptonPanel1.Controls.Add(this.Fermer);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(546, 320);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabFichier);
            this.tabControl1.Location = new System.Drawing.Point(12, 47);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(520, 234);
            this.tabControl1.TabIndex = 47;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.kryptonPanel2);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(512, 208);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "Général";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.txtPointage);
            this.kryptonPanel2.Controls.Add(this.pictureBox1);
            this.kryptonPanel2.Controls.Add(this.pictureBox2);
            this.kryptonPanel2.Controls.Add(this.pictureBox3);
            this.kryptonPanel2.Controls.Add(this.pictureBox4);
            this.kryptonPanel2.Controls.Add(this.txtCategorie);
            this.kryptonPanel2.Controls.Add(this.pictureBox5);
            this.kryptonPanel2.Controls.Add(this.txtTiers);
            this.kryptonPanel2.Controls.Add(this.pictureBox6);
            this.kryptonPanel2.Controls.Add(this.txtMontant);
            this.kryptonPanel2.Controls.Add(this.txtDateMvt);
            this.kryptonPanel2.Controls.Add(this.txtLibelle);
            this.kryptonPanel2.Controls.Add(this.txtModePaiement);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(3, 3);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(506, 202);
            this.kryptonPanel2.TabIndex = 0;
            // 
            // txtCategorie
            // 
            this.txtCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCategorie.DropDownWidth = 166;
            this.txtCategorie.Location = new System.Drawing.Point(76, 126);
            this.txtCategorie.Name = "txtCategorie";
            this.txtCategorie.Size = new System.Drawing.Size(166, 21);
            this.txtCategorie.TabIndex = 39;
            // 
            // txtTiers
            // 
            this.txtTiers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTiers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtTiers.DropDownWidth = 166;
            this.txtTiers.Location = new System.Drawing.Point(76, 99);
            this.txtTiers.Name = "txtTiers";
            this.txtTiers.Size = new System.Drawing.Size(166, 21);
            this.txtTiers.TabIndex = 38;
            // 
            // txtMontant
            // 
            this.txtMontant.DecimalPlaces = 2;
            this.txtMontant.Location = new System.Drawing.Point(270, 125);
            this.txtMontant.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(185, 22);
            this.txtMontant.TabIndex = 37;
            this.txtMontant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontant_KeyPress);
            // 
            // txtDateMvt
            // 
            this.txtDateMvt.Location = new System.Drawing.Point(270, 45);
            this.txtDateMvt.Name = "txtDateMvt";
            this.txtDateMvt.Size = new System.Drawing.Size(186, 21);
            this.txtDateMvt.TabIndex = 34;
            // 
            // txtLibelle
            // 
            this.txtLibelle.Location = new System.Drawing.Point(270, 99);
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(185, 23);
            this.txtLibelle.TabIndex = 36;
            // 
            // txtModePaiement
            // 
            this.txtModePaiement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtModePaiement.DropDownWidth = 185;
            this.txtModePaiement.Location = new System.Drawing.Point(270, 72);
            this.txtModePaiement.Name = "txtModePaiement";
            this.txtModePaiement.Size = new System.Drawing.Size(185, 21);
            this.txtModePaiement.TabIndex = 35;
            this.txtModePaiement.SelectedIndexChanged += new System.EventHandler(this.TxtModePaiement_SelectedIndexChanged);
            // 
            // tabFichier
            // 
            this.tabFichier.Controls.Add(this.kPanelFichier);
            this.tabFichier.Location = new System.Drawing.Point(4, 22);
            this.tabFichier.Name = "tabFichier";
            this.tabFichier.Padding = new System.Windows.Forms.Padding(3);
            this.tabFichier.Size = new System.Drawing.Size(512, 208);
            this.tabFichier.TabIndex = 1;
            this.tabFichier.Text = "Fichiers";
            this.tabFichier.UseVisualStyleBackColor = true;
            // 
            // kPanelFichier
            // 
            this.kPanelFichier.Controls.Add(this.dgvFichiers);
            this.kPanelFichier.Controls.Add(this.btnAddFichier);
            this.kPanelFichier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kPanelFichier.Location = new System.Drawing.Point(3, 3);
            this.kPanelFichier.Name = "kPanelFichier";
            this.kPanelFichier.Size = new System.Drawing.Size(506, 202);
            this.kPanelFichier.TabIndex = 0;
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
            this.dgvFichiers.Location = new System.Drawing.Point(3, 34);
            this.dgvFichiers.MultiSelect = false;
            this.dgvFichiers.Name = "dgvFichiers";
            this.dgvFichiers.ReadOnly = true;
            this.dgvFichiers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFichiers.Size = new System.Drawing.Size(500, 165);
            this.dgvFichiers.TabIndex = 1;
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
            // kLblHeader
            // 
            this.kLblHeader.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.kLblHeader.Location = new System.Drawing.Point(227, 12);
            this.kLblHeader.Name = "kLblHeader";
            this.kLblHeader.Size = new System.Drawing.Size(100, 29);
            this.kLblHeader.TabIndex = 46;
            this.kLblHeader.Values.Text = "Opération";
            // 
            // OFDImport
            // 
            this.OFDImport.Title = "Fichier d\'Opérations à importer";
            // 
            // OperationForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Fermer;
            this.ClientSize = new System.Drawing.Size(546, 320);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModePaiement)).EndInit();
            this.tabFichier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kPanelFichier)).EndInit();
            this.kPanelFichier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichiers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.TabPage tabFichier;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kPanelFichier;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvFichiers;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddFichier;
        private System.Windows.Forms.OpenFileDialog OFDImport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
    }
}