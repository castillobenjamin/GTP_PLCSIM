namespace PLCSIM_Adv_CoSimulation
{
    partial class CoSimInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoSimInterface));
            this.GroupBox_SafetyBoard_TDWS = new System.Windows.Forms.GroupBox();
            this.CheckBox_SafetyBoard_TDWS = new System.Windows.Forms.CheckBox();
            this.Label_SafetyBoard_TDWS = new System.Windows.Forms.Label();
            this.groupBoxCELL = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBox_BotEvacComplete = new System.Windows.Forms.CheckBox();
            this.RadioButton_SystemIsStartingUp = new System.Windows.Forms.RadioButton();
            this.RadioButton_CanSystemStartUp = new System.Windows.Forms.RadioButton();
            this.CheckBox_IsCellConnectedPulse = new System.Windows.Forms.CheckBox();
            this.Btn_ResetFromCell = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Label_CELLcomm_PlcStatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CheckBox_AllAisles = new System.Windows.Forms.CheckBox();
            this.GroupBox_Door_Aisle = new System.Windows.Forms.GroupBox();
            this.Label_UnlockDoor_Aisle = new System.Windows.Forms.Label();
            this.Label_DoorIsLocked_Aisle = new System.Windows.Forms.Label();
            this.GroupBox_DoorSensor_Aisle = new System.Windows.Forms.GroupBox();
            this.RadioButton_DoorClosed_Aisle = new System.Windows.Forms.RadioButton();
            this.RadioButton_DoorOpen_Aisle = new System.Windows.Forms.RadioButton();
            this.GroupBox_Estop_Aisle = new System.Windows.Forms.GroupBox();
            this.CheckBox_ReqCompleteFlag_Aisle = new System.Windows.Forms.CheckBox();
            this.Label_StopStatus_Aisle = new System.Windows.Forms.Label();
            this.Label_StopRequest_Aisle = new System.Windows.Forms.Label();
            this.GroupBox_SafetyBoard_Aisle = new System.Windows.Forms.GroupBox();
            this.CheckBox_SafetyBoard_AisleSouth = new System.Windows.Forms.CheckBox();
            this.CheckBox_SafetyBoard_AisleNorth = new System.Windows.Forms.CheckBox();
            this.Label_Safety_AisleSouth = new System.Windows.Forms.Label();
            this.Label_SafetyBoard_AisleNorth = new System.Windows.Forms.Label();
            this.GroupBox_Zoning_Aisle = new System.Windows.Forms.GroupBox();
            this.TextBox_ZoningStatus_Aisle = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox_ZoningCellCmd_Aisle = new System.Windows.Forms.GroupBox();
            this.RadioButton_Cancel_Aisle = new System.Windows.Forms.RadioButton();
            this.RadioButton_Permit_Aisle = new System.Windows.Forms.RadioButton();
            this.RadioButton_Run_Aisle = new System.Windows.Forms.RadioButton();
            this.RadioButton_None_Aisle = new System.Windows.Forms.RadioButton();
            this.GroupBox_Contactors_Aisle = new System.Windows.Forms.GroupBox();
            this.Label_ContactorLamp_Aisle = new System.Windows.Forms.Label();
            this.GroupBox_Ctor_AisleSouth = new System.Windows.Forms.GroupBox();
            this.CheckBox_ContactorTripped_AisleSouth = new System.Windows.Forms.CheckBox();
            this.CheckBox_ContactorFdbk_AisleSouth = new System.Windows.Forms.CheckBox();
            this.Label_ContactorFdbk_AisleSouth = new System.Windows.Forms.Label();
            this.CheckBox_ContactorOnOff_AisleSouth = new System.Windows.Forms.CheckBox();
            this.Label_ContactorPlcOut_AisleSouth = new System.Windows.Forms.Label();
            this.CheckBox_FBAuto_Aisle = new System.Windows.Forms.CheckBox();
            this.GroupBox_Ctor_AisleNorth = new System.Windows.Forms.GroupBox();
            this.CheckBox_ContactorTripped_AisleNorth = new System.Windows.Forms.CheckBox();
            this.CheckBox_ContactorFdbk_AisleNorth = new System.Windows.Forms.CheckBox();
            this.Label_ContactorFdbk_AisleNorth = new System.Windows.Forms.Label();
            this.CheckBox_ContactorOnOff_AisleNorth = new System.Windows.Forms.CheckBox();
            this.Label_ContactorPlcOut_AisleNorth = new System.Windows.Forms.Label();
            this.ComboBox_Aisles = new System.Windows.Forms.ComboBox();
            this.GroupBox_OpBox_Aisle = new System.Windows.Forms.GroupBox();
            this.GroupBox_KeySwitch_Aisle = new System.Windows.Forms.GroupBox();
            this.RadioButton_Ready_Aisle = new System.Windows.Forms.RadioButton();
            this.RadioButton_Req_Aisle = new System.Windows.Forms.RadioButton();
            this.Label_OpBoxLed_Aisle = new System.Windows.Forms.Label();
            this.CheckBox_EstopBtn_Aisle = new System.Windows.Forms.CheckBox();
            this.Btn_Reset_Aisle = new System.Windows.Forms.Button();
            this.Btn_Run_Aisle = new System.Windows.Forms.Button();
            this.RadioButton_MaintArea_MaintMode = new System.Windows.Forms.RadioButton();
            this.GroupBox_Stopper = new System.Windows.Forms.GroupBox();
            this.CheckBox_AutoStopper = new System.Windows.Forms.CheckBox();
            this.CheckBox_Alarm_Stopper = new System.Windows.Forms.CheckBox();
            this.ComboBox_Stoppers = new System.Windows.Forms.ComboBox();
            this.Label_TimeOverSignalToCell_Stopper = new System.Windows.Forms.Label();
            this.GroupBox_Q_Stopper = new System.Windows.Forms.GroupBox();
            this.Label_PlcOpenOut_Stopper = new System.Windows.Forms.Label();
            this.Label_PlcCloseOut_Stopper = new System.Windows.Forms.Label();
            this.Label_ErrorSignalToCell_Stopper = new System.Windows.Forms.Label();
            this.Label_IsClosedStatusToCell_Stopper = new System.Windows.Forms.Label();
            this.GroupBox_Sensor_Stopper = new System.Windows.Forms.GroupBox();
            this.CheckBox_IsClosedSensor_Stopper = new System.Windows.Forms.CheckBox();
            this.Label_IsOpenSensor_Stopper = new System.Windows.Forms.Label();
            this.CheckBox_IsOpenSensor_Stopper = new System.Windows.Forms.CheckBox();
            this.Label_IsClosedSensor_Stopper = new System.Windows.Forms.Label();
            this.Label_IsOpenStatusToCell_Stopper = new System.Windows.Forms.Label();
            this.CheckBox_CloseCommandFromCell_Stopper = new System.Windows.Forms.CheckBox();
            this.CheckBox_OpenCommandFromCell_Stopper = new System.Windows.Forms.CheckBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.GroupBox_Door_Deck = new System.Windows.Forms.GroupBox();
            this.Label_UnlockDoor_Deck = new System.Windows.Forms.Label();
            this.Label_DoorIsLocked_Deck = new System.Windows.Forms.Label();
            this.GroupBox_DoorSensor_Deck = new System.Windows.Forms.GroupBox();
            this.RadioButton_DoorClosed_Deck = new System.Windows.Forms.RadioButton();
            this.RadioButton_DoorOpen_Deck = new System.Windows.Forms.RadioButton();
            this.GroupBox_OpBox_Deck = new System.Windows.Forms.GroupBox();
            this.GroupBox_KeySwitch_Deck = new System.Windows.Forms.GroupBox();
            this.RadioButton_Ready_Deck = new System.Windows.Forms.RadioButton();
            this.RadioButton_Req_Deck = new System.Windows.Forms.RadioButton();
            this.Label_OpBoxLed_Deck = new System.Windows.Forms.Label();
            this.CheckBox_EstopBtn_Deck = new System.Windows.Forms.CheckBox();
            this.Btn_Reset_Deck = new System.Windows.Forms.Button();
            this.Btn_Run_Deck = new System.Windows.Forms.Button();
            this.GroupBox_Estop_Deck = new System.Windows.Forms.GroupBox();
            this.CheckBox_ReqCompleteFlag_Deck = new System.Windows.Forms.CheckBox();
            this.Label_StopStatus_Deck = new System.Windows.Forms.Label();
            this.Label_StopRequest_Deck = new System.Windows.Forms.Label();
            this.CheckBox_AllDecks = new System.Windows.Forms.CheckBox();
            this.groupBox_Zoning_Deck = new System.Windows.Forms.GroupBox();
            this.TextBox_ZoningStatus_Deck = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox_ZoningCellCmd_Deck = new System.Windows.Forms.GroupBox();
            this.RadioButton_Cancel_Deck = new System.Windows.Forms.RadioButton();
            this.RadioButton_Permit_Deck = new System.Windows.Forms.RadioButton();
            this.RadioButton_Run_Deck = new System.Windows.Forms.RadioButton();
            this.RadioButton_None_Deck = new System.Windows.Forms.RadioButton();
            this.ComboBox_Decks = new System.Windows.Forms.ComboBox();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.Label_LedTowerWhite_DwsPanel = new System.Windows.Forms.Label();
            this.Label_LedTowerGreen_DwsPanel = new System.Windows.Forms.Label();
            this.Label_LedTowerYellow_DwsPanel = new System.Windows.Forms.Label();
            this.Label_LedTowerBlue_DwsPanel = new System.Windows.Forms.Label();
            this.CheckBox_EstopBtn_DwsPanel = new System.Windows.Forms.CheckBox();
            this.Btn_Reset_DwsPanel = new System.Windows.Forms.Button();
            this.Label_LedTowerRed_DwsPanel = new System.Windows.Forms.Label();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.Btn_Reset_NorthPanel = new System.Windows.Forms.Button();
            this.Label_LedTower_NorthPanel = new System.Windows.Forms.Label();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.Label_LedTower_SouthPanel = new System.Windows.Forms.Label();
            this.GroupBox_MaintArea = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Label_MaintenanceStatus = new System.Windows.Forms.Label();
            this.GroupBox_ = new System.Windows.Forms.GroupBox();
            this.RadioButton_MaintArea_AisleMode = new System.Windows.Forms.RadioButton();
            this.GroupBox_Ctor_MaintArea = new System.Windows.Forms.GroupBox();
            this.CheckBox_ContactorFdbk_MaintArea = new System.Windows.Forms.CheckBox();
            this.Label_ContactorFdbk_MaintArea = new System.Windows.Forms.Label();
            this.Label_ContactorPlcOut_MaintArea = new System.Windows.Forms.Label();
            this.Label_BotHPtoCell = new System.Windows.Forms.Label();
            this.CheckBox_BOT_HP = new System.Windows.Forms.CheckBox();
            this.GroupBox_Panels = new System.Windows.Forms.GroupBox();
            this.Btn_BuzzerAck = new System.Windows.Forms.Button();
            this.ListBox_Log = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.GroupBox_Door_TDWS = new System.Windows.Forms.GroupBox();
            this.Label_UnlockDoor_TDWS = new System.Windows.Forms.Label();
            this.Label_DoorIsLocked_TDWS = new System.Windows.Forms.Label();
            this.GroupBox_DoorSensor_TDWS = new System.Windows.Forms.GroupBox();
            this.RadioButton_DoorClosed_TDWS = new System.Windows.Forms.RadioButton();
            this.RadioButton_DoorOpen_TDWS = new System.Windows.Forms.RadioButton();
            this.CheckBox_AllTDWSs = new System.Windows.Forms.CheckBox();
            this.ComboBox_TowerDWS = new System.Windows.Forms.ComboBox();
            this.GroupBox_Estop_TDWS = new System.Windows.Forms.GroupBox();
            this.CheckBox_ReqCompleteFlag_TDWS = new System.Windows.Forms.CheckBox();
            this.Label_StopStatus_TDWS = new System.Windows.Forms.Label();
            this.Label_StopRequest_TDWS = new System.Windows.Forms.Label();
            this.GroupBox_OpBox_TDWS = new System.Windows.Forms.GroupBox();
            this.GroupBox_KeySwitch_TDWS = new System.Windows.Forms.GroupBox();
            this.RadioButton_Ready_TDWS = new System.Windows.Forms.RadioButton();
            this.RadioButton_Req_TDWS = new System.Windows.Forms.RadioButton();
            this.Label_OpBoxLed_TDWS = new System.Windows.Forms.Label();
            this.CheckBox_EstopBtn_TDWS = new System.Windows.Forms.CheckBox();
            this.Btn_Reset_TDWS = new System.Windows.Forms.Button();
            this.Btn_Run_TDWS = new System.Windows.Forms.Button();
            this.GroupBox_Contactors_TDWS = new System.Windows.Forms.GroupBox();
            this.Label_ContactorLamp_TDWS = new System.Windows.Forms.Label();
            this.GroupBox_Ctor_TDWStower = new System.Windows.Forms.GroupBox();
            this.CheckBox_ContactorTripped_TDWStower = new System.Windows.Forms.CheckBox();
            this.CheckBox_ContactorFdbk_TDWStower = new System.Windows.Forms.CheckBox();
            this.Label_ContactorFdbk_TDWStower = new System.Windows.Forms.Label();
            this.CheckBox_ContactorOnOff_TDWStower = new System.Windows.Forms.CheckBox();
            this.Label_ContactorPlcOut_TDWStower = new System.Windows.Forms.Label();
            this.CheckBox_FBAuto_TDWS = new System.Windows.Forms.CheckBox();
            this.GroupBox_Ctor_TDWSpick = new System.Windows.Forms.GroupBox();
            this.CheckBox_ContactorTripped_TDWSpick = new System.Windows.Forms.CheckBox();
            this.CheckBox_ContactorFdbk_TDWSpick = new System.Windows.Forms.CheckBox();
            this.Label_ContactorFdbk_TDWSpick = new System.Windows.Forms.Label();
            this.CheckBox_ContactorOnOff_TDWSpick = new System.Windows.Forms.CheckBox();
            this.Label_ContactorPlcOut_TDWSpick = new System.Windows.Forms.Label();
            this.GroupBox_ZoningTDWS = new System.Windows.Forms.GroupBox();
            this.TextBox_ZoningStatus_TDWS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GroupBox_ZoningCellCmd_TDWS = new System.Windows.Forms.GroupBox();
            this.RadioButton_Cancel_TDWS = new System.Windows.Forms.RadioButton();
            this.RadioButton_Permit_TDWS = new System.Windows.Forms.RadioButton();
            this.RadioButton_Run_TDWS = new System.Windows.Forms.RadioButton();
            this.RadioButton_None_TDWS = new System.Windows.Forms.RadioButton();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.CheckBox_FBAuto_SmallAisle = new System.Windows.Forms.CheckBox();
            this.GroupBox_Estop_SmallAisle = new System.Windows.Forms.GroupBox();
            this.CheckBox_ReqCompleteFlag_SmallAisle = new System.Windows.Forms.CheckBox();
            this.Label_StopStatus_SmallAisle = new System.Windows.Forms.Label();
            this.Label_StopRequest_SmallAisle = new System.Windows.Forms.Label();
            this.GroupBox_Ctor_SmallAisle = new System.Windows.Forms.GroupBox();
            this.CheckBox_ContactorTripped_SmallAisle = new System.Windows.Forms.CheckBox();
            this.CheckBox_ContactorFdbk_SmallAisle = new System.Windows.Forms.CheckBox();
            this.Label_ContactorFdbk_SmallAisle = new System.Windows.Forms.Label();
            this.CheckBox_ContactorOnOff_SmallAisle = new System.Windows.Forms.CheckBox();
            this.Label_ContactorPlcOut_SmallAisle = new System.Windows.Forms.Label();
            this.GroupBox_OpBox_SmallAisle = new System.Windows.Forms.GroupBox();
            this.GroupBox_KeySwitch_SmallAisle = new System.Windows.Forms.GroupBox();
            this.RadioButton_Ready_SmallAisle = new System.Windows.Forms.RadioButton();
            this.RadioButton_Req_SmallAisle = new System.Windows.Forms.RadioButton();
            this.Label_OpBoxLed_SmallAisle = new System.Windows.Forms.Label();
            this.CheckBox_EstopBtn_SmallAisle = new System.Windows.Forms.CheckBox();
            this.Btn_Reset_SmallAisle = new System.Windows.Forms.Button();
            this.Btn_Run_SmallAisle = new System.Windows.Forms.Button();
            this.CheckBox_AllSmallAisles = new System.Windows.Forms.CheckBox();
            this.ComboBox_SmallAisle = new System.Windows.Forms.ComboBox();
            this.GroupBox_Zoning_SmallAisle = new System.Windows.Forms.GroupBox();
            this.TextBox_ZoningStatus_SmallAisle = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.GroupBox_ZoningCellCmd_SmallAisle = new System.Windows.Forms.GroupBox();
            this.RadioButton_Cancel_SmallAisle = new System.Windows.Forms.RadioButton();
            this.RadioButton_Permit_SmallAisle = new System.Windows.Forms.RadioButton();
            this.RadioButton_Run_SmallAisle = new System.Windows.Forms.RadioButton();
            this.RadioButton_None_SmallAisle = new System.Windows.Forms.RadioButton();
            this.GroupBox_BOT = new System.Windows.Forms.GroupBox();
            this.ComboBox_Bots = new System.Windows.Forms.ComboBox();
            this.Label_IsEstop_Bot = new System.Windows.Forms.Label();
            this.Label_IsFault_Bot = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.CheckBox_Estop_BOT = new System.Windows.Forms.CheckBox();
            this.CheckBox_FireAlarm = new System.Windows.Forms.CheckBox();
            this.GroupBox_SafetyBoard_TDWS.SuspendLayout();
            this.groupBoxCELL.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GroupBox_Door_Aisle.SuspendLayout();
            this.GroupBox_DoorSensor_Aisle.SuspendLayout();
            this.GroupBox_Estop_Aisle.SuspendLayout();
            this.GroupBox_SafetyBoard_Aisle.SuspendLayout();
            this.GroupBox_Zoning_Aisle.SuspendLayout();
            this.groupBox_ZoningCellCmd_Aisle.SuspendLayout();
            this.GroupBox_Contactors_Aisle.SuspendLayout();
            this.GroupBox_Ctor_AisleSouth.SuspendLayout();
            this.GroupBox_Ctor_AisleNorth.SuspendLayout();
            this.GroupBox_OpBox_Aisle.SuspendLayout();
            this.GroupBox_KeySwitch_Aisle.SuspendLayout();
            this.GroupBox_Stopper.SuspendLayout();
            this.GroupBox_Q_Stopper.SuspendLayout();
            this.GroupBox_Sensor_Stopper.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.GroupBox_Door_Deck.SuspendLayout();
            this.GroupBox_DoorSensor_Deck.SuspendLayout();
            this.GroupBox_OpBox_Deck.SuspendLayout();
            this.GroupBox_KeySwitch_Deck.SuspendLayout();
            this.GroupBox_Estop_Deck.SuspendLayout();
            this.groupBox_Zoning_Deck.SuspendLayout();
            this.groupBox_ZoningCellCmd_Deck.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox36.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.GroupBox_MaintArea.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.GroupBox_.SuspendLayout();
            this.GroupBox_Ctor_MaintArea.SuspendLayout();
            this.GroupBox_Panels.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.GroupBox_Door_TDWS.SuspendLayout();
            this.GroupBox_DoorSensor_TDWS.SuspendLayout();
            this.GroupBox_Estop_TDWS.SuspendLayout();
            this.GroupBox_OpBox_TDWS.SuspendLayout();
            this.GroupBox_KeySwitch_TDWS.SuspendLayout();
            this.GroupBox_Contactors_TDWS.SuspendLayout();
            this.GroupBox_Ctor_TDWStower.SuspendLayout();
            this.GroupBox_Ctor_TDWSpick.SuspendLayout();
            this.GroupBox_ZoningTDWS.SuspendLayout();
            this.GroupBox_ZoningCellCmd_TDWS.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.GroupBox_Estop_SmallAisle.SuspendLayout();
            this.GroupBox_Ctor_SmallAisle.SuspendLayout();
            this.GroupBox_OpBox_SmallAisle.SuspendLayout();
            this.GroupBox_KeySwitch_SmallAisle.SuspendLayout();
            this.GroupBox_Zoning_SmallAisle.SuspendLayout();
            this.GroupBox_ZoningCellCmd_SmallAisle.SuspendLayout();
            this.GroupBox_BOT.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox_SafetyBoard_TDWS
            // 
            this.GroupBox_SafetyBoard_TDWS.Controls.Add(this.CheckBox_SafetyBoard_TDWS);
            this.GroupBox_SafetyBoard_TDWS.Controls.Add(this.Label_SafetyBoard_TDWS);
            this.GroupBox_SafetyBoard_TDWS.Location = new System.Drawing.Point(137, 329);
            this.GroupBox_SafetyBoard_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_SafetyBoard_TDWS.Name = "GroupBox_SafetyBoard_TDWS";
            this.GroupBox_SafetyBoard_TDWS.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_SafetyBoard_TDWS.Size = new System.Drawing.Size(129, 46);
            this.GroupBox_SafetyBoard_TDWS.TabIndex = 32;
            this.GroupBox_SafetyBoard_TDWS.TabStop = false;
            this.GroupBox_SafetyBoard_TDWS.Text = "足場板";
            // 
            // CheckBox_SafetyBoard_TDWS
            // 
            this.CheckBox_SafetyBoard_TDWS.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_SafetyBoard_TDWS.AutoSize = true;
            this.CheckBox_SafetyBoard_TDWS.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_SafetyBoard_TDWS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_SafetyBoard_TDWS.Location = new System.Drawing.Point(4, 16);
            this.CheckBox_SafetyBoard_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_SafetyBoard_TDWS.Name = "CheckBox_SafetyBoard_TDWS";
            this.CheckBox_SafetyBoard_TDWS.Size = new System.Drawing.Size(46, 22);
            this.CheckBox_SafetyBoard_TDWS.TabIndex = 10;
            this.CheckBox_SafetyBoard_TDWS.Text = "Tower";
            this.CheckBox_SafetyBoard_TDWS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_SafetyBoard_TDWS.UseVisualStyleBackColor = true;
            this.CheckBox_SafetyBoard_TDWS.CheckedChanged += new System.EventHandler(this.CheckBox_SafetyBoard_TDWS_CheckedChanged);
            // 
            // Label_SafetyBoard_TDWS
            // 
            this.Label_SafetyBoard_TDWS.AutoSize = true;
            this.Label_SafetyBoard_TDWS.Location = new System.Drawing.Point(65, 22);
            this.Label_SafetyBoard_TDWS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_SafetyBoard_TDWS.Name = "Label_SafetyBoard_TDWS";
            this.Label_SafetyBoard_TDWS.Size = new System.Drawing.Size(23, 12);
            this.Label_SafetyBoard_TDWS.TabIndex = 10;
            this.Label_SafetyBoard_TDWS.Text = "---";
            // 
            // groupBoxCELL
            // 
            this.groupBoxCELL.Controls.Add(this.groupBox1);
            this.groupBoxCELL.Controls.Add(this.groupBox2);
            this.groupBoxCELL.Location = new System.Drawing.Point(9, 10);
            this.groupBoxCELL.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxCELL.Name = "groupBoxCELL";
            this.groupBoxCELL.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxCELL.Size = new System.Drawing.Size(138, 179);
            this.groupBoxCELL.TabIndex = 0;
            this.groupBoxCELL.TabStop = false;
            this.groupBoxCELL.Text = "CELL comm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckBox_BotEvacComplete);
            this.groupBox1.Controls.Add(this.RadioButton_SystemIsStartingUp);
            this.groupBox1.Controls.Add(this.RadioButton_CanSystemStartUp);
            this.groupBox1.Controls.Add(this.CheckBox_IsCellConnectedPulse);
            this.groupBox1.Controls.Add(this.Btn_ResetFromCell);
            this.groupBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Location = new System.Drawing.Point(4, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(130, 115);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CELL";
            // 
            // CheckBox_BotEvacComplete
            // 
            this.CheckBox_BotEvacComplete.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_BotEvacComplete.AutoSize = true;
            this.CheckBox_BotEvacComplete.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_BotEvacComplete.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.CheckBox_BotEvacComplete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_BotEvacComplete.Location = new System.Drawing.Point(61, 16);
            this.CheckBox_BotEvacComplete.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_BotEvacComplete.Name = "CheckBox_BotEvacComplete";
            this.CheckBox_BotEvacComplete.Size = new System.Drawing.Size(63, 22);
            this.CheckBox_BotEvacComplete.TabIndex = 3;
            this.CheckBox_BotEvacComplete.Text = "退避完了";
            this.CheckBox_BotEvacComplete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_BotEvacComplete.UseVisualStyleBackColor = true;
            this.CheckBox_BotEvacComplete.CheckedChanged += new System.EventHandler(this.CheckBox_BotEvacComplete_CheckedChanged);
            // 
            // RadioButton_SystemIsStartingUp
            // 
            this.RadioButton_SystemIsStartingUp.AutoSize = true;
            this.RadioButton_SystemIsStartingUp.Location = new System.Drawing.Point(4, 90);
            this.RadioButton_SystemIsStartingUp.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_SystemIsStartingUp.Name = "RadioButton_SystemIsStartingUp";
            this.RadioButton_SystemIsStartingUp.Size = new System.Drawing.Size(59, 16);
            this.RadioButton_SystemIsStartingUp.TabIndex = 2;
            this.RadioButton_SystemIsStartingUp.TabStop = true;
            this.RadioButton_SystemIsStartingUp.Text = "起動中";
            this.RadioButton_SystemIsStartingUp.UseVisualStyleBackColor = true;
            this.RadioButton_SystemIsStartingUp.CheckedChanged += new System.EventHandler(this.RadioButton_SystemIsStartingUp_CheckedChanged);
            // 
            // RadioButton_CanSystemStartUp
            // 
            this.RadioButton_CanSystemStartUp.AutoSize = true;
            this.RadioButton_CanSystemStartUp.Location = new System.Drawing.Point(4, 70);
            this.RadioButton_CanSystemStartUp.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_CanSystemStartUp.Name = "RadioButton_CanSystemStartUp";
            this.RadioButton_CanSystemStartUp.Size = new System.Drawing.Size(59, 16);
            this.RadioButton_CanSystemStartUp.TabIndex = 1;
            this.RadioButton_CanSystemStartUp.TabStop = true;
            this.RadioButton_CanSystemStartUp.Text = "起動可";
            this.RadioButton_CanSystemStartUp.UseVisualStyleBackColor = true;
            this.RadioButton_CanSystemStartUp.CheckedChanged += new System.EventHandler(this.RadioButton_CanSystemStartUp_CheckedChanged);
            // 
            // CheckBox_IsCellConnectedPulse
            // 
            this.CheckBox_IsCellConnectedPulse.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_IsCellConnectedPulse.AutoSize = true;
            this.CheckBox_IsCellConnectedPulse.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_IsCellConnectedPulse.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.CheckBox_IsCellConnectedPulse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_IsCellConnectedPulse.Location = new System.Drawing.Point(4, 17);
            this.CheckBox_IsCellConnectedPulse.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_IsCellConnectedPulse.Name = "CheckBox_IsCellConnectedPulse";
            this.CheckBox_IsCellConnectedPulse.Size = new System.Drawing.Size(39, 22);
            this.CheckBox_IsCellConnectedPulse.TabIndex = 1;
            this.CheckBox_IsCellConnectedPulse.Text = "生存";
            this.CheckBox_IsCellConnectedPulse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_IsCellConnectedPulse.UseVisualStyleBackColor = true;
            this.CheckBox_IsCellConnectedPulse.CheckedChanged += new System.EventHandler(this.CheckBox_IsCellConnectedPulse_CheckedChanged);
            // 
            // Btn_ResetFromCell
            // 
            this.Btn_ResetFromCell.Location = new System.Drawing.Point(4, 42);
            this.Btn_ResetFromCell.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_ResetFromCell.Name = "Btn_ResetFromCell";
            this.Btn_ResetFromCell.Size = new System.Drawing.Size(44, 24);
            this.Btn_ResetFromCell.TabIndex = 1;
            this.Btn_ResetFromCell.Text = "Reset";
            this.Btn_ResetFromCell.UseVisualStyleBackColor = true;
            this.Btn_ResetFromCell.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_ResetFromCell_MouseDown);
            this.Btn_ResetFromCell.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_ResetFromCell_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Label_CELLcomm_PlcStatus);
            this.groupBox2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox2.Location = new System.Drawing.Point(4, 136);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(86, 33);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PLC";
            // 
            // Label_CELLcomm_PlcStatus
            // 
            this.Label_CELLcomm_PlcStatus.AutoSize = true;
            this.Label_CELLcomm_PlcStatus.Location = new System.Drawing.Point(4, 14);
            this.Label_CELLcomm_PlcStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_CELLcomm_PlcStatus.Name = "Label_CELLcomm_PlcStatus";
            this.Label_CELLcomm_PlcStatus.Size = new System.Drawing.Size(23, 12);
            this.Label_CELLcomm_PlcStatus.TabIndex = 2;
            this.Label_CELLcomm_PlcStatus.Text = "---";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.CheckBox_AllAisles);
            this.groupBox3.Controls.Add(this.GroupBox_Door_Aisle);
            this.groupBox3.Controls.Add(this.GroupBox_Estop_Aisle);
            this.groupBox3.Controls.Add(this.GroupBox_SafetyBoard_Aisle);
            this.groupBox3.Controls.Add(this.GroupBox_Zoning_Aisle);
            this.groupBox3.Controls.Add(this.GroupBox_Contactors_Aisle);
            this.groupBox3.Controls.Add(this.ComboBox_Aisles);
            this.groupBox3.Controls.Add(this.GroupBox_OpBox_Aisle);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(151, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(271, 564);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AISLE";
            // 
            // CheckBox_AllAisles
            // 
            this.CheckBox_AllAisles.AutoSize = true;
            this.CheckBox_AllAisles.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBox_AllAisles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckBox_AllAisles.Location = new System.Drawing.Point(126, 17);
            this.CheckBox_AllAisles.Name = "CheckBox_AllAisles";
            this.CheckBox_AllAisles.Size = new System.Drawing.Size(84, 16);
            this.CheckBox_AllAisles.TabIndex = 37;
            this.CheckBox_AllAisles.Text = "All Aisles";
            this.CheckBox_AllAisles.UseVisualStyleBackColor = true;
            this.CheckBox_AllAisles.CheckedChanged += new System.EventHandler(this.CheckBox_AllAisles_CheckedChanged);
            // 
            // GroupBox_Door_Aisle
            // 
            this.GroupBox_Door_Aisle.Controls.Add(this.Label_UnlockDoor_Aisle);
            this.GroupBox_Door_Aisle.Controls.Add(this.Label_DoorIsLocked_Aisle);
            this.GroupBox_Door_Aisle.Controls.Add(this.GroupBox_DoorSensor_Aisle);
            this.GroupBox_Door_Aisle.Location = new System.Drawing.Point(137, 236);
            this.GroupBox_Door_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Door_Aisle.Name = "GroupBox_Door_Aisle";
            this.GroupBox_Door_Aisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Door_Aisle.Size = new System.Drawing.Size(129, 88);
            this.GroupBox_Door_Aisle.TabIndex = 27;
            this.GroupBox_Door_Aisle.TabStop = false;
            this.GroupBox_Door_Aisle.Text = "扉";
            // 
            // Label_UnlockDoor_Aisle
            // 
            this.Label_UnlockDoor_Aisle.AutoSize = true;
            this.Label_UnlockDoor_Aisle.Location = new System.Drawing.Point(50, 61);
            this.Label_UnlockDoor_Aisle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_UnlockDoor_Aisle.Name = "Label_UnlockDoor_Aisle";
            this.Label_UnlockDoor_Aisle.Size = new System.Drawing.Size(23, 12);
            this.Label_UnlockDoor_Aisle.TabIndex = 31;
            this.Label_UnlockDoor_Aisle.Text = "---";
            // 
            // Label_DoorIsLocked_Aisle
            // 
            this.Label_DoorIsLocked_Aisle.AutoSize = true;
            this.Label_DoorIsLocked_Aisle.Location = new System.Drawing.Point(4, 61);
            this.Label_DoorIsLocked_Aisle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_DoorIsLocked_Aisle.Name = "Label_DoorIsLocked_Aisle";
            this.Label_DoorIsLocked_Aisle.Size = new System.Drawing.Size(23, 12);
            this.Label_DoorIsLocked_Aisle.TabIndex = 30;
            this.Label_DoorIsLocked_Aisle.Text = "---";
            // 
            // GroupBox_DoorSensor_Aisle
            // 
            this.GroupBox_DoorSensor_Aisle.Controls.Add(this.RadioButton_DoorClosed_Aisle);
            this.GroupBox_DoorSensor_Aisle.Controls.Add(this.RadioButton_DoorOpen_Aisle);
            this.GroupBox_DoorSensor_Aisle.Location = new System.Drawing.Point(4, 17);
            this.GroupBox_DoorSensor_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_DoorSensor_Aisle.Name = "GroupBox_DoorSensor_Aisle";
            this.GroupBox_DoorSensor_Aisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_DoorSensor_Aisle.Size = new System.Drawing.Size(82, 40);
            this.GroupBox_DoorSensor_Aisle.TabIndex = 29;
            this.GroupBox_DoorSensor_Aisle.TabStop = false;
            this.GroupBox_DoorSensor_Aisle.Text = "Sensor";
            // 
            // RadioButton_DoorClosed_Aisle
            // 
            this.RadioButton_DoorClosed_Aisle.AutoSize = true;
            this.RadioButton_DoorClosed_Aisle.Location = new System.Drawing.Point(41, 18);
            this.RadioButton_DoorClosed_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_DoorClosed_Aisle.Name = "RadioButton_DoorClosed_Aisle";
            this.RadioButton_DoorClosed_Aisle.Size = new System.Drawing.Size(35, 16);
            this.RadioButton_DoorClosed_Aisle.TabIndex = 7;
            this.RadioButton_DoorClosed_Aisle.TabStop = true;
            this.RadioButton_DoorClosed_Aisle.Text = "閉";
            this.RadioButton_DoorClosed_Aisle.UseVisualStyleBackColor = true;
            this.RadioButton_DoorClosed_Aisle.CheckedChanged += new System.EventHandler(this.RadioButton_DoorClosed_Aisle_CheckedChanged);
            // 
            // RadioButton_DoorOpen_Aisle
            // 
            this.RadioButton_DoorOpen_Aisle.AutoSize = true;
            this.RadioButton_DoorOpen_Aisle.Location = new System.Drawing.Point(4, 17);
            this.RadioButton_DoorOpen_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_DoorOpen_Aisle.Name = "RadioButton_DoorOpen_Aisle";
            this.RadioButton_DoorOpen_Aisle.Size = new System.Drawing.Size(35, 16);
            this.RadioButton_DoorOpen_Aisle.TabIndex = 6;
            this.RadioButton_DoorOpen_Aisle.TabStop = true;
            this.RadioButton_DoorOpen_Aisle.Text = "開";
            this.RadioButton_DoorOpen_Aisle.UseVisualStyleBackColor = true;
            this.RadioButton_DoorOpen_Aisle.CheckedChanged += new System.EventHandler(this.RadioButton_DoorOpen_Aisle_CheckedChanged);
            // 
            // GroupBox_Estop_Aisle
            // 
            this.GroupBox_Estop_Aisle.Controls.Add(this.CheckBox_ReqCompleteFlag_Aisle);
            this.GroupBox_Estop_Aisle.Controls.Add(this.Label_StopStatus_Aisle);
            this.GroupBox_Estop_Aisle.Controls.Add(this.Label_StopRequest_Aisle);
            this.GroupBox_Estop_Aisle.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBox_Estop_Aisle.Location = new System.Drawing.Point(137, 166);
            this.GroupBox_Estop_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Estop_Aisle.Name = "GroupBox_Estop_Aisle";
            this.GroupBox_Estop_Aisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Estop_Aisle.Size = new System.Drawing.Size(96, 66);
            this.GroupBox_Estop_Aisle.TabIndex = 21;
            this.GroupBox_Estop_Aisle.TabStop = false;
            this.GroupBox_Estop_Aisle.Text = "非常停止";
            // 
            // CheckBox_ReqCompleteFlag_Aisle
            // 
            this.CheckBox_ReqCompleteFlag_Aisle.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ReqCompleteFlag_Aisle.AutoSize = true;
            this.CheckBox_ReqCompleteFlag_Aisle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ReqCompleteFlag_Aisle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ReqCompleteFlag_Aisle.Location = new System.Drawing.Point(8, 20);
            this.CheckBox_ReqCompleteFlag_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ReqCompleteFlag_Aisle.Name = "CheckBox_ReqCompleteFlag_Aisle";
            this.CheckBox_ReqCompleteFlag_Aisle.Size = new System.Drawing.Size(39, 22);
            this.CheckBox_ReqCompleteFlag_Aisle.TabIndex = 10;
            this.CheckBox_ReqCompleteFlag_Aisle.Text = "完了";
            this.CheckBox_ReqCompleteFlag_Aisle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ReqCompleteFlag_Aisle.UseVisualStyleBackColor = true;
            this.CheckBox_ReqCompleteFlag_Aisle.CheckedChanged += new System.EventHandler(this.CheckBox_ReqCompleteFlag_Aisle_CheckedChanged);
            // 
            // Label_StopStatus_Aisle
            // 
            this.Label_StopStatus_Aisle.AutoSize = true;
            this.Label_StopStatus_Aisle.Location = new System.Drawing.Point(54, 34);
            this.Label_StopStatus_Aisle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_StopStatus_Aisle.Name = "Label_StopStatus_Aisle";
            this.Label_StopStatus_Aisle.Size = new System.Drawing.Size(29, 12);
            this.Label_StopStatus_Aisle.TabIndex = 20;
            this.Label_StopStatus_Aisle.Text = "状態";
            // 
            // Label_StopRequest_Aisle
            // 
            this.Label_StopRequest_Aisle.AutoSize = true;
            this.Label_StopRequest_Aisle.Location = new System.Drawing.Point(54, 14);
            this.Label_StopRequest_Aisle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_StopRequest_Aisle.Name = "Label_StopRequest_Aisle";
            this.Label_StopRequest_Aisle.Size = new System.Drawing.Size(29, 12);
            this.Label_StopRequest_Aisle.TabIndex = 18;
            this.Label_StopRequest_Aisle.Text = "要求";
            // 
            // GroupBox_SafetyBoard_Aisle
            // 
            this.GroupBox_SafetyBoard_Aisle.Controls.Add(this.CheckBox_SafetyBoard_AisleSouth);
            this.GroupBox_SafetyBoard_Aisle.Controls.Add(this.CheckBox_SafetyBoard_AisleNorth);
            this.GroupBox_SafetyBoard_Aisle.Controls.Add(this.Label_Safety_AisleSouth);
            this.GroupBox_SafetyBoard_Aisle.Controls.Add(this.Label_SafetyBoard_AisleNorth);
            this.GroupBox_SafetyBoard_Aisle.Location = new System.Drawing.Point(137, 328);
            this.GroupBox_SafetyBoard_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_SafetyBoard_Aisle.Name = "GroupBox_SafetyBoard_Aisle";
            this.GroupBox_SafetyBoard_Aisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_SafetyBoard_Aisle.Size = new System.Drawing.Size(129, 68);
            this.GroupBox_SafetyBoard_Aisle.TabIndex = 15;
            this.GroupBox_SafetyBoard_Aisle.TabStop = false;
            this.GroupBox_SafetyBoard_Aisle.Text = "足場板";
            // 
            // CheckBox_SafetyBoard_AisleSouth
            // 
            this.CheckBox_SafetyBoard_AisleSouth.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_SafetyBoard_AisleSouth.AutoSize = true;
            this.CheckBox_SafetyBoard_AisleSouth.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_SafetyBoard_AisleSouth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_SafetyBoard_AisleSouth.Location = new System.Drawing.Point(4, 42);
            this.CheckBox_SafetyBoard_AisleSouth.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_SafetyBoard_AisleSouth.Name = "CheckBox_SafetyBoard_AisleSouth";
            this.CheckBox_SafetyBoard_AisleSouth.Size = new System.Drawing.Size(53, 22);
            this.CheckBox_SafetyBoard_AisleSouth.TabIndex = 11;
            this.CheckBox_SafetyBoard_AisleSouth.Text = "SOUTH";
            this.CheckBox_SafetyBoard_AisleSouth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_SafetyBoard_AisleSouth.UseVisualStyleBackColor = true;
            this.CheckBox_SafetyBoard_AisleSouth.CheckedChanged += new System.EventHandler(this.CheckBox_SafetyBoard_AisleSouth_CheckedChanged);
            // 
            // CheckBox_SafetyBoard_AisleNorth
            // 
            this.CheckBox_SafetyBoard_AisleNorth.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_SafetyBoard_AisleNorth.AutoSize = true;
            this.CheckBox_SafetyBoard_AisleNorth.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_SafetyBoard_AisleNorth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_SafetyBoard_AisleNorth.Location = new System.Drawing.Point(4, 16);
            this.CheckBox_SafetyBoard_AisleNorth.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_SafetyBoard_AisleNorth.Name = "CheckBox_SafetyBoard_AisleNorth";
            this.CheckBox_SafetyBoard_AisleNorth.Size = new System.Drawing.Size(54, 22);
            this.CheckBox_SafetyBoard_AisleNorth.TabIndex = 10;
            this.CheckBox_SafetyBoard_AisleNorth.Text = "NORTH";
            this.CheckBox_SafetyBoard_AisleNorth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_SafetyBoard_AisleNorth.UseVisualStyleBackColor = true;
            this.CheckBox_SafetyBoard_AisleNorth.CheckedChanged += new System.EventHandler(this.CheckBox_SafetyBoard_AisleNorth_CheckedChanged);
            // 
            // Label_Safety_AisleSouth
            // 
            this.Label_Safety_AisleSouth.AutoSize = true;
            this.Label_Safety_AisleSouth.Location = new System.Drawing.Point(65, 47);
            this.Label_Safety_AisleSouth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Safety_AisleSouth.Name = "Label_Safety_AisleSouth";
            this.Label_Safety_AisleSouth.Size = new System.Drawing.Size(23, 12);
            this.Label_Safety_AisleSouth.TabIndex = 12;
            this.Label_Safety_AisleSouth.Text = "---";
            // 
            // Label_SafetyBoard_AisleNorth
            // 
            this.Label_SafetyBoard_AisleNorth.AutoSize = true;
            this.Label_SafetyBoard_AisleNorth.Location = new System.Drawing.Point(65, 22);
            this.Label_SafetyBoard_AisleNorth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_SafetyBoard_AisleNorth.Name = "Label_SafetyBoard_AisleNorth";
            this.Label_SafetyBoard_AisleNorth.Size = new System.Drawing.Size(23, 12);
            this.Label_SafetyBoard_AisleNorth.TabIndex = 10;
            this.Label_SafetyBoard_AisleNorth.Text = "---";
            // 
            // GroupBox_Zoning_Aisle
            // 
            this.GroupBox_Zoning_Aisle.Controls.Add(this.TextBox_ZoningStatus_Aisle);
            this.GroupBox_Zoning_Aisle.Controls.Add(this.label19);
            this.GroupBox_Zoning_Aisle.Controls.Add(this.groupBox_ZoningCellCmd_Aisle);
            this.GroupBox_Zoning_Aisle.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBox_Zoning_Aisle.Location = new System.Drawing.Point(137, 40);
            this.GroupBox_Zoning_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Zoning_Aisle.Name = "GroupBox_Zoning_Aisle";
            this.GroupBox_Zoning_Aisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Zoning_Aisle.Size = new System.Drawing.Size(125, 122);
            this.GroupBox_Zoning_Aisle.TabIndex = 16;
            this.GroupBox_Zoning_Aisle.TabStop = false;
            this.GroupBox_Zoning_Aisle.Text = "ゾーニング";
            // 
            // TextBox_ZoningStatus_Aisle
            // 
            this.TextBox_ZoningStatus_Aisle.Location = new System.Drawing.Point(45, 88);
            this.TextBox_ZoningStatus_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_ZoningStatus_Aisle.Name = "TextBox_ZoningStatus_Aisle";
            this.TextBox_ZoningStatus_Aisle.Size = new System.Drawing.Size(76, 19);
            this.TextBox_ZoningStatus_Aisle.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 92);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 12);
            this.label19.TabIndex = 18;
            this.label19.Text = "Status";
            // 
            // groupBox_ZoningCellCmd_Aisle
            // 
            this.groupBox_ZoningCellCmd_Aisle.Controls.Add(this.RadioButton_Cancel_Aisle);
            this.groupBox_ZoningCellCmd_Aisle.Controls.Add(this.RadioButton_Permit_Aisle);
            this.groupBox_ZoningCellCmd_Aisle.Controls.Add(this.RadioButton_Run_Aisle);
            this.groupBox_ZoningCellCmd_Aisle.Controls.Add(this.RadioButton_None_Aisle);
            this.groupBox_ZoningCellCmd_Aisle.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox_ZoningCellCmd_Aisle.Location = new System.Drawing.Point(4, 17);
            this.groupBox_ZoningCellCmd_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_ZoningCellCmd_Aisle.Name = "groupBox_ZoningCellCmd_Aisle";
            this.groupBox_ZoningCellCmd_Aisle.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_ZoningCellCmd_Aisle.Size = new System.Drawing.Size(116, 60);
            this.groupBox_ZoningCellCmd_Aisle.TabIndex = 17;
            this.groupBox_ZoningCellCmd_Aisle.TabStop = false;
            this.groupBox_ZoningCellCmd_Aisle.Text = "CELL 指示";
            // 
            // RadioButton_Cancel_Aisle
            // 
            this.RadioButton_Cancel_Aisle.AutoSize = true;
            this.RadioButton_Cancel_Aisle.Location = new System.Drawing.Point(56, 37);
            this.RadioButton_Cancel_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Cancel_Aisle.Name = "RadioButton_Cancel_Aisle";
            this.RadioButton_Cancel_Aisle.Size = new System.Drawing.Size(58, 16);
            this.RadioButton_Cancel_Aisle.TabIndex = 3;
            this.RadioButton_Cancel_Aisle.TabStop = true;
            this.RadioButton_Cancel_Aisle.Text = "Cancel";
            this.RadioButton_Cancel_Aisle.UseVisualStyleBackColor = true;
            this.RadioButton_Cancel_Aisle.CheckedChanged += new System.EventHandler(this.RadioButton_Cancel_Aisle_CheckedChanged);
            // 
            // RadioButton_Permit_Aisle
            // 
            this.RadioButton_Permit_Aisle.AutoSize = true;
            this.RadioButton_Permit_Aisle.Location = new System.Drawing.Point(56, 17);
            this.RadioButton_Permit_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Permit_Aisle.Name = "RadioButton_Permit_Aisle";
            this.RadioButton_Permit_Aisle.Size = new System.Drawing.Size(56, 16);
            this.RadioButton_Permit_Aisle.TabIndex = 2;
            this.RadioButton_Permit_Aisle.TabStop = true;
            this.RadioButton_Permit_Aisle.Text = "Permit";
            this.RadioButton_Permit_Aisle.UseVisualStyleBackColor = true;
            this.RadioButton_Permit_Aisle.CheckedChanged += new System.EventHandler(this.RadioButton_Permit_Aisle_CheckedChanged);
            // 
            // RadioButton_Run_Aisle
            // 
            this.RadioButton_Run_Aisle.AutoSize = true;
            this.RadioButton_Run_Aisle.Location = new System.Drawing.Point(4, 37);
            this.RadioButton_Run_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Run_Aisle.Name = "RadioButton_Run_Aisle";
            this.RadioButton_Run_Aisle.Size = new System.Drawing.Size(43, 16);
            this.RadioButton_Run_Aisle.TabIndex = 1;
            this.RadioButton_Run_Aisle.TabStop = true;
            this.RadioButton_Run_Aisle.Text = "Run";
            this.RadioButton_Run_Aisle.UseVisualStyleBackColor = true;
            this.RadioButton_Run_Aisle.CheckedChanged += new System.EventHandler(this.RadioButton_Run_Aisle_CheckedChanged);
            // 
            // RadioButton_None_Aisle
            // 
            this.RadioButton_None_Aisle.AutoSize = true;
            this.RadioButton_None_Aisle.Location = new System.Drawing.Point(4, 17);
            this.RadioButton_None_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_None_Aisle.Name = "RadioButton_None_Aisle";
            this.RadioButton_None_Aisle.Size = new System.Drawing.Size(49, 16);
            this.RadioButton_None_Aisle.TabIndex = 0;
            this.RadioButton_None_Aisle.TabStop = true;
            this.RadioButton_None_Aisle.Text = "None";
            this.RadioButton_None_Aisle.UseVisualStyleBackColor = true;
            this.RadioButton_None_Aisle.CheckedChanged += new System.EventHandler(this.RadioButton_None_Aisle_CheckedChanged);
            // 
            // GroupBox_Contactors_Aisle
            // 
            this.GroupBox_Contactors_Aisle.Controls.Add(this.Label_ContactorLamp_Aisle);
            this.GroupBox_Contactors_Aisle.Controls.Add(this.GroupBox_Ctor_AisleSouth);
            this.GroupBox_Contactors_Aisle.Controls.Add(this.CheckBox_FBAuto_Aisle);
            this.GroupBox_Contactors_Aisle.Controls.Add(this.GroupBox_Ctor_AisleNorth);
            this.GroupBox_Contactors_Aisle.Location = new System.Drawing.Point(4, 161);
            this.GroupBox_Contactors_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Contactors_Aisle.Name = "GroupBox_Contactors_Aisle";
            this.GroupBox_Contactors_Aisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Contactors_Aisle.Size = new System.Drawing.Size(129, 283);
            this.GroupBox_Contactors_Aisle.TabIndex = 11;
            this.GroupBox_Contactors_Aisle.TabStop = false;
            this.GroupBox_Contactors_Aisle.Text = "コンタクタ";
            // 
            // Label_ContactorLamp_Aisle
            // 
            this.Label_ContactorLamp_Aisle.AutoSize = true;
            this.Label_ContactorLamp_Aisle.Location = new System.Drawing.Point(4, 253);
            this.Label_ContactorLamp_Aisle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorLamp_Aisle.Name = "Label_ContactorLamp_Aisle";
            this.Label_ContactorLamp_Aisle.Size = new System.Drawing.Size(23, 12);
            this.Label_ContactorLamp_Aisle.TabIndex = 30;
            this.Label_ContactorLamp_Aisle.Text = "---";
            // 
            // GroupBox_Ctor_AisleSouth
            // 
            this.GroupBox_Ctor_AisleSouth.Controls.Add(this.CheckBox_ContactorTripped_AisleSouth);
            this.GroupBox_Ctor_AisleSouth.Controls.Add(this.CheckBox_ContactorFdbk_AisleSouth);
            this.GroupBox_Ctor_AisleSouth.Controls.Add(this.Label_ContactorFdbk_AisleSouth);
            this.GroupBox_Ctor_AisleSouth.Controls.Add(this.CheckBox_ContactorOnOff_AisleSouth);
            this.GroupBox_Ctor_AisleSouth.Controls.Add(this.Label_ContactorPlcOut_AisleSouth);
            this.GroupBox_Ctor_AisleSouth.Location = new System.Drawing.Point(4, 121);
            this.GroupBox_Ctor_AisleSouth.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_AisleSouth.Name = "GroupBox_Ctor_AisleSouth";
            this.GroupBox_Ctor_AisleSouth.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_AisleSouth.Size = new System.Drawing.Size(82, 100);
            this.GroupBox_Ctor_AisleSouth.TabIndex = 30;
            this.GroupBox_Ctor_AisleSouth.TabStop = false;
            this.GroupBox_Ctor_AisleSouth.Text = "SOUTH";
            // 
            // CheckBox_ContactorTripped_AisleSouth
            // 
            this.CheckBox_ContactorTripped_AisleSouth.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorTripped_AisleSouth.AutoSize = true;
            this.CheckBox_ContactorTripped_AisleSouth.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorTripped_AisleSouth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorTripped_AisleSouth.Location = new System.Drawing.Point(4, 70);
            this.CheckBox_ContactorTripped_AisleSouth.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorTripped_AisleSouth.Name = "CheckBox_ContactorTripped_AisleSouth";
            this.CheckBox_ContactorTripped_AisleSouth.Size = new System.Drawing.Size(53, 22);
            this.CheckBox_ContactorTripped_AisleSouth.TabIndex = 29;
            this.CheckBox_ContactorTripped_AisleSouth.Text = "Tripped";
            this.CheckBox_ContactorTripped_AisleSouth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorTripped_AisleSouth.UseVisualStyleBackColor = true;
            // 
            // CheckBox_ContactorFdbk_AisleSouth
            // 
            this.CheckBox_ContactorFdbk_AisleSouth.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorFdbk_AisleSouth.AutoSize = true;
            this.CheckBox_ContactorFdbk_AisleSouth.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_AisleSouth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorFdbk_AisleSouth.Location = new System.Drawing.Point(4, 43);
            this.CheckBox_ContactorFdbk_AisleSouth.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorFdbk_AisleSouth.Name = "CheckBox_ContactorFdbk_AisleSouth";
            this.CheckBox_ContactorFdbk_AisleSouth.Size = new System.Drawing.Size(30, 22);
            this.CheckBox_ContactorFdbk_AisleSouth.TabIndex = 28;
            this.CheckBox_ContactorFdbk_AisleSouth.Text = "FB";
            this.CheckBox_ContactorFdbk_AisleSouth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_AisleSouth.UseVisualStyleBackColor = true;
            this.CheckBox_ContactorFdbk_AisleSouth.CheckedChanged += new System.EventHandler(this.CheckBox_ContactorFdbk_AisleSouth_CheckedChanged);
            // 
            // Label_ContactorFdbk_AisleSouth
            // 
            this.Label_ContactorFdbk_AisleSouth.AutoSize = true;
            this.Label_ContactorFdbk_AisleSouth.Location = new System.Drawing.Point(43, 48);
            this.Label_ContactorFdbk_AisleSouth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorFdbk_AisleSouth.Name = "Label_ContactorFdbk_AisleSouth";
            this.Label_ContactorFdbk_AisleSouth.Size = new System.Drawing.Size(20, 12);
            this.Label_ContactorFdbk_AisleSouth.TabIndex = 13;
            this.Label_ContactorFdbk_AisleSouth.Text = "FB";
            // 
            // CheckBox_ContactorOnOff_AisleSouth
            // 
            this.CheckBox_ContactorOnOff_AisleSouth.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorOnOff_AisleSouth.AutoSize = true;
            this.CheckBox_ContactorOnOff_AisleSouth.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorOnOff_AisleSouth.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.CheckBox_ContactorOnOff_AisleSouth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorOnOff_AisleSouth.Location = new System.Drawing.Point(4, 17);
            this.CheckBox_ContactorOnOff_AisleSouth.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorOnOff_AisleSouth.Name = "CheckBox_ContactorOnOff_AisleSouth";
            this.CheckBox_ContactorOnOff_AisleSouth.Size = new System.Drawing.Size(31, 22);
            this.CheckBox_ContactorOnOff_AisleSouth.TabIndex = 10;
            this.CheckBox_ContactorOnOff_AisleSouth.Text = "ON";
            this.CheckBox_ContactorOnOff_AisleSouth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorOnOff_AisleSouth.UseVisualStyleBackColor = true;
            this.CheckBox_ContactorOnOff_AisleSouth.CheckedChanged += new System.EventHandler(this.CheckBox_ContactorOnOff_AisleSouth_CheckedChanged);
            // 
            // Label_ContactorPlcOut_AisleSouth
            // 
            this.Label_ContactorPlcOut_AisleSouth.AutoSize = true;
            this.Label_ContactorPlcOut_AisleSouth.Location = new System.Drawing.Point(43, 22);
            this.Label_ContactorPlcOut_AisleSouth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorPlcOut_AisleSouth.Name = "Label_ContactorPlcOut_AisleSouth";
            this.Label_ContactorPlcOut_AisleSouth.Size = new System.Drawing.Size(23, 12);
            this.Label_ContactorPlcOut_AisleSouth.TabIndex = 10;
            this.Label_ContactorPlcOut_AisleSouth.Text = "---";
            // 
            // CheckBox_FBAuto_Aisle
            // 
            this.CheckBox_FBAuto_Aisle.AutoSize = true;
            this.CheckBox_FBAuto_Aisle.Checked = true;
            this.CheckBox_FBAuto_Aisle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_FBAuto_Aisle.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.CheckBox_FBAuto_Aisle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckBox_FBAuto_Aisle.Location = new System.Drawing.Point(5, 226);
            this.CheckBox_FBAuto_Aisle.Name = "CheckBox_FBAuto_Aisle";
            this.CheckBox_FBAuto_Aisle.Size = new System.Drawing.Size(43, 24);
            this.CheckBox_FBAuto_Aisle.TabIndex = 38;
            this.CheckBox_FBAuto_Aisle.Text = "FB\r\nauto";
            this.CheckBox_FBAuto_Aisle.UseVisualStyleBackColor = true;
            // 
            // GroupBox_Ctor_AisleNorth
            // 
            this.GroupBox_Ctor_AisleNorth.Controls.Add(this.CheckBox_ContactorTripped_AisleNorth);
            this.GroupBox_Ctor_AisleNorth.Controls.Add(this.CheckBox_ContactorFdbk_AisleNorth);
            this.GroupBox_Ctor_AisleNorth.Controls.Add(this.Label_ContactorFdbk_AisleNorth);
            this.GroupBox_Ctor_AisleNorth.Controls.Add(this.CheckBox_ContactorOnOff_AisleNorth);
            this.GroupBox_Ctor_AisleNorth.Controls.Add(this.Label_ContactorPlcOut_AisleNorth);
            this.GroupBox_Ctor_AisleNorth.Location = new System.Drawing.Point(4, 17);
            this.GroupBox_Ctor_AisleNorth.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_AisleNorth.Name = "GroupBox_Ctor_AisleNorth";
            this.GroupBox_Ctor_AisleNorth.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_AisleNorth.Size = new System.Drawing.Size(82, 100);
            this.GroupBox_Ctor_AisleNorth.TabIndex = 16;
            this.GroupBox_Ctor_AisleNorth.TabStop = false;
            this.GroupBox_Ctor_AisleNorth.Text = "NORTH";
            // 
            // CheckBox_ContactorTripped_AisleNorth
            // 
            this.CheckBox_ContactorTripped_AisleNorth.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorTripped_AisleNorth.AutoSize = true;
            this.CheckBox_ContactorTripped_AisleNorth.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorTripped_AisleNorth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorTripped_AisleNorth.Location = new System.Drawing.Point(4, 70);
            this.CheckBox_ContactorTripped_AisleNorth.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorTripped_AisleNorth.Name = "CheckBox_ContactorTripped_AisleNorth";
            this.CheckBox_ContactorTripped_AisleNorth.Size = new System.Drawing.Size(53, 22);
            this.CheckBox_ContactorTripped_AisleNorth.TabIndex = 29;
            this.CheckBox_ContactorTripped_AisleNorth.Text = "Tripped";
            this.CheckBox_ContactorTripped_AisleNorth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorTripped_AisleNorth.UseVisualStyleBackColor = true;
            // 
            // CheckBox_ContactorFdbk_AisleNorth
            // 
            this.CheckBox_ContactorFdbk_AisleNorth.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorFdbk_AisleNorth.AutoSize = true;
            this.CheckBox_ContactorFdbk_AisleNorth.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_AisleNorth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorFdbk_AisleNorth.Location = new System.Drawing.Point(4, 43);
            this.CheckBox_ContactorFdbk_AisleNorth.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorFdbk_AisleNorth.Name = "CheckBox_ContactorFdbk_AisleNorth";
            this.CheckBox_ContactorFdbk_AisleNorth.Size = new System.Drawing.Size(30, 22);
            this.CheckBox_ContactorFdbk_AisleNorth.TabIndex = 28;
            this.CheckBox_ContactorFdbk_AisleNorth.Text = "FB";
            this.CheckBox_ContactorFdbk_AisleNorth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_AisleNorth.UseVisualStyleBackColor = true;
            this.CheckBox_ContactorFdbk_AisleNorth.CheckedChanged += new System.EventHandler(this.CheckBox_ContactorFdbk_AisleNorth_CheckedChanged);
            // 
            // Label_ContactorFdbk_AisleNorth
            // 
            this.Label_ContactorFdbk_AisleNorth.AutoSize = true;
            this.Label_ContactorFdbk_AisleNorth.Location = new System.Drawing.Point(43, 48);
            this.Label_ContactorFdbk_AisleNorth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorFdbk_AisleNorth.Name = "Label_ContactorFdbk_AisleNorth";
            this.Label_ContactorFdbk_AisleNorth.Size = new System.Drawing.Size(20, 12);
            this.Label_ContactorFdbk_AisleNorth.TabIndex = 13;
            this.Label_ContactorFdbk_AisleNorth.Text = "FB";
            // 
            // CheckBox_ContactorOnOff_AisleNorth
            // 
            this.CheckBox_ContactorOnOff_AisleNorth.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorOnOff_AisleNorth.AutoSize = true;
            this.CheckBox_ContactorOnOff_AisleNorth.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorOnOff_AisleNorth.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.CheckBox_ContactorOnOff_AisleNorth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorOnOff_AisleNorth.Location = new System.Drawing.Point(4, 17);
            this.CheckBox_ContactorOnOff_AisleNorth.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorOnOff_AisleNorth.Name = "CheckBox_ContactorOnOff_AisleNorth";
            this.CheckBox_ContactorOnOff_AisleNorth.Size = new System.Drawing.Size(31, 22);
            this.CheckBox_ContactorOnOff_AisleNorth.TabIndex = 10;
            this.CheckBox_ContactorOnOff_AisleNorth.Text = "ON";
            this.CheckBox_ContactorOnOff_AisleNorth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorOnOff_AisleNorth.UseVisualStyleBackColor = true;
            this.CheckBox_ContactorOnOff_AisleNorth.CheckedChanged += new System.EventHandler(this.CheckBox_ContactorOnOff_AisleNorth_CheckedChanged);
            // 
            // Label_ContactorPlcOut_AisleNorth
            // 
            this.Label_ContactorPlcOut_AisleNorth.AutoSize = true;
            this.Label_ContactorPlcOut_AisleNorth.Location = new System.Drawing.Point(43, 22);
            this.Label_ContactorPlcOut_AisleNorth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorPlcOut_AisleNorth.Name = "Label_ContactorPlcOut_AisleNorth";
            this.Label_ContactorPlcOut_AisleNorth.Size = new System.Drawing.Size(23, 12);
            this.Label_ContactorPlcOut_AisleNorth.TabIndex = 10;
            this.Label_ContactorPlcOut_AisleNorth.Text = "---";
            // 
            // ComboBox_Aisles
            // 
            this.ComboBox_Aisles.FormattingEnabled = true;
            this.ComboBox_Aisles.Location = new System.Drawing.Point(4, 17);
            this.ComboBox_Aisles.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBox_Aisles.Name = "ComboBox_Aisles";
            this.ComboBox_Aisles.Size = new System.Drawing.Size(117, 20);
            this.ComboBox_Aisles.TabIndex = 0;
            this.ComboBox_Aisles.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Aisles_SelectedIndexChanged);
            // 
            // GroupBox_OpBox_Aisle
            // 
            this.GroupBox_OpBox_Aisle.Controls.Add(this.GroupBox_KeySwitch_Aisle);
            this.GroupBox_OpBox_Aisle.Controls.Add(this.Label_OpBoxLed_Aisle);
            this.GroupBox_OpBox_Aisle.Controls.Add(this.CheckBox_EstopBtn_Aisle);
            this.GroupBox_OpBox_Aisle.Controls.Add(this.Btn_Reset_Aisle);
            this.GroupBox_OpBox_Aisle.Controls.Add(this.Btn_Run_Aisle);
            this.GroupBox_OpBox_Aisle.Location = new System.Drawing.Point(4, 40);
            this.GroupBox_OpBox_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_OpBox_Aisle.Name = "GroupBox_OpBox_Aisle";
            this.GroupBox_OpBox_Aisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_OpBox_Aisle.Size = new System.Drawing.Size(129, 117);
            this.GroupBox_OpBox_Aisle.TabIndex = 10;
            this.GroupBox_OpBox_Aisle.TabStop = false;
            this.GroupBox_OpBox_Aisle.Text = "OpBox";
            // 
            // GroupBox_KeySwitch_Aisle
            // 
            this.GroupBox_KeySwitch_Aisle.Controls.Add(this.RadioButton_Ready_Aisle);
            this.GroupBox_KeySwitch_Aisle.Controls.Add(this.RadioButton_Req_Aisle);
            this.GroupBox_KeySwitch_Aisle.Location = new System.Drawing.Point(57, 15);
            this.GroupBox_KeySwitch_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_KeySwitch_Aisle.Name = "GroupBox_KeySwitch_Aisle";
            this.GroupBox_KeySwitch_Aisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_KeySwitch_Aisle.Size = new System.Drawing.Size(64, 61);
            this.GroupBox_KeySwitch_Aisle.TabIndex = 29;
            this.GroupBox_KeySwitch_Aisle.TabStop = false;
            this.GroupBox_KeySwitch_Aisle.Text = "KeySw";
            // 
            // RadioButton_Ready_Aisle
            // 
            this.RadioButton_Ready_Aisle.AutoSize = true;
            this.RadioButton_Ready_Aisle.Location = new System.Drawing.Point(5, 37);
            this.RadioButton_Ready_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Ready_Aisle.Name = "RadioButton_Ready_Aisle";
            this.RadioButton_Ready_Aisle.Size = new System.Drawing.Size(55, 16);
            this.RadioButton_Ready_Aisle.TabIndex = 5;
            this.RadioButton_Ready_Aisle.TabStop = true;
            this.RadioButton_Ready_Aisle.Text = "Ready";
            this.RadioButton_Ready_Aisle.UseVisualStyleBackColor = true;
            this.RadioButton_Ready_Aisle.CheckedChanged += new System.EventHandler(this.RadioButton_Ready_Aisle_CheckedChanged);
            // 
            // RadioButton_Req_Aisle
            // 
            this.RadioButton_Req_Aisle.AutoSize = true;
            this.RadioButton_Req_Aisle.Location = new System.Drawing.Point(5, 17);
            this.RadioButton_Req_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Req_Aisle.Name = "RadioButton_Req_Aisle";
            this.RadioButton_Req_Aisle.Size = new System.Drawing.Size(43, 16);
            this.RadioButton_Req_Aisle.TabIndex = 4;
            this.RadioButton_Req_Aisle.TabStop = true;
            this.RadioButton_Req_Aisle.Text = "Req";
            this.RadioButton_Req_Aisle.UseVisualStyleBackColor = true;
            this.RadioButton_Req_Aisle.CheckedChanged += new System.EventHandler(this.RadioButton_Req_Aisle_CheckedChanged);
            // 
            // Label_OpBoxLed_Aisle
            // 
            this.Label_OpBoxLed_Aisle.AutoSize = true;
            this.Label_OpBoxLed_Aisle.Location = new System.Drawing.Point(4, 93);
            this.Label_OpBoxLed_Aisle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_OpBoxLed_Aisle.Name = "Label_OpBoxLed_Aisle";
            this.Label_OpBoxLed_Aisle.Size = new System.Drawing.Size(23, 12);
            this.Label_OpBoxLed_Aisle.TabIndex = 5;
            this.Label_OpBoxLed_Aisle.Text = "---";
            // 
            // CheckBox_EstopBtn_Aisle
            // 
            this.CheckBox_EstopBtn_Aisle.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_EstopBtn_Aisle.AutoSize = true;
            this.CheckBox_EstopBtn_Aisle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_EstopBtn_Aisle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_EstopBtn_Aisle.Location = new System.Drawing.Point(4, 17);
            this.CheckBox_EstopBtn_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_EstopBtn_Aisle.Name = "CheckBox_EstopBtn_Aisle";
            this.CheckBox_EstopBtn_Aisle.Size = new System.Drawing.Size(44, 22);
            this.CheckBox_EstopBtn_Aisle.TabIndex = 5;
            this.CheckBox_EstopBtn_Aisle.Text = "Estop";
            this.CheckBox_EstopBtn_Aisle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_EstopBtn_Aisle.UseVisualStyleBackColor = true;
            this.CheckBox_EstopBtn_Aisle.CheckedChanged += new System.EventHandler(this.CheckBox_EstopBtn_Aisle_CheckedChanged);
            // 
            // Btn_Reset_Aisle
            // 
            this.Btn_Reset_Aisle.Location = new System.Drawing.Point(4, 42);
            this.Btn_Reset_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Reset_Aisle.Name = "Btn_Reset_Aisle";
            this.Btn_Reset_Aisle.Size = new System.Drawing.Size(44, 22);
            this.Btn_Reset_Aisle.TabIndex = 3;
            this.Btn_Reset_Aisle.Text = "Reset";
            this.Btn_Reset_Aisle.UseVisualStyleBackColor = true;
            this.Btn_Reset_Aisle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_Aisle_MouseDown);
            this.Btn_Reset_Aisle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_Aisle_MouseUp);
            // 
            // Btn_Run_Aisle
            // 
            this.Btn_Run_Aisle.Location = new System.Drawing.Point(4, 67);
            this.Btn_Run_Aisle.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Run_Aisle.Name = "Btn_Run_Aisle";
            this.Btn_Run_Aisle.Size = new System.Drawing.Size(44, 22);
            this.Btn_Run_Aisle.TabIndex = 6;
            this.Btn_Run_Aisle.Text = "起動";
            this.Btn_Run_Aisle.UseVisualStyleBackColor = true;
            this.Btn_Run_Aisle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Run_Aisle_MouseDown);
            this.Btn_Run_Aisle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Run_Aisle_MouseUp);
            // 
            // RadioButton_MaintArea_MaintMode
            // 
            this.RadioButton_MaintArea_MaintMode.AutoSize = true;
            this.RadioButton_MaintArea_MaintMode.Location = new System.Drawing.Point(4, 16);
            this.RadioButton_MaintArea_MaintMode.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_MaintArea_MaintMode.Name = "RadioButton_MaintArea_MaintMode";
            this.RadioButton_MaintArea_MaintMode.Size = new System.Drawing.Size(51, 16);
            this.RadioButton_MaintArea_MaintMode.TabIndex = 6;
            this.RadioButton_MaintArea_MaintMode.TabStop = true;
            this.RadioButton_MaintArea_MaintMode.Text = "Maint";
            this.RadioButton_MaintArea_MaintMode.UseVisualStyleBackColor = true;
            this.RadioButton_MaintArea_MaintMode.CheckedChanged += new System.EventHandler(this.RadioButton_MaintArea_Maint_CheckedChanged);
            // 
            // GroupBox_Stopper
            // 
            this.GroupBox_Stopper.Controls.Add(this.CheckBox_AutoStopper);
            this.GroupBox_Stopper.Controls.Add(this.CheckBox_Alarm_Stopper);
            this.GroupBox_Stopper.Controls.Add(this.ComboBox_Stoppers);
            this.GroupBox_Stopper.Controls.Add(this.Label_TimeOverSignalToCell_Stopper);
            this.GroupBox_Stopper.Controls.Add(this.GroupBox_Q_Stopper);
            this.GroupBox_Stopper.Controls.Add(this.Label_ErrorSignalToCell_Stopper);
            this.GroupBox_Stopper.Controls.Add(this.Label_IsClosedStatusToCell_Stopper);
            this.GroupBox_Stopper.Controls.Add(this.GroupBox_Sensor_Stopper);
            this.GroupBox_Stopper.Controls.Add(this.Label_IsOpenStatusToCell_Stopper);
            this.GroupBox_Stopper.Controls.Add(this.CheckBox_CloseCommandFromCell_Stopper);
            this.GroupBox_Stopper.Controls.Add(this.CheckBox_OpenCommandFromCell_Stopper);
            this.GroupBox_Stopper.Location = new System.Drawing.Point(436, 299);
            this.GroupBox_Stopper.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Stopper.Name = "GroupBox_Stopper";
            this.GroupBox_Stopper.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Stopper.Size = new System.Drawing.Size(276, 126);
            this.GroupBox_Stopper.TabIndex = 15;
            this.GroupBox_Stopper.TabStop = false;
            this.GroupBox_Stopper.Text = "ストッパー";
            // 
            // CheckBox_AutoStopper
            // 
            this.CheckBox_AutoStopper.AutoSize = true;
            this.CheckBox_AutoStopper.Checked = true;
            this.CheckBox_AutoStopper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_AutoStopper.Location = new System.Drawing.Point(106, 105);
            this.CheckBox_AutoStopper.Name = "CheckBox_AutoStopper";
            this.CheckBox_AutoStopper.Size = new System.Drawing.Size(48, 16);
            this.CheckBox_AutoStopper.TabIndex = 37;
            this.CheckBox_AutoStopper.Text = "Auto";
            this.CheckBox_AutoStopper.UseVisualStyleBackColor = true;
            // 
            // CheckBox_Alarm_Stopper
            // 
            this.CheckBox_Alarm_Stopper.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_Alarm_Stopper.AutoSize = true;
            this.CheckBox_Alarm_Stopper.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_Alarm_Stopper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_Alarm_Stopper.Location = new System.Drawing.Point(201, 50);
            this.CheckBox_Alarm_Stopper.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_Alarm_Stopper.Name = "CheckBox_Alarm_Stopper";
            this.CheckBox_Alarm_Stopper.Size = new System.Drawing.Size(45, 22);
            this.CheckBox_Alarm_Stopper.TabIndex = 24;
            this.CheckBox_Alarm_Stopper.Text = "Alarm";
            this.CheckBox_Alarm_Stopper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_Alarm_Stopper.UseVisualStyleBackColor = true;
            this.CheckBox_Alarm_Stopper.CheckedChanged += new System.EventHandler(this.CheckBox_InvAlarm_Stopper_CheckedChanged);
            // 
            // ComboBox_Stoppers
            // 
            this.ComboBox_Stoppers.FormattingEnabled = true;
            this.ComboBox_Stoppers.Location = new System.Drawing.Point(4, 17);
            this.ComboBox_Stoppers.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBox_Stoppers.Name = "ComboBox_Stoppers";
            this.ComboBox_Stoppers.Size = new System.Drawing.Size(189, 20);
            this.ComboBox_Stoppers.TabIndex = 22;
            this.ComboBox_Stoppers.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Stoppers_SelectedIndexChanged);
            // 
            // Label_TimeOverSignalToCell_Stopper
            // 
            this.Label_TimeOverSignalToCell_Stopper.AutoSize = true;
            this.Label_TimeOverSignalToCell_Stopper.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Label_TimeOverSignalToCell_Stopper.Location = new System.Drawing.Point(65, 76);
            this.Label_TimeOverSignalToCell_Stopper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_TimeOverSignalToCell_Stopper.Name = "Label_TimeOverSignalToCell_Stopper";
            this.Label_TimeOverSignalToCell_Stopper.Size = new System.Drawing.Size(38, 12);
            this.Label_TimeOverSignalToCell_Stopper.TabIndex = 14;
            this.Label_TimeOverSignalToCell_Stopper.Text = "T over";
            // 
            // GroupBox_Q_Stopper
            // 
            this.GroupBox_Q_Stopper.Controls.Add(this.Label_PlcOpenOut_Stopper);
            this.GroupBox_Q_Stopper.Controls.Add(this.Label_PlcCloseOut_Stopper);
            this.GroupBox_Q_Stopper.Location = new System.Drawing.Point(107, 41);
            this.GroupBox_Q_Stopper.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Q_Stopper.Name = "GroupBox_Q_Stopper";
            this.GroupBox_Q_Stopper.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Q_Stopper.Size = new System.Drawing.Size(27, 61);
            this.GroupBox_Q_Stopper.TabIndex = 16;
            this.GroupBox_Q_Stopper.TabStop = false;
            this.GroupBox_Q_Stopper.Text = "Q";
            // 
            // Label_PlcOpenOut_Stopper
            // 
            this.Label_PlcOpenOut_Stopper.AutoSize = true;
            this.Label_PlcOpenOut_Stopper.Location = new System.Drawing.Point(4, 14);
            this.Label_PlcOpenOut_Stopper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_PlcOpenOut_Stopper.Name = "Label_PlcOpenOut_Stopper";
            this.Label_PlcOpenOut_Stopper.Size = new System.Drawing.Size(17, 12);
            this.Label_PlcOpenOut_Stopper.TabIndex = 15;
            this.Label_PlcOpenOut_Stopper.Text = "開";
            // 
            // Label_PlcCloseOut_Stopper
            // 
            this.Label_PlcCloseOut_Stopper.AutoSize = true;
            this.Label_PlcCloseOut_Stopper.Location = new System.Drawing.Point(4, 39);
            this.Label_PlcCloseOut_Stopper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_PlcCloseOut_Stopper.Name = "Label_PlcCloseOut_Stopper";
            this.Label_PlcCloseOut_Stopper.Size = new System.Drawing.Size(17, 12);
            this.Label_PlcCloseOut_Stopper.TabIndex = 16;
            this.Label_PlcCloseOut_Stopper.Text = "閉";
            // 
            // Label_ErrorSignalToCell_Stopper
            // 
            this.Label_ErrorSignalToCell_Stopper.AutoSize = true;
            this.Label_ErrorSignalToCell_Stopper.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Label_ErrorSignalToCell_Stopper.Location = new System.Drawing.Point(65, 51);
            this.Label_ErrorSignalToCell_Stopper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ErrorSignalToCell_Stopper.Name = "Label_ErrorSignalToCell_Stopper";
            this.Label_ErrorSignalToCell_Stopper.Size = new System.Drawing.Size(30, 12);
            this.Label_ErrorSignalToCell_Stopper.TabIndex = 13;
            this.Label_ErrorSignalToCell_Stopper.Text = "Error";
            // 
            // Label_IsClosedStatusToCell_Stopper
            // 
            this.Label_IsClosedStatusToCell_Stopper.AutoSize = true;
            this.Label_IsClosedStatusToCell_Stopper.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Label_IsClosedStatusToCell_Stopper.Location = new System.Drawing.Point(38, 76);
            this.Label_IsClosedStatusToCell_Stopper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_IsClosedStatusToCell_Stopper.Name = "Label_IsClosedStatusToCell_Stopper";
            this.Label_IsClosedStatusToCell_Stopper.Size = new System.Drawing.Size(17, 12);
            this.Label_IsClosedStatusToCell_Stopper.TabIndex = 12;
            this.Label_IsClosedStatusToCell_Stopper.Text = "閉";
            this.Label_IsClosedStatusToCell_Stopper.ForeColorChanged += new System.EventHandler(this.Label_IsClosedStatusToCell_Stopper_ForeColorChanged);
            // 
            // GroupBox_Sensor_Stopper
            // 
            this.GroupBox_Sensor_Stopper.Controls.Add(this.CheckBox_IsClosedSensor_Stopper);
            this.GroupBox_Sensor_Stopper.Controls.Add(this.Label_IsOpenSensor_Stopper);
            this.GroupBox_Sensor_Stopper.Controls.Add(this.CheckBox_IsOpenSensor_Stopper);
            this.GroupBox_Sensor_Stopper.Controls.Add(this.Label_IsClosedSensor_Stopper);
            this.GroupBox_Sensor_Stopper.Location = new System.Drawing.Point(138, 41);
            this.GroupBox_Sensor_Stopper.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Sensor_Stopper.Name = "GroupBox_Sensor_Stopper";
            this.GroupBox_Sensor_Stopper.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Sensor_Stopper.Size = new System.Drawing.Size(55, 61);
            this.GroupBox_Sensor_Stopper.TabIndex = 17;
            this.GroupBox_Sensor_Stopper.TabStop = false;
            this.GroupBox_Sensor_Stopper.Text = "Sensors";
            // 
            // CheckBox_IsClosedSensor_Stopper
            // 
            this.CheckBox_IsClosedSensor_Stopper.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_IsClosedSensor_Stopper.AutoSize = true;
            this.CheckBox_IsClosedSensor_Stopper.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_IsClosedSensor_Stopper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_IsClosedSensor_Stopper.Location = new System.Drawing.Point(25, 34);
            this.CheckBox_IsClosedSensor_Stopper.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_IsClosedSensor_Stopper.Name = "CheckBox_IsClosedSensor_Stopper";
            this.CheckBox_IsClosedSensor_Stopper.Size = new System.Drawing.Size(27, 22);
            this.CheckBox_IsClosedSensor_Stopper.TabIndex = 23;
            this.CheckBox_IsClosedSensor_Stopper.Text = "閉";
            this.CheckBox_IsClosedSensor_Stopper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_IsClosedSensor_Stopper.UseVisualStyleBackColor = true;
            this.CheckBox_IsClosedSensor_Stopper.CheckedChanged += new System.EventHandler(this.CheckBox_IsClosedSensor_Stopper_CheckedChanged);
            // 
            // Label_IsOpenSensor_Stopper
            // 
            this.Label_IsOpenSensor_Stopper.AutoSize = true;
            this.Label_IsOpenSensor_Stopper.Location = new System.Drawing.Point(4, 14);
            this.Label_IsOpenSensor_Stopper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_IsOpenSensor_Stopper.Name = "Label_IsOpenSensor_Stopper";
            this.Label_IsOpenSensor_Stopper.Size = new System.Drawing.Size(17, 12);
            this.Label_IsOpenSensor_Stopper.TabIndex = 19;
            this.Label_IsOpenSensor_Stopper.Text = "開";
            // 
            // CheckBox_IsOpenSensor_Stopper
            // 
            this.CheckBox_IsOpenSensor_Stopper.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_IsOpenSensor_Stopper.AutoSize = true;
            this.CheckBox_IsOpenSensor_Stopper.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_IsOpenSensor_Stopper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_IsOpenSensor_Stopper.Location = new System.Drawing.Point(25, 9);
            this.CheckBox_IsOpenSensor_Stopper.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_IsOpenSensor_Stopper.Name = "CheckBox_IsOpenSensor_Stopper";
            this.CheckBox_IsOpenSensor_Stopper.Size = new System.Drawing.Size(27, 22);
            this.CheckBox_IsOpenSensor_Stopper.TabIndex = 23;
            this.CheckBox_IsOpenSensor_Stopper.Text = "開";
            this.CheckBox_IsOpenSensor_Stopper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_IsOpenSensor_Stopper.UseVisualStyleBackColor = true;
            this.CheckBox_IsOpenSensor_Stopper.CheckedChanged += new System.EventHandler(this.CheckBox_IsOpenSensor_Stopper_CheckedChanged);
            // 
            // Label_IsClosedSensor_Stopper
            // 
            this.Label_IsClosedSensor_Stopper.AutoSize = true;
            this.Label_IsClosedSensor_Stopper.Location = new System.Drawing.Point(4, 39);
            this.Label_IsClosedSensor_Stopper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_IsClosedSensor_Stopper.Name = "Label_IsClosedSensor_Stopper";
            this.Label_IsClosedSensor_Stopper.Size = new System.Drawing.Size(17, 12);
            this.Label_IsClosedSensor_Stopper.TabIndex = 20;
            this.Label_IsClosedSensor_Stopper.Text = "閉";
            // 
            // Label_IsOpenStatusToCell_Stopper
            // 
            this.Label_IsOpenStatusToCell_Stopper.AutoSize = true;
            this.Label_IsOpenStatusToCell_Stopper.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Label_IsOpenStatusToCell_Stopper.Location = new System.Drawing.Point(38, 51);
            this.Label_IsOpenStatusToCell_Stopper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_IsOpenStatusToCell_Stopper.Name = "Label_IsOpenStatusToCell_Stopper";
            this.Label_IsOpenStatusToCell_Stopper.Size = new System.Drawing.Size(17, 12);
            this.Label_IsOpenStatusToCell_Stopper.TabIndex = 10;
            this.Label_IsOpenStatusToCell_Stopper.Text = "開";
            this.Label_IsOpenStatusToCell_Stopper.ForeColorChanged += new System.EventHandler(this.Label_IsOpenStatusToCell_Stopper_ForeColorChanged);
            // 
            // CheckBox_CloseCommandFromCell_Stopper
            // 
            this.CheckBox_CloseCommandFromCell_Stopper.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_CloseCommandFromCell_Stopper.AutoSize = true;
            this.CheckBox_CloseCommandFromCell_Stopper.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_CloseCommandFromCell_Stopper.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.CheckBox_CloseCommandFromCell_Stopper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_CloseCommandFromCell_Stopper.Location = new System.Drawing.Point(4, 72);
            this.CheckBox_CloseCommandFromCell_Stopper.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_CloseCommandFromCell_Stopper.Name = "CheckBox_CloseCommandFromCell_Stopper";
            this.CheckBox_CloseCommandFromCell_Stopper.Size = new System.Drawing.Size(27, 22);
            this.CheckBox_CloseCommandFromCell_Stopper.TabIndex = 11;
            this.CheckBox_CloseCommandFromCell_Stopper.Text = "閉";
            this.CheckBox_CloseCommandFromCell_Stopper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_CloseCommandFromCell_Stopper.UseVisualStyleBackColor = true;
            this.CheckBox_CloseCommandFromCell_Stopper.CheckedChanged += new System.EventHandler(this.CheckBox_CloseCommandFromCell_Stopper_CheckedChanged);
            // 
            // CheckBox_OpenCommandFromCell_Stopper
            // 
            this.CheckBox_OpenCommandFromCell_Stopper.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_OpenCommandFromCell_Stopper.AutoSize = true;
            this.CheckBox_OpenCommandFromCell_Stopper.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_OpenCommandFromCell_Stopper.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.CheckBox_OpenCommandFromCell_Stopper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_OpenCommandFromCell_Stopper.Location = new System.Drawing.Point(4, 47);
            this.CheckBox_OpenCommandFromCell_Stopper.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_OpenCommandFromCell_Stopper.Name = "CheckBox_OpenCommandFromCell_Stopper";
            this.CheckBox_OpenCommandFromCell_Stopper.Size = new System.Drawing.Size(27, 22);
            this.CheckBox_OpenCommandFromCell_Stopper.TabIndex = 10;
            this.CheckBox_OpenCommandFromCell_Stopper.Text = "開";
            this.CheckBox_OpenCommandFromCell_Stopper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_OpenCommandFromCell_Stopper.UseVisualStyleBackColor = true;
            this.CheckBox_OpenCommandFromCell_Stopper.CheckedChanged += new System.EventHandler(this.CheckBox_OpenCommandFromCell_Stopper_CheckedChanged);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.GroupBox_Door_Deck);
            this.groupBox16.Controls.Add(this.GroupBox_OpBox_Deck);
            this.groupBox16.Controls.Add(this.GroupBox_Estop_Deck);
            this.groupBox16.Controls.Add(this.CheckBox_AllDecks);
            this.groupBox16.Controls.Add(this.groupBox_Zoning_Deck);
            this.groupBox16.Controls.Add(this.ComboBox_Decks);
            this.groupBox16.Location = new System.Drawing.Point(440, 12);
            this.groupBox16.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox16.Size = new System.Drawing.Size(272, 264);
            this.groupBox16.TabIndex = 22;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "DECK";
            // 
            // GroupBox_Door_Deck
            // 
            this.GroupBox_Door_Deck.Controls.Add(this.Label_UnlockDoor_Deck);
            this.GroupBox_Door_Deck.Controls.Add(this.Label_DoorIsLocked_Deck);
            this.GroupBox_Door_Deck.Controls.Add(this.GroupBox_DoorSensor_Deck);
            this.GroupBox_Door_Deck.Location = new System.Drawing.Point(4, 162);
            this.GroupBox_Door_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Door_Deck.Name = "GroupBox_Door_Deck";
            this.GroupBox_Door_Deck.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Door_Deck.Size = new System.Drawing.Size(129, 88);
            this.GroupBox_Door_Deck.TabIndex = 33;
            this.GroupBox_Door_Deck.TabStop = false;
            this.GroupBox_Door_Deck.Text = "扉";
            // 
            // Label_UnlockDoor_Deck
            // 
            this.Label_UnlockDoor_Deck.AutoSize = true;
            this.Label_UnlockDoor_Deck.Location = new System.Drawing.Point(50, 61);
            this.Label_UnlockDoor_Deck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_UnlockDoor_Deck.Name = "Label_UnlockDoor_Deck";
            this.Label_UnlockDoor_Deck.Size = new System.Drawing.Size(23, 12);
            this.Label_UnlockDoor_Deck.TabIndex = 31;
            this.Label_UnlockDoor_Deck.Text = "---";
            // 
            // Label_DoorIsLocked_Deck
            // 
            this.Label_DoorIsLocked_Deck.AutoSize = true;
            this.Label_DoorIsLocked_Deck.Location = new System.Drawing.Point(4, 61);
            this.Label_DoorIsLocked_Deck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_DoorIsLocked_Deck.Name = "Label_DoorIsLocked_Deck";
            this.Label_DoorIsLocked_Deck.Size = new System.Drawing.Size(23, 12);
            this.Label_DoorIsLocked_Deck.TabIndex = 30;
            this.Label_DoorIsLocked_Deck.Text = "---";
            // 
            // GroupBox_DoorSensor_Deck
            // 
            this.GroupBox_DoorSensor_Deck.Controls.Add(this.RadioButton_DoorClosed_Deck);
            this.GroupBox_DoorSensor_Deck.Controls.Add(this.RadioButton_DoorOpen_Deck);
            this.GroupBox_DoorSensor_Deck.Location = new System.Drawing.Point(4, 17);
            this.GroupBox_DoorSensor_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_DoorSensor_Deck.Name = "GroupBox_DoorSensor_Deck";
            this.GroupBox_DoorSensor_Deck.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_DoorSensor_Deck.Size = new System.Drawing.Size(82, 40);
            this.GroupBox_DoorSensor_Deck.TabIndex = 29;
            this.GroupBox_DoorSensor_Deck.TabStop = false;
            this.GroupBox_DoorSensor_Deck.Text = "Sensor";
            // 
            // RadioButton_DoorClosed_Deck
            // 
            this.RadioButton_DoorClosed_Deck.AutoSize = true;
            this.RadioButton_DoorClosed_Deck.Location = new System.Drawing.Point(41, 18);
            this.RadioButton_DoorClosed_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_DoorClosed_Deck.Name = "RadioButton_DoorClosed_Deck";
            this.RadioButton_DoorClosed_Deck.Size = new System.Drawing.Size(35, 16);
            this.RadioButton_DoorClosed_Deck.TabIndex = 7;
            this.RadioButton_DoorClosed_Deck.TabStop = true;
            this.RadioButton_DoorClosed_Deck.Text = "閉";
            this.RadioButton_DoorClosed_Deck.UseVisualStyleBackColor = true;
            this.RadioButton_DoorClosed_Deck.CheckedChanged += new System.EventHandler(this.RadioButton_DoorClosed_Deck_CheckedChanged);
            // 
            // RadioButton_DoorOpen_Deck
            // 
            this.RadioButton_DoorOpen_Deck.AutoSize = true;
            this.RadioButton_DoorOpen_Deck.Location = new System.Drawing.Point(4, 17);
            this.RadioButton_DoorOpen_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_DoorOpen_Deck.Name = "RadioButton_DoorOpen_Deck";
            this.RadioButton_DoorOpen_Deck.Size = new System.Drawing.Size(35, 16);
            this.RadioButton_DoorOpen_Deck.TabIndex = 6;
            this.RadioButton_DoorOpen_Deck.TabStop = true;
            this.RadioButton_DoorOpen_Deck.Text = "開";
            this.RadioButton_DoorOpen_Deck.UseVisualStyleBackColor = true;
            this.RadioButton_DoorOpen_Deck.CheckedChanged += new System.EventHandler(this.RadioButton_DoorOpen_Deck_CheckedChanged);
            // 
            // GroupBox_OpBox_Deck
            // 
            this.GroupBox_OpBox_Deck.Controls.Add(this.GroupBox_KeySwitch_Deck);
            this.GroupBox_OpBox_Deck.Controls.Add(this.Label_OpBoxLed_Deck);
            this.GroupBox_OpBox_Deck.Controls.Add(this.CheckBox_EstopBtn_Deck);
            this.GroupBox_OpBox_Deck.Controls.Add(this.Btn_Reset_Deck);
            this.GroupBox_OpBox_Deck.Controls.Add(this.Btn_Run_Deck);
            this.GroupBox_OpBox_Deck.Location = new System.Drawing.Point(4, 41);
            this.GroupBox_OpBox_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_OpBox_Deck.Name = "GroupBox_OpBox_Deck";
            this.GroupBox_OpBox_Deck.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_OpBox_Deck.Size = new System.Drawing.Size(129, 117);
            this.GroupBox_OpBox_Deck.TabIndex = 30;
            this.GroupBox_OpBox_Deck.TabStop = false;
            this.GroupBox_OpBox_Deck.Text = "OpBox";
            // 
            // GroupBox_KeySwitch_Deck
            // 
            this.GroupBox_KeySwitch_Deck.Controls.Add(this.RadioButton_Ready_Deck);
            this.GroupBox_KeySwitch_Deck.Controls.Add(this.RadioButton_Req_Deck);
            this.GroupBox_KeySwitch_Deck.Location = new System.Drawing.Point(57, 15);
            this.GroupBox_KeySwitch_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_KeySwitch_Deck.Name = "GroupBox_KeySwitch_Deck";
            this.GroupBox_KeySwitch_Deck.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_KeySwitch_Deck.Size = new System.Drawing.Size(64, 61);
            this.GroupBox_KeySwitch_Deck.TabIndex = 29;
            this.GroupBox_KeySwitch_Deck.TabStop = false;
            this.GroupBox_KeySwitch_Deck.Text = "KeySw";
            // 
            // RadioButton_Ready_Deck
            // 
            this.RadioButton_Ready_Deck.AutoSize = true;
            this.RadioButton_Ready_Deck.Location = new System.Drawing.Point(5, 37);
            this.RadioButton_Ready_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Ready_Deck.Name = "RadioButton_Ready_Deck";
            this.RadioButton_Ready_Deck.Size = new System.Drawing.Size(55, 16);
            this.RadioButton_Ready_Deck.TabIndex = 5;
            this.RadioButton_Ready_Deck.TabStop = true;
            this.RadioButton_Ready_Deck.Text = "Ready";
            this.RadioButton_Ready_Deck.UseVisualStyleBackColor = true;
            this.RadioButton_Ready_Deck.CheckedChanged += new System.EventHandler(this.RadioButton_Ready_Deck_CheckedChanged);
            // 
            // RadioButton_Req_Deck
            // 
            this.RadioButton_Req_Deck.AutoSize = true;
            this.RadioButton_Req_Deck.Location = new System.Drawing.Point(5, 17);
            this.RadioButton_Req_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Req_Deck.Name = "RadioButton_Req_Deck";
            this.RadioButton_Req_Deck.Size = new System.Drawing.Size(43, 16);
            this.RadioButton_Req_Deck.TabIndex = 4;
            this.RadioButton_Req_Deck.TabStop = true;
            this.RadioButton_Req_Deck.Text = "Req";
            this.RadioButton_Req_Deck.UseVisualStyleBackColor = true;
            this.RadioButton_Req_Deck.CheckedChanged += new System.EventHandler(this.RadioButton_Req_Deck_CheckedChanged);
            // 
            // Label_OpBoxLed_Deck
            // 
            this.Label_OpBoxLed_Deck.AutoSize = true;
            this.Label_OpBoxLed_Deck.Location = new System.Drawing.Point(4, 93);
            this.Label_OpBoxLed_Deck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_OpBoxLed_Deck.Name = "Label_OpBoxLed_Deck";
            this.Label_OpBoxLed_Deck.Size = new System.Drawing.Size(23, 12);
            this.Label_OpBoxLed_Deck.TabIndex = 5;
            this.Label_OpBoxLed_Deck.Text = "---";
            // 
            // CheckBox_EstopBtn_Deck
            // 
            this.CheckBox_EstopBtn_Deck.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_EstopBtn_Deck.AutoSize = true;
            this.CheckBox_EstopBtn_Deck.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_EstopBtn_Deck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_EstopBtn_Deck.Location = new System.Drawing.Point(4, 17);
            this.CheckBox_EstopBtn_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_EstopBtn_Deck.Name = "CheckBox_EstopBtn_Deck";
            this.CheckBox_EstopBtn_Deck.Size = new System.Drawing.Size(44, 22);
            this.CheckBox_EstopBtn_Deck.TabIndex = 5;
            this.CheckBox_EstopBtn_Deck.Text = "Estop";
            this.CheckBox_EstopBtn_Deck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_EstopBtn_Deck.UseVisualStyleBackColor = true;
            this.CheckBox_EstopBtn_Deck.CheckedChanged += new System.EventHandler(this.CheckBox_EstopBtn_Deck_CheckedChanged);
            // 
            // Btn_Reset_Deck
            // 
            this.Btn_Reset_Deck.Location = new System.Drawing.Point(4, 42);
            this.Btn_Reset_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Reset_Deck.Name = "Btn_Reset_Deck";
            this.Btn_Reset_Deck.Size = new System.Drawing.Size(44, 22);
            this.Btn_Reset_Deck.TabIndex = 3;
            this.Btn_Reset_Deck.Text = "Reset";
            this.Btn_Reset_Deck.UseVisualStyleBackColor = true;
            this.Btn_Reset_Deck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_Deck_MouseDown);
            this.Btn_Reset_Deck.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_Deck_MouseUp);
            // 
            // Btn_Run_Deck
            // 
            this.Btn_Run_Deck.Location = new System.Drawing.Point(4, 67);
            this.Btn_Run_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Run_Deck.Name = "Btn_Run_Deck";
            this.Btn_Run_Deck.Size = new System.Drawing.Size(44, 22);
            this.Btn_Run_Deck.TabIndex = 6;
            this.Btn_Run_Deck.Text = "起動";
            this.Btn_Run_Deck.UseVisualStyleBackColor = true;
            this.Btn_Run_Deck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Run_Deck_MouseDown);
            this.Btn_Run_Deck.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Run_Deck_MouseUp);
            // 
            // GroupBox_Estop_Deck
            // 
            this.GroupBox_Estop_Deck.Controls.Add(this.CheckBox_ReqCompleteFlag_Deck);
            this.GroupBox_Estop_Deck.Controls.Add(this.Label_StopStatus_Deck);
            this.GroupBox_Estop_Deck.Controls.Add(this.Label_StopRequest_Deck);
            this.GroupBox_Estop_Deck.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBox_Estop_Deck.Location = new System.Drawing.Point(137, 160);
            this.GroupBox_Estop_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Estop_Deck.Name = "GroupBox_Estop_Deck";
            this.GroupBox_Estop_Deck.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Estop_Deck.Size = new System.Drawing.Size(96, 66);
            this.GroupBox_Estop_Deck.TabIndex = 32;
            this.GroupBox_Estop_Deck.TabStop = false;
            this.GroupBox_Estop_Deck.Text = "非常停止";
            // 
            // CheckBox_ReqCompleteFlag_Deck
            // 
            this.CheckBox_ReqCompleteFlag_Deck.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ReqCompleteFlag_Deck.AutoSize = true;
            this.CheckBox_ReqCompleteFlag_Deck.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ReqCompleteFlag_Deck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ReqCompleteFlag_Deck.Location = new System.Drawing.Point(8, 20);
            this.CheckBox_ReqCompleteFlag_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ReqCompleteFlag_Deck.Name = "CheckBox_ReqCompleteFlag_Deck";
            this.CheckBox_ReqCompleteFlag_Deck.Size = new System.Drawing.Size(39, 22);
            this.CheckBox_ReqCompleteFlag_Deck.TabIndex = 10;
            this.CheckBox_ReqCompleteFlag_Deck.Text = "完了";
            this.CheckBox_ReqCompleteFlag_Deck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ReqCompleteFlag_Deck.UseVisualStyleBackColor = true;
            this.CheckBox_ReqCompleteFlag_Deck.CheckedChanged += new System.EventHandler(this.CheckBox_ReqCompleteFlag_Deck_CheckedChanged);
            // 
            // Label_StopStatus_Deck
            // 
            this.Label_StopStatus_Deck.AutoSize = true;
            this.Label_StopStatus_Deck.Location = new System.Drawing.Point(54, 34);
            this.Label_StopStatus_Deck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_StopStatus_Deck.Name = "Label_StopStatus_Deck";
            this.Label_StopStatus_Deck.Size = new System.Drawing.Size(29, 12);
            this.Label_StopStatus_Deck.TabIndex = 20;
            this.Label_StopStatus_Deck.Text = "状態";
            // 
            // Label_StopRequest_Deck
            // 
            this.Label_StopRequest_Deck.AutoSize = true;
            this.Label_StopRequest_Deck.Location = new System.Drawing.Point(54, 14);
            this.Label_StopRequest_Deck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_StopRequest_Deck.Name = "Label_StopRequest_Deck";
            this.Label_StopRequest_Deck.Size = new System.Drawing.Size(29, 12);
            this.Label_StopRequest_Deck.TabIndex = 18;
            this.Label_StopRequest_Deck.Text = "要求";
            // 
            // CheckBox_AllDecks
            // 
            this.CheckBox_AllDecks.AutoSize = true;
            this.CheckBox_AllDecks.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBox_AllDecks.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckBox_AllDecks.Location = new System.Drawing.Point(130, 17);
            this.CheckBox_AllDecks.Name = "CheckBox_AllDecks";
            this.CheckBox_AllDecks.Size = new System.Drawing.Size(83, 16);
            this.CheckBox_AllDecks.TabIndex = 38;
            this.CheckBox_AllDecks.Text = "All Decks";
            this.CheckBox_AllDecks.UseVisualStyleBackColor = true;
            this.CheckBox_AllDecks.CheckedChanged += new System.EventHandler(this.CheckBox_AllDecks_CheckedChanged);
            // 
            // groupBox_Zoning_Deck
            // 
            this.groupBox_Zoning_Deck.Controls.Add(this.TextBox_ZoningStatus_Deck);
            this.groupBox_Zoning_Deck.Controls.Add(this.label26);
            this.groupBox_Zoning_Deck.Controls.Add(this.groupBox_ZoningCellCmd_Deck);
            this.groupBox_Zoning_Deck.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox_Zoning_Deck.Location = new System.Drawing.Point(137, 41);
            this.groupBox_Zoning_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Zoning_Deck.Name = "groupBox_Zoning_Deck";
            this.groupBox_Zoning_Deck.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Zoning_Deck.Size = new System.Drawing.Size(125, 115);
            this.groupBox_Zoning_Deck.TabIndex = 22;
            this.groupBox_Zoning_Deck.TabStop = false;
            this.groupBox_Zoning_Deck.Text = "ゾーニング";
            // 
            // TextBox_ZoningStatus_Deck
            // 
            this.TextBox_ZoningStatus_Deck.Location = new System.Drawing.Point(45, 88);
            this.TextBox_ZoningStatus_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_ZoningStatus_Deck.Name = "TextBox_ZoningStatus_Deck";
            this.TextBox_ZoningStatus_Deck.Size = new System.Drawing.Size(76, 19);
            this.TextBox_ZoningStatus_Deck.TabIndex = 19;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(4, 92);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(38, 12);
            this.label26.TabIndex = 18;
            this.label26.Text = "Status";
            // 
            // groupBox_ZoningCellCmd_Deck
            // 
            this.groupBox_ZoningCellCmd_Deck.Controls.Add(this.RadioButton_Cancel_Deck);
            this.groupBox_ZoningCellCmd_Deck.Controls.Add(this.RadioButton_Permit_Deck);
            this.groupBox_ZoningCellCmd_Deck.Controls.Add(this.RadioButton_Run_Deck);
            this.groupBox_ZoningCellCmd_Deck.Controls.Add(this.RadioButton_None_Deck);
            this.groupBox_ZoningCellCmd_Deck.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox_ZoningCellCmd_Deck.Location = new System.Drawing.Point(4, 17);
            this.groupBox_ZoningCellCmd_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_ZoningCellCmd_Deck.Name = "groupBox_ZoningCellCmd_Deck";
            this.groupBox_ZoningCellCmd_Deck.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_ZoningCellCmd_Deck.Size = new System.Drawing.Size(116, 60);
            this.groupBox_ZoningCellCmd_Deck.TabIndex = 17;
            this.groupBox_ZoningCellCmd_Deck.TabStop = false;
            this.groupBox_ZoningCellCmd_Deck.Text = "CELL 指示";
            // 
            // RadioButton_Cancel_Deck
            // 
            this.RadioButton_Cancel_Deck.AutoSize = true;
            this.RadioButton_Cancel_Deck.Location = new System.Drawing.Point(56, 37);
            this.RadioButton_Cancel_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Cancel_Deck.Name = "RadioButton_Cancel_Deck";
            this.RadioButton_Cancel_Deck.Size = new System.Drawing.Size(58, 16);
            this.RadioButton_Cancel_Deck.TabIndex = 3;
            this.RadioButton_Cancel_Deck.TabStop = true;
            this.RadioButton_Cancel_Deck.Text = "Cancel";
            this.RadioButton_Cancel_Deck.UseVisualStyleBackColor = true;
            this.RadioButton_Cancel_Deck.CheckedChanged += new System.EventHandler(this.RadioButton_Cancel_Deck_CheckedChanged);
            // 
            // RadioButton_Permit_Deck
            // 
            this.RadioButton_Permit_Deck.AutoSize = true;
            this.RadioButton_Permit_Deck.Location = new System.Drawing.Point(56, 17);
            this.RadioButton_Permit_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Permit_Deck.Name = "RadioButton_Permit_Deck";
            this.RadioButton_Permit_Deck.Size = new System.Drawing.Size(56, 16);
            this.RadioButton_Permit_Deck.TabIndex = 2;
            this.RadioButton_Permit_Deck.TabStop = true;
            this.RadioButton_Permit_Deck.Text = "Permit";
            this.RadioButton_Permit_Deck.UseVisualStyleBackColor = true;
            this.RadioButton_Permit_Deck.CheckedChanged += new System.EventHandler(this.RadioButton_Permit_Deck_CheckedChanged);
            // 
            // RadioButton_Run_Deck
            // 
            this.RadioButton_Run_Deck.AutoSize = true;
            this.RadioButton_Run_Deck.Location = new System.Drawing.Point(4, 37);
            this.RadioButton_Run_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Run_Deck.Name = "RadioButton_Run_Deck";
            this.RadioButton_Run_Deck.Size = new System.Drawing.Size(43, 16);
            this.RadioButton_Run_Deck.TabIndex = 1;
            this.RadioButton_Run_Deck.TabStop = true;
            this.RadioButton_Run_Deck.Text = "Run";
            this.RadioButton_Run_Deck.UseVisualStyleBackColor = true;
            this.RadioButton_Run_Deck.CheckedChanged += new System.EventHandler(this.RadioButton_Run_Deck_CheckedChanged);
            // 
            // RadioButton_None_Deck
            // 
            this.RadioButton_None_Deck.AutoSize = true;
            this.RadioButton_None_Deck.Location = new System.Drawing.Point(4, 17);
            this.RadioButton_None_Deck.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_None_Deck.Name = "RadioButton_None_Deck";
            this.RadioButton_None_Deck.Size = new System.Drawing.Size(49, 16);
            this.RadioButton_None_Deck.TabIndex = 0;
            this.RadioButton_None_Deck.TabStop = true;
            this.RadioButton_None_Deck.Text = "None";
            this.RadioButton_None_Deck.UseVisualStyleBackColor = true;
            this.RadioButton_None_Deck.CheckedChanged += new System.EventHandler(this.RadioButton_None_Deck_CheckedChanged);
            // 
            // ComboBox_Decks
            // 
            this.ComboBox_Decks.FormattingEnabled = true;
            this.ComboBox_Decks.Location = new System.Drawing.Point(4, 17);
            this.ComboBox_Decks.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBox_Decks.Name = "ComboBox_Decks";
            this.ComboBox_Decks.Size = new System.Drawing.Size(117, 20);
            this.ComboBox_Decks.TabIndex = 0;
            this.ComboBox_Decks.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Decks_SelectedIndexChanged);
            // 
            // groupBox35
            // 
            this.groupBox35.BackColor = System.Drawing.Color.Transparent;
            this.groupBox35.Controls.Add(this.Label_LedTowerWhite_DwsPanel);
            this.groupBox35.Controls.Add(this.Label_LedTowerGreen_DwsPanel);
            this.groupBox35.Controls.Add(this.Label_LedTowerYellow_DwsPanel);
            this.groupBox35.Controls.Add(this.Label_LedTowerBlue_DwsPanel);
            this.groupBox35.Controls.Add(this.CheckBox_EstopBtn_DwsPanel);
            this.groupBox35.Controls.Add(this.Btn_Reset_DwsPanel);
            this.groupBox35.Controls.Add(this.Label_LedTowerRed_DwsPanel);
            this.groupBox35.Location = new System.Drawing.Point(4, 17);
            this.groupBox35.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox35.Size = new System.Drawing.Size(86, 104);
            this.groupBox35.TabIndex = 29;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "DWS盤";
            // 
            // Label_LedTowerWhite_DwsPanel
            // 
            this.Label_LedTowerWhite_DwsPanel.AutoSize = true;
            this.Label_LedTowerWhite_DwsPanel.Location = new System.Drawing.Point(27, 89);
            this.Label_LedTowerWhite_DwsPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_LedTowerWhite_DwsPanel.Name = "Label_LedTowerWhite_DwsPanel";
            this.Label_LedTowerWhite_DwsPanel.Size = new System.Drawing.Size(20, 12);
            this.Label_LedTowerWhite_DwsPanel.TabIndex = 30;
            this.Label_LedTowerWhite_DwsPanel.Text = "Wh";
            // 
            // Label_LedTowerGreen_DwsPanel
            // 
            this.Label_LedTowerGreen_DwsPanel.AutoSize = true;
            this.Label_LedTowerGreen_DwsPanel.Location = new System.Drawing.Point(4, 89);
            this.Label_LedTowerGreen_DwsPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_LedTowerGreen_DwsPanel.Name = "Label_LedTowerGreen_DwsPanel";
            this.Label_LedTowerGreen_DwsPanel.Size = new System.Drawing.Size(19, 12);
            this.Label_LedTowerGreen_DwsPanel.TabIndex = 29;
            this.Label_LedTowerGreen_DwsPanel.Text = "Gn";
            // 
            // Label_LedTowerYellow_DwsPanel
            // 
            this.Label_LedTowerYellow_DwsPanel.AutoSize = true;
            this.Label_LedTowerYellow_DwsPanel.Location = new System.Drawing.Point(29, 72);
            this.Label_LedTowerYellow_DwsPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_LedTowerYellow_DwsPanel.Name = "Label_LedTowerYellow_DwsPanel";
            this.Label_LedTowerYellow_DwsPanel.Size = new System.Drawing.Size(15, 12);
            this.Label_LedTowerYellow_DwsPanel.TabIndex = 28;
            this.Label_LedTowerYellow_DwsPanel.Text = "Yl";
            // 
            // Label_LedTowerBlue_DwsPanel
            // 
            this.Label_LedTowerBlue_DwsPanel.AutoSize = true;
            this.Label_LedTowerBlue_DwsPanel.Location = new System.Drawing.Point(48, 72);
            this.Label_LedTowerBlue_DwsPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_LedTowerBlue_DwsPanel.Name = "Label_LedTowerBlue_DwsPanel";
            this.Label_LedTowerBlue_DwsPanel.Size = new System.Drawing.Size(29, 12);
            this.Label_LedTowerBlue_DwsPanel.TabIndex = 27;
            this.Label_LedTowerBlue_DwsPanel.Text = "Buzz";
            // 
            // CheckBox_EstopBtn_DwsPanel
            // 
            this.CheckBox_EstopBtn_DwsPanel.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_EstopBtn_DwsPanel.AutoSize = true;
            this.CheckBox_EstopBtn_DwsPanel.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_EstopBtn_DwsPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_EstopBtn_DwsPanel.Location = new System.Drawing.Point(4, 17);
            this.CheckBox_EstopBtn_DwsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_EstopBtn_DwsPanel.Name = "CheckBox_EstopBtn_DwsPanel";
            this.CheckBox_EstopBtn_DwsPanel.Size = new System.Drawing.Size(44, 22);
            this.CheckBox_EstopBtn_DwsPanel.TabIndex = 26;
            this.CheckBox_EstopBtn_DwsPanel.Text = "Estop";
            this.CheckBox_EstopBtn_DwsPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_EstopBtn_DwsPanel.UseVisualStyleBackColor = true;
            this.CheckBox_EstopBtn_DwsPanel.CheckedChanged += new System.EventHandler(this.CheckBox_EstopBtn_DwsPanel_CheckedChanged);
            // 
            // Btn_Reset_DwsPanel
            // 
            this.Btn_Reset_DwsPanel.Location = new System.Drawing.Point(4, 42);
            this.Btn_Reset_DwsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Reset_DwsPanel.Name = "Btn_Reset_DwsPanel";
            this.Btn_Reset_DwsPanel.Size = new System.Drawing.Size(44, 24);
            this.Btn_Reset_DwsPanel.TabIndex = 25;
            this.Btn_Reset_DwsPanel.Text = "Reset";
            this.Btn_Reset_DwsPanel.UseVisualStyleBackColor = true;
            this.Btn_Reset_DwsPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_DwsPanel_MouseDown);
            this.Btn_Reset_DwsPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_DwsPanel_MouseUp);
            // 
            // Label_LedTowerRed_DwsPanel
            // 
            this.Label_LedTowerRed_DwsPanel.AutoSize = true;
            this.Label_LedTowerRed_DwsPanel.Location = new System.Drawing.Point(4, 72);
            this.Label_LedTowerRed_DwsPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_LedTowerRed_DwsPanel.Name = "Label_LedTowerRed_DwsPanel";
            this.Label_LedTowerRed_DwsPanel.Size = new System.Drawing.Size(19, 12);
            this.Label_LedTowerRed_DwsPanel.TabIndex = 17;
            this.Label_LedTowerRed_DwsPanel.Text = "Rd";
            // 
            // groupBox36
            // 
            this.groupBox36.Controls.Add(this.Btn_Reset_NorthPanel);
            this.groupBox36.Controls.Add(this.Label_LedTower_NorthPanel);
            this.groupBox36.Location = new System.Drawing.Point(3, 126);
            this.groupBox36.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox36.Size = new System.Drawing.Size(87, 66);
            this.groupBox36.TabIndex = 30;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "NORTH盤";
            // 
            // Btn_Reset_NorthPanel
            // 
            this.Btn_Reset_NorthPanel.Location = new System.Drawing.Point(5, 34);
            this.Btn_Reset_NorthPanel.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Reset_NorthPanel.Name = "Btn_Reset_NorthPanel";
            this.Btn_Reset_NorthPanel.Size = new System.Drawing.Size(44, 24);
            this.Btn_Reset_NorthPanel.TabIndex = 31;
            this.Btn_Reset_NorthPanel.Text = "Reset";
            this.Btn_Reset_NorthPanel.UseVisualStyleBackColor = true;
            this.Btn_Reset_NorthPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_NorthPanel_MouseDown);
            this.Btn_Reset_NorthPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_NorthPanel_MouseUp);
            // 
            // Label_LedTower_NorthPanel
            // 
            this.Label_LedTower_NorthPanel.AutoSize = true;
            this.Label_LedTower_NorthPanel.Location = new System.Drawing.Point(4, 20);
            this.Label_LedTower_NorthPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_LedTower_NorthPanel.Name = "Label_LedTower_NorthPanel";
            this.Label_LedTower_NorthPanel.Size = new System.Drawing.Size(23, 12);
            this.Label_LedTower_NorthPanel.TabIndex = 17;
            this.Label_LedTower_NorthPanel.Text = "---";
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.Label_LedTower_SouthPanel);
            this.groupBox37.Location = new System.Drawing.Point(3, 197);
            this.groupBox37.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox37.Size = new System.Drawing.Size(87, 66);
            this.groupBox37.TabIndex = 31;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "SOUTH盤";
            // 
            // Label_LedTower_SouthPanel
            // 
            this.Label_LedTower_SouthPanel.AutoSize = true;
            this.Label_LedTower_SouthPanel.Location = new System.Drawing.Point(4, 20);
            this.Label_LedTower_SouthPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_LedTower_SouthPanel.Name = "Label_LedTower_SouthPanel";
            this.Label_LedTower_SouthPanel.Size = new System.Drawing.Size(23, 12);
            this.Label_LedTower_SouthPanel.TabIndex = 17;
            this.Label_LedTower_SouthPanel.Text = "---";
            // 
            // GroupBox_MaintArea
            // 
            this.GroupBox_MaintArea.Controls.Add(this.groupBox5);
            this.GroupBox_MaintArea.Controls.Add(this.GroupBox_);
            this.GroupBox_MaintArea.Controls.Add(this.GroupBox_Ctor_MaintArea);
            this.GroupBox_MaintArea.Controls.Add(this.Label_BotHPtoCell);
            this.GroupBox_MaintArea.Controls.Add(this.CheckBox_BOT_HP);
            this.GroupBox_MaintArea.Location = new System.Drawing.Point(436, 433);
            this.GroupBox_MaintArea.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_MaintArea.Name = "GroupBox_MaintArea";
            this.GroupBox_MaintArea.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_MaintArea.Size = new System.Drawing.Size(276, 155);
            this.GroupBox_MaintArea.TabIndex = 26;
            this.GroupBox_MaintArea.TabStop = false;
            this.GroupBox_MaintArea.Text = "メンテナンスエリア";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Label_MaintenanceStatus);
            this.groupBox5.Location = new System.Drawing.Point(159, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(102, 40);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "切替許可　灯";
            // 
            // Label_MaintenanceStatus
            // 
            this.Label_MaintenanceStatus.AutoSize = true;
            this.Label_MaintenanceStatus.Location = new System.Drawing.Point(5, 15);
            this.Label_MaintenanceStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_MaintenanceStatus.Name = "Label_MaintenanceStatus";
            this.Label_MaintenanceStatus.Size = new System.Drawing.Size(23, 12);
            this.Label_MaintenanceStatus.TabIndex = 39;
            this.Label_MaintenanceStatus.Text = "---";
            // 
            // GroupBox_
            // 
            this.GroupBox_.Controls.Add(this.RadioButton_MaintArea_AisleMode);
            this.GroupBox_.Controls.Add(this.RadioButton_MaintArea_MaintMode);
            this.GroupBox_.Location = new System.Drawing.Point(90, 16);
            this.GroupBox_.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_.Name = "GroupBox_";
            this.GroupBox_.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_.Size = new System.Drawing.Size(64, 60);
            this.GroupBox_.TabIndex = 30;
            this.GroupBox_.TabStop = false;
            this.GroupBox_.Text = "KeySw";
            // 
            // RadioButton_MaintArea_AisleMode
            // 
            this.RadioButton_MaintArea_AisleMode.AutoSize = true;
            this.RadioButton_MaintArea_AisleMode.Location = new System.Drawing.Point(4, 36);
            this.RadioButton_MaintArea_AisleMode.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_MaintArea_AisleMode.Name = "RadioButton_MaintArea_AisleMode";
            this.RadioButton_MaintArea_AisleMode.Size = new System.Drawing.Size(49, 16);
            this.RadioButton_MaintArea_AisleMode.TabIndex = 7;
            this.RadioButton_MaintArea_AisleMode.TabStop = true;
            this.RadioButton_MaintArea_AisleMode.Text = "Aisle";
            this.RadioButton_MaintArea_AisleMode.UseVisualStyleBackColor = true;
            this.RadioButton_MaintArea_AisleMode.CheckedChanged += new System.EventHandler(this.RadioButton_MaintArea_Aisle_CheckedChanged);
            // 
            // GroupBox_Ctor_MaintArea
            // 
            this.GroupBox_Ctor_MaintArea.Controls.Add(this.CheckBox_ContactorFdbk_MaintArea);
            this.GroupBox_Ctor_MaintArea.Controls.Add(this.Label_ContactorFdbk_MaintArea);
            this.GroupBox_Ctor_MaintArea.Controls.Add(this.Label_ContactorPlcOut_MaintArea);
            this.GroupBox_Ctor_MaintArea.Location = new System.Drawing.Point(4, 42);
            this.GroupBox_Ctor_MaintArea.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_MaintArea.Name = "GroupBox_Ctor_MaintArea";
            this.GroupBox_Ctor_MaintArea.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_MaintArea.Size = new System.Drawing.Size(82, 71);
            this.GroupBox_Ctor_MaintArea.TabIndex = 16;
            this.GroupBox_Ctor_MaintArea.TabStop = false;
            this.GroupBox_Ctor_MaintArea.Text = "コンタクタ";
            // 
            // CheckBox_ContactorFdbk_MaintArea
            // 
            this.CheckBox_ContactorFdbk_MaintArea.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorFdbk_MaintArea.AutoSize = true;
            this.CheckBox_ContactorFdbk_MaintArea.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_MaintArea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorFdbk_MaintArea.Location = new System.Drawing.Point(4, 43);
            this.CheckBox_ContactorFdbk_MaintArea.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorFdbk_MaintArea.Name = "CheckBox_ContactorFdbk_MaintArea";
            this.CheckBox_ContactorFdbk_MaintArea.Size = new System.Drawing.Size(30, 22);
            this.CheckBox_ContactorFdbk_MaintArea.TabIndex = 28;
            this.CheckBox_ContactorFdbk_MaintArea.Text = "FB";
            this.CheckBox_ContactorFdbk_MaintArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_MaintArea.UseVisualStyleBackColor = true;
            this.CheckBox_ContactorFdbk_MaintArea.CheckedChanged += new System.EventHandler(this.CheckBox_ContactorFdbk_MaintArea_CheckedChanged);
            // 
            // Label_ContactorFdbk_MaintArea
            // 
            this.Label_ContactorFdbk_MaintArea.AutoSize = true;
            this.Label_ContactorFdbk_MaintArea.Location = new System.Drawing.Point(43, 48);
            this.Label_ContactorFdbk_MaintArea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorFdbk_MaintArea.Name = "Label_ContactorFdbk_MaintArea";
            this.Label_ContactorFdbk_MaintArea.Size = new System.Drawing.Size(20, 12);
            this.Label_ContactorFdbk_MaintArea.TabIndex = 13;
            this.Label_ContactorFdbk_MaintArea.Text = "FB";
            // 
            // Label_ContactorPlcOut_MaintArea
            // 
            this.Label_ContactorPlcOut_MaintArea.AutoSize = true;
            this.Label_ContactorPlcOut_MaintArea.Location = new System.Drawing.Point(8, 22);
            this.Label_ContactorPlcOut_MaintArea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorPlcOut_MaintArea.Name = "Label_ContactorPlcOut_MaintArea";
            this.Label_ContactorPlcOut_MaintArea.Size = new System.Drawing.Size(23, 12);
            this.Label_ContactorPlcOut_MaintArea.TabIndex = 10;
            this.Label_ContactorPlcOut_MaintArea.Text = "---";
            // 
            // Label_BotHPtoCell
            // 
            this.Label_BotHPtoCell.AutoSize = true;
            this.Label_BotHPtoCell.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Label_BotHPtoCell.Location = new System.Drawing.Point(65, 21);
            this.Label_BotHPtoCell.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_BotHPtoCell.Name = "Label_BotHPtoCell";
            this.Label_BotHPtoCell.Size = new System.Drawing.Size(20, 12);
            this.Label_BotHPtoCell.TabIndex = 21;
            this.Label_BotHPtoCell.Text = "HP";
            // 
            // CheckBox_BOT_HP
            // 
            this.CheckBox_BOT_HP.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_BOT_HP.AutoSize = true;
            this.CheckBox_BOT_HP.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_BOT_HP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_BOT_HP.Location = new System.Drawing.Point(4, 16);
            this.CheckBox_BOT_HP.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_BOT_HP.Name = "CheckBox_BOT_HP";
            this.CheckBox_BOT_HP.Size = new System.Drawing.Size(57, 22);
            this.CheckBox_BOT_HP.TabIndex = 35;
            this.CheckBox_BOT_HP.Text = "BOT HP";
            this.CheckBox_BOT_HP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_BOT_HP.UseVisualStyleBackColor = true;
            this.CheckBox_BOT_HP.CheckedChanged += new System.EventHandler(this.CheckBox_BOT_HP_CheckedChanged);
            // 
            // GroupBox_Panels
            // 
            this.GroupBox_Panels.Controls.Add(this.groupBox35);
            this.GroupBox_Panels.Controls.Add(this.groupBox36);
            this.GroupBox_Panels.Controls.Add(this.groupBox37);
            this.GroupBox_Panels.Location = new System.Drawing.Point(9, 193);
            this.GroupBox_Panels.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Panels.Name = "GroupBox_Panels";
            this.GroupBox_Panels.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Panels.Size = new System.Drawing.Size(99, 273);
            this.GroupBox_Panels.TabIndex = 32;
            this.GroupBox_Panels.TabStop = false;
            this.GroupBox_Panels.Text = "PANELS";
            // 
            // Btn_BuzzerAck
            // 
            this.Btn_BuzzerAck.Location = new System.Drawing.Point(9, 470);
            this.Btn_BuzzerAck.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_BuzzerAck.Name = "Btn_BuzzerAck";
            this.Btn_BuzzerAck.Size = new System.Drawing.Size(77, 24);
            this.Btn_BuzzerAck.TabIndex = 32;
            this.Btn_BuzzerAck.Text = "Buzzer Ack";
            this.Btn_BuzzerAck.UseVisualStyleBackColor = true;
            this.Btn_BuzzerAck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_BuzzerAck_MouseDown);
            this.Btn_BuzzerAck.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_BuzzerAck_MouseUp);
            // 
            // ListBox_Log
            // 
            this.ListBox_Log.FormattingEnabled = true;
            this.ListBox_Log.ItemHeight = 12;
            this.ListBox_Log.Location = new System.Drawing.Point(13, 590);
            this.ListBox_Log.Margin = new System.Windows.Forms.Padding(2);
            this.ListBox_Log.Name = "ListBox_Log";
            this.ListBox_Log.Size = new System.Drawing.Size(409, 76);
            this.ListBox_Log.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 576);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "Log";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.GroupBox_Door_TDWS);
            this.groupBox4.Controls.Add(this.CheckBox_AllTDWSs);
            this.groupBox4.Controls.Add(this.ComboBox_TowerDWS);
            this.groupBox4.Controls.Add(this.GroupBox_Estop_TDWS);
            this.groupBox4.Controls.Add(this.GroupBox_OpBox_TDWS);
            this.groupBox4.Controls.Add(this.GroupBox_SafetyBoard_TDWS);
            this.groupBox4.Controls.Add(this.GroupBox_Contactors_TDWS);
            this.groupBox4.Controls.Add(this.GroupBox_ZoningTDWS);
            this.groupBox4.Location = new System.Drawing.Point(726, 10);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(272, 463);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TowerDWS";
            // 
            // GroupBox_Door_TDWS
            // 
            this.GroupBox_Door_TDWS.Controls.Add(this.Label_UnlockDoor_TDWS);
            this.GroupBox_Door_TDWS.Controls.Add(this.Label_DoorIsLocked_TDWS);
            this.GroupBox_Door_TDWS.Controls.Add(this.GroupBox_DoorSensor_TDWS);
            this.GroupBox_Door_TDWS.Location = new System.Drawing.Point(137, 237);
            this.GroupBox_Door_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Door_TDWS.Name = "GroupBox_Door_TDWS";
            this.GroupBox_Door_TDWS.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Door_TDWS.Size = new System.Drawing.Size(129, 88);
            this.GroupBox_Door_TDWS.TabIndex = 35;
            this.GroupBox_Door_TDWS.TabStop = false;
            this.GroupBox_Door_TDWS.Text = "扉";
            // 
            // Label_UnlockDoor_TDWS
            // 
            this.Label_UnlockDoor_TDWS.AutoSize = true;
            this.Label_UnlockDoor_TDWS.Location = new System.Drawing.Point(50, 61);
            this.Label_UnlockDoor_TDWS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_UnlockDoor_TDWS.Name = "Label_UnlockDoor_TDWS";
            this.Label_UnlockDoor_TDWS.Size = new System.Drawing.Size(23, 12);
            this.Label_UnlockDoor_TDWS.TabIndex = 31;
            this.Label_UnlockDoor_TDWS.Text = "---";
            // 
            // Label_DoorIsLocked_TDWS
            // 
            this.Label_DoorIsLocked_TDWS.AutoSize = true;
            this.Label_DoorIsLocked_TDWS.Location = new System.Drawing.Point(4, 61);
            this.Label_DoorIsLocked_TDWS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_DoorIsLocked_TDWS.Name = "Label_DoorIsLocked_TDWS";
            this.Label_DoorIsLocked_TDWS.Size = new System.Drawing.Size(23, 12);
            this.Label_DoorIsLocked_TDWS.TabIndex = 30;
            this.Label_DoorIsLocked_TDWS.Text = "---";
            // 
            // GroupBox_DoorSensor_TDWS
            // 
            this.GroupBox_DoorSensor_TDWS.Controls.Add(this.RadioButton_DoorClosed_TDWS);
            this.GroupBox_DoorSensor_TDWS.Controls.Add(this.RadioButton_DoorOpen_TDWS);
            this.GroupBox_DoorSensor_TDWS.Location = new System.Drawing.Point(4, 17);
            this.GroupBox_DoorSensor_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_DoorSensor_TDWS.Name = "GroupBox_DoorSensor_TDWS";
            this.GroupBox_DoorSensor_TDWS.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_DoorSensor_TDWS.Size = new System.Drawing.Size(82, 40);
            this.GroupBox_DoorSensor_TDWS.TabIndex = 29;
            this.GroupBox_DoorSensor_TDWS.TabStop = false;
            this.GroupBox_DoorSensor_TDWS.Text = "Sensor";
            // 
            // RadioButton_DoorClosed_TDWS
            // 
            this.RadioButton_DoorClosed_TDWS.AutoSize = true;
            this.RadioButton_DoorClosed_TDWS.Location = new System.Drawing.Point(41, 18);
            this.RadioButton_DoorClosed_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_DoorClosed_TDWS.Name = "RadioButton_DoorClosed_TDWS";
            this.RadioButton_DoorClosed_TDWS.Size = new System.Drawing.Size(35, 16);
            this.RadioButton_DoorClosed_TDWS.TabIndex = 7;
            this.RadioButton_DoorClosed_TDWS.TabStop = true;
            this.RadioButton_DoorClosed_TDWS.Text = "閉";
            this.RadioButton_DoorClosed_TDWS.UseVisualStyleBackColor = true;
            this.RadioButton_DoorClosed_TDWS.CheckedChanged += new System.EventHandler(this.RadioButton_DoorClosed_TDWS_CheckedChanged);
            // 
            // RadioButton_DoorOpen_TDWS
            // 
            this.RadioButton_DoorOpen_TDWS.AutoSize = true;
            this.RadioButton_DoorOpen_TDWS.Location = new System.Drawing.Point(4, 17);
            this.RadioButton_DoorOpen_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_DoorOpen_TDWS.Name = "RadioButton_DoorOpen_TDWS";
            this.RadioButton_DoorOpen_TDWS.Size = new System.Drawing.Size(35, 16);
            this.RadioButton_DoorOpen_TDWS.TabIndex = 6;
            this.RadioButton_DoorOpen_TDWS.TabStop = true;
            this.RadioButton_DoorOpen_TDWS.Text = "開";
            this.RadioButton_DoorOpen_TDWS.UseVisualStyleBackColor = true;
            this.RadioButton_DoorOpen_TDWS.CheckedChanged += new System.EventHandler(this.RadioButton_DoorOpen_TDWS_CheckedChanged);
            // 
            // CheckBox_AllTDWSs
            // 
            this.CheckBox_AllTDWSs.AutoSize = true;
            this.CheckBox_AllTDWSs.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBox_AllTDWSs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckBox_AllTDWSs.Location = new System.Drawing.Point(131, 17);
            this.CheckBox_AllTDWSs.Name = "CheckBox_AllTDWSs";
            this.CheckBox_AllTDWSs.Size = new System.Drawing.Size(81, 16);
            this.CheckBox_AllTDWSs.TabIndex = 39;
            this.CheckBox_AllTDWSs.Text = "All TDWS";
            this.CheckBox_AllTDWSs.UseVisualStyleBackColor = true;
            this.CheckBox_AllTDWSs.CheckedChanged += new System.EventHandler(this.CheckBox_AllTDWSs_CheckedChanged);
            // 
            // ComboBox_TowerDWS
            // 
            this.ComboBox_TowerDWS.FormattingEnabled = true;
            this.ComboBox_TowerDWS.Location = new System.Drawing.Point(4, 17);
            this.ComboBox_TowerDWS.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBox_TowerDWS.Name = "ComboBox_TowerDWS";
            this.ComboBox_TowerDWS.Size = new System.Drawing.Size(117, 20);
            this.ComboBox_TowerDWS.TabIndex = 0;
            this.ComboBox_TowerDWS.SelectedIndexChanged += new System.EventHandler(this.ComboBox_TowerDWS_SelectedIndexChanged);
            // 
            // GroupBox_Estop_TDWS
            // 
            this.GroupBox_Estop_TDWS.Controls.Add(this.CheckBox_ReqCompleteFlag_TDWS);
            this.GroupBox_Estop_TDWS.Controls.Add(this.Label_StopStatus_TDWS);
            this.GroupBox_Estop_TDWS.Controls.Add(this.Label_StopRequest_TDWS);
            this.GroupBox_Estop_TDWS.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBox_Estop_TDWS.Location = new System.Drawing.Point(137, 167);
            this.GroupBox_Estop_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Estop_TDWS.Name = "GroupBox_Estop_TDWS";
            this.GroupBox_Estop_TDWS.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Estop_TDWS.Size = new System.Drawing.Size(96, 66);
            this.GroupBox_Estop_TDWS.TabIndex = 34;
            this.GroupBox_Estop_TDWS.TabStop = false;
            this.GroupBox_Estop_TDWS.Text = "非常停止";
            // 
            // CheckBox_ReqCompleteFlag_TDWS
            // 
            this.CheckBox_ReqCompleteFlag_TDWS.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ReqCompleteFlag_TDWS.AutoSize = true;
            this.CheckBox_ReqCompleteFlag_TDWS.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ReqCompleteFlag_TDWS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ReqCompleteFlag_TDWS.Location = new System.Drawing.Point(8, 20);
            this.CheckBox_ReqCompleteFlag_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ReqCompleteFlag_TDWS.Name = "CheckBox_ReqCompleteFlag_TDWS";
            this.CheckBox_ReqCompleteFlag_TDWS.Size = new System.Drawing.Size(39, 22);
            this.CheckBox_ReqCompleteFlag_TDWS.TabIndex = 10;
            this.CheckBox_ReqCompleteFlag_TDWS.Text = "完了";
            this.CheckBox_ReqCompleteFlag_TDWS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ReqCompleteFlag_TDWS.UseVisualStyleBackColor = true;
            this.CheckBox_ReqCompleteFlag_TDWS.CheckedChanged += new System.EventHandler(this.CheckBox_ReqCompleteFlag_TDWS_CheckedChanged);
            // 
            // Label_StopStatus_TDWS
            // 
            this.Label_StopStatus_TDWS.AutoSize = true;
            this.Label_StopStatus_TDWS.Location = new System.Drawing.Point(54, 34);
            this.Label_StopStatus_TDWS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_StopStatus_TDWS.Name = "Label_StopStatus_TDWS";
            this.Label_StopStatus_TDWS.Size = new System.Drawing.Size(29, 12);
            this.Label_StopStatus_TDWS.TabIndex = 20;
            this.Label_StopStatus_TDWS.Text = "状態";
            // 
            // Label_StopRequest_TDWS
            // 
            this.Label_StopRequest_TDWS.AutoSize = true;
            this.Label_StopRequest_TDWS.Location = new System.Drawing.Point(54, 14);
            this.Label_StopRequest_TDWS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_StopRequest_TDWS.Name = "Label_StopRequest_TDWS";
            this.Label_StopRequest_TDWS.Size = new System.Drawing.Size(29, 12);
            this.Label_StopRequest_TDWS.TabIndex = 18;
            this.Label_StopRequest_TDWS.Text = "要求";
            // 
            // GroupBox_OpBox_TDWS
            // 
            this.GroupBox_OpBox_TDWS.Controls.Add(this.GroupBox_KeySwitch_TDWS);
            this.GroupBox_OpBox_TDWS.Controls.Add(this.Label_OpBoxLed_TDWS);
            this.GroupBox_OpBox_TDWS.Controls.Add(this.CheckBox_EstopBtn_TDWS);
            this.GroupBox_OpBox_TDWS.Controls.Add(this.Btn_Reset_TDWS);
            this.GroupBox_OpBox_TDWS.Controls.Add(this.Btn_Run_TDWS);
            this.GroupBox_OpBox_TDWS.Location = new System.Drawing.Point(4, 41);
            this.GroupBox_OpBox_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_OpBox_TDWS.Name = "GroupBox_OpBox_TDWS";
            this.GroupBox_OpBox_TDWS.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_OpBox_TDWS.Size = new System.Drawing.Size(129, 117);
            this.GroupBox_OpBox_TDWS.TabIndex = 30;
            this.GroupBox_OpBox_TDWS.TabStop = false;
            this.GroupBox_OpBox_TDWS.Text = "OpBox";
            // 
            // GroupBox_KeySwitch_TDWS
            // 
            this.GroupBox_KeySwitch_TDWS.Controls.Add(this.RadioButton_Ready_TDWS);
            this.GroupBox_KeySwitch_TDWS.Controls.Add(this.RadioButton_Req_TDWS);
            this.GroupBox_KeySwitch_TDWS.Location = new System.Drawing.Point(57, 15);
            this.GroupBox_KeySwitch_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_KeySwitch_TDWS.Name = "GroupBox_KeySwitch_TDWS";
            this.GroupBox_KeySwitch_TDWS.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_KeySwitch_TDWS.Size = new System.Drawing.Size(64, 62);
            this.GroupBox_KeySwitch_TDWS.TabIndex = 29;
            this.GroupBox_KeySwitch_TDWS.TabStop = false;
            this.GroupBox_KeySwitch_TDWS.Text = "KeySw";
            // 
            // RadioButton_Ready_TDWS
            // 
            this.RadioButton_Ready_TDWS.AutoSize = true;
            this.RadioButton_Ready_TDWS.Location = new System.Drawing.Point(5, 37);
            this.RadioButton_Ready_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Ready_TDWS.Name = "RadioButton_Ready_TDWS";
            this.RadioButton_Ready_TDWS.Size = new System.Drawing.Size(55, 16);
            this.RadioButton_Ready_TDWS.TabIndex = 5;
            this.RadioButton_Ready_TDWS.TabStop = true;
            this.RadioButton_Ready_TDWS.Text = "Ready";
            this.RadioButton_Ready_TDWS.UseVisualStyleBackColor = true;
            this.RadioButton_Ready_TDWS.CheckedChanged += new System.EventHandler(this.RadioButton_Ready_TDWS_CheckedChanged);
            // 
            // RadioButton_Req_TDWS
            // 
            this.RadioButton_Req_TDWS.AutoSize = true;
            this.RadioButton_Req_TDWS.Location = new System.Drawing.Point(5, 17);
            this.RadioButton_Req_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Req_TDWS.Name = "RadioButton_Req_TDWS";
            this.RadioButton_Req_TDWS.Size = new System.Drawing.Size(43, 16);
            this.RadioButton_Req_TDWS.TabIndex = 4;
            this.RadioButton_Req_TDWS.TabStop = true;
            this.RadioButton_Req_TDWS.Text = "Req";
            this.RadioButton_Req_TDWS.UseVisualStyleBackColor = true;
            this.RadioButton_Req_TDWS.CheckedChanged += new System.EventHandler(this.RadioButton_Req_TDWS_CheckedChanged);
            // 
            // Label_OpBoxLed_TDWS
            // 
            this.Label_OpBoxLed_TDWS.AutoSize = true;
            this.Label_OpBoxLed_TDWS.Location = new System.Drawing.Point(4, 93);
            this.Label_OpBoxLed_TDWS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_OpBoxLed_TDWS.Name = "Label_OpBoxLed_TDWS";
            this.Label_OpBoxLed_TDWS.Size = new System.Drawing.Size(23, 12);
            this.Label_OpBoxLed_TDWS.TabIndex = 5;
            this.Label_OpBoxLed_TDWS.Text = "---";
            // 
            // CheckBox_EstopBtn_TDWS
            // 
            this.CheckBox_EstopBtn_TDWS.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_EstopBtn_TDWS.AutoSize = true;
            this.CheckBox_EstopBtn_TDWS.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_EstopBtn_TDWS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_EstopBtn_TDWS.Location = new System.Drawing.Point(4, 17);
            this.CheckBox_EstopBtn_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_EstopBtn_TDWS.Name = "CheckBox_EstopBtn_TDWS";
            this.CheckBox_EstopBtn_TDWS.Size = new System.Drawing.Size(44, 22);
            this.CheckBox_EstopBtn_TDWS.TabIndex = 5;
            this.CheckBox_EstopBtn_TDWS.Text = "Estop";
            this.CheckBox_EstopBtn_TDWS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_EstopBtn_TDWS.UseVisualStyleBackColor = true;
            this.CheckBox_EstopBtn_TDWS.CheckedChanged += new System.EventHandler(this.CheckBox_EstopBtn_TDWS_CheckedChanged);
            // 
            // Btn_Reset_TDWS
            // 
            this.Btn_Reset_TDWS.Location = new System.Drawing.Point(4, 42);
            this.Btn_Reset_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Reset_TDWS.Name = "Btn_Reset_TDWS";
            this.Btn_Reset_TDWS.Size = new System.Drawing.Size(44, 22);
            this.Btn_Reset_TDWS.TabIndex = 3;
            this.Btn_Reset_TDWS.Text = "Reset";
            this.Btn_Reset_TDWS.UseVisualStyleBackColor = true;
            this.Btn_Reset_TDWS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_TDWS_MouseDown);
            this.Btn_Reset_TDWS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_TDWS_MouseUp);
            // 
            // Btn_Run_TDWS
            // 
            this.Btn_Run_TDWS.Location = new System.Drawing.Point(4, 67);
            this.Btn_Run_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Run_TDWS.Name = "Btn_Run_TDWS";
            this.Btn_Run_TDWS.Size = new System.Drawing.Size(44, 22);
            this.Btn_Run_TDWS.TabIndex = 6;
            this.Btn_Run_TDWS.Text = "起動";
            this.Btn_Run_TDWS.UseVisualStyleBackColor = true;
            this.Btn_Run_TDWS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Run_TDWS_MouseDown);
            this.Btn_Run_TDWS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Run_TDWS_MouseUp);
            // 
            // GroupBox_Contactors_TDWS
            // 
            this.GroupBox_Contactors_TDWS.Controls.Add(this.Label_ContactorLamp_TDWS);
            this.GroupBox_Contactors_TDWS.Controls.Add(this.GroupBox_Ctor_TDWStower);
            this.GroupBox_Contactors_TDWS.Controls.Add(this.CheckBox_FBAuto_TDWS);
            this.GroupBox_Contactors_TDWS.Controls.Add(this.GroupBox_Ctor_TDWSpick);
            this.GroupBox_Contactors_TDWS.Location = new System.Drawing.Point(4, 162);
            this.GroupBox_Contactors_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Contactors_TDWS.Name = "GroupBox_Contactors_TDWS";
            this.GroupBox_Contactors_TDWS.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Contactors_TDWS.Size = new System.Drawing.Size(129, 283);
            this.GroupBox_Contactors_TDWS.TabIndex = 31;
            this.GroupBox_Contactors_TDWS.TabStop = false;
            this.GroupBox_Contactors_TDWS.Text = "コンタクタ";
            // 
            // Label_ContactorLamp_TDWS
            // 
            this.Label_ContactorLamp_TDWS.AutoSize = true;
            this.Label_ContactorLamp_TDWS.Location = new System.Drawing.Point(4, 253);
            this.Label_ContactorLamp_TDWS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorLamp_TDWS.Name = "Label_ContactorLamp_TDWS";
            this.Label_ContactorLamp_TDWS.Size = new System.Drawing.Size(23, 12);
            this.Label_ContactorLamp_TDWS.TabIndex = 30;
            this.Label_ContactorLamp_TDWS.Text = "---";
            // 
            // GroupBox_Ctor_TDWStower
            // 
            this.GroupBox_Ctor_TDWStower.Controls.Add(this.CheckBox_ContactorTripped_TDWStower);
            this.GroupBox_Ctor_TDWStower.Controls.Add(this.CheckBox_ContactorFdbk_TDWStower);
            this.GroupBox_Ctor_TDWStower.Controls.Add(this.Label_ContactorFdbk_TDWStower);
            this.GroupBox_Ctor_TDWStower.Controls.Add(this.CheckBox_ContactorOnOff_TDWStower);
            this.GroupBox_Ctor_TDWStower.Controls.Add(this.Label_ContactorPlcOut_TDWStower);
            this.GroupBox_Ctor_TDWStower.Location = new System.Drawing.Point(4, 121);
            this.GroupBox_Ctor_TDWStower.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_TDWStower.Name = "GroupBox_Ctor_TDWStower";
            this.GroupBox_Ctor_TDWStower.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_TDWStower.Size = new System.Drawing.Size(82, 100);
            this.GroupBox_Ctor_TDWStower.TabIndex = 30;
            this.GroupBox_Ctor_TDWStower.TabStop = false;
            this.GroupBox_Ctor_TDWStower.Text = "Tower side";
            // 
            // CheckBox_ContactorTripped_TDWStower
            // 
            this.CheckBox_ContactorTripped_TDWStower.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorTripped_TDWStower.AutoSize = true;
            this.CheckBox_ContactorTripped_TDWStower.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorTripped_TDWStower.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorTripped_TDWStower.Location = new System.Drawing.Point(4, 70);
            this.CheckBox_ContactorTripped_TDWStower.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorTripped_TDWStower.Name = "CheckBox_ContactorTripped_TDWStower";
            this.CheckBox_ContactorTripped_TDWStower.Size = new System.Drawing.Size(53, 22);
            this.CheckBox_ContactorTripped_TDWStower.TabIndex = 29;
            this.CheckBox_ContactorTripped_TDWStower.Text = "Tripped";
            this.CheckBox_ContactorTripped_TDWStower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorTripped_TDWStower.UseVisualStyleBackColor = true;
            // 
            // CheckBox_ContactorFdbk_TDWStower
            // 
            this.CheckBox_ContactorFdbk_TDWStower.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorFdbk_TDWStower.AutoSize = true;
            this.CheckBox_ContactorFdbk_TDWStower.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_TDWStower.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorFdbk_TDWStower.Location = new System.Drawing.Point(4, 43);
            this.CheckBox_ContactorFdbk_TDWStower.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorFdbk_TDWStower.Name = "CheckBox_ContactorFdbk_TDWStower";
            this.CheckBox_ContactorFdbk_TDWStower.Size = new System.Drawing.Size(30, 22);
            this.CheckBox_ContactorFdbk_TDWStower.TabIndex = 28;
            this.CheckBox_ContactorFdbk_TDWStower.Text = "FB";
            this.CheckBox_ContactorFdbk_TDWStower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_TDWStower.UseVisualStyleBackColor = true;
            this.CheckBox_ContactorFdbk_TDWStower.CheckedChanged += new System.EventHandler(this.CheckBox_ContactorFdbk_TDWStower_CheckedChanged);
            // 
            // Label_ContactorFdbk_TDWStower
            // 
            this.Label_ContactorFdbk_TDWStower.AutoSize = true;
            this.Label_ContactorFdbk_TDWStower.Location = new System.Drawing.Point(43, 48);
            this.Label_ContactorFdbk_TDWStower.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorFdbk_TDWStower.Name = "Label_ContactorFdbk_TDWStower";
            this.Label_ContactorFdbk_TDWStower.Size = new System.Drawing.Size(20, 12);
            this.Label_ContactorFdbk_TDWStower.TabIndex = 13;
            this.Label_ContactorFdbk_TDWStower.Text = "FB";
            // 
            // CheckBox_ContactorOnOff_TDWStower
            // 
            this.CheckBox_ContactorOnOff_TDWStower.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorOnOff_TDWStower.AutoSize = true;
            this.CheckBox_ContactorOnOff_TDWStower.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorOnOff_TDWStower.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.CheckBox_ContactorOnOff_TDWStower.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorOnOff_TDWStower.Location = new System.Drawing.Point(4, 17);
            this.CheckBox_ContactorOnOff_TDWStower.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorOnOff_TDWStower.Name = "CheckBox_ContactorOnOff_TDWStower";
            this.CheckBox_ContactorOnOff_TDWStower.Size = new System.Drawing.Size(31, 22);
            this.CheckBox_ContactorOnOff_TDWStower.TabIndex = 10;
            this.CheckBox_ContactorOnOff_TDWStower.Text = "ON";
            this.CheckBox_ContactorOnOff_TDWStower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorOnOff_TDWStower.UseVisualStyleBackColor = true;
            this.CheckBox_ContactorOnOff_TDWStower.CheckedChanged += new System.EventHandler(this.CheckBox_ContactorOnOff_TDWStower_CheckedChanged);
            // 
            // Label_ContactorPlcOut_TDWStower
            // 
            this.Label_ContactorPlcOut_TDWStower.AutoSize = true;
            this.Label_ContactorPlcOut_TDWStower.Location = new System.Drawing.Point(43, 22);
            this.Label_ContactorPlcOut_TDWStower.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorPlcOut_TDWStower.Name = "Label_ContactorPlcOut_TDWStower";
            this.Label_ContactorPlcOut_TDWStower.Size = new System.Drawing.Size(23, 12);
            this.Label_ContactorPlcOut_TDWStower.TabIndex = 10;
            this.Label_ContactorPlcOut_TDWStower.Text = "---";
            // 
            // CheckBox_FBAuto_TDWS
            // 
            this.CheckBox_FBAuto_TDWS.AutoSize = true;
            this.CheckBox_FBAuto_TDWS.Checked = true;
            this.CheckBox_FBAuto_TDWS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_FBAuto_TDWS.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.CheckBox_FBAuto_TDWS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckBox_FBAuto_TDWS.Location = new System.Drawing.Point(5, 226);
            this.CheckBox_FBAuto_TDWS.Name = "CheckBox_FBAuto_TDWS";
            this.CheckBox_FBAuto_TDWS.Size = new System.Drawing.Size(43, 24);
            this.CheckBox_FBAuto_TDWS.TabIndex = 38;
            this.CheckBox_FBAuto_TDWS.Text = "FB\r\nauto";
            this.CheckBox_FBAuto_TDWS.UseVisualStyleBackColor = true;
            // 
            // GroupBox_Ctor_TDWSpick
            // 
            this.GroupBox_Ctor_TDWSpick.Controls.Add(this.CheckBox_ContactorTripped_TDWSpick);
            this.GroupBox_Ctor_TDWSpick.Controls.Add(this.CheckBox_ContactorFdbk_TDWSpick);
            this.GroupBox_Ctor_TDWSpick.Controls.Add(this.Label_ContactorFdbk_TDWSpick);
            this.GroupBox_Ctor_TDWSpick.Controls.Add(this.CheckBox_ContactorOnOff_TDWSpick);
            this.GroupBox_Ctor_TDWSpick.Controls.Add(this.Label_ContactorPlcOut_TDWSpick);
            this.GroupBox_Ctor_TDWSpick.Location = new System.Drawing.Point(4, 17);
            this.GroupBox_Ctor_TDWSpick.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_TDWSpick.Name = "GroupBox_Ctor_TDWSpick";
            this.GroupBox_Ctor_TDWSpick.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_TDWSpick.Size = new System.Drawing.Size(82, 100);
            this.GroupBox_Ctor_TDWSpick.TabIndex = 16;
            this.GroupBox_Ctor_TDWSpick.TabStop = false;
            this.GroupBox_Ctor_TDWSpick.Text = "Pick side";
            // 
            // CheckBox_ContactorTripped_TDWSpick
            // 
            this.CheckBox_ContactorTripped_TDWSpick.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorTripped_TDWSpick.AutoSize = true;
            this.CheckBox_ContactorTripped_TDWSpick.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorTripped_TDWSpick.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorTripped_TDWSpick.Location = new System.Drawing.Point(4, 70);
            this.CheckBox_ContactorTripped_TDWSpick.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorTripped_TDWSpick.Name = "CheckBox_ContactorTripped_TDWSpick";
            this.CheckBox_ContactorTripped_TDWSpick.Size = new System.Drawing.Size(53, 22);
            this.CheckBox_ContactorTripped_TDWSpick.TabIndex = 29;
            this.CheckBox_ContactorTripped_TDWSpick.Text = "Tripped";
            this.CheckBox_ContactorTripped_TDWSpick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorTripped_TDWSpick.UseVisualStyleBackColor = true;
            // 
            // CheckBox_ContactorFdbk_TDWSpick
            // 
            this.CheckBox_ContactorFdbk_TDWSpick.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorFdbk_TDWSpick.AutoSize = true;
            this.CheckBox_ContactorFdbk_TDWSpick.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_TDWSpick.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorFdbk_TDWSpick.Location = new System.Drawing.Point(4, 43);
            this.CheckBox_ContactorFdbk_TDWSpick.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorFdbk_TDWSpick.Name = "CheckBox_ContactorFdbk_TDWSpick";
            this.CheckBox_ContactorFdbk_TDWSpick.Size = new System.Drawing.Size(30, 22);
            this.CheckBox_ContactorFdbk_TDWSpick.TabIndex = 28;
            this.CheckBox_ContactorFdbk_TDWSpick.Text = "FB";
            this.CheckBox_ContactorFdbk_TDWSpick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_TDWSpick.UseVisualStyleBackColor = true;
            this.CheckBox_ContactorFdbk_TDWSpick.CheckedChanged += new System.EventHandler(this.CheckBox_ContactorFdbk_TDWSpick_CheckedChanged);
            // 
            // Label_ContactorFdbk_TDWSpick
            // 
            this.Label_ContactorFdbk_TDWSpick.AutoSize = true;
            this.Label_ContactorFdbk_TDWSpick.Location = new System.Drawing.Point(43, 48);
            this.Label_ContactorFdbk_TDWSpick.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorFdbk_TDWSpick.Name = "Label_ContactorFdbk_TDWSpick";
            this.Label_ContactorFdbk_TDWSpick.Size = new System.Drawing.Size(20, 12);
            this.Label_ContactorFdbk_TDWSpick.TabIndex = 13;
            this.Label_ContactorFdbk_TDWSpick.Text = "FB";
            // 
            // CheckBox_ContactorOnOff_TDWSpick
            // 
            this.CheckBox_ContactorOnOff_TDWSpick.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorOnOff_TDWSpick.AutoSize = true;
            this.CheckBox_ContactorOnOff_TDWSpick.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorOnOff_TDWSpick.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.CheckBox_ContactorOnOff_TDWSpick.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorOnOff_TDWSpick.Location = new System.Drawing.Point(4, 17);
            this.CheckBox_ContactorOnOff_TDWSpick.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorOnOff_TDWSpick.Name = "CheckBox_ContactorOnOff_TDWSpick";
            this.CheckBox_ContactorOnOff_TDWSpick.Size = new System.Drawing.Size(31, 22);
            this.CheckBox_ContactorOnOff_TDWSpick.TabIndex = 10;
            this.CheckBox_ContactorOnOff_TDWSpick.Text = "ON";
            this.CheckBox_ContactorOnOff_TDWSpick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorOnOff_TDWSpick.UseVisualStyleBackColor = true;
            this.CheckBox_ContactorOnOff_TDWSpick.CheckedChanged += new System.EventHandler(this.CheckBox_ContactorOnOff_TDWSpick_CheckedChanged);
            // 
            // Label_ContactorPlcOut_TDWSpick
            // 
            this.Label_ContactorPlcOut_TDWSpick.AutoSize = true;
            this.Label_ContactorPlcOut_TDWSpick.Location = new System.Drawing.Point(43, 22);
            this.Label_ContactorPlcOut_TDWSpick.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorPlcOut_TDWSpick.Name = "Label_ContactorPlcOut_TDWSpick";
            this.Label_ContactorPlcOut_TDWSpick.Size = new System.Drawing.Size(23, 12);
            this.Label_ContactorPlcOut_TDWSpick.TabIndex = 10;
            this.Label_ContactorPlcOut_TDWSpick.Text = "---";
            // 
            // GroupBox_ZoningTDWS
            // 
            this.GroupBox_ZoningTDWS.Controls.Add(this.TextBox_ZoningStatus_TDWS);
            this.GroupBox_ZoningTDWS.Controls.Add(this.label10);
            this.GroupBox_ZoningTDWS.Controls.Add(this.GroupBox_ZoningCellCmd_TDWS);
            this.GroupBox_ZoningTDWS.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBox_ZoningTDWS.Location = new System.Drawing.Point(137, 41);
            this.GroupBox_ZoningTDWS.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_ZoningTDWS.Name = "GroupBox_ZoningTDWS";
            this.GroupBox_ZoningTDWS.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_ZoningTDWS.Size = new System.Drawing.Size(125, 122);
            this.GroupBox_ZoningTDWS.TabIndex = 33;
            this.GroupBox_ZoningTDWS.TabStop = false;
            this.GroupBox_ZoningTDWS.Text = "ゾーニング";
            // 
            // TextBox_ZoningStatus_TDWS
            // 
            this.TextBox_ZoningStatus_TDWS.Location = new System.Drawing.Point(45, 88);
            this.TextBox_ZoningStatus_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_ZoningStatus_TDWS.Name = "TextBox_ZoningStatus_TDWS";
            this.TextBox_ZoningStatus_TDWS.Size = new System.Drawing.Size(76, 19);
            this.TextBox_ZoningStatus_TDWS.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 92);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "Status";
            // 
            // GroupBox_ZoningCellCmd_TDWS
            // 
            this.GroupBox_ZoningCellCmd_TDWS.Controls.Add(this.RadioButton_Cancel_TDWS);
            this.GroupBox_ZoningCellCmd_TDWS.Controls.Add(this.RadioButton_Permit_TDWS);
            this.GroupBox_ZoningCellCmd_TDWS.Controls.Add(this.RadioButton_Run_TDWS);
            this.GroupBox_ZoningCellCmd_TDWS.Controls.Add(this.RadioButton_None_TDWS);
            this.GroupBox_ZoningCellCmd_TDWS.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBox_ZoningCellCmd_TDWS.Location = new System.Drawing.Point(4, 17);
            this.GroupBox_ZoningCellCmd_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_ZoningCellCmd_TDWS.Name = "GroupBox_ZoningCellCmd_TDWS";
            this.GroupBox_ZoningCellCmd_TDWS.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_ZoningCellCmd_TDWS.Size = new System.Drawing.Size(116, 60);
            this.GroupBox_ZoningCellCmd_TDWS.TabIndex = 17;
            this.GroupBox_ZoningCellCmd_TDWS.TabStop = false;
            this.GroupBox_ZoningCellCmd_TDWS.Text = "CELL 指示";
            // 
            // RadioButton_Cancel_TDWS
            // 
            this.RadioButton_Cancel_TDWS.AutoSize = true;
            this.RadioButton_Cancel_TDWS.Location = new System.Drawing.Point(56, 37);
            this.RadioButton_Cancel_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Cancel_TDWS.Name = "RadioButton_Cancel_TDWS";
            this.RadioButton_Cancel_TDWS.Size = new System.Drawing.Size(58, 16);
            this.RadioButton_Cancel_TDWS.TabIndex = 3;
            this.RadioButton_Cancel_TDWS.TabStop = true;
            this.RadioButton_Cancel_TDWS.Text = "Cancel";
            this.RadioButton_Cancel_TDWS.UseVisualStyleBackColor = true;
            this.RadioButton_Cancel_TDWS.CheckedChanged += new System.EventHandler(this.RadioButton_Cancel_TDWS_CheckedChanged);
            // 
            // RadioButton_Permit_TDWS
            // 
            this.RadioButton_Permit_TDWS.AutoSize = true;
            this.RadioButton_Permit_TDWS.Location = new System.Drawing.Point(56, 17);
            this.RadioButton_Permit_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Permit_TDWS.Name = "RadioButton_Permit_TDWS";
            this.RadioButton_Permit_TDWS.Size = new System.Drawing.Size(56, 16);
            this.RadioButton_Permit_TDWS.TabIndex = 2;
            this.RadioButton_Permit_TDWS.TabStop = true;
            this.RadioButton_Permit_TDWS.Text = "Permit";
            this.RadioButton_Permit_TDWS.UseVisualStyleBackColor = true;
            this.RadioButton_Permit_TDWS.CheckedChanged += new System.EventHandler(this.RadioButton_Permit_TDWS_CheckedChanged);
            // 
            // RadioButton_Run_TDWS
            // 
            this.RadioButton_Run_TDWS.AutoSize = true;
            this.RadioButton_Run_TDWS.Location = new System.Drawing.Point(4, 37);
            this.RadioButton_Run_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Run_TDWS.Name = "RadioButton_Run_TDWS";
            this.RadioButton_Run_TDWS.Size = new System.Drawing.Size(43, 16);
            this.RadioButton_Run_TDWS.TabIndex = 1;
            this.RadioButton_Run_TDWS.TabStop = true;
            this.RadioButton_Run_TDWS.Text = "Run";
            this.RadioButton_Run_TDWS.UseVisualStyleBackColor = true;
            this.RadioButton_Run_TDWS.CheckedChanged += new System.EventHandler(this.RadioButton_Run_TDWS_CheckedChanged);
            // 
            // RadioButton_None_TDWS
            // 
            this.RadioButton_None_TDWS.AutoSize = true;
            this.RadioButton_None_TDWS.Location = new System.Drawing.Point(4, 17);
            this.RadioButton_None_TDWS.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_None_TDWS.Name = "RadioButton_None_TDWS";
            this.RadioButton_None_TDWS.Size = new System.Drawing.Size(49, 16);
            this.RadioButton_None_TDWS.TabIndex = 0;
            this.RadioButton_None_TDWS.TabStop = true;
            this.RadioButton_None_TDWS.Text = "None";
            this.RadioButton_None_TDWS.UseVisualStyleBackColor = true;
            this.RadioButton_None_TDWS.CheckedChanged += new System.EventHandler(this.RadioButton_None_TDWS_CheckedChanged);
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.CheckBox_FBAuto_SmallAisle);
            this.groupBox23.Controls.Add(this.GroupBox_Estop_SmallAisle);
            this.groupBox23.Controls.Add(this.GroupBox_Ctor_SmallAisle);
            this.groupBox23.Controls.Add(this.GroupBox_OpBox_SmallAisle);
            this.groupBox23.Controls.Add(this.CheckBox_AllSmallAisles);
            this.groupBox23.Controls.Add(this.ComboBox_SmallAisle);
            this.groupBox23.Controls.Add(this.GroupBox_Zoning_SmallAisle);
            this.groupBox23.Location = new System.Drawing.Point(1031, 12);
            this.groupBox23.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox23.Size = new System.Drawing.Size(272, 485);
            this.groupBox23.TabIndex = 40;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "SmallAisle";
            // 
            // CheckBox_FBAuto_SmallAisle
            // 
            this.CheckBox_FBAuto_SmallAisle.AutoSize = true;
            this.CheckBox_FBAuto_SmallAisle.Checked = true;
            this.CheckBox_FBAuto_SmallAisle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_FBAuto_SmallAisle.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.CheckBox_FBAuto_SmallAisle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckBox_FBAuto_SmallAisle.Location = new System.Drawing.Point(5, 266);
            this.CheckBox_FBAuto_SmallAisle.Name = "CheckBox_FBAuto_SmallAisle";
            this.CheckBox_FBAuto_SmallAisle.Size = new System.Drawing.Size(43, 24);
            this.CheckBox_FBAuto_SmallAisle.TabIndex = 38;
            this.CheckBox_FBAuto_SmallAisle.Text = "FB\r\nauto";
            this.CheckBox_FBAuto_SmallAisle.UseVisualStyleBackColor = true;
            // 
            // GroupBox_Estop_SmallAisle
            // 
            this.GroupBox_Estop_SmallAisle.Controls.Add(this.CheckBox_ReqCompleteFlag_SmallAisle);
            this.GroupBox_Estop_SmallAisle.Controls.Add(this.Label_StopStatus_SmallAisle);
            this.GroupBox_Estop_SmallAisle.Controls.Add(this.Label_StopRequest_SmallAisle);
            this.GroupBox_Estop_SmallAisle.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBox_Estop_SmallAisle.Location = new System.Drawing.Point(137, 167);
            this.GroupBox_Estop_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Estop_SmallAisle.Name = "GroupBox_Estop_SmallAisle";
            this.GroupBox_Estop_SmallAisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Estop_SmallAisle.Size = new System.Drawing.Size(96, 66);
            this.GroupBox_Estop_SmallAisle.TabIndex = 38;
            this.GroupBox_Estop_SmallAisle.TabStop = false;
            this.GroupBox_Estop_SmallAisle.Text = "非常停止";
            // 
            // CheckBox_ReqCompleteFlag_SmallAisle
            // 
            this.CheckBox_ReqCompleteFlag_SmallAisle.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ReqCompleteFlag_SmallAisle.AutoSize = true;
            this.CheckBox_ReqCompleteFlag_SmallAisle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ReqCompleteFlag_SmallAisle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ReqCompleteFlag_SmallAisle.Location = new System.Drawing.Point(8, 20);
            this.CheckBox_ReqCompleteFlag_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ReqCompleteFlag_SmallAisle.Name = "CheckBox_ReqCompleteFlag_SmallAisle";
            this.CheckBox_ReqCompleteFlag_SmallAisle.Size = new System.Drawing.Size(39, 22);
            this.CheckBox_ReqCompleteFlag_SmallAisle.TabIndex = 10;
            this.CheckBox_ReqCompleteFlag_SmallAisle.Text = "完了";
            this.CheckBox_ReqCompleteFlag_SmallAisle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ReqCompleteFlag_SmallAisle.UseVisualStyleBackColor = true;
            this.CheckBox_ReqCompleteFlag_SmallAisle.CheckedChanged += new System.EventHandler(this.CheckBox_ReqCompleteFlag_SmallAisle_CheckedChanged);
            // 
            // Label_StopStatus_SmallAisle
            // 
            this.Label_StopStatus_SmallAisle.AutoSize = true;
            this.Label_StopStatus_SmallAisle.Location = new System.Drawing.Point(54, 34);
            this.Label_StopStatus_SmallAisle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_StopStatus_SmallAisle.Name = "Label_StopStatus_SmallAisle";
            this.Label_StopStatus_SmallAisle.Size = new System.Drawing.Size(29, 12);
            this.Label_StopStatus_SmallAisle.TabIndex = 20;
            this.Label_StopStatus_SmallAisle.Text = "状態";
            // 
            // Label_StopRequest_SmallAisle
            // 
            this.Label_StopRequest_SmallAisle.AutoSize = true;
            this.Label_StopRequest_SmallAisle.Location = new System.Drawing.Point(54, 14);
            this.Label_StopRequest_SmallAisle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_StopRequest_SmallAisle.Name = "Label_StopRequest_SmallAisle";
            this.Label_StopRequest_SmallAisle.Size = new System.Drawing.Size(29, 12);
            this.Label_StopRequest_SmallAisle.TabIndex = 18;
            this.Label_StopRequest_SmallAisle.Text = "要求";
            // 
            // GroupBox_Ctor_SmallAisle
            // 
            this.GroupBox_Ctor_SmallAisle.Controls.Add(this.CheckBox_ContactorTripped_SmallAisle);
            this.GroupBox_Ctor_SmallAisle.Controls.Add(this.CheckBox_ContactorFdbk_SmallAisle);
            this.GroupBox_Ctor_SmallAisle.Controls.Add(this.Label_ContactorFdbk_SmallAisle);
            this.GroupBox_Ctor_SmallAisle.Controls.Add(this.CheckBox_ContactorOnOff_SmallAisle);
            this.GroupBox_Ctor_SmallAisle.Controls.Add(this.Label_ContactorPlcOut_SmallAisle);
            this.GroupBox_Ctor_SmallAisle.Location = new System.Drawing.Point(4, 162);
            this.GroupBox_Ctor_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_SmallAisle.Name = "GroupBox_Ctor_SmallAisle";
            this.GroupBox_Ctor_SmallAisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Ctor_SmallAisle.Size = new System.Drawing.Size(82, 100);
            this.GroupBox_Ctor_SmallAisle.TabIndex = 16;
            this.GroupBox_Ctor_SmallAisle.TabStop = false;
            this.GroupBox_Ctor_SmallAisle.Text = "コンタクタ";
            // 
            // CheckBox_ContactorTripped_SmallAisle
            // 
            this.CheckBox_ContactorTripped_SmallAisle.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorTripped_SmallAisle.AutoSize = true;
            this.CheckBox_ContactorTripped_SmallAisle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorTripped_SmallAisle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorTripped_SmallAisle.Location = new System.Drawing.Point(4, 70);
            this.CheckBox_ContactorTripped_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorTripped_SmallAisle.Name = "CheckBox_ContactorTripped_SmallAisle";
            this.CheckBox_ContactorTripped_SmallAisle.Size = new System.Drawing.Size(53, 22);
            this.CheckBox_ContactorTripped_SmallAisle.TabIndex = 29;
            this.CheckBox_ContactorTripped_SmallAisle.Text = "Tripped";
            this.CheckBox_ContactorTripped_SmallAisle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorTripped_SmallAisle.UseVisualStyleBackColor = true;
            // 
            // CheckBox_ContactorFdbk_SmallAisle
            // 
            this.CheckBox_ContactorFdbk_SmallAisle.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorFdbk_SmallAisle.AutoSize = true;
            this.CheckBox_ContactorFdbk_SmallAisle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_SmallAisle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorFdbk_SmallAisle.Location = new System.Drawing.Point(4, 43);
            this.CheckBox_ContactorFdbk_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorFdbk_SmallAisle.Name = "CheckBox_ContactorFdbk_SmallAisle";
            this.CheckBox_ContactorFdbk_SmallAisle.Size = new System.Drawing.Size(30, 22);
            this.CheckBox_ContactorFdbk_SmallAisle.TabIndex = 28;
            this.CheckBox_ContactorFdbk_SmallAisle.Text = "FB";
            this.CheckBox_ContactorFdbk_SmallAisle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorFdbk_SmallAisle.UseVisualStyleBackColor = true;
            this.CheckBox_ContactorFdbk_SmallAisle.CheckedChanged += new System.EventHandler(this.CheckBox_ContactorFdbk_SmallAisle_CheckedChanged);
            // 
            // Label_ContactorFdbk_SmallAisle
            // 
            this.Label_ContactorFdbk_SmallAisle.AutoSize = true;
            this.Label_ContactorFdbk_SmallAisle.Location = new System.Drawing.Point(43, 48);
            this.Label_ContactorFdbk_SmallAisle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorFdbk_SmallAisle.Name = "Label_ContactorFdbk_SmallAisle";
            this.Label_ContactorFdbk_SmallAisle.Size = new System.Drawing.Size(20, 12);
            this.Label_ContactorFdbk_SmallAisle.TabIndex = 13;
            this.Label_ContactorFdbk_SmallAisle.Text = "FB";
            // 
            // CheckBox_ContactorOnOff_SmallAisle
            // 
            this.CheckBox_ContactorOnOff_SmallAisle.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_ContactorOnOff_SmallAisle.AutoSize = true;
            this.CheckBox_ContactorOnOff_SmallAisle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorOnOff_SmallAisle.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.CheckBox_ContactorOnOff_SmallAisle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_ContactorOnOff_SmallAisle.Location = new System.Drawing.Point(4, 17);
            this.CheckBox_ContactorOnOff_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_ContactorOnOff_SmallAisle.Name = "CheckBox_ContactorOnOff_SmallAisle";
            this.CheckBox_ContactorOnOff_SmallAisle.Size = new System.Drawing.Size(31, 22);
            this.CheckBox_ContactorOnOff_SmallAisle.TabIndex = 10;
            this.CheckBox_ContactorOnOff_SmallAisle.Text = "ON";
            this.CheckBox_ContactorOnOff_SmallAisle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_ContactorOnOff_SmallAisle.UseVisualStyleBackColor = true;
            this.CheckBox_ContactorOnOff_SmallAisle.CheckedChanged += new System.EventHandler(this.CheckBox_ContactorOnOff_SmallAisle_CheckedChanged);
            // 
            // Label_ContactorPlcOut_SmallAisle
            // 
            this.Label_ContactorPlcOut_SmallAisle.AutoSize = true;
            this.Label_ContactorPlcOut_SmallAisle.Location = new System.Drawing.Point(43, 22);
            this.Label_ContactorPlcOut_SmallAisle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_ContactorPlcOut_SmallAisle.Name = "Label_ContactorPlcOut_SmallAisle";
            this.Label_ContactorPlcOut_SmallAisle.Size = new System.Drawing.Size(23, 12);
            this.Label_ContactorPlcOut_SmallAisle.TabIndex = 10;
            this.Label_ContactorPlcOut_SmallAisle.Text = "---";
            // 
            // GroupBox_OpBox_SmallAisle
            // 
            this.GroupBox_OpBox_SmallAisle.Controls.Add(this.GroupBox_KeySwitch_SmallAisle);
            this.GroupBox_OpBox_SmallAisle.Controls.Add(this.Label_OpBoxLed_SmallAisle);
            this.GroupBox_OpBox_SmallAisle.Controls.Add(this.CheckBox_EstopBtn_SmallAisle);
            this.GroupBox_OpBox_SmallAisle.Controls.Add(this.Btn_Reset_SmallAisle);
            this.GroupBox_OpBox_SmallAisle.Controls.Add(this.Btn_Run_SmallAisle);
            this.GroupBox_OpBox_SmallAisle.Location = new System.Drawing.Point(4, 41);
            this.GroupBox_OpBox_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_OpBox_SmallAisle.Name = "GroupBox_OpBox_SmallAisle";
            this.GroupBox_OpBox_SmallAisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_OpBox_SmallAisle.Size = new System.Drawing.Size(129, 117);
            this.GroupBox_OpBox_SmallAisle.TabIndex = 35;
            this.GroupBox_OpBox_SmallAisle.TabStop = false;
            this.GroupBox_OpBox_SmallAisle.Text = "OpBox";
            // 
            // GroupBox_KeySwitch_SmallAisle
            // 
            this.GroupBox_KeySwitch_SmallAisle.Controls.Add(this.RadioButton_Ready_SmallAisle);
            this.GroupBox_KeySwitch_SmallAisle.Controls.Add(this.RadioButton_Req_SmallAisle);
            this.GroupBox_KeySwitch_SmallAisle.Location = new System.Drawing.Point(57, 15);
            this.GroupBox_KeySwitch_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_KeySwitch_SmallAisle.Name = "GroupBox_KeySwitch_SmallAisle";
            this.GroupBox_KeySwitch_SmallAisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_KeySwitch_SmallAisle.Size = new System.Drawing.Size(64, 62);
            this.GroupBox_KeySwitch_SmallAisle.TabIndex = 29;
            this.GroupBox_KeySwitch_SmallAisle.TabStop = false;
            this.GroupBox_KeySwitch_SmallAisle.Text = "KeySw";
            // 
            // RadioButton_Ready_SmallAisle
            // 
            this.RadioButton_Ready_SmallAisle.AutoSize = true;
            this.RadioButton_Ready_SmallAisle.Location = new System.Drawing.Point(5, 37);
            this.RadioButton_Ready_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Ready_SmallAisle.Name = "RadioButton_Ready_SmallAisle";
            this.RadioButton_Ready_SmallAisle.Size = new System.Drawing.Size(55, 16);
            this.RadioButton_Ready_SmallAisle.TabIndex = 5;
            this.RadioButton_Ready_SmallAisle.TabStop = true;
            this.RadioButton_Ready_SmallAisle.Text = "Ready";
            this.RadioButton_Ready_SmallAisle.UseVisualStyleBackColor = true;
            this.RadioButton_Ready_SmallAisle.CheckedChanged += new System.EventHandler(this.RadioButton_Ready_SmallAisle_CheckedChanged);
            // 
            // RadioButton_Req_SmallAisle
            // 
            this.RadioButton_Req_SmallAisle.AutoSize = true;
            this.RadioButton_Req_SmallAisle.Location = new System.Drawing.Point(5, 17);
            this.RadioButton_Req_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Req_SmallAisle.Name = "RadioButton_Req_SmallAisle";
            this.RadioButton_Req_SmallAisle.Size = new System.Drawing.Size(43, 16);
            this.RadioButton_Req_SmallAisle.TabIndex = 4;
            this.RadioButton_Req_SmallAisle.TabStop = true;
            this.RadioButton_Req_SmallAisle.Text = "Req";
            this.RadioButton_Req_SmallAisle.UseVisualStyleBackColor = true;
            this.RadioButton_Req_SmallAisle.CheckedChanged += new System.EventHandler(this.RadioButton_Req_SmallAisle_CheckedChanged);
            // 
            // Label_OpBoxLed_SmallAisle
            // 
            this.Label_OpBoxLed_SmallAisle.AutoSize = true;
            this.Label_OpBoxLed_SmallAisle.Location = new System.Drawing.Point(4, 93);
            this.Label_OpBoxLed_SmallAisle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_OpBoxLed_SmallAisle.Name = "Label_OpBoxLed_SmallAisle";
            this.Label_OpBoxLed_SmallAisle.Size = new System.Drawing.Size(23, 12);
            this.Label_OpBoxLed_SmallAisle.TabIndex = 5;
            this.Label_OpBoxLed_SmallAisle.Text = "---";
            // 
            // CheckBox_EstopBtn_SmallAisle
            // 
            this.CheckBox_EstopBtn_SmallAisle.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_EstopBtn_SmallAisle.AutoSize = true;
            this.CheckBox_EstopBtn_SmallAisle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_EstopBtn_SmallAisle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_EstopBtn_SmallAisle.Location = new System.Drawing.Point(4, 17);
            this.CheckBox_EstopBtn_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_EstopBtn_SmallAisle.Name = "CheckBox_EstopBtn_SmallAisle";
            this.CheckBox_EstopBtn_SmallAisle.Size = new System.Drawing.Size(44, 22);
            this.CheckBox_EstopBtn_SmallAisle.TabIndex = 5;
            this.CheckBox_EstopBtn_SmallAisle.Text = "Estop";
            this.CheckBox_EstopBtn_SmallAisle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_EstopBtn_SmallAisle.UseVisualStyleBackColor = true;
            this.CheckBox_EstopBtn_SmallAisle.CheckedChanged += new System.EventHandler(this.CheckBox_EstopBtn_SmallAisle_CheckedChanged);
            // 
            // Btn_Reset_SmallAisle
            // 
            this.Btn_Reset_SmallAisle.Location = new System.Drawing.Point(4, 42);
            this.Btn_Reset_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Reset_SmallAisle.Name = "Btn_Reset_SmallAisle";
            this.Btn_Reset_SmallAisle.Size = new System.Drawing.Size(44, 22);
            this.Btn_Reset_SmallAisle.TabIndex = 3;
            this.Btn_Reset_SmallAisle.Text = "Reset";
            this.Btn_Reset_SmallAisle.UseVisualStyleBackColor = true;
            this.Btn_Reset_SmallAisle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_SmallAisle_MouseDown);
            this.Btn_Reset_SmallAisle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Reset_SmallAisle_MouseUp);
            // 
            // Btn_Run_SmallAisle
            // 
            this.Btn_Run_SmallAisle.Location = new System.Drawing.Point(4, 67);
            this.Btn_Run_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Run_SmallAisle.Name = "Btn_Run_SmallAisle";
            this.Btn_Run_SmallAisle.Size = new System.Drawing.Size(44, 22);
            this.Btn_Run_SmallAisle.TabIndex = 6;
            this.Btn_Run_SmallAisle.Text = "起動";
            this.Btn_Run_SmallAisle.UseVisualStyleBackColor = true;
            this.Btn_Run_SmallAisle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Run_SmallAisle_MouseDown);
            this.Btn_Run_SmallAisle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Run_SmallAisle_MouseUp);
            // 
            // CheckBox_AllSmallAisles
            // 
            this.CheckBox_AllSmallAisles.AutoSize = true;
            this.CheckBox_AllSmallAisles.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBox_AllSmallAisles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckBox_AllSmallAisles.Location = new System.Drawing.Point(131, 17);
            this.CheckBox_AllSmallAisles.Name = "CheckBox_AllSmallAisles";
            this.CheckBox_AllSmallAisles.Size = new System.Drawing.Size(81, 16);
            this.CheckBox_AllSmallAisles.TabIndex = 39;
            this.CheckBox_AllSmallAisles.Text = "All TDWS";
            this.CheckBox_AllSmallAisles.UseVisualStyleBackColor = true;
            this.CheckBox_AllSmallAisles.CheckedChanged += new System.EventHandler(this.CheckBox_AllSmallAisles_CheckedChanged);
            // 
            // ComboBox_SmallAisle
            // 
            this.ComboBox_SmallAisle.FormattingEnabled = true;
            this.ComboBox_SmallAisle.Location = new System.Drawing.Point(4, 17);
            this.ComboBox_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBox_SmallAisle.Name = "ComboBox_SmallAisle";
            this.ComboBox_SmallAisle.Size = new System.Drawing.Size(117, 20);
            this.ComboBox_SmallAisle.TabIndex = 0;
            this.ComboBox_SmallAisle.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SmallAisle_SelectedIndexChanged);
            // 
            // GroupBox_Zoning_SmallAisle
            // 
            this.GroupBox_Zoning_SmallAisle.Controls.Add(this.TextBox_ZoningStatus_SmallAisle);
            this.GroupBox_Zoning_SmallAisle.Controls.Add(this.label12);
            this.GroupBox_Zoning_SmallAisle.Controls.Add(this.GroupBox_ZoningCellCmd_SmallAisle);
            this.GroupBox_Zoning_SmallAisle.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBox_Zoning_SmallAisle.Location = new System.Drawing.Point(137, 41);
            this.GroupBox_Zoning_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_Zoning_SmallAisle.Name = "GroupBox_Zoning_SmallAisle";
            this.GroupBox_Zoning_SmallAisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_Zoning_SmallAisle.Size = new System.Drawing.Size(125, 122);
            this.GroupBox_Zoning_SmallAisle.TabIndex = 37;
            this.GroupBox_Zoning_SmallAisle.TabStop = false;
            this.GroupBox_Zoning_SmallAisle.Text = "ゾーニング";
            // 
            // TextBox_ZoningStatus_SmallAisle
            // 
            this.TextBox_ZoningStatus_SmallAisle.Location = new System.Drawing.Point(45, 88);
            this.TextBox_ZoningStatus_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_ZoningStatus_SmallAisle.Name = "TextBox_ZoningStatus_SmallAisle";
            this.TextBox_ZoningStatus_SmallAisle.Size = new System.Drawing.Size(76, 19);
            this.TextBox_ZoningStatus_SmallAisle.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 92);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "Status";
            // 
            // GroupBox_ZoningCellCmd_SmallAisle
            // 
            this.GroupBox_ZoningCellCmd_SmallAisle.Controls.Add(this.RadioButton_Cancel_SmallAisle);
            this.GroupBox_ZoningCellCmd_SmallAisle.Controls.Add(this.RadioButton_Permit_SmallAisle);
            this.GroupBox_ZoningCellCmd_SmallAisle.Controls.Add(this.RadioButton_Run_SmallAisle);
            this.GroupBox_ZoningCellCmd_SmallAisle.Controls.Add(this.RadioButton_None_SmallAisle);
            this.GroupBox_ZoningCellCmd_SmallAisle.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBox_ZoningCellCmd_SmallAisle.Location = new System.Drawing.Point(4, 17);
            this.GroupBox_ZoningCellCmd_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_ZoningCellCmd_SmallAisle.Name = "GroupBox_ZoningCellCmd_SmallAisle";
            this.GroupBox_ZoningCellCmd_SmallAisle.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_ZoningCellCmd_SmallAisle.Size = new System.Drawing.Size(116, 60);
            this.GroupBox_ZoningCellCmd_SmallAisle.TabIndex = 17;
            this.GroupBox_ZoningCellCmd_SmallAisle.TabStop = false;
            this.GroupBox_ZoningCellCmd_SmallAisle.Text = "CELL 指示";
            // 
            // RadioButton_Cancel_SmallAisle
            // 
            this.RadioButton_Cancel_SmallAisle.AutoSize = true;
            this.RadioButton_Cancel_SmallAisle.Location = new System.Drawing.Point(56, 37);
            this.RadioButton_Cancel_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Cancel_SmallAisle.Name = "RadioButton_Cancel_SmallAisle";
            this.RadioButton_Cancel_SmallAisle.Size = new System.Drawing.Size(58, 16);
            this.RadioButton_Cancel_SmallAisle.TabIndex = 3;
            this.RadioButton_Cancel_SmallAisle.TabStop = true;
            this.RadioButton_Cancel_SmallAisle.Text = "Cancel";
            this.RadioButton_Cancel_SmallAisle.UseVisualStyleBackColor = true;
            this.RadioButton_Cancel_SmallAisle.CheckedChanged += new System.EventHandler(this.RadioButton_Cancel_SmallAisle_CheckedChanged);
            // 
            // RadioButton_Permit_SmallAisle
            // 
            this.RadioButton_Permit_SmallAisle.AutoSize = true;
            this.RadioButton_Permit_SmallAisle.Location = new System.Drawing.Point(56, 17);
            this.RadioButton_Permit_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Permit_SmallAisle.Name = "RadioButton_Permit_SmallAisle";
            this.RadioButton_Permit_SmallAisle.Size = new System.Drawing.Size(56, 16);
            this.RadioButton_Permit_SmallAisle.TabIndex = 2;
            this.RadioButton_Permit_SmallAisle.TabStop = true;
            this.RadioButton_Permit_SmallAisle.Text = "Permit";
            this.RadioButton_Permit_SmallAisle.UseVisualStyleBackColor = true;
            this.RadioButton_Permit_SmallAisle.CheckedChanged += new System.EventHandler(this.RadioButton_Permit_SmallAisle_CheckedChanged);
            // 
            // RadioButton_Run_SmallAisle
            // 
            this.RadioButton_Run_SmallAisle.AutoSize = true;
            this.RadioButton_Run_SmallAisle.Location = new System.Drawing.Point(4, 37);
            this.RadioButton_Run_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_Run_SmallAisle.Name = "RadioButton_Run_SmallAisle";
            this.RadioButton_Run_SmallAisle.Size = new System.Drawing.Size(43, 16);
            this.RadioButton_Run_SmallAisle.TabIndex = 1;
            this.RadioButton_Run_SmallAisle.TabStop = true;
            this.RadioButton_Run_SmallAisle.Text = "Run";
            this.RadioButton_Run_SmallAisle.UseVisualStyleBackColor = true;
            this.RadioButton_Run_SmallAisle.CheckedChanged += new System.EventHandler(this.RadioButton_Run_SmallAisle_CheckedChanged);
            // 
            // RadioButton_None_SmallAisle
            // 
            this.RadioButton_None_SmallAisle.AutoSize = true;
            this.RadioButton_None_SmallAisle.Location = new System.Drawing.Point(4, 17);
            this.RadioButton_None_SmallAisle.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_None_SmallAisle.Name = "RadioButton_None_SmallAisle";
            this.RadioButton_None_SmallAisle.Size = new System.Drawing.Size(49, 16);
            this.RadioButton_None_SmallAisle.TabIndex = 0;
            this.RadioButton_None_SmallAisle.TabStop = true;
            this.RadioButton_None_SmallAisle.Text = "None";
            this.RadioButton_None_SmallAisle.UseVisualStyleBackColor = true;
            this.RadioButton_None_SmallAisle.CheckedChanged += new System.EventHandler(this.RadioButton_None_SmallAisle_CheckedChanged);
            // 
            // GroupBox_BOT
            // 
            this.GroupBox_BOT.Controls.Add(this.ComboBox_Bots);
            this.GroupBox_BOT.Controls.Add(this.Label_IsEstop_Bot);
            this.GroupBox_BOT.Controls.Add(this.Label_IsFault_Bot);
            this.GroupBox_BOT.Controls.Add(this.checkBox5);
            this.GroupBox_BOT.Controls.Add(this.CheckBox_Estop_BOT);
            this.GroupBox_BOT.Location = new System.Drawing.Point(726, 477);
            this.GroupBox_BOT.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox_BOT.Name = "GroupBox_BOT";
            this.GroupBox_BOT.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox_BOT.Size = new System.Drawing.Size(272, 102);
            this.GroupBox_BOT.TabIndex = 38;
            this.GroupBox_BOT.TabStop = false;
            this.GroupBox_BOT.Text = "BOT";
            // 
            // ComboBox_Bots
            // 
            this.ComboBox_Bots.FormattingEnabled = true;
            this.ComboBox_Bots.Location = new System.Drawing.Point(4, 17);
            this.ComboBox_Bots.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBox_Bots.Name = "ComboBox_Bots";
            this.ComboBox_Bots.Size = new System.Drawing.Size(77, 20);
            this.ComboBox_Bots.TabIndex = 22;
            // 
            // Label_IsEstop_Bot
            // 
            this.Label_IsEstop_Bot.AutoSize = true;
            this.Label_IsEstop_Bot.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Label_IsEstop_Bot.Location = new System.Drawing.Point(76, 76);
            this.Label_IsEstop_Bot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_IsEstop_Bot.Name = "Label_IsEstop_Bot";
            this.Label_IsEstop_Bot.Size = new System.Drawing.Size(77, 12);
            this.Label_IsEstop_Bot.TabIndex = 12;
            this.Label_IsEstop_Bot.Text = "非常停止状態";
            // 
            // Label_IsFault_Bot
            // 
            this.Label_IsFault_Bot.AutoSize = true;
            this.Label_IsFault_Bot.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Label_IsFault_Bot.Location = new System.Drawing.Point(76, 51);
            this.Label_IsFault_Bot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_IsFault_Bot.Name = "Label_IsFault_Bot";
            this.Label_IsFault_Bot.Size = new System.Drawing.Size(53, 12);
            this.Label_IsFault_Bot.TabIndex = 10;
            this.Label_IsFault_Bot.Text = "安全確認";
            // 
            // checkBox5
            // 
            this.checkBox5.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox5.AutoSize = true;
            this.checkBox5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox5.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.checkBox5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox5.Location = new System.Drawing.Point(4, 72);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(39, 22);
            this.checkBox5.TabIndex = 11;
            this.checkBox5.Text = "解除";
            this.checkBox5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // CheckBox_Estop_BOT
            // 
            this.CheckBox_Estop_BOT.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_Estop_BOT.AutoSize = true;
            this.CheckBox_Estop_BOT.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_Estop_BOT.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.CheckBox_Estop_BOT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_Estop_BOT.Location = new System.Drawing.Point(4, 47);
            this.CheckBox_Estop_BOT.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_Estop_BOT.Name = "CheckBox_Estop_BOT";
            this.CheckBox_Estop_BOT.Size = new System.Drawing.Size(63, 22);
            this.CheckBox_Estop_BOT.TabIndex = 10;
            this.CheckBox_Estop_BOT.Text = "非常停止";
            this.CheckBox_Estop_BOT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_Estop_BOT.UseVisualStyleBackColor = true;
            // 
            // CheckBox_FireAlarm
            // 
            this.CheckBox_FireAlarm.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_FireAlarm.AutoSize = true;
            this.CheckBox_FireAlarm.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_FireAlarm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBox_FireAlarm.Location = new System.Drawing.Point(9, 498);
            this.CheckBox_FireAlarm.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_FireAlarm.Name = "CheckBox_FireAlarm";
            this.CheckBox_FireAlarm.Size = new System.Drawing.Size(69, 22);
            this.CheckBox_FireAlarm.TabIndex = 31;
            this.CheckBox_FireAlarm.Text = "Fire Alarm";
            this.CheckBox_FireAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_FireAlarm.UseVisualStyleBackColor = true;
            this.CheckBox_FireAlarm.CheckedChanged += new System.EventHandler(this.CheckBox_FireAlarm_CheckedChanged);
            // 
            // CoSimInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1373, 682);
            this.Controls.Add(this.Btn_BuzzerAck);
            this.Controls.Add(this.CheckBox_FireAlarm);
            this.Controls.Add(this.GroupBox_BOT);
            this.Controls.Add(this.groupBox23);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListBox_Log);
            this.Controls.Add(this.GroupBox_Panels);
            this.Controls.Add(this.GroupBox_MaintArea);
            this.Controls.Add(this.groupBox16);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxCELL);
            this.Controls.Add(this.GroupBox_Stopper);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CoSimInterface";
            this.Text = "AlphaBot PLC SIM - IO";
            this.GroupBox_SafetyBoard_TDWS.ResumeLayout(false);
            this.GroupBox_SafetyBoard_TDWS.PerformLayout();
            this.groupBoxCELL.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GroupBox_Door_Aisle.ResumeLayout(false);
            this.GroupBox_Door_Aisle.PerformLayout();
            this.GroupBox_DoorSensor_Aisle.ResumeLayout(false);
            this.GroupBox_DoorSensor_Aisle.PerformLayout();
            this.GroupBox_Estop_Aisle.ResumeLayout(false);
            this.GroupBox_Estop_Aisle.PerformLayout();
            this.GroupBox_SafetyBoard_Aisle.ResumeLayout(false);
            this.GroupBox_SafetyBoard_Aisle.PerformLayout();
            this.GroupBox_Zoning_Aisle.ResumeLayout(false);
            this.GroupBox_Zoning_Aisle.PerformLayout();
            this.groupBox_ZoningCellCmd_Aisle.ResumeLayout(false);
            this.groupBox_ZoningCellCmd_Aisle.PerformLayout();
            this.GroupBox_Contactors_Aisle.ResumeLayout(false);
            this.GroupBox_Contactors_Aisle.PerformLayout();
            this.GroupBox_Ctor_AisleSouth.ResumeLayout(false);
            this.GroupBox_Ctor_AisleSouth.PerformLayout();
            this.GroupBox_Ctor_AisleNorth.ResumeLayout(false);
            this.GroupBox_Ctor_AisleNorth.PerformLayout();
            this.GroupBox_OpBox_Aisle.ResumeLayout(false);
            this.GroupBox_OpBox_Aisle.PerformLayout();
            this.GroupBox_KeySwitch_Aisle.ResumeLayout(false);
            this.GroupBox_KeySwitch_Aisle.PerformLayout();
            this.GroupBox_Stopper.ResumeLayout(false);
            this.GroupBox_Stopper.PerformLayout();
            this.GroupBox_Q_Stopper.ResumeLayout(false);
            this.GroupBox_Q_Stopper.PerformLayout();
            this.GroupBox_Sensor_Stopper.ResumeLayout(false);
            this.GroupBox_Sensor_Stopper.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.GroupBox_Door_Deck.ResumeLayout(false);
            this.GroupBox_Door_Deck.PerformLayout();
            this.GroupBox_DoorSensor_Deck.ResumeLayout(false);
            this.GroupBox_DoorSensor_Deck.PerformLayout();
            this.GroupBox_OpBox_Deck.ResumeLayout(false);
            this.GroupBox_OpBox_Deck.PerformLayout();
            this.GroupBox_KeySwitch_Deck.ResumeLayout(false);
            this.GroupBox_KeySwitch_Deck.PerformLayout();
            this.GroupBox_Estop_Deck.ResumeLayout(false);
            this.GroupBox_Estop_Deck.PerformLayout();
            this.groupBox_Zoning_Deck.ResumeLayout(false);
            this.groupBox_Zoning_Deck.PerformLayout();
            this.groupBox_ZoningCellCmd_Deck.ResumeLayout(false);
            this.groupBox_ZoningCellCmd_Deck.PerformLayout();
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox36.ResumeLayout(false);
            this.groupBox36.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.GroupBox_MaintArea.ResumeLayout(false);
            this.GroupBox_MaintArea.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.GroupBox_.ResumeLayout(false);
            this.GroupBox_.PerformLayout();
            this.GroupBox_Ctor_MaintArea.ResumeLayout(false);
            this.GroupBox_Ctor_MaintArea.PerformLayout();
            this.GroupBox_Panels.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.GroupBox_Door_TDWS.ResumeLayout(false);
            this.GroupBox_Door_TDWS.PerformLayout();
            this.GroupBox_DoorSensor_TDWS.ResumeLayout(false);
            this.GroupBox_DoorSensor_TDWS.PerformLayout();
            this.GroupBox_Estop_TDWS.ResumeLayout(false);
            this.GroupBox_Estop_TDWS.PerformLayout();
            this.GroupBox_OpBox_TDWS.ResumeLayout(false);
            this.GroupBox_OpBox_TDWS.PerformLayout();
            this.GroupBox_KeySwitch_TDWS.ResumeLayout(false);
            this.GroupBox_KeySwitch_TDWS.PerformLayout();
            this.GroupBox_Contactors_TDWS.ResumeLayout(false);
            this.GroupBox_Contactors_TDWS.PerformLayout();
            this.GroupBox_Ctor_TDWStower.ResumeLayout(false);
            this.GroupBox_Ctor_TDWStower.PerformLayout();
            this.GroupBox_Ctor_TDWSpick.ResumeLayout(false);
            this.GroupBox_Ctor_TDWSpick.PerformLayout();
            this.GroupBox_ZoningTDWS.ResumeLayout(false);
            this.GroupBox_ZoningTDWS.PerformLayout();
            this.GroupBox_ZoningCellCmd_TDWS.ResumeLayout(false);
            this.GroupBox_ZoningCellCmd_TDWS.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.GroupBox_Estop_SmallAisle.ResumeLayout(false);
            this.GroupBox_Estop_SmallAisle.PerformLayout();
            this.GroupBox_Ctor_SmallAisle.ResumeLayout(false);
            this.GroupBox_Ctor_SmallAisle.PerformLayout();
            this.GroupBox_OpBox_SmallAisle.ResumeLayout(false);
            this.GroupBox_OpBox_SmallAisle.PerformLayout();
            this.GroupBox_KeySwitch_SmallAisle.ResumeLayout(false);
            this.GroupBox_KeySwitch_SmallAisle.PerformLayout();
            this.GroupBox_Zoning_SmallAisle.ResumeLayout(false);
            this.GroupBox_Zoning_SmallAisle.PerformLayout();
            this.GroupBox_ZoningCellCmd_SmallAisle.ResumeLayout(false);
            this.GroupBox_ZoningCellCmd_SmallAisle.PerformLayout();
            this.GroupBox_BOT.ResumeLayout(false);
            this.GroupBox_BOT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCELL;
        private System.Windows.Forms.CheckBox CheckBox_IsCellConnectedPulse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_ResetFromCell;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RadioButton_SystemIsStartingUp;
        private System.Windows.Forms.RadioButton RadioButton_CanSystemStartUp;
        private System.Windows.Forms.Label Label_CELLcomm_PlcStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox GroupBox_Contactors_Aisle;
        private System.Windows.Forms.Label Label_ContactorFdbk_AisleNorth;
        private System.Windows.Forms.Label Label_ContactorPlcOut_AisleNorth;
        private System.Windows.Forms.CheckBox CheckBox_ContactorOnOff_AisleNorth;
        private System.Windows.Forms.ComboBox ComboBox_Aisles;
        private System.Windows.Forms.GroupBox GroupBox_OpBox_Aisle;
        private System.Windows.Forms.Label Label_OpBoxLed_Aisle;
        private System.Windows.Forms.CheckBox CheckBox_EstopBtn_Aisle;
        private System.Windows.Forms.Button Btn_Reset_Aisle;
        private System.Windows.Forms.Button Btn_Run_Aisle;
        private System.Windows.Forms.GroupBox GroupBox_Stopper;
        private System.Windows.Forms.Label Label_TimeOverSignalToCell_Stopper;
        private System.Windows.Forms.Label Label_ErrorSignalToCell_Stopper;
        private System.Windows.Forms.Label Label_IsClosedStatusToCell_Stopper;
        private System.Windows.Forms.Label Label_IsOpenStatusToCell_Stopper;
        private System.Windows.Forms.CheckBox CheckBox_CloseCommandFromCell_Stopper;
        private System.Windows.Forms.CheckBox CheckBox_OpenCommandFromCell_Stopper;
        private System.Windows.Forms.Label Label_PlcCloseOut_Stopper;
        private System.Windows.Forms.Label Label_PlcOpenOut_Stopper;
        private System.Windows.Forms.Label Label_IsClosedSensor_Stopper;
        private System.Windows.Forms.Label Label_IsOpenSensor_Stopper;
        private System.Windows.Forms.GroupBox GroupBox_Q_Stopper;
        private System.Windows.Forms.GroupBox GroupBox_Sensor_Stopper;
        private System.Windows.Forms.GroupBox GroupBox_SafetyBoard_Aisle;
        private System.Windows.Forms.Label Label_Safety_AisleSouth;
        private System.Windows.Forms.CheckBox CheckBox_SafetyBoard_AisleNorth;
        private System.Windows.Forms.CheckBox CheckBox_SafetyBoard_AisleSouth;
        private System.Windows.Forms.Label Label_SafetyBoard_AisleNorth;
        private System.Windows.Forms.GroupBox GroupBox_Ctor_AisleNorth;
        private System.Windows.Forms.GroupBox GroupBox_Estop_Aisle;
        private System.Windows.Forms.Label Label_StopStatus_Aisle;
        private System.Windows.Forms.Label Label_StopRequest_Aisle;
        private System.Windows.Forms.CheckBox CheckBox_ReqCompleteFlag_Aisle;
        private System.Windows.Forms.GroupBox GroupBox_Zoning_Aisle;
        private System.Windows.Forms.TextBox TextBox_ZoningStatus_Aisle;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox_ZoningCellCmd_Aisle;
        private System.Windows.Forms.RadioButton RadioButton_Cancel_Aisle;
        private System.Windows.Forms.RadioButton RadioButton_Permit_Aisle;
        private System.Windows.Forms.RadioButton RadioButton_Run_Aisle;
        private System.Windows.Forms.RadioButton RadioButton_None_Aisle;
        private System.Windows.Forms.ComboBox ComboBox_Stoppers;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.ComboBox ComboBox_Decks;
        private System.Windows.Forms.GroupBox groupBox_Zoning_Deck;
        private System.Windows.Forms.TextBox TextBox_ZoningStatus_Deck;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox_ZoningCellCmd_Deck;
        private System.Windows.Forms.RadioButton RadioButton_Cancel_Deck;
        private System.Windows.Forms.RadioButton RadioButton_Permit_Deck;
        private System.Windows.Forms.RadioButton RadioButton_Run_Deck;
        private System.Windows.Forms.RadioButton RadioButton_None_Deck;
        private System.Windows.Forms.GroupBox groupBox35;
        private System.Windows.Forms.CheckBox CheckBox_EstopBtn_DwsPanel;
        private System.Windows.Forms.Button Btn_Reset_DwsPanel;
        private System.Windows.Forms.Label Label_LedTowerRed_DwsPanel;
        private System.Windows.Forms.GroupBox groupBox36;
        private System.Windows.Forms.Label Label_LedTower_NorthPanel;
        private System.Windows.Forms.GroupBox groupBox37;
        private System.Windows.Forms.Label Label_LedTower_SouthPanel;
        private System.Windows.Forms.GroupBox GroupBox_MaintArea;
        private System.Windows.Forms.GroupBox GroupBox_Door_Aisle;
        private System.Windows.Forms.RadioButton RadioButton_DoorClosed_Aisle;
        private System.Windows.Forms.RadioButton RadioButton_DoorOpen_Aisle;
        private System.Windows.Forms.GroupBox GroupBox_Panels;
        private System.Windows.Forms.GroupBox GroupBox_DoorSensor_Aisle;
        private System.Windows.Forms.ListBox ListBox_Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBox_IsClosedSensor_Stopper;
        private System.Windows.Forms.CheckBox CheckBox_IsOpenSensor_Stopper;
        private System.Windows.Forms.CheckBox CheckBox_ContactorFdbk_AisleNorth;
        private System.Windows.Forms.CheckBox CheckBox_Alarm_Stopper;
        private System.Windows.Forms.Label Label_LedTowerGreen_DwsPanel;
        private System.Windows.Forms.Label Label_LedTowerYellow_DwsPanel;
        private System.Windows.Forms.Label Label_LedTowerBlue_DwsPanel;
        private System.Windows.Forms.Label Label_LedTowerWhite_DwsPanel;
        private System.Windows.Forms.GroupBox GroupBox_KeySwitch_Aisle;
        private System.Windows.Forms.RadioButton RadioButton_Ready_Aisle;
        private System.Windows.Forms.RadioButton RadioButton_Req_Aisle;
        private System.Windows.Forms.CheckBox CheckBox_AllAisles;
        private System.Windows.Forms.CheckBox CheckBox_AllDecks;
        private System.Windows.Forms.CheckBox CheckBox_AutoStopper;
        private System.Windows.Forms.CheckBox CheckBox_BOT_HP;
        private System.Windows.Forms.Label Label_BotHPtoCell;
        private System.Windows.Forms.CheckBox CheckBox_FBAuto_Aisle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox CheckBox_AllTDWSs;
        private System.Windows.Forms.ComboBox ComboBox_TowerDWS;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.CheckBox CheckBox_AllSmallAisles;
        private System.Windows.Forms.ComboBox ComboBox_SmallAisle;
        private System.Windows.Forms.RadioButton RadioButton_MaintArea_MaintMode;
        private System.Windows.Forms.Label Label_UnlockDoor_Aisle;
        private System.Windows.Forms.Label Label_DoorIsLocked_Aisle;
        private System.Windows.Forms.CheckBox CheckBox_ContactorTripped_AisleNorth;
        private System.Windows.Forms.GroupBox GroupBox_Ctor_AisleSouth;
        private System.Windows.Forms.CheckBox CheckBox_ContactorTripped_AisleSouth;
        private System.Windows.Forms.CheckBox CheckBox_ContactorFdbk_AisleSouth;
        private System.Windows.Forms.Label Label_ContactorFdbk_AisleSouth;
        private System.Windows.Forms.CheckBox CheckBox_ContactorOnOff_AisleSouth;
        private System.Windows.Forms.Label Label_ContactorPlcOut_AisleSouth;
        private System.Windows.Forms.GroupBox GroupBox_OpBox_Deck;
        private System.Windows.Forms.GroupBox GroupBox_KeySwitch_Deck;
        private System.Windows.Forms.RadioButton RadioButton_Ready_Deck;
        private System.Windows.Forms.RadioButton RadioButton_Req_Deck;
        private System.Windows.Forms.Label Label_OpBoxLed_Deck;
        private System.Windows.Forms.CheckBox CheckBox_EstopBtn_Deck;
        private System.Windows.Forms.Button Btn_Reset_Deck;
        private System.Windows.Forms.Button Btn_Run_Deck;
        private System.Windows.Forms.GroupBox GroupBox_Door_Deck;
        private System.Windows.Forms.Label Label_UnlockDoor_Deck;
        private System.Windows.Forms.Label Label_DoorIsLocked_Deck;
        private System.Windows.Forms.GroupBox GroupBox_DoorSensor_Deck;
        private System.Windows.Forms.RadioButton RadioButton_DoorClosed_Deck;
        private System.Windows.Forms.RadioButton RadioButton_DoorOpen_Deck;
        private System.Windows.Forms.GroupBox GroupBox_Estop_Deck;
        private System.Windows.Forms.CheckBox CheckBox_ReqCompleteFlag_Deck;
        private System.Windows.Forms.Label Label_StopStatus_Deck;
        private System.Windows.Forms.Label Label_StopRequest_Deck;
        private System.Windows.Forms.Label Label_ContactorLamp_Aisle;
        private System.Windows.Forms.GroupBox GroupBox_Door_TDWS;
        private System.Windows.Forms.Label Label_UnlockDoor_TDWS;
        private System.Windows.Forms.Label Label_DoorIsLocked_TDWS;
        private System.Windows.Forms.GroupBox GroupBox_DoorSensor_TDWS;
        private System.Windows.Forms.RadioButton RadioButton_DoorClosed_TDWS;
        private System.Windows.Forms.RadioButton RadioButton_DoorOpen_TDWS;
        private System.Windows.Forms.GroupBox GroupBox_Estop_TDWS;
        private System.Windows.Forms.CheckBox CheckBox_ReqCompleteFlag_TDWS;
        private System.Windows.Forms.Label Label_StopStatus_TDWS;
        private System.Windows.Forms.Label Label_StopRequest_TDWS;
        private System.Windows.Forms.GroupBox GroupBox_OpBox_TDWS;
        private System.Windows.Forms.GroupBox GroupBox_KeySwitch_TDWS;
        private System.Windows.Forms.RadioButton RadioButton_Ready_TDWS;
        private System.Windows.Forms.RadioButton RadioButton_Req_TDWS;
        private System.Windows.Forms.Label Label_OpBoxLed_TDWS;
        private System.Windows.Forms.CheckBox CheckBox_EstopBtn_TDWS;
        private System.Windows.Forms.Button Btn_Reset_TDWS;
        private System.Windows.Forms.Button Btn_Run_TDWS;
        private System.Windows.Forms.CheckBox CheckBox_SafetyBoard_TDWS;
        private System.Windows.Forms.Label Label_SafetyBoard_TDWS;
        private System.Windows.Forms.GroupBox GroupBox_Contactors_TDWS;
        private System.Windows.Forms.Label Label_ContactorLamp_TDWS;
        private System.Windows.Forms.GroupBox GroupBox_Ctor_TDWStower;
        private System.Windows.Forms.CheckBox CheckBox_ContactorTripped_TDWStower;
        private System.Windows.Forms.CheckBox CheckBox_ContactorFdbk_TDWStower;
        private System.Windows.Forms.Label Label_ContactorFdbk_TDWStower;
        private System.Windows.Forms.CheckBox CheckBox_ContactorOnOff_TDWStower;
        private System.Windows.Forms.Label Label_ContactorPlcOut_TDWStower;
        private System.Windows.Forms.CheckBox CheckBox_FBAuto_TDWS;
        private System.Windows.Forms.GroupBox GroupBox_Ctor_TDWSpick;
        private System.Windows.Forms.CheckBox CheckBox_ContactorTripped_TDWSpick;
        private System.Windows.Forms.CheckBox CheckBox_ContactorFdbk_TDWSpick;
        private System.Windows.Forms.Label Label_ContactorFdbk_TDWSpick;
        private System.Windows.Forms.CheckBox CheckBox_ContactorOnOff_TDWSpick;
        private System.Windows.Forms.Label Label_ContactorPlcOut_TDWSpick;
        private System.Windows.Forms.GroupBox GroupBox_ZoningTDWS;
        private System.Windows.Forms.TextBox TextBox_ZoningStatus_TDWS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox GroupBox_ZoningCellCmd_TDWS;
        private System.Windows.Forms.RadioButton RadioButton_Cancel_TDWS;
        private System.Windows.Forms.RadioButton RadioButton_Permit_TDWS;
        private System.Windows.Forms.RadioButton RadioButton_Run_TDWS;
        private System.Windows.Forms.RadioButton RadioButton_None_TDWS;
        private System.Windows.Forms.GroupBox GroupBox_Estop_SmallAisle;
        private System.Windows.Forms.CheckBox CheckBox_ReqCompleteFlag_SmallAisle;
        private System.Windows.Forms.Label Label_StopStatus_SmallAisle;
        private System.Windows.Forms.Label Label_StopRequest_SmallAisle;
        private System.Windows.Forms.GroupBox GroupBox_OpBox_SmallAisle;
        private System.Windows.Forms.GroupBox GroupBox_KeySwitch_SmallAisle;
        private System.Windows.Forms.RadioButton RadioButton_Ready_SmallAisle;
        private System.Windows.Forms.RadioButton RadioButton_Req_SmallAisle;
        private System.Windows.Forms.Label Label_OpBoxLed_SmallAisle;
        private System.Windows.Forms.CheckBox CheckBox_EstopBtn_SmallAisle;
        private System.Windows.Forms.Button Btn_Reset_SmallAisle;
        private System.Windows.Forms.Button Btn_Run_SmallAisle;
        private System.Windows.Forms.CheckBox CheckBox_FBAuto_SmallAisle;
        private System.Windows.Forms.GroupBox GroupBox_Ctor_SmallAisle;
        private System.Windows.Forms.CheckBox CheckBox_ContactorTripped_SmallAisle;
        private System.Windows.Forms.CheckBox CheckBox_ContactorFdbk_SmallAisle;
        private System.Windows.Forms.Label Label_ContactorFdbk_SmallAisle;
        private System.Windows.Forms.CheckBox CheckBox_ContactorOnOff_SmallAisle;
        private System.Windows.Forms.Label Label_ContactorPlcOut_SmallAisle;
        private System.Windows.Forms.GroupBox GroupBox_Zoning_SmallAisle;
        private System.Windows.Forms.TextBox TextBox_ZoningStatus_SmallAisle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox GroupBox_ZoningCellCmd_SmallAisle;
        private System.Windows.Forms.RadioButton RadioButton_Cancel_SmallAisle;
        private System.Windows.Forms.RadioButton RadioButton_Permit_SmallAisle;
        private System.Windows.Forms.RadioButton RadioButton_Run_SmallAisle;
        private System.Windows.Forms.RadioButton RadioButton_None_SmallAisle;
        private System.Windows.Forms.GroupBox GroupBox_BOT;
        private System.Windows.Forms.ComboBox ComboBox_Bots;
        private System.Windows.Forms.Label Label_IsEstop_Bot;
        private System.Windows.Forms.Label Label_IsFault_Bot;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox CheckBox_Estop_BOT;
        private System.Windows.Forms.GroupBox GroupBox_Ctor_MaintArea;
        private System.Windows.Forms.CheckBox CheckBox_ContactorFdbk_MaintArea;
        private System.Windows.Forms.Label Label_ContactorFdbk_MaintArea;
        private System.Windows.Forms.Label Label_ContactorPlcOut_MaintArea;
        private System.Windows.Forms.Button Btn_Reset_NorthPanel;
        private System.Windows.Forms.Button Btn_BuzzerAck;
        private System.Windows.Forms.CheckBox CheckBox_FireAlarm;
        private System.Windows.Forms.CheckBox CheckBox_BotEvacComplete;
        private System.Windows.Forms.GroupBox GroupBox_;
        private System.Windows.Forms.RadioButton RadioButton_MaintArea_AisleMode;
        private System.Windows.Forms.Label Label_MaintenanceStatus;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox GroupBox_SafetyBoard_TDWS;
    }
}