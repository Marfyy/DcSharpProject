namespace DcSharpProject
{
    partial class LoginForm
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
            this.txtBoxLoginName = new System.Windows.Forms.TextBox();
            this.txtBoxLoginPass = new System.Windows.Forms.TextBox();
            this.txtBoxLoginIP = new System.Windows.Forms.TextBox();
            this.txtBoxLoginPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxLoginName
            // 
            this.txtBoxLoginName.Location = new System.Drawing.Point(18, 37);
            this.txtBoxLoginName.Name = "txtBoxLoginName";
            this.txtBoxLoginName.Size = new System.Drawing.Size(181, 20);
            this.txtBoxLoginName.TabIndex = 0;
            // 
            // txtBoxLoginPass
            // 
            this.txtBoxLoginPass.Location = new System.Drawing.Point(20, 91);
            this.txtBoxLoginPass.Name = "txtBoxLoginPass";
            this.txtBoxLoginPass.Size = new System.Drawing.Size(179, 20);
            this.txtBoxLoginPass.TabIndex = 1;
            // 
            // txtBoxLoginIP
            // 
            this.txtBoxLoginIP.Location = new System.Drawing.Point(20, 153);
            this.txtBoxLoginIP.Name = "txtBoxLoginIP";
            this.txtBoxLoginIP.Size = new System.Drawing.Size(179, 20);
            this.txtBoxLoginIP.TabIndex = 2;
            // 
            // txtBoxLoginPort
            // 
            this.txtBoxLoginPort.Location = new System.Drawing.Point(20, 212);
            this.txtBoxLoginPort.Name = "txtBoxLoginPort";
            this.txtBoxLoginPort.Size = new System.Drawing.Size(179, 20);
            this.txtBoxLoginPort.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(30, 269);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(96, 41);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(158, 269);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(93, 41);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 348);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxLoginPort);
            this.Controls.Add(this.txtBoxLoginIP);
            this.Controls.Add(this.txtBoxLoginPass);
            this.Controls.Add(this.txtBoxLoginName);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxLoginName;
        private System.Windows.Forms.TextBox txtBoxLoginPass;
        private System.Windows.Forms.TextBox txtBoxLoginIP;
        private System.Windows.Forms.TextBox txtBoxLoginPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
    }
}