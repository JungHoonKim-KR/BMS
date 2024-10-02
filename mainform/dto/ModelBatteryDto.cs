using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMSmonitoring.mainform.model;

namespace BMSmonitoring.mainform.dto
{
    public class ModuleDto
    {
        public int No { get; set; }
        public double Voltage { get; set; }
        public double AvgCellVolt { get; set; }
        public double MinCellVolt { get; set; }
        public double MaxCellVolt { get; set; }
        public double AvgCellTemp { get; set; }
        public double MinCellTemp { get; set; }
        public double MaxCellTemp { get; set; }

        public ModuleDto(int no, double voltage, double avgCellVolt, double minCellVolt, double maxCellVolt,
                                double avgCellTemp, double minCellTemp, double maxCellTemp)
        {
            No = no;
            Voltage = voltage;
            AvgCellVolt = avgCellVolt;
            MinCellVolt = minCellVolt;
            MaxCellVolt = maxCellVolt;
            AvgCellTemp = avgCellTemp;
            MinCellTemp = minCellTemp;
            MaxCellTemp = maxCellTemp;
        }

        public static ModuleDto ToDto(Module module)
        {
            return new ModuleDto(
                module.GetNo(),
                module.GetVoltage(),
                module.GetAvgCellVolt(),
                module.GetMinCellVolt(),
                module.GetMaxCellVolt(),
                module.GetAvgCellTemp(),
                module.GetMinCellTemp(),
                module.GetMaxCellTemp()
            );
        }

    }
}
