using karatsuba.Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karatsuba.Logica.Contextos
{
    public class ContextoKaratsuba
    {
        private IMultiplicacionKaratsuba _Contexto;

        public ContextoKaratsuba(IMultiplicacionKaratsuba contexto)
        {
            _Contexto = contexto;
        }

        public string Multiplicar(string primerValor, string segundoValor)
        {
            return _Contexto.Multiplicar(primerValor,segundoValor);
        }

    }
}
