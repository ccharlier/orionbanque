namespace OrionBanque.Forms
{
    partial class CategoriesForm
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
            this.kLblHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox3 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.tvCategorie = new System.Windows.Forms.TreeView();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kCkbCategorieParentMajSup = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.cbModCatPa = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnSupCat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnValidMod = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtLibelleMod = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kCkbCategorieParentAjout = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.cbCategorieParent = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnSauvCat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtLibelleAdd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbModCatPa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategorieParent)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kLblHeader);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox3);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(691, 463);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kLblHeader
            // 
            this.kLblHeader.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.kLblHeader.Location = new System.Drawing.Point(279, 12);
            this.kLblHeader.Name = "kLblHeader";
            this.kLblHeader.Size = new System.Drawing.Size(105, 29);
            this.kLblHeader.TabIndex = 30;
            this.kLblHeader.Values.Text = "Catégories";
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.Location = new System.Drawing.Point(12, 66);
            this.kryptonGroupBox3.Name = "kryptonGroupBox3";
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.tvCategorie);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(274, 380);
            this.kryptonGroupBox3.TabIndex = 19;
            this.kryptonGroupBox3.Values.Heading = "Visualisation";
            // 
            // tvCategorie
            // 
            this.tvCategorie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCategorie.Location = new System.Drawing.Point(0, 0);
            this.tvCategorie.Name = "tvCategorie";
            this.tvCategorie.Size = new System.Drawing.Size(270, 356);
            this.tvCategorie.TabIndex = 0;
            this.tvCategorie.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvCategorie_AfterSelect);
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(292, 66);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.kCkbCategorieParentMajSup);
            this.kryptonGroupBox2.Panel.Controls.Add(this.cbModCatPa);
            this.kryptonGroupBox2.Panel.Controls.Add(this.btnSupCat);
            this.kryptonGroupBox2.Panel.Controls.Add(this.btnValidMod);
            this.kryptonGroupBox2.Panel.Controls.Add(this.txtLibelleMod);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(385, 95);
            this.kryptonGroupBox2.TabIndex = 17;
            this.kryptonGroupBox2.Values.Heading = "Modification / Suppression";
            // 
            // kCkbCategorieParentMajSup
            // 
            this.kCkbCategorieParentMajSup.CheckPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.kCkbCategorieParentMajSup.Location = new System.Drawing.Point(20, 34);
            this.kCkbCategorieParentMajSup.Name = "kCkbCategorieParentMajSup";
            this.kCkbCategorieParentMajSup.Size = new System.Drawing.Size(121, 20);
            this.kCkbCategorieParentMajSup.TabIndex = 21;
            this.kCkbCategorieParentMajSup.Values.Text = "Catégorie Parent :";
            this.kCkbCategorieParentMajSup.CheckedChanged += new System.EventHandler(this.KryptonCheckBox2_CheckedChanged);
            // 
            // cbModCatPa
            // 
            this.cbModCatPa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModCatPa.DropDownWidth = 171;
            this.cbModCatPa.Enabled = false;
            this.cbModCatPa.Location = new System.Drawing.Point(145, 34);
            this.cbModCatPa.Name = "cbModCatPa";
            this.cbModCatPa.Size = new System.Drawing.Size(171, 21);
            this.cbModCatPa.TabIndex = 20;
            // 
            // btnSupCat
            // 
            this.btnSupCat.Location = new System.Drawing.Point(351, 33);
            this.btnSupCat.Name = "btnSupCat";
            this.btnSupCat.Size = new System.Drawing.Size(23, 23);
            this.btnSupCat.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnSupCat, "Supprimer la Catégorie");
            this.btnSupCat.Values.Image = global::OrionBanque.Properties.Resources.cancel1;
            this.btnSupCat.Values.Text = "";
            this.btnSupCat.Click += new System.EventHandler(this.BtnSupCat_Click);
            // 
            // btnValidMod
            // 
            this.btnValidMod.Location = new System.Drawing.Point(322, 33);
            this.btnValidMod.Name = "btnValidMod";
            this.btnValidMod.Size = new System.Drawing.Size(23, 23);
            this.btnValidMod.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnValidMod, "Sauvegarder les changements");
            this.btnValidMod.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.btnValidMod.Values.Text = "";
            this.btnValidMod.Click += new System.EventHandler(this.BtnValidMod_Click);
            // 
            // txtLibelleMod
            // 
            this.txtLibelleMod.Location = new System.Drawing.Point(145, 8);
            this.txtLibelleMod.Name = "txtLibelleMod";
            this.txtLibelleMod.Size = new System.Drawing.Size(171, 23);
            this.txtLibelleMod.TabIndex = 13;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(90, 6);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel2.TabIndex = 13;
            this.kryptonLabel2.Values.Text = "Libelle :";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(294, 167);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kCkbCategorieParentAjout);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cbCategorieParent);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnSauvCat);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtLibelleAdd);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(385, 89);
            this.kryptonGroupBox1.TabIndex = 16;
            this.kryptonGroupBox1.Values.Heading = "Ajout";
            // 
            // kCkbCategorieParentAjout
            // 
            this.kCkbCategorieParentAjout.CheckPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.kCkbCategorieParentAjout.Location = new System.Drawing.Point(20, 30);
            this.kCkbCategorieParentAjout.Name = "kCkbCategorieParentAjout";
            this.kCkbCategorieParentAjout.Size = new System.Drawing.Size(121, 20);
            this.kCkbCategorieParentAjout.TabIndex = 18;
            this.kCkbCategorieParentAjout.Values.Text = "Catégorie Parent :";
            this.kCkbCategorieParentAjout.CheckedChanged += new System.EventHandler(this.KryptonCheckBox1_CheckedChanged);
            // 
            // cbCategorieParent
            // 
            this.cbCategorieParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategorieParent.DropDownWidth = 171;
            this.cbCategorieParent.Enabled = false;
            this.cbCategorieParent.Location = new System.Drawing.Point(145, 30);
            this.cbCategorieParent.Name = "cbCategorieParent";
            this.cbCategorieParent.Size = new System.Drawing.Size(171, 21);
            this.cbCategorieParent.TabIndex = 17;
            // 
            // btnSauvCat
            // 
            this.btnSauvCat.Location = new System.Drawing.Point(322, 29);
            this.btnSauvCat.Name = "btnSauvCat";
            this.btnSauvCat.Size = new System.Drawing.Size(23, 23);
            this.btnSauvCat.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnSauvCat, "Ajouter cette Catégorie");
            this.btnSauvCat.Values.Image = global::OrionBanque.Properties.Resources.add1;
            this.btnSauvCat.Values.Text = "";
            this.btnSauvCat.Click += new System.EventHandler(this.BtnSauvCat_Click);
            // 
            // txtLibelleAdd
            // 
            this.txtLibelleAdd.Location = new System.Drawing.Point(145, 4);
            this.txtLibelleAdd.Name = "txtLibelleAdd";
            this.txtLibelleAdd.Size = new System.Drawing.Size(171, 23);
            this.txtLibelleAdd.TabIndex = 11;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(90, 5);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel1.TabIndex = 10;
            this.kryptonLabel1.Values.Text = "Libelle :";
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 463);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoriesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Catégories";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).EndInit();
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbModCatPa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbCategorieParent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSupCat;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnValidMod;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLibelleMod;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSauvCat;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLibelleAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kCkbCategorieParentAjout;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbCategorieParent;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox3;
        private System.Windows.Forms.TreeView tvCategorie;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kCkbCategorieParentMajSup;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbModCatPa;
        private System.Windows.Forms.ToolTip toolTip1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kLblHeader;
    }
}