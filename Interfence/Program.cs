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
            Console.ReadLine();
        }
    }
}

