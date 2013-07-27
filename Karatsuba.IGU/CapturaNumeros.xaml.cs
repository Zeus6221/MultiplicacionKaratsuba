using Karatsuba.IGU.Delegados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Karatsuba.IGU
{
    /// <summary>
    /// Lógica de interacción para CapturaNumeros.xaml
    /// </summary>
    public partial class CapturaNumeros : UserControl
    {
        KaratsubaDelegado delegadoKaratsuba;

        public CapturaNumeros()
        {
            delegadoKaratsuba = new KaratsubaDelegado();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string PrimerNumero = txtPrimerNumero.Text;
            string SegundoNumero = txtSegundoNumero.Text;

            string error = string.Empty;
            Regex r = new Regex(@"^\d+$");

            if (!r.IsMatch(PrimerNumero) && PrimerNumero[0] != '-')
            {
                error += " El primer valor introducido no es valido, verifique que sea un numero de menos de 500 digitos por favor/n";
            }

            if (!r.IsMatch(SegundoNumero) && SegundoNumero[0] != '-')
            {
                error += " El segundo valor introducido no es valido, verifique que sea un numero de menos de 500 digitos por favor/n";
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error);
            }
            else
            {
                try
                {
                    lblRespuesta.Text = delegadoKaratsuba.Multiplicar(PrimerNumero, SegundoNumero);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

        }
    }
}
