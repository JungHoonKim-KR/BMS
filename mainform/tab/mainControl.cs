using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMSmonitoring.mainform.model;

namespace BMSmonitoring.mainform.tab
{
    public partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();
        }

        private void textBox_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.FromArgb(204, 204, 204), ButtonBorderStyle.Solid);
        }
        public void UpdateData(Battery battery)
        {
            Parsing(battery);
        }

        public void Parsing(Battery battery)
        {
            // 평균값
            tbAvgCellVolt.Text = battery.GetAvgCellVolt().ToString();
            tbAvgCellTemp.Text = battery.GetAvgCellTemp().ToString();

            // 최대값
            tbMaxCellVolt.Text = battery.GetMaxCellVolt().ToString();
            tbMaxCellTemp.Text = battery.GetMaxCellTemp().ToString();
            tbMaxVoltNumOfModule.Text = battery.GetModuleMaxVolt().ToString();
            tbMaxTempNumOfModule.Text = battery.GetModuleMaxTemp().ToString();

            // 최솟값
            tbMinCellVolt.Text = battery.GetMinCellVolt().ToString();
            tbMinCellTemp.Text = battery.GetMinCellTemp().ToString();
            tbMinVoltNumOfModule.Text = battery.GetModuleMinVolt().ToString();
            tbMinTempNumOfModule.Text = battery.GetModuleMinTemp().ToString();

        }

        private void MainControl_Load(object sender, EventArgs e)
        {

        }
    }
}
