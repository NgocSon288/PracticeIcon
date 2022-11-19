using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icon.Basic._1.StaticMethodOverloading
{
    public class Person
    {
        #region Execute

        public static void RunExample()
        {
            SayHello();
            SayHello("Son");
            SayHello("Vinh", 2);
        }

        #endregion

        public static void SayHello()
        {
            Console.WriteLine("Hello nothing!");
        }

        public static void SayHello(string name)
        {
            Console.WriteLine($"Hello {name}!");
        }

        public static void SayHello(string name, int old)
        {
            Console.WriteLine($"Hello {name}!, I am {old} years old");
        }
    }
}
