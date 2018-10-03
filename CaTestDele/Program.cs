using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaTestDele
{
    class Program
    {
        delegate object xnDelegate(object o1, object o2);
        //以委托作为参数，定义方法fun(),以求st1和st2中成绩较好的和较差的
        static Student fun(Student st1, Student st2, xnDelegate fxn)
        {
            return (Student)fxn(st1, st2);
        }
       
        static void Main(string[] args)
        {

            new Class1().testKim();
            Console.WriteLine("------------------");
            Student[] sts =                //创建学生数组
            {
                new Student ("zhangsan",90),
                new Student("lisi",100),
                new Student ("wangwu",189),
                new Student ("wanger",69),
            };
            //创建委托对象mx,关联静态方法student.max
            xnDelegate mx = new xnDelegate(Student.max);
            
            Student maxst;
            maxst = sts[0];
            sts[0].showInfo();
            //利用fun()方法求成绩最好的学生和成绩最差的学生
            for (int i = 1; i <= sts.Length - 1; i++)
            {
                
                sts[i].showInfo();
                maxst = fun(maxst, sts[i], mx);
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("成绩最好的学生:");
            maxst.showInfo();
            Console.ReadKey();
        }
    }
}

class Student
{
    private string name;      //姓名
    private double score;     // 成绩
    public Student(string name, double score)  //定义构造函数，初始化姓名和成绩
    {
        this.name = name;
        this.score = score;
    }
    public void showInfo()    //显示学生信息
    {
        Console.WriteLine("姓名：{0},\t成绩:{1}", name, score.ToString());
    }
    public static object max(object obj1, object obj2)   //求最大值（静态方法）
    {
        Student st1 = (Student)obj1;
        Student st2 = (Student)obj2;
        if (st1.score > st2.score) return st1;
        return st2;
    }  
    //申明委托类型，可以关联静态方法student.max()和student.min()

}

