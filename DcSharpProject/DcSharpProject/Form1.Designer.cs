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
            this.tabDownloads = new System.Windows.Forms.TabPage();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.tabDC = new System.Windows.Forms.TabControl();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstDownloads = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSprServer = new System.Windows.Forms.ListBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstUploads = new System.Windows.Forms.ListBox();
            this.tabDownloads.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tabDC.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDownloads
            // 
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
            // tabUser
            // 
            this.tabUser.Controls.Add(this.cmbServer);
            this.tabUser.Controls.Add(this.label2);
            this.tabUser.Controls.Add(this.lstFiles);
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
            // lstUser
            // 
            this.lstUser.FormattingEnabled = true;
            this.lstUser.Location = new System.Drawing.Point(21, 83);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(201, 368);
            this.lstUser.TabIndex = 3;
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
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(231, 83);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(740, 368);
            this.lstFiles.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Downloads:";
            // 
            // lstDownloads
            // 
            this.lstDownloads.FormattingEnabled = true;
            this.lstDownloads.Location = new System.Drawing.Point(26, 47);
            this.lstDownloads.Name = "lstDownloads";
            this.lstDownloads.Size = new System.Drawing.Size(927, 173);
            this.lstDownloads.TabIndex = 4;
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
            // lstSprServer
            // 
            this.lstSprServer.FormattingEnabled = true;
            this.lstSprServer.Location = new System.Drawing.Point(30, 42);
            this.lstSprServer.Name = "lstSprServer";
            this.lstSprServer.Size = new System.Drawing.Size(930, 381);
            this.lstSprServer.TabIndex = 2;
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(83, 12);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(888, 21);
            this.cmbServer.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Uploads:";
            // 
            // lstUploads
            // 
            this.lstUploads.FormattingEnabled = true;
            this.lstUploads.Location = new System.Drawing.Point(26, 250);
            this.lstUploads.Name = "lstUploads";
            this.lstUploads.Size = new System.Drawing.Size(927, 186);
            this.lstUploads.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 499);
            this.Controls.Add(this.tabDC);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstSprServer;
    }
}

