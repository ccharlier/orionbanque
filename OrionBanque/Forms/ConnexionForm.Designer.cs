namespace OrionBanque.Forms
{
    partial class ConnexionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnexionForm));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kBtnTrashRefFileOB = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kBtnCreerFichierCompteOB = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kBtnOuvrirFichierCompteOB = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kLbFile = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.kLblHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnAddCompte = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Fermer = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.OK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtMdp = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtLogin = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.OFDOrionBanque = new System.Windows.Forms.OpenFileDialog();
            this.FBDOrionBanque = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kBtnTrashRefFileOB);
            this.kryptonPanel1.Controls.Add(this.kBtnCreerFichierCompteOB);
            this.kryptonPanel1.Controls.Add(this.kBtnOuvrirFichierCompteOB);
            this.kryptonPanel1.Controls.Add(this.kLbFile);
            this.kryptonPanel1.Controls.Add(this.kLblHeader);
            this.kryptonPanel1.Controls.Add(this.btnAddCompte);
            this.kryptonPanel1.Controls.Add(this.Fermer);
            this.kryptonPanel1.Controls.Add(this.OK);
            this.kryptonPanel1.Controls.Add(this.txtMdp);
            this.kryptonPanel1.Controls.Add(this.txtLogin);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(405, 320);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kBtnTrashRefFileOB
            // 
            this.kBtnTrashRefFileOB.Enabled = false;
            this.kBtnTrashRefFileOB.Location = new System.Drawing.Point(190, 196);
            this.kBtnTrashRefFileOB.Name = "kBtnTrashRefFileOB";
            this.kBtnTrashRefFileOB.Size = new System.Drawing.Size(23, 23);
            this.kBtnTrashRefFileOB.TabIndex = 34;
            this.toolTip1.SetToolTip(this.kBtnTrashRefFileOB, "Supprime la référence à ce fichier OrionBanque");
            this.kBtnTrashRefFileOB.Values.Image = global::OrionBanque.Properties.Resources.bin_closed;
            this.kBtnTrashRefFileOB.Values.Text = "";
            this.kBtnTrashRefFileOB.Click += new System.EventHandler(this.KBtnTrashRefFileOB_Click);
            // 
            // kBtnCreerFichierCompteOB
            // 
            this.kBtnCreerFichierCompteOB.Location = new System.Drawing.Point(12, 196);
            this.kBtnCreerFichierCompteOB.Name = "kBtnCreerFichierCompteOB";
            this.kBtnCreerFichierCompteOB.Size = new System.Drawing.Size(23, 23);
            this.kBtnCreerFichierCompteOB.TabIndex = 33;
            this.toolTip1.SetToolTip(this.kBtnCreerFichierCompteOB, "Créer un nouveau fichier de Compte OrionBanque");
            this.kBtnCreerFichierCompteOB.Values.Image = global::OrionBanque.Properties.Resources.page_add;
            this.kBtnCreerFichierCompteOB.Values.Text = "";
            this.kBtnCreerFichierCompteOB.Click += new System.EventHandler(this.KBtnCreerFichierCompteOB_Click);
            // 
            // kBtnOuvrirFichierCompteOB
            // 
            this.kBtnOuvrirFichierCompteOB.Location = new System.Drawing.Point(370, 196);
            this.kBtnOuvrirFichierCompteOB.Name = "kBtnOuvrirFichierCompteOB";
            this.kBtnOuvrirFichierCompteOB.Size = new System.Drawing.Size(23, 23);
            this.kBtnOuvrirFichierCompteOB.TabIndex = 32;
            this.toolTip1.SetToolTip(this.kBtnOuvrirFichierCompteOB, "Ouvrir un fichier de compte OrionBanque");
            this.kBtnOuvrirFichierCompteOB.Values.Image = global::OrionBanque.Properties.Resources.folder_page;
            this.kBtnOuvrirFichierCompteOB.Values.Text = "";
            this.kBtnOuvrirFichierCompteOB.Click += new System.EventHandler(this.KBtnOuvrirFichierCompteOB_Click);
            // 
            // kLbFile
            // 
            this.kLbFile.Location = new System.Drawing.Point(12, 47);
            this.kLbFile.Name = "kLbFile";
            this.kLbFile.Size = new System.Drawing.Size(381, 143);
            this.kLbFile.TabIndex = 31;
            this.kLbFile.SelectedIndexChanged += new System.EventHandler(this.KLbFile_SelectedIndexChanged);
            // 
            // kLblHeader
            // 
            this.kLblHeader.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.kLblHeader.Location = new System.Drawing.Point(137, 12);
            this.kLblHeader.Name = "kLblHeader";
            this.kLblHeader.Size = new System.Drawing.Size(106, 29);
            this.kLblHeader.TabIndex = 29;
            this.kLblHeader.Values.Text = "Connexion";
            // 
            // btnAddCompte
            // 
            this.btnAddCompte.Enabled = false;
            this.btnAddCompte.Location = new System.Drawing.Point(190, 283);
            this.btnAddCompte.Name = "btnAddCompte";
            this.btnAddCompte.Size = new System.Drawing.Size(23, 23);
            this.btnAddCompte.TabIndex = 28;
            this.toolTip1.SetToolTip(this.btnAddCompte, "Ajouter un utilisateur");
            this.btnAddCompte.Values.Image = global::OrionBanque.Properties.Resources.user_add;
            this.btnAddCompte.Values.Text = "";
            this.btnAddCompte.Click += new System.EventHandler(this.BtnAddCompte_Click);
            // 
            // Fermer
            // 
            this.Fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Fermer.Location = new System.Drawing.Point(12, 283);
            this.Fermer.Name = "Fermer";
            this.Fermer.Size = new System.Drawing.Size(23, 23);
            this.Fermer.TabIndex = 24;
            this.toolTip1.SetToolTip(this.Fermer, "Fermer OrionBanque sans se connecter");
            this.Fermer.Values.Image = global::OrionBanque.Properties.Resources.cross1;
            this.Fermer.Values.Text = "";
            // 
            // OK
            // 
            this.OK.Enabled = false;
            this.OK.Location = new System.Drawing.Point(370, 283);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(23, 23);
            this.OK.TabIndex = 25;
            this.toolTip1.SetToolTip(this.OK, "Se connecter avec les identifiants précisés");
            this.OK.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.OK.Values.Text = "";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // txtMdp
            // 
            this.txtMdp.Enabled = false;
            this.txtMdp.Location = new System.Drawing.Point(108, 254);
            this.txtMdp.Name = "txtMdp";
            this.txtMdp.PasswordChar = '●';
            this.txtMdp.Size = new System.Drawing.Size(285, 23);
            this.txtMdp.TabIndex = 23;
            this.txtMdp.UseSystemPasswordChar = true;
            // 
            // txtLogin
            // 
            this.txtLogin.Enabled = false;
            this.txtLogin.Location = new System.Drawing.Point(108, 225);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(285, 23);
            this.txtLogin.TabIndex = 22;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 257);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(90, 20);
            this.kryptonLabel1.TabIndex = 21;
            this.kryptonLabel1.Values.Text = "Mot de passe :";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(30, 228);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel3.TabIndex = 20;
            this.kryptonLabel3.Values.Text = "Utilisateur :";
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // OFDOrionBanque
            // 
            this.OFDOrionBanque.Filter = "Fichier OrionBanque|*.obq";
            // 
            // FBDOrionBanque
            // 
            this.FBDOrionBanque.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ConnexionForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Fermer;
            this.ClientSize = new System.Drawing.Size(405, 320);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnexionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connexion";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMdp;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Fermer;
        private ComponentFactory.Krypton.Toolkit.KryptonButton OK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddCompte;
        private System.Windows.Forms.ToolTip toolTip1;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kLblHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLogin;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox kLbFile;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnOuvrirFichierCompteOB;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnCreerFichierCompteOB;
        private System.Windows.Forms.OpenFileDialog OFDOrionBanque;
        private System.Windows.Forms.FolderBrowserDialog FBDOrionBanque;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnTrashRefFileOB;
    }
}