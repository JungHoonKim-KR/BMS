using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System;
using System.Linq;
using System.Data.SQLite;
using BMSmonitoring.mainform.model;

namespace BMSmonitoring
{

    public class BatteryService
    {
        Conn_Database db = Conn_Database.Instance;
        public Battery CreateBattery(string data)
        {
            // 예시 데이터: "M1-C01:38724,C02:38733,...Cnn:38739,T1:30000,…,Tn:35000,EC:00000000\r\n"
            //string data = @"M1-C01:20000,C02:30000,C03:25000,C04:30000,SC:47012,T1:92,T2:80,T3:102,EC:00000000\r\n"
            //                   + @"M2-C01:15000,C02:170000,SC:48888,T1:75,T2:80,T3:94,T4:95,EC:00000000\r\n"
            //                   + @"M3-C01:10000,C02:12000,C03:14000,SC:39720,T1:84,T2:70,EC:00000000\r\n";

            // 모듈 데이터 추출용 정규식
            string moduleReg = @"M(\d+)-((?:C\d+:\d+,)*(?:SC:\d+,)?(?:T\d+:\d+,)*EC:\d+)";
            MatchCollection moduleMatches = Regex.Matches(data, moduleReg);

            //// SOC, SOH 추출용 정규식
            //string socSohReg = @"SOC:(\d+),SOH:(\d+)";
            //Match socSohMatch = Regex.Match(data, socSohReg);

            // 모듈 리스트 생성
            List<Module> modules = new List<Module>();

            // 각 모듈 데이터 처리
            foreach (Match match in moduleMatches)
            {
                int moduleNumber = int.Parse(match.Groups[1].Value);
                string details = match.Groups[2].Value;

                // 셀 데이터 추출
                List<string> cellDataList = ExtractMatches(details, @"C\d+:(\d+)");

                //// SC 추출
                //List<string> scDataList = ExtractMatches(details, @"SC:(\d+)");

                // 온도 데이터 추출
                List<double> temperatureDataList = ExtractMatches(details, @"T\d+:(\d+)").Select(temp => (double.Parse(temp) - 273.0)/100).ToList();

                // Cell 객체 생성 후 리스트에 추가
                List<Cell> cellList = new List<Cell>();
                for (int i = 0; i < cellDataList.Count; i++)
                {
                    Cell cell = new Cell(double.Parse(cellDataList[i])/1000);
                    cellList.Add(cell);
                }



                // 모듈 생성 후 리스트에 추가
                Module module = new Module(moduleNumber, cellList, temperatureDataList);
                modules.Add(module);
            }

            // SOC와 SOH 값 추출 및 처리
            //double soc = 0.0, soh = 0.0;
            //if (socSohMatch.Success)
            //{
            //    soc = double.Parse(socSohMatch.Groups[1].Value);
            //    soh = double.Parse(socSohMatch.Groups[2].Value);
            //}

            return new Battery(modules, 0.0, 0.0);
        }

        // 간단한 매치 추출 메서드 (셀 값 및 온도 값 추출에 사용)
        private List<string> ExtractMatches(string input, string pattern)
        {
            List<string> matches = new List<string>();
            MatchCollection matchCollection = Regex.Matches(input, pattern);
            foreach (Match match in matchCollection)
            {
                matches.Add(match.Groups[1].Value);
            }
            return matches;
        }

        private MatchCollection make_MatchCollection(string reg, string data)
        {
            Regex regex = new Regex(reg);
            return regex.Matches(data);
        }

        public void InsertBatteryData(Battery battery)
        {
            // 배터리 데이터를 데이터베이스에 삽입하기 위해 Dictionary로 변환
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                { "voltage", battery.GetVoltage() },
                { "current", battery.GetCurrent() },
                { "SOC", battery.GetSOC() },
                { "SOH", battery.GetSOH() },
                { "avgCellVolt", battery.GetAvgCellVolt() },
                { "maxCellVolt", battery.GetMaxCellVolt() },
                { "moduleMaxVolt", battery.GetModuleMaxVolt() },
                { "minCellVolt", battery.GetModuleMinVolt() },
                { "moduleMinVolt", battery.GetModuleMinVolt() },
                { "avgCellTemp", battery.GetAvgCellTemp() },
                { "maxCellTemp", battery.GetMaxCellTemp() },
                { "moduleMaxTemp", battery.GetModuleMaxTemp() },
                { "minCellTemp", battery.GetMinCellTemp() },
                { "moduleMinTemp", battery.GetModuleMinTemp() }
            };

            db.InsertData("BatteryData", data);
            data.Clear();

            foreach (Module module in battery.GetModules())
            {
                int i = 0;
                data.Add("module", module.GetNo());
                foreach(Cell cell in module.GetCells())
                {
                    i++;
                    data.Add($"cell{i}", cell.GetVolt());
                }

                i = 0;
                foreach(double temp in module.GetTemperatures())
                {
                    i++;
                    data.Add($"temp{i}", temp);
                }

                db.InsertData("CellLog", data);
                data.Clear();
            }

        }

        public List<Battery> GetBatteries()
        {
            List<Battery> batteryList = db.SelectData("BatteryData", Battery.MapBatteryData);

            return batteryList;
        }



    }


}
