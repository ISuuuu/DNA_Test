using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinLinq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            int[] num = { 2, 4, 11, 18 };
            IEnumerable<int> lowNum =
                from n in num
                where n < 10
                select n;

            DataTable dt = InitDt();
            IEnumerable<DataRow> ac = from a in dt.AsEnumerable()
                                     // .GroupBy(p=>p.Field<int>("sex")==1)

                                      select a;

           
            foreach (var x in ac)
            {
                //Console.WriteLine(x);
                DataRow dr = (DataRow)x;
                //txtR.Text = dr["name"].ToString();
            }
            string tmp = "";
            var rows = dt.AsEnumerable()
                        //.GroupBy(p => p.Field<int>("sex"))
                        .Where(p=>p.Field<string>("name") =="张三" )
                        .OrderBy(p => p.Field<int>("sex"))
                       .Select(p => new
                       {
                           tmp = p.Field<string>("address")
                       });


            foreach (var x in rows)
            {
                txtR.Text = x.tmp+Environment.NewLine;
            }

            var rows2 = from a in dt.AsEnumerable()
                        orderby a.Field<int>("sex")
                        select a;

            foreach (var x in rows2)
            {
                DataRow dr = (DataRow)x;
                txtR.Text = dr["address"].ToString();
            }
            Console.WriteLine("---------------------------------------");

            //group by
            var q = from p in dt.AsEnumerable()
                    group p by p.Field<int>("sex") into g
                    select new
                    {
                        id = g.Key,                        
                        name = g
                    };
            foreach (var item in q)
            {
                Console.WriteLine(item.id);
                foreach (var p in item.name)
                {
                    Console.WriteLine(p.Field<string>("name"));
                }
            }




        }

        private DataTable InitDt()
        {
            DataTable dt = new DataTable("个人简历");
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("sex", typeof(int));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("aihao", typeof(string));
            dt.Columns.Add("photo", typeof(string));
            dt.Rows.Add(new object[] { 1, "张三", 1, "东大街6号", "看书", "" });
            dt.Rows.Add(new object[] { 1, "王五", 0, "西大街2号", "上网,游戏", "" });
            dt.Rows.Add(new object[] { 1, "李四", 1, "南大街3号", "上网,逛街", "" });
            dt.Rows.Add(new object[] { 1, "钱八", 0, "北大街5号", "上网,逛街,看书,游戏", "" });
            dt.Rows.Add(new object[] { 1, "赵九", 1, "中大街1号", "看书,逛街,游戏", "" });
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Expr(txtR.Text);


        }
        public static string Expr(string pStr)
        {
            string strtmp = pStr.Replace("''", "'");
            return strtmp.Replace("'", "''");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal dd = 0.00M;
            textBox1.Text = dd == 0 ? "是的" : "NO";


        }
    }
}
