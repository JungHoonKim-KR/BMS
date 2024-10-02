namespace BMSmonitoring
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbSerialPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.gbDatabits = new System.Windows.Forms.GroupBox();
            this.rbData2 = new System.Windows.Forms.RadioButton();
            this.rbData1 = new System.Windows.Forms.RadioButton();
            this.gbParity = new System.Windows.Forms.GroupBox();
            this.rbParity3 = new System.Windows.Forms.RadioButton();
            this.rbParity2 = new System.Windows.Forms.RadioButton();
            this.rbParity1 = new System.Windows.Forms.RadioButton();
            this.gbStopBits = new System.Windows.Forms.GroupBox();
            this.rbStop2 = new System.Windows.Forms.RadioButton();
            this.rbStop1 = new System.Windows.Forms.RadioButton();
            this.gbFlowControl = new System.Windows.Forms.GroupBox();
            this.rbFlow4 = new System.Windows.Forms.RadioButton();
            this.rbFlow2 = new System.Windows.Forms.RadioButton();
            this.rbFlow1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_close = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gbDatabits.SuspendLayout();
            this.gbParity.SuspendLayout();
            this.gbStopBits.SuspendLayout();
            this.gbFlowControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial Port:";
            // 
            // cbSerialPort
            // 
            this.cbSerialPort.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbSerialPort.FormattingEnabled = true;
            this.cbSerialPort.ItemHeight = 15;
            this.cbSerialPort.Location = new System.Drawing.Point(10, 68);
            this.cbSerialPort.Name = "cbSerialPort";
            this.cbSerialPort.Size = new System.Drawing.Size(158, 23);
            this.cbSerialPort.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(196, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate [bps]:";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.ItemHeight = 15;
            this.cbBaudRate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.cbBaudRate.Location = new System.Drawing.Point(198, 68);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(158, 23);
            this.cbBaudRate.TabIndex = 3;
            // 
            // gbDatabits
            // 
            this.gbDatabits.Controls.Add(this.rbData2);
            this.gbDatabits.Controls.Add(this.rbData1);
            this.gbDatabits.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.gbDatabits.Location = new System.Drawing.Point(10, 98);
            this.gbDatabits.Name = "gbDatabits";
            this.gbDatabits.Size = new System.Drawing.Size(158, 50);
            this.gbDatabits.TabIndex = 4;
            this.gbDatabits.TabStop = false;
            this.gbDatabits.Text = "Data Bits: ";
            // 
            // rbData2
            // 
            this.rbData2.AutoSize = true;
            this.rbData2.Location = new System.Drawing.Point(81, 23);
            this.rbData2.Name = "rbData2";
            this.rbData2.Size = new System.Drawing.Size(55, 19);
            this.rbData2.TabIndex = 1;
            this.rbData2.Text = "8 bits";
            this.rbData2.UseVisualStyleBackColor = true;
            // 
            // rbData1
            // 
            this.rbData1.AutoSize = true;
            this.rbData1.Location = new System.Drawing.Point(11, 23);
            this.rbData1.Name = "rbData1";
            this.rbData1.Size = new System.Drawing.Size(55, 19);
            this.rbData1.TabIndex = 0;
            this.rbData1.Text = "7 bits";
            this.rbData1.UseVisualStyleBackColor = true;
            // 
            // gbParity
            // 
            this.gbParity.Controls.Add(this.rbParity3);
            this.gbParity.Controls.Add(this.rbParity2);
            this.gbParity.Controls.Add(this.rbParity1);
            this.gbParity.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.gbParity.Location = new System.Drawing.Point(10, 160);
            this.gbParity.Name = "gbParity";
            this.gbParity.Size = new System.Drawing.Size(158, 105);
            this.gbParity.TabIndex = 6;
            this.gbParity.TabStop = false;
            this.gbParity.Text = "Parity: ";
            // 
            // rbParity3
            // 
            this.rbParity3.AutoSize = true;
            this.rbParity3.Location = new System.Drawing.Point(9, 74);
            this.rbParity3.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.rbParity3.Name = "rbParity3";
            this.rbParity3.Size = new System.Drawing.Size(50, 19);
            this.rbParity3.TabIndex = 2;
            this.rbParity3.Text = "Even";
            this.rbParity3.UseVisualStyleBackColor = true;
            // 
            // rbParity2
            // 
            this.rbParity2.AutoSize = true;
            this.rbParity2.Location = new System.Drawing.Point(9, 50);
            this.rbParity2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.rbParity2.Name = "rbParity2";
            this.rbParity2.Size = new System.Drawing.Size(48, 19);
            this.rbParity2.TabIndex = 1;
            this.rbParity2.Text = "Odd";
            this.rbParity2.UseVisualStyleBackColor = true;
            // 
            // rbParity1
            // 
            this.rbParity1.AutoSize = true;
            this.rbParity1.Location = new System.Drawing.Point(9, 25);
            this.rbParity1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.rbParity1.Name = "rbParity1";
            this.rbParity1.Size = new System.Drawing.Size(54, 19);
            this.rbParity1.TabIndex = 0;
            this.rbParity1.Text = "None";
            this.rbParity1.UseVisualStyleBackColor = true;
            // 
            // gbStopBits
            // 
            this.gbStopBits.Controls.Add(this.rbStop2);
            this.gbStopBits.Controls.Add(this.rbStop1);
            this.gbStopBits.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.gbStopBits.Location = new System.Drawing.Point(10, 275);
            this.gbStopBits.Name = "gbStopBits";
            this.gbStopBits.Size = new System.Drawing.Size(158, 50);
            this.gbStopBits.TabIndex = 7;
            this.gbStopBits.TabStop = false;
            this.gbStopBits.Text = "Stop Bits: ";
            // 
            // rbStop2
            // 
            this.rbStop2.AutoSize = true;
            this.rbStop2.Location = new System.Drawing.Point(81, 21);
            this.rbStop2.Name = "rbStop2";
            this.rbStop2.Size = new System.Drawing.Size(50, 19);
            this.rbStop2.TabIndex = 1;
            this.rbStop2.Text = "2 bit";
            this.rbStop2.UseVisualStyleBackColor = true;
            // 
            // rbStop1
            // 
            this.rbStop1.AutoSize = true;
            this.rbStop1.Checked = true;
            this.rbStop1.Location = new System.Drawing.Point(8, 21);
            this.rbStop1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.rbStop1.Name = "rbStop1";
            this.rbStop1.Size = new System.Drawing.Size(50, 19);
            this.rbStop1.TabIndex = 0;
            this.rbStop1.TabStop = true;
            this.rbStop1.Text = "1 bit";
            this.rbStop1.UseVisualStyleBackColor = true;
            // 
            // gbFlowControl
            // 
            this.gbFlowControl.Controls.Add(this.rbFlow4);
            this.gbFlowControl.Controls.Add(this.rbFlow2);
            this.gbFlowControl.Controls.Add(this.rbFlow1);
            this.gbFlowControl.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.gbFlowControl.Location = new System.Drawing.Point(198, 98);
            this.gbFlowControl.Name = "gbFlowControl";
            this.gbFlowControl.Size = new System.Drawing.Size(158, 95);
            this.gbFlowControl.TabIndex = 8;
            this.gbFlowControl.TabStop = false;
            this.gbFlowControl.Text = "Flow Control: ";
            // 
            // rbFlow4
            // 
            this.rbFlow4.AutoSize = true;
            this.rbFlow4.Location = new System.Drawing.Point(9, 66);
            this.rbFlow4.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.rbFlow4.Name = "rbFlow4";
            this.rbFlow4.Size = new System.Drawing.Size(75, 19);
            this.rbFlow4.TabIndex = 3;
            this.rbFlow4.Text = "DTR/DSR";
            this.rbFlow4.UseVisualStyleBackColor = true;
            // 
            // rbFlow2
            // 
            this.rbFlow2.AutoSize = true;
            this.rbFlow2.Location = new System.Drawing.Point(9, 44);
            this.rbFlow2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.rbFlow2.Name = "rbFlow2";
            this.rbFlow2.Size = new System.Drawing.Size(71, 19);
            this.rbFlow2.TabIndex = 2;
            this.rbFlow2.Text = "RTS/CTS";
            this.rbFlow2.UseVisualStyleBackColor = true;
            // 
            // rbFlow1
            // 
            this.rbFlow1.AutoSize = true;
            this.rbFlow1.Checked = true;
            this.rbFlow1.Location = new System.Drawing.Point(9, 22);
            this.rbFlow1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.rbFlow1.Name = "rbFlow1";
            this.rbFlow1.Size = new System.Drawing.Size(54, 19);
            this.rbFlow1.TabIndex = 0;
            this.rbFlow1.TabStop = true;
            this.rbFlow1.Text = "None";
            this.rbFlow1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.gbFlowControl);
            this.panel1.Controls.Add(this.gbStopBits);
            this.panel1.Controls.Add(this.gbParity);
            this.panel1.Controls.Add(this.gbDatabits);
            this.panel1.Controls.Add(this.cbBaudRate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbSerialPort);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 385);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 336);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 47);
            this.panel2.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(199)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(199)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::BMSmonitoring.Properties.Resources.icon_Refresh4;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(10, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 30);
            this.button2.TabIndex = 11;
            this.button2.Text = "RTU Default";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(194)))), ((int)(((byte)(214)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(194)))), ((int)(((byte)(211)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::BMSmonitoring.Properties.Resources.icon_close1;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(263, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(95, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "CANCEL";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Image = global::BMSmonitoring.Properties.Resources.icon_Check1;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(161, 9);
            this.btnOk.Name = "btnOk";
            this.btnOk.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnOk.Size = new System.Drawing.Size(95, 30);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.btn_close, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(368, 35);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.btn_close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Image = global::BMSmonitoring.Properties.Resources.close;
            this.btn_close.Location = new System.Drawing.Point(338, 5);
            this.btn_close.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(25, 25);
            this.btn_close.TabIndex = 5;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 9, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Setting Device";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 385);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting Device";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.gbDatabits.ResumeLayout(false);
            this.gbDatabits.PerformLayout();
            this.gbParity.ResumeLayout(false);
            this.gbParity.PerformLayout();
            this.gbStopBits.ResumeLayout(false);
            this.gbStopBits.PerformLayout();
            this.gbFlowControl.ResumeLayout(false);
            this.gbFlowControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSerialPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.GroupBox gbDatabits;
        private System.Windows.Forms.RadioButton rbData2;
        private System.Windows.Forms.RadioButton rbData1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox gbParity;
        private System.Windows.Forms.RadioButton rbParity3;
        private System.Windows.Forms.RadioButton rbParity2;
        private System.Windows.Forms.RadioButton rbParity1;
        private System.Windows.Forms.GroupBox gbStopBits;
        private System.Windows.Forms.RadioButton rbStop2;
        private System.Windows.Forms.RadioButton rbStop1;
        private System.Windows.Forms.GroupBox gbFlowControl;
        private System.Windows.Forms.RadioButton rbFlow4;
        private System.Windows.Forms.RadioButton rbFlow2;
        private System.Windows.Forms.RadioButton rbFlow1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
    }
}