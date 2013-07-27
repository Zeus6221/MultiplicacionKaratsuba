using karatsuba.Logica.Manejadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Karatsuba.ServiciosWCF
{
    public class ServicioMultiplicacionKaratsuba : IServicioMultiplicacionKaratsuba
    {
        public string Multiplicar(string primerValor, string segundoValor)
        {
            ManejadorKaratsuba manejador = new ManejadorKaratsuba();
            return manejador.Multiplicar(primerValor, segundoValor);
        }
    }
}
