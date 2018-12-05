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
            this.kryptonListBox1 = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonListBox2 = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.kBtnActiveOne = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kBtnDesactiveOne = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kBtnDesactiveAll = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kBtnActiveAll = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonListBox1
            // 
            this.kryptonListBox1.Location = new System.Drawing.Point(76, 69);
            this.kryptonListBox1.Name = "kryptonListBox1";
            this.kryptonListBox1.Size = new System.Drawing.Size(195, 306);
            this.kryptonListBox1.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kBtnDesactiveAll);
            this.kryptonPanel1.Controls.Add(this.kBtnActiveAll);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.kBtnDesactiveOne);
            this.kryptonPanel1.Controls.Add(this.kBtnActiveOne);
            this.kryptonPanel1.Controls.Add(this.kryptonListBox2);
            this.kryptonPanel1.Controls.Add(this.kryptonListBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(646, 419);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonListBox2
            // 
            this.kryptonListBox2.Location = new System.Drawing.Point(376, 69);
            this.kryptonListBox2.Name = "kryptonListBox2";
            this.kryptonListBox2.Size = new System.Drawing.Size(195, 306);
            this.kryptonListBox2.TabIndex = 1;
            // 
            // kBtnActiveOne
            // 
            this.kBtnActiveOne.Location = new System.Drawing.Point(277, 181);
            this.kBtnActiveOne.Name = "kBtnActiveOne";
            this.kBtnActiveOne.Size = new System.Drawing.Size(93, 25);
            this.kBtnActiveOne.TabIndex = 2;
            this.toolTip.SetToolTip(this.kBtnActiveOne, "Activer le Tiers sélectionné");
            this.kBtnActiveOne.Values.Image = global::OrionBanque.Properties.Resources.arrow_curve_000_left;
            this.kBtnActiveOne.Values.Text = "";
            // 
            // kBtnDesactiveOne
            // 
            this.kBtnDesactiveOne.Location = new System.Drawing.Point(277, 223);
            this.kBtnDesactiveOne.Name = "kBtnDesactiveOne";
            this.kBtnDesactiveOne.Size = new System.Drawing.Size(93, 25);
            this.kBtnDesactiveOne.TabIndex = 3;
            this.toolTip.SetToolTip(this.kBtnDesactiveOne, "Désactiver le Tiers sélectionné");
            this.kBtnDesactiveOne.Values.Image = global::OrionBanque.Properties.Resources.arrow_curve_180;
            this.kBtnDesactiveOne.Values.Text = "";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(145, 43);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Tiers saisis";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(397, 43);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(147, 20);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Tiers dans les prédictions";
            // 
            // kBtnDesactiveAll
            // 
            this.kBtnDesactiveAll.Location = new System.Drawing.Point(277, 286);
            this.kBtnDesactiveAll.Name = "kBtnDesactiveAll";
            this.kBtnDesactiveAll.Size = new System.Drawing.Size(93, 25);
            this.kBtnDesactiveAll.TabIndex = 7;
            this.toolTip.SetToolTip(this.kBtnDesactiveAll, "Désactiver tous les Tiers");
            this.kBtnDesactiveAll.Values.Image = global::OrionBanque.Properties.Resources.arrow_curve_180_double;
            this.kBtnDesactiveAll.Values.Text = "";
            // 
            // kBtnActiveAll
            // 
            this.kBtnActiveAll.Location = new System.Drawing.Point(277, 116);
            this.kBtnActiveAll.Name = "kBtnActiveAll";
            this.kBtnActiveAll.Size = new System.Drawing.Size(93, 25);
            this.kBtnActiveAll.TabIndex = 6;
            this.toolTip.SetToolTip(this.kBtnActiveAll, "Activer tous les Tiers");
            this.kBtnActiveAll.Values.Image = global::OrionBanque.Properties.Resources.arrow_curve_000_double;
            this.kBtnActiveAll.Values.Text = "";
            // 
            // GestTiersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 419);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GestTiersForm";
            this.Text = "Gestion des Tiers";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonListBox kryptonListBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnDesactiveOne;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnActiveOne;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox kryptonListBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnDesactiveAll;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnActiveAll;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ToolTip toolTip;
    }
}