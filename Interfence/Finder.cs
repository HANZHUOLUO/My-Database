using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfence
{
    class Finder
    {

        public static int Find<T>(T[] items,T item)///创建一个泛型方法
        {
            for (int i=0;i<items.Length;i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
