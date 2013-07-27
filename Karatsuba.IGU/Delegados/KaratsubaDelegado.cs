using Karatsuba.IGU.KaratsubaCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karatsuba.IGU.Delegados
{
    public class KaratsubaDelegado
    {
        public string Multiplicar(string primerValor, string segundoValor)
        {
            ServicioMultiplicacionKaratsubaClient cliente = new KaratsubaCliente.ServicioMultiplicacionKaratsubaClient();
            return cliente.Multiplicar(primerValor, segundoValor);
        }
    }
}
