namespace klient
{
    partial class ClientForm
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
            this.txt_username = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_registrera = new System.Windows.Forms.Button();
            this.txt_userregister = new System.Windows.Forms.TextBox();
            this.txt_connClient = new System.Windows.Forms.TextBox();
            this.connectbtn = new System.Windows.Forms.Button();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_passregister = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(67, 295);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(112, 20);
            this.txt_username.TabIndex = 0;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(6, 347);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(63, 25);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_registrera
            // 
            this.btn_registrera.Location = new System.Drawing.Point(6, 251);
            this.btn_registrera.Name = "btn_registrera";
            this.btn_registrera.Size = new System.Drawing.Size(64, 27);
            this.btn_registrera.TabIndex = 2;
            this.btn_registrera.Text = "registrera";
            this.btn_registrera.UseVisualStyleBackColor = true;
            this.btn_registrera.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_userregister
            // 
            this.txt_userregister.Location = new System.Drawing.Point(64, 199);
            this.txt_userregister.Name = "txt_userregister";
            this.txt_userregister.Size = new System.Drawing.Size(115, 20);
            this.txt_userregister.TabIndex = 3;
            // 
            // txt_connClient
            // 
            this.txt_connClient.Location = new System.Drawing.Point(12, 25);
            this.txt_connClient.Multiline = true;
            this.txt_connClient.Name = "txt_connClient";
            this.txt_connClient.Size = new System.Drawing.Size(236, 144);
            this.txt_connClient.TabIndex = 4;
            // 
            // connectbtn
            // 
            this.connectbtn.Location = new System.Drawing.Point(6, 422);
            this.connectbtn.Name = "connectbtn";
            this.connectbtn.Size = new System.Drawing.Size(75, 23);
            this.connectbtn.TabIndex = 5;
            this.connectbtn.Text = "connect";
            this.connectbtn.UseVisualStyleBackColor = true;
            this.connectbtn.Click += new System.EventHandler(this.connectbtn_Click);
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(31, 391);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(158, 20);
            this.txt_ip.TabIndex = 6;
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(230, 391);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(52, 20);
            this.txt_port.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port:";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(67, 319);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(112, 20);
            this.txt_password.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Lösenord:";
            // 
            // txt_passregister
            // 
            this.txt_passregister.Location = new System.Drawing.Point(65, 225);
            this.txt_passregister.Name = "txt_passregister";
            this.txt_passregister.Size = new System.Drawing.Size(114, 20);
            this.txt_passregister.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Connected Clients";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Username:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Lösenord:";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 457);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_passregister);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.connectbtn);
            this.Controls.Add(this.txt_connClient);
            this.Controls.Add(this.txt_userregister);
            this.Controls.Add(this.btn_registrera);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txt_username);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_registrera;
        private System.Windows.Forms.TextBox txt_userregister;
        private System.Windows.Forms.TextBox txt_connClient;
        private System.Windows.Forms.Button connectbtn;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_passregister;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

