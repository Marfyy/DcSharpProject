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
    public partial class RegisterForm : Form
    {
        

        public RegisterForm()
        {
            InitializeComponent();
            
        }

        private void btnRegisterNewAcc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxRegisterUserPass.Text) || string.IsNullOrEmpty(txtBoxRegisterUserName.Text))
            {
                MessageBox.Show("Please fill out your desired Username and Password", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                
            }
        }
    }
}
