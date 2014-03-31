namespace DcSharpProject
{
    partial class RegisterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxRegisterUserName = new System.Windows.Forms.TextBox();
            this.txtBoxRegisterUserPass = new System.Windows.Forms.TextBox();
            this.btnRegisterNewAcc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // txtBoxRegisterUserName
            // 
            this.txtBoxRegisterUserName.Location = new System.Drawing.Point(15, 38);
            this.txtBoxRegisterUserName.Name = "txtBoxRegisterUserName";
            this.txtBoxRegisterUserName.Size = new System.Drawing.Size(244, 20);
            this.txtBoxRegisterUserName.TabIndex = 2;
            // 
            // txtBoxRegisterUserPass
            // 
            this.txtBoxRegisterUserPass.Location = new System.Drawing.Point(12, 112);
            this.txtBoxRegisterUserPass.Name = "txtBoxRegisterUserPass";
            this.txtBoxRegisterUserPass.Size = new System.Drawing.Size(244, 20);
            this.txtBoxRegisterUserPass.TabIndex = 3;
            // 
            // btnRegisterNewAcc
            // 
            this.btnRegisterNewAcc.Location = new System.Drawing.Point(66, 166);
            this.btnRegisterNewAcc.Name = "btnRegisterNewAcc";
            this.btnRegisterNewAcc.Size = new System.Drawing.Size(143, 59);
            this.btnRegisterNewAcc.TabIndex = 4;
            this.btnRegisterNewAcc.Text = "Register";
            this.btnRegisterNewAcc.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnRegisterNewAcc);
            this.Controls.Add(this.txtBoxRegisterUserPass);
            this.Controls.Add(this.txtBoxRegisterUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "Register new Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxRegisterUserName;
        private System.Windows.Forms.TextBox txtBoxRegisterUserPass;
        private System.Windows.Forms.Button btnRegisterNewAcc;
    }
}