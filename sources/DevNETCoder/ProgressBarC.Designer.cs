namespace DevNETCoder
{
    partial class ProgressBarC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressBarC));
            this.loading = new DevExpress.XtraEditors.ProgressBarControl();
            this.gri = new DevExpress.XtraGrid.GridControl();
            this.gridResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btF = new DevExpress.XtraEditors.SimpleButton();
            this.lbPro = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.loading.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.SuspendLayout();
            // 
            // loading
            // 
            this.loading.Location = new System.Drawing.Point(12, 12);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(609, 24);
            this.loading.TabIndex = 0;
            // 
            // gri
            // 
            this.gri.Location = new System.Drawing.Point(13, 64);
            this.gri.MainView = this.gridResult;
            this.gri.Name = "gri";
            this.gri.Size = new System.Drawing.Size(608, 141);
            this.gri.TabIndex = 1;
            this.gri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridResult});
            // 
            // gridResult
            // 
            this.gridResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridResult.GridControl = this.gri;
            this.gridResult.Name = "gridResult";
            this.gridResult.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Action";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 295;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Result";
            this.gridColumn2.FieldName = "Result";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 50;
            // 
            // btF
            // 
            this.btF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btF.Enabled = false;
            this.btF.Location = new System.Drawing.Point(534, 211);
            this.btF.Name = "btF";
            this.btF.Size = new System.Drawing.Size(88, 23);
            this.btF.TabIndex = 3;
            this.btF.Text = "Finish";
            this.btF.Click += new System.EventHandler(this.btF_Click);
            // 
            // lbPro
            // 
            this.lbPro.Location = new System.Drawing.Point(13, 44);
            this.lbPro.Name = "lbPro";
            this.lbPro.Size = new System.Drawing.Size(47, 13);
            this.lbPro.TabIndex = 4;
            this.lbPro.Text = "Executing";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProgressBarC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 239);
            this.ControlBox = false;
            this.Controls.Add(this.lbPro);
            this.Controls.Add(this.btF);
            this.Controls.Add(this.gri);
            this.Controls.Add(this.loading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressBarC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please waiting ...";
            this.Load += new System.EventHandler(this.ProgressBar_Load);
            this.Shown += new System.EventHandler(this.ProgressBar_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.loading.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl loading;
        private DevExpress.XtraGrid.GridControl gri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridResult;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton btF;
        private DevExpress.XtraEditors.LabelControl lbPro;
        private System.Windows.Forms.Timer timer1;
    }
}