using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDevpressGridControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dateTimePicker1.Value = System.DateTime.Now.AddDays(+2);
            this.gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int selectedHandle;
            selectedHandle = this.gridView1.GetSelectedRows()[0];
            MessageBox.Show(this.gridView1.GetRowCellValue(selectedHandle, "name").ToString());
        }

        string path ="";
        Image ia = null;

        private DataTable InitDt()
        {
            DataTable dt = new DataTable("个人简历");
            dt.Columns.Add("checked", typeof(bool));
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("sex", typeof(int));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("aihao", typeof(string));
            dt.Columns.Add("photo", typeof(Image));
            dt.Columns.Add("time", typeof(DateTime));
            dt.Rows.Add(new object[] {false, 1, "张三", 1, "东大街6号", "看书", ia,null });
            dt.Rows.Add(new object[] { true ,1, "王五", 0, "西大街2号", "上网,游戏", null, null });
            dt.Rows.Add(new object[] { true,1, "李四", 1, "南大街3号", "上网,逛街", null, null });
            dt.Rows.Add(new object[] { true, 1, "钱八", 0, "北大街5号", "上网,逛街,看书,游戏", null, null });
            dt.Rows.Add(new object[] { true, 1, "赵九", 1, "中大街1号", "看书,逛街,游戏", null, null });
            for (int s = 0; s < 30; s++)
            {
                dt.Rows.Add(new object[] { false, 1, "张三"+s.ToString(), 1, "东大街6号", "看书", null, null });

            }

            return dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // gridControl1.DataSource = InitDt();
            path = Application.StartupPath + "\\Image\\a.png";
            ia = Image.FromFile(path);

            DataTable dt = InitDt();
            foreach (DataRow dr in dt.Rows)
            {
                dr["time"] = this.dateTimePicker1.Value;
            }
            this.gridControl1.MainView = this.gridView1;
            gridControl1.DataSource = dt;
            this.gridView1.Columns["address"].OptionsColumn.AllowEdit = false;

           // this.gridView1.ActiveFilterString = " name like '%张三%'"; //增加过滤条件

            DataTable dv = this.gridControl1.DataSource as DataTable;
            foreach (DataRow dr in dv.Rows)
            {
                dr["aihao"] = "88888888";
            }
        }

        // 根据ID选中行，并将选中行显示在GridView最顶端

        protected void SelectRowByID(DataGridView dgv, string ID)

        {

            //根据GridView某字段的值获得行号

            DataRow[] rows = (dgv.DataSource as DataTable).Select("ID='" + ID + "'");

            if (rows.Length > 0)

            {

                int findRow = (dgv.DataSource as DataTable).Rows.IndexOf(rows[0]);

                dgv.ClearSelection();

                if (findRow != -1)

                {

                    dgv.FirstDisplayedScrollingRowIndex = findRow;//将此行滚动到GridView最项端

                }

                dgv.Rows[findRow].Selected = true;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = (this.gridView1.DataSource as DataView).Table;
            foreach (DataRow dr in dt.Rows)
            {
                object o = dr.RowState; //add
                dr[1] = 100;
                o = dr.RowState; //add
            }
            dt.AcceptChanges();  //dr.RowState==Unchanged
            foreach (DataRow dr in dt.Rows)
            {
                object o = dr.RowState; //
                dr[1] = 100;
                o = dr.RowState; //unchanged
            }

            if (dt.Rows[0][7] == System.DBNull.Value)
                textBox1.Text = "datatable.null value=System.dbNull.value";
            else
                textBox1.Text = "datatable.null value!=System.dbNull.value";


           // var a=from t in dt.AsEnumerable()

        }
    }
}
