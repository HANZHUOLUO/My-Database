using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfence
{
    interface ICter 
    {
        string Id
        {
            get;
            set;
        }
        string Name
        {
            get;
            set;
        }
         void Show();
    }
}
