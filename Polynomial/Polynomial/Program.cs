using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial polynomial0 = new Polynomial(1, 0) + new Polynomial(1, 1) + new Polynomial(2, 2);
            Console.WriteLine(polynomial0);
            Polynomial polynomial1 = new Polynomial(1, 0) - new Polynomial(1, 1) - new Polynomial(2, 2);
            Console.WriteLine(polynomial1);

            Polynomial result = polynomial0 * polynomial1;
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
