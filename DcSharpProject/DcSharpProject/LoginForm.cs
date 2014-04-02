using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DcSharpProject
{
    public partial class LoginForm : Form
    {
        public Server connectionserver { get; set; }
        public bool status { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        public Server getserver()
        {
            return connectionserver;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtBoxLoginIP.Text) || string.IsNullOrEmpty(txtBoxLoginName.Text) || string.IsNullOrEmpty(txtBoxLoginPass.Text) || string.IsNullOrEmpty(txtBoxLoginPort.Text))
            {
                MessageBox.Show("Please fill out your information correctly", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.connectionserver = new Server(" ", txtBoxLoginIP.Text, int.Parse(txtBoxLoginPort.Text), txtBoxLoginName.Text, txtBoxLoginPass.Text);
                this.Close();
                this.status = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxLoginIP.Text) || string.IsNullOrEmpty(txtBoxLoginName.Text) || string.IsNullOrEmpty(txtBoxLoginPass.Text) || string.IsNullOrEmpty(txtBoxLoginPort.Text))
            {
                MessageBox.Show("Please fill out your information correctly", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.connectionserver = new Server(" ", txtBoxLoginIP.Text, int.Parse(txtBoxLoginPort.Text), txtBoxLoginName.Text, txtBoxLoginPass.Text);
                this.Close();
                this.status = true;
            }
        }

        


    }
}
