using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfence
{
   public abstract class MyClass
    {
        //声明属性
        private string id = "";
        private string name = "";

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        //定义抽象方法用来输出对象
        public abstract void ShowInfo();
        
    }
    public class DriveClass : MyClass //继承抽象类
    {
        public override void ShowInfo()
        {
            Console.WriteLine(Id+" "+Name);
        }

    }
}
