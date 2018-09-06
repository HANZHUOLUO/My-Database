using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfence
{

    
        interface Ipeople
        {
            string Names
            {
                get;
                set;
            }
            string Sexs
            {
                get;
                set;
            }

        }
        interface ITeacher : Ipeople
        {

            void Teach();

        }
        interface IStudent : Ipeople
        {

            void Study();
        }


    
}
