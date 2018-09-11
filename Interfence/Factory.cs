using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfence
{
    public interface IGenericlnterface<T>
    {
        T Createlnstance();
    }
   public class Factory<T,TI> : IGenericlnterface<TI> where T:TI,new() 
    {
        public TI Createlnstance()
        {
            return new T();

        }
    }
}
