namespace ArxivOrgWinForm
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
            this.btn_Start = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txBxInfo = new System.Windows.Forms.TextBox();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.cmbBoxYearStart = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBoxMonthStart = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBoxMonthStop = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBoxYearStop = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkBxGetArticles = new System.Windows.Forms.CheckBox();
            this.txBxSavePDF = new System.Windows.Forms.TextBox();
            this.chkBxGetPDF = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txBxStartIndex = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(81, 19);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(86, 23);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Get articles";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txBxInfo);
            this.groupBox1.Controls.Add(this.btn_Stop);
            this.groupBox1.Controls.Add(this.btn_Start);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 210);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get articles";
            // 
            // txBxInfo
            // 
            this.txBxInfo.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txBxInfo.Location = new System.Drawing.Point(10, 59);
            this.txBxInfo.Multiline = true;
            this.txBxInfo.Name = "txBxInfo";
            this.txBxInfo.ReadOnly = true;
            this.txBxInfo.Size = new System.Drawing.Size(319, 128);
            this.txBxInfo.TabIndex = 5;
            this.txBxInfo.Text = "info...";
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(173, 19);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(86, 23);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "Cancel";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // cmbBoxYearStart
            // 
            this.cmbBoxYearStart.DropDownHeight = 60;
            this.cmbBoxYearStart.FormattingEnabled = true;
            this.cmbBoxYearStart.IntegralHeight = false;
            this.cmbBoxYearStart.Location = new System.Drawing.Point(51, 36);
            this.cmbBoxYearStart.Name = "cmbBoxYearStart";
            this.cmbBoxYearStart.Size = new System.Drawing.Size(76, 21);
            this.cmbBoxYearStart.TabIndex = 11;
            this.cmbBoxYearStart.SelectedIndexChanged += new System.EventHandler(this.CmbBoxYearStart_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbBoxMonthStart);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbBoxYearStart);
            this.groupBox2.Location = new System.Drawing.Point(12, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 100);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "From date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Month";
            // 
            // cmbBoxMonthStart
            // 
            this.cmbBoxMonthStart.DropDownHeight = 60;
            this.cmbBoxMonthStart.FormattingEnabled = true;
            this.cmbBoxMonthStart.IntegralHeight = false;
            this.cmbBoxMonthStart.Location = new System.Drawing.Point(51, 63);
            this.cmbBoxMonthStart.Name = "cmbBoxMonthStart";
            this.cmbBoxMonthStart.Size = new System.Drawing.Size(76, 21);
            this.cmbBoxMonthStart.TabIndex = 15;
            this.cmbBoxMonthStart.SelectedIndexChanged += new System.EventHandler(this.CmbBoxMonthStart_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Year";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cmbBoxMonthStop);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cmbBoxYearStop);
            this.groupBox3.Location = new System.Drawing.Point(163, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(145, 100);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "To date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Month";
            // 
            // cmbBoxMonthStop
            // 
            this.cmbBoxMonthStop.DropDownHeight = 60;
            this.cmbBoxMonthStop.FormattingEnabled = true;
            this.cmbBoxMonthStop.IntegralHeight = false;
            this.cmbBoxMonthStop.Location = new System.Drawing.Point(51, 63);
            this.cmbBoxMonthStop.Name = "cmbBoxMonthStop";
            this.cmbBoxMonthStop.Size = new System.Drawing.Size(76, 21);
            this.cmbBoxMonthStop.TabIndex = 15;
            this.cmbBoxMonthStop.SelectedIndexChanged += new System.EventHandler(this.CmbBoxMonthStop_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Year";
            // 
            // cmbBoxYearStop
            // 
            this.cmbBoxYearStop.DropDownHeight = 60;
            this.cmbBoxYearStop.FormattingEnabled = true;
            this.cmbBoxYearStop.IntegralHeight = false;
            this.cmbBoxYearStop.Location = new System.Drawing.Point(51, 36);
            this.cmbBoxYearStop.Name = "cmbBoxYearStop";
            this.cmbBoxYearStop.Size = new System.Drawing.Size(76, 21);
            this.cmbBoxYearStop.TabIndex = 11;
            this.cmbBoxYearStop.SelectedIndexChanged += new System.EventHandler(this.CmbBoxYearStop_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Article start index";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.txBxStartIndex);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Location = new System.Drawing.Point(10, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(319, 275);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkBxGetArticles);
            this.groupBox5.Controls.Add(this.txBxSavePDF);
            this.groupBox5.Controls.Add(this.chkBxGetPDF);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.btnBrowse);
            this.groupBox5.Location = new System.Drawing.Point(12, 152);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(296, 105);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            // 
            // chkBxGetArticles
            // 
            this.chkBxGetArticles.AutoSize = true;
            this.chkBxGetArticles.Location = new System.Drawing.Point(165, 18);
            this.chkBxGetArticles.Name = "chkBxGetArticles";
            this.chkBxGetArticles.Size = new System.Drawing.Size(79, 17);
            this.chkBxGetArticles.TabIndex = 24;
            this.chkBxGetArticles.Text = "Get articles";
            this.chkBxGetArticles.UseVisualStyleBackColor = true;
            // 
            // txBxSavePDF
            // 
            this.txBxSavePDF.Location = new System.Drawing.Point(88, 45);
            this.txBxSavePDF.Name = "txBxSavePDF";
            this.txBxSavePDF.Size = new System.Drawing.Size(195, 20);
            this.txBxSavePDF.TabIndex = 21;
            // 
            // chkBxGetPDF
            // 
            this.chkBxGetPDF.AutoSize = true;
            this.chkBxGetPDF.Location = new System.Drawing.Point(16, 18);
            this.chkBxGetPDF.Name = "chkBxGetPDF";
            this.chkBxGetPDF.Size = new System.Drawing.Size(67, 17);
            this.chkBxGetPDF.TabIndex = 23;
            this.chkBxGetPDF.Text = "Get PDF";
            this.chkBxGetPDF.UseVisualStyleBackColor = true;
            this.chkBxGetPDF.CheckedChanged += new System.EventHandler(this.ChkBxGetPDF_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "File path";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(207, 71);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(76, 25);
            this.btnBrowse.TabIndex = 22;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txBxStartIndex
            // 
            this.txBxStartIndex.Location = new System.Drawing.Point(102, 128);
            this.txBxStartIndex.Name = "txBxStartIndex";
            this.txBxStartIndex.Size = new System.Drawing.Size(85, 20);
            this.txBxStartIndex.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 511);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 550);
            this.MinimumSize = new System.Drawing.Size(356, 195);
            this.Name = "MainForm";
            this.Text = "Hoarding scientific articles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.TextBox txBxInfo;
        private System.Windows.Forms.ComboBox cmbBoxYearStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBoxMonthStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBoxMonthStop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBoxYearStop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txBxStartIndex;
        private System.Windows.Forms.TextBox txBxSavePDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkBxGetArticles;
        private System.Windows.Forms.CheckBox chkBxGetPDF;
    }
}

