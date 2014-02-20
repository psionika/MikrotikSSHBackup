using System;
using System.Windows.Forms;

namespace MikrotikSSHBackup
{
    public partial class Form_LastBackup : Form
    {
        public Form_LastBackup(string MikrotikBackup)
        {
            InitializeComponent();

            scintilla1.Lexing.Lexer = ScintillaNET.Lexer.Cpp;

            scintilla1.Lexing.Keywords[0] = "ip system interface if else while for end switch case return break continue func";
            scintilla1.Lexing.Keywords[1] = "add set disabled name";

            scintilla1.Lexing.LineCommentPrefix = "#";

            scintilla1.Styles[scintilla1.Lexing.StyleNameMap["DOCUMENT_DEFAULT"]].ForeColor = System.Drawing.Color.Black;
            scintilla1.Styles[scintilla1.Lexing.StyleNameMap["NUMBER"]].ForeColor = System.Drawing.Color.SteelBlue;
            scintilla1.Styles[scintilla1.Lexing.StyleNameMap["WORD"]].ForeColor = System.Drawing.Color.Blue;
            scintilla1.Styles[scintilla1.Lexing.StyleNameMap["WORD2"]].ForeColor = System.Drawing.Color.Red;
            scintilla1.Styles[scintilla1.Lexing.StyleNameMap["STRING"]].ForeColor = System.Drawing.Color.Red;
            scintilla1.Styles[scintilla1.Lexing.StyleNameMap["CHARACTER"]].ForeColor = System.Drawing.Color.Red;
            scintilla1.Styles[scintilla1.Lexing.StyleNameMap["PREPROCESSOR"]].ForeColor = System.Drawing.Color.Brown;
            scintilla1.Styles[scintilla1.Lexing.StyleNameMap["OPERATOR"]].ForeColor = System.Drawing.Color.Black;
            scintilla1.Styles[scintilla1.Lexing.StyleNameMap["IDENTIFIER"]].ForeColor = System.Drawing.Color.Black;
            scintilla1.Styles[scintilla1.Lexing.StyleNameMap["COMMENT"]].ForeColor = System.Drawing.Color.Green;            

            scintilla1.Margins[0].Width = 20;

            scintilla1.Text = MikrotikBackup;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
