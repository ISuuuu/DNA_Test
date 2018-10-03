using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTestTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object a1 = 2;
            object a2 = 2;
            textBox1.Text = "---------------" + Environment.NewLine;
            if (a1 == a2)
                textBox1.Text += "a1==a2"+Environment.NewLine;

            if (a1.Equals(a2))
                textBox1.Text += "a1.Equals(a2)";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Thread(Test) { IsBackground = false }.Start();
            ThreadPool.QueueUserWorkItem(o => Test());
            Task.Run((Action)Test);
            Console.WriteLine("Main Thread");
        }

        static void Test()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello World");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "10*11*112";
            int a = s.IndexOf('*');
            string[] arr = s.Split('*');
            int aa = (Convert.ToInt16(arr[0]) * Convert.ToInt16(arr[1]) * Convert.ToInt16(arr[2]));
            decimal ss = Convert.ToDecimal(a / 1000000);

           
        }
    }
}
