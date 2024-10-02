using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BMSmonitoring.mainform.model
{
    public class Cell
    {
        double volt;

        public Cell(double volt)
        {
            this.volt = volt;
        }
        public double GetVolt() => volt;
    }

   
    public class Module
    {
        private List<Cell> cells = new List<Cell>();
        private List<double> temperatures = new List<double>();

        private int no;
        private double voltage = 0.0;  // "voltage" 컬럼
        private double avgCellVolt;  // "avgCellVolt" 컬럼
        private double maxCellVolt;  // "maxCellVolt" 컬럼
        private double minCellVolt;  // "minCellVolt" 컬럼
        private double avgCellTemp;  // "avgCellTemp" 컬럼
        private double maxCellTemp;  // "maxCellTemp" 컬럼
        private double minCellTemp;  // "minCellTemp" 컬럼

        public int GetNo() => no;
        public List<Cell> GetCells() => cells;
        public List<double> GetTemperatures() => temperatures;
        public double GetVoltage() => voltage;
        public double GetAvgCellVolt() => avgCellVolt;
        public double GetMaxCellVolt() => maxCellVolt;
        public double GetMinCellVolt() => minCellVolt;
        public double GetAvgCellTemp() => avgCellTemp;
        public double GetMaxCellTemp() => maxCellTemp;
        public double GetMinCellTemp() => minCellTemp;

        public Module() { }

        public Module(int no, List<Cell> cells, List<double> temperatures)
        {
            this.no = no;
            this.cells = cells;
            this.temperatures = temperatures;

            calSumVolt();

            Tuple<double, double> avgResult = calAvg();
            avgCellVolt = avgResult.Item1;
            avgCellTemp = avgResult.Item2;

            Tuple<double, double> maxResult = calMax();
            maxCellVolt = maxResult.Item1;
            maxCellTemp = maxResult.Item2;

            Tuple<double, double> minResult = calMin();
            minCellVolt = minResult.Item1;
            minCellTemp = minResult.Item2;
        }

        public List<Cell> getCells()
        {
            return this.cells;
        }

        private void calSumVolt()
        {
            foreach (Cell cell in cells)
            {
                this.voltage += cell.GetVolt();
            }
        }

        public Tuple<double, double> calAvg()
        {

            // 각 모듈들의 값들을 계산하는 중에 각 모듈들에게 데이터를 매핑
            double avgVolt = cells.Any() ? cells.Average(cell => cell.GetVolt()) : 0.0;
            double avgTemp = temperatures.Any() ? temperatures.Average() : 0.0;
            return new Tuple<double, double>(avgVolt, avgTemp);

        }

        public Tuple<double, double> calMax()
        {
            // 초기값 설정
            double maxVolt = cells.Any() ? cells.Max(cell => cell.GetVolt()) : 0.0;
            double maxTemp = temperatures.Any() ? temperatures.Max() : 0.0;

            return Tuple.Create(maxVolt, maxTemp);
        }


        public Tuple<double, double> calMin()
        {
            // 초기값 설정 (최대값으로 설정)

            double minVolt = cells.Any() ? cells.Min(cell => cell.GetVolt()) : 0.0;
            double minTemperature = temperatures.Any() ? temperatures.Min() : 0.0;
            // 두 값을 Tuple로 반환 (최소값과 각 모듈의 인덱스 반환)
            return Tuple.Create(minVolt, minTemperature);
        }

        //public static Module ToDto()
        //{

        //}
    }

    public class Battery
    {
        private List<Module> modules = new List<Module>();
        private DateTime time;  // "time" 컬럼
        private double voltage = 0.0;  // "voltage" 컬럼
        private double current = 0.0;  // "current" 컬럼
        private double soc;  // "SOC" 컬럼
        private double soh;  // "SOH" 컬럼
        private double avgCellVolt;  // "avgCellVolt" 컬럼
        private double maxCellVolt;  // "maxCellVolt" 컬럼
        private int moduleMaxVolt;  // "moduleMaxVolt" 컬럼
        private double minCellVolt;  // "minCellVolt" 컬럼
        private int moduleMinVolt;  // "moduleMinVolt" 컬럼
        private double avgCellTemp;  // "avgCellTemp" 컬럼
        private double maxCellTemp;  // "maxCellTemp" 컬럼
        private int moduleMaxTemp;  // "moduleMaxTemp" 컬럼
        private double minCellTemp;  // "minCellTemp" 컬럼
        private int moduleMinTemp;  // "moduleMinTemp" 컬럼

        public List<Module> GetModules() => modules;
        public DateTime GetTime() => time;
        public double GetVoltage() => voltage;
        public double GetCurrent() => current;
        public double GetSOC() => soc;
        public double GetSOH() => soh;
        public double GetAvgCellVolt() => avgCellVolt;
        public double GetMaxCellVolt() => maxCellVolt;
        public int GetModuleMaxVolt() => moduleMaxVolt;
        public double GetMinCellVolt() => minCellVolt;
        public int GetModuleMinVolt() => moduleMinVolt;
        public double GetAvgCellTemp() => avgCellTemp;
        public double GetMaxCellTemp() => maxCellTemp;
        public int GetModuleMaxTemp() => moduleMaxTemp;
        public double GetMinCellTemp() => minCellTemp;
        public int GetModuleMinTemp() => moduleMinTemp;


        public Battery() { }

        public Battery(List<Module> modules, double soc, double soh)
        {
            this.modules = modules;

            Tuple<double, double> avgResult = calAvg();
            avgCellVolt = avgResult.Item1;
            avgCellTemp = avgResult.Item2;

            // 최대값
            Tuple<double, double, int, int> maxResult = calMax();
            maxCellVolt = maxResult.Item1;
            maxCellTemp = maxResult.Item2;
            moduleMaxVolt = maxResult.Item3;
            moduleMaxTemp = maxResult.Item4;

            // 최대값
            Tuple<double, double, int, int> minResult = calMin();
            minCellVolt = minResult.Item1;
            minCellTemp = minResult.Item2;
            moduleMinVolt = minResult.Item3;
            moduleMinTemp = minResult.Item4;

            // 전압값 매핑
            calVolt();

            this.soc = soc;
            this.soh = soh;
        }
        private void calVolt()
        {
            foreach (Module module in this.modules)
            {
                this.voltage += module.GetVoltage();
            }
        }

        public Tuple<double, double> calAvg()
        {

            // 각 모듈들의 값들을 계산하는 중에 각 모듈들에게 데이터를 매핑
            double sumAvgOfVolt = modules.Average(module => module.GetAvgCellVolt());
            double sumAvgOfTemp = modules.Average(module => module.GetAvgCellTemp());

            return new Tuple<double, double>(sumAvgOfVolt ,sumAvgOfTemp );

        }

        public Tuple<double, double, int, int> calMax()
        {
            // 초기값 설정
            var maxVoltModule = modules
                .Select(module => new { No = module.GetNo(), Voltage = module.GetMaxCellVolt() })
                .OrderByDescending(x => x.Voltage)
                .FirstOrDefault();

            var maxTempModule = modules.
                Select(module => new { No = module.GetNo(), Temp = module.GetMaxCellTemp() })
                .OrderByDescending(x => x.Temp)
                .FirstOrDefault();

            // 두 값을 Tuple로 반환 (최대값과 각 모듈의 인덱스 반환)
            return Tuple.Create(maxVoltModule.Voltage, maxTempModule.Temp, maxVoltModule.No,maxTempModule.No);
        }


        public Tuple<double, double, int, int> calMin()
        {
            var minVoltModule = modules
              .Select(module => new { No = module.GetNo(), Voltage = module.GetMaxCellVolt() })
              .OrderBy(x => x.Voltage)
              .FirstOrDefault();

            var minTempModule = modules.
                Select(module => new { No = module.GetNo(), Temp = module.GetMaxCellTemp() })
                .OrderBy(x => x.Temp)
                .FirstOrDefault();
            return Tuple.Create(minVoltModule.Voltage, minTempModule.Temp, minVoltModule.No, minTempModule.No);
        }

        public static Battery MapBatteryData(SQLiteDataReader reader)
        {
            return new Battery
            {
                voltage = reader.IsDBNull(reader.GetOrdinal("voltage")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("voltage")),
                avgCellVolt = reader.IsDBNull(reader.GetOrdinal("avgCellVolt")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("avgCellVolt")),
                minCellVolt = reader.IsDBNull(reader.GetOrdinal("minCellVolt")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("minCellVolt")),
                maxCellVolt = reader.IsDBNull(reader.GetOrdinal("maxCellVolt")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("maxCellVolt")),
                avgCellTemp = reader.IsDBNull(reader.GetOrdinal("avgCellTemp")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("avgCellTemp")),
                minCellTemp = reader.IsDBNull(reader.GetOrdinal("minCellTemp")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("minCellTemp")),
                maxCellTemp = reader.IsDBNull(reader.GetOrdinal("maxCellTemp")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("maxCellTemp"))
            };
        }

    }
}
