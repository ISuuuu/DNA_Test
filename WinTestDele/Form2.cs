using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTestDele
{
    public delegate void MyDelegate(string Item1, string Item2);//委托实质上是一个类

    public partial class Form2 : Form
    {
        public MyDelegate myDelegate;//声明一个委托的对象
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myDelegate(this.textBox1.Text, this.textBox2.Text);
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
