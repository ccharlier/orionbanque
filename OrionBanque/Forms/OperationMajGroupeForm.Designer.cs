namespace OrionBanque.Forms
{
    partial class OperationMajGroupeForm
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
            if(disposing && (components != null))
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kLblHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kBtnValidTiers = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kCbTiersVers = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kCbTiersDe = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnValidCat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtCategorieDest = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtCategorieOri = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kCbTiersVers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kCbTiersDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorieDest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorieOri)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kLblHeader);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(418, 302);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kLblHeader
            // 
            this.kLblHeader.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.kLblHeader.Location = new System.Drawing.Point(145, 12);
            this.kLblHeader.Name = "kLblHeader";
            this.kLblHeader.Size = new System.Drawing.Size(109, 29);
            this.kLblHeader.TabIndex = 36;
            this.kLblHeader.Values.Text = "Mise à jour";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(12, 167);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.kBtnValidTiers);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kCbTiersVers);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kCbTiersDe);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(394, 112);
            this.kryptonGroupBox2.TabIndex = 35;
            this.kryptonGroupBox2.Values.Heading = "Transfert Tiers";
            this.kryptonGroupBox2.Values.Image = global::OrionBanque.Properties.Resources.user_business;
            // 
            // kBtnValidTiers
            // 
            this.kBtnValidTiers.Location = new System.Drawing.Point(296, 46);
            this.kBtnValidTiers.Name = "kBtnValidTiers";
            this.kBtnValidTiers.Size = new System.Drawing.Size(23, 23);
            this.kBtnValidTiers.TabIndex = 42;
            this.kBtnValidTiers.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.kBtnValidTiers.Values.Text = "";
            // 
            // kCbTiersVers
            // 
            this.kCbTiersVers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kCbTiersVers.DropDownWidth = 166;
            this.kCbTiersVers.Location = new System.Drawing.Point(115, 46);
            this.kCbTiersVers.Name = "kCbTiersVers";
            this.kCbTiersVers.Size = new System.Drawing.Size(166, 21);
            this.kCbTiersVers.TabIndex = 41;
            // 
            // kCbTiersDe
            // 
            this.kCbTiersDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kCbTiersDe.DropDownWidth = 166;
            this.kCbTiersDe.Location = new System.Drawing.Point(115, 19);
            this.kCbTiersDe.Name = "kCbTiersDe";
            this.kCbTiersDe.Size = new System.Drawing.Size(166, 21);
            this.kCbTiersDe.TabIndex = 40;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(71, 48);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(40, 20);
            this.kryptonLabel3.TabIndex = 1;
            this.kryptonLabel3.Values.Text = "Vers :";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(79, 21);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(32, 20);
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.Values.Text = "De :";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 49);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnValidCat);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtCategorieDest);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtCategorieOri);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(394, 112);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Transfert Catégorie";
            this.kryptonGroupBox1.Values.Image = global::OrionBanque.Properties.Resources.chart_organisation1;
            // 
            // btnValidCat
            // 
            this.btnValidCat.Location = new System.Drawing.Point(296, 46);
            this.btnValidCat.Name = "btnValidCat";
            this.btnValidCat.Size = new System.Drawing.Size(23, 23);
            this.btnValidCat.TabIndex = 42;
            this.btnValidCat.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.btnValidCat.Values.Text = "";
            this.btnValidCat.Click += new System.EventHandler(this.BtnValidCat_Click);
            // 
            // txtCategorieDest
            // 
            this.txtCategorieDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCategorieDest.DropDownWidth = 166;
            this.txtCategorieDest.Location = new System.Drawing.Point(115, 46);
            this.txtCategorieDest.Name = "txtCategorieDest";
            this.txtCategorieDest.Size = new System.Drawing.Size(166, 21);
            this.txtCategorieDest.TabIndex = 41;
            // 
            // txtCategorieOri
            // 
            this.txtCategorieOri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCategorieOri.DropDownWidth = 166;
            this.txtCategorieOri.Location = new System.Drawing.Point(115, 19);
            this.txtCategorieOri.Name = "txtCategorieOri";
            this.txtCategorieOri.Size = new System.Drawing.Size(166, 21);
            this.txtCategorieOri.TabIndex = 40;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(71, 48);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(40, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Vers :";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(79, 21);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(32, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "De :";
            // 
            // OperationMajGroupeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 302);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperationMajGroupeForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mise à jour en Masse des Opérations";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kCbTiersVers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kCbTiersDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorieDest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorieOri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtCategorieDest;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtCategorieOri;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnValidCat;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnValidTiers;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kCbTiersVers;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kCbTiersDe;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kLblHeader;
    }
}