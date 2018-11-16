namespace OrionBanque.Forms
{
    partial class ModePaiementForm
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
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbDebCredAdd = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtLibelleAdd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnSupCat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnValidMod = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbDebCredMod = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cbModePaiement = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtLibelleMod = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDebCredAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDebCredMod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbModePaiement)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(478, 263);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.kryptonLabel6.Location = new System.Drawing.Point(168, 12);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(177, 29);
            this.kryptonLabel6.TabIndex = 30;
            this.kryptonLabel6.Values.Text = "Mode de Paiement";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(12, 164);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.btnAdd);
            this.kryptonGroupBox2.Panel.Controls.Add(this.cbDebCredAdd);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel5);
            this.kryptonGroupBox2.Panel.Controls.Add(this.txtLibelleAdd);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(452, 85);
            this.kryptonGroupBox2.TabIndex = 24;
            this.kryptonGroupBox2.Values.Heading = "Ajout";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(386, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btnAdd, "Ajouter un mode de paiement");
            this.btnAdd.Values.Image = global::OrionBanque.Properties.Resources.add1;
            this.btnAdd.Values.Text = "";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // cbDebCredAdd
            // 
            this.cbDebCredAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDebCredAdd.DropDownWidth = 171;
            this.cbDebCredAdd.Items.AddRange(new object[] {
            "Débit",
            "Crédit"});
            this.cbDebCredAdd.Location = new System.Drawing.Point(212, 29);
            this.cbDebCredAdd.Name = "cbDebCredAdd";
            this.cbDebCredAdd.Size = new System.Drawing.Size(166, 21);
            this.cbDebCredAdd.TabIndex = 23;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel5.Location = new System.Drawing.Point(115, 29);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel5.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel5.TabIndex = 22;
            this.kryptonLabel5.Values.Text = "Débit / Crédit :";
            // 
            // txtLibelleAdd
            // 
            this.txtLibelleAdd.Location = new System.Drawing.Point(212, 3);
            this.txtLibelleAdd.Name = "txtLibelleAdd";
            this.txtLibelleAdd.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txtLibelleAdd.Size = new System.Drawing.Size(166, 23);
            this.txtLibelleAdd.TabIndex = 21;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel4.Location = new System.Drawing.Point(154, 3);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel4.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel4.TabIndex = 20;
            this.kryptonLabel4.Values.Text = "Libelle :";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 49);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnSupCat);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnValidMod);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cbDebCredMod);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cbModePaiement);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtLibelleMod);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(452, 109);
            this.kryptonGroupBox1.TabIndex = 23;
            this.kryptonGroupBox1.Values.Heading = "Modification / Suppression";
            // 
            // btnSupCat
            // 
            this.btnSupCat.Location = new System.Drawing.Point(415, 55);
            this.btnSupCat.Name = "btnSupCat";
            this.btnSupCat.Size = new System.Drawing.Size(23, 23);
            this.btnSupCat.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btnSupCat, "Supprimer le mode de paiement");
            this.btnSupCat.Values.Image = global::OrionBanque.Properties.Resources.cancel1;
            this.btnSupCat.Values.Text = "";
            this.btnSupCat.Click += new System.EventHandler(this.BtnSupCat_Click);
            // 
            // btnValidMod
            // 
            this.btnValidMod.Location = new System.Drawing.Point(386, 55);
            this.btnValidMod.Name = "btnValidMod";
            this.btnValidMod.Size = new System.Drawing.Size(23, 23);
            this.btnValidMod.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnValidMod, "Valider les changements");
            this.btnValidMod.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.btnValidMod.Values.Text = "";
            this.btnValidMod.Click += new System.EventHandler(this.BtnValidMod_Click);
            // 
            // cbDebCredMod
            // 
            this.cbDebCredMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDebCredMod.DropDownWidth = 171;
            this.cbDebCredMod.Items.AddRange(new object[] {
            "Débit",
            "Crédit"});
            this.cbDebCredMod.Location = new System.Drawing.Point(212, 56);
            this.cbDebCredMod.Name = "cbDebCredMod";
            this.cbDebCredMod.Size = new System.Drawing.Size(166, 21);
            this.cbDebCredMod.TabIndex = 21;
            // 
            // cbModePaiement
            // 
            this.cbModePaiement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModePaiement.DropDownWidth = 171;
            this.cbModePaiement.Location = new System.Drawing.Point(212, 3);
            this.cbModePaiement.Name = "cbModePaiement";
            this.cbModePaiement.Size = new System.Drawing.Size(166, 21);
            this.cbModePaiement.TabIndex = 20;
            this.cbModePaiement.SelectedIndexChanged += new System.EventHandler(this.CbModePaiement_SelectedIndexChanged);
            // 
            // txtLibelleMod
            // 
            this.txtLibelleMod.Location = new System.Drawing.Point(212, 30);
            this.txtLibelleMod.Name = "txtLibelleMod";
            this.txtLibelleMod.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txtLibelleMod.Size = new System.Drawing.Size(166, 23);
            this.txtLibelleMod.TabIndex = 19;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel3.Location = new System.Drawing.Point(154, 30);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel3.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel3.TabIndex = 18;
            this.kryptonLabel3.Values.Text = "Libelle :";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(115, 56);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel2.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel2.TabIndex = 17;
            this.kryptonLabel2.Values.Text = "Débit / Crédit :";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(86, 4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonLabel1.Size = new System.Drawing.Size(120, 20);
            this.kryptonLabel1.TabIndex = 16;
            this.kryptonLabel1.Values.Text = "Mode de Paiement :";
            // 
            // ModePaiement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 263);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModePaiement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrionBanque -  Mode de Paiement";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbDebCredAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbDebCredMod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbModePaiement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLibelleMod;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbDebCredMod;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbModePaiement;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSupCat;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnValidMod;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbDebCredAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLibelleAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private System.Windows.Forms.ToolTip toolTip1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
    }
}