using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ConvertTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String A = "ABC Convert(A, B, C, D) = XYX";
            //string[] spliter = new string[] { "Convert(", ",", ")" };
            //string[] results = A.Split(spliter, StringSplitOptions.RemoveEmptyEntries);
            //StringBuilder x = new StringBuilder();
            //foreach (string r in results)
            //    x.AppendLine(r);
            //textBox1.Text = x.ToString();

            string input = @"ABC Convert(A, B, C, D) = (A + X) - XYX";
            string pattern = @"([A-z]+\([^)]*\))|(\([^)]*\))|( )";

            string[] results = Regex.Split(input, pattern);

            StringBuilder x = new StringBuilder();
            foreach (string r in results)
                x.AppendLine(r);
            txtComment_STR.Text = x.ToString();
        }

        #region private void btnBrowse_Click(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open File";
            theDialog.Filter = "VB files(*.vb)|*.vb|All files (*.*)|*.*";
            theDialog.RestoreDirectory = true;
            theDialog.CheckFileExists = true;
            theDialog.Multiselect = false;

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                txt_inputFile.Text = theDialog.FileName;
            }
        }
        #endregion

        #region private void btnConvert_Click(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            String inputFileNm = txt_inputFile.Text;
            if (!File.Exists(inputFileNm))
            {
                MessageBox.Show("File không tồn tại", "Error", MessageBoxButtons.OK);
                return;
            }

            if (chkComment.Checked && String.IsNullOrEmpty(txtComment_STR.Text) && String.IsNullOrEmpty(txtComment_END.Text))
            {
                MessageBox.Show("Hãy nhập nội dung comment", "Error", MessageBoxButtons.OK);
                return;
            }

            if (String.IsNullOrEmpty(txtRule.Text))
            {
                MessageBox.Show("Vui lòng nhập rule", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!txtRule.Text.Contains("@"))
            {
                MessageBox.Show("Rule phải có ký tự @ để xác định chuyển đổi", "Error", MessageBoxButtons.OK);
                return;
            }

            File.Move(txt_inputFile.Text, txt_inputFile.Text + "_tmp");

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(txt_inputFile.Text + "_tmp");
            System.IO.StreamWriter wfile = File.CreateText(txt_inputFile.Text);

            CodeReplace tool = new CodeReplace();
            string rule = txtRule.Text;

            string line;
            while ((line = file.ReadLine()) != null)
            {
                bool hasChanged = false;
                string codeAfter = tool.convertCode(rule, line, ref hasChanged);
                if (hasChanged)
                {
                    if(chkComment.Checked) wfile.WriteLine(txtComment_STR.Text);
                    wfile.WriteLine("'"+line);
                    wfile.WriteLine(codeAfter);
                    if (chkComment.Checked) wfile.WriteLine(txtComment_END.Text);
                }
                else
                {
                    wfile.WriteLine(line);
                }
            }
            file.Close();
            wfile.Close();
            MessageBox.Show("OK");
        }
        #endregion

        #region private void btnReplace1_Click(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplace1_Click(object sender, EventArgs e)
        {
            String inputFileNm = txt_inputFile.Text;
            if (!File.Exists(inputFileNm))
            {
                MessageBox.Show("File không tồn tại", "Error", MessageBoxButtons.OK);
                return;
            }

            if (chkComment.Checked && String.IsNullOrEmpty(txtComment_STR.Text) && String.IsNullOrEmpty(txtComment_END.Text))
            {
                MessageBox.Show("Hãy nhập nội dung comment", "Error", MessageBoxButtons.OK);
                return;
            }

            if (String.IsNullOrEmpty(txt_search.Text))
            {
                MessageBox.Show("Hãy text cần tìm kiếm", "Error", MessageBoxButtons.OK);
                return;
            }

            //input search text
            String oldCode = txt_search.Text;
            String newCode = Environment.NewLine + txt_replace.Text + Environment.NewLine;
            String[] arrInput = oldCode.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            List<String> arrSearch = new List<string>();
            foreach(String i in arrInput)
            {
                string rawLine = i.Trim(new char[] { ' ', '\t' });
                if (!String.IsNullOrEmpty(rawLine)) arrSearch.Add(rawLine);
            }

            File.Move(txt_inputFile.Text, txt_inputFile.Text + "_tmp");

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(txt_inputFile.Text + "_tmp");
            System.IO.StreamWriter wfile = File.CreateText(txt_inputFile.Text);

            List<String> tmpCode = new List<string>();
            List<String> compareCode = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string rawLine = line.Trim(new char[] { ' ', '\t' });
                if (arrSearch.Contains(rawLine))
                {
                    tmpCode.Add(line);
                    if (!String.IsNullOrEmpty(rawLine)) compareCode.Add(rawLine);
                    if(compareCode.Count == arrSearch.Count)
                    {
                        if (chkComment.Checked) wfile.WriteLine(txtComment_STR.Text);
                        foreach (string cd in tmpCode) wfile.WriteLine("'" + cd);
                        wfile.Write(newCode);
                        if (chkComment.Checked) wfile.WriteLine(txtComment_END.Text);

                        tmpCode.Clear();
                        compareCode.Clear();
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(rawLine))
                    {
                        continue;
                    }
                    else
                    {
                        foreach (string cd in tmpCode) wfile.WriteLine(cd);
                        tmpCode.Clear();
                        compareCode.Clear();
                        wfile.WriteLine(line);
                    }
                }
            }
            file.Close();
            wfile.Close();
            MessageBox.Show("OK");
        } 
        #endregion
    }
}
