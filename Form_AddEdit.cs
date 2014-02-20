using System.Windows.Forms;

namespace MikrotikSSHBackup
{
    public partial class Form_AddEdit : Form
    {
        public Form_AddEdit(string name, string ip, string sshport, string login, string password)
        {
            InitializeComponent();

            tb_Name.Text     = name;
            tb_IP.Text       = ip;
            tbSSHPort.Text   = sshport;
            tb_Login.Text    = login;
            tb_Password.Text = password;
        }
    }
}
