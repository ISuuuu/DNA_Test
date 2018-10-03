using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinEnum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public enum FactoryActualPaymentIDTS
        {
            BaseData,
            Detail,  //发单配比 
            File

        }

        private void button1_Click(object sender, EventArgs e)
        {
            object dataType = FactoryActualPaymentIDTS.File;
            FactoryActualPaymentIDTS rType = (FactoryActualPaymentIDTS)dataType;
            if (rType == FactoryActualPaymentIDTS.File)
            {
            }
        }
    }
}
