namespace PLCSIM_Adv_CoSimulation
{
    partial class TestingInterface
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
            this.ListBox_Log = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_StartTest = new System.Windows.Forms.Button();
            this.TextBox_ProgramVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_BrowseFile = new System.Windows.Forms.Button();
            this.TextBox_TestFilePath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Label_Log = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox_Log
            // 
            this.ListBox_Log.FormattingEnabled = true;
            this.ListBox_Log.ItemHeight = 12;
            this.ListBox_Log.Location = new System.Drawing.Point(251, 27);
            this.ListBox_Log.Name = "ListBox_Log";
            this.ListBox_Log.Size = new System.Drawing.Size(463, 172);
            this.ListBox_Log.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_StartTest);
            this.groupBox1.Controls.Add(this.TextBox_ProgramVersion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Btn_BrowseFile);
            this.groupBox1.Controls.Add(this.TextBox_TestFilePath);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 194);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Data";
            // 
            // Btn_StartTest
            // 
            this.Btn_StartTest.Location = new System.Drawing.Point(6, 153);
            this.Btn_StartTest.Name = "Btn_StartTest";
            this.Btn_StartTest.Size = new System.Drawing.Size(88, 35);
            this.Btn_StartTest.TabIndex = 2;
            this.Btn_StartTest.Text = "Start Test";
            this.Btn_StartTest.UseVisualStyleBackColor = true;
            this.Btn_StartTest.Click += new System.EventHandler(this.Btn_StartTest_Click);
            // 
            // TextBox_ProgramVersion
            // 
            this.TextBox_ProgramVersion.Location = new System.Drawing.Point(6, 30);
            this.TextBox_ProgramVersion.Name = "TextBox_ProgramVersion";
            this.TextBox_ProgramVersion.Size = new System.Drawing.Size(216, 19);
            this.TextBox_ProgramVersion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Program version";
            // 
            // Btn_BrowseFile
            // 
            this.Btn_BrowseFile.Location = new System.Drawing.Point(5, 94);
            this.Btn_BrowseFile.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_BrowseFile.Name = "Btn_BrowseFile";
            this.Btn_BrowseFile.Size = new System.Drawing.Size(58, 22);
            this.Btn_BrowseFile.TabIndex = 18;
            this.Btn_BrowseFile.Text = "Browse";
            this.Btn_BrowseFile.UseVisualStyleBackColor = true;
            this.Btn_BrowseFile.Click += new System.EventHandler(this.Btn_BrowseFile_Click);
            // 
            // TextBox_TestFilePath
            // 
            this.TextBox_TestFilePath.Location = new System.Drawing.Point(5, 71);
            this.TextBox_TestFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_TestFilePath.Name = "TextBox_TestFilePath";
            this.TextBox_TestFilePath.Size = new System.Drawing.Size(151, 19);
            this.TextBox_TestFilePath.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 57);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "Test file";
            // 
            // Label_Log
            // 
            this.Label_Log.AutoSize = true;
            this.Label_Log.Location = new System.Drawing.Point(250, 12);
            this.Label_Log.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Log.Name = "Label_Log";
            this.Label_Log.Size = new System.Drawing.Size(23, 12);
            this.Label_Log.TabIndex = 23;
            this.Label_Log.Text = "Log";
            // 
            // TestingInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 214);
            this.Controls.Add(this.Label_Log);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ListBox_Log);
            this.Name = "TestingInterface";
            this.Text = "TestingInterface";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox_Log;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TextBox_ProgramVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_StartTest;
        private System.Windows.Forms.Button Btn_BrowseFile;
        private System.Windows.Forms.TextBox TextBox_TestFilePath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Label_Log;
    }
}