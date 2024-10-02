namespace BMSmonitoring.mainform.tab
{
    partial class ModuleControl
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgCellVolt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinCellVolt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxCellVolt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgCellTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinCellTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxCellTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Voltage,
            this.AvgCellVolt,
            this.MinCellVolt,
            this.MaxCellVolt,
            this.AvgCellTemp,
            this.MinCellTemp,
            this.MaxCellTemp});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.Location = new System.Drawing.Point(20, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(972, 287);
            this.dataGridView1.TabIndex = 2;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            // 
            // Voltage
            // 
            this.Voltage.DataPropertyName = "Voltage";
            this.Voltage.HeaderText = "Voltage [V]";
            this.Voltage.Name = "Voltage";
            // 
            // AvgCellVolt
            // 
            this.AvgCellVolt.DataPropertyName = "AvgCellVolt";
            this.AvgCellVolt.HeaderText = "Avg. Cell Volt. [V]";
            this.AvgCellVolt.Name = "AvgCellVolt";
            // 
            // MinCellVolt
            // 
            this.MinCellVolt.DataPropertyName = "MinCellVolt";
            this.MinCellVolt.HeaderText = "Min. Cell Volt. [V]";
            this.MinCellVolt.Name = "MinCellVolt";
            // 
            // MaxCellVolt
            // 
            this.MaxCellVolt.DataPropertyName = "MaxCellVolt";
            this.MaxCellVolt.HeaderText = "Max. Cell Volt. [V]";
            this.MaxCellVolt.Name = "MaxCellVolt";
            // 
            // AvgCellTemp
            // 
            this.AvgCellTemp.DataPropertyName = "AvgCellTemp";
            this.AvgCellTemp.HeaderText = "Avg. Cell Temp. [℃]";
            this.AvgCellTemp.Name = "AvgCellTemp";
            // 
            // MinCellTemp
            // 
            this.MinCellTemp.DataPropertyName = "MinCellTemp";
            this.MinCellTemp.HeaderText = "Min. Cell Temp. [℃]";
            this.MinCellTemp.Name = "MinCellTemp";
            // 
            // MaxCellTemp
            // 
            this.MaxCellTemp.DataPropertyName = "MaxCellTemp";
            this.MaxCellTemp.HeaderText = "Max. Cell Temp. [℃]";
            this.MaxCellTemp.Name = "MaxCellTemp";
            // 
            // ModuleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "ModuleControl";
            this.Size = new System.Drawing.Size(1012, 362);
            this.Load += new System.EventHandler(this.ModuleControl_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgCellVolt;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinCellVolt;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxCellVolt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgCellTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinCellTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxCellTemp;
    }
}
