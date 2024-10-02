using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMSmonitoring.mainform.tab
{
    public partial class StatusControl : UserControl
    {
        public StatusControl()
        {
            InitializeComponent();

            dgStatus.Rows.Add("Cell Over Voltage", "●", "●");
            dgStatus.Rows.Add("Cell Under Voltage", "●", "●");
            dgStatus.Rows.Add("Cell Voltage Deviation", "●", "●");
            dgStatus.Rows.Add("Cell Over Temperature", "●", "●");
            dgStatus.Rows.Add("Cell Under Temperature", "●", "●");
            dgStatus.Rows.Add("Cell Temp. Deviation", "●", "●");
            dgStatus.Rows.Add("Battery Over Voltage", "●", "●");
            dgStatus.Rows.Add("Battery Under Voltage", "●", "●");
            dgStatus.Rows.Add("Battery Over Charging Current:", "●", "●");
            dgStatus.Rows.Add("Battery Over Discharging Current", "●", "●");
            dgStatus.Rows.Add("Low SOC", "●", "●");

            dgModuleFaults.Rows.Add("MODULE 01", "MODULE 09");
            dgModuleFaults.Rows.Add("MODULE 02", "MODULE 10");
            dgModuleFaults.Rows.Add("MODULE 03", "MODULE 11");
            dgModuleFaults.Rows.Add("MODULE 04", "MODULE 12");
            dgModuleFaults.Rows.Add("MODULE 05", "MODULE 13");
            dgModuleFaults.Rows.Add("MODULE 06", "MODULE 14");
            dgModuleFaults.Rows.Add("MODULE 07", "MODULE 15");
            dgModuleFaults.Rows.Add("MODULE 08", "MODULE 16");

            dgOpertationFault.Rows.Add("Precharge Relay Fault");
            dgOpertationFault.Rows.Add("MAIN+Relay Fault");
            dgOpertationFault.Rows.Add("Fuse Blown Fault");
        }

    }
}
