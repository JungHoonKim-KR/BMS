namespace BMSmonitoring
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

  
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbVoltage;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tbSOC;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox tbCurrent;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox tbSOH;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnBatteryStatus;
        private System.Windows.Forms.Button btnOperation;
        private System.Windows.Forms.Button btnModuleFault;
        private System.Windows.Forms.Button btnProtectionFault;
        private System.Windows.Forms.Button btnProtectionWarning;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.Button btnParameters;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Button btnCell;
        private System.Windows.Forms.Button btnModule;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.TabPage tabModule;
        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgCellVolt;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinCellVolt;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxCellVolt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgCellTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinCellTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxCellTemp;
        private System.Windows.Forms.TabPage tabCell;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.TabPage tabParameters;
        private System.Windows.Forms.TabPage tabSystem;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tslComm;
        private System.Windows.Forms.ToolStripStatusLabel tslLog;
        private System.Windows.Forms.ToolStripStatusLabel tslTime;
        private System.Windows.Forms.ToolStripStatusLabel tslVersion;
        private System.Windows.Forms.Timer PCtimer;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Panel panel23;
        private System.Diagnostics.EventLog eventLog1;
        private mainform.tab.MainControl mainControl;
        private mainform.tab.StatusControl statusControl;
        private mainform.tab.ModuleControl moduleControl;

    }
}