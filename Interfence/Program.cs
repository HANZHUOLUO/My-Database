using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interfence
{
    class Program: ICter, Ipeople,ITeacher,IStudent,interface1,interface2
    {
        string id = "";
        string name = "";

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }


        public void Show()
        {
            Console.WriteLine("编号\t 姓名");
            Console.WriteLine(id+"\t"+Name);
        }

        string names = "";
        string sexs = "";
        public string Names { get => names; set => names = value; }
        public string Sexs { get => sexs; set => sexs = value; }
        public void Teach()
        {
            Console.WriteLine(names + " "+ sexs + " 教师");
        }
        public void Study()
        {
            Console.WriteLine(names + " "+ sexs + " 学生");
        }

        int interface1.Add()
        {
            int x = 1;
            int y = 2;
            return x + y;
        }
        int interface2.Add()
        {
            int x = 2;
            int y = 3;
            return x + y;
        }
        static void Main(string[] args)
        {
            DriveClass drive = new DriveClass();//实例化派生类
            MyClass myClass = drive;//使用派生类对象实例化抽象类
            drive.Id = "韩";
            drive.Name = " 卓";
            drive.ShowInfo();

            Program program = new Program();
            ICter cter = program;
            cter.Id = "TM";
            cter.Name = "C#";
            cter.Show();
            
            ITeacher teacher = program;
            teacher.Names = "TM";
            teacher.Sexs = "男";
            teacher.Teach();
            IStudent student = program;
            student.Names = "C#";
            student.Sexs = "男";
            student.Study();
            interface1 interface1 = program;
            interface2 interface2 = program;
            Console.WriteLine(interface1.Add());
            Console.WriteLine(interface2.Add());
            Sealed se = new Sealed();
            se.Idse1 = "001";
            se.Namese1 = "tm";
            se.Method();
            ///Demo1
            DemoOne demo = new DemoOne();
            demo.A = 7;
            demo.B = 8;
            Console.WriteLine("面积是："+ demo.Mj());
            //Demo2
            Demo2M demo21 = new Demo2M();
            Demo2Class demo2 = demo21;
            demo21.A = 5;
            demo21.B = 3.14;
            Console.WriteLine("圆的面积是："+demo21.Mj());
            //Demo3
            Demo3Class demo3 = new Demo3Class();
            Console.WriteLine("请输入用户名：");
           demo3.Name= Console.ReadLine();
            Console.WriteLine("请输入密码：");
            demo3.Psd= Console.ReadLine();
            Console.WriteLine("用户名："+demo3.Name+"\t"+"密码："+demo3.Psd);

            IGenericlnterface<System.ComponentModel.IListSource> Factoy = new Factory<System.Data.DataTable, System.ComponentModel.IListSource>();
            Console.WriteLine(Factoy.Createlnstance().GetType().ToString());
            int i = Finder.Find<int>(new int[] { 1,2,3,4,5,6,7,8,9},6);
            Console.WriteLine("6 在数组中的位置："+i.ToString());
            ///泛型数组
            List<int> MyList = new List<int>();
            for (int j=0;j<10;j++)
            {
                MyList.Add(j);
            }
            foreach (int a in MyList)
            {
                Console.WriteLine(a);
            }
            Fclass1<int> fclass1 = new Fclass1<int>();
            Fclass2<int> fclass2 = new Fclass2<int>();
             Console.ReadLine();
        }
    }


    class Fclass1<T>
    {
        public Fclass1()
        {
            Console.WriteLine("第一个泛型方法");
        }
    }
    class Fclass2<T> : Fclass1<T>
    {
        public Fclass2()
        {
            Console.WriteLine("第二个泛型方法");

        }

    }
}

