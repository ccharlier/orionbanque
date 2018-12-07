namespace OrionBanque.Forms
{
    partial class FichiersForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FichiersForm));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.kDgvFichiers = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tT = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kDgvFichiers)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kDgvFichiers);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(958, 549);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kDgvFichiers
            // 
            this.kDgvFichiers.AllowUserToAddRows = false;
            this.kDgvFichiers.AllowUserToDeleteRows = false;
            this.kDgvFichiers.AllowUserToOrderColumns = true;
            this.kDgvFichiers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kDgvFichiers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kDgvFichiers.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.kDgvFichiers.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.kDgvFichiers.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kDgvFichiers.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kDgvFichiers.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kDgvFichiers.Location = new System.Drawing.Point(0, 0);
            this.kDgvFichiers.Name = "kDgvFichiers";
            this.kDgvFichiers.ReadOnly = true;
            this.kDgvFichiers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kDgvFichiers.Size = new System.Drawing.Size(958, 549);
            this.kDgvFichiers.TabIndex = 1;
            this.tT.SetToolTip(this.kDgvFichiers, "Vous pouvez double cliquer pour ouvrir le fichier.\r\nIl sera ouvert avec le progra" +
        "mme par dédaut du Système");
            this.kDgvFichiers.DoubleClick += new System.EventHandler(this.kDgvFichiers_DoubleClick);
            // 
            // FichiersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 549);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FichiersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion des Tiers";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kDgvFichiers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ToolTip toolTip;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kDgvFichiers;
        private System.Windows.Forms.ToolTip tT;
    }
}