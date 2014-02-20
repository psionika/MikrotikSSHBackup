namespace MikrotikSSHBackup
{
    partial class Form_Email
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txb_Email = new System.Windows.Forms.TextBox();
            this.txb_User = new System.Windows.Forms.TextBox();
            this.txb_Port = new System.Windows.Forms.TextBox();
            this.chb_SendEmail = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SendTestEmail = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_Server = new System.Windows.Forms.TextBox();
            this.txb_Password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chb_EnSSL = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.88435F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.11565F));
            this.tableLayoutPanel1.Controls.Add(this.txb_Email, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txb_User, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txb_Port, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chb_SendEmail, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_SendTestEmail, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btn_OK, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btn_Cancel, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txb_Server, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txb_Password, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chb_EnSSL, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(294, 315);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txb_Email
            // 
            this.txb_Email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_Email.Location = new System.Drawing.Point(3, 217);
            this.txb_Email.Name = "txb_Email";
            this.txb_Email.Size = new System.Drawing.Size(172, 20);
            this.txb_Email.TabIndex = 7;
            // 
            // txb_User
            // 
            this.txb_User.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_User.Location = new System.Drawing.Point(3, 147);
            this.txb_User.Name = "txb_User";
            this.txb_User.Size = new System.Drawing.Size(172, 20);
            this.txb_User.TabIndex = 5;
            // 
            // txb_Port
            // 
            this.txb_Port.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_Port.Location = new System.Drawing.Point(3, 77);
            this.txb_Port.Name = "txb_Port";
            this.txb_Port.Size = new System.Drawing.Size(172, 20);
            this.txb_Port.TabIndex = 3;
            this.txb_Port.Text = "25";
            // 
            // chb_SendEmail
            // 
            this.chb_SendEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chb_SendEmail.AutoSize = true;
            this.chb_SendEmail.Location = new System.Drawing.Point(81, 10);
            this.chb_SendEmail.Name = "chb_SendEmail";
            this.chb_SendEmail.Size = new System.Drawing.Size(15, 14);
            this.chb_SendEmail.TabIndex = 1;
            this.chb_SendEmail.UseVisualStyleBackColor = true;
            this.chb_SendEmail.CheckedChanged += new System.EventHandler(this.chb_SendEmail_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Send email when an error?";
            // 
            // btn_SendTestEmail
            // 
            this.btn_SendTestEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btn_SendTestEmail, 2);
            this.btn_SendTestEmail.Location = new System.Drawing.Point(79, 251);
            this.btn_SendTestEmail.Name = "btn_SendTestEmail";
            this.btn_SendTestEmail.Size = new System.Drawing.Size(135, 23);
            this.btn_SendTestEmail.TabIndex = 8;
            this.btn_SendTestEmail.Text = "Send test message";
            this.btn_SendTestEmail.UseVisualStyleBackColor = true;
            this.btn_SendTestEmail.Click += new System.EventHandler(this.btn_SendTestEmail_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(51, 286);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(198, 286);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Port";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Email to report";
            // 
            // txb_Server
            // 
            this.txb_Server.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_Server.Location = new System.Drawing.Point(3, 42);
            this.txb_Server.Name = "txb_Server";
            this.txb_Server.Size = new System.Drawing.Size(172, 20);
            this.txb_Server.TabIndex = 2;
            // 
            // txb_Password
            // 
            this.txb_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_Password.Location = new System.Drawing.Point(3, 182);
            this.txb_Password.Name = "txb_Password";
            this.txb_Password.Size = new System.Drawing.Size(172, 20);
            this.txb_Password.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "User";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Enable SSL?";
            // 
            // chb_EnSSL
            // 
            this.chb_EnSSL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chb_EnSSL.AutoSize = true;
            this.chb_EnSSL.Location = new System.Drawing.Point(81, 115);
            this.chb_EnSSL.Name = "chb_EnSSL";
            this.chb_EnSSL.Size = new System.Drawing.Size(15, 14);
            this.chb_EnSSL.TabIndex = 4;
            this.chb_EnSSL.UseVisualStyleBackColor = true;
            // 
            // Form_Email
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(294, 315);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Email";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Email Settings";
            this.Load += new System.EventHandler(this.Form_Email_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txb_Email;
        private System.Windows.Forms.TextBox txb_User;
        private System.Windows.Forms.TextBox txb_Port;
        private System.Windows.Forms.CheckBox chb_SendEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SendTestEmail;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_Server;
        private System.Windows.Forms.TextBox txb_Password;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chb_EnSSL;
    }
}