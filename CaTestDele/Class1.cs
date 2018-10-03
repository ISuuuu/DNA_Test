using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaTestDele
{
    delegate object myDelete(object s1, object s2);
    public class Class1
    {

        myDelete mydelete = new myDelete(stu.getMaxAge);
        stu fun(stu s1, stu s2, myDelete ss)
        {
            return (stu)ss(s1,s2);
        }        

        public void testKim()
        {
            stu[] sTuAll =
            {new stu("a1",89),
            new stu("a3",80),
            new stu("a2",60),
             };
            stu maxStu;
            maxStu = sTuAll[0];
            for (int k = 0; k < sTuAll.Length; k++)
            {
                sTuAll[k].showInfo();

                fun(maxStu, sTuAll[k], mydelete);
            }
            Console.WriteLine("age最大的是：");
            maxStu.showInfo();
        }

     





    }

    public class stu
    {
        public string name;
        public int age;
        public stu(string s1, int s2)
        {
            this.name = s1;
            this.age = s2;
        }
        public void showInfo()
        {
            Console.WriteLine(this.name+"_"+this.age);
        }

        public static stu getMaxAge(object stu1, object stu2)
        {
            stu s1 = (stu)stu1;
            stu s2 = (stu)stu2;
            if (s1.age > s2.age)
                return s1;
            return s2;
        }


    }
}
