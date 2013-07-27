using karatsuba.Logica.Manejadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karatsuba.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite el primer numero");
            string primerNumero = Console.ReadLine().Trim();


            Console.WriteLine("Digite el segundo numero");
            string segundoNumero = Console.ReadLine().Trim();

            ManejadorKaratsuba manejador = new ManejadorKaratsuba();

            string respuesta = string.Format("El resultado es {0}", manejador.Multiplicar(primerNumero,segundoNumero));
            Console.WriteLine(respuesta);
            Console.Read();

        }
    }
}
