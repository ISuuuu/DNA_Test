using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTabPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //

        void set()
        {
            foreach (TabPage loadPage in this.tabControl1.TabPages)
            {
                tabControl1.SelectedTab = loadPage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            set();
            textBox1.Text = this.dateTimePicker1.Value.Hour.ToString() +":"+ this.dateTimePicker1.Value.Minute.ToString()
               +":"+ this.dateTimePicker1.Value.Second.ToString();
            this.dateTimePicker1.Value = DateTime.Now.AddDays(+1);


            
        }
    }
}
