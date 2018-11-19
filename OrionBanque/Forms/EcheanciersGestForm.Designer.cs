namespace OrionBanque.Forms
{
    partial class EcheanciersGestForm
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
            this.dgvEcheance = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDateInsereEch = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kBtnInsere = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kBtnSupprime = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kBtnModifie = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kBtnAjout = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcheance)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.dgvEcheance);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonLabel1);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.txtDateInsereEch);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kBtnInsere);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kBtnSupprime);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kBtnModifie);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kBtnAjout);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1292, 552);
            this.kryptonSplitContainer1.SplitterDistance = 482;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // dgvEcheance
            // 
            this.dgvEcheance.AllowUserToAddRows = false;
            this.dgvEcheance.AllowUserToDeleteRows = false;
            this.dgvEcheance.AllowUserToOrderColumns = true;
            this.dgvEcheance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEcheance.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvEcheance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEcheance.Location = new System.Drawing.Point(0, 0);
            this.dgvEcheance.Name = "dgvEcheance";
            this.dgvEcheance.ReadOnly = true;
            this.dgvEcheance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEcheance.Size = new System.Drawing.Size(1292, 482);
            this.dgvEcheance.TabIndex = 0;
            this.dgvEcheance.DoubleClick += new System.EventHandler(this.DgvEcheance_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.modifierToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 70);
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.calendar_add;
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.ajouterToolStripMenuItem.Text = "&Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.AjouterToolStripMenuItem_Click);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.calendar_edit;
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.modifierToolStripMenuItem.Text = "&Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.ModifierToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.calendar_delete;
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.supprimerToolStripMenuItem.Text = "&Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.SupprimerToolStripMenuItem_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(592, 21);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(103, 20);
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Values.Text = "Insérer jusqu\'au :";
            // 
            // txtDateInsereEch
            // 
            this.txtDateInsereEch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateInsereEch.Location = new System.Drawing.Point(695, 19);
            this.txtDateInsereEch.Name = "txtDateInsereEch";
            this.txtDateInsereEch.Size = new System.Drawing.Size(176, 21);
            this.txtDateInsereEch.TabIndex = 4;
            // 
            // kBtnInsere
            // 
            this.kBtnInsere.Location = new System.Drawing.Point(877, 16);
            this.kBtnInsere.Name = "kBtnInsere";
            this.kBtnInsere.Size = new System.Drawing.Size(102, 27);
            this.kBtnInsere.TabIndex = 3;
            this.kBtnInsere.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.kBtnInsere.Values.Text = "Insérer";
            this.kBtnInsere.Click += new System.EventHandler(this.KryptonButton4_Click);
            // 
            // kBtnSupprime
            // 
            this.kBtnSupprime.Location = new System.Drawing.Point(374, 16);
            this.kBtnSupprime.Name = "kBtnSupprime";
            this.kBtnSupprime.Size = new System.Drawing.Size(102, 27);
            this.kBtnSupprime.TabIndex = 2;
            this.kBtnSupprime.Values.Image = global::OrionBanque.Properties.Resources.calendar_delete;
            this.kBtnSupprime.Values.Text = "Supprimer";
            this.kBtnSupprime.Click += new System.EventHandler(this.KryptonButton3_Click);
            // 
            // kBtnModifie
            // 
            this.kBtnModifie.Location = new System.Drawing.Point(224, 16);
            this.kBtnModifie.Name = "kBtnModifie";
            this.kBtnModifie.Size = new System.Drawing.Size(102, 27);
            this.kBtnModifie.TabIndex = 1;
            this.kBtnModifie.Values.Image = global::OrionBanque.Properties.Resources.calendar_edit;
            this.kBtnModifie.Values.Text = "Modifier";
            this.kBtnModifie.Click += new System.EventHandler(this.KryptonButton2_Click);
            // 
            // kBtnAjout
            // 
            this.kBtnAjout.Location = new System.Drawing.Point(74, 16);
            this.kBtnAjout.Name = "kBtnAjout";
            this.kBtnAjout.Size = new System.Drawing.Size(102, 27);
            this.kBtnAjout.TabIndex = 0;
            this.kBtnAjout.Values.Image = global::OrionBanque.Properties.Resources.calendar_add;
            this.kBtnAjout.Values.Text = "Ajouter";
            this.kBtnAjout.Click += new System.EventHandler(this.KryptonButton1_Click);
            // 
            // EcheanciersGestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 552);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcheanciersGestForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion Echéances";
            this.TextExtra = "OrionBanque";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcheance)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvEcheance;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnAjout;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnSupprime;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnModifie;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kBtnInsere;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtDateInsereEch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;

    }
}