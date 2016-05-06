namespace DevNETCoder
{
    partial class CreateAllClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAllClass));
            this.btC = new DevExpress.XtraEditors.SimpleButton();
            this.btF = new DevExpress.XtraEditors.SimpleButton();
            this.tlP = new DevExpress.XtraTreeList.TreeList();
            this.NameCC = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.IDi = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.folderID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btBr = new DevExpress.XtraEditors.SimpleButton();
            this.txtPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rd = new DevExpress.XtraEditors.RadioGroup();
            this.onpenFolder = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.tlP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btC
            // 
            this.btC.Location = new System.Drawing.Point(356, 189);
            this.btC.Name = "btC";
            this.btC.Size = new System.Drawing.Size(75, 23);
            this.btC.TabIndex = 10;
            this.btC.Text = "Cancel";
            this.btC.Click += new System.EventHandler(this.btC_Click);
            // 
            // btF
            // 
            this.btF.Location = new System.Drawing.Point(272, 189);
            this.btF.Name = "btF";
            this.btF.Size = new System.Drawing.Size(75, 23);
            this.btF.TabIndex = 9;
            this.btF.Text = "Finish";
            this.btF.Click += new System.EventHandler(this.btF_Click);
            // 
            // tlP
            // 
            this.tlP.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.NameCC,
            this.IDi,
            this.folderID});
            this.tlP.KeyFieldName = "CId";
            this.tlP.Location = new System.Drawing.Point(4, 81);
            this.tlP.Name = "tlP";
            this.tlP.OptionsBehavior.Editable = false;
            this.tlP.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            this.tlP.OptionsView.ShowCheckBoxes = true;
            this.tlP.ParentFieldName = "folderID";
            this.tlP.PreviewFieldName = "name";
            this.tlP.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.tlP.Size = new System.Drawing.Size(248, 131);
            this.tlP.TabIndex = 6;
            this.tlP.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlP_AfterCheckNode);
            // 
            // NameCC
            // 
            this.NameCC.Caption = "All Class";
            this.NameCC.FieldName = "name";
            this.NameCC.MinWidth = 32;
            this.NameCC.Name = "NameCC";
            this.NameCC.Visible = true;
            this.NameCC.VisibleIndex = 0;
            // 
            // IDi
            // 
            this.IDi.Caption = "ID";
            this.IDi.FieldName = "Cid";
            this.IDi.Name = "IDi";
            // 
            // folderID
            // 
            this.folderID.Caption = "treeListColumn2";
            this.folderID.FieldName = "folderID";
            this.folderID.Name = "folderID";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AccessibleName = "Name";
            this.repositoryItemCheckEdit1.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btBr);
            this.groupControl1.Controls.Add(this.txtPath);
            this.groupControl1.Location = new System.Drawing.Point(4, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(434, 63);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Location";
            // 
            // btBr
            // 
            this.btBr.Location = new System.Drawing.Point(349, 28);
            this.btBr.Name = "btBr";
            this.btBr.Size = new System.Drawing.Size(76, 23);
            this.btBr.TabIndex = 12;
            this.btBr.Text = "Browse";
            this.btBr.Click += new System.EventHandler(this.btBr_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(9, 30);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(334, 20);
            this.txtPath.TabIndex = 9;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(258, 87);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(173, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Do you like to replace the saving file";
            // 
            // rd
            // 
            this.rd.Location = new System.Drawing.Point(258, 106);
            this.rd.Name = "rd";
            this.rd.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.rd.Properties.Appearance.Options.UseBackColor = true;
            this.rd.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Replace"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Skip")});
            this.rd.Size = new System.Drawing.Size(171, 62);
            this.rd.TabIndex = 12;
            // 
            // CreateAllClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 222);
            this.ControlBox = false;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.rd);
            this.Controls.Add(this.btC);
            this.Controls.Add(this.btF);
            this.Controls.Add(this.tlP);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateAllClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create All Class";
            this.Load += new System.EventHandler(this.CreateAllClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tlP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btC;
        private DevExpress.XtraEditors.SimpleButton btF;
        private DevExpress.XtraTreeList.TreeList tlP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn NameCC;
        private DevExpress.XtraTreeList.Columns.TreeListColumn IDi;
        private DevExpress.XtraTreeList.Columns.TreeListColumn folderID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btBr;
        private DevExpress.XtraEditors.TextEdit txtPath;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.RadioGroup rd;
        private System.Windows.Forms.FolderBrowserDialog onpenFolder;
    }
}