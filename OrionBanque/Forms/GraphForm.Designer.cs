namespace OrionBanque.Forms
{
    partial class GraphiqueForm
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
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.xGraph = new ZedGraph.ZedGraphControl();
            this.kPosition = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbTypeGraph = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kbtnCam = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kBtnHisto = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTypeGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            this.kryptonSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.xGraph);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kPosition);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonLabel1);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.cbTypeGraph);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kbtnCam);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kBtnHisto);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(807, 505);
            this.kryptonSplitContainer1.SplitterDistance = 468;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // xGraph
            // 
            this.xGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xGraph.Location = new System.Drawing.Point(0, 0);
            this.xGraph.Name = "xGraph";
            this.xGraph.ScrollGrace = 0D;
            this.xGraph.ScrollMaxX = 0D;
            this.xGraph.ScrollMaxY = 0D;
            this.xGraph.ScrollMaxY2 = 0D;
            this.xGraph.ScrollMinX = 0D;
            this.xGraph.ScrollMinY = 0D;
            this.xGraph.ScrollMinY2 = 0D;
            this.xGraph.Size = new System.Drawing.Size(807, 468);
            this.xGraph.TabIndex = 1;
            this.xGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.XGraph_MouseMove);
            // 
            // kPosition
            // 
            this.kPosition.Location = new System.Drawing.Point(732, 7);
            this.kPosition.Name = "kPosition";
            this.kPosition.Size = new System.Drawing.Size(54, 20);
            this.kPosition.TabIndex = 5;
            this.kPosition.Values.Text = "Position";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 7);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(374, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.ExtraText = "Faites un cliques droit sur le graphique pour plus d\'option";
            this.kryptonLabel1.Values.Text = "Astuce : ";
            // 
            // cbTypeGraph
            // 
            this.cbTypeGraph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeGraph.DropDownWidth = 159;
            this.cbTypeGraph.Items.AddRange(new object[] {
            "Par Tiers",
            "Par Tiers Dissociés",
            "Par Catégories",
            "Par Catégories Dissociées"});
            this.cbTypeGraph.Location = new System.Drawing.Point(372, 6);
            this.cbTypeGraph.Name = "cbTypeGraph";
            this.cbTypeGraph.Size = new System.Drawing.Size(159, 21);
            this.cbTypeGraph.TabIndex = 2;
            this.cbTypeGraph.SelectedIndexChanged += new System.EventHandler(this.CbTypeGraph_SelectedIndexChanged);
            // 
            // kbtnCam
            // 
            this.kbtnCam.Location = new System.Drawing.Point(568, 4);
            this.kbtnCam.Name = "kbtnCam";
            this.kbtnCam.Size = new System.Drawing.Size(25, 25);
            this.kbtnCam.TabIndex = 1;
            this.kbtnCam.Values.Image = global::OrionBanque.Properties.Resources.chart_pie1;
            this.kbtnCam.Values.Text = "";
            this.kbtnCam.Click += new System.EventHandler(this.KbtnCam_Click);
            // 
            // kBtnHisto
            // 
            this.kBtnHisto.Checked = true;
            this.kBtnHisto.Location = new System.Drawing.Point(537, 4);
            this.kBtnHisto.Name = "kBtnHisto";
            this.kBtnHisto.Size = new System.Drawing.Size(25, 25);
            this.kBtnHisto.TabIndex = 0;
            this.kBtnHisto.Values.Image = global::OrionBanque.Properties.Resources.chart_bar1;
            this.kBtnHisto.Values.Text = "";
            this.kBtnHisto.Click += new System.EventHandler(this.KBtnHisto_Click);
            // 
            // Graphique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 505);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "Graphique";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrionBanque - Graphique";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbTypeGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ZedGraph.ZedGraphControl xGraph;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kBtnHisto;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbTypeGraph;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kbtnCam;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kPosition;

    }
}