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
            this.kPanelMain = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.kDgvTotalCompte = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kPanelMain)).BeginInit();
            this.kPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kDgvTotalCompte)).BeginInit();
            this.SuspendLayout();
            // 
            // kPanelMain
            // 
            this.kPanelMain.Controls.Add(this.kDgvTotalCompte);
            this.kPanelMain.Controls.Add(this.statusStrip);
            this.kPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kPanelMain.Location = new System.Drawing.Point(0, 0);
            this.kPanelMain.Name = "kPanelMain";
            this.kPanelMain.Size = new System.Drawing.Size(613, 301);
            this.kPanelMain.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 279);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(613, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
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
            this.kDgvTotalCompte.Size = new System.Drawing.Size(613, 279);
            this.kDgvTotalCompte.TabIndex = 0;
            this.kDgvTotalCompte.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.kDgvTotalCompte_CellFormatting);
            // 
            // TotalComptes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 301);
            this.Controls.Add(this.kPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TotalComptes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Total des Comptes";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kPanelMain)).EndInit();
            this.kPanelMain.ResumeLayout(false);
            this.kPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kDgvTotalCompte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kPanelMain;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kDgvTotalCompte;
        private System.Windows.Forms.StatusStrip statusStrip;
    }
}