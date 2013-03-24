using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;

// http://blog.daum.net/starkcb/46
// Server Side

namespace WiFi_Server_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitalizeServer();
        }

        public static Socket Server;
        EndPoint localEP, remoteEP;
        public bool InitalizeServer()
        {
            // set addr obj
            //IPAddress serverIP = IPAddress.Parse("192.168.0.108");
            localEP = new IPEndPoint(IPAddress.Any, 1234);
            remoteEP = new IPEndPoint(IPAddress.None, 1234);

            try {
                // set server obj
                Server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                Server.Bind(localEP);

                Status("-------------------------------");
                Status("Waiting for Connection ..."); 
                Status("-------------------------------");
                RunClientThread();

            } catch (Exception e) {
                MessageBox.Show(e.Message.ToString());
                Status("Error Initalizing Server."); 
            }

            return true;
        }

        public static Thread SThread;
        public void RunClientThread()
        {
            bAlive = true;
            SThread = new Thread(SocketThreadFunc);
            SThread.Start();
        }

        string stringbyte;
        byte[] getByte = new byte[1024];
        Boolean bAlive;
        public void SocketThreadFunc()
        {
            try
            {
                while (bAlive)
                {
                    getByte = new byte[1024];
                    int l = Server.ReceiveFrom(getByte, ref remoteEP);
                    stringbyte = Encoding.ASCII.GetString(getByte);
                    String[] str_datas = stringbyte.Split('\n');
                    for (int i = 0; i < str_datas.Length; i++)
                        ProcessRecvData(str_datas[i]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                Status("Error Socket Data Transmission."); 
            }
            Status("연결 종료");
        }

        public void ProcessRecvData(String str)
        {
            try
            {
                str = str.Replace("\0", string.Empty);
                if (str.Length == 0) return;

                String[] str_param = str.Split('#');
                if (str_param.Length <= 1)
                {
                    Status(String.Format("데이터:{0}", str_param[0]));

                }
                else if (str_param.Length == 3)
                {
                    if (Int32.Parse(str_param[0]) == 200)
                    {
                        String[] str_args = str_param[2].Split(',');
                        float _acclX = Single.Parse(str_args[0]);
                        float _acclY = Single.Parse(str_args[1]);
                        float _acclZ = Single.Parse(str_args[2]);

                        acclX.Invoke(new MethodInvoker(delegate() { acclX.Value = (int)(_acclX * 100) + 5000; }));
                        acclY.Invoke(new MethodInvoker(delegate() { acclY.Value = (int)(_acclY * 100) + 5000; }));
                        acclZ.Invoke(new MethodInvoker(delegate() { acclZ.Value = (int)(_acclZ * 100) + 5000; }));

                        accl_stat.Invoke(new MethodInvoker(delegate() { 
                            accl_stat.Text = String.Format("{0} - {1}, {2}, {3}",
                                sensor_Accl_proc(_acclX, _acclY, _acclZ).ToString(),
                                _acclX, _acclY, _acclZ); 
                        }));
                    }
                    else if (Int32.Parse(str_param[0]) == 201)
                    {
                        String[] str_args = str_param[2].Split(',');
                        oriX = Single.Parse(str_args[0]);
                        oriY = Single.Parse(str_args[1]);
                        oriZ = Single.Parse(str_args[2]);

                        ori_stat.Invoke(new MethodInvoker(delegate()
                        {
                            ori_stat.Text = String.Format("{0}, {1}, {2}",
                                oriX, oriY, oriZ);
                        }));
                        pb.Invalidate();
                    }
                    else if (Int32.Parse(str_param[0]) == 300)
                    {
                        if (str_param[2] != "null")
                        {
                            Status(str_param[2]);
                        }

                        // left right up 등 만들기
                    }
                    else if (Int32.Parse(str_param[0]) == 301)
                    {
                    }
                }
            }
            catch (Exception e)
            {
                Status("[ERROR] 와이파이 수신상태가 좋지 않습니다 (Buffer Overflow)");
            }
        }

        public static int byteArrayDefrag(byte[] sData)
        {
            int endLength = 0;
            for (int i = 0; i < sData.Length; i++)
            {
                if ((byte)sData[i] != (byte)0)
                {
                    endLength = i;
                }
            }
            return endLength;
        }

        public void Status(String s)
        {
            lb.Invoke(new MethodInvoker(delegate()
            {
                lb.Items.Add(s);
            }));
        }

        public float sensor_Accl_proc(float X, float Y, float Z)
        {
            double v = System.Math.Sqrt(X*X+Y*Y+Z*Z);
            return (float)(v - 9.8);
        }

        float oriX;
        float oriY;
        float oriZ;

        private void button2_Click(object sender, EventArgs e)
        {
            bAlive = false;
            SThread.Abort();
            Server.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String str = "Shake";
            ASCIIEncoding ae = new ASCIIEncoding();

            //Server.Send(ae.GetBytes(str));
            int i = Server.SendTo(ae.GetBytes(str), ae.GetBytes(str).Length, SocketFlags.None, remoteEP);
            Status(String.Format("{0} bytes 보냄", i));
        }

        private void pbPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);

            // get pos
            int px = (int)(pb.Width * (1 + oriX / 40) / 2);
            int py = (int)(pb.Height * (1 + oriY / 30) / 2);

            e.Graphics.DrawRectangle(new Pen(Color.White), px - 5, py - 5, 10, 10);
        }

        /*
         * 할 일
         * 1. 센서값을 화면좌표로 환산 (ok)
         * -> calibration 기능 추가! (ok)
         * 2. 패킷송수신 예외 제거 및 확실하게 보장하기
         * 3. 가속도센서 확인해보기 (일정값 이상이면 특정 이벤트 작동) <선택> -> 왼쪽 오른쪽 위 아래 앞 뒤 가속도상태확인하기
         * 
         * grav y값 음수 (대략 -3) : 왼쪽
           양수 (+3) : 오른쪽 
         * 
         */
    }
}
