using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using karatsuba.Logica.Manejadores;

namespace Karatsuba.PruebasUnitarias
{
    [TestClass]
    public class PruebaMultiplicacionKaratsuba
    {
        [TestMethod]
        public void MultiplicaNumerosNegativos()
        {            
                ManejadorKaratsuba manejador = new ManejadorKaratsuba();
                Assert.AreEqual(manejador.Multiplicar("-4", "-5"), "20");
        }

        [TestMethod]
        public void MultiplicaNumerosGrandes()
        {
            ManejadorKaratsuba manejador = new ManejadorKaratsuba();

            string primerNumero = "10000000000000000000000000000000000000000000000000000000000000000000000000000000";
            string segundoNumero = "9000000000000000000000000000000000000000000000008000000000000000000000000000000";
            string respuestaEsperada = "90000000000000000000000000000000000000000000000080000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

            Assert.AreEqual(manejador.Multiplicar(primerNumero, segundoNumero), respuestaEsperada);
        }

        [TestMethod]
        public void MultiplicaNumerosCaracteresEspecialesEnPrimerCampo()
        {
            try
            {
                ManejadorKaratsuba manejador = new ManejadorKaratsuba();

                string primerValor = "90809&8970808";
                string segundoValor = "1000";

                manejador.Multiplicar(primerValor, segundoValor);
            }
            catch (Exception ex){
                Assert.AreEqual(ex.Message, "El primer valor introducido no es valido, verifique que sea un numero de menos de 500 digitos por favor");
            }               
        }

        [TestMethod]
        public void MultiplicaNumerosCaracteresEspecialesEnSegundoCampo()
        {
            try
            {
                ManejadorKaratsuba manejador = new ManejadorKaratsuba();

                string primerValor = "808";
                string segundoValor = "90809897&0808";

                manejador.Multiplicar(primerValor, segundoValor);

            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "El segundo valor introducido no es valido, verifique que sea un numero de menos de 500 digitos por favor");
            }
        }

        [TestMethod]
        public void MultiplicaNumerosPrimeroMasGrande()
        {            
                ManejadorKaratsuba manejador = new ManejadorKaratsuba();

                string primerValor = "10000000000000000000000000000000";
                string segundoValor = "3";
                string respuestaEsperada = "30000000000000000000000000000000";

                Assert.AreEqual(manejador.Multiplicar(primerValor, segundoValor), respuestaEsperada);
        }

        [TestMethod]
        public void MultiplicaNumerosSegundoMasGrande()
        {
            ManejadorKaratsuba manejador = new ManejadorKaratsuba();

            string primerValor = "3";
            string segundoValor = "10000000000000000000000000000000";
            string respuestaEsperada = "30000000000000000000000000000000";

            Assert.AreEqual(manejador.Multiplicar(primerValor, segundoValor), respuestaEsperada);
        }

        [TestMethod]
        public void MultiplicaNumerosPrimeroImpar()
        {
            ManejadorKaratsuba manejador = new ManejadorKaratsuba();

            string primerValor = "333";
            string segundoValor = "1000";
            string respuestaEsperada = "333000";

            Assert.AreEqual(manejador.Multiplicar(primerValor, segundoValor), respuestaEsperada);
        }

        [TestMethod]
        public void MultiplicaNumerosSegundoImpar()
        {
            ManejadorKaratsuba manejador = new ManejadorKaratsuba();

            string primerValor = "1000";
            string segundoValor = "333";
            string respuestaEsperada = "333000";

            Assert.AreEqual(manejador.Multiplicar(primerValor, segundoValor), respuestaEsperada);
        }
    }
}
