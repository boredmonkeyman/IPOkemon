using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Principal;
using System.Threading.Tasks;
using Windows.Devices.Radios;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace CharmanderBueno
{
    public class AtaqueEventArgs : EventArgs
    {
        public int CantidadDanio { get; set; }

        public AtaqueEventArgs(int cantidadDanio)
        {
            CantidadDanio = cantidadDanio;
        }
    }
    public sealed partial class CharmanderFJDR : UserControl, iPokemon

    {

        public event EventHandler CuracionRealizada;
        public event EventHandler EscudoActivado;
        public const int VIDA_CRITICA = 25;
        public bool componentesCargados = false;
        DispatcherTimer dtTimeVida; //temporizador
        DispatcherTimer dtTimeEnergia;

        public double Vida
        {
            get { return this.pb_vida.Value; }
            set { this.pb_vida.Value = value; }
        }
        public double Energia
        {
            get { return this.pb_energia.Value; }
            set { this.pb_energia.Value = value; }
        }
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string categoría;
        public string Categoría
        {
            get { return categoría; }
            set { categoría = value; }
        }
        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private double altura;
        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }
        private double peso;
        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        private string evolucion;
        public string Evolucion
        {
            get { return evolucion; }
            set { evolucion = value; }
        }
        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public CharmanderFJDR()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            componentesCargados = true;
            movimientoCola();
            Vida = 50;
            Energia = 50;
            Nombre = "Charmander";
            Categoría = "Lagartija";
            Tipo = "Fuego";
            Altura = 0.6;
            Peso = 8.5;
            Evolucion = "Charmeleon";
            Descripcion = "Charmander es un pequeño monstruo bípedo parecido a un lagarto. Sus características de fuego son resaltadas por su color de piel anaranjado y su cola, cuya punta está envuelta en llamas.";
        }
        private void OnCuracionRealizada()
        {
            CuracionRealizada?.Invoke(this, EventArgs.Empty);
        }
        private void OnEscudoActivado()
        {
            EscudoActivado?.Invoke(this, EventArgs.Empty);
        }
        private void movimientoCola()
        {
            Storyboard sb = (Storyboard)this.Resources["sbMovimientoCola"];
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
        }
        public void verFondo(bool verFondo)
        {
            if (!verFondo)
            {
                this.imgFondo.Visibility = Visibility.Collapsed;
            }
            else
                this.imgFondo.Visibility = Visibility.Visible;
        }
        public void verNombre(bool verNombre)
        {
            if (!verNombre)
            {
                this.txtBNombre.Visibility = Visibility.Collapsed;
            }
            else
                this.txtBNombre.Visibility = Visibility.Visible;
        }

        private void increaseHealth(object sender, object e)
        {
            pb_vida.Value += 0.2;
            if (pb_vida.Value >= 100)
            {
                dtTimeVida.Stop();
                imgPocionVida.Opacity = 0; // Oculta la imagen de la poción de vida
            }
        }
        private void incrementarEnergia(object sender, object e)
        {
            pb_energia.Value += 0.2;
            if (pb_energia.Value >= 100)
            {
                dtTimeEnergia.Stop();
                imgPocionEnergia.Opacity = 0; // Oculta la imagen de la poción de energía
            }
        }
        private void btnEstadoEscudo_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.ptPupilaIzq.Resources["ojoIzqAzulKey"];
            Storyboard sb2 = (Storyboard)this.ptPupilaDer.Resources["ojoDerAzulKey"];
            sb.Begin();
            sb2.Begin();
        }


        private void pbVida_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (componentesCargados)
            {
                Console.WriteLine("Vida: " + pb_vida.Value);
                if (pb_vida.Value <= VIDA_CRITICA)
                    cambiarVisibilidad(imgFuegoCola, false);
                else
                    cambiarVisibilidad(imgFuegoCola, true);
            }

        }

        private void cambiarVisibilidad(Image imagen, bool visible)
        {
            Visibility vb = Visibility.Visible;
            if (!visible)
                vb = Visibility.Collapsed;
            try
            {
                imagen.Visibility = vb;

            }
            catch (Exception)
            {
                //Se igonora la excepción
            }


        }



        public void verFilaVida(object sender, object e)
        {

            pb_vida.Value += 0.2;
            if (pb_vida.Value >= 100)
            {
                dtTimeVida.Stop();
                imgPocionVida.Opacity = 0; // Oculta la imagen de la poción de vida
            }
        }

        public void verFilaEnergia(bool ver)
        {

            pb_energia.Value += 0.2;
            if (pb_energia.Value >= 100)
            {
                dtTimeEnergia.Stop();
                imgPocionEnergia.Opacity = 0; // Oculta la imagen de la poción de energía
            }
        }

        public void verPocionVida(object sender, PointerRoutedEventArgs e)
        {

            dtTimeVida = new DispatcherTimer();
            dtTimeVida.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeVida.Tick += increaseHealth;
            dtTimeVida.Start();
            imgPocionVida.Opacity = 0.5;
        }

        public void verPocionEnergia(object sender, PointerRoutedEventArgs e)
        {

            dtTimeEnergia = new DispatcherTimer();
            dtTimeEnergia.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeEnergia.Tick += incrementarEnergia;
            dtTimeEnergia.Start();
            imgPocionEnergia.Opacity = 0.5;
        }


        public void activarAniIdle(bool activar)
        {
            throw new NotImplementedException();
        }
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            int numeroAnimacion;

            // Comprueba si la tecla presionada es un número
            if (int.TryParse(args.VirtualKey.ToString().Replace("Number", ""), out numeroAnimacion))
            {
                // Si es un número, ejecuta la animación correspondiente
                ejecutarAnimacion(numeroAnimacion);
            }
        }
        public void ejecutarAnimacion(int numeroAnimacion)
        {
            switch (numeroAnimacion)
            {
                case 1:
                    animacionAtaqueFlojo(null, null);
                    break;
                case 2:
                    animacionAtaqueFuerte(null, null);
                    break;
                case 3:
                    animacionDefensa(null, null);
                    break;
                case 4:
                    animacionDescasar(null, null);
                    break;
                case 5:
                    animacionCansado(null, null);
                    break;
                case 6:
                    animacionHerido(null, null);
                    break;
                case 7:
                    animacionDerrota(null, null);
                    break;


                default:
                    Console.WriteLine("Número de animación no válido");
                    break;
            }
        }

        public void animacionAtaqueFlojo(object sender, RoutedEventArgs e)
        {
            imgLlama.Visibility = Visibility.Visible;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += (s, args) =>
            {
                imgLlama.Visibility = Visibility.Collapsed;
                timer.Stop();
            };
            timer.Start();
        }


        public void animacionAtaqueFuerte(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbBolaFuego"];
            sb.AutoReverse = false;
            sb.Begin();
        }

        public void animacionDefensa(object sender, RoutedEventArgs e)
        {
            imgEscudo.Visibility = Visibility.Visible;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += (s, args) =>
            {
                imgEscudo.Visibility = Visibility.Collapsed;
                timer.Stop();
            };
            timer.Start();
        }


        public void animacionDescasar(object sender, object e)
        {
            // Si la vida y la energía ya están al máximo, no hacer nada
            if (pb_energia.Value >= 100 && pb_vida.Value >= 100)
            {
                return;
            }

            if (pb_energia.Value < 100)
            {
                pb_energia.Value += 0.2;
            }
            else
            {
                dtTimeEnergia.Stop();
            }

            if (pb_vida.Value < 100)
            {
                pb_vida.Value += 0.2;
            }
            else
            {
                dtTimeVida.Stop();
            }
        }


        public void animacionCansado(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.ptPupilaIzq.Resources["ojoIzqAmarilloKey"];
            Storyboard sb2 = (Storyboard)this.ptPupilaDer.Resources["ojoDerAmarilloKey"];
            sb.Begin();
            sb2.Begin();
        }

        public void animacionNoCansado()
        {
            throw new NotImplementedException();
        }

        public void animacionHerido(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.ptPupilaIzq.Resources["ojoIzqRojoKey"];
            Storyboard sb2 = (Storyboard)this.ptPupilaDer.Resources["ojoDerRojoKey"];
            sb.Begin();
            sb2.Begin();
        }

        public void animacionNoHerido()
        {
            throw new NotImplementedException();
        }

        public void animacionDerrota(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.ptPupilaIzq.Resources["ojoIzqNegroKey"];
            Storyboard sb2 = (Storyboard)this.ptPupilaDer.Resources["ojoDerNegroKey"];
            sb.Begin();
            sb2.Begin();
        }

        public void verFilaVida(bool ver)
        {
            throw new NotImplementedException();
        }

        public void verPocionVida(bool ver)
        {
            throw new NotImplementedException();
        }

        public void verPocionEnergia(bool ver)
        {
            throw new NotImplementedException();
        }

        public void animacionAtaqueFlojo()
        {
            throw new NotImplementedException();
        }

        public void animacionAtaqueFuerte()
        {
            throw new NotImplementedException();
        }

        public void animacionDefensa()
        {
            throw new NotImplementedException();
        }

        public void animacionDescasar()
        {
            throw new NotImplementedException();
        }

        public void animacionCansado()
        {
            throw new NotImplementedException();
        }

        public void animacionHerido()
        {
            throw new NotImplementedException();
        }

        public void animacionDerrota()
        {
            throw new NotImplementedException();
        }
    }
}
