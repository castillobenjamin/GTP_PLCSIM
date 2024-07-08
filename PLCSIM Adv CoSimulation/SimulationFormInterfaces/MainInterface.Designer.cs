using System;

namespace PLCSIM_Adv_CoSimulation
{
    partial class MainInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainInterface));
            this.Btn_updatePlcList = new System.Windows.Forms.Button();
            this.PLCgroup = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_OpState = new System.Windows.Forms.Label();
            this.btn_Reboot = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btn_PwrOFF = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_PwrON = new System.Windows.Forms.Button();
            this.comboBox_PLC_list = new System.Windows.Forms.ComboBox();
            this.listBox_notifications = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_StartSimulation = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CheckBox_CellOnly = new System.Windows.Forms.CheckBox();
            this.Btn_StopSimulation = new System.Windows.Forms.Button();
            this.textBox_ConfigFilePath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_BrowseFile = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Button_DisconnectCell = new System.Windows.Forms.Button();
            this.TextBox_ModbusPort = new System.Windows.Forms.TextBox();
            this.TextBox_ModbusServerIP = new System.Windows.Forms.TextBox();
            this.Button_ConnectCell = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_TestingLaunch = new System.Windows.Forms.Button();
            this.PLCgroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_updatePlcList
            // 
            this.Btn_updatePlcList.Location = new System.Drawing.Point(4, 40);
            this.Btn_updatePlcList.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_updatePlcList.Name = "Btn_updatePlcList";
            this.Btn_updatePlcList.Size = new System.Drawing.Size(79, 22);
            this.Btn_updatePlcList.TabIndex = 0;
            this.Btn_updatePlcList.Text = "Update list";
            this.Btn_updatePlcList.UseVisualStyleBackColor = true;
            this.Btn_updatePlcList.Click += new System.EventHandler(this.Btn_updatePlcList_Click);
            // 
            // PLCgroup
            // 
            this.PLCgroup.Controls.Add(this.groupBox1);
            this.PLCgroup.Controls.Add(this.comboBox_PLC_list);
            this.PLCgroup.Controls.Add(this.Btn_updatePlcList);
            this.PLCgroup.Location = new System.Drawing.Point(11, 11);
            this.PLCgroup.Margin = new System.Windows.Forms.Padding(2);
            this.PLCgroup.Name = "PLCgroup";
            this.PLCgroup.Padding = new System.Windows.Forms.Padding(2);
            this.PLCgroup.Size = new System.Drawing.Size(132, 206);
            this.PLCgroup.TabIndex = 8;
            this.PLCgroup.TabStop = false;
            this.PLCgroup.Text = "Virtual PLC";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_OpState);
            this.groupBox1.Controls.Add(this.btn_Reboot);
            this.groupBox1.Controls.Add(this.btn_Run);
            this.groupBox1.Controls.Add(this.btn_PwrOFF);
            this.groupBox1.Controls.Add(this.btn_Stop);
            this.groupBox1.Controls.Add(this.btn_PwrON);
            this.groupBox1.Location = new System.Drawing.Point(8, 77);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(116, 122);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operating State";
            // 
            // label_OpState
            // 
            this.label_OpState.AutoSize = true;
            this.label_OpState.Location = new System.Drawing.Point(6, 17);
            this.label_OpState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_OpState.Name = "label_OpState";
            this.label_OpState.Size = new System.Drawing.Size(11, 12);
            this.label_OpState.TabIndex = 16;
            this.label_OpState.Text = "-";
            // 
            // btn_Reboot
            // 
            this.btn_Reboot.Location = new System.Drawing.Point(4, 93);
            this.btn_Reboot.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Reboot.Name = "btn_Reboot";
            this.btn_Reboot.Size = new System.Drawing.Size(56, 22);
            this.btn_Reboot.TabIndex = 12;
            this.btn_Reboot.Text = "Reboot";
            this.btn_Reboot.UseVisualStyleBackColor = true;
            this.btn_Reboot.Click += new System.EventHandler(this.Btn_Reboot_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(4, 67);
            this.btn_Run.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(44, 22);
            this.btn_Run.TabIndex = 14;
            this.btn_Run.Text = "RUN";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.Btn_Run_Click);
            // 
            // btn_PwrOFF
            // 
            this.btn_PwrOFF.Location = new System.Drawing.Point(52, 41);
            this.btn_PwrOFF.Margin = new System.Windows.Forms.Padding(2);
            this.btn_PwrOFF.Name = "btn_PwrOFF";
            this.btn_PwrOFF.Size = new System.Drawing.Size(44, 22);
            this.btn_PwrOFF.TabIndex = 11;
            this.btn_PwrOFF.Text = "OFF";
            this.btn_PwrOFF.UseVisualStyleBackColor = true;
            this.btn_PwrOFF.Click += new System.EventHandler(this.Btn_PwrOFF_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(52, 67);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(44, 22);
            this.btn_Stop.TabIndex = 15;
            this.btn_Stop.Text = "STOP";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // btn_PwrON
            // 
            this.btn_PwrON.Location = new System.Drawing.Point(4, 41);
            this.btn_PwrON.Margin = new System.Windows.Forms.Padding(2);
            this.btn_PwrON.Name = "btn_PwrON";
            this.btn_PwrON.Size = new System.Drawing.Size(44, 22);
            this.btn_PwrON.TabIndex = 10;
            this.btn_PwrON.Text = "ON";
            this.btn_PwrON.UseVisualStyleBackColor = true;
            this.btn_PwrON.Click += new System.EventHandler(this.Btn_PwrON_Click);
            // 
            // comboBox_PLC_list
            // 
            this.comboBox_PLC_list.FormattingEnabled = true;
            this.comboBox_PLC_list.Location = new System.Drawing.Point(4, 16);
            this.comboBox_PLC_list.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_PLC_list.Name = "comboBox_PLC_list";
            this.comboBox_PLC_list.Size = new System.Drawing.Size(120, 20);
            this.comboBox_PLC_list.TabIndex = 8;
            this.comboBox_PLC_list.SelectedIndexChanged += new System.EventHandler(this.ComboBox_PLC_list_SelectedIndexChanged);
            // 
            // listBox_notifications
            // 
            this.listBox_notifications.FormattingEnabled = true;
            this.listBox_notifications.ItemHeight = 12;
            this.listBox_notifications.Location = new System.Drawing.Point(11, 279);
            this.listBox_notifications.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_notifications.Name = "listBox_notifications";
            this.listBox_notifications.Size = new System.Drawing.Size(304, 100);
            this.listBox_notifications.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 263);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Log";
            // 
            // Btn_StartSimulation
            // 
            this.Btn_StartSimulation.Location = new System.Drawing.Point(7, 90);
            this.Btn_StartSimulation.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_StartSimulation.Name = "Btn_StartSimulation";
            this.Btn_StartSimulation.Size = new System.Drawing.Size(60, 29);
            this.Btn_StartSimulation.TabIndex = 18;
            this.Btn_StartSimulation.Text = "Launch";
            this.Btn_StartSimulation.UseVisualStyleBackColor = true;
            this.Btn_StartSimulation.Click += new System.EventHandler(this.Btn_StartSimulation_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CheckBox_CellOnly);
            this.groupBox4.Controls.Add(this.Btn_StopSimulation);
            this.groupBox4.Controls.Add(this.textBox_ConfigFilePath);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.btn_BrowseFile);
            this.groupBox4.Controls.Add(this.Btn_StartSimulation);
            this.groupBox4.Location = new System.Drawing.Point(148, 88);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(167, 130);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Simulation";
            // 
            // CheckBox_CellOnly
            // 
            this.CheckBox_CellOnly.AutoSize = true;
            this.CheckBox_CellOnly.Location = new System.Drawing.Point(71, 58);
            this.CheckBox_CellOnly.Name = "CheckBox_CellOnly";
            this.CheckBox_CellOnly.Size = new System.Drawing.Size(78, 16);
            this.CheckBox_CellOnly.TabIndex = 24;
            this.CheckBox_CellOnly.Text = "CELL Only";
            this.CheckBox_CellOnly.UseVisualStyleBackColor = true;
            // 
            // Btn_StopSimulation
            // 
            this.Btn_StopSimulation.Location = new System.Drawing.Point(71, 90);
            this.Btn_StopSimulation.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_StopSimulation.Name = "Btn_StopSimulation";
            this.Btn_StopSimulation.Size = new System.Drawing.Size(58, 29);
            this.Btn_StopSimulation.TabIndex = 23;
            this.Btn_StopSimulation.Text = "Stop";
            this.Btn_StopSimulation.UseVisualStyleBackColor = true;
            this.Btn_StopSimulation.Click += new System.EventHandler(this.Btn_StopSimulation_Click);
            // 
            // textBox_ConfigFilePath
            // 
            this.textBox_ConfigFilePath.Location = new System.Drawing.Point(7, 31);
            this.textBox_ConfigFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ConfigFilePath.Name = "textBox_ConfigFilePath";
            this.textBox_ConfigFilePath.Size = new System.Drawing.Size(151, 19);
            this.textBox_ConfigFilePath.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 17);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "Configuration file";
            // 
            // btn_BrowseFile
            // 
            this.btn_BrowseFile.Location = new System.Drawing.Point(7, 54);
            this.btn_BrowseFile.Margin = new System.Windows.Forms.Padding(2);
            this.btn_BrowseFile.Name = "btn_BrowseFile";
            this.btn_BrowseFile.Size = new System.Drawing.Size(58, 22);
            this.btn_BrowseFile.TabIndex = 18;
            this.btn_BrowseFile.Text = "Browse";
            this.btn_BrowseFile.UseVisualStyleBackColor = true;
            this.btn_BrowseFile.Click += new System.EventHandler(this.Btn_BrowseFile_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.Button_DisconnectCell);
            this.groupBox6.Controls.Add(this.TextBox_ModbusPort);
            this.groupBox6.Controls.Add(this.TextBox_ModbusServerIP);
            this.groupBox6.Controls.Add(this.Button_ConnectCell);
            this.groupBox6.Location = new System.Drawing.Point(148, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(167, 71);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cell connection";
            // 
            // Button_DisconnectCell
            // 
            this.Button_DisconnectCell.Location = new System.Drawing.Point(68, 40);
            this.Button_DisconnectCell.Margin = new System.Windows.Forms.Padding(2);
            this.Button_DisconnectCell.Name = "Button_DisconnectCell";
            this.Button_DisconnectCell.Size = new System.Drawing.Size(72, 24);
            this.Button_DisconnectCell.TabIndex = 27;
            this.Button_DisconnectCell.Text = "Disconnect";
            this.Button_DisconnectCell.UseVisualStyleBackColor = true;
            this.Button_DisconnectCell.Click += new System.EventHandler(this.Button_DisconnectCell_Click);
            // 
            // TextBox_ModbusPort
            // 
            this.TextBox_ModbusPort.Location = new System.Drawing.Point(99, 17);
            this.TextBox_ModbusPort.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_ModbusPort.Name = "TextBox_ModbusPort";
            this.TextBox_ModbusPort.Size = new System.Drawing.Size(59, 19);
            this.TextBox_ModbusPort.TabIndex = 26;
            // 
            // TextBox_ModbusServerIP
            // 
            this.TextBox_ModbusServerIP.Location = new System.Drawing.Point(5, 17);
            this.TextBox_ModbusServerIP.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_ModbusServerIP.Name = "TextBox_ModbusServerIP";
            this.TextBox_ModbusServerIP.Size = new System.Drawing.Size(90, 19);
            this.TextBox_ModbusServerIP.TabIndex = 25;
            // 
            // Button_ConnectCell
            // 
            this.Button_ConnectCell.Location = new System.Drawing.Point(5, 40);
            this.Button_ConnectCell.Margin = new System.Windows.Forms.Padding(2);
            this.Button_ConnectCell.Name = "Button_ConnectCell";
            this.Button_ConnectCell.Size = new System.Drawing.Size(59, 24);
            this.Button_ConnectCell.TabIndex = 24;
            this.Button_ConnectCell.Text = "Connect";
            this.Button_ConnectCell.UseVisualStyleBackColor = true;
            this.Button_ConnectCell.Click += new System.EventHandler(this.Button_ConnectCell_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_TestingLaunch);
            this.groupBox2.Location = new System.Drawing.Point(148, 222);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(167, 53);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Testing";
            // 
            // Btn_TestingLaunch
            // 
            this.Btn_TestingLaunch.Location = new System.Drawing.Point(4, 16);
            this.Btn_TestingLaunch.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_TestingLaunch.Name = "Btn_TestingLaunch";
            this.Btn_TestingLaunch.Size = new System.Drawing.Size(60, 29);
            this.Btn_TestingLaunch.TabIndex = 18;
            this.Btn_TestingLaunch.Text = "Launch";
            this.Btn_TestingLaunch.UseVisualStyleBackColor = true;
            this.Btn_TestingLaunch.Click += new System.EventHandler(this.Btn_TestingLaunch_Click);
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 392);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox_notifications);
            this.Controls.Add(this.PLCgroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainInterface";
            this.Text = "AlphaBot PLC SIM (GTP 1.5)";
            this.PLCgroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_updatePlcList;
        private System.Windows.Forms.GroupBox PLCgroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Reboot;
        private System.Windows.Forms.Button btn_PwrOFF;
        private System.Windows.Forms.Button btn_PwrON;
        private System.Windows.Forms.ComboBox comboBox_PLC_list;
        private System.Windows.Forms.ListBox listBox_notifications;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_OpState;
        private System.Windows.Forms.Button Btn_StartSimulation;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_ConfigFilePath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_BrowseFile;
        private System.Windows.Forms.Button Btn_StopSimulation;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox TextBox_ModbusPort;
        private System.Windows.Forms.TextBox TextBox_ModbusServerIP;
        private System.Windows.Forms.Button Button_ConnectCell;
        private System.Windows.Forms.Button Button_DisconnectCell;
        private System.Windows.Forms.CheckBox CheckBox_CellOnly;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_TestingLaunch;
    }
}

