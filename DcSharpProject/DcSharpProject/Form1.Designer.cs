namespace DcSharpProject
{
    partial class Form1
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
            this.tabDownloads = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lstUploads = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstDownloads = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.userDirTreeView = new System.Windows.Forms.TreeView();
            this.dirIconList = new System.Windows.Forms.ImageList(this.components);
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabDC = new System.Windows.Forms.TabControl();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lstSprServer = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDownloads.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tabDC.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDownloads
            // 
            this.tabDownloads.Controls.Add(this.label14);
            this.tabDownloads.Controls.Add(this.label13);
            this.tabDownloads.Controls.Add(this.label12);
            this.tabDownloads.Controls.Add(this.label11);
            this.tabDownloads.Controls.Add(this.label10);
            this.tabDownloads.Controls.Add(this.label9);
            this.tabDownloads.Controls.Add(this.label8);
            this.tabDownloads.Controls.Add(this.label7);
            this.tabDownloads.Controls.Add(this.lstUploads);
            this.tabDownloads.Controls.Add(this.label6);
            this.tabDownloads.Controls.Add(this.lstDownloads);
            this.tabDownloads.Controls.Add(this.label5);
            this.tabDownloads.Location = new System.Drawing.Point(4, 22);
            this.tabDownloads.Name = "tabDownloads";
            this.tabDownloads.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloads.Size = new System.Drawing.Size(979, 472);
            this.tabDownloads.TabIndex = 2;
            this.tabDownloads.Text = "Downloads";
            this.tabDownloads.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(736, 262);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Done";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(458, 262);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Filetype";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(298, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Size";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 262);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(458, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Filetype";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(736, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Done";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Size";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Name";
            // 
            // lstUploads
            // 
            this.lstUploads.FormattingEnabled = true;
            this.lstUploads.Location = new System.Drawing.Point(26, 278);
            this.lstUploads.Name = "lstUploads";
            this.lstUploads.Size = new System.Drawing.Size(927, 186);
            this.lstUploads.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Current Uploads:";
            // 
            // lstDownloads
            // 
            this.lstDownloads.FormattingEnabled = true;
            this.lstDownloads.Location = new System.Drawing.Point(26, 47);
            this.lstDownloads.Name = "lstDownloads";
            this.lstDownloads.Size = new System.Drawing.Size(927, 173);
            this.lstDownloads.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Current Downloads:";
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.userDirTreeView);
            this.tabUser.Controls.Add(this.cmbServer);
            this.tabUser.Controls.Add(this.label2);
            this.tabUser.Controls.Add(this.label4);
            this.tabUser.Controls.Add(this.lstUser);
            this.tabUser.Controls.Add(this.label3);
            this.tabUser.Location = new System.Drawing.Point(4, 22);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(979, 472);
            this.tabUser.TabIndex = 1;
            this.tabUser.Text = "Server";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // userDirTreeView
            // 
            this.userDirTreeView.ImageIndex = 0;
            this.userDirTreeView.ImageList = this.dirIconList;
            this.userDirTreeView.Location = new System.Drawing.Point(231, 84);
            this.userDirTreeView.Name = "userDirTreeView";
            this.userDirTreeView.SelectedImageIndex = 0;
            this.userDirTreeView.Size = new System.Drawing.Size(740, 367);
            this.userDirTreeView.TabIndex = 8;
            this.userDirTreeView.DoubleClick += new System.EventHandler(this.userDirTreeView_DoubleClick);
            // 
            // dirIconList
            // 
            this.dirIconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.dirIconList.ImageSize = new System.Drawing.Size(16, 16);
            this.dirIconList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(83, 12);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(888, 21);
            this.cmbServer.TabIndex = 7;
            this.cmbServer.SelectedIndexChanged += new System.EventHandler(this.cmbServer_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Server:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(227, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Files:";
            // 
            // lstUser
            // 
            this.lstUser.FormattingEnabled = true;
            this.lstUser.Location = new System.Drawing.Point(21, 83);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(201, 368);
            this.lstUser.TabIndex = 3;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.lstUser_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "User:";
            // 
            // tabDC
            // 
            this.tabDC.AccessibleName = "";
            this.tabDC.Controls.Add(this.tabServer);
            this.tabDC.Controls.Add(this.tabUser);
            this.tabDC.Controls.Add(this.tabDownloads);
            this.tabDC.Location = new System.Drawing.Point(1, 1);
            this.tabDC.Name = "tabDC";
            this.tabDC.SelectedIndex = 0;
            this.tabDC.Size = new System.Drawing.Size(987, 498);
            this.tabDC.TabIndex = 0;
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.btnDisconnect);
            this.tabServer.Controls.Add(this.btnConnect);
            this.tabServer.Controls.Add(this.lstSprServer);
            this.tabServer.Controls.Add(this.label1);
            this.tabServer.Location = new System.Drawing.Point(4, 22);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabServer.Size = new System.Drawing.Size(979, 472);
            this.tabServer.TabIndex = 0;
            this.tabServer.Text = "Home";
            this.tabServer.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(484, 430);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(476, 23);
            this.btnDisconnect.TabIndex = 4;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(30, 430);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(447, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lstSprServer
            // 
            this.lstSprServer.FormattingEnabled = true;
            this.lstSprServer.Location = new System.Drawing.Point(30, 42);
            this.lstSprServer.Name = "lstSprServer";
            this.lstSprServer.Size = new System.Drawing.Size(930, 381);
            this.lstSprServer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Super Server:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 499);
            this.Controls.Add(this.tabDC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabDownloads.ResumeLayout(false);
            this.tabDownloads.PerformLayout();
            this.tabUser.ResumeLayout(false);
            this.tabUser.PerformLayout();
            this.tabDC.ResumeLayout(false);
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabDownloads;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.TabControl tabDC;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstUploads;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstDownloads;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstSprServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TreeView userDirTreeView;
        private System.Windows.Forms.ImageList dirIconList;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

