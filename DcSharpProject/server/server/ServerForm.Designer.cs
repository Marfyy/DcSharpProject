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
            this.btn_connClient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lst_serverlist = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_exitServer = new System.Windows.Forms.Button();
            this.lb_port = new System.Windows.Forms.Label();
            this.lbn_port1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 290);
            this.textBox1.TabIndex = 0;
            // 
            // btn_connClient
            // 
            this.btn_connClient.Location = new System.Drawing.Point(12, 321);
            this.btn_connClient.Name = "btn_connClient";
            this.btn_connClient.Size = new System.Drawing.Size(112, 23);
            this.btn_connClient.TabIndex = 1;
            this.btn_connClient.Text = "Connected clients";
            this.btn_connClient.UseVisualStyleBackColor = true;
            this.btn_connClient.Click += new System.EventHandler(this.btn_connClient_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Connected Clients";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Serverlist";
            // 
            // lst_serverlist
            // 
            this.lst_serverlist.FormattingEnabled = true;
            this.lst_serverlist.Location = new System.Drawing.Point(247, 25);
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
            this.btn_exitServer.Location = new System.Drawing.Point(247, 321);
            this.btn_exitServer.Name = "btn_exitServer";
            this.btn_exitServer.Size = new System.Drawing.Size(75, 23);
            this.btn_exitServer.TabIndex = 9;
            this.btn_exitServer.Text = "Exit";
            this.btn_exitServer.UseVisualStyleBackColor = true;
            this.btn_exitServer.Click += new System.EventHandler(this.btn_exitServer_Click);
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(12, 363);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(66, 13);
            this.lb_port.TabIndex = 10;
            this.lb_port.Text = "Current Port:";
            // 
            // lbn_port1
            // 
            this.lbn_port1.AutoSize = true;
            this.lbn_port1.Location = new System.Drawing.Point(84, 363);
            this.lbn_port1.Name = "lbn_port1";
            this.lbn_port1.Size = new System.Drawing.Size(13, 13);
            this.lbn_port1.TabIndex = 11;
            this.lbn_port1.Text = "0";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 385);
            this.Controls.Add(this.lbn_port1);
            this.Controls.Add(this.lb_port);
            this.Controls.Add(this.btn_exitServer);
            this.Controls.Add(this.lst_serverlist);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_connClient);
            this.Controls.Add(this.textBox1);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_connClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lst_serverlist;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_exitServer;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.Label lbn_port1;
    }
}

