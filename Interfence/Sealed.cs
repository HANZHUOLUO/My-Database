using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfence
{
   public class MyClass1
    {
        public virtual void Method()
        {
            Console.WriteLine("基类中的虚方法");
        }
    }
  public sealed class Sealed :MyClass1
    {
        private string Idse="";
        private string Namese="";

        public string Idse1 { get => Idse; set => Idse = value; }
        public string Namese1 { get => Namese; set => Namese = value; }

        public sealed override void Method ()
        {
            base.Method();
            Console.WriteLine(Idse1+"\t"+Namese1);
        }
        
    }
}
