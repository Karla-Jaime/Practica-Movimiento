using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace PracticaMovimienot
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            elCanvas.Focus();
        }

        private void elCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                double topTigreActual = Canvas.GetTop(imgTigre);
                //Primero el elemento a mover, Luego los valores a mover
                Canvas.SetTop(imgTigre, topTigreActual - 15);
            }
            if (e.Key == Key.Down)
            {
                double bottomTigreActual = Canvas.GetBottom(imgTigre);
                Canvas.SetBottom(imgTigre, bottomTigreActual + 15);
            }
        }

        private void elCanvas_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
