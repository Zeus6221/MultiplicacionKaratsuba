using karatsuba.Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karatsuba.Logica.ClasesConcretas
{
    public class KaratsubaListas : IMultiplicacionKaratsuba
    {
        #region METODOS PUBLICOS

        public string Multiplicar(string primero, string segundo)
        {
            bool Esnegativo = ObtenerSignoResultante(primero, segundo);       

            List<int> respuesta = Multiplicar(ConvertirAListaEnteros(primero), ConvertirAListaEnteros(segundo));
            StringBuilder sb = new StringBuilder();
            int indice = 0;

            while (indice < respuesta.Count - 1 && respuesta[indice] == 0)
            {
                indice++;
            }

            for (int posicion = indice; posicion < respuesta.Count; posicion++)
            {
                sb.Append(respuesta[posicion]);
            }

            if (Esnegativo)
            {
                sb.Insert(0, "-");
            }
            

            return sb.ToString();
        }

        private bool ObtenerSignoResultante(string primero, string segundo)
        {
            StringBuilder signos = new StringBuilder();

            if (primero[0] == '-')
            {
                signos.Append('-');                
            }

            if (segundo[0] == '-')
            {
                signos.Append('-');                
            }

            return signos.Length == 1;
        }

        #endregion

        #region METODOS PRIVADOS

        private List<int> ConvertirAListaEnteros(string primero)
        {
            List<int> lista = new List<int>();
            if (primero[0] == '-')
            {
                primero = primero.Substring(1, (primero.Length - 1));
            }

            for (int posicion = 0; posicion < primero.Length; posicion++)
            {
                lista.Add(int.Parse(primero[posicion].ToString()));
            }
            return lista;
        }

        private List<int> Multiplicar(List<int> primero, List<int> segundo)
        {
            IgualaArreglos(primero, segundo);

            if (primero.Count < 2 || segundo.Count < 2)
                return Multiplica(primero, segundo);

            double potencia = CalcularPotencia(primero.Count);

            List<int> x1 = ObtenerMitad(primero, potencia, Mitad.Superior);
            List<int> y1 = ObtenerMitad(segundo, potencia, Mitad.Superior);

            List<int> x0 = ObtenerMitad(primero, potencia, Mitad.Inferior);
            List<int> y0 = ObtenerMitad(segundo, potencia, Mitad.Inferior);

            // z2 = x1y1
            List<int> z2 = Multiplicar(x1, y1);

            // z0 = x0y0
            List<int> z0 = Multiplicar(x0, y0);

            // z1 = (x1 + x0)(y1 + y0) − z2 − z0

            List<int> x1x0 = Suma(x1, x0);
            List<int> y1y0 = Suma(y1, y0);
            List<int> libre = Suma(z2, z0);

            List<int> z1 = Resta(Multiplicar(x1x0, y1y0), libre);

            List<int> termino = Suma(ObtenerTermino(z2, potencia, 2), ObtenerTermino(z1, potencia));

            return Suma(termino, z0);
        }

        private void IgualaArreglos(List<int> primero, List<int> segundo)
        {
            if (primero.Count < segundo.Count)
            {
                Adicionar(primero, (segundo.Count - primero.Count));
            }

            else
            {
                Adicionar(segundo, (primero.Count - segundo.Count));
            }
        }

        private void Adicionar(List<int> list, int p)
        {
            for (int i = 0; i < p; i++)
            {
                list.Insert(0, 0);
            }
        }

        private List<int> Multiplica(List<int> list, List<int> libre)
        {
            IgualaArreglos(list, libre);
            List<int> respuesta = new List<int>();
            int Count = list.Count - 1;

            int inicio = 0;
            int auxiliar = 0;
            Operador op = new Operador();
            foreach (int numero in list)
            {
                op.PrimerNumero = list[Count - inicio];
                foreach (int valor in libre)
                {
                    op.SegundoNumero = libre[Count - auxiliar];
                    op.RealizaOperacion(Operacion.Multiplicacion);

                    respuesta.Insert(0, op.Resultado);
                    auxiliar++;
                }
                auxiliar = 0;
                inicio++;
            }

            if (op.Acarreo != 0)
            {
                respuesta.Insert(0, op.Acarreo);
            }

            return respuesta;
        }

        private double CalcularPotencia(int p)
        {
            return Math.Ceiling(p / 2.0);
        }

        private List<int> ObtenerMitad(List<int> list, double potencia, Mitad mitad)
        {
            List<int> resultado = new List<int>();
            double inicio = 0;
            double fin = 0;

            if (mitad == Mitad.Superior)
            {
                fin = list.Count - potencia;
            }
            else
            {
                inicio = list.Count - potencia;
                fin = list.Count;
            }

            for (double posicion = inicio; posicion < fin; posicion++)
            {
                resultado.Add(list[(int)posicion]);
            }
            return resultado;
        }

        private List<int> Suma(List<int> list, List<int> libre)
        {
            Operador op = new Operador();
            List<int> respuesta = RalizaOperacion(list, libre, Operacion.Suma, op);
            if (op.Acarreo != 0)
            {
                respuesta.Insert(0, op.Acarreo);
            }
            return respuesta;
        }

        private List<int> RalizaOperacion(List<int> list, List<int> libre, Operacion operacion, Operador op)
        {

            IgualaArreglos(list, libre);
            List<int> respuesta = new List<int>();
            int Count = libre.Count - 1;

            for (int inicio = 0; inicio < list.Count; inicio++)
            {

                op.PrimerNumero = list[Count - inicio];
                op.SegundoNumero = libre[Count - inicio];
                op.RealizaOperacion(operacion);

                respuesta.Insert(0, op.Resultado);
            }

            return respuesta;
        }

        private List<int> Resta(List<int> list, List<int> libre)
        {
            Operador op = new Operador();
            return RalizaOperacion(list, libre, Operacion.Resta, op);
        }

        private List<int> ObtenerTermino(List<int> z2, double potencia, int p = 1)
        {
            double exponente = potencia * p;

            List<int> respuesta = new List<int>();
            foreach (int numero in z2)
            {
                respuesta.Add(numero);
            }

            for (double valor = 0; valor < exponente; valor++)
            {
                respuesta.Add(0);
            }

            return respuesta;
        }

        #endregion
    }
}
