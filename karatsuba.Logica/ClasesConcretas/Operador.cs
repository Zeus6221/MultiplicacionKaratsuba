using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karatsuba.Logica.ClasesConcretas
{
    public enum Operacion
    {
        Suma,
        Resta,
        Multiplicacion
    }

    public class Operador
    {
        #region ATRIBUTOS

        int primerNumero = 0;

        int segundoNumero = 0;

        int acarreo = 0;

        int resultado = 0;

        #endregion
        
        #region PROPIEDADES

        public int Acarreo
        {
            get { return acarreo; }
            set { acarreo = value; }
        }

        public int PrimerNumero
        {
            get { return primerNumero; }
            set { primerNumero = value; }
        }

        public int SegundoNumero
        {
            get { return segundoNumero; }
            set { segundoNumero = value; }
        }

        #endregion
        
        #region CONSTRUCTOR

        public int Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        #endregion

        #region METODOS PUBLICOS

        public void RealizaOperacion(Operacion op)
        {
            if (op == Operacion.Suma)
            {
                resultado = primerNumero + segundoNumero + acarreo;

                if (resultado > 9)
                {
                    acarreo = resultado / 10;
                    resultado = resultado % 10;
                }
                else
                {
                    acarreo = 0;
                }
            }

            else if (op == Operacion.Resta)
            {
                primerNumero -= acarreo;
                if (primerNumero < segundoNumero)
                {
                    primerNumero += 10;
                    acarreo = 1;
                }
                else
                {
                    acarreo = 0;
                }
                resultado = primerNumero - segundoNumero;
            }
            else
            {
                resultado = (primerNumero * segundoNumero) + acarreo;
                if (resultado > 9)
                {
                    acarreo = resultado / 10;
                    resultado = resultado % 10;
                }
                else
                {
                    acarreo = 0;
                }
            }

        }

        #endregion        
    }
}
