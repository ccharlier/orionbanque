namespace OrionBanque.Forms
{
    partial class Utilisateur
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
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.showPwd = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkPwd = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.Fermer = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.OK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtMdp = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtLogin = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.showPwd);
            this.kryptonPanel1.Controls.Add(this.chkPwd);
            this.kryptonPanel1.Controls.Add(this.Fermer);
            this.kryptonPanel1.Controls.Add(this.OK);
            this.kryptonPanel1.Controls.Add(this.txtMdp);
            this.kryptonPanel1.Controls.Add(this.txtLogin);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(334, 166);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.kryptonLabel3.Location = new System.Drawing.Point(115, 12);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(103, 29);
            this.kryptonLabel3.TabIndex = 30;
            this.kryptonLabel3.Values.Text = "Utilisateur";
            // 
            // showPwd
            // 
            this.showPwd.Location = new System.Drawing.Point(115, 112);
            this.showPwd.Name = "showPwd";
            this.showPwd.Size = new System.Drawing.Size(6, 2);
            this.showPwd.TabIndex = 24;
            this.showPwd.Values.Text = "";
            // 
            // chkPwd
            // 
            this.chkPwd.Location = new System.Drawing.Point(245, 87);
            this.chkPwd.Name = "chkPwd";
            this.chkPwd.Size = new System.Drawing.Size(68, 20);
            this.chkPwd.TabIndex = 23;
            this.chkPwd.Values.Text = "Montrer";
            this.chkPwd.CheckedChanged += new System.EventHandler(this.ChkPwd_CheckedChanged);
            // 
            // Fermer
            // 
            this.Fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Fermer.Location = new System.Drawing.Point(115, 115);
            this.Fermer.Name = "Fermer";
            this.Fermer.Size = new System.Drawing.Size(23, 23);
            this.Fermer.TabIndex = 21;
            this.toolTip1.SetToolTip(this.Fermer, "Fermer la fenêtre sans enregistrer");
            this.Fermer.Values.Image = global::OrionBanque.Properties.Resources.cross1;
            this.Fermer.Values.Text = "";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(216, 115);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(23, 23);
            this.OK.TabIndex = 22;
            this.toolTip1.SetToolTip(this.OK, "Valider la fenêtre");
            this.OK.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.OK.Values.Text = "";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // txtMdp
            // 
            this.txtMdp.Location = new System.Drawing.Point(115, 86);
            this.txtMdp.Name = "txtMdp";
            this.txtMdp.PasswordChar = '●';
            this.txtMdp.Size = new System.Drawing.Size(124, 23);
            this.txtMdp.TabIndex = 19;
            this.txtMdp.UseSystemPasswordChar = true;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(115, 60);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(124, 23);
            this.txtLogin.TabIndex = 18;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(24, 87);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(90, 20);
            this.kryptonLabel2.TabIndex = 17;
            this.kryptonLabel2.Values.Text = "Mot de Passe :";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(64, 60);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(47, 20);
            this.kryptonLabel1.TabIndex = 16;
            this.kryptonLabel1.Values.Text = "Login :";
            // 
            // Utilisateur
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Fermer;
            this.ClientSize = new System.Drawing.Size(334, 166);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Utilisateur";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrionBanque - Utilisateur";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Fermer;
        private ComponentFactory.Krypton.Toolkit.KryptonButton OK;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMdp;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLogin;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkPwd;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel showPwd;
        private System.Windows.Forms.ToolTip toolTip1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
    }
}