// pragma added
#pragma warning disable 1587     //  XML comment is not placed on a valid language element
///--------------------------------------------------------------------------------///
///-- WSS v3 Event Handler Explorer                                              --///
///-- Demoware created by Patrick Tisseghem (U2U)                                --///
///-- patrick@u2u.be - http://blog.u2u.info/dottextweb/patrick                   --///
///-- This is a small application demonstrating how developers can retrieve      --///
///-- information regarding the event handlers associated with the various       --///
///-- types in the WSS object model. Additionally, you can register and          --///
///-- unregister event handlers.                                                 --///
///--------------------------------------------------------------------------------///
///-- You can freely use this application but remember this was created with the --///
///-- the purpose of demonstrating the concept of event handlers in WSS v3       --///
///-- and is not tested for other uses                                           --///
///--------------------------------------------------------------------------------///
#pragma warning restore 1587     //XML comment is not placed on a valid language element

using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;
using Microsoft.SharePoint;
using System.Drawing;
using System.Management.Automation;


namespace EventHandlerExplorer
{
    using System.Diagnostics;

    /// <summary>
    /// </summary>
    public partial class FormMain : Form
    {
        private SPSite _site = null;

        /// <summary>
        /// Xml configuration
        /// </summary>
        public Settings Settings { get; set; }

        /// <summary>
        /// Event Handler Explorer
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvLog.View = View.Details;
            lvLog.HideSelection = false;
            lvLog.Columns.Add("Log messages", "Log messages", 2000);

            textBoxSiteCollectionURL.Text = @"http://localhost/";
            textBoxSequence.Text = @"10000";
        }

        /// <summary>
        /// Initialize
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                Logger("Loading settings..");
                Settings = new Settings(this);
                Settings.LoadSettings();
                Logger("Succesfully!");

                checkboxLoadWebs.Checked = Settings.LoadWebsOnStart;
                checkboxAutoIisReset.Checked = Settings.AutoIisReset;

                if (Settings.LoadWebsOnStart)
                {
                    ExploreInformation();
                }
            }
            catch (Exception ex)
            {
                Logger("Exception on Form Load: " + ex.ToString(), Color.LightBlue);
            }
        }


        /// <summary>
        /// Run PowerShell scripts, wrapper
        /// </summary>
        private void LaunchPsCommand(string script)
        {
            using (PowerShell powerShellInstance = PowerShell.Create())
            {
                powerShellInstance.AddScript(script);

                Logger(script);
                Logger(string.Empty);

                // Collection to store output stream objects
                PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();

                // We will be notified when an error is returned from stream:
                powerShellInstance.Streams.Error.DataAdded += Error_DataAdded;

                // Invoke async execution on the pipeline (collecting output)
                IAsyncResult result = powerShellInstance.BeginInvoke<PSObject, PSObject>(null, outputCollection);

                foreach (PSObject outputItem in outputCollection)
                {
                    if (outputItem != null && outputItem.BaseObject != null)
                    {
                        Logger(outputItem.BaseObject.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Catch if Async powershell returns error
        /// </summary>
        private void Error_DataAdded(object sender, DataAddedEventArgs e)
        {
            var errorCollection = (PSDataCollection<ErrorRecord>)sender;
            var errorResults = errorCollection.ReadAll();

            Logger("Powershell returned Error:", Color.LightBlue);
            if (errorResults[0] != null)
            {
                // Show, if an error is written to the error stream
                Logger(errorResults[0].ToString(), Color.LightBlue);
            }
            errorResults.Clear();
        }


        /// <summary>
        /// Log in listview
        /// </summary>
        public void Logger(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Logger), message);
            }
            else
            {
                ListViewItem lvi = new ListViewItem(new string[] { message });
                lvLog.Items.Add(lvi);

                // scroll down log records
                int count = lvLog.Items.Count;
                lvLog.EnsureVisible(count - 1);
            }
        }

        /// <summary>
        /// Log warnings 
        /// </summary>
        public void Logger(string message, Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, Color>(Logger), message, color);
            }
            else
            {
                ListViewItem lvi = new ListViewItem(new string[] { message });
                lvi.BackColor = color;
                lvLog.Items.Add(lvi);

                // scroll down
                lvLog.EnsureVisible(lvLog.Items.Count - 1);
            }
        }


        /// <summary>
        /// Save current control settings
        /// </summary>
        private void CallSaveSettings()
        {
            Settings.AutoIisReset = this.checkboxAutoIisReset.Checked;
            Settings.LoadWebsOnStart = this.checkboxLoadWebs.Checked;

            Settings.SaveSettings();
            Logger("Saved setting.");
        }

        private void ButtonRestartIisClick(object sender, EventArgs e)
        {
            LaunchPsCommand(Settings.ScriptIisReset);
        }



        private void ButtonExploreClick(object sender, EventArgs e)
        {
            ExploreInformation();
        }

        private void ExploreInformation()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _site = new SPSite(textBoxSiteCollectionURL.Text);

                FillTree();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Logger(ex.Message, Color.LightBlue);
            }
        }

        private void FillTree()
        {
            treeViewItems.Nodes.Clear();
            TreeNode siteCollectionNode = treeViewItems.Nodes.Add(_site.Url);
            siteCollectionNode.ImageIndex = 2;
            siteCollectionNode.SelectedImageIndex = 2;
          

            //-- add individual sites
            TreeNode sitesNode = siteCollectionNode.Nodes.Add("Sites");


            foreach (SPWeb web in _site.AllWebs)
            {
                TreeNode node = sitesNode.Nodes.Add(web.Title);
                node.Tag = web;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;

                //-- add lists and document libraries
                TreeNode listsNode = node.Nodes.Add("Lists");                
                TreeNode librariesNode = node.Nodes.Add("Document Libraries");                

                foreach (SPList list in web.Lists)
                {
                    if ((!list.Hidden) && (list.BaseType != SPBaseType.DocumentLibrary))
                    {
                        TreeNode listNode = listsNode.Nodes.Add(list.Title);
                        listNode.Tag = list;
                        listNode.ImageIndex = 11;
                        listNode.SelectedImageIndex = 11;

                        TreeNode itemsNode = listNode.Nodes.Add("Items");
                        itemsNode.Tag = "Items";
                        itemsNode.ImageIndex = 0;
                        itemsNode.SelectedImageIndex = 0;
                        

                        TreeNode eventHandlersNode = listNode.Nodes.Add("Event Handlers");
                        eventHandlersNode.Tag = "List Event Handlers";
                        eventHandlersNode.ImageIndex = 0;
                        eventHandlersNode.SelectedImageIndex = 0;                        
                    }
                    else
                    {
                        TreeNode libNode = librariesNode.Nodes.Add(list.Title);
                        libNode.Tag = list;
                        libNode.ImageIndex = 12;
                        libNode.SelectedImageIndex = 12;

                        TreeNode filesNode = libNode.Nodes.Add("Files");
                        filesNode.Tag = "Files";
                        filesNode.ImageIndex = 0;
                        filesNode.SelectedImageIndex = 0;                        

                        TreeNode eventHandlersNode = libNode.Nodes.Add("Event Handlers");
                        eventHandlersNode.Tag = "Lib Event Handlers";
                        eventHandlersNode.ImageIndex = 0;
                        eventHandlersNode.SelectedImageIndex = 0;                          
                    }
                }

                TreeNode eventHandlerNode = node.Nodes.Add("Event Handlers");
                eventHandlerNode.Tag = "Web Event Handlers";
                eventHandlerNode.ImageIndex = 0;
                eventHandlerNode.SelectedImageIndex = 0;                 

            }

            //-- add content types for the site collection
            TreeNode contentTypesNode = siteCollectionNode.Nodes.Add("Content Types");
            contentTypesNode.ImageIndex = 0;
            contentTypesNode.SelectedImageIndex = 0;                

            SPWeb rootWeb = _site.RootWeb;
            foreach (SPContentType contentType in rootWeb.ContentTypes)
            {
                TreeNode node = contentTypesNode.Nodes.Add(contentType.Name);
                node.Tag = contentType;
                node.ImageIndex = 8;
                node.SelectedImageIndex = 8;

                TreeNode eventHandlersNode = node.Nodes.Add("Event Handlers");
                eventHandlersNode.Tag = "ContentType Event Handlers";
                eventHandlersNode.ImageIndex = 0;
                eventHandlersNode.SelectedImageIndex = 0;   

            }

            siteCollectionNode.Expand();
            sitesNode.Expand();
        }

        private void TreeViewItemsNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Tag != null)
                {
                    string tag = e.Node.Tag.ToString();

                    switch (tag)
                    {
                        case "ContentType Event Handlers":
                            {
                                SPContentType item = (SPContentType)e.Node.Parent.Tag;

                                e.Node.Nodes.Clear();

                                foreach (SPEventReceiverDefinition er in item.EventReceivers)
                                {
                                    TreeNode node = e.Node.Nodes.Add(er.Class + " (" + er.Type.ToString() + ")");
                                    node.Tag = er;
                                    node.ImageIndex = 10;
                                    node.SelectedImageIndex = 10;
                                }
                                break;
                            }
                        case "Web Event Handlers":
                            {
                                SPWeb item = (SPWeb)e.Node.Parent.Tag;

                                e.Node.Nodes.Clear();

                                foreach (SPEventReceiverDefinition er in item.EventReceivers)
                                {
                                    TreeNode node = e.Node.Nodes.Add(er.Class + " (" + er.Type.ToString() + ")");
                                    node.Tag = er;
                                    node.ImageIndex = 10;
                                    node.SelectedImageIndex = 10;
                                }
                                break;
                            }
                        case "Lib Event Handlers":
                            {
                                SPDocumentLibrary item = (SPDocumentLibrary)e.Node.Parent.Tag;

                                e.Node.Nodes.Clear();

                                foreach (SPEventReceiverDefinition er in item.EventReceivers)
                                {
                                    TreeNode node = e.Node.Nodes.Add(er.Class + " (" + er.Type.ToString() + ")");
                                    node.Tag = er;
                                    node.ImageIndex = 10;
                                    node.SelectedImageIndex = 10;
                                }
                                break;
                            }
                        case "Files":
                            {
                                SPDocumentLibrary item = (SPDocumentLibrary)e.Node.Parent.Tag;

                                e.Node.Nodes.Clear();

                                foreach (SPListItem listItem in item.Items)
                                {
                                    TreeNode node = e.Node.Nodes.Add(listItem.File.Name);
                                    node.Tag = listItem.File;
                                    node.ImageIndex = 3;
                                    node.SelectedImageIndex = 3;
                                    TreeNode evNode = node.Nodes.Add("Event Handlers");
                                    evNode.Tag = "File Event Handlers";

                                }
                                break;
                            }
                        case "List Event Handlers":
                            {
                                SPList item = (SPList)e.Node.Parent.Tag;

                                e.Node.Nodes.Clear();

                                foreach (SPEventReceiverDefinition er in item.EventReceivers)
                                {
                                    TreeNode node = e.Node.Nodes.Add(er.Class + " (" + er.Type.ToString() + ")");
                                    node.Tag = er;
                                    node.ImageIndex = 10;
                                    node.SelectedImageIndex = 10;
                                }
                                break;
                            }
                        case "Items":
                            {
                                SPList item = (SPList)e.Node.Parent.Tag;

                                e.Node.Nodes.Clear();

                                foreach (SPListItem listItem in item.Items)
                                {
                                    TreeNode node = e.Node.Nodes.Add(listItem.Title);
                                    node.Tag = listItem;
                                    node.ImageIndex = 5;
                                    node.SelectedImageIndex = 5;
                                    TreeNode evNode = node.Nodes.Add("Event Handlers");
                                    evNode.Tag = "Item Event Handlers";

                                }
                                break;
                            }
                        case "Item Event Handlers":
                            {
                                SPListItem item = (SPListItem)e.Node.Parent.Tag;
                                SPList list = item.ParentList;

                                e.Node.Nodes.Clear();

                                foreach (SPEventReceiverDefinition er in list.EventReceivers)
                                {
                                    TreeNode node = e.Node.Nodes.Add(er.Class + " (" + er.Type.ToString() + ")");
                                    node.Tag = er;
                                    node.ImageIndex = 10;
                                    node.SelectedImageIndex = 10;
                                }
                                break;
                            }
                        case "File Event Handlers":
                            {
                                SPFile item = (SPFile)e.Node.Parent.Tag;

                                e.Node.Nodes.Clear();

                                foreach (SPEventReceiverDefinition er in item.EventReceivers)
                                {
                                    TreeNode node = e.Node.Nodes.Add(er.Class);
                                    node.Tag = er;
                                    node.ImageIndex = 10;
                                    node.SelectedImageIndex = 10;
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger(ex.ToString(), Color.LightBlue);
            }
        }

        private void ButtonLoadAssemblyClick(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog fileDialog = new OpenFileDialog())
                {
                    fileDialog.Title = @"Select .NET Assembly";
                    fileDialog.Filter = @"Assemblies (*.dll)|*.dll";
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string dll = fileDialog.FileName;
                        Assembly ass = Assembly.LoadFile(dll);
                        if (!ass.GlobalAssemblyCache)
                        {
                            Logger("Your Assembly has not yet been deployed in the GAC! If already tried to deploy, check if is signed?", Color.LightBlue);
                        }
                        else
                        {
                            textBoxAssemlby.Text = ass.FullName;

                            comboBoxClasses.SelectedIndex = -1;
                            comboBoxClasses.Items.Clear();
                            foreach (Type type in ass.GetTypes())
                            {
                                if (type.IsClass)
                                    comboBoxClasses.Items.Add(type.FullName);
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger(ex.Message, Color.LightBlue);
            }
        }

        private void ButtonAddClick(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                TreeNode node = treeViewItems.SelectedNode;

                if (node.Tag is SPList)
                {
                    SPList list = (SPList)node.Tag;
                    SPEventReceiverDefinition eventReceiverDefinition = list.EventReceivers.Add();
                    eventReceiverDefinition.Type = (SPEventReceiverType)Enum.Parse(typeof(SPEventReceiverType), comboBoxEventType.Text);
                    eventReceiverDefinition.Assembly = textBoxAssemlby.Text;
                    eventReceiverDefinition.Class = comboBoxClasses.Text;
                    eventReceiverDefinition.SequenceNumber = Int32.Parse(textBoxSequence.Text);
                    eventReceiverDefinition.Update();
                    list.Update();
                    flag = true;
                }
                if (node.Tag is SPContentType)
                {
                    SPContentType ct = (SPContentType)node.Tag;
                    SPEventReceiverDefinition eventReceiverDefinition = ct.EventReceivers.Add();
                    eventReceiverDefinition.Type = (SPEventReceiverType)Enum.Parse(typeof(SPEventReceiverType), comboBoxEventType.Text);
                    eventReceiverDefinition.Assembly = textBoxAssemlby.Text;
                    eventReceiverDefinition.Class = comboBoxClasses.Text;
                    eventReceiverDefinition.SequenceNumber = Int32.Parse(textBoxSequence.Text);
                    eventReceiverDefinition.Update();
                    ct.Update();
                    flag = true;
                }
                if (node.Tag is SPWeb)
                {
                    SPWeb w = (SPWeb)node.Tag;
                    SPEventReceiverDefinition eventReceiverDefinition = w.EventReceivers.Add();
                    eventReceiverDefinition.Type = (SPEventReceiverType)Enum.Parse(typeof(SPEventReceiverType), comboBoxEventType.Text);
                    eventReceiverDefinition.Assembly = textBoxAssemlby.Text;
                    eventReceiverDefinition.Class = comboBoxClasses.Text;
                    eventReceiverDefinition.SequenceNumber = Int32.Parse(textBoxSequence.Text);
                    eventReceiverDefinition.Update();
                    w.Update();
                    flag = true;
                }
                if (flag)
                {
                    Logger($"Event handler succesfully registered on {comboBoxEventType.Text}(deploy and reset needed on all Web Front Ends)");

                    if (checkboxAutoIisReset.Checked)
                    {
                        LaunchPsCommand(Settings.ScriptIisReset);
                    }
                }
                else
                    Logger(@"Are you sure your selected node is a list, document library, file, content type or web?", Color.LightBlue);
            }
            catch (Exception ex)
            {
                Logger(ex.Message, Color.LightBlue);
            }

        }

        private void TreeViewItemsNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Tag is SPEventReceiverDefinition)
                {
                    SPEventReceiverDefinition er = (SPEventReceiverDefinition)e.Node.Tag;
                    textBoxAssemlby.Text = er.Assembly;
                    comboBoxClasses.Items.Clear();
                    comboBoxClasses.Text = er.Class;
                    textBoxSequence.Text = er.SequenceNumber.ToString();
                    for (int i = 0; i < comboBoxEventType.Items.Count; i++)
                    {
                        if (comboBoxEventType.Items[i].ToString() == er.Type.ToString()) comboBoxEventType.SelectedIndex = i;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger(ex.Message, Color.LightBlue);
            }

        }

        private void ButtonRemoveClick(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = treeViewItems.SelectedNode;
                SPEventReceiverDefinition er = (SPEventReceiverDefinition)node.Tag;
                if (MessageBox.Show("Are you sure you want to remove this event handler?", "Event Handler Explorer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    er.Delete();
                    comboBoxEventType.SelectedIndex = -1;
                    comboBoxClasses.Items.Clear();
                    node.Parent.Nodes.Remove(node);
                    Logger(@"Event handler unregistered(iisreset needed)");

                    if (checkboxAutoIisReset.Checked)
                    {
                        LaunchPsCommand(Settings.ScriptIisReset);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger(ex.Message, Color.LightBlue);
            }
        }



        // Copy log messages in clipboard buffer
        private void listviewLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender != lvLog)
            {
                return;
            }

            // for 'KeyUp' event: if (((e.KeyData & Keys.ControlKey) != Keys.ControlKey) && e.KeyCode == Keys.C)
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopyLogEntriesToClipboard();
            }
        }

        private void lvLog_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvLog.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenu.Show(Cursor.Position);
                }
            }
        }

        private void contextMenuStrip_Click(object sender, EventArgs e)
        {
            CopyLogEntriesToClipboard();
        }

        private void CopyLogEntriesToClipboard()
        {
            var builder = new StringBuilder();

            foreach (ListViewItem item in lvLog.SelectedItems)
            {
                builder.AppendLine(item.SubItems[0].Text);
            }

            Clipboard.SetText(builder.ToString());
        }


        // Install assemblies in Global Assembly Cache
        private void btnInstallGAC_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog fileDialog = new OpenFileDialog())
                {
                    fileDialog.Title = @"Select .NET Assembly";
                    fileDialog.Filter = @"Assemblies (*.dll)|*.dll";
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fullPath = fileDialog.FileName;
                        string script = Settings.ScriptGacInstall.Replace("$fullpath", @fullPath);

                        LaunchPsCommand(script);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger(ex.Message, Color.LightBlue);
            }
        }

        private void btnRemoveGAC_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog fileDialog = new OpenFileDialog())
                {
                    fileDialog.Title = @"Select .NET Assembly";
                    fileDialog.Filter = @"Assemblies (*.dll)|*.dll";
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fullPath = fileDialog.FileName;
                        string script = Settings.ScriptGacRemove.Replace("$fullpath", @fullPath);

                        LaunchPsCommand(script);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger(ex.Message, Color.LightBlue);
            }
        }


        // Overwrite settings on checkboxes change
        private void checkboxLoadWebs_Click(object sender, EventArgs e)
        {
            CallSaveSettings();
        }

        private void checkboxAutoIisReset_Click(object sender, EventArgs e)
        {
            CallSaveSettings();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CallSaveSettings();
        }


        // Help icon
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://gennady-g.github.io//EventHandlerExplorer/");
            Process.Start(sInfo);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Cursor = Cursors.Default;
        }


        private void ButtonExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}