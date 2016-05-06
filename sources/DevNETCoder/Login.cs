using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Collections;
using System.Data.SqlClient;
using DevNETCoder.Static;

namespace DevNETCoder
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        Server server;
        public void LoadServer()
        {
            if (Save.Servers != null)
            {
                cbSV.SelectedIndex = 0;
                DataTable dtServers = Save.Servers;
                dtServers.PrimaryKey = new DataColumn[] { dtServers.Columns[0] };
                cbSV.Properties.Items.Add(".\\SQLEXPRESS");
                cbSV.Properties.Items.Add("(Local)");
                foreach (DataRow row in dtServers.Rows)
                {
                    cbSV.Properties.Items.Add(row["Name"].ToString());
                }              
                cbSV.SelectedIndex = 0;
               // if (dtServers.Rows.Count > 0) cbSV.SelectedIndex = 2;
            }
            
        }

        public Login()
        {
            InitializeComponent();
        }

        private const int CS_DROPSHADOW = 0x00020000;
        private Point prevLeftClick;
        private bool isFirst = true;
        private bool toBlock = true;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;                
                return cp;
            }
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                LoadServer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
           
        }

        private void btE_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {               
                if (isFirst == true)
                {                   
                    prevLeftClick = new Point(e.X, e.Y);                
                    isFirst = false;
                }              
                else
                {                  
                    if (toBlock == false)
                        this.Location = new Point(this.Location.X + e.X - prevLeftClick.X, this.Location.Y + e.Y - prevLeftClick.Y);                 
                    prevLeftClick = new Point(e.X, e.Y);                  
                    toBlock = !toBlock;
                }
            }          
            else
                isFirst = true;
        }

        private void btA_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://devnet.vn");
        }

        private void btH_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://devnet.vn");
        }

        private void btbC_Click(object sender, EventArgs e)
        {
            try
            {
                    btbC.Text = "Loading...";
                    btbC.Enabled =  false;
                    btA.Enabled = false;
                    btE.Enabled = false;
                    btH.Enabled = false;
                    btA.Update(); btbC.Update(); btH.Update(); btE.Update();


           

                    server = new Server(cbSV.Text);
                    server.ConnectionContext.LockTimeout = 15;

                    if (cbL.SelectedIndex == 0)
                    {
                        server.ConnectionContext.InUse = true;
                        server.ConnectionContext.LoginSecure = true;
                    }
                    else
                    {
                        if (txtPa.Text == "" || txtUN.Text == "") { MessageBox.Show("Please enter username and password !", "Connect to server"); return; }
                        server.ConnectionContext.LoginSecure = false;
                        server.ConnectionContext.Login = txtUN.Text;
                        server.ConnectionContext.Password = txtPa.Text;
                    }
           
                        server.ConnectionContext.Connect();
                        Save.Connection = server.ConnectionContext.ConnectionString.ToString();                
                        Save.SVName = server;               
                        SForm.MainForm.Show();
                
               
            }
            catch
            {
                MessageBox.Show("Cannot connect to " + cbSV.Text, "Connect to server");
            }
            finally
            {
                btbC.Enabled = btA.Enabled = btE.Enabled = btH.Enabled = true;
                btbC.Text = "Connect";
            }
           
        }
        public void LoginClick()
        {
            try
            {
                server = new Server(cbSV.Text);
                server.ConnectionContext.LockTimeout = 15;

                if (cbL.SelectedIndex == 0)
                {
                    server.ConnectionContext.InUse = true;
                    server.ConnectionContext.LoginSecure = true;
                }
                else
                {
                    if (txtPa.Text == "" || txtUN.Text == "") { MessageBox.Show("Please enter username and password !", "Connect to server"); return; }
                    server.ConnectionContext.LoginSecure = false;
                    server.ConnectionContext.Login = txtUN.Text;
                    server.ConnectionContext.Password = txtPa.Text;
                }
            
                    server.ConnectionContext.Connect();
                    Save.Connection = server.ConnectionContext.ConnectionString.ToString();
                    Save.SVName = server;
                    SForm.MainForm.Show();
            }
            catch
            {
                MessageBox.Show("Cannot connect to " + cbSV.Text, "Connect to server");
            }
            
        }

        private void cbL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbL.SelectedIndex == 0)
            {
                lbN.Enabled = lbP.Enabled = txtUN.Enabled = txtPa.Enabled = false;
            }
            else
            {
                lbN.Enabled = lbP.Enabled = txtUN.Enabled = txtPa.Enabled = true;
            }
        }  
    }
}