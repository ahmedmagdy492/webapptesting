using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class MyMath
    {
        public int result = 0;

        public void Sum(int num1, int num2)
        {
            result = num1 + num2;
        }

        public void Div(int num1, int num2)
        {
            if(num2 == 0)
            {
                throw new DivideByZeroException("num2 cannot be 0");
            }
            result = num1 / num2;
        }
    }
    class Program
    {        
        static void Main(string[] args)
        {
        }
    }
}
