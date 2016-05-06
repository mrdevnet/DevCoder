namespace DevNETCoder
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.cbSV = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbL = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtUN = new DevExpress.XtraEditors.TextEdit();
            this.txtPa = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbN = new DevExpress.XtraEditors.LabelControl();
            this.lbP = new DevExpress.XtraEditors.LabelControl();
            this.btbC = new DevExpress.XtraEditors.SimpleButton();
            this.btE = new DevExpress.XtraEditors.SimpleButton();
            this.btH = new DevExpress.XtraEditors.SimpleButton();
            this.btA = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cbSV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSV
            // 
            this.cbSV.Location = new System.Drawing.Point(138, 132);
            this.cbSV.Name = "cbSV";
            this.cbSV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSV.Size = new System.Drawing.Size(277, 20);
            this.cbSV.TabIndex = 1;
            // 
            // cbL
            // 
            this.cbL.EditValue = "Windows Authentication";
            this.cbL.Location = new System.Drawing.Point(138, 167);
            this.cbL.Name = "cbL";
            this.cbL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbL.Properties.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cbL.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbL.Size = new System.Drawing.Size(277, 20);
            this.cbL.TabIndex = 2;
            this.cbL.SelectedIndexChanged += new System.EventHandler(this.cbL_SelectedIndexChanged);
            // 
            // txtUN
            // 
            this.txtUN.EditValue = "sa";
            this.txtUN.Enabled = false;
            this.txtUN.Location = new System.Drawing.Point(138, 202);
            this.txtUN.Name = "txtUN";
            this.txtUN.Size = new System.Drawing.Size(277, 20);
            this.txtUN.TabIndex = 3;
            // 
            // txtPa
            // 
            this.txtPa.Enabled = false;
            this.txtPa.Location = new System.Drawing.Point(138, 238);
            this.txtPa.Name = "txtPa";
            this.txtPa.Properties.UseSystemPasswordChar = true;
            this.txtPa.Size = new System.Drawing.Size(277, 20);
            this.txtPa.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 135);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Server Name : ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 170);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Authentication : ";
            // 
            // lbN
            // 
            this.lbN.Enabled = false;
            this.lbN.Location = new System.Drawing.Point(24, 205);
            this.lbN.Name = "lbN";
            this.lbN.Size = new System.Drawing.Size(62, 13);
            this.lbN.TabIndex = 7;
            this.lbN.Text = "User Name : ";
            // 
            // lbP
            // 
            this.lbP.Enabled = false;
            this.lbP.Location = new System.Drawing.Point(24, 241);
            this.lbP.Name = "lbP";
            this.lbP.Size = new System.Drawing.Size(56, 13);
            this.lbP.TabIndex = 8;
            this.lbP.Text = "Password : ";
            // 
            // btbC
            // 
            this.btbC.Location = new System.Drawing.Point(73, 291);
            this.btbC.Name = "btbC";
            this.btbC.Size = new System.Drawing.Size(75, 23);
            this.btbC.TabIndex = 9;
            this.btbC.Text = "Connect";
            this.btbC.Click += new System.EventHandler(this.btbC_Click);
            // 
            // btE
            // 
            this.btE.Location = new System.Drawing.Point(167, 291);
            this.btE.Name = "btE";
            this.btE.Size = new System.Drawing.Size(75, 23);
            this.btE.TabIndex = 10;
            this.btE.Text = "Cancel";
            this.btE.Click += new System.EventHandler(this.btE_Click);
            // 
            // btH
            // 
            this.btH.Location = new System.Drawing.Point(261, 291);
            this.btH.Name = "btH";
            this.btH.Size = new System.Drawing.Size(75, 23);
            this.btH.TabIndex = 11;
            this.btH.Text = "Help";
            this.btH.Click += new System.EventHandler(this.btH_Click);
            // 
            // btA
            // 
            this.btA.Location = new System.Drawing.Point(354, 291);
            this.btA.Name = "btA";
            this.btA.Size = new System.Drawing.Size(75, 23);
            this.btA.TabIndex = 12;
            this.btA.Text = "About";
            this.btA.Click += new System.EventHandler(this.btA_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::DevNETCoder.Properties.Resources.index1;
            this.pictureBox1.InitialImage = global::DevNETCoder.Properties.Resources.index1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 109);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::DevNETCoder.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(500, 337);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btA);
            this.Controls.Add(this.btH);
            this.Controls.Add(this.btE);
            this.Controls.Add(this.btbC);
            this.Controls.Add(this.lbP);
            this.Controls.Add(this.lbN);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPa);
            this.Controls.Add(this.txtUN);
            this.Controls.Add(this.cbL);
            this.Controls.Add(this.cbSV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2007 Black";
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.cbSV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbSV;
        private DevExpress.XtraEditors.ComboBoxEdit cbL;
        private DevExpress.XtraEditors.TextEdit txtUN;
        private DevExpress.XtraEditors.TextEdit txtPa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbN;
        private DevExpress.XtraEditors.LabelControl lbP;
        private DevExpress.XtraEditors.SimpleButton btbC;
        private DevExpress.XtraEditors.SimpleButton btE;
        private DevExpress.XtraEditors.SimpleButton btH;
        private DevExpress.XtraEditors.SimpleButton btA;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}