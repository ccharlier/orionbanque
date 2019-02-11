namespace OrionBanque.Forms
{
    partial class TotalComptesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TotalComptesForm));
            this.kDgvTotalCompte = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.miniToolStrip = new System.Windows.Forms.StatusStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kLBCompte = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
            this.kCbListTotalCompte = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnSpecTtCpteAjout = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnSpecTtCpteSupprime = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.kDgvTotalCompte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kCbListTotalCompte)).BeginInit();
            this.SuspendLayout();
            // 
            // kDgvTotalCompte
            // 
            this.kDgvTotalCompte.AllowUserToAddRows = false;
            this.kDgvTotalCompte.AllowUserToDeleteRows = false;
            this.kDgvTotalCompte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kDgvTotalCompte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kDgvTotalCompte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kDgvTotalCompte.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.kDgvTotalCompte.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.kDgvTotalCompte.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kDgvTotalCompte.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kDgvTotalCompte.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kDgvTotalCompte.Location = new System.Drawing.Point(0, 0);
            this.kDgvTotalCompte.Name = "kDgvTotalCompte";
            this.kDgvTotalCompte.ReadOnly = true;
            this.kDgvTotalCompte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kDgvTotalCompte.Size = new System.Drawing.Size(504, 323);
            this.kDgvTotalCompte.TabIndex = 0;
            this.kDgvTotalCompte.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.kDgvTotalCompte_CellFormatting);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "Nouvelle sélection d\'élément";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(1, 1);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(613, 22);
            this.miniToolStrip.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 323);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(770, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kCbListTotalCompte);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kLBCompte);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kDgvTotalCompte);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(770, 323);
            this.kryptonSplitContainer1.SplitterDistance = 261;
            this.kryptonSplitContainer1.TabIndex = 2;
            // 
            // kLBCompte
            // 
            this.kLBCompte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kLBCompte.Location = new System.Drawing.Point(0, 27);
            this.kLBCompte.Name = "kLBCompte";
            this.kLBCompte.Size = new System.Drawing.Size(262, 296);
            this.kLBCompte.TabIndex = 1;
            this.kLBCompte.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.kLBCompte_ItemCheck);
            // 
            // kCbListTotalCompte
            // 
            this.kCbListTotalCompte.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSpecTtCpteAjout,
            this.btnSpecTtCpteSupprime});
            this.kCbListTotalCompte.DisplayMember = "Libelle";
            this.kCbListTotalCompte.Dock = System.Windows.Forms.DockStyle.Top;
            this.kCbListTotalCompte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kCbListTotalCompte.DropDownWidth = 216;
            this.kCbListTotalCompte.Location = new System.Drawing.Point(0, 0);
            this.kCbListTotalCompte.Name = "kCbListTotalCompte";
            this.kCbListTotalCompte.Size = new System.Drawing.Size(261, 24);
            this.kCbListTotalCompte.TabIndex = 1;
            this.kCbListTotalCompte.ValueMember = "Id";
            this.kCbListTotalCompte.SelectedIndexChanged += new System.EventHandler(this.kCbListTotalCompte_SelectedIndexChanged);
            // 
            // btnSpecTtCpteAjout
            // 
            this.btnSpecTtCpteAjout.Image = global::OrionBanque.Properties.Resources.add1;
            this.btnSpecTtCpteAjout.ToolTipBody = "Permet d\'ajouter une configuration de Total des Comptes";
            this.btnSpecTtCpteAjout.UniqueName = "DAC7921262A24A9E069DAF0E2ACB3326";
            this.btnSpecTtCpteAjout.Click += new System.EventHandler(this.btnSpecTtCpteAjout_Click);
            // 
            // btnSpecTtCpteSupprime
            // 
            this.btnSpecTtCpteSupprime.Image = global::OrionBanque.Properties.Resources.cross1;
            this.btnSpecTtCpteSupprime.ToolTipBody = "Permet de Supprimer la configuration actuelle de Total des Comptes";
            this.btnSpecTtCpteSupprime.UniqueName = "571357E9D3244D5F6BA182783B2EE658";
            this.btnSpecTtCpteSupprime.Click += new System.EventHandler(this.btnSpecTtCpteSupprime_Click);
            // 
            // TotalComptesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 345);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TotalComptesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Total des Comptes";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kDgvTotalCompte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kCbListTotalCompte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kDgvTotalCompte;
        private System.Windows.Forms.StatusStrip miniToolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox kLBCompte;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kCbListTotalCompte;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSpecTtCpteAjout;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSpecTtCpteSupprime;
    }
}