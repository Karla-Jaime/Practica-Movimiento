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
///Librerias para multiprocesamientos
using System.Threading; //Se agrego esta libreria para Threading
using System.Diagnostics; // Para el dispatcher y timers 


namespace PracticaMovimienot
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopwatch; //Toma el tiempo de ejecución del programa
        TimeSpan tiempoAnterior; //Timespan guarda rangos de tiempo


        public MainWindow()
        {
            InitializeComponent();
            elCanvas.Focus();

            stopwatch = new Stopwatch();
            stopwatch.Start();
            tiempoAnterior = stopwatch.Elapsed;

            //Se puede mandar como parametro a una función en C#
            //1..Establecer instrucciones
            ThreadStart threadStart = new ThreadStart(moverEnemigos);
            //2..Inicializar el Thread - Dar valores e instrucciones
            Thread threadMoverEnemigos = new Thread(threadStart);
            //3..Ejecutar el Thread
            threadMoverEnemigos.Start();
        }

        void moverEnemigos()
        {   //Invoke lleva de parametro una función
            while (true) { 
            Dispatcher.Invoke(
                () => //Se creo una función nueva dentro de otro la => es para indicar que es otra función
                {
                    var tiempoActuali = stopwatch.Elapsed;
                    var deltaTime = tiempoActuali - tiempoAnterior;

                        double leftCarroActual = Canvas.GetLeft(imgCarro);
                                                                   // se mueve 120 pixeles por segundo
                        Canvas.SetLeft(imgCarro, leftCarroActual - (120* deltaTime.TotalSeconds));
                    if (Canvas.GetLeft(imgCarro) <= -100)
                    {
                        Canvas.SetLeft(imgCarro, 800);
                    }
                    tiempoAnterior = tiempoActuali;
                }
                );
            }
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
                double bottomTigreActual = Canvas.GetTop(imgTigre);
                Canvas.SetTop(imgTigre, bottomTigreActual + 15);
            }

            if (e.Key == Key.Left)
            {
                double LeftTigreActual = Canvas.GetLeft(imgTigre);
                Canvas.SetLeft(imgTigre, LeftTigreActual - 15);
            }

            if (e.Key == Key.Right)
            {
                double RightTigreActual = Canvas.GetLeft(imgTigre);
                Canvas.SetLeft(imgTigre, RightTigreActual + 15);
            }
        }
    }
}
