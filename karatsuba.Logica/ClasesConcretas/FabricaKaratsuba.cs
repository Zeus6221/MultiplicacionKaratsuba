using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karatsuba.Logica.ClasesConcretas
{
    public class FabricaKaratsuba
    {
        /// <summary>
        /// retorna una ejemplificacion correspondiente a una clase concreta 
        /// para ejecutar el algoritmo de multiplicacion, dependiendo del tamano
        /// que tienen los numeros a multiplicar.
        /// </summary>
        /// <param name="totalTamano"></param>
        /// <returns></returns>
        public static Interfaces.IMultiplicacionKaratsuba Crear(int totalTamano)
        {
            if (totalTamano > 13)
            {
                //para valores resultantes que podrian exceder el espacio de 
                //una primitiva.
                return new KaratsubaListas();
            }
            else
            {
                //para valores que pueden ser multiplicados sin riesgo de un 
                //desbordamiento.
                return new KaratsubaDouble();
            }
        }
    }
}
