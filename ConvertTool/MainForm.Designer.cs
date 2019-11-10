namespace ConvertTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReplace = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_inputFile = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRule = new System.Windows.Forms.TextBox();
            this.txtComment_STR = new System.Windows.Forms.TextBox();
            this.chkComment = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtComment_END = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_replace = new System.Windows.Forms.TextBox();
            this.btnReplace1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(245, 112);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(164, 23);
            this.btnReplace.TabIndex = 2;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn File:";
            // 
            // txt_inputFile
            // 
            this.txt_inputFile.Location = new System.Drawing.Point(73, 21);
            this.txt_inputFile.Name = "txt_inputFile";
            this.txt_inputFile.Size = new System.Drawing.Size(545, 20);
            this.txt_inputFile.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(624, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(44, 21);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rule:";
            // 
            // txtRule
            // 
            this.txtRule.Location = new System.Drawing.Point(86, 42);
            this.txtRule.Name = "txtRule";
            this.txtRule.Size = new System.Drawing.Size(528, 20);
            this.txtRule.TabIndex = 1;
            // 
            // txtComment_STR
            // 
            this.txtComment_STR.Location = new System.Drawing.Point(73, 85);
            this.txtComment_STR.Name = "txtComment_STR";
            this.txtComment_STR.Size = new System.Drawing.Size(545, 20);
            this.txtComment_STR.TabIndex = 7;
            // 
            // chkComment
            // 
            this.chkComment.AutoSize = true;
            this.chkComment.Location = new System.Drawing.Point(16, 62);
            this.chkComment.Name = "chkComment";
            this.chkComment.Size = new System.Drawing.Size(173, 17);
            this.chkComment.TabIndex = 9;
            this.chkComment.Text = "Thêm comment (START & END)";
            this.chkComment.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "$ : Tham số / @ : Keyword thay đổii";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 184);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(690, 395);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtRule);
            this.tabPage1.Controls.Add(this.btnReplace);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(682, 313);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Replace Theo Rule";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtComment_END
            // 
            this.txtComment_END.Location = new System.Drawing.Point(73, 111);
            this.txtComment_END.Name = "txtComment_END";
            this.txtComment_END.Size = new System.Drawing.Size(545, 20);
            this.txtComment_END.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnReplace1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txt_replace);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txt_search);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(682, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Replace Thường";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtComment_END);
            this.panel1.Controls.Add(this.txt_inputFile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.chkComment);
            this.panel1.Controls.Add(this.txtComment_STR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 184);
            this.panel1.TabIndex = 12;
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(34, 31);
            this.txt_search.Multiline = true;
            this.txt_search.Name = "txt_search";
            this.txt_search.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_search.Size = new System.Drawing.Size(605, 120);
            this.txt_search.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Search";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Replace";
            // 
            // txt_replace
            // 
            this.txt_replace.Location = new System.Drawing.Point(34, 185);
            this.txt_replace.Multiline = true;
            this.txt_replace.Name = "txt_replace";
            this.txt_replace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_replace.Size = new System.Drawing.Size(605, 131);
            this.txt_replace.TabIndex = 8;
            // 
            // btnReplace1
            // 
            this.btnReplace1.Location = new System.Drawing.Point(253, 326);
            this.btnReplace1.Name = "btnReplace1";
            this.btnReplace1.Size = new System.Drawing.Size(164, 23);
            this.btnReplace1.TabIndex = 10;
            this.btnReplace1.Text = "Replace";
            this.btnReplace1.UseVisualStyleBackColor = true;
            this.btnReplace1.Click += new System.EventHandler(this.btnReplace1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 579);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Replace Code";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_inputFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRule;
        private System.Windows.Forms.TextBox txtComment_STR;
        private System.Windows.Forms.CheckBox chkComment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtComment_END;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReplace1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_replace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_search;
    }
}

