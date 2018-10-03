using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nes", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("time", typeof(DateTime));
            dt.Rows.Add(new object[] { "1231","zhangsan",DateTime.Now.AddDays(+10) });

            DataRow dr = dt.Rows[0];

          //  UP.Win.BaseForm.DataEditHelper.SetDataToCtl(dr, this.Controls); //控件名称长度至少为5
            ;

            foreach (Control c in this.Controls)
            {
                string ctlTypeName = c.GetType().Name;
                string sName = c.Name.Trim();

                if (ctlTypeName.Equals("DateTimePicker") || ctlTypeName.Equals("DateTimePickerEx"))
                    sName = sName.Substring(5, sName.Length - 5);  // 日期类型的开头为5个短名称
                else
                    sName = sName.Substring(3, sName.Length - 3);

                object val = dr[sName];
                switch (ctlTypeName)
                {
                    case "Label":
                        break;                   
                  
                 
                    case "AutoCompleteComboBox":
                        c.Text = c.ToString();
                        break;

                    case "DateTimePicker":
                    case "DateTimePickerEx":
                        //时间控件的开始是dTime 所以需要再截断2
                        //sName = sName.Substring(2,sName.Length-2); 
                        sName = sName.Substring(2, sName.Length - 2);

                        DateTimePicker timePick = c as DateTimePicker;
                        if (val == null || val.ToString().Length == 0)
                            timePick.Checked = false;
                        else
                        {
                            timePick.Checked = true;
                            //ctl.Text = val.ToString();
                            timePick.Value = UP.Utils.UPConvert.ToDateTime(val);
                        }

                        break;
                
                    default:
                        //UP.Data.IFace.IObjectChildEditCtl childCtl = ctl as UP.Data.IFace.IObjectChildEditCtl;
                        //if (childCtl != null && childCtl.BindMultiField)
                        //    doFillControlText(drData, ctl.Controls);
                        break;
                }

            }


        

        }
    }
}
