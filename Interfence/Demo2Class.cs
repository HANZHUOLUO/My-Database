using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfence
{
   public abstract class Demo2Class
    {
        private Double a;
        private Double b;
        public Double A { get => a; set => a = value; }
        public Double B { get => b; set => b = value; }
        public abstract Double Mj();
    }
    public class Demo2M:Demo2Class
    {
        public override double Mj()
        {
            return A * B;
        }
    }
}
