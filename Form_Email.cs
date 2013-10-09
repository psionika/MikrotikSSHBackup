using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MikrotikSSHBackup
{
    public partial class Form_Email : Form
    {
        public Form_Email()
        {
            InitializeComponent();
        }

        private void Form_Email_Load(object sender, EventArgs e)
        {
            chb_SendEmail.Checked = EmailStatic.EnableEmail;
            txb_Server.Text = EmailStatic.EmailServer;
            txb_Port.Text = EmailStatic.EmailPort;
            chb_EnSSL.Checked = EmailStatic.EnableEmailSSL;
            txb_User.Text = EmailStatic.EmailUser;
            txb_Password.Text = EmailStatic.EmailPassowrd;
            txb_Email.Text = EmailStatic.EmailAddress;

            chb_SendEmail_CheckedState();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            EmailStatic.EnableEmail = chb_SendEmail.Checked;
            EmailStatic.EmailServer = txb_Server.Text;
            EmailStatic.EmailPort = txb_Port.Text;
            EmailStatic.EnableEmailSSL = chb_EnSSL.Checked;
            EmailStatic.EmailUser = txb_User.Text;
            EmailStatic.EmailPassowrd = txb_Password.Text;
            EmailStatic.EmailAddress = txb_Email.Text; 
        }

        private void chb_SendEmail_CheckedChanged(object sender, EventArgs e)
        {
            chb_SendEmail_CheckedState();
        }

        private void chb_SendEmail_CheckedState()
        {
            txb_Server.Enabled = chb_SendEmail.Checked;
            txb_Port.Enabled = chb_SendEmail.Checked;
            chb_EnSSL.Enabled = chb_SendEmail.Checked;
            txb_User.Enabled = chb_SendEmail.Checked;
            txb_Password.Enabled = chb_SendEmail.Checked;
            txb_Email.Enabled = chb_SendEmail.Checked;

            btn_SendTestEmail.Enabled = chb_SendEmail.Checked;
        }

        private void btn_SendTestEmail_Click(object sender, EventArgs e)
        {
            SendEmailReport ser = new SendEmailReport();
            ser.SendEmail("Test message");
        }
    }
}
