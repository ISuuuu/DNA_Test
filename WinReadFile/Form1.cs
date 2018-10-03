using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinReadFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path = @"C:\Users\zhang\Desktop\new1";
        string pathReal = Application.StartupPath;

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            try
            {
                CopyFile(path);
                textBox1.Text = "完成";
            }
            catch (Exception ew)
            {
                textBox1.Text = ew.Message;
            }
        }

        void CopyFile(string path)
        {
            if (!Directory.Exists(path))
                return;
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            int i = 0;
            foreach (FileInfo fi in files)
            {
                i++;
                if (fi.Extension.ToLower() == ".xlsx"&&!fi.FullName.Contains("~$")) //~$缓存文件
                {
                    File.Copy(fi.FullName, pathReal + "\\"+i.ToString()+".xlsx");
                }
            }



        }


        void test()
        {
            //为测试
            //在FileStream fs = File.Create(path3);
            //后面加一句，
            //fs.Close();
            //由于调用File.Create(path3); 
            //使得文件“d:\copy\file.txt”被使用而锁定，而fs.Close(); 则会释放该文件，使得拷贝可以执行。
        }
    }
}
