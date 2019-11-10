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
            if (!this.checkInput()) return;

            CodeReplace tool = new CodeReplace();
            string rule = txtRule.Text;

            File.Move(txt_inputFile.Text, txt_inputFile.Text + "_tmp");

            // Read the file and display it line by line.  
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(txt_inputFile.Text + "_tmp");
            System.IO.StreamWriter wfile = File.CreateText(txt_inputFile.Text);

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

        #region private Boolean checkInput()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Boolean checkInput()
        {
            String inputFileNm = txt_inputFile.Text;
            if (!File.Exists(inputFileNm))
            {
                MessageBox.Show("File không tồn tại", "Error", MessageBoxButtons.OK);
                return false;
            }

            if (String.IsNullOrEmpty(txtRule.Text))
            {
                MessageBox.Show("Vui lòng nhập rule", "Error", MessageBoxButtons.OK);
                return false;
            }

            if (!txtRule.Text.Contains("@"))
            {
                MessageBox.Show("Rule phải có ký tự @ để xác định chuyển đổi", "Error", MessageBoxButtons.OK);
                return false;
            }

            if(chkComment.Checked && String.IsNullOrEmpty(txtComment_STR.Text) && String.IsNullOrEmpty(txtComment_END.Text))
            {
                MessageBox.Show("Hãy nhập nội dung comment", "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        } 
        #endregion
    }
}
