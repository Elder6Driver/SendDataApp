using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Model;

namespace SendDataApp
{
    public partial class Form1 : Form
    {

        private SerialPort comArduino = new SerialPort();
        private StringBuilder builder = new StringBuilder();
        private IList<string> datanow = new List<string>();
        System.Timers.Timer t = new System.Timers.Timer();  


        public Form1()
        {
            InitializeComponent();
        }

        //刷新com口列表
        private void btnComRefresh_Click(object sender, EventArgs e)
        {
            comRefresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comRefresh();

            comArduino.NewLine = "\r\n";
            comArduino.RtsEnable = true;//根据实际情况吧。

            t.Enabled = false;     //是否执行System.Timers.Timer.Elapsed事件；  

            comArduino.DataReceived += comArduino_DataReceived;

            t.Elapsed += new System.Timers.ElapsedEventHandler(timething); //到达时间的时候执行事件；   
        }


        void comArduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(50);//如果不sleep的话得到的串会分开
            int n = comArduino.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
            byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据

            comArduino.Read(buf, 0, n);//读取缓冲数据
            builder.Clear();//清除字符串构造器的内容
            //因为要访问ui资源，所以需要使用invoke方式同步ui。
            this.Invoke((EventHandler)(delegate
            {

                builder.Append(Encoding.ASCII.GetString(buf));
                char[] trimchars = { '\r', '\n' };
                string originaldata = builder.ToString().Trim(trimchars);
                string[] dataarray = originaldata.Split(',');

                //这里需要读取相关信息，然后显示在dataadd中
                //同时将数据插入相关数据库

                DataOperate dataoperator = new DataOperate();

                IList<ParamInfo> paraminfo = new List<ParamInfo>();

                paraminfo = dataoperator.GetParamByParamName(dataarray[1]);

                int deviceid = dataoperator.GetDeviceIDbyDeviceDesc(dataarray[0]);

                OriginalDataInfo datainfo = new OriginalDataInfo();

                datainfo.DeviceID = deviceid;
                datainfo.InsertTime = DateTime.Now;
                datainfo.ParamID = paraminfo[0].ParamID;
                datainfo.ParamValue = float.Parse( dataarray[2]);

                dataoperator.InsertData(datainfo);

                string dataadd = "设备信息:" + dataarray[0] + "  " + "参数描述:" + paraminfo[0].ParamDesc + "  " + "时间:" + datainfo.InsertTime + "  " + "参数值:" + dataarray[2];
                
                




                if (lbxData.Items.Count > 1000)
                {
                    lbxData.Items.RemoveAt(0);
                }
                lbxData.Items.Add(dataadd);

            }));
        }

        
        private void comRefresh()
        {
            cbxCom.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            cbxCom.Items.AddRange(ports);
            cbxCom.SelectedIndex = cbxCom.Items.Count > 0 ? 0 : -1;

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (comArduino.IsOpen)
            {
                //打开时点击，则关闭串口
                comArduino.Close();
                pbxConnect.BackColor = System.Drawing.Color.Red;
                
            }
            else
            {
                //关闭时点击，则设置好端口，波特率后打开
                comArduino.PortName = cbxCom.Text;
                
                comArduino.BaudRate = 9600;
                try
                {
                    comArduino.Open();
                    pbxConnect.BackColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                double time = tbtime.Value  * 1000*30*60;
                t.Interval = time;
                t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；  
                t.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
                
            }
            catch (Exception ex)
            {
                //现实异常信息给客户。
                MessageBox.Show(ex.Message);
            }

        }

        public void timething(object source, System.Timers.ElapsedEventArgs e)
        {
            comArduino.Write("+tempreature");
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                t.Enabled = false;     //是否执行System.Timers.Timer.Elapsed事件；  
                t.AutoReset = false;   //设置是执行一次（false）还是一直执行(true)；   

            }
            catch (Exception ex)
            {
                //现实异常信息给客户。
                MessageBox.Show(ex.Message);
            }
        }  


    }
}
