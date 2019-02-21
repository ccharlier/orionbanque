namespace OrionBanque.Forms
{
    partial class GestTiersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestTiersForm));
            this.kLBTiersSaisis = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kBtnDesactiveOne = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kBtnActiveOne = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kLBTiersPredict = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kLBTiersSaisis
            // 
            this.kLBTiersSaisis.Location = new System.Drawing.Point(71, 69);
            this.kLBTiersSaisis.Name = "kLBTiersSaisis";
            this.kLBTiersSaisis.Size = new System.Drawing.Size(195, 306);
            this.kLBTiersSaisis.TabIndex = 1;
            this.kLBTiersSaisis.DoubleClick += new System.EventHandler(this.kLBTiersSaisis_DoubleClick);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.kBtnDesactiveOne);
            this.kryptonPanel1.Controls.Add(this.kBtnActiveOne);
            this.kryptonPanel1.Controls.Add(this.kLBTiersPredict);
            this.kryptonPanel1.Controls.Add(this.kLBTiersSaisis);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(646, 419);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(392, 43);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(147, 20);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Tiers dans les prédictions";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(135, 43);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Tiers saisis";
            // 
            // kBtnDesactiveOne
            // 
            this.kBtnDesactiveOne.Location = new System.Drawing.Point(272, 229);
            this.kBtnDesactiveOne.Name = "kBtnDesactiveOne";
            this.kBtnDesactiveOne.Size = new System.Drawing.Size(93, 25);
            this.kBtnDesactiveOne.TabIndex = 3;
            this.toolTip.SetToolTip(this.kBtnDesactiveOne, "Désactiver le Tiers sélectionné");
            this.kBtnDesactiveOne.Values.Image = global::OrionBanque.Properties.Resources.arrow180;
            this.kBtnDesactiveOne.Values.Text = "";
            this.kBtnDesactiveOne.Click += new System.EventHandler(this.kBtnDesactiveOne_Click);
            // 
            // kBtnActiveOne
            // 
            this.kBtnActiveOne.Location = new System.Drawing.Point(272, 175);
            this.kBtnActiveOne.Name = "kBtnActiveOne";
            this.kBtnActiveOne.Size = new System.Drawing.Size(93, 25);
            this.kBtnActiveOne.TabIndex = 2;
            this.toolTip.SetToolTip(this.kBtnActiveOne, "Activer le Tiers sélectionné");
            this.kBtnActiveOne.Values.Image = global::OrionBanque.Properties.Resources.arrow;
            this.kBtnActiveOne.Values.Text = "";
            this.kBtnActiveOne.Click += new System.EventHandler(this.kBtnActiveOne_Click);
            // 
            // kLBTiersPredict
            // 
            this.kLBTiersPredict.Location = new System.Drawing.Point(371, 69);
            this.kLBTiersPredict.Name = "kLBTiersPredict";
            this.kLBTiersPredict.Size = new System.Drawing.Size(195, 306);
            this.kLBTiersPredict.TabIndex = 4;
            this.kLBTiersPredict.DoubleClick += new System.EventHandler(this.kLBTiersPredict_DoubleClick);
            // 
            // GestTiersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 419);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GestTiersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion des Tiers";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonListBox kLBTiersSaisis;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnDesactiveOne;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnActiveOne;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox kLBTiersPredict;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ToolTip toolTip;
    }
}