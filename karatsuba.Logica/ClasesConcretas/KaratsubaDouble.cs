using karatsuba.Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karatsuba.Logica.ClasesConcretas
{
    public enum Mitad
    {
        Superior,
        Inferior
    }

    public class KaratsubaDouble : IMultiplicacionKaratsuba
    {
        #region METODOS PUBLICOS 

        public string Multiplicar(string primerValor, string segundoValor)
        {
            return Multiplicar(double.Parse(primerValor), double.Parse(segundoValor)).ToString();
        }

        #endregion

        #region METODOS PRIVADOS

        private double Multiplicar(double primero, double segundo)
        {
            if (primero < 10 || segundo < 10)
                return primero * segundo;

            double potencia = CalcularPotencia(primero, segundo);

            double x1 = ObtenerMitad(primero, potencia, Mitad.Superior);
            double y1 = ObtenerMitad(segundo, potencia, Mitad.Superior);


            double x0 = ObtenerMitad(primero, potencia, Mitad.Inferior);
            double y0 = ObtenerMitad(segundo, potencia, Mitad.Inferior);


            //Supongamos z2 = x1y1
            double z2 = Multiplicar(x1, y1);

            //Supongamos z0 = x0y0
            double z0 = Multiplicar(x0, y0);

            //Supongamos z1 = (x1 + x0)(y1 + y0) − z2 − z0
            double z1 = (x1 + x0) * (y1 + y0) - z2 - z0;

            // z2 · B2m + z1 · Bm + z0

            return (z2 * ObtenerBm(potencia, 2)) + (z1 * ObtenerBm(potencia)) + z0;
        }

        private double ObtenerBm(double potencia, int p = 1)
        {
            potencia *= p;
            return Math.Pow(10, potencia);
        }

        private double ObtenerMitad(double primero, double potencia, Mitad mitad)
        {
            double residuo = primero % (Math.Pow(10, potencia));

            if (mitad == Mitad.Superior)
            {
                var respuesta = primero - residuo;
                respuesta /= Math.Pow(10, potencia);
                return respuesta;
            }

            return primero % (Math.Pow(10, potencia));
        }

        private double CalcularPotencia(double primero, double segundo)
        {
            double mayor = primero > segundo ? primero : segundo;
            double palabra = (mayor.ToString().Length) / 2.0;

            double potencia = Math.Ceiling(palabra);

            return potencia;

        }

        #endregion
    }
}
