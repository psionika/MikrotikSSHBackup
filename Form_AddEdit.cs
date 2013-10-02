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
    public partial class Form_AddEdit : Form
    {
        public Form_AddEdit(string name, string ip, string login, string password)
        {
            InitializeComponent();

            tb_Name.Text     = name;
            tb_IP.Text       = ip;
            tb_Login.Text    = login;
            tb_Password.Text = password;
        }
    }
}
