using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Configuration;

namespace MegalabClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          // Control.CheckForIllegalCrossThreadCalls = false;
        }

        Socket socketSend;
        string host = "192.168.1.139";

        private void btnCommSet_Click(object sender, EventArgs e)
        {
            IPAddress IPWasher = IPAddress.Parse(host);
            var message = "";
            try
            {
                //创建客户端Socket，获得远程ip和端口号
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketSend.Connect(IPWasher, 8090);

                var buffer = new byte[1024];//设置一个缓冲区，用来保存数据

                socketSend.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback((ar) =>
                {
                    var length = socketSend.EndReceive(ar);
                    message = Encoding.Unicode.GetString(buffer, 0, length);
                    OutputLine(message);
                }), null);
                OutputLine("Connnet to server");
                socketSend.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socketSend);
            }
            catch (Exception)
            {
                OutputLine("IP或者端口号错误...");
            }
        }


        static byte[] buffer = new byte[1024];
        public  void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                var socket = ar.AsyncState as Socket;
                var length = socket.EndReceive(ar);
                var message = Encoding.Unicode.GetString(buffer, 0, length);
                OutputLine(message);
                //嵌套调动
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
            }
            catch (Exception ex)
            {
                OutputLine(ex.Message);
            }
        }

        public  void OutputLine(String str)
        {
            Action<string> ac = (strLine) =>
            {
                  strLine = (strLine.Replace("\r\n", "\n").Replace("\n", "\r\n")) + "\r\n";

                  int charsToRemove = (tbCommInfo.TextLength + strLine.Length) - tbCommInfo.MaxLength;

                  if (charsToRemove > 0)
                  {
                      tbCommInfo.Text = tbCommInfo.Text.Remove(0, tbCommInfo.Text.IndexOf("\r\n", charsToRemove) + 2);
                  }

                  tbCommInfo.AppendText(strLine);
                  tbCommInfo.AppendText("\r\n");
              };
            Invoke(ac, str);
        }

        private void OutputLine(String strErrorText, Exception exception)
        {
            OutputLine(strErrorText);
            OutputLine("/==============================\\");
            OutputLine("Error Code: " + exception.Message);
            OutputLine("------------------------------");
            OutputLine("Error Text:");
            OutputLine("\t" + exception.Message.Replace("\r\n", "\n").Replace("\n", "\r\n\t"));
            OutputLine("\\==============================/");
        }
        private void btnCommInfoClear_Click(object sender, EventArgs e)
        {
            tbCommInfo.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = tbDataSend.Text.Trim();
                socketSend.Send(Encoding.Unicode.GetBytes(msg));
            }
            catch { }
        }


        delegate void feedbcak(int value);

        void feedbacktooutput(int ii)
        {
            OutputLine("res is "+ ii.ToString());
        }



        void counter(feedbcak fb)
        {
            for(int ii = 0;ii<5;ii++ )
            {
                if(fb!=null)
                {
                    fb(33);
                }
            }
        }
        private void btnDoDeleGate_Click(object sender, EventArgs e)
        {
            //counter(new feedbcak (feedbacktooutput));
            // feedbcak myfb = new feedbcak(feedbacktooutput);
            //counter((int ii) => OutputLine("what a fuck"));

            // test mytest_1 = new test(mytest);
            //mytest_1.Invoke();
            //hertest(new test(mytest));
            //hertest((string str)=>OutputLine("Hello world"));
            //actiontest();
            //threadaction();
            //OutputLine("hello");

            doit();
        }


        void threadaction()
        {
            Thread th = new Thread((object o) =>
            {
                int mm = Convert.ToInt32(o);
                   for (int ii = 0; ii < mm; ii++)
                   {
                       Action ac = () =>
                       {
                           OutputLine("thread ii is " + ii.ToString());
                       };
                       Invoke(ac);
                       Thread.Sleep(1000);
                   }
            }
            );
            tbDataSend.Text = "HHH";
            th.Start(8);
        }

        delegate void test(string str);
        void mytest(string str)
        {
            OutputLine("my name is .."+ str);
        }

        void hertest(test tt)
        {
            if(tt!=null)
            {
                tt("HH");
            }
        }

        void actiontest()
        {
            Action<string> myaction = new Action<string>(mytest);
            myaction("hh");
        }

        delegate void deletest(int ii);

        void add_1(int ii)
        {
            OutputLine("add_1 is "+ ii.ToString());
        }

        void add_2(int ii)
        {
            OutputLine("add_2 is " + ii.ToString());
        }


        void doit()
        {
            deletest mydel = new deletest(add_1);
            mydel += add_2;
            mydel(44);
        }


        public delegate int AddHandler(int a, int b);


       public   int adder(int a,int b)
        {
            Action ac = () =>
            {
               OutputLine("res is " + (a + b).ToString());
            };
            //ac.Invoke();
            Invoke(ac);
            
            return a + b;
        }

        void test_1()
        {         
           AddHandler handler = new AddHandler(adder);
            //异步操作接口(注意BeginInvoke方法的不同！)
            IAsyncResult result = handler.BeginInvoke(1, 2, new AsyncCallback(cbfunc), "AsycState:OK");
            Console.WriteLine("继续做别的事情。。。");
            //Thread.Sleep(10000);
            OutputLine("end");
            //Console.ReadKey();
        }
        public  void cbfunc(IAsyncResult result)
        {
            //result 是“加法类.Add()方法”的返回值
            //AsyncResult 是IAsyncResult接口的一个实现类，空间：System.Runtime.Remoting.Messaging
            //AsyncDelegate 属性可以强制转换为用户定义的委托的实际类。
            AddHandler handler = (AddHandler)((AsyncResult)result).AsyncDelegate;
            //Console.WriteLine(handler.EndInvoke(result));
            //Console.WriteLine(result.AsyncState);
            Action ac = () =>
            {
                OutputLine("hh is "+ handler.EndInvoke(result).ToString());
                OutputLine((string)result.AsyncState);
            };
            Invoke(ac);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //test_1();
            //mytest();
            appconfigtest();
        }


        void appconfigtest()
        {
            //for(int ii = 0;ii<ConfigurationManager.ConnectionStrings.Count;ii++)
            //{
            //    string name = ConfigurationManager.ConnectionStrings[ii].Name;
            //    string str = ConfigurationManager.ConnectionStrings[ii].ConnectionString;
            //     OutputLine(name+" "+ str);
            //    OutputLine("over"); ;
            //}


            string[] keys = ConfigurationManager.AppSettings.AllKeys;
            foreach(string Key in keys)
            {
                OutputLine("key:"+Key + ", Value:"+ConfigurationManager.AppSettings[Key]);
            }

        }


        public delegate string delegateexample(int a,int b);


        public string myadd(int a,int b)
        {

            for(int ii = 0;ii< 6; ii ++)
            {
                OutputLine("Cycle "+ ii.ToString());
                Thread.Sleep(1000);
            }
            return (a + b).ToString();
        }

        public void mytest()
        {
            delegateexample mydeletest = myadd;
            IAsyncResult res =  mydeletest.BeginInvoke(1,4, new AsyncCallback(cb), mydeletest);

            //while(res.IsCompleted == false)
            //{
            //    OutputLine("wait of end");
            //    Thread.Sleep(500);
            //}

            //string ss = mydeletest.EndInvoke(res);
            //OutputLine("end invoke is "+ss);
        }

        public void cb(IAsyncResult ia)
        {

            delegateexample tmp = ia.AsyncState as delegateexample;
            string res = tmp.EndInvoke(ia);
            OutputLine("res is cb" + res);
        }


    }
}
