using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using BMSmonitoring.mainform.model;
namespace BMSmonitoring
{
    public partial class MainForm : Form
    {
        Conn_Database db = Conn_Database.Instance;
        // 여기서 Battery 정보를 받아서 객체로 만드는게 필요
        BatteryService batteryService = new BatteryService();

        private string command = "";

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            PCtimer.Interval = 1000;
            lbPtime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            PCtimer.Start();
            tslLog.Text = "";
            tslTime.Text = "Start: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            tslVersion.Text = "App: 1.0.0.14";
        }

        private void PCtimer_Tick(object sender, EventArgs e)
        {
            lbPtime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMin = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbPtime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnProtectionFault = new System.Windows.Forms.Button();
            this.btnProtectionWarning = new System.Windows.Forms.Button();
            this.btnModuleFault = new System.Windows.Forms.Button();
            this.btnOperation = new System.Windows.Forms.Button();
            this.btnBatteryStatus = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tbSOH = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbCurrent = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tbSOC = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbVoltage = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnSystem = new System.Windows.Forms.Button();
            this.btnParameters = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.btnCell = new System.Windows.Forms.Button();
            this.btnModule = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.tabModule = new System.Windows.Forms.TabPage();
            this.tabCell = new System.Windows.Forms.TabPage();
            this.tabData = new System.Windows.Forms.TabPage();
            this.tabParameters = new System.Windows.Forms.TabPage();
            this.tabSystem = new System.Windows.Forms.TabPage();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgCellVolt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinCellVolt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxCellVolt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgCellTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinCellTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxCellTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tslComm = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.PCtimer = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.eventLog1 = new System.Diagnostics.EventLog();
         
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabStatus.SuspendLayout();
            this.tabModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.btnMin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.title, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMax, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 35);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.btnMin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Image = global::BMSmonitoring.Properties.Resources.minus;
            this.btnMin.Location = new System.Drawing.Point(1100, 5);
            this.btnMin.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(25, 25);
            this.btnMin.TabIndex = 3;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.title.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(3, 0);
            this.title.Name = "title";
            this.title.Padding = new System.Windows.Forms.Padding(15, 7, 0, 0);
            this.title.Size = new System.Drawing.Size(1089, 35);
            this.title.TabIndex = 0;
            this.title.Text = "BMS Monitoring Program";
            this.title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_MouseDown);
            this.title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title_MouseMove);
            this.title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.title_MouseUp);
            // 
            // btnMax
            // 
            this.btnMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.btnMax.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.ForeColor = System.Drawing.Color.White;
            this.btnMax.Image = global::BMSmonitoring.Properties.Resources.max;
            this.btnMax.Location = new System.Drawing.Point(1135, 5);
            this.btnMax.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(25, 25);
            this.btnMax.TabIndex = 2;
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(155)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::BMSmonitoring.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(1170, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1200, 51);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 50);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnSetting, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnConnect, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 3, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(753, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(436, 50);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // btnSetting
            // 
            this.btnSetting.AutoSize = true;
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Image = global::BMSmonitoring.Properties.Resources.icon_s_off;
            this.btnSetting.Location = new System.Drawing.Point(183, 10);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(39, 30);
            this.btnSetting.TabIndex = 3;
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            this.btnSetting.MouseLeave += new System.EventHandler(this.btnSettingOff);
            this.btnSetting.MouseHover += new System.EventHandler(this.btnSettingOn);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(194)))), ((int)(((byte)(211)))));
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(70, 10);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(110, 31);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            this.btnConnect.MouseHover += new System.EventHandler(this.btn_Connect);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label3.Location = new System.Drawing.Point(0, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "COMM.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbPtime);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(228, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 44);
            this.panel2.TabIndex = 4;
            // 
            // lbPtime
            // 
            this.lbPtime.AutoSize = true;
            this.lbPtime.Font = new System.Drawing.Font("돋움", 9F);
            this.lbPtime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(84)))), ((int)(((byte)(176)))));
            this.lbPtime.Location = new System.Drawing.Point(80, 17);
            this.lbPtime.Name = "lbPtime";
            this.lbPtime.Size = new System.Drawing.Size(113, 12);
            this.lbPtime.TabIndex = 12;
            this.lbPtime.Text = "2024-09-23 00:00:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(84)))), ((int)(((byte)(176)))));
            this.label4.Location = new System.Drawing.Point(8, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "PC Time";
            // 
            // label2
            // 
            this.label2.Image = global::BMSmonitoring.Properties.Resources.login;
            this.label2.Location = new System.Drawing.Point(20, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 38);
            this.label2.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(458, 98);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(730, 123);
            this.panel4.TabIndex = 9;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.btnProtectionFault);
            this.panel6.Controls.Add(this.btnProtectionWarning);
            this.panel6.Controls.Add(this.btnModuleFault);
            this.panel6.Controls.Add(this.btnOperation);
            this.panel6.Controls.Add(this.btnBatteryStatus);
            this.panel6.Controls.Add(this.label25);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.label21);
            this.panel6.Controls.Add(this.label22);
            this.panel6.Controls.Add(this.label23);
            this.panel6.Controls.Add(this.label24);
            this.panel6.Location = new System.Drawing.Point(3, 1);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 3, 5, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(724, 121);
            this.panel6.TabIndex = 0;
            // 
            // btnProtectionFault
            // 
            this.btnProtectionFault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.btnProtectionFault.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnProtectionFault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProtectionFault.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProtectionFault.Location = new System.Drawing.Point(364, 75);
            this.btnProtectionFault.Name = "btnProtectionFault";
            this.btnProtectionFault.Size = new System.Drawing.Size(110, 26);
            this.btnProtectionFault.TabIndex = 23;
            this.btnProtectionFault.Text = "Normal";
            this.btnProtectionFault.UseVisualStyleBackColor = false;
            this.btnProtectionFault.MouseHover += new System.EventHandler(this.btn_Warning);
            // 
            // btnProtectionWarning
            // 
            this.btnProtectionWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.btnProtectionWarning.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnProtectionWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProtectionWarning.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProtectionWarning.Location = new System.Drawing.Point(135, 75);
            this.btnProtectionWarning.Name = "btnProtectionWarning";
            this.btnProtectionWarning.Size = new System.Drawing.Size(110, 26);
            this.btnProtectionWarning.TabIndex = 22;
            this.btnProtectionWarning.Text = "Normal";
            this.btnProtectionWarning.UseVisualStyleBackColor = false;
            this.btnProtectionWarning.MouseHover += new System.EventHandler(this.btn_Warning);
            // 
            // btnModuleFault
            // 
            this.btnModuleFault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.btnModuleFault.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnModuleFault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModuleFault.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModuleFault.Location = new System.Drawing.Point(585, 40);
            this.btnModuleFault.Name = "btnModuleFault";
            this.btnModuleFault.Size = new System.Drawing.Size(110, 26);
            this.btnModuleFault.TabIndex = 21;
            this.btnModuleFault.Text = "Normal";
            this.btnModuleFault.UseVisualStyleBackColor = false;
            this.btnModuleFault.MouseHover += new System.EventHandler(this.btn_Fault);
            // 
            // btnOperation
            // 
            this.btnOperation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.btnOperation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperation.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOperation.Location = new System.Drawing.Point(364, 40);
            this.btnOperation.Name = "btnOperation";
            this.btnOperation.Size = new System.Drawing.Size(110, 26);
            this.btnOperation.TabIndex = 20;
            this.btnOperation.Text = "Normal";
            this.btnOperation.UseVisualStyleBackColor = false;
            this.btnOperation.MouseHover += new System.EventHandler(this.btn_Fault);
            // 
            // btnBatteryStatus
            // 
            this.btnBatteryStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.btnBatteryStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBatteryStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatteryStatus.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBatteryStatus.Location = new System.Drawing.Point(135, 40);
            this.btnBatteryStatus.Name = "btnBatteryStatus";
            this.btnBatteryStatus.Size = new System.Drawing.Size(110, 26);
            this.btnBatteryStatus.TabIndex = 19;
            this.btnBatteryStatus.Text = "Discharge";
            this.btnBatteryStatus.UseVisualStyleBackColor = false;
            this.btnBatteryStatus.MouseLeave += new System.EventHandler(this.btn_stand);
            this.btnBatteryStatus.MouseHover += new System.EventHandler(this.btn_Charge);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label25.Location = new System.Drawing.Point(500, 46);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 15);
            this.label25.TabIndex = 18;
            this.label25.Text = "Module Fault";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label17.Location = new System.Drawing.Point(266, 81);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 15);
            this.label17.TabIndex = 13;
            this.label17.Text = "Protection Fault";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label21.Location = new System.Drawing.Point(266, 46);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(90, 15);
            this.label21.TabIndex = 12;
            this.label21.Text = "Operation Fault";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label22.Location = new System.Drawing.Point(19, 81);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(111, 15);
            this.label22.TabIndex = 11;
            this.label22.Text = "Protection Warning";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label23.Location = new System.Drawing.Point(19, 46);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 15);
            this.label23.TabIndex = 10;
            this.label23.Text = "Battery Status";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.Location = new System.Drawing.Point(19, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(110, 20);
            this.label24.TabIndex = 9;
            this.label24.Text = "Battery Status";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.label31);
            this.panel5.Controls.Add(this.label32);
            this.panel5.Location = new System.Drawing.Point(14, 98);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(428, 123);
            this.panel5.TabIndex = 8;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.tbSOH);
            this.panel9.Location = new System.Drawing.Point(290, 77);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(110, 26);
            this.panel9.TabIndex = 8;
            this.panel9.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // tbSOH
            // 
            this.tbSOH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSOH.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSOH.Location = new System.Drawing.Point(5, 6);
            this.tbSOH.Name = "tbSOH";
            this.tbSOH.Size = new System.Drawing.Size(100, 16);
            this.tbSOH.TabIndex = 6;
            this.tbSOH.Text = "asdfsdf";
            this.tbSOH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.tbCurrent);
            this.panel8.Location = new System.Drawing.Point(93, 77);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(110, 26);
            this.panel8.TabIndex = 7;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // tbCurrent
            // 
            this.tbCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCurrent.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCurrent.Location = new System.Drawing.Point(5, 6);
            this.tbCurrent.Name = "tbCurrent";
            this.tbCurrent.Size = new System.Drawing.Size(100, 16);
            this.tbCurrent.TabIndex = 6;
            this.tbCurrent.Text = "asdfsdf";
            this.tbCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.tbSOC);
            this.panel7.Location = new System.Drawing.Point(290, 42);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(110, 26);
            this.panel7.TabIndex = 6;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // tbSOC
            // 
            this.tbSOC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSOC.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSOC.Location = new System.Drawing.Point(5, 6);
            this.tbSOC.Name = "tbSOC";
            this.tbSOC.Size = new System.Drawing.Size(100, 16);
            this.tbSOC.TabIndex = 6;
            this.tbSOC.Text = "asdfsdf";
            this.tbSOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.tbVoltage);
            this.panel3.Location = new System.Drawing.Point(93, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(110, 26);
            this.panel3.TabIndex = 5;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // tbVoltage
            // 
            this.tbVoltage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVoltage.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbVoltage.Location = new System.Drawing.Point(5, 6);
            this.tbVoltage.Name = "tbVoltage";
            this.tbVoltage.Size = new System.Drawing.Size(100, 16);
            this.tbVoltage.TabIndex = 6;
            this.tbVoltage.Text = "asdfsdf";
            this.tbVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label20.Location = new System.Drawing.Point(229, 82);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 15);
            this.label20.TabIndex = 4;
            this.label20.Text = "SOH [%]";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label19.Location = new System.Drawing.Point(229, 46);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 15);
            this.label19.TabIndex = 3;
            this.label19.Text = "SOC [%]";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label18.Location = new System.Drawing.Point(19, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 15);
            this.label18.TabIndex = 2;
            this.label18.Text = "Current[A]";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label31.Location = new System.Drawing.Point(19, 46);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(68, 15);
            this.label31.TabIndex = 1;
            this.label31.Text = "Voltage [V]";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label32.Location = new System.Drawing.Point(19, 13);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(117, 20);
            this.label32.TabIndex = 0;
            this.label32.Text = "Battery System";
            // 
            // btnSetup
            // 
            this.btnSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(211)))), ((int)(((byte)(224)))));
            this.btnSetup.FlatAppearance.BorderSize = 0;
            this.btnSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetup.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSetup.Location = new System.Drawing.Point(903, 236);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(125, 34);
            this.btnSetup.TabIndex = 21;
            this.btnSetup.Text = "SET UP";
            this.btnSetup.UseVisualStyleBackColor = false;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnSystem
            // 
            this.btnSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(211)))), ((int)(((byte)(224)))));
            this.btnSystem.FlatAppearance.BorderSize = 0;
            this.btnSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystem.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSystem.Location = new System.Drawing.Point(776, 236);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(125, 34);
            this.btnSystem.TabIndex = 20;
            this.btnSystem.Text = "SYSTEM";
            this.btnSystem.UseVisualStyleBackColor = false;
            this.btnSystem.Click += new System.EventHandler(this.btnSystem_Click);
            // 
            // btnParameters
            // 
            this.btnParameters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(211)))), ((int)(((byte)(224)))));
            this.btnParameters.FlatAppearance.BorderSize = 0;
            this.btnParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParameters.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnParameters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnParameters.Location = new System.Drawing.Point(649, 236);
            this.btnParameters.Name = "btnParameters";
            this.btnParameters.Size = new System.Drawing.Size(125, 34);
            this.btnParameters.TabIndex = 19;
            this.btnParameters.Text = "PARAMETERS";
            this.btnParameters.UseVisualStyleBackColor = false;
            this.btnParameters.Click += new System.EventHandler(this.btnParameters_Click);
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(211)))), ((int)(((byte)(224)))));
            this.btnData.FlatAppearance.BorderSize = 0;
            this.btnData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnData.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnData.Location = new System.Drawing.Point(522, 236);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(125, 34);
            this.btnData.TabIndex = 18;
            this.btnData.Text = "DATA";
            this.btnData.UseVisualStyleBackColor = false;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // btnCell
            // 
            this.btnCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(211)))), ((int)(((byte)(224)))));
            this.btnCell.FlatAppearance.BorderSize = 0;
            this.btnCell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCell.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnCell.Location = new System.Drawing.Point(395, 236);
            this.btnCell.Name = "btnCell";
            this.btnCell.Size = new System.Drawing.Size(125, 34);
            this.btnCell.TabIndex = 17;
            this.btnCell.Text = "CELL";
            this.btnCell.UseVisualStyleBackColor = false;
            this.btnCell.Click += new System.EventHandler(this.btnCell_Click);
            // 
            // btnModule
            // 
            this.btnModule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(211)))), ((int)(((byte)(224)))));
            this.btnModule.FlatAppearance.BorderSize = 0;
            this.btnModule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModule.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnModule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnModule.Location = new System.Drawing.Point(268, 236);
            this.btnModule.Name = "btnModule";
            this.btnModule.Size = new System.Drawing.Size(125, 34);
            this.btnModule.TabIndex = 16;
            this.btnModule.Text = "MODULE";
            this.btnModule.UseVisualStyleBackColor = false;
            this.btnModule.Click += new System.EventHandler(this.btnModule_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(211)))), ((int)(((byte)(224)))));
            this.btnStatus.FlatAppearance.BorderSize = 0;
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatus.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnStatus.Location = new System.Drawing.Point(141, 236);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(125, 34);
            this.btnStatus.TabIndex = 15;
            this.btnStatus.Text = "STATUS";
            this.btnStatus.UseVisualStyleBackColor = false;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(84)))), ((int)(((byte)(176)))));
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnMain.ForeColor = System.Drawing.Color.White;
            this.btnMain.Location = new System.Drawing.Point(14, 236);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(125, 34);
            this.btnMain.TabIndex = 14;
            this.btnMain.Text = "MAIN";
            this.btnMain.UseVisualStyleBackColor = false;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabStatus);
            this.tabControl.Controls.Add(this.tabModule);
            this.tabControl.Controls.Add(this.tabCell);
            this.tabControl.Controls.Add(this.tabData);
            this.tabControl.Controls.Add(this.tabParameters);
            this.tabControl.Controls.Add(this.tabSystem);
            this.tabControl.Controls.Add(this.tabSetup);
            this.tabControl.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(15, 272);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(25, 3);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1173, 390);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 22;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_Selected);
            // 
            // tabMain
            // 
            this.mainControl = new mainform.tab.MainControl();
            this.tabMain.Controls.Add(this.mainControl);
            this.tabMain.Location = new System.Drawing.Point(4, 5);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1165, 381);
            this.tabMain.TabIndex = 0;
            // 
            // tabStatus
            // 
            this.statusControl = new BMSmonitoring.mainform.tab.StatusControl();
            this.tabStatus.Controls.Add(this.statusControl);
            this.tabStatus.Location = new System.Drawing.Point(4, 5);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatus.Size = new System.Drawing.Size(1165, 381);
            this.tabStatus.TabIndex = 1;
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // tabModule
            // 
            this.moduleControl = new BMSmonitoring.mainform.tab.ModuleControl();
            this.tabModule.Controls.Add(this.moduleControl);
            this.tabModule.Location = new System.Drawing.Point(4, 5);
            this.tabModule.Name = "tabModule";
            this.tabModule.Padding = new System.Windows.Forms.Padding(3);
            this.tabModule.Size = new System.Drawing.Size(1165, 381);
            this.tabModule.TabIndex = 2;
            this.tabModule.UseVisualStyleBackColor = true;
            // 
            // tabCell
            // 
            this.tabCell.Location = new System.Drawing.Point(4, 5);
            this.tabCell.Name = "tabCell";
            this.tabCell.Padding = new System.Windows.Forms.Padding(3);
            this.tabCell.Size = new System.Drawing.Size(1165, 381);
            this.tabCell.TabIndex = 3;
            this.tabCell.UseVisualStyleBackColor = true;
            // 
            // tabData
            // 
            this.tabData.Location = new System.Drawing.Point(4, 5);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(1165, 381);
            this.tabData.TabIndex = 4;
            this.tabData.UseVisualStyleBackColor = true;

            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            // 
            // tabParameters
            // 
            this.tabParameters.Location = new System.Drawing.Point(4, 5);
            this.tabParameters.Name = "tabParameters";
            this.tabParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabParameters.Size = new System.Drawing.Size(1165, 381);
            this.tabParameters.TabIndex = 5;
            this.tabParameters.UseVisualStyleBackColor = true;
            // 
            // tabSystem
            // 
            this.tabSystem.Location = new System.Drawing.Point(4, 5);
            this.tabSystem.Name = "tabSystem";
            this.tabSystem.Padding = new System.Windows.Forms.Padding(3);
            this.tabSystem.Size = new System.Drawing.Size(1165, 381);
            this.tabSystem.TabIndex = 6;
            this.tabSystem.UseVisualStyleBackColor = true;
            // 
            // tabSetup
            // 
            this.tabSetup.Location = new System.Drawing.Point(4, 5);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(1165, 381);
            this.tabSetup.TabIndex = 7;
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Voltage,
            this.AvgCellVolt,
            this.MinCellVolt,
            this.MaxCellVolt,
            this.AvgCellTemp,
            this.MinCellTemp,
            this.MaxCellTemp});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(19, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(972, 287);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            // 
            // Voltage
            // 
            this.Voltage.HeaderText = "Voltage [V]";
            this.Voltage.Name = "Voltage";
            // 
            // AvgCellVolt
            // 
            this.AvgCellVolt.HeaderText = "Avg. Cell Volt. [V]";
            this.AvgCellVolt.Name = "AvgCellVolt";
            // 
            // MinCellVolt
            // 
            this.MinCellVolt.HeaderText = "Min. Cell Volt. [V]";
            this.MinCellVolt.Name = "MinCellVolt";
            // 
            // MaxCellVolt
            // 
            this.MaxCellVolt.HeaderText = "Max. Cell Volt. [V]";
            this.MaxCellVolt.Name = "MaxCellVolt";
            // 
            // AvgCellTemp
            // 
            this.AvgCellTemp.HeaderText = "Avg. Cell Temp. [℃]";
            this.AvgCellTemp.Name = "AvgCellTemp";
            // 
            // MinCellTemp
            // 
            this.MinCellTemp.HeaderText = "Min. Cell Temp. [℃]";
            this.MinCellTemp.Name = "MinCellTemp";
            // 
            // MaxCellTemp
            // 
            this.MaxCellTemp.HeaderText = "Max. Cell Temp. [℃]";
            this.MaxCellTemp.Name = "MaxCellTemp";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(244)))));
            this.statusStrip.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslComm,
            this.tslLog,
            this.tslTime,
            this.tslVersion});
            this.statusStrip.Location = new System.Drawing.Point(0, 676);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 24);
            this.statusStrip.TabIndex = 23;
            // 
            // tslComm
            // 
            this.tslComm.AutoSize = false;
            this.tslComm.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tslComm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tslComm.Name = "tslComm";
            this.tslComm.Size = new System.Drawing.Size(150, 19);
            this.tslComm.Text = ": Ready";
            this.tslComm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tslLog
            // 
            this.tslLog.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tslLog.Name = "tslLog";
            this.tslLog.Size = new System.Drawing.Size(730, 19);
            this.tslLog.Spring = true;
            // 
            // tslTime
            // 
            this.tslTime.AutoSize = false;
            this.tslTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tslTime.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tslTime.Name = "tslTime";
            this.tslTime.Size = new System.Drawing.Size(160, 19);
            // 
            // tslVersion
            // 
            this.tslVersion.AutoSize = false;
            this.tslVersion.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tslVersion.Name = "tslVersion";
            this.tslVersion.Size = new System.Drawing.Size(145, 19);
            this.tslVersion.Text = "App: 1.0.0.1";
            this.tslVersion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // panel20
            // 
            this.panel20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.panel20.Controls.Add(this.panel21);
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Margin = new System.Windows.Forms.Padding(3, 3, 3, 23);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(1200, 700);
            this.panel20.TabIndex = 24;
            this.panel20.Paint += new System.Windows.Forms.PaintEventHandler(this.panel20_line);
            // 
            // panel21
            // 
            this.panel21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.panel21.Controls.Add(this.panel23);
            this.panel21.Controls.Add(this.panel22);
            this.panel21.Location = new System.Drawing.Point(3, 3);
            this.panel21.Margin = new System.Windows.Forms.Padding(2, 3, 2, 25);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(1195, 696);
            this.panel21.TabIndex = 25;
            // 
            // panel23
            // 
            this.panel23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(169)))), ((int)(((byte)(233)))));
            this.panel23.Location = new System.Drawing.Point(11, 268);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(1175, 392);
            this.panel23.TabIndex = 1;
            // 
            // panel22
            // 
            this.panel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel22.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel22.Location = new System.Drawing.Point(0, 672);
            this.panel22.Margin = new System.Windows.Forms.Padding(0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(1195, 24);
            this.panel22.TabIndex = 0;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // mainControl
            // 
            this.mainControl.Location = new System.Drawing.Point(0, 0);
            this.mainControl.Name = "mainControl";
            this.mainControl.Size = new System.Drawing.Size(1161, 377);
            this.mainControl.TabIndex = 0;
            this.mainControl.Load += new System.EventHandler(this.mainControl_Load);
            // 
            // statusControl
            // 
            this.statusControl.Location = new System.Drawing.Point(0, 0);
            this.statusControl.Name = "statusControl";
            this.statusControl.Size = new System.Drawing.Size(1161, 377);
            this.statusControl.TabIndex = 0;
            // 
            // moduleControl
            // 
            this.moduleControl.Location = new System.Drawing.Point(0, 0);
            this.moduleControl.Name = "moduleControl";
            this.moduleControl.Size = new System.Drawing.Size(1012, 362);
            this.moduleControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.btnSystem);
            this.Controls.Add(this.btnParameters);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.btnCell);
            this.Controls.Add(this.btnModule);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel20);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BMS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabStatus.ResumeLayout(false);
            this.tabModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

 
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnMin;
        private Button btnClose;
        private Button btnMax;

        // 창 이동 관련 전역 변수
        bool mouseDown;
        Point lastLocation;

        // 마우스 좌클릭 시
        private void title_MouseDown(object sender, MouseEventArgs e)
        {
            // 마우스 클릭 여부, 폼의 마지막 위치 저장
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }

        // 마우스 클릭을 마친 경우 클릭 이벤트
        private void title_MouseUp(object sender, MouseEventArgs e)
        {
            // 마우스 클릭 여부 저장
            mouseDown = false;
        }

        // 마우스로 폼 이동 시
        private void title_MouseMove(object sender, MouseEventArgs e)
        {
            // 마우스 클릭 상태 시 폼이 이동된 위치로 이동
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        // 최소화
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // 최대화 / 원상태로
        private void btnMax_Click(object sender, EventArgs e)
        {
            // 최대화 상태가 아닐 때 최대화
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMax.Image = global::BMSmonitoring.Properties.Resources.min;
            }
            // 최대화 상태일 때 원상태로
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMax.Image = global::BMSmonitoring.Properties.Resources.max;
            }
        }

        // 닫기
        private void btnClose_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private TableLayoutPanel tableLayoutPanel2;
        private Label title;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label2;
        private Label label3;
        private Button btnConnect;

        
        private Button btnSetting;
        private Panel panel2;
        private Label lbPtime;
        private Label label4;


        private void btnSettingOn(object sender, EventArgs e)
        {
            btnSetting.Image = BMSmonitoring.Properties.Resources.icon_s_on;
        }

        private void btnSettingOff(object sender, EventArgs e)
        {
            btnSetting.Image = BMSmonitoring.Properties.Resources.icon_s;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(158, 169, 233);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int Thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.panel5.ClientRectangle, col, Thickness, bbs, col, Thickness, bbs, col, Thickness, bbs, col, Thickness, bbs);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.FromArgb(158, 169, 233), ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.FromArgb(204, 204, 204), ButtonBorderStyle.Solid);
        }
        //
        //Battery Status 색버튼
        //
        private void btn_Charge(object sender, EventArgs e)
        {
            btnBatteryStatus.BackColor = Color.FromArgb(126, 232, 184);
            btnBatteryStatus.FlatStyle = FlatStyle.Flat;
            btnBatteryStatus.FlatAppearance.BorderColor = Color.FromArgb(126, 232, 184);
            btnBatteryStatus.FlatAppearance.BorderSize = 1;
            btnBatteryStatus.Text = "Charge";
            btnBatteryStatus.ForeColor = Color.White;
        }

        private void btn_stand(object sender, EventArgs e)
        {
            btnBatteryStatus.BackColor = Color.FromArgb(154, 194, 255);
            btnBatteryStatus.FlatStyle = FlatStyle.Flat;
            btnBatteryStatus.FlatAppearance.BorderColor = Color.FromArgb(154, 194, 255);
            btnBatteryStatus.FlatAppearance.BorderSize = 1;
            btnBatteryStatus.Text = "stand-by";
            btnBatteryStatus.ForeColor = Color.White;
        }
        
        private void btn_Fault(object sender, EventArgs e)
        {
            btnModuleFault.BackColor = Color.FromArgb(255, 199, 216);
            btnModuleFault.FlatStyle = FlatStyle.Flat;
            btnModuleFault.FlatAppearance.BorderColor = Color.FromArgb(255, 199, 216);
            btnModuleFault.FlatAppearance.BorderSize = 1;
            btnModuleFault.Text = "Fault";
            btnModuleFault.ForeColor = Color.White;
        }

        private void btn_Warning(object sender, EventArgs e)
        {
            btnProtectionFault.BackColor = Color.FromArgb(255, 213, 151);
            btnProtectionFault.FlatStyle = FlatStyle.Flat;
            btnProtectionFault.FlatAppearance.BorderColor = Color.FromArgb(255, 213, 151);
            btnProtectionFault.FlatAppearance.BorderSize = 1;
            btnProtectionFault.Text = "Warning";
            btnProtectionFault.ForeColor = Color.White;
        }
        //
        //tabpage 연결
        //
        private void btn_Connect(object sender, EventArgs e)
        {
            btnConnect.BackColor = Color.FromArgb(120, 174, 255);
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void btnModule_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void btnCell_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 4;
        }

        private void btnParameters_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 5;
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 6;
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 7;
        }

        

        private void tabControl1_Selected(object sender, EventArgs e)
        {
            btnMain.BackColor = Color.FromArgb(208, 211, 224);
            btnMain.ForeColor = Color.FromArgb(51, 51, 51);
            btnStatus.BackColor = Color.FromArgb(208, 211, 224);
            btnStatus.ForeColor = Color.FromArgb(51, 51, 51);
            btnModule.BackColor = Color.FromArgb(208, 211, 224);
            btnModule.ForeColor = Color.FromArgb(51, 51, 51);
            btnCell.BackColor = Color.FromArgb(208, 211, 224);
            btnCell.ForeColor = Color.FromArgb(51, 51, 51);
            btnData.BackColor = Color.FromArgb(208, 211, 224);
            btnData.ForeColor = Color.FromArgb(51, 51, 51);
            btnParameters.BackColor = Color.FromArgb(208, 211, 224);
            btnParameters.ForeColor = Color.FromArgb(51, 51, 51);
            btnSystem.BackColor = Color.FromArgb(208, 211, 224);
            btnSystem.ForeColor = Color.FromArgb(51, 51, 51);
            btnSetup.BackColor = Color.FromArgb(208, 211, 224);
            btnSetup.ForeColor = Color.FromArgb(51, 51, 51);


            switch (tabControl.SelectedIndex)
            {

                case 0:
                    btnMain.BackColor = Color.FromArgb(37, 84, 176);
                    btnMain.ForeColor = Color.FromArgb(255, 255, 255);                      
                    break;                    
                case 1:
                    btnStatus.BackColor = Color.FromArgb(37, 84, 176);
                    btnStatus.ForeColor = Color.FromArgb(255, 255, 255);                     
                    break;
                case 2:
                    btnModule.BackColor = Color.FromArgb(37, 84, 176);
                    btnModule.ForeColor = Color.FromArgb(255, 255, 255);
                    break;
                case 3:
                    btnCell.BackColor = Color.FromArgb(37, 84, 176);
                    btnCell.ForeColor = Color.FromArgb(255, 255, 255);
                    break;
                case 4:
                    btnData.BackColor = Color.FromArgb(37, 84, 176);
                    btnData.ForeColor = Color.FromArgb(255, 255, 255);
                    break;
                case 5:
                    btnParameters.BackColor = Color.FromArgb(37, 84, 176);
                    btnParameters.ForeColor = Color.FromArgb(255, 255, 255);
                    break;
                case 6:
                    btnSystem.BackColor = Color.FromArgb(37, 84, 176);
                    btnSystem.ForeColor = Color.FromArgb(255, 255, 255);
                    break;
                case 7:
                    btnSetup.BackColor = Color.FromArgb(37, 84, 176);
                    btnSetup.ForeColor = Color.FromArgb(255, 255, 255);
                    break;
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen == false)
            {
                try
                {
                    string selectQuery = "SELECT portName, baudRate, dataBits, parity, stopBits, flowControl FROM SerialPort";
                    System.Data.DataTable dt = db.GetDataTable(selectQuery);
                    serialPort.PortName = dt.Rows[0]["portName"].ToString();
                    serialPort.BaudRate = int.Parse(dt.Rows[0]["baudRate"].ToString());
                    serialPort.DataBits = int.Parse(dt.Rows[0]["dataBits"].ToString());
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), dt.Rows[0]["parity"].ToString());
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), dt.Rows[0]["stopBits"].ToString());
                    if (dt.Rows[0]["flowControl"].ToString() == "None")
                    {
                        serialPort.Handshake = Handshake.None;
                    }
                    else if (dt.Rows[0]["flowControl"].ToString() == "RTS/CTS")
                    {
                        serialPort.Handshake = Handshake.RequestToSend;
                    }
                    else if (dt.Rows[0]["flowControl"].ToString() == "DTR/DSR")
                    {
                        serialPort.Handshake = Handshake.RequestToSend;
                    }     

                    Console.WriteLine(serialPort.PortName);
                    serialPort.Open();
                    btnConnect.Text = "CONNECTED";
                    tslComm.Text = serialPort.PortName + " : Connected";
                    btnSetting.Enabled = false;

                    // 배터리 측정 요청
                    command = "AT&S";
                    serialPort.Write(command+ "\r\n");

               

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tslComm.Text = serialPort.PortName + " : Disconnected";
                    tslLog.Text = "EXCEPT: Could not open serial port (" + serialPort.PortName + ")";
                }
            }
            else
            {
                // 배터리 측정 중단
                command = "AT&E";
                serialPort.Write(command+ "\r\n");
                serialPort.Close();
                tslComm.Text = serialPort.PortName + " : Disconnected";
                tslLog.Text = "";
                btnConnect.Text = "CONNECT";
                btnSetting.Enabled = true;
                    
            }
        }


        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(158, 169, 233);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int Thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.panel5.ClientRectangle, col, Thickness, bbs, col, Thickness, bbs, col, Thickness, bbs, col, Thickness, bbs);
        }

        private void panel20_line(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(75, 75, 75);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int Thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.panel20.ClientRectangle, col, Thickness, bbs, col, Thickness, bbs, col, Thickness, bbs, col, Thickness, bbs);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(SerialReceived));
        }

        /* 데이터 파싱
        */

        // 탭이 변경될 때 호출되는 메서드
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string data = @"M1-C01:20000,C02:30000,C03:25000,C04:30000,SC:47012,T1:20000,T2:25000,T3:10200,EC:00000000\r\n"
                                      + @"M2-C01:15000,C02:17000,SC:48888,T1:35000,T2:32500,T3:40000,T4:37500,EC:00000000\r\n"
                                      + @"M3-C01:10000,C02:12000,C03:14000,SC:39720,T1:44000,T2:37000,EC:00000000\r\n";
            UpdateCurTabData(data);
        }

        // interval에 맞게 동작하며 데이터를 control에 계속 뿌려줌
        private void UpdateCurTabData(string data)
        {
            Battery battery = batteryService.CreateBattery(data);

            // 선택된 탭의 인덱스에 따른 처리
            if (tabControl.SelectedIndex == 0)
            {
                // 첫 번째 탭이 선택되었을 때 실행할 코드
                this.mainControl.UpdateData(battery);
            }
            else if (tabControl.SelectedIndex == 1)
            {
                // 두 번째 탭이 선택되었을 때 실행할 코드
                MessageBox.Show("두 번째 탭이 선택되었습니다.");
            }
            else if (tabControl.SelectedIndex == 2)
            {

                this.moduleControl.UpdateData(battery);
            }
            // 데이터 insert 메서드
            //batteryService.InsertBatteryData(battery);
        }
        /*
        */
        private void SerialReceived(object sender, EventArgs e)
        {
            string receivedData = serialPort.ReadExisting();
            Console.WriteLine(receivedData);

            switch (command)
            {
                case "AT&S":
                    // 배터리 정보 파싱
                    UpdateCurTabData(receivedData);

                    break;
                case "AT+rSI":
                    string pattern = @"(CI:)\d+|(NC:)\d+|(NM:)\d+|(NT:)\d+";

                    MatchCollection matches = Regex.Matches(receivedData, pattern);

                    foreach (Match match in matches)
                    {
                        string key = match.Groups[1].Value + match.Groups[2].Value + match.Groups[3].Value + match.Groups[4].Value;
                        string value = match.Value.Substring(key.Length);

                        switch (key)
                        {
                            case "CI":

                                break;
                            case "NC":
                                break;
                            case "NM":
                                break;
                            case "NT":
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine($"Key: {key}, Value: {value}");
                    }
                    break;
                case "AT+wSI":
                    break;
                case "AT+rSW":
                    break;
                case "AT+wSW":
                    break;
                case "AT+rCWL":
                    break;
                case "AT+wCWL":
                    break;
                case "AT+rCWR":
                    break;
                case "AT+wCWR":
                    break;
                case "AT+rCPL":
                    break;
                case "AT+wCPL":
                    break;
                case "AT+rCPR":
                    break;
                case "AT+wCPR":
                    break;
                case "AT+rRWL":
                    break;
                case "AT+wRWL":
                    break;
                case "AT+rRWR":
                    break;
                case "AT+wRWR":
                    break;
                case "AT+rRPL":
                    break;
                case "AT+wRPL":
                    break;
                case "AT+rRPR":
                    break;
                case "AT+wRPR":
                    break;
                default:
                    break;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen == true)
            {
                serialPort.Write("AT&E\r\n");
                serialPort.Close();
            }
            db.Close();
        }

        private void statusControl_ButtonClicked(object sender, EventArgs e)
        {
            serialPort.Write("AT&E\r\n");
            Thread.Sleep(100);
            command = "AT+rSI";
            serialPort.Write(command+"\r\n");

        }

        private void mainControl_Load(object sender, EventArgs e)
        {

        }
    }
}