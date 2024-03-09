using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAdministrationAPI
{
    public static class FactoryPattern<K,T> where T:class,K,new()
    {
        // instantiate an object generically
        // generics enable the code to be stronglly typed
        // -> the code is checked at compile time
        public static K GetInstance()
        {
            K objK;
            objK = new T();
            return objK;
        }
    }
}
