namespace EventHandlerExplorer
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkboxLoadWebs = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExplore = new System.Windows.Forms.Button();
            this.textBoxSiteCollectionURL = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeViewItems = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveGAC = new System.Windows.Forms.Button();
            this.btnInstallGAC = new System.Windows.Forms.Button();
            this.checkboxAutoIisReset = new System.Windows.Forms.CheckBox();
            this.btnRestartIIS = new System.Windows.Forms.Button();
            this.comboBoxClasses = new System.Windows.Forms.ComboBox();
            this.btnLoadAssembly = new System.Windows.Forms.Button();
            this.btnRemoveHandler = new System.Windows.Forms.Button();
            this.buttonAddHandler = new System.Windows.Forms.Button();
            this.comboBoxEventType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSequence = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAssemlby = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvLog = new System.Windows.Forms.ListView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkboxLoadWebs);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnExplore);
            this.groupBox1.Controls.Add(this.textBoxSiteCollectionURL);
            this.groupBox1.Location = new System.Drawing.Point(294, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter URL for the site collection you want to explore";
            // 
            // checkboxLoadWebs
            // 
            this.checkboxLoadWebs.AutoSize = true;
            this.checkboxLoadWebs.Location = new System.Drawing.Point(4, 50);
            this.checkboxLoadWebs.Margin = new System.Windows.Forms.Padding(2);
            this.checkboxLoadWebs.Name = "checkboxLoadWebs";
            this.checkboxLoadWebs.Size = new System.Drawing.Size(116, 17);
            this.checkboxLoadWebs.TabIndex = 8;
            this.checkboxLoadWebs.Text = "Load webs on start";
            this.checkboxLoadWebs.UseVisualStyleBackColor = true;
            this.checkboxLoadWebs.Click += new System.EventHandler(this.checkboxLoadWebs_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(230, 45);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 24);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.ButtonExitClick);
            // 
            // btnExplore
            // 
            this.btnExplore.Image = ((System.Drawing.Image)(resources.GetObject("btnExplore.Image")));
            this.btnExplore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExplore.Location = new System.Drawing.Point(156, 45);
            this.btnExplore.Name = "btnExplore";
            this.btnExplore.Size = new System.Drawing.Size(68, 24);
            this.btnExplore.TabIndex = 0;
            this.btnExplore.Text = "Explore";
            this.btnExplore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExplore.UseVisualStyleBackColor = true;
            this.btnExplore.Click += new System.EventHandler(this.ButtonExploreClick);
            // 
            // textBoxSiteCollectionURL
            // 
            this.textBoxSiteCollectionURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSiteCollectionURL.Location = new System.Drawing.Point(4, 22);
            this.textBoxSiteCollectionURL.Name = "textBoxSiteCollectionURL";
            this.textBoxSiteCollectionURL.Size = new System.Drawing.Size(292, 20);
            this.textBoxSiteCollectionURL.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.treeViewItems);
            this.groupBox2.Location = new System.Drawing.Point(9, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 421);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SharePoint Explorer";
            // 
            // treeViewItems
            // 
            this.treeViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewItems.ImageIndex = 0;
            this.treeViewItems.ImageList = this.imageList1;
            this.treeViewItems.Location = new System.Drawing.Point(6, 19);
            this.treeViewItems.Name = "treeViewItems";
            this.treeViewItems.SelectedImageIndex = 0;
            this.treeViewItems.Size = new System.Drawing.Size(267, 396);
            this.treeViewItems.TabIndex = 0;
            this.treeViewItems.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewItemsNodeMouseClick);
            this.treeViewItems.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewItemsNodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder Blue.ico");
            this.imageList1.Images.SetKeyName(1, "Globe 2.ico");
            this.imageList1.Images.SetKeyName(2, "Home 2.ico");
            this.imageList1.Images.SetKeyName(3, "noextension32.gif");
            this.imageList1.Images.SetKeyName(4, "PAGELOGO.GIF");
            this.imageList1.Images.SetKeyName(5, "DESVIEW.GIF");
            this.imageList1.Images.SetKeyName(6, "DETAIL.GIF");
            this.imageList1.Images.SetKeyName(7, "EXC16.GIF");
            this.imageList1.Images.SetKeyName(8, "GENERIC.GIF");
            this.imageList1.Images.SetKeyName(9, "ITSMRTPG.GIF");
            this.imageList1.Images.SetKeyName(10, "LISTSET.GIF");
            this.imageList1.Images.SetKeyName(11, "LTDATASH.GIF");
            this.imageList1.Images.SetKeyName(12, "LTDCL.GIF");
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.btnRemoveGAC);
            this.groupBox3.Controls.Add(this.btnInstallGAC);
            this.groupBox3.Controls.Add(this.checkboxAutoIisReset);
            this.groupBox3.Controls.Add(this.btnRestartIIS);
            this.groupBox3.Controls.Add(this.comboBoxClasses);
            this.groupBox3.Controls.Add(this.btnLoadAssembly);
            this.groupBox3.Controls.Add(this.btnRemoveHandler);
            this.groupBox3.Controls.Add(this.buttonAddHandler);
            this.groupBox3.Controls.Add(this.comboBoxEventType);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxSequence);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxAssemlby);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(294, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 336);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Details of Event Handler";
            // 
            // btnRemoveGAC
            // 
            this.btnRemoveGAC.Location = new System.Drawing.Point(207, 101);
            this.btnRemoveGAC.Name = "btnRemoveGAC";
            this.btnRemoveGAC.Size = new System.Drawing.Size(89, 23);
            this.btnRemoveGAC.TabIndex = 13;
            this.btnRemoveGAC.Text = "Remove f/GAC";
            this.btnRemoveGAC.UseVisualStyleBackColor = true;
            this.btnRemoveGAC.Click += new System.EventHandler(this.btnRemoveGAC_Click);
            // 
            // btnInstallGAC
            // 
            this.btnInstallGAC.Location = new System.Drawing.Point(110, 101);
            this.btnInstallGAC.Name = "btnInstallGAC";
            this.btnInstallGAC.Size = new System.Drawing.Size(93, 23);
            this.btnInstallGAC.TabIndex = 12;
            this.btnInstallGAC.Text = "Install in GAC";
            this.btnInstallGAC.UseVisualStyleBackColor = true;
            this.btnInstallGAC.Click += new System.EventHandler(this.btnInstallGAC_Click);
            // 
            // checkboxAutoIisReset
            // 
            this.checkboxAutoIisReset.AutoSize = true;
            this.checkboxAutoIisReset.Location = new System.Drawing.Point(9, 292);
            this.checkboxAutoIisReset.Margin = new System.Windows.Forms.Padding(2);
            this.checkboxAutoIisReset.Name = "checkboxAutoIisReset";
            this.checkboxAutoIisReset.Size = new System.Drawing.Size(228, 17);
            this.checkboxAutoIisReset.TabIndex = 6;
            this.checkboxAutoIisReset.Text = "Auto restart IIS after Add/Remove receiver";
            this.checkboxAutoIisReset.UseVisualStyleBackColor = true;
            this.checkboxAutoIisReset.Click += new System.EventHandler(this.checkboxAutoIisReset_Click);
            // 
            // btnRestartIIS
            // 
            this.btnRestartIIS.Location = new System.Drawing.Point(7, 261);
            this.btnRestartIIS.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestartIIS.Name = "btnRestartIIS";
            this.btnRestartIIS.Size = new System.Drawing.Size(92, 23);
            this.btnRestartIIS.TabIndex = 5;
            this.btnRestartIIS.Text = "Restart IIS";
            this.btnRestartIIS.UseVisualStyleBackColor = true;
            this.btnRestartIIS.Click += new System.EventHandler(this.ButtonRestartIisClick);
            // 
            // comboBoxClasses
            // 
            this.comboBoxClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxClasses.FormattingEnabled = true;
            this.comboBoxClasses.Location = new System.Drawing.Point(6, 151);
            this.comboBoxClasses.Name = "comboBoxClasses";
            this.comboBoxClasses.Size = new System.Drawing.Size(290, 21);
            this.comboBoxClasses.TabIndex = 11;
            // 
            // btnLoadAssembly
            // 
            this.btnLoadAssembly.Location = new System.Drawing.Point(6, 101);
            this.btnLoadAssembly.Name = "btnLoadAssembly";
            this.btnLoadAssembly.Size = new System.Drawing.Size(92, 23);
            this.btnLoadAssembly.TabIndex = 10;
            this.btnLoadAssembly.Text = "Load Assembly";
            this.btnLoadAssembly.UseVisualStyleBackColor = true;
            this.btnLoadAssembly.Click += new System.EventHandler(this.ButtonLoadAssemblyClick);
            // 
            // btnRemoveHandler
            // 
            this.btnRemoveHandler.Location = new System.Drawing.Point(105, 233);
            this.btnRemoveHandler.Name = "btnRemoveHandler";
            this.btnRemoveHandler.Size = new System.Drawing.Size(93, 23);
            this.btnRemoveHandler.TabIndex = 9;
            this.btnRemoveHandler.Text = "Remove Handler";
            this.btnRemoveHandler.UseVisualStyleBackColor = true;
            this.btnRemoveHandler.Click += new System.EventHandler(this.ButtonRemoveClick);
            // 
            // buttonAddHandler
            // 
            this.buttonAddHandler.Location = new System.Drawing.Point(7, 233);
            this.buttonAddHandler.Name = "buttonAddHandler";
            this.buttonAddHandler.Size = new System.Drawing.Size(93, 23);
            this.buttonAddHandler.TabIndex = 8;
            this.buttonAddHandler.Text = "Add Handler";
            this.buttonAddHandler.UseVisualStyleBackColor = true;
            this.buttonAddHandler.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // comboBoxEventType
            // 
            this.comboBoxEventType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEventType.FormattingEnabled = true;
            this.comboBoxEventType.Items.AddRange(new object[] {
            "EmailReceived",
            "FieldAdded",
            "FieldAdding",
            "FieldDeleted",
            "FieldDeleting",
            "FieldUpdated",
            "FieldUpdating",
            "ItemAdded",
            "ItemAdding",
            "ItemAttachmentAdded",
            "ItemAttachmentAdding",
            "ItemAttachmentDeleted",
            "ItemAttachmentDeleting",
            "ItemCheckedIn",
            "ItemCheckedOut",
            "ItemCheckingIn",
            "ItemCheckingOut",
            "ItemDeleted",
            "ItemDeleting",
            "ItemFileMoved",
            "ItemFileMoving",
            "ItemFileTransformed",
            "ItemUncheckOut",
            "ItemUncheckingOut",
            "ItemUpdated",
            "ItemUpdating",
            "SiteDeleted",
            "SiteDeleting",
            "WebDeleted",
            "WebDeleting",
            "WebMoved",
            "WebMoving"});
            this.comboBoxEventType.Location = new System.Drawing.Point(74, 201);
            this.comboBoxEventType.Name = "comboBoxEventType";
            this.comboBoxEventType.Size = new System.Drawing.Size(222, 21);
            this.comboBoxEventType.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Event Type:";
            // 
            // textBoxSequence
            // 
            this.textBoxSequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSequence.Location = new System.Drawing.Point(74, 178);
            this.textBoxSequence.Name = "textBoxSequence";
            this.textBoxSequence.Size = new System.Drawing.Size(222, 20);
            this.textBoxSequence.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sequence:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class:";
            // 
            // textBoxAssemlby
            // 
            this.textBoxAssemlby.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAssemlby.Location = new System.Drawing.Point(7, 49);
            this.textBoxAssemlby.Multiline = true;
            this.textBoxAssemlby.Name = "textBoxAssemlby";
            this.textBoxAssemlby.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAssemlby.Size = new System.Drawing.Size(289, 46);
            this.textBoxAssemlby.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assembly:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(601, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(238, 17);
            this.toolStripStatusLabel1.Text = "Originally was created by Patrick Tisseghem";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // lvLog
            // 
            this.lvLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLog.FullRowSelect = true;
            this.lvLog.GridLines = true;
            this.lvLog.Location = new System.Drawing.Point(8, 427);
            this.lvLog.Margin = new System.Windows.Forms.Padding(2);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(585, 100);
            this.lvLog.TabIndex = 5;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listviewLog_KeyDown);
            this.lvLog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvLog_MouseClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip";
            this.contextMenu.Size = new System.Drawing.Size(103, 26);
            this.contextMenu.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(279, 233);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 551);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Handler Explorer 2013/2016";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExplore;
        private System.Windows.Forms.TextBox textBoxSiteCollectionURL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonAddHandler;
        private System.Windows.Forms.ComboBox comboBoxEventType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSequence;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAssemlby;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveHandler;
        private System.Windows.Forms.TreeView treeViewItems;
        private System.Windows.Forms.Button btnLoadAssembly;
        private System.Windows.Forms.ComboBox comboBoxClasses;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRestartIIS;
        private System.Windows.Forms.CheckBox checkboxAutoIisReset;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.CheckBox checkboxLoadWebs;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.Button btnRemoveGAC;
        private System.Windows.Forms.Button btnInstallGAC;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

