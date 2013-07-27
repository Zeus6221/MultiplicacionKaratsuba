using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Karatsuba.ServiciosWCF
{
    [ServiceContract]
    public interface IServicioMultiplicacionKaratsuba
    {
        [OperationContract]
        string Multiplicar(string primerValor, string segundoValor);

    }
}
