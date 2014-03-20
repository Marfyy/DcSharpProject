namespace server
{
    partial class ServerForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.portbtn = new System.Windows.Forms.Button();
            this.portbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lst_serverlist = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_exitServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 68);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 290);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Connected clients";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // portbtn
            // 
            this.portbtn.Location = new System.Drawing.Point(153, 9);
            this.portbtn.Name = "portbtn";
            this.portbtn.Size = new System.Drawing.Size(75, 23);
            this.portbtn.TabIndex = 2;
            this.portbtn.Text = "Set port";
            this.portbtn.UseVisualStyleBackColor = true;
            this.portbtn.Click += new System.EventHandler(this.portbtn_Click);
            // 
            // portbox
            // 
            this.portbox.Location = new System.Drawing.Point(47, 11);
            this.portbox.Name = "portbox";
            this.portbox.Size = new System.Drawing.Size(100, 20);
            this.portbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Connected Clients";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Serverlist";
            // 
            // lst_serverlist
            // 
            this.lst_serverlist.FormattingEnabled = true;
            this.lst_serverlist.Location = new System.Drawing.Point(247, 69);
            this.lst_serverlist.Name = "lst_serverlist";
            this.lst_serverlist.Size = new System.Drawing.Size(216, 290);
            this.lst_serverlist.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_exitServer
            // 
            this.btn_exitServer.Location = new System.Drawing.Point(388, 370);
            this.btn_exitServer.Name = "btn_exitServer";
            this.btn_exitServer.Size = new System.Drawing.Size(75, 23);
            this.btn_exitServer.TabIndex = 9;
            this.btn_exitServer.Text = "Exit";
            this.btn_exitServer.UseVisualStyleBackColor = true;
            this.btn_exitServer.Click += new System.EventHandler(this.btn_exitServer_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 405);
            this.Controls.Add(this.btn_exitServer);
            this.Controls.Add(this.lst_serverlist);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portbox);
            this.Controls.Add(this.portbtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button portbtn;
        private System.Windows.Forms.TextBox portbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lst_serverlist;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_exitServer;
    }
}

