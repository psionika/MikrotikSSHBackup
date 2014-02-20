using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;

using System.Diagnostics;
using System.Security.Cryptography;
using System.Globalization;
using Renci.SshNet;

namespace MikrotikSSHBackup
{
    public partial class Form_Main : Form
    {
        #region FormAction
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveDataSet();

            Settings.EncryptPassword = "";
            SettingAction.WriteXml();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var arguments = Environment.GetCommandLineArgs();

            SettingAction.ReadXml();
                        
            if (arguments.Length > 1 && arguments[1] == "Backup")
            {
                if (!File.Exists("data.xml")) Environment.Exit(0);
                
                if (arguments.Length == 2 && !Settings.EncryptEnable)
                {            
                    loadDataSet();
                    dataGridView1.DataSource = mikrotikListBindingSource;
            
                    StartBackup();
                    SendEmailReport();
                    Environment.Exit(0);
                }
                else if (arguments.Length == 3 && !String.IsNullOrEmpty(arguments[2]) && Settings.EncryptEnable)
                {                    
                    if (LoadCryptDataSet("data.xml", arguments[2], dataSet1))
                    {
                        dataGridView1.DataSource = mikrotikListBindingSource;

                        EmailStatic.EmailServer = dataSet1.Tables["Email"].Rows[0]["Server"].ToString();
                        EmailStatic.EmailPort = dataSet1.Tables["Email"].Rows[0]["Port"].ToString();
                        EmailStatic.EnableEmailSSL = Convert.ToBoolean(dataSet1.Tables["Email"].Rows[0]["EnableSSL"]);
                        EmailStatic.EmailUser = dataSet1.Tables["Email"].Rows[0]["User"].ToString();
                        EmailStatic.EmailPassword = dataSet1.Tables["Email"].Rows[0]["Password"].ToString();
                        EmailStatic.EmailAddress = dataSet1.Tables["Email"].Rows[0]["Address"].ToString();

                        StartBackup();
                        SendEmailReport();
                    }
                    Environment.Exit(0);
                }
                else if (arguments.Length == 2 && Settings.EncryptEnable)
                {
                    MessageBox.Show("\nData file encrypted!!! Run: \"MikrotikSSHBackup.exe Backup Password\"\n");
                    Environment.Exit(0);
                }
            }
            else if (arguments.Length > 1 && arguments[1] != "Backup")
            {
                MessageBox.Show("\nError parameters. Run: \"MikrotikSSHBackup,exe Backup Password\"\n");
                Environment.Exit(0);
            }
            else
            {
                toolStripProgressBar1.MarqueeAnimationSpeed = 0;

                loadDataSet();
            }
        }
        #endregion

        #region Tool Strip Button Action
        private void tsb_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsb_Add_Click(object sender, EventArgs e)
        {
            addMikrotik("", "", "22", "admin", "");
        }

        private void tsb_Edit_Click(object sender, EventArgs e)
        {
            editMikrotik();
        }

        private void tsb_Delete_Click(object sender, EventArgs e)
        {
            deleteMikrotik();
        }

        private void tsb_About_Click(object sender, EventArgs e)
        {
            Form_About about = new Form_About();
            about.ShowDialog();
        }
        #endregion

        #region Context menu
        private void cmAdd_Click(object sender, EventArgs e)
        {
            addMikrotik("", "", "22", "admin", "");
        }

        private void cmEdit_Click(object sender, EventArgs e)
        {
            editMikrotik();
        }

        private void cmDelete_Click(object sender, EventArgs e)
        {
            deleteMikrotik();
        }

        private void cmCopy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var name = dataGridView1.CurrentRow.Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
            var ip = dataGridView1.CurrentRow.Cells["iPDataGridViewTextBoxColumn"].Value.ToString();
            var sshport = dataGridView1.CurrentRow.Cells["sSHPortDataGridViewTextBoxColumn"].Value.ToString();
            var login = dataGridView1.CurrentRow.Cells["loginDataGridViewTextBoxColumn"].Value.ToString();
            var password = dataGridView1.CurrentRow.Cells["passwordDataGridViewTextBoxColumn"].Value.ToString();

            addMikrotik(name, ip, sshport, login, password);
        }

        private void cmConnectOverWinbox_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var ip = dataGridView1.CurrentRow.Cells["iPDataGridViewTextBoxColumn"].Value.ToString();
            var login = dataGridView1.CurrentRow.Cells["loginDataGridViewTextBoxColumn"].Value.ToString();
            var password = dataGridView1.CurrentRow.Cells["passwordDataGridViewTextBoxColumn"].Value.ToString();

            ExecuteProgram(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("MikrotikSSHBackup.exe", "winbox.exe"),
                ip + " " + login + " " + password);
        }
        #endregion

        #region Datagrid Action

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

            if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var pt = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
            pt.X += e.Location.X;
            pt.Y += e.Location.Y;

            contextMenuStrip1.Show(dataGridView1, pt);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) editMikrotik();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridViewColumn = dataGridView1.Columns["LastBackup"];
            if (dataGridViewColumn != null && (e.RowIndex < 0 || e.ColumnIndex !=
                                                                dataGridViewColumn.Index)) return;

            if (dataGridView1.CurrentRow == null) return;

            var text = GetLastFileDirectory(
                GetFolderName(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString()), dataGridView1.CurrentRow.Cells[0].Value.ToString());

            if (text != "")
            {
                text = File.ReadAllText(text);

                Form_LastBackup lb = new Form_LastBackup(text);
                lb.ShowDialog();
            }
            else
            {
                Form_LastBackup lb = new Form_LastBackup("Not found backup copy");
                lb.ShowDialog();
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            if (tb == null) return;
            if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                tb.PasswordChar = '*';
            }
            else
            {
                tb.PasswordChar = (char)0;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 4) return;

            if (e.Value != null && e.Value.ToString().Length > 0)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }

        #endregion

        #region Backup
        private void btn_StartBackup_Click(object sender, EventArgs e)
        {
            toolStrip1.Enabled = false;
            btn_StartBackup.Enabled = false;
            dataGridView1.Enabled = false;

            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.MarqueeAnimationSpeed = 100;

            foreach (var row in dataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[0].Value != null))
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }

                row.Cells[5].Value = "";
            }

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            StartBackup();
            SendEmailReport();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.MarqueeAnimationSpeed = 0;
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;

            toolStrip1.Enabled = true;
            btn_StartBackup.Enabled = true;
            dataGridView1.Enabled = true;
        }

        private void StartBackup()
        {
            foreach (var row in dataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[0].Value != null))
            {
                try
                {
                    Directory.CreateDirectory(GetFolderName(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()));

                    var filename = GetFolderName(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()) + 
                                      row.Cells[0].Value + ", IP " + 
                                      row.Cells[1].Value + " " +
                                      DateTime.Now.ToString(CultureInfo.InvariantCulture)
                                          .Replace(@"/", "-")
                                          .Replace(":", "-")+".txt";

                    saveAsOwnTextFormat(
                        filename,
                        MikrotikExportCompact(row.Cells["iPDataGridViewTextBoxColumn"].Value.ToString(),
                            Convert.ToInt32(row.Cells["sSHPortDataGridViewTextBoxColumn"].Value),
                            row.Cells["loginDataGridViewTextBoxColumn"].Value.ToString(),
                            row.Cells["passwordDataGridViewTextBoxColumn"].Value.ToString()));

                    foreach (DataGridViewCell cell in row.Cells)
                    {                            
                        cell.Style.BackColor = Color.LightGreen;
                    }

                    row.Cells[5].Value = "OK";
                }
                catch
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {                            
                        cell.Style.BackColor = Color.LightPink;
                    }

                    row.Cells[5].Value = "Error";
                }
            }
        }

        #region GetMikrotikExportCompactOverSSH
        private string MikrotikExportCompact(string MikrotikIP, int MikrotikSSHPort, string MikrotikUser, string MikrotikPassword)
        {
            ConnectionInfo sLogin = new PasswordConnectionInfo(MikrotikIP, MikrotikSSHPort, MikrotikUser, MikrotikPassword);
            SshClient sClient = new SshClient(sLogin);
            sClient.Connect();

            SshCommand appStatCmd = sClient.CreateCommand("export compact");
            appStatCmd.Execute();

            sClient.Disconnect();
            sClient.Dispose();

            return appStatCmd.Result;
        }
        #endregion
        #endregion

        #region SaveLoadDataSet
        private void saveDataSet()
        {
            if (EmailStatic.EmailAddress != null)
            {
                dataSet1.Tables["Email"].Rows[0]["Server"] = EmailStatic.EmailServer;
                dataSet1.Tables["Email"].Rows[0]["Port"] = EmailStatic.EmailPort;
                dataSet1.Tables["Email"].Rows[0]["EnableSSL"] = EmailStatic.EnableEmailSSL;
                dataSet1.Tables["Email"].Rows[0]["User"] = EmailStatic.EmailUser;
                dataSet1.Tables["Email"].Rows[0]["Password"] = EmailStatic.EmailPassword;
                dataSet1.Tables["Email"].Rows[0]["Address"] = EmailStatic.EmailAddress;
            }

            switch (Settings.EncryptEnable)
            {
                case false:
                    dataSet1.WriteXml("data.xml", XmlWriteMode.IgnoreSchema);
                    break;
                default:
                    SaveCryptDataSet("data.xml", dataSet1, Settings.EncryptPassword);
                    break;
            }
        }

        private void loadDataSet()
        {   
            if (!File.Exists("data.xml")) return;

            dataSet1.Clear();
            if (Settings.EncryptEnable == false && String.IsNullOrEmpty(Settings.EncryptPassword))
            {
                dataSet1.ReadXml("data.xml");

                dataGridView1.DataSource = mikrotikListBindingSource;
            }
            else if (Settings.EncryptEnable == true && String.IsNullOrEmpty(Settings.EncryptPassword))
            {
                do
                {
                    PasswordRequest();
                } while (!LoadCryptDataSet("data.xml", Settings.EncryptPassword, dataSet1));

                dataGridView1.DataSource = mikrotikListBindingSource;
            }
            else
            {
                LoadCryptDataSet("data.xml", Settings.EncryptPassword, dataSet1);
            }

            if (dataSet1.Tables["Email"].Rows.Count < 1) dataSet1.Tables["Email"].Rows.Add("Server", "Port", false, "User", "Password", "adress");

            EmailStatic.EmailServer = dataSet1.Tables["Email"].Rows[0]["Server"].ToString();
            EmailStatic.EmailPort = dataSet1.Tables["Email"].Rows[0]["Port"].ToString();
            EmailStatic.EnableEmailSSL = Convert.ToBoolean(dataSet1.Tables["Email"].Rows[0]["EnableSSL"]);
            EmailStatic.EmailUser = dataSet1.Tables["Email"].Rows[0]["User"].ToString();
            EmailStatic.EmailPassword = dataSet1.Tables["Email"].Rows[0]["Password"].ToString();
            EmailStatic.EmailAddress = dataSet1.Tables["Email"].Rows[0]["Address"].ToString();
            
        }
        #endregion

        #region File Action
        private static string GetFolderName(string name, string ip)
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("MikrotikSSHBackup.exe", "") +
                                "Backup" + "\\" +
                                name + " " +
                                ip + "\\";                                
        }

        private static string GetLastFileDirectory(string folderName, string MikrotikName)
        {
            try
            {
                var directory = new DirectoryInfo(folderName);
                var myFile = (from f in directory.GetFiles(MikrotikName + "*")
                              orderby f.LastWriteTime descending
                              select f).First();

                

                return folderName + myFile;
            }
            catch
            {
                return "";
            }
        }

        private void saveAsOwnTextFormat(string filename, string textToSave)
        {
            try
            {                
                var sw = File.CreateText(filename);             
                    sw.WriteLine(textToSave);                
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        #endregion

        #region Add, Edit, Delete
        private void addMikrotik(string name, string ip, string sshport, string username, string password)
        {
            Form_AddEdit fae = new Form_AddEdit(name, ip, sshport, username, password);
            fae.ShowDialog();

            if (fae.DialogResult != DialogResult.OK) return;

            dataSet1.Tables["MikrotikList"].Rows.Add(fae.tb_Name.Text, fae.tb_IP.Text, fae.tb_Login.Text, fae.tb_Password.Text, Convert.ToInt32(fae.tbSSHPort.Text));
            saveDataSet();
        }

        private void editMikrotik()
        {
            if (dataGridView1.CurrentRow == null) return;

            var name = dataGridView1.CurrentRow.Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
            var ip = dataGridView1.CurrentRow.Cells["iPDataGridViewTextBoxColumn"].Value.ToString();
            var sshport = dataGridView1.CurrentRow.Cells["sSHPortDataGridViewTextBoxColumn"].Value.ToString();
            var login = dataGridView1.CurrentRow.Cells["loginDataGridViewTextBoxColumn"].Value.ToString();
            var password = dataGridView1.CurrentRow.Cells["passwordDataGridViewTextBoxColumn"].Value.ToString();

            Form_AddEdit fae = new Form_AddEdit(name, ip, sshport, login, password);
            fae.ShowDialog();

            if (fae.DialogResult != DialogResult.OK) return;

            var mikrotikRow = ((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row;

            mikrotikRow["Name"] = fae.tb_Name.Text;
            mikrotikRow["IP"] = fae.tb_IP.Text;
            mikrotikRow["SSHPort"] = fae.tbSSHPort.Text;
            mikrotikRow["Login"] = fae.tb_Login.Text;
            mikrotikRow["Password"] = fae.tb_Password.Text;

            saveDataSet();
        }

        private void deleteMikrotik()
        {
            if (dataGridView1.CurrentRow == null) return;

            var result = MessageBox.Show("Are you sure you want to remove the current item?",
                "Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            mikrotikListBindingSource.RemoveCurrent();
            saveDataSet();
        }
        #endregion

        #region Email
        private void tsb_Email_Click(object sender, EventArgs e)
        {
            Form_Email formEmail = new Form_Email();
            formEmail.ShowDialog();
        }

        private void SendEmailReport()
        {
            if (!Settings.EnableEmail) return;

            var i = 0;
            var Report = "WARNING!!! A backup copy of the following elements has not been created" + Environment.NewLine;

            foreach (var row in from DataGridViewRow row in dataGridView1.Rows where row.Cells[0].Value != null where row.Cells[5].Value.ToString() == "Error" select row)
            {
                i++;
                Report += "Name: " + row.Cells[0].Value + " IP: " + row.Cells[1].Value + Environment.NewLine;
            }

            if (i <= 0) return;

            SendEmailReport ser = new SendEmailReport();
            ser.SendEmail(Report, EmailStatic.EmailServer, EmailStatic.EmailPort, EmailStatic.EmailUser, EmailStatic.EmailPassword, EmailStatic.EnableEmailSSL, EmailStatic.EmailAddress);

        }

        #endregion

        #region Start winbox
        public static void ExecuteProgram(string fileName, string arguments)
        {
            if (!File.Exists(fileName))
            {
                MessageBox.Show("Winbox.exe not found in the program directory!");
                return;
            }

            Process prc = null;

            try
            {
                prc = new Process {StartInfo = {FileName = fileName, Arguments = arguments}};

                prc.Start();
            }
            finally
            {
                if (prc != null) prc.Close();
            }
        }
        #endregion

        #region Password

        private void tsbEncrypt_Click(object sender, EventArgs e)
        {
            Form_Encryption formEncryption = new Form_Encryption();
            formEncryption.ShowDialog();

            SettingAction.WriteXml();
        }

        private static void PasswordRequest()
        {
            Form_RequestPassword formRP = new Form_RequestPassword();
            formRP.ShowDialog();
        }

        private static bool LoadCryptDataSet(string file, string key, DataSet ds)
        {
            var crypto = Rijndael.Create();

            crypto.IV = Encoding.ASCII.GetBytes("qwert".PadRight(16, 'x'));
            crypto.Key = Encoding.ASCII.GetBytes(key.PadRight(16, 'x'));
            crypto.Padding = PaddingMode.Zeros;

            using (FileStream stream = new FileStream(file, FileMode.Open))
            {
                using (
                    CryptoStream cryptoStream = new CryptoStream(stream, crypto.CreateDecryptor(), CryptoStreamMode.Read)
                    )
                {
                    try
                    {
                        ds.ReadXml(cryptoStream);
                    }
                    catch
                    {
                        MessageBox.Show("Password not correct!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    cryptoStream.Close();
                    stream.Close();
                }
            }
            return true;
        }

        private static void SaveCryptDataSet(string file, DataSet ds, string key)
        {
            var crypto = Rijndael.Create();

            crypto.IV = Encoding.ASCII.GetBytes("qwert".PadRight(16, 'x'));
            crypto.Key = Encoding.ASCII.GetBytes(key.PadRight(16, 'x'));
            crypto.Padding = PaddingMode.Zeros;

            File.Delete(file);

            using (FileStream stream = new FileStream(file, FileMode.OpenOrCreate))
            {
                using (
                    CryptoStream cryptoStream = new CryptoStream(stream, crypto.CreateEncryptor(),
                        CryptoStreamMode.Write))
                {
                    ds.WriteXml(cryptoStream);
                    cryptoStream.Flush();
                    stream.Flush();
                    cryptoStream.Close();
                    stream.Close();
                }
            }
        }

        #endregion

    }
}
