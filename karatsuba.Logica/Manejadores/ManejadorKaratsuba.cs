using karatsuba.Logica.ClasesConcretas;
using karatsuba.Logica.Contextos;
using karatsuba.Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace karatsuba.Logica.Manejadores
{
    public class ManejadorKaratsuba : IMultiplicacionKaratsuba
    {
        public string Multiplicar(string primerValor, string segundoValor)
        {
            string errores = EntradaValida(primerValor, segundoValor);
            if (string.IsNullOrEmpty(errores))
            {
                int totalTamano = primerValor.Length + segundoValor.Length;
                IMultiplicacionKaratsuba karatsu = FabricaKaratsuba.Crear(totalTamano);
                ContextoKaratsuba contexto = new ContextoKaratsuba(karatsu);
                return contexto.Multiplicar(primerValor, segundoValor);

            }
            else
            {
                return errores.ToString();
            }
        }

        private string EntradaValida(string primerValor, string segundoValor)
        {
            StringBuilder errores = new StringBuilder();

            Regex r = new Regex(@"^\d+$");
            if (!r.IsMatch(primerValor) && primerValor[0] != '-')
            {
                errores.Append("El primer valor introducido no es valido, verifique que sea un numero de menos de 500 digitos por favor");
            }
            if (!r.IsMatch(segundoValor) && segundoValor[0]!='-')
            {
                errores.Append("El segundo valor introducido no es valido, verifique que sea un numero de menos de 500 digitos por favor");
            }
            if (errores.Length > 0)
            {
                return errores.ToString();
            }
            return null;
        }
    }
}
