namespace PLCSIM_Adv_CoSimulation
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // btn_createPLC
            // 
            this.btn_createPLC.Location = new System.Drawing.Point(12, 34);
            this.btn_createPLC.Name = "btn_createPLC";
            this.btn_createPLC.Size = new System.Drawing.Size(98, 28);
            this.btn_createPLC.TabIndex = 0;
            this.btn_createPLC.Text = "Create PLC";
            this.btn_createPLC.UseVisualStyleBackColor = true;
            this.btn_createPLC.Click += new System.EventHandler(this.btn_createPLC_Click);
            // 
            // textBox_PLC_name
            // 
            this.textBox_PLC_name.Location = new System.Drawing.Point(116, 38);
            this.textBox_PLC_name.Name = "textBox_PLC_name";
            this.textBox_PLC_name.Size = new System.Drawing.Size(116, 22);
            this.textBox_PLC_name.TabIndex = 1;
            // 
            // textBox_PLC_IPaddress
            // 
            this.textBox_PLC_IPaddress.Location = new System.Drawing.Point(238, 38);
            this.textBox_PLC_IPaddress.Name = "textBox_PLC_IPaddress";
            this.textBox_PLC_IPaddress.Size = new System.Drawing.Size(116, 22);
            this.textBox_PLC_IPaddress.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "PLC name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP address";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_PLC_IPaddress);
            this.Controls.Add(this.textBox_PLC_name);
            this.Controls.Add(this.btn_createPLC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_createPLC;
        private System.Windows.Forms.TextBox textBox_PLC_name;
        private System.Windows.Forms.TextBox textBox_PLC_IPaddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

