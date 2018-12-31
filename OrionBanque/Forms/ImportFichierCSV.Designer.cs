namespace OrionBanque.Forms
{
    partial class ImportFichierCSV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFichierCSV));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.cbCompte = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kLblCompte = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kTbFileNameImport = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSpecParcourir = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.OK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ODFImport = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompte)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.OK);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.kTbFileNameImport);
            this.kryptonPanel1.Controls.Add(this.kLblCompte);
            this.kryptonPanel1.Controls.Add(this.cbCompte);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 187);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // cbCompte
            // 
            this.cbCompte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCompte.DisplayMember = "Libelle";
            this.cbCompte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompte.DropDownWidth = 121;
            this.cbCompte.Location = new System.Drawing.Point(288, 42);
            this.cbCompte.Name = "cbCompte";
            this.cbCompte.Size = new System.Drawing.Size(404, 21);
            this.cbCompte.TabIndex = 38;
            this.cbCompte.ValueMember = "Id";
            // 
            // kLblCompte
            // 
            this.kLblCompte.Location = new System.Drawing.Point(62, 42);
            this.kLblCompte.Name = "kLblCompte";
            this.kLblCompte.Size = new System.Drawing.Size(220, 20);
            this.kLblCompte.TabIndex = 39;
            this.kLblCompte.Values.Text = "Choix du compte dans lequel importer";
            // 
            // kTbFileNameImport
            // 
            this.kTbFileNameImport.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSpecParcourir});
            this.kTbFileNameImport.Location = new System.Drawing.Point(288, 86);
            this.kTbFileNameImport.Name = "kTbFileNameImport";
            this.kTbFileNameImport.ReadOnly = true;
            this.kTbFileNameImport.Size = new System.Drawing.Size(404, 28);
            this.kTbFileNameImport.TabIndex = 40;
            // 
            // btnSpecParcourir
            // 
            this.btnSpecParcourir.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Cluster;
            this.btnSpecParcourir.Text = "Parcourir...";
            this.btnSpecParcourir.UniqueName = "CF3806F2CD4742514DB3A1C646F72743";
            this.btnSpecParcourir.Click += new System.EventHandler(this.btnSpecParcourir_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(187, 89);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(95, 20);
            this.kryptonLabel1.TabIndex = 41;
            this.kryptonLabel1.Values.Text = "Choix du fichier";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(669, 130);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(23, 23);
            this.OK.TabIndex = 43;
            this.OK.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.OK.Values.Text = "";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // ODFImport
            // 
            this.ODFImport.Title = "Fichier d\'Opérations à importer";
            // 
            // ImportFichierCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 187);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportFichierCSV";
            this.Text = "Importer un fichier CSV";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kTbFileNameImport;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSpecParcourir;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kLblCompte;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbCompte;
        private ComponentFactory.Krypton.Toolkit.KryptonButton OK;
        private System.Windows.Forms.OpenFileDialog ODFImport;
    }
}