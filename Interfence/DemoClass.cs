using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfence
{
    interface IdemoClass
    {
        Decimal A { get; set; }
        Decimal B { get; set; }
        Decimal Mj();


    }
    class DemoOne:IdemoClass
    {
        private Decimal a = 0;
        private Decimal b = 0;

        public decimal A { get => a; set => a = value; }
        public decimal B { get => b; set => b = value; }
        public Decimal Mj()
        {
            return A * B;
        }
    }
}
