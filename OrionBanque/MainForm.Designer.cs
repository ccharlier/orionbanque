namespace OrionBanque
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsNbLigne = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerSousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unFichierCSVBPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.modeDePaiementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catégoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comptesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.opérationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.gestionOpérationsEnGroupeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbSoldeFinal = new System.Windows.Forms.PictureBox();
            this.pb = new System.Windows.Forms.PictureBox();
            this.btnValidDateEvol = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEvolSoldMax = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.txtEvolSoldeMin = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.xGraph = new ZedGraph.ZedGraphControl();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbCompte = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblSoldFinal = new System.Windows.Forms.Label();
            this.lblAVenir = new System.Windows.Forms.Label();
            this.lblSoldPoint = new System.Windows.Forms.Label();
            this.spltOpeRecher = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.txtFiltrePointe = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kFiltreMontant = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kFiltreCategorie = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kFiltreTiers = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kFiltreModePaiement = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kFiltreDate = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.cbFiltreMontant = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtFiltreCategorie = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtFiltreMontant = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtFiltreModePaiement = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtFiltreTiers = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cbFiltreDate = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtFiltreDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dgvOperations = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ajouterToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsConnection = new System.Windows.Forms.ToolStrip();
            this.tsBtnConnection = new System.Windows.Forms.ToolStripButton();
            this.tsGestionUser = new System.Windows.Forms.ToolStrip();
            this.tsAddUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsModUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSupUser = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsGestGeneral = new System.Windows.Forms.ToolStrip();
            this.tsGestionModePaiement = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsGestionCategories = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsGraphChoix = new System.Windows.Forms.ToolStripComboBox();
            this.tsMontreGraph = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAjoutOperation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsVirementCaC = new System.Windows.Forms.ToolStripButton();
            this.toolTipG = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.OFDImport = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSoldeFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCompte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltOpeRecher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltOpeRecher.Panel1)).BeginInit();
            this.spltOpeRecher.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltOpeRecher.Panel2)).BeginInit();
            this.spltOpeRecher.Panel2.SuspendLayout();
            this.spltOpeRecher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFiltreMontant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltreCategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltreModePaiement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltreTiers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFiltreDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tsConnection.SuspendLayout();
            this.tsGestionUser.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tsGestGeneral.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUser,
            this.toolStripStatusLabel1,
            this.tsDate,
            this.tsNbLigne});
            this.statusStrip1.Location = new System.Drawing.Point(0, 632);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1256, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsUser
            // 
            this.tsUser.Image = global::OrionBanque.Properties.Resources.user;
            this.tsUser.Name = "tsUser";
            this.tsUser.Size = new System.Drawing.Size(42, 17);
            this.tsUser.Text = " : --";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::OrionBanque.Properties.Resources.calendar_view_day;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = " : --";
            // 
            // tsDate
            // 
            this.tsDate.Name = "tsDate";
            this.tsDate.Size = new System.Drawing.Size(0, 17);
            // 
            // tsNbLigne
            // 
            this.tsNbLigne.Image = global::OrionBanque.Properties.Resources.table1;
            this.tsNbLigne.Name = "tsNbLigne";
            this.tsNbLigne.Size = new System.Drawing.Size(42, 17);
            this.tsNbLigne.Text = " : --";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.tsmConfiguration,
            this.comptesToolStripMenuItem,
            this.opérationsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1256, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enregistrerSousToolStripMenuItem,
            this.quitterToolStripMenuItem,
            this.importerToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "&Fichier";
            // 
            // enregistrerSousToolStripMenuItem
            // 
            this.enregistrerSousToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.disk;
            this.enregistrerSousToolStripMenuItem.Name = "enregistrerSousToolStripMenuItem";
            this.enregistrerSousToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.enregistrerSousToolStripMenuItem.Text = "&Faire une sauvegarde";
            this.enregistrerSousToolStripMenuItem.Click += new System.EventHandler(this.EnregistrerSousToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.door_in;
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.QuitterToolStripMenuItem_Click);
            // 
            // importerToolStripMenuItem
            // 
            this.importerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unFichierCSVBPToolStripMenuItem});
            this.importerToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.page_white_text;
            this.importerToolStripMenuItem.Name = "importerToolStripMenuItem";
            this.importerToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.importerToolStripMenuItem.Text = "Importer";
            // 
            // unFichierCSVBPToolStripMenuItem
            // 
            this.unFichierCSVBPToolStripMenuItem.Name = "unFichierCSVBPToolStripMenuItem";
            this.unFichierCSVBPToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.unFichierCSVBPToolStripMenuItem.Text = "Un fichier CSV BP";
            this.unFichierCSVBPToolStripMenuItem.Click += new System.EventHandler(this.unFichierCSVBPToolStripMenuItem_Click);
            // 
            // tsmConfiguration
            // 
            this.tsmConfiguration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeDePaiementToolStripMenuItem,
            this.catégoriesToolStripMenuItem});
            this.tsmConfiguration.Name = "tsmConfiguration";
            this.tsmConfiguration.Size = new System.Drawing.Size(93, 20);
            this.tsmConfiguration.Text = "&Configuration";
            // 
            // modeDePaiementToolStripMenuItem
            // 
            this.modeDePaiementToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.creditcards;
            this.modeDePaiementToolStripMenuItem.Name = "modeDePaiementToolStripMenuItem";
            this.modeDePaiementToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.modeDePaiementToolStripMenuItem.Text = "&Modes de paiement";
            this.modeDePaiementToolStripMenuItem.Click += new System.EventHandler(this.ModeDePaiementToolStripMenuItem_Click);
            // 
            // catégoriesToolStripMenuItem
            // 
            this.catégoriesToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.chart_organisation1;
            this.catégoriesToolStripMenuItem.Name = "catégoriesToolStripMenuItem";
            this.catégoriesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.catégoriesToolStripMenuItem.Text = "&Catégories";
            this.catégoriesToolStripMenuItem.Click += new System.EventHandler(this.CatégoriesToolStripMenuItem_Click);
            // 
            // comptesToolStripMenuItem
            // 
            this.comptesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.modifierToolStripMenuItem1,
            this.supprimerToolStripMenuItem1});
            this.comptesToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.coins1;
            this.comptesToolStripMenuItem.Name = "comptesToolStripMenuItem";
            this.comptesToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.comptesToolStripMenuItem.Text = "Com&ptes";
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.coins_add;
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.ajouterToolStripMenuItem.Text = "&Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.AjouterToolStripMenuItem_Click);
            // 
            // modifierToolStripMenuItem1
            // 
            this.modifierToolStripMenuItem1.Image = global::OrionBanque.Properties.Resources.coins1;
            this.modifierToolStripMenuItem1.Name = "modifierToolStripMenuItem1";
            this.modifierToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.modifierToolStripMenuItem1.Text = "&Modifier";
            this.modifierToolStripMenuItem1.Click += new System.EventHandler(this.ModifierToolStripMenuItem1_Click);
            // 
            // supprimerToolStripMenuItem1
            // 
            this.supprimerToolStripMenuItem1.Image = global::OrionBanque.Properties.Resources.coins_delete;
            this.supprimerToolStripMenuItem1.Name = "supprimerToolStripMenuItem1";
            this.supprimerToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.supprimerToolStripMenuItem1.Text = "&Supprimer";
            this.supprimerToolStripMenuItem1.Click += new System.EventHandler(this.SupprimerToolStripMenuItem1_Click);
            // 
            // opérationsToolStripMenuItem
            // 
            this.opérationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem1,
            this.modifierToolStripMenuItem2,
            this.supprimerToolStripMenuItem2,
            this.toolStripSeparator3,
            this.gestionOpérationsEnGroupeToolStripMenuItem});
            this.opérationsToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.table1;
            this.opérationsToolStripMenuItem.Name = "opérationsToolStripMenuItem";
            this.opérationsToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.opérationsToolStripMenuItem.Text = "&Opérations";
            // 
            // ajouterToolStripMenuItem1
            // 
            this.ajouterToolStripMenuItem1.Image = global::OrionBanque.Properties.Resources.table_row_insert;
            this.ajouterToolStripMenuItem1.Name = "ajouterToolStripMenuItem1";
            this.ajouterToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.ajouterToolStripMenuItem1.Text = "&Ajouter";
            this.ajouterToolStripMenuItem1.Click += new System.EventHandler(this.AjouterToolStripMenuItem1_Click);
            // 
            // modifierToolStripMenuItem2
            // 
            this.modifierToolStripMenuItem2.Image = global::OrionBanque.Properties.Resources.table_edit;
            this.modifierToolStripMenuItem2.Name = "modifierToolStripMenuItem2";
            this.modifierToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.modifierToolStripMenuItem2.Text = "&Modifier";
            this.modifierToolStripMenuItem2.Click += new System.EventHandler(this.ModifierToolStripMenuItem2_Click);
            // 
            // supprimerToolStripMenuItem2
            // 
            this.supprimerToolStripMenuItem2.Image = global::OrionBanque.Properties.Resources.table_row_delete;
            this.supprimerToolStripMenuItem2.Name = "supprimerToolStripMenuItem2";
            this.supprimerToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.supprimerToolStripMenuItem2.Text = "&Supprimer";
            this.supprimerToolStripMenuItem2.Click += new System.EventHandler(this.SupprimerToolStripMenuItem2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // gestionOpérationsEnGroupeToolStripMenuItem
            // 
            this.gestionOpérationsEnGroupeToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.wand;
            this.gestionOpérationsEnGroupeToolStripMenuItem.Name = "gestionOpérationsEnGroupeToolStripMenuItem";
            this.gestionOpérationsEnGroupeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gestionOpérationsEnGroupeToolStripMenuItem.Text = "Mise à jour Groupée";
            this.gestionOpérationsEnGroupeToolStripMenuItem.Click += new System.EventHandler(this.GestionOpérationsEnGroupeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aideToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "&?";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.help;
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.aideToolStripMenuItem.Text = "&Aide (Wiki)";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.application_osx;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.aboutToolStripMenuItem.Text = "A &propos de...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1232, 583);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.tsConnection);
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.tsGestionUser);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1256, 608);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsGestGeneral);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.pbSoldeFinal);
            this.splitContainer1.Panel1.Controls.Add(this.pb);
            this.splitContainer1.Panel1.Controls.Add(this.btnValidDateEvol);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtEvolSoldMax);
            this.splitContainer1.Panel1.Controls.Add(this.txtEvolSoldeMin);
            this.splitContainer1.Panel1.Controls.Add(this.kryptonPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.kryptonLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.kryptonLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.kryptonLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.cbCompte);
            this.splitContainer1.Panel1.Controls.Add(this.lblSoldFinal);
            this.splitContainer1.Panel1.Controls.Add(this.lblAVenir);
            this.splitContainer1.Panel1.Controls.Add(this.lblSoldPoint);
            this.splitContainer1.Panel1MinSize = 215;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.spltOpeRecher);
            this.splitContainer1.Size = new System.Drawing.Size(1232, 583);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 4;
            // 
            // pbSoldeFinal
            // 
            this.pbSoldeFinal.BackColor = System.Drawing.Color.Transparent;
            this.pbSoldeFinal.Image = global::OrionBanque.Properties.Resources.error1;
            this.pbSoldeFinal.Location = new System.Drawing.Point(21, 129);
            this.pbSoldeFinal.Name = "pbSoldeFinal";
            this.pbSoldeFinal.Size = new System.Drawing.Size(16, 16);
            this.pbSoldeFinal.TabIndex = 29;
            this.pbSoldeFinal.TabStop = false;
            this.pbSoldeFinal.Visible = false;
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.Transparent;
            this.pb.Image = global::OrionBanque.Properties.Resources.error1;
            this.pb.Location = new System.Drawing.Point(16, 56);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(16, 16);
            this.pb.TabIndex = 28;
            this.pb.TabStop = false;
            this.pb.Visible = false;
            // 
            // btnValidDateEvol
            // 
            this.btnValidDateEvol.Location = new System.Drawing.Point(124, 514);
            this.btnValidDateEvol.Name = "btnValidDateEvol";
            this.btnValidDateEvol.Size = new System.Drawing.Size(23, 23);
            this.btnValidDateEvol.TabIndex = 24;
            this.toolTipG.SetToolTip(this.btnValidDateEvol, "Actualiser le graphique avec les dates choisies");
            this.btnValidDateEvol.Values.Image = global::OrionBanque.Properties.Resources.accept1;
            this.btnValidDateEvol.Values.Text = "";
            this.btnValidDateEvol.Click += new System.EventHandler(this.BtnValidDateEvol_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 523);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Au";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Du";
            // 
            // txtEvolSoldMax
            // 
            this.txtEvolSoldMax.CalendarTodayDate = new System.DateTime(2010, 1, 2, 0, 0, 0, 0);
            this.txtEvolSoldMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtEvolSoldMax.Location = new System.Drawing.Point(31, 515);
            this.txtEvolSoldMax.Name = "txtEvolSoldMax";
            this.txtEvolSoldMax.Size = new System.Drawing.Size(89, 21);
            this.txtEvolSoldMax.TabIndex = 15;
            // 
            // txtEvolSoldeMin
            // 
            this.txtEvolSoldeMin.CalendarTodayDate = new System.DateTime(2010, 1, 2, 0, 0, 0, 0);
            this.txtEvolSoldeMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtEvolSoldeMin.Location = new System.Drawing.Point(30, 488);
            this.txtEvolSoldeMin.Name = "txtEvolSoldeMin";
            this.txtEvolSoldeMin.Size = new System.Drawing.Size(89, 21);
            this.txtEvolSoldeMin.TabIndex = 14;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel1.Controls.Add(this.xGraph);
            this.kryptonPanel1.Location = new System.Drawing.Point(4, 181);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(297, 299);
            this.kryptonPanel1.TabIndex = 13;
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
            this.xGraph.Size = new System.Drawing.Size(297, 299);
            this.xGraph.TabIndex = 12;
            this.xGraph.UseExtendedPrintDialog = true;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(43, 129);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(76, 16);
            this.kryptonLabel3.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 10;
            this.kryptonLabel3.Values.Text = "Solde Final :";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(67, 85);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(52, 16);
            this.kryptonLabel2.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 9;
            this.kryptonLabel2.Values.Text = "A venir :";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(38, 56);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(81, 16);
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 8;
            this.kryptonLabel1.Values.Text = "Solde Pointé :";
            // 
            // cbCompte
            // 
            this.cbCompte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCompte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompte.DropDownWidth = 121;
            this.cbCompte.Location = new System.Drawing.Point(52, 13);
            this.cbCompte.Name = "cbCompte";
            this.cbCompte.Size = new System.Drawing.Size(219, 21);
            this.cbCompte.TabIndex = 7;
            this.cbCompte.SelectedIndexChanged += new System.EventHandler(this.CbCompte_SelectedIndexChanged);
            // 
            // lblSoldFinal
            // 
            this.lblSoldFinal.AutoSize = true;
            this.lblSoldFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoldFinal.Location = new System.Drawing.Point(125, 132);
            this.lblSoldFinal.Name = "lblSoldFinal";
            this.lblSoldFinal.Size = new System.Drawing.Size(43, 13);
            this.lblSoldFinal.TabIndex = 6;
            this.lblSoldFinal.Text = "0.00 €";
            this.lblSoldFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAVenir
            // 
            this.lblAVenir.AutoSize = true;
            this.lblAVenir.Location = new System.Drawing.Point(125, 88);
            this.lblAVenir.Name = "lblAVenir";
            this.lblAVenir.Size = new System.Drawing.Size(37, 13);
            this.lblAVenir.TabIndex = 5;
            this.lblAVenir.Text = "0.00 €";
            this.lblAVenir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoldPoint
            // 
            this.lblSoldPoint.AutoSize = true;
            this.lblSoldPoint.Location = new System.Drawing.Point(125, 59);
            this.lblSoldPoint.Name = "lblSoldPoint";
            this.lblSoldPoint.Size = new System.Drawing.Size(37, 13);
            this.lblSoldPoint.TabIndex = 4;
            this.lblSoldPoint.Text = "0.00 €";
            this.lblSoldPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spltOpeRecher
            // 
            this.spltOpeRecher.Cursor = System.Windows.Forms.Cursors.Default;
            this.spltOpeRecher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltOpeRecher.Location = new System.Drawing.Point(0, 0);
            this.spltOpeRecher.Name = "spltOpeRecher";
            this.spltOpeRecher.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltOpeRecher.Panel1
            // 
            this.spltOpeRecher.Panel1.Controls.Add(this.txtFiltrePointe);
            this.spltOpeRecher.Panel1.Controls.Add(this.kFiltreMontant);
            this.spltOpeRecher.Panel1.Controls.Add(this.kFiltreCategorie);
            this.spltOpeRecher.Panel1.Controls.Add(this.kFiltreTiers);
            this.spltOpeRecher.Panel1.Controls.Add(this.kFiltreModePaiement);
            this.spltOpeRecher.Panel1.Controls.Add(this.kFiltreDate);
            this.spltOpeRecher.Panel1.Controls.Add(this.cbFiltreMontant);
            this.spltOpeRecher.Panel1.Controls.Add(this.txtFiltreCategorie);
            this.spltOpeRecher.Panel1.Controls.Add(this.txtFiltreMontant);
            this.spltOpeRecher.Panel1.Controls.Add(this.txtFiltreModePaiement);
            this.spltOpeRecher.Panel1.Controls.Add(this.txtFiltreTiers);
            this.spltOpeRecher.Panel1.Controls.Add(this.cbFiltreDate);
            this.spltOpeRecher.Panel1.Controls.Add(this.txtFiltreDate);
            // 
            // spltOpeRecher.Panel2
            // 
            this.spltOpeRecher.Panel2.Controls.Add(this.dgvOperations);
            this.spltOpeRecher.Size = new System.Drawing.Size(926, 583);
            this.spltOpeRecher.SplitterDistance = 30;
            this.spltOpeRecher.TabIndex = 0;
            // 
            // txtFiltrePointe
            // 
            this.txtFiltrePointe.Location = new System.Drawing.Point(793, 13);
            this.txtFiltrePointe.Name = "txtFiltrePointe";
            this.txtFiltrePointe.Size = new System.Drawing.Size(92, 20);
            this.txtFiltrePointe.TabIndex = 52;
            this.toolTipG.SetToolTip(this.txtFiltrePointe, "Activer pour afficher que les mouvements non pointés");
            this.txtFiltrePointe.Values.Text = "Non Pointée";
            this.txtFiltrePointe.CheckedChanged += new System.EventHandler(this.TxtFiltrePointe_CheckedChanged);
            // 
            // kFiltreMontant
            // 
            this.kFiltreMontant.Location = new System.Drawing.Point(616, 10);
            this.kFiltreMontant.Name = "kFiltreMontant";
            this.kFiltreMontant.Size = new System.Drawing.Size(27, 24);
            this.kFiltreMontant.TabIndex = 51;
            this.toolTipG.SetToolTip(this.kFiltreMontant, "Activer pour filtrer sur la somme du mouvement");
            this.kFiltreMontant.Values.Image = global::OrionBanque.Properties.Resources.money1;
            this.kFiltreMontant.Values.Text = "";
            this.kFiltreMontant.Click += new System.EventHandler(this.KFiltreDate_Click);
            // 
            // kFiltreCategorie
            // 
            this.kFiltreCategorie.Location = new System.Drawing.Point(481, 10);
            this.kFiltreCategorie.Name = "kFiltreCategorie";
            this.kFiltreCategorie.Size = new System.Drawing.Size(27, 24);
            this.kFiltreCategorie.TabIndex = 50;
            this.toolTipG.SetToolTip(this.kFiltreCategorie, "Activer pour filtrer sur la catégorie du mouvement");
            this.kFiltreCategorie.Values.Image = global::OrionBanque.Properties.Resources.chart_organisation1;
            this.kFiltreCategorie.Values.Text = "";
            this.kFiltreCategorie.Click += new System.EventHandler(this.KFiltreDate_Click);
            // 
            // kFiltreTiers
            // 
            this.kFiltreTiers.Location = new System.Drawing.Point(341, 10);
            this.kFiltreTiers.Name = "kFiltreTiers";
            this.kFiltreTiers.Size = new System.Drawing.Size(27, 24);
            this.kFiltreTiers.TabIndex = 49;
            this.toolTipG.SetToolTip(this.kFiltreTiers, "Activer pour filtrer sur le tiers du mouvement");
            this.kFiltreTiers.Values.Image = global::OrionBanque.Properties.Resources.user_business;
            this.kFiltreTiers.Values.Text = "";
            this.kFiltreTiers.Click += new System.EventHandler(this.KFiltreDate_Click);
            // 
            // kFiltreModePaiement
            // 
            this.kFiltreModePaiement.Location = new System.Drawing.Point(194, 10);
            this.kFiltreModePaiement.Name = "kFiltreModePaiement";
            this.kFiltreModePaiement.Size = new System.Drawing.Size(27, 24);
            this.kFiltreModePaiement.TabIndex = 48;
            this.toolTipG.SetToolTip(this.kFiltreModePaiement, "Activer pour filtrer sur le mode de paiement du mouvement");
            this.kFiltreModePaiement.Values.Image = global::OrionBanque.Properties.Resources.creditcards;
            this.kFiltreModePaiement.Values.Text = "";
            this.kFiltreModePaiement.Click += new System.EventHandler(this.KFiltreDate_Click);
            // 
            // kFiltreDate
            // 
            this.kFiltreDate.Location = new System.Drawing.Point(3, 9);
            this.kFiltreDate.Name = "kFiltreDate";
            this.kFiltreDate.Size = new System.Drawing.Size(40, 25);
            this.kFiltreDate.TabIndex = 1;
            this.toolTipG.SetToolTip(this.kFiltreDate, "Activer pour filtrer sur la date du mouvement");
            this.kFiltreDate.Values.Text = "Date";
            this.kFiltreDate.Click += new System.EventHandler(this.KFiltreDate_Click);
            // 
            // cbFiltreMontant
            // 
            this.cbFiltreMontant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltreMontant.DropDownWidth = 44;
            this.cbFiltreMontant.Items.AddRange(new object[] {
            "<=",
            "=",
            ">="});
            this.cbFiltreMontant.Location = new System.Drawing.Point(649, 11);
            this.cbFiltreMontant.Name = "cbFiltreMontant";
            this.cbFiltreMontant.Size = new System.Drawing.Size(44, 21);
            this.cbFiltreMontant.TabIndex = 47;
            // 
            // txtFiltreCategorie
            // 
            this.txtFiltreCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtFiltreCategorie.DropDownWidth = 300;
            this.txtFiltreCategorie.Location = new System.Drawing.Point(514, 11);
            this.txtFiltreCategorie.Name = "txtFiltreCategorie";
            this.txtFiltreCategorie.Size = new System.Drawing.Size(96, 21);
            this.txtFiltreCategorie.TabIndex = 46;
            // 
            // txtFiltreMontant
            // 
            this.txtFiltreMontant.DecimalPlaces = 2;
            this.txtFiltreMontant.Location = new System.Drawing.Point(699, 11);
            this.txtFiltreMontant.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtFiltreMontant.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.txtFiltreMontant.Name = "txtFiltreMontant";
            this.txtFiltreMontant.Size = new System.Drawing.Size(88, 22);
            this.txtFiltreMontant.TabIndex = 45;
            // 
            // txtFiltreModePaiement
            // 
            this.txtFiltreModePaiement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtFiltreModePaiement.DropDownWidth = 185;
            this.txtFiltreModePaiement.Location = new System.Drawing.Point(227, 11);
            this.txtFiltreModePaiement.Name = "txtFiltreModePaiement";
            this.txtFiltreModePaiement.Size = new System.Drawing.Size(108, 21);
            this.txtFiltreModePaiement.TabIndex = 42;
            // 
            // txtFiltreTiers
            // 
            this.txtFiltreTiers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFiltreTiers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtFiltreTiers.DropDownWidth = 166;
            this.txtFiltreTiers.Location = new System.Drawing.Point(374, 11);
            this.txtFiltreTiers.Name = "txtFiltreTiers";
            this.txtFiltreTiers.Size = new System.Drawing.Size(101, 21);
            this.txtFiltreTiers.TabIndex = 40;
            // 
            // cbFiltreDate
            // 
            this.cbFiltreDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltreDate.DropDownWidth = 44;
            this.cbFiltreDate.Items.AddRange(new object[] {
            "<=",
            "=",
            ">="});
            this.cbFiltreDate.Location = new System.Drawing.Point(49, 11);
            this.cbFiltreDate.Name = "cbFiltreDate";
            this.cbFiltreDate.Size = new System.Drawing.Size(44, 21);
            this.cbFiltreDate.TabIndex = 16;
            // 
            // txtFiltreDate
            // 
            this.txtFiltreDate.CalendarTodayDate = new System.DateTime(2010, 1, 2, 0, 0, 0, 0);
            this.txtFiltreDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFiltreDate.Location = new System.Drawing.Point(99, 11);
            this.txtFiltreDate.Name = "txtFiltreDate";
            this.txtFiltreDate.Size = new System.Drawing.Size(89, 21);
            this.txtFiltreDate.TabIndex = 15;
            // 
            // dgvOperations
            // 
            this.dgvOperations.AllowUserToAddRows = false;
            this.dgvOperations.AllowUserToDeleteRows = false;
            this.dgvOperations.AllowUserToOrderColumns = true;
            this.dgvOperations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOperations.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperations.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.dgvOperations.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvOperations.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvOperations.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvOperations.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvOperations.Location = new System.Drawing.Point(0, 0);
            this.dgvOperations.Name = "dgvOperations";
            this.dgvOperations.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.dgvOperations.ReadOnly = true;
            this.dgvOperations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperations.Size = new System.Drawing.Size(926, 548);
            this.dgvOperations.TabIndex = 0;
            this.dgvOperations.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOperations_CellFormatting);
            this.dgvOperations.DoubleClick += new System.EventHandler(this.DgvOperations_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem2,
            this.modifierToolStripMenuItem,
            this.supprimerToolStripMenuItem,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 92);
            // 
            // ajouterToolStripMenuItem2
            // 
            this.ajouterToolStripMenuItem2.Image = global::OrionBanque.Properties.Resources.table_row_insert;
            this.ajouterToolStripMenuItem2.Name = "ajouterToolStripMenuItem2";
            this.ajouterToolStripMenuItem2.Size = new System.Drawing.Size(129, 22);
            this.ajouterToolStripMenuItem2.Text = "Ajouter";
            this.ajouterToolStripMenuItem2.Click += new System.EventHandler(this.AjouterToolStripMenuItem2_Click);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.table_edit;
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.modifierToolStripMenuItem.Text = "&Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.ModifierToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Image = global::OrionBanque.Properties.Resources.table_row_delete;
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.supprimerToolStripMenuItem.Text = "&Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.SupprimerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItem2.Text = "&Export";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            // 
            // tsConnection
            // 
            this.tsConnection.Dock = System.Windows.Forms.DockStyle.None;
            this.tsConnection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnConnection});
            this.tsConnection.Location = new System.Drawing.Point(0, 3);
            this.tsConnection.Name = "tsConnection";
            this.tsConnection.Size = new System.Drawing.Size(24, 34);
            this.tsConnection.TabIndex = 3;
            // 
            // tsBtnConnection
            // 
            this.tsBtnConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnConnection.Image = global::OrionBanque.Properties.Resources.lock_go;
            this.tsBtnConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnConnection.Name = "tsBtnConnection";
            this.tsBtnConnection.Size = new System.Drawing.Size(22, 20);
            this.tsBtnConnection.Text = "toolStripButton10";
            this.tsBtnConnection.ToolTipText = "Se connecter";
            this.tsBtnConnection.Click += new System.EventHandler(this.TsBtnConnection_Click);
            // 
            // tsGestionUser
            // 
            this.tsGestionUser.Dock = System.Windows.Forms.DockStyle.None;
            this.tsGestionUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsGestionUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddUser,
            this.toolStripSeparator5,
            this.tsModUser,
            this.toolStripSeparator6,
            this.tsSupUser});
            this.tsGestionUser.Location = new System.Drawing.Point(0, 46);
            this.tsGestionUser.Name = "tsGestionUser";
            this.tsGestionUser.Size = new System.Drawing.Size(24, 92);
            this.tsGestionUser.TabIndex = 2;
            // 
            // tsAddUser
            // 
            this.tsAddUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAddUser.Image = global::OrionBanque.Properties.Resources.user_add;
            this.tsAddUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddUser.Name = "tsAddUser";
            this.tsAddUser.Size = new System.Drawing.Size(22, 20);
            this.tsAddUser.Text = "toolStripButton7";
            this.tsAddUser.ToolTipText = "Ajouter un Utilisateur";
            this.tsAddUser.Click += new System.EventHandler(this.ToolStripButton7_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(22, 6);
            // 
            // tsModUser
            // 
            this.tsModUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsModUser.Image = global::OrionBanque.Properties.Resources.user_edit;
            this.tsModUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsModUser.Name = "tsModUser";
            this.tsModUser.Size = new System.Drawing.Size(22, 20);
            this.tsModUser.Text = "toolStripButton8";
            this.tsModUser.ToolTipText = "Modifier l\'Utilisateur";
            this.tsModUser.Click += new System.EventHandler(this.TsModUser_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(22, 6);
            // 
            // tsSupUser
            // 
            this.tsSupUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSupUser.Image = global::OrionBanque.Properties.Resources.user_delete;
            this.tsSupUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSupUser.Name = "tsSupUser";
            this.tsSupUser.Size = new System.Drawing.Size(22, 20);
            this.tsSupUser.Text = "toolStripButton9";
            this.tsSupUser.ToolTipText = "Supprimer l\'Utilisateur";
            this.tsSupUser.Click += new System.EventHandler(this.TsSupUser_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSave});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(35, 25);
            this.toolStrip1.TabIndex = 5;
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Enabled = false;
            this.tsSave.Image = global::OrionBanque.Properties.Resources.disk;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(23, 22);
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // tsGestGeneral
            // 
            this.tsGestGeneral.Dock = System.Windows.Forms.DockStyle.None;
            this.tsGestGeneral.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsGestGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGestionModePaiement,
            this.toolStripSeparator7,
            this.tsGestionCategories,
            this.toolStripSeparator8,
            this.toolStripButton1,
            this.toolStripSeparator9,
            this.tsGraphChoix,
            this.tsMontreGraph,
            this.toolStripSeparator1,
            this.tsAjoutOperation,
            this.toolStripSeparator2,
            this.tsVirementCaC});
            this.tsGestGeneral.Location = new System.Drawing.Point(38, 0);
            this.tsGestGeneral.Name = "tsGestGeneral";
            this.tsGestGeneral.Size = new System.Drawing.Size(303, 25);
            this.tsGestGeneral.TabIndex = 4;
            // 
            // tsGestionModePaiement
            // 
            this.tsGestionModePaiement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsGestionModePaiement.Image = global::OrionBanque.Properties.Resources.creditcards;
            this.tsGestionModePaiement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGestionModePaiement.Name = "tsGestionModePaiement";
            this.tsGestionModePaiement.Size = new System.Drawing.Size(23, 22);
            this.tsGestionModePaiement.ToolTipText = "Gérer les Modes de Paiement";
            this.tsGestionModePaiement.Click += new System.EventHandler(this.TsGestionModePaiement_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsGestionCategories
            // 
            this.tsGestionCategories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsGestionCategories.Image = global::OrionBanque.Properties.Resources.chart_organisation1;
            this.tsGestionCategories.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGestionCategories.Name = "tsGestionCategories";
            this.tsGestionCategories.Size = new System.Drawing.Size(23, 22);
            this.tsGestionCategories.ToolTipText = "Gérer les Catégories";
            this.tsGestionCategories.Click += new System.EventHandler(this.TsGestionCategories_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::OrionBanque.Properties.Resources.calendar_2;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.ToolTipText = "Gérer l\'échéancier";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // tsGraphChoix
            // 
            this.tsGraphChoix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsGraphChoix.Items.AddRange(new object[] {
            "Par Tiers",
            "Par Tiers Dissociés",
            "Par Catégories",
            "Par Catégories Dissociées"});
            this.tsGraphChoix.Name = "tsGraphChoix";
            this.tsGraphChoix.Size = new System.Drawing.Size(121, 25);
            // 
            // tsMontreGraph
            // 
            this.tsMontreGraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMontreGraph.Image = global::OrionBanque.Properties.Resources.chart_pie_edit;
            this.tsMontreGraph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMontreGraph.Name = "tsMontreGraph";
            this.tsMontreGraph.Size = new System.Drawing.Size(23, 22);
            this.tsMontreGraph.ToolTipText = "Visualiser le graphique choisi";
            this.tsMontreGraph.Click += new System.EventHandler(this.TsMontreGraph_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsAjoutOperation
            // 
            this.tsAjoutOperation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAjoutOperation.Image = global::OrionBanque.Properties.Resources.table_row_insert;
            this.tsAjoutOperation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAjoutOperation.Name = "tsAjoutOperation";
            this.tsAjoutOperation.Size = new System.Drawing.Size(23, 22);
            this.tsAjoutOperation.ToolTipText = "Insérer une opération";
            this.tsAjoutOperation.Click += new System.EventHandler(this.TsAjoutOperation_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsVirementCaC
            // 
            this.tsVirementCaC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVirementCaC.Image = global::OrionBanque.Properties.Resources.tag;
            this.tsVirementCaC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVirementCaC.Name = "tsVirementCaC";
            this.tsVirementCaC.Size = new System.Drawing.Size(23, 22);
            this.tsVirementCaC.ToolTipText = "Effectuer un virement de compte à compte";
            this.tsVirementCaC.Click += new System.EventHandler(this.TsVirementCaC_Click);
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(1256, 629);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(1256, 654);
            this.toolStripContainer2.TabIndex = 0;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // OFDImport
            // 
            this.OFDImport.Title = "Fichier d\'Opérations à importer";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 654);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolStripContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "OrionBanque - Gestion de Comptes Bancaires";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSoldeFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbCompte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltOpeRecher.Panel1)).EndInit();
            this.spltOpeRecher.Panel1.ResumeLayout(false);
            this.spltOpeRecher.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltOpeRecher.Panel2)).EndInit();
            this.spltOpeRecher.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltOpeRecher)).EndInit();
            this.spltOpeRecher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbFiltreMontant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltreCategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltreModePaiement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltreTiers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFiltreDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tsConnection.ResumeLayout(false);
            this.tsConnection.PerformLayout();
            this.tsGestionUser.ResumeLayout(false);
            this.tsGestionUser.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tsGestGeneral.ResumeLayout(false);
            this.tsGestGeneral.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmConfiguration;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolTip toolTipG;
        private System.Windows.Forms.ToolStrip tsGestionUser;
        private System.Windows.Forms.ToolStripButton tsAddUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsModUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsSupUser;
        private System.Windows.Forms.ToolStripMenuItem modeDePaiementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catégoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsConnection;
        private System.Windows.Forms.ToolStripButton tsBtnConnection;
        private System.Windows.Forms.ToolStripStatusLabel tsUser;
        private System.Windows.Forms.ToolStrip tsGestGeneral;
        private System.Windows.Forms.ToolStripButton tsGestionModePaiement;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsGestionCategories;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tsMontreGraph;
        private System.Windows.Forms.ToolStripComboBox tsGraphChoix;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbCompte;
        private System.Windows.Forms.Label lblSoldFinal;
        private System.Windows.Forms.Label lblAVenir;
        private System.Windows.Forms.Label lblSoldPoint;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvOperations;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsDate;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ZedGraph.ZedGraphControl xGraph;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtEvolSoldMax;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtEvolSoldeMin;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnValidDateEvol;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer spltOpeRecher;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbFiltreDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtFiltreDate;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtFiltreTiers;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtFiltreModePaiement;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtFiltreCategorie;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtFiltreMontant;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbFiltreMontant;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kFiltreDate;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kFiltreCategorie;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kFiltreTiers;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kFiltreModePaiement;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kFiltreMontant;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.ToolStripMenuItem comptesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem opérationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsAjoutOperation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem enregistrerSousToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox txtFiltrePointe;
        private System.Windows.Forms.PictureBox pbSoldeFinal;
        private System.Windows.Forms.ToolStripButton tsVirementCaC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem gestionOpérationsEnGroupeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unFichierCSVBPToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OFDImport;
        private System.Windows.Forms.ToolStripStatusLabel tsNbLigne;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsSave;
    }
}

