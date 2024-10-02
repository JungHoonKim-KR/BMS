using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMSmonitoring.mainform.model;
using System.Windows.Forms;
using BMSmonitoring.mainform.dto;

namespace BMSmonitoring.mainform.tab
{
    public partial class ModuleControl : UserControl
    {
        Conn_Database db = Conn_Database.Instance;
        private BatteryService batteryService = new BatteryService();
        public ModuleControl()
        {
            InitializeComponent();
        }

        public void UpdateData(Battery bayttery)
        {
            Parsing(bayttery);
        }

        private void Parsing(Battery battery)
        {
            List<Module> modules = battery.GetModules();
            List<ModuleDto> moduleDtos = new List<ModuleDto>();
            foreach(Module module in modules)
            {
                ModuleDto moduleDto = ModuleDto.ToDto(module);
                moduleDtos.Add(moduleDto);
            }
            

            dataGridView1.DataSource = moduleDtos;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void ModuleControl_Load(object sender, EventArgs e)
        {

        }

        private void ModuleControl_Load_1(object sender, EventArgs e)
        {

        }
    }
}
