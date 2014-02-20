using System;
using System.Windows.Forms;

namespace MikrotikSSHBackup
{
    public partial class Form_RequestPassword : Form
    {
        public Form_RequestPassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Settings.EncryptPassword = maskedTextBox1.Text;
            Close();
        }
    }
}
