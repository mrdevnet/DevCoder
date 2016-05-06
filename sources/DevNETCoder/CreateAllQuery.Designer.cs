namespace DevNETCoder
{
    partial class CreateAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAll));
            this.tlP = new DevExpress.XtraTreeList.TreeList();
            this.NameC = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.TableID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ckbP = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rd = new DevExpress.XtraEditors.RadioGroup();
            this.btF = new DevExpress.XtraEditors.SimpleButton();
            this.btC = new DevExpress.XtraEditors.SimpleButton();
            this.lbT = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tlP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlP
            // 
            this.tlP.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.NameC,
            this.ID,
            this.TableID});
            this.tlP.Location = new System.Drawing.Point(12, 12);
            this.tlP.Name = "tlP";
            this.tlP.OptionsBehavior.Editable = false;
            this.tlP.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            this.tlP.OptionsView.ShowCheckBoxes = true;
            this.tlP.ParentFieldName = "TableID";
            this.tlP.PreviewFieldName = "Name";
            this.tlP.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.tlP.Size = new System.Drawing.Size(260, 300);
            this.tlP.TabIndex = 0;
            this.tlP.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlP_AfterCheckNode);
            // 
            // NameC
            // 
            this.NameC.Caption = "All Procedule";
            this.NameC.FieldName = "Name";
            this.NameC.MinWidth = 32;
            this.NameC.Name = "NameC";
            this.NameC.Visible = true;
            this.NameC.VisibleIndex = 0;
            // 
            // ID
            // 
            this.ID.Caption = "treeListColumn1";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // TableID
            // 
            this.TableID.Caption = "treeListColumn2";
            this.TableID.FieldName = "TableID";
            this.TableID.Name = "TableID";
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
            this.groupControl1.Controls.Add(this.ckbP);
            this.groupControl1.Location = new System.Drawing.Point(279, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(236, 180);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Procedule";
            // 
            // ckbP
            // 
            this.ckbP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbP.CheckOnClick = true;
            this.ckbP.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Insert", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Update", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Delete", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "SelectAll", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "SelectPage", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "SelectTop", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "SelectById", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "TestById", System.Windows.Forms.CheckState.Checked)});
            this.ckbP.Location = new System.Drawing.Point(5, 25);
            this.ckbP.Name = "ckbP";
            this.ckbP.Size = new System.Drawing.Size(222, 144);
            this.ckbP.TabIndex = 8;
            this.ckbP.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.ckbP_ItemCheck);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.rd);
            this.groupControl2.Location = new System.Drawing.Point(279, 199);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(236, 113);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Setup";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(214, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Do you like to replace the existing procedure";
            // 
            // rd
            // 
            this.rd.Location = new System.Drawing.Point(5, 49);
            this.rd.Name = "rd";
            this.rd.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.rd.Properties.Appearance.Options.UseBackColor = true;
            this.rd.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Replace"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Skip")});
            this.rd.Size = new System.Drawing.Size(222, 54);
            this.rd.TabIndex = 10;
            // 
            // btF
            // 
            this.btF.Location = new System.Drawing.Point(341, 323);
            this.btF.Name = "btF";
            this.btF.Size = new System.Drawing.Size(75, 23);
            this.btF.TabIndex = 3;
            this.btF.Text = "Finish";
            this.btF.Click += new System.EventHandler(this.btF_Click);
            // 
            // btC
            // 
            this.btC.Location = new System.Drawing.Point(431, 323);
            this.btC.Name = "btC";
            this.btC.Size = new System.Drawing.Size(75, 23);
            this.btC.TabIndex = 4;
            this.btC.Text = "Cancel";
            this.btC.Click += new System.EventHandler(this.btC_Click);
            // 
            // lbT
            // 
            this.lbT.Location = new System.Drawing.Point(12, 324);
            this.lbT.Name = "lbT";
            this.lbT.Size = new System.Drawing.Size(24, 13);
            this.lbT.TabIndex = 5;
            this.lbT.Text = "Total";
            // 
            // CreateAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 352);
            this.ControlBox = false;
            this.Controls.Add(this.lbT);
            this.Controls.Add(this.btC);
            this.Controls.Add(this.btF);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create All Procedule";
            this.Load += new System.EventHandler(this.CreateAllQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tlP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckbP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn NameC;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn TableID;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckedListBoxControl ckbP;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btF;
        private DevExpress.XtraEditors.SimpleButton btC;
        private DevExpress.XtraEditors.LabelControl lbT;
        public DevExpress.XtraEditors.RadioGroup rd;

    }
}