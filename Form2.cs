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

namespace BMSmonitoring
{
    public partial class Form2 : Form
    {
        Conn_Database db = Conn_Database.Instance;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cbSerialPort.Items.AddRange(ports);
            //cbSerialPort.SelectedIndex = 0;
            //cbSerialPort.SelectedIndex = 10;

            string selectQuery = "SELECT portName, baudRate, dataBits, parity, stopBits, flowControl FROM SerialPort";
            DataTable dt = db.GetDataTable(selectQuery);
            
            foreach (var item in cbSerialPort.Items)
            {                    
                if (item.ToString() == dt.Rows[0]["portName"].ToString())
                {
                    cbSerialPort.SelectedItem = item;
                    break;  // 일치하는 버튼을 찾았으면 반복 종료
                }
            }

            foreach (var item in cbBaudRate.Items)
            {
                if (item.ToString() == dt.Rows[0]["baudRate"].ToString())
                {
                    cbBaudRate.SelectedItem = item;
                    break;
                }
            }

            foreach (Control control in gbDatabits.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Text.Substring(0,1) == dt.Rows[0]["dataBits"].ToString())
                    {
                        radioButton.Checked = true;
                        break; 
                    }
                }
            }

            foreach (Control control in gbParity.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Text == dt.Rows[0]["parity"].ToString())
                    {
                        radioButton.Checked = true;
                        break; 
                    }
                }
            }

            foreach (Control control in gbStopBits.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Text.Substring(0, 1) == dt.Rows[0]["stopBits"].ToString())
                    {
                        radioButton.Checked = true;
                        break; 
                    }
                }
            }

            foreach (Control control in gbFlowControl.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Text == dt.Rows[0]["flowControl"].ToString())
                    {
                        radioButton.Checked = true;
                        break;
                    }
                }
            }

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            string portName = cbSerialPort.Text;
            int baudRate = int.Parse(cbBaudRate.Text);
            int dataBits = 8;
            string parity = "None";
            int stopBits = 1;
            string flowControl = "None";


            foreach (Control control in gbDatabits.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    dataBits = int.Parse(radioButton.Text.Substring(0, 1));
                    break; // 선택된 RadioButton이 있으면 반복문 종료
                }
            }

            foreach (Control control in gbParity.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    parity = radioButton.Text;
                    break;
                }
            }

            foreach (Control control in gbStopBits.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    stopBits = int.Parse(radioButton.Text.Substring(0, 1));
                    break;
                }
            }

            foreach (Control control in gbFlowControl.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    flowControl = radioButton.Text;
                    break;
                }
            }

            var data = new Dictionary<string, object>
                {
                    {"portName", portName},
                    {"baudRate", baudRate},
                    {"dataBits", dataBits },
                    {"parity", parity},
                    {"stopBits", stopBits},
                    {"flowControl", flowControl}
                };

            db.UpdateData("SerialPort", data, "1=1");

            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cbBaudRate.SelectedItem = "38400";
            rbData2.Checked = true;
            rbParity1.Checked = true;
            rbStop1.Checked = true;
            rbFlow1.Checked = true;
        }
    }
}
