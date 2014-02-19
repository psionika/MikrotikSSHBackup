using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.IO;

using System.Globalization;
using Renci.SshNet;

namespace MikrotikSSHBackup
{
    public partial class Form_Main : Form
    {
        Props props = new Props();

        #region FormAction
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveDataSet();
            writeSetting();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readSetting();

            loadDataSet();
                    
            string[] arguments = Environment.GetCommandLineArgs();
            
            if (arguments.Length > 1)
            {
                string args = arguments[1];
                if (args == "Backup")
                {
                    StartBackup();
                    readSetting();
                    SendEmailReport();
                    Application.Exit();
                }
            }            
        }
        #endregion

        private void btn_StartBackup_Click(object sender, EventArgs e)
        {
            try
            {
                Form_ProgressBar Progress = new Form_ProgressBar();
                backgroundWorker1.RunWorkerAsync();
                Progress.ShowDialog();
            }
            catch
            { }
        }

        private void StartBackup()
        {            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    try
                    {
                        Directory.CreateDirectory(GetFolderName(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()));

                        string filename = GetFolderName(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()) + 
                            row.Cells[0].Value.ToString() + ", IP " + 
                            row.Cells[1].Value.ToString() + " " +
                            DateTime.Now.ToString(CultureInfo.InvariantCulture)
                             .Replace(@"/", "-")
                             .Replace(":", "-")+".txt";
                                                
                        saveAsOwnTextFormat(
                            filename,
                            MikrotikExportCompact(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString())
                            );

                        row.Cells[5].Value = "OK";

                        foreach (DataGridViewCell cell in row.Cells)
                        {                            
                            cell.Style.BackColor = Color.LightGreen;
                            cell.Style.ForeColor = Color.Black;
                        }
                    }
                    catch
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {                            
                            cell.Style.BackColor = Color.LightPink;
                            cell.Style.ForeColor = Color.Black;
                        }

                        row.Cells[5].Value = "Error";
                    }
                }
            }
        }

        #region Datagrid Action

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) editMikrotik();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridView1.Columns["LastBackup"].Index) return;

            string text = GetLastFileDirectory(
                    GetFolderName(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString()), dataGridView1.CurrentRow.Cells[0].Value.ToString());

            if (text != "")
            {
                text = System.IO.File.ReadAllText(text);
                
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
            if (tb != null)
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 4)
                {
                    tb.PasswordChar = '*';
                }
                else
                {
                    tb.PasswordChar = (char)0;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value != null && e.Value.ToString().Length > 0)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }
        #endregion

        #region SaveLoadDataSet
        private void saveDataSet()
        {
            dataSet1.WriteXml("data.xml", XmlWriteMode.IgnoreSchema);
        }

        private void loadDataSet()
        {
            dataSet1.Clear();

            if (File.Exists("data.xml") == true)
            {
                dataSet1.ReadXml("data.xml");
                dataGridView1.DataSource = this.mikrotikListBindingSource;
            }
        }
        #endregion
        
        #region GetMikrotikExportCompactOverSSH
        private string MikrotikExportCompact(string MikrotikIP, string MikrotikUser, string MikrotikPassword)
        {
            ConnectionInfo sLogin = new PasswordConnectionInfo(MikrotikIP, MikrotikUser, MikrotikPassword);
            SshClient sClient = new SshClient(sLogin);
            sClient.Connect();

            SshCommand appStatCmd = sClient.CreateCommand("export compact");
            appStatCmd.Execute();                

            sClient.Disconnect();
            sClient.Dispose();

            return appStatCmd.Result;
        }
        #endregion

        #region File Action
        private string GetFolderName(string name, string ip)
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("MikrotikSSHBackup.exe", "") +
                                "Backup" + "\\" +
                                name + " " +
                                ip + "\\";                                
        }

        private string GetLastFileDirectory(string folderName, string MikrotikName)
        {
            try
            {
                var directory = new DirectoryInfo(folderName);
                var myFile = (from f in directory.GetFiles(MikrotikName + "*")
                              orderby f.LastWriteTime descending
                              select f).First();

                

                return folderName + myFile.ToString();
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
                StreamWriter sw = File.CreateText(filename);             
                    sw.WriteLine(textToSave);                
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
            Form_AddEdit fae = new Form_AddEdit("", "", "", "");
            fae.ShowDialog();

            if (fae.DialogResult == DialogResult.OK)
            {
                dataSet1.Tables["MikrotikList"].Rows.Add(fae.tb_Name.Text, fae.tb_IP.Text, fae.tb_Login.Text, fae.tb_Password.Text);
            }

            saveDataSet();
        }

        private void tsb_Edit_Click(object sender, EventArgs e)
        {
            editMikrotik();
        }

        private void editMikrotik()
        {
            if (dataGridView1.CurrentRow != null)
            {
                string name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string ip = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string login = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string password = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                Form_AddEdit fae = new Form_AddEdit(name, ip, login, password);
                fae.ShowDialog();

                if (fae.DialogResult == DialogResult.OK)
                {
                    DataRow mikrotikRow = ((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row;

                    mikrotikRow["Name"] = fae.tb_Name.Text;
                    mikrotikRow["IP"] = fae.tb_IP.Text;
                    mikrotikRow["Login"] = fae.tb_Login.Text;
                    mikrotikRow["Password"] = fae.tb_Password.Text;
                }
            }

            saveDataSet();
        }

        private void tsb_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var result = MessageBox.Show("Are you sure you want to remove the current item?",
                    "Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    mikrotikListBindingSource.RemoveCurrent();
                    saveDataSet();
                }
            }
        }

        private void tsb_About_Click(object sender, EventArgs e)
        {
            Form_About about = new Form_About();
            about.ShowDialog();
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
            if (EmailStatic.EnableEmail == true)
            {
                int i = 0;
                string Report = "WARNING!!! A backup copy of the following elements has not been created" + Environment.NewLine;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[5].Value.ToString() == "Error")
                        {
                            i++;
                            Report += "Name: " + row.Cells[0].Value.ToString() + " IP: " + row.Cells[1].Value.ToString() + Environment.NewLine;
                        }
                    }
                }

                if (i > 0)
                {
                    SendEmailReport ser = new SendEmailReport();
                    ser.SendEmail(Report);
                }
            }
        }

        #endregion

        #region Settings
        private void readSetting()
        {
            props.ReadXml();

            EmailStatic.EnableEmail = props.Fields.EnableEmail;
            EmailStatic.EmailServer = props.Fields.EmailServer;
            EmailStatic.EmailPort = props.Fields.EmailPort;
            EmailStatic.EnableEmailSSL = props.Fields.EnableEmailSSL;
            EmailStatic.EmailUser = props.Fields.EmailUser;
            EmailStatic.EmailPassowrd = props.Fields.EmailPassowrd;
            EmailStatic.EmailAddress = props.Fields.EmailAddress;
        }

        private void writeSetting()
        {
            props.Fields.EnableEmail    = EmailStatic.EnableEmail;
            props.Fields.EmailServer    = EmailStatic.EmailServer;
            props.Fields.EmailPort      = EmailStatic.EmailPort;
            props.Fields.EnableEmailSSL = EmailStatic.EnableEmailSSL;
            props.Fields.EmailUser      = EmailStatic.EmailUser;
            props.Fields.EmailPassowrd  = EmailStatic.EmailPassowrd;
            props.Fields.EmailAddress   = EmailStatic.EmailAddress; 

            props.WriteXml();
        }

        #endregion

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            StartBackup();
            SendEmailReport();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {            
            Form_ProgressBar.ActiveForm.Close();
        }

    }
}
