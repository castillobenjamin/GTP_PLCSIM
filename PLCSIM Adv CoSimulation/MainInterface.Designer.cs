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
            this.btn_createPLC = new System.Windows.Forms.Button();
            this.textBox_PLC_name = new System.Windows.Forms.TextBox();
            this.textBox_PLC_IPaddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_deletePLC = new System.Windows.Forms.Button();
            this.textBox_SubnetMask = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PLCgroup = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Gateway = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_TCPIP = new System.Windows.Forms.Button();
            this.btn_Local = new System.Windows.Forms.Button();
            this.label_connectionType = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_OpState = new System.Windows.Forms.Label();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Reboot = new System.Windows.Forms.Button();
            this.btn_PwrOFF = new System.Windows.Forms.Button();
            this.btn_PwrON = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_PLC_list = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.trackBar_timeScale = new System.Windows.Forms.TrackBar();
            this.textBox_timeScale = new System.Windows.Forms.TextBox();
            this.listBox_notifications = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TagsGroup = new System.Windows.Forms.GroupBox();
            this.textBox_setTagValue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_tagValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TagOptionsGroup = new System.Windows.Forms.GroupBox();
            this.checkBox_IO = new System.Windows.Forms.CheckBox();
            this.checkBox_DBs = new System.Windows.Forms.CheckBox();
            this.checkBox_M = new System.Windows.Forms.CheckBox();
            this.checkBox_CTs = new System.Windows.Forms.CheckBox();
            this.comboBox_tagList = new System.Windows.Forms.ComboBox();
            this.btn_readTag = new System.Windows.Forms.Button();
            this.btn_writeTag = new System.Windows.Forms.Button();
            this.Btn_StartSimulation = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Btn_StopSimulation = new System.Windows.Forms.Button();
            this.textBox_ConfigFilePath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_BrowseFile = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_IOAddress = new System.Windows.Forms.TextBox();
            this.textBox_addressBit = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_addressValue = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_addressType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox_addressArea = new System.Windows.Forms.ComboBox();
            this.btn_readFromAddress = new System.Windows.Forms.Button();
            this.btn_writeToAddess = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Button_DisconnectCell = new System.Windows.Forms.Button();
            this.TextBox_ModbusPort = new System.Windows.Forms.TextBox();
            this.TextBox_ModbusServerIP = new System.Windows.Forms.TextBox();
            this.Button_ConnectCell = new System.Windows.Forms.Button();
            this.PLCgroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_timeScale)).BeginInit();
            this.TagsGroup.SuspendLayout();
            this.TagOptionsGroup.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_createPLC
            // 
            this.btn_createPLC.Location = new System.Drawing.Point(8, 28);
            this.btn_createPLC.Margin = new System.Windows.Forms.Padding(2);
            this.btn_createPLC.Name = "btn_createPLC";
            this.btn_createPLC.Size = new System.Drawing.Size(74, 22);
            this.btn_createPLC.TabIndex = 0;
            this.btn_createPLC.Text = "Create PLC";
            this.btn_createPLC.UseVisualStyleBackColor = true;
            this.btn_createPLC.Click += new System.EventHandler(this.Btn_createPLC_Click);
            // 
            // textBox_PLC_name
            // 
            this.textBox_PLC_name.Location = new System.Drawing.Point(86, 31);
            this.textBox_PLC_name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_PLC_name.Name = "textBox_PLC_name";
            this.textBox_PLC_name.Size = new System.Drawing.Size(88, 19);
            this.textBox_PLC_name.TabIndex = 1;
            // 
            // textBox_PLC_IPaddress
            // 
            this.textBox_PLC_IPaddress.Location = new System.Drawing.Point(179, 31);
            this.textBox_PLC_IPaddress.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_PLC_IPaddress.Name = "textBox_PLC_IPaddress";
            this.textBox_PLC_IPaddress.Size = new System.Drawing.Size(88, 19);
            this.textBox_PLC_IPaddress.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "PLC name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP address";
            // 
            // btn_deletePLC
            // 
            this.btn_deletePLC.Location = new System.Drawing.Point(8, 65);
            this.btn_deletePLC.Margin = new System.Windows.Forms.Padding(2);
            this.btn_deletePLC.Name = "btn_deletePLC";
            this.btn_deletePLC.Size = new System.Drawing.Size(74, 22);
            this.btn_deletePLC.TabIndex = 5;
            this.btn_deletePLC.Text = "Delete PLC";
            this.btn_deletePLC.UseVisualStyleBackColor = true;
            this.btn_deletePLC.Click += new System.EventHandler(this.Btn_DeletePLC_Click);
            // 
            // textBox_SubnetMask
            // 
            this.textBox_SubnetMask.Location = new System.Drawing.Point(275, 31);
            this.textBox_SubnetMask.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SubnetMask.Name = "textBox_SubnetMask";
            this.textBox_SubnetMask.Size = new System.Drawing.Size(88, 19);
            this.textBox_SubnetMask.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Subnet Mask";
            // 
            // PLCgroup
            // 
            this.PLCgroup.Controls.Add(this.label6);
            this.PLCgroup.Controls.Add(this.textBox_Gateway);
            this.PLCgroup.Controls.Add(this.groupBox2);
            this.PLCgroup.Controls.Add(this.groupBox1);
            this.PLCgroup.Controls.Add(this.btn_Reboot);
            this.PLCgroup.Controls.Add(this.btn_PwrOFF);
            this.PLCgroup.Controls.Add(this.btn_PwrON);
            this.PLCgroup.Controls.Add(this.label4);
            this.PLCgroup.Controls.Add(this.comboBox_PLC_list);
            this.PLCgroup.Controls.Add(this.label3);
            this.PLCgroup.Controls.Add(this.textBox_PLC_IPaddress);
            this.PLCgroup.Controls.Add(this.textBox_SubnetMask);
            this.PLCgroup.Controls.Add(this.btn_createPLC);
            this.PLCgroup.Controls.Add(this.btn_deletePLC);
            this.PLCgroup.Controls.Add(this.textBox_PLC_name);
            this.PLCgroup.Controls.Add(this.label2);
            this.PLCgroup.Controls.Add(this.label1);
            this.PLCgroup.Controls.Add(this.groupBox3);
            this.PLCgroup.Location = new System.Drawing.Point(9, 10);
            this.PLCgroup.Margin = new System.Windows.Forms.Padding(2);
            this.PLCgroup.Name = "PLCgroup";
            this.PLCgroup.Padding = new System.Windows.Forms.Padding(2);
            this.PLCgroup.Size = new System.Drawing.Size(374, 287);
            this.PLCgroup.TabIndex = 8;
            this.PLCgroup.TabStop = false;
            this.PLCgroup.Text = "Virtual PLC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 51);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "Default Gateway";
            // 
            // textBox_Gateway
            // 
            this.textBox_Gateway.Location = new System.Drawing.Point(275, 66);
            this.textBox_Gateway.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Gateway.Name = "textBox_Gateway";
            this.textBox_Gateway.Size = new System.Drawing.Size(88, 19);
            this.textBox_Gateway.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_TCPIP);
            this.groupBox2.Controls.Add(this.btn_Local);
            this.groupBox2.Controls.Add(this.label_connectionType);
            this.groupBox2.Location = new System.Drawing.Point(88, 114);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(171, 80);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection Type";
            // 
            // btn_TCPIP
            // 
            this.btn_TCPIP.Location = new System.Drawing.Point(93, 51);
            this.btn_TCPIP.Margin = new System.Windows.Forms.Padding(2);
            this.btn_TCPIP.Name = "btn_TCPIP";
            this.btn_TCPIP.Size = new System.Drawing.Size(74, 22);
            this.btn_TCPIP.TabIndex = 17;
            this.btn_TCPIP.Text = "Ethernet";
            this.btn_TCPIP.UseVisualStyleBackColor = true;
            this.btn_TCPIP.Click += new System.EventHandler(this.Btn_TCPIP_Click);
            // 
            // btn_Local
            // 
            this.btn_Local.Location = new System.Drawing.Point(93, 24);
            this.btn_Local.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Local.Name = "btn_Local";
            this.btn_Local.Size = new System.Drawing.Size(74, 22);
            this.btn_Local.TabIndex = 18;
            this.btn_Local.Text = "PLCSIM";
            this.btn_Local.UseVisualStyleBackColor = true;
            this.btn_Local.Click += new System.EventHandler(this.Btn_Local_Click);
            // 
            // label_connectionType
            // 
            this.label_connectionType.AutoSize = true;
            this.label_connectionType.Location = new System.Drawing.Point(4, 34);
            this.label_connectionType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_connectionType.Name = "label_connectionType";
            this.label_connectionType.Size = new System.Drawing.Size(11, 12);
            this.label_connectionType.TabIndex = 11;
            this.label_connectionType.Text = "-";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_OpState);
            this.groupBox1.Controls.Add(this.btn_Run);
            this.groupBox1.Controls.Add(this.btn_Stop);
            this.groupBox1.Location = new System.Drawing.Point(263, 85);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(99, 109);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operating State";
            // 
            // label_OpState
            // 
            this.label_OpState.AutoSize = true;
            this.label_OpState.Location = new System.Drawing.Point(10, 33);
            this.label_OpState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_OpState.Name = "label_OpState";
            this.label_OpState.Size = new System.Drawing.Size(11, 12);
            this.label_OpState.TabIndex = 16;
            this.label_OpState.Text = "-";
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(12, 53);
            this.btn_Run.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(74, 22);
            this.btn_Run.TabIndex = 14;
            this.btn_Run.Text = "RUN";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.Btn_Run_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(12, 80);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(74, 22);
            this.btn_Stop.TabIndex = 15;
            this.btn_Stop.Text = "STOP";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // btn_Reboot
            // 
            this.btn_Reboot.Location = new System.Drawing.Point(8, 166);
            this.btn_Reboot.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Reboot.Name = "btn_Reboot";
            this.btn_Reboot.Size = new System.Drawing.Size(74, 22);
            this.btn_Reboot.TabIndex = 12;
            this.btn_Reboot.Text = "Reboot PLC";
            this.btn_Reboot.UseVisualStyleBackColor = true;
            this.btn_Reboot.Click += new System.EventHandler(this.Btn_Reboot_Click);
            // 
            // btn_PwrOFF
            // 
            this.btn_PwrOFF.Location = new System.Drawing.Point(8, 139);
            this.btn_PwrOFF.Margin = new System.Windows.Forms.Padding(2);
            this.btn_PwrOFF.Name = "btn_PwrOFF";
            this.btn_PwrOFF.Size = new System.Drawing.Size(74, 22);
            this.btn_PwrOFF.TabIndex = 11;
            this.btn_PwrOFF.Text = "Power OFF";
            this.btn_PwrOFF.UseVisualStyleBackColor = true;
            this.btn_PwrOFF.Click += new System.EventHandler(this.Btn_PwrOFF_Click);
            // 
            // btn_PwrON
            // 
            this.btn_PwrON.Location = new System.Drawing.Point(8, 112);
            this.btn_PwrON.Margin = new System.Windows.Forms.Padding(2);
            this.btn_PwrON.Name = "btn_PwrON";
            this.btn_PwrON.Size = new System.Drawing.Size(74, 22);
            this.btn_PwrON.TabIndex = 10;
            this.btn_PwrON.Text = "Power ON";
            this.btn_PwrON.UseVisualStyleBackColor = true;
            this.btn_PwrON.Click += new System.EventHandler(this.Btn_PwrON_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "PLC instances";
            // 
            // comboBox_PLC_list
            // 
            this.comboBox_PLC_list.FormattingEnabled = true;
            this.comboBox_PLC_list.Location = new System.Drawing.Point(86, 85);
            this.comboBox_PLC_list.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_PLC_list.Name = "comboBox_PLC_list";
            this.comboBox_PLC_list.Size = new System.Drawing.Size(120, 20);
            this.comboBox_PLC_list.TabIndex = 8;
            this.comboBox_PLC_list.SelectedIndexChanged += new System.EventHandler(this.ComboBox_PLC_list_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_save);
            this.groupBox3.Controls.Add(this.trackBar_timeScale);
            this.groupBox3.Controls.Add(this.textBox_timeScale);
            this.groupBox3.Location = new System.Drawing.Point(8, 198);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(355, 74);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time Scaling";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(268, 17);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(74, 22);
            this.btn_save.TabIndex = 17;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // trackBar_timeScale
            // 
            this.trackBar_timeScale.LargeChange = 10;
            this.trackBar_timeScale.Location = new System.Drawing.Point(10, 17);
            this.trackBar_timeScale.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar_timeScale.Maximum = 199;
            this.trackBar_timeScale.Minimum = 1;
            this.trackBar_timeScale.Name = "trackBar_timeScale";
            this.trackBar_timeScale.Size = new System.Drawing.Size(173, 45);
            this.trackBar_timeScale.TabIndex = 15;
            this.trackBar_timeScale.TickFrequency = 20;
            this.trackBar_timeScale.Value = 1;
            this.trackBar_timeScale.Scroll += new System.EventHandler(this.TrackBar_timeScale_Scroll);
            // 
            // textBox_timeScale
            // 
            this.textBox_timeScale.Location = new System.Drawing.Point(188, 17);
            this.textBox_timeScale.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_timeScale.Name = "textBox_timeScale";
            this.textBox_timeScale.Size = new System.Drawing.Size(40, 19);
            this.textBox_timeScale.TabIndex = 16;
            // 
            // listBox_notifications
            // 
            this.listBox_notifications.FormattingEnabled = true;
            this.listBox_notifications.ItemHeight = 12;
            this.listBox_notifications.Location = new System.Drawing.Point(9, 314);
            this.listBox_notifications.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_notifications.Name = "listBox_notifications";
            this.listBox_notifications.Size = new System.Drawing.Size(374, 124);
            this.listBox_notifications.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 299);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Notifications";
            // 
            // TagsGroup
            // 
            this.TagsGroup.Controls.Add(this.textBox_setTagValue);
            this.TagsGroup.Controls.Add(this.label9);
            this.TagsGroup.Controls.Add(this.textBox_tagValue);
            this.TagsGroup.Controls.Add(this.label8);
            this.TagsGroup.Controls.Add(this.label7);
            this.TagsGroup.Controls.Add(this.TagOptionsGroup);
            this.TagsGroup.Controls.Add(this.comboBox_tagList);
            this.TagsGroup.Controls.Add(this.btn_readTag);
            this.TagsGroup.Controls.Add(this.btn_writeTag);
            this.TagsGroup.Location = new System.Drawing.Point(387, 10);
            this.TagsGroup.Margin = new System.Windows.Forms.Padding(2);
            this.TagsGroup.Name = "TagsGroup";
            this.TagsGroup.Padding = new System.Windows.Forms.Padding(2);
            this.TagsGroup.Size = new System.Drawing.Size(334, 160);
            this.TagsGroup.TabIndex = 11;
            this.TagsGroup.TabStop = false;
            this.TagsGroup.Text = "PLC Tag IO access";
            // 
            // textBox_setTagValue
            // 
            this.textBox_setTagValue.Location = new System.Drawing.Point(250, 20);
            this.textBox_setTagValue.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_setTagValue.Name = "textBox_setTagValue";
            this.textBox_setTagValue.Size = new System.Drawing.Size(72, 19);
            this.textBox_setTagValue.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(160, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "Modify tag value:";
            // 
            // textBox_tagValue
            // 
            this.textBox_tagValue.Location = new System.Drawing.Point(163, 42);
            this.textBox_tagValue.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_tagValue.Name = "textBox_tagValue";
            this.textBox_tagValue.Size = new System.Drawing.Size(159, 19);
            this.textBox_tagValue.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "Current Tag info:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "Tag list:";
            // 
            // TagOptionsGroup
            // 
            this.TagOptionsGroup.Controls.Add(this.checkBox_IO);
            this.TagOptionsGroup.Controls.Add(this.checkBox_DBs);
            this.TagOptionsGroup.Controls.Add(this.checkBox_M);
            this.TagOptionsGroup.Controls.Add(this.checkBox_CTs);
            this.TagOptionsGroup.Location = new System.Drawing.Point(4, 88);
            this.TagOptionsGroup.Margin = new System.Windows.Forms.Padding(2);
            this.TagOptionsGroup.Name = "TagOptionsGroup";
            this.TagOptionsGroup.Padding = new System.Windows.Forms.Padding(2);
            this.TagOptionsGroup.Size = new System.Drawing.Size(245, 67);
            this.TagOptionsGroup.TabIndex = 24;
            this.TagOptionsGroup.TabStop = false;
            this.TagOptionsGroup.Text = "Tag Area";
            // 
            // checkBox_IO
            // 
            this.checkBox_IO.AutoSize = true;
            this.checkBox_IO.Location = new System.Drawing.Point(4, 17);
            this.checkBox_IO.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_IO.Name = "checkBox_IO";
            this.checkBox_IO.Size = new System.Drawing.Size(41, 16);
            this.checkBox_IO.TabIndex = 20;
            this.checkBox_IO.Text = "I/O";
            this.checkBox_IO.UseVisualStyleBackColor = true;
            this.checkBox_IO.CheckedChanged += new System.EventHandler(this.CheckBox_IO_CheckedChanged);
            // 
            // checkBox_DBs
            // 
            this.checkBox_DBs.AutoSize = true;
            this.checkBox_DBs.Location = new System.Drawing.Point(109, 37);
            this.checkBox_DBs.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_DBs.Name = "checkBox_DBs";
            this.checkBox_DBs.Size = new System.Drawing.Size(109, 16);
            this.checkBox_DBs.TabIndex = 23;
            this.checkBox_DBs.Text = "DB: Data Blocks";
            this.checkBox_DBs.UseVisualStyleBackColor = true;
            this.checkBox_DBs.CheckedChanged += new System.EventHandler(this.CheckBox_DBs_CheckedChanged);
            // 
            // checkBox_M
            // 
            this.checkBox_M.AutoSize = true;
            this.checkBox_M.Location = new System.Drawing.Point(4, 37);
            this.checkBox_M.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_M.Name = "checkBox_M";
            this.checkBox_M.Size = new System.Drawing.Size(98, 16);
            this.checkBox_M.TabIndex = 21;
            this.checkBox_M.Text = "M: Bit Memory";
            this.checkBox_M.UseVisualStyleBackColor = true;
            this.checkBox_M.CheckedChanged += new System.EventHandler(this.CheckBox_M_CheckedChanged);
            // 
            // checkBox_CTs
            // 
            this.checkBox_CTs.AutoSize = true;
            this.checkBox_CTs.Location = new System.Drawing.Point(109, 17);
            this.checkBox_CTs.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_CTs.Name = "checkBox_CTs";
            this.checkBox_CTs.Size = new System.Drawing.Size(140, 16);
            this.checkBox_CTs.TabIndex = 22;
            this.checkBox_CTs.Text = "CT: Counters n Timers";
            this.checkBox_CTs.UseVisualStyleBackColor = true;
            this.checkBox_CTs.CheckedChanged += new System.EventHandler(this.CheckBox_CTs_CheckedChanged);
            // 
            // comboBox_tagList
            // 
            this.comboBox_tagList.FormattingEnabled = true;
            this.comboBox_tagList.Location = new System.Drawing.Point(4, 65);
            this.comboBox_tagList.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_tagList.Name = "comboBox_tagList";
            this.comboBox_tagList.Size = new System.Drawing.Size(318, 20);
            this.comboBox_tagList.TabIndex = 19;
            this.comboBox_tagList.SelectedIndexChanged += new System.EventHandler(this.ComboBox_tagList_SelectedIndexChanged);
            // 
            // btn_readTag
            // 
            this.btn_readTag.Location = new System.Drawing.Point(4, 17);
            this.btn_readTag.Margin = new System.Windows.Forms.Padding(2);
            this.btn_readTag.Name = "btn_readTag";
            this.btn_readTag.Size = new System.Drawing.Size(74, 22);
            this.btn_readTag.TabIndex = 17;
            this.btn_readTag.Text = "Read Tags";
            this.btn_readTag.UseVisualStyleBackColor = true;
            this.btn_readTag.Click += new System.EventHandler(this.Btn_readTag_Click);
            // 
            // btn_writeTag
            // 
            this.btn_writeTag.Location = new System.Drawing.Point(82, 17);
            this.btn_writeTag.Margin = new System.Windows.Forms.Padding(2);
            this.btn_writeTag.Name = "btn_writeTag";
            this.btn_writeTag.Size = new System.Drawing.Size(74, 22);
            this.btn_writeTag.TabIndex = 18;
            this.btn_writeTag.Text = "Write value";
            this.btn_writeTag.UseVisualStyleBackColor = true;
            this.btn_writeTag.Click += new System.EventHandler(this.Btn_writeTag_Click);
            // 
            // Btn_StartSimulation
            // 
            this.Btn_StartSimulation.Location = new System.Drawing.Point(4, 59);
            this.Btn_StartSimulation.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_StartSimulation.Name = "Btn_StartSimulation";
            this.Btn_StartSimulation.Size = new System.Drawing.Size(74, 42);
            this.Btn_StartSimulation.TabIndex = 18;
            this.Btn_StartSimulation.Text = "Start Simulation";
            this.Btn_StartSimulation.UseVisualStyleBackColor = true;
            this.Btn_StartSimulation.Click += new System.EventHandler(this.Btn_StartSimulation_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Btn_StopSimulation);
            this.groupBox4.Controls.Add(this.textBox_ConfigFilePath);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.btn_BrowseFile);
            this.groupBox4.Controls.Add(this.Btn_StartSimulation);
            this.groupBox4.Location = new System.Drawing.Point(387, 316);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(229, 121);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Simulation";
            // 
            // Btn_StopSimulation
            // 
            this.Btn_StopSimulation.Location = new System.Drawing.Point(85, 59);
            this.Btn_StopSimulation.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_StopSimulation.Name = "Btn_StopSimulation";
            this.Btn_StopSimulation.Size = new System.Drawing.Size(74, 42);
            this.Btn_StopSimulation.TabIndex = 23;
            this.Btn_StopSimulation.Text = "Stop Simulation";
            this.Btn_StopSimulation.UseVisualStyleBackColor = true;
            this.Btn_StopSimulation.Click += new System.EventHandler(this.Btn_StopSimulation_Click);
            // 
            // textBox_ConfigFilePath
            // 
            this.textBox_ConfigFilePath.Location = new System.Drawing.Point(7, 31);
            this.textBox_ConfigFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ConfigFilePath.Name = "textBox_ConfigFilePath";
            this.textBox_ConfigFilePath.Size = new System.Drawing.Size(152, 19);
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
            this.btn_BrowseFile.Location = new System.Drawing.Point(163, 28);
            this.btn_BrowseFile.Margin = new System.Windows.Forms.Padding(2);
            this.btn_BrowseFile.Name = "btn_BrowseFile";
            this.btn_BrowseFile.Size = new System.Drawing.Size(58, 22);
            this.btn_BrowseFile.TabIndex = 18;
            this.btn_BrowseFile.Text = "Browse";
            this.btn_BrowseFile.UseVisualStyleBackColor = true;
            this.btn_BrowseFile.Click += new System.EventHandler(this.Btn_BrowseFile_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_IOAddress);
            this.groupBox5.Controls.Add(this.textBox_addressBit);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.textBox_addressValue);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.comboBox_addressType);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.comboBox_addressArea);
            this.groupBox5.Controls.Add(this.btn_readFromAddress);
            this.groupBox5.Controls.Add(this.btn_writeToAddess);
            this.groupBox5.Location = new System.Drawing.Point(387, 176);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(334, 135);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PLC Address IO access";
            // 
            // textBox_IOAddress
            // 
            this.textBox_IOAddress.Location = new System.Drawing.Point(204, 65);
            this.textBox_IOAddress.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_IOAddress.Name = "textBox_IOAddress";
            this.textBox_IOAddress.Size = new System.Drawing.Size(84, 19);
            this.textBox_IOAddress.TabIndex = 32;
            // 
            // textBox_addressBit
            // 
            this.textBox_addressBit.Location = new System.Drawing.Point(80, 103);
            this.textBox_addressBit.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_addressBit.Name = "textBox_addressBit";
            this.textBox_addressBit.Size = new System.Drawing.Size(72, 19);
            this.textBox_addressBit.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(80, 90);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 12);
            this.label16.TabIndex = 31;
            this.label16.Text = "Bit:";
            // 
            // textBox_addressValue
            // 
            this.textBox_addressValue.Location = new System.Drawing.Point(4, 103);
            this.textBox_addressValue.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_addressValue.Name = "textBox_addressValue";
            this.textBox_addressValue.Size = new System.Drawing.Size(72, 19);
            this.textBox_addressValue.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 90);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 12);
            this.label15.TabIndex = 29;
            this.label15.Text = "Value:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(204, 51);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 12);
            this.label13.TabIndex = 22;
            this.label13.Text = "I/O Address:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(104, 51);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "Type:";
            // 
            // comboBox_addressType
            // 
            this.comboBox_addressType.FormattingEnabled = true;
            this.comboBox_addressType.Location = new System.Drawing.Point(104, 65);
            this.comboBox_addressType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_addressType.Name = "comboBox_addressType";
            this.comboBox_addressType.Size = new System.Drawing.Size(96, 20);
            this.comboBox_addressType.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 51);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 12);
            this.label14.TabIndex = 17;
            this.label14.Text = "Area:";
            // 
            // comboBox_addressArea
            // 
            this.comboBox_addressArea.FormattingEnabled = true;
            this.comboBox_addressArea.Location = new System.Drawing.Point(4, 65);
            this.comboBox_addressArea.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_addressArea.Name = "comboBox_addressArea";
            this.comboBox_addressArea.Size = new System.Drawing.Size(96, 20);
            this.comboBox_addressArea.TabIndex = 19;
            // 
            // btn_readFromAddress
            // 
            this.btn_readFromAddress.Location = new System.Drawing.Point(4, 17);
            this.btn_readFromAddress.Margin = new System.Windows.Forms.Padding(2);
            this.btn_readFromAddress.Name = "btn_readFromAddress";
            this.btn_readFromAddress.Size = new System.Drawing.Size(74, 22);
            this.btn_readFromAddress.TabIndex = 17;
            this.btn_readFromAddress.Text = "Read addr";
            this.btn_readFromAddress.UseVisualStyleBackColor = true;
            this.btn_readFromAddress.Click += new System.EventHandler(this.Btn_readFromAddress_Click);
            // 
            // btn_writeToAddess
            // 
            this.btn_writeToAddess.Location = new System.Drawing.Point(82, 17);
            this.btn_writeToAddess.Margin = new System.Windows.Forms.Padding(2);
            this.btn_writeToAddess.Name = "btn_writeToAddess";
            this.btn_writeToAddess.Size = new System.Drawing.Size(74, 22);
            this.btn_writeToAddess.TabIndex = 18;
            this.btn_writeToAddess.Text = "Write value";
            this.btn_writeToAddess.UseVisualStyleBackColor = true;
            this.btn_writeToAddess.Click += new System.EventHandler(this.Btn_writeToAddess_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.Button_DisconnectCell);
            this.groupBox6.Controls.Add(this.TextBox_ModbusPort);
            this.groupBox6.Controls.Add(this.TextBox_ModbusServerIP);
            this.groupBox6.Controls.Add(this.Button_ConnectCell);
            this.groupBox6.Location = new System.Drawing.Point(621, 316);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(100, 122);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cell connection";
            // 
            // Button_DisconnectCell
            // 
            this.Button_DisconnectCell.Location = new System.Drawing.Point(5, 91);
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
            this.TextBox_ModbusPort.Location = new System.Drawing.Point(5, 40);
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
            this.Button_ConnectCell.Location = new System.Drawing.Point(5, 63);
            this.Button_ConnectCell.Margin = new System.Windows.Forms.Padding(2);
            this.Button_ConnectCell.Name = "Button_ConnectCell";
            this.Button_ConnectCell.Size = new System.Drawing.Size(59, 24);
            this.Button_ConnectCell.TabIndex = 24;
            this.Button_ConnectCell.Text = "Connect";
            this.Button_ConnectCell.UseVisualStyleBackColor = true;
            this.Button_ConnectCell.Click += new System.EventHandler(this.Button_ConnectCell_Click);
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 449);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.TagsGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox_notifications);
            this.Controls.Add(this.PLCgroup);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainInterface";
            this.Text = "Main Interface (CELL ONLY sim)";
            this.PLCgroup.ResumeLayout(false);
            this.PLCgroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_timeScale)).EndInit();
            this.TagsGroup.ResumeLayout(false);
            this.TagsGroup.PerformLayout();
            this.TagOptionsGroup.ResumeLayout(false);
            this.TagOptionsGroup.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_createPLC;
        private System.Windows.Forms.TextBox textBox_PLC_name;
        private System.Windows.Forms.TextBox textBox_PLC_IPaddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_deletePLC;
        private System.Windows.Forms.TextBox textBox_SubnetMask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox PLCgroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Reboot;
        private System.Windows.Forms.Button btn_PwrOFF;
        private System.Windows.Forms.Button btn_PwrON;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_PLC_list;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_connectionType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TrackBar trackBar_timeScale;
        private System.Windows.Forms.TextBox textBox_timeScale;
        private System.Windows.Forms.ListBox listBox_notifications;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_OpState;
        private System.Windows.Forms.Button btn_TCPIP;
        private System.Windows.Forms.Button btn_Local;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Gateway;
        private System.Windows.Forms.GroupBox TagsGroup;
        private System.Windows.Forms.ComboBox comboBox_tagList;
        private System.Windows.Forms.Button btn_readTag;
        private System.Windows.Forms.Button btn_writeTag;
        private System.Windows.Forms.GroupBox TagOptionsGroup;
        private System.Windows.Forms.CheckBox checkBox_IO;
        private System.Windows.Forms.CheckBox checkBox_DBs;
        private System.Windows.Forms.CheckBox checkBox_M;
        private System.Windows.Forms.CheckBox checkBox_CTs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_tagValue;
        private System.Windows.Forms.TextBox textBox_setTagValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Btn_StartSimulation;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_ConfigFilePath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_BrowseFile;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox_addressArea;
        private System.Windows.Forms.Button btn_readFromAddress;
        private System.Windows.Forms.Button btn_writeToAddess;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_addressType;
        private System.Windows.Forms.TextBox textBox_addressBit;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_addressValue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_IOAddress;
        private System.Windows.Forms.Button Btn_StopSimulation;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox TextBox_ModbusPort;
        private System.Windows.Forms.TextBox TextBox_ModbusServerIP;
        private System.Windows.Forms.Button Button_ConnectCell;
        private System.Windows.Forms.Button Button_DisconnectCell;
    }
}

