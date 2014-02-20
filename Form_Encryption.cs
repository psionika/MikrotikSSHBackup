using System;
using System.Windows.Forms;

namespace MikrotikSSHBackup
{
    public partial class Form_Encryption : Form
    {
        public Form_Encryption()
        {
            InitializeComponent();
        }

        private void Form_Encryption_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Settings.EncryptEnable;
            if (Settings.EncryptPassword != null)
            {
                maskedTextBox1.Text = Settings.EncryptPassword;
                maskedTextBox2.Text = Settings.EncryptPassword;
            }
            EnabledComponents();
        }

        private void EnabledComponents()
        {
            switch (checkBox1.Checked)
            {
                case true:
                    maskedTextBox1.Enabled = true;
                    maskedTextBox2.Enabled = true;
                    break;
                case false:
                    maskedTextBox1.Enabled = false;
                    maskedTextBox2.Enabled = false;
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            EnabledComponents();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked
                && maskedTextBox1.Text == maskedTextBox2.Text
                && maskedTextBox1.Text != "")
            {
                Settings.EncryptEnable = checkBox1.Checked;
                Settings.EncryptPassword = maskedTextBox1.Text;

                Close();
            }
            else if (checkBox1.Checked && maskedTextBox1.Text != maskedTextBox2.Text)
            {
                MessageBox.Show("The passwords are not the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkBox1.Checked && maskedTextBox1.Text == "")
            {
                MessageBox.Show("Password can not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (checkBox1.Checked) return;
            Settings.EncryptEnable = false;
            Settings.EncryptPassword = "";
            Close();
        }
    }
}
