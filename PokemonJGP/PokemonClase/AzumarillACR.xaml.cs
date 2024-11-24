using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Pokemon1
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AzumarillACR : UserControl, iPokemon
    {
        DispatcherTimer dtTime_r;
        DispatcherTimer dtTime_ama;

        private double vida;
        public double Vida
        {
            get { return this.pb_vida.Value; }
            set { this.pb_vida.Value = value; }
        }

        private double energia;
        public double Energia
        {
            get { return this.pb_energia.Value; }
            set { this.pb_energia.Value = value; }
        }

        private string nombrePok;
        public string Nombre
        {
            get { return nombrePok; }
            set { nombrePok = value; }
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

        public AzumarillACR()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Vida = 100;
            Energia = 100;
            Nombre = "Azumarill";
            Categoría = "Conejo Agua";
            Tipo = "Agua";
            Altura = 0.8;
            Peso = 28.5;
            Evolucion = "No tiene";
            Descripcion = "Azumarill tiene un cuerpo redondeado y robusto, con orejas grandes y esponjosas y una cola corta. Su pelaje es de un azul vibrante, con manchas blancas en el pecho y las mejillas. Sus grandes ojos redondos tienen un tono amable y expresivo. Azumarill es famoso por su fuerza física, capaz de romper bloques de concreto con facilidad gracias a sus poderosas mandíbulas y sus extremidades musculosas.Este Pokémon es conocido por su personalidad cariñosa y amigable. A menudo se le ve jugando alegremente en arroyos y lagos, y es muy protector con su territorio y su familia. A pesar de su apariencia dulce, Azumarill es un luchador valiente y tenaz en combate, capaz de resistir ataques poderosos y contraatacar con movimientos acuáticos y de hada. En resumen, Azumarill es una combinación única de fuerza, ternura y determinación, lo que lo convierte en un compañero querido por entrenadores y amantes de los Pokémon por igual.";



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
        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime_r = new DispatcherTimer();
            dtTime_r.Interval = TimeSpan.FromMilliseconds(100);
            dtTime_r.Tick += increaseHealth;
            dtTime_r.Start();
            this.im_pocion_roja.Opacity = 0.5;
        }
        private void increaseHealth(object sender, object e)
        {
            this.pb_vida.Value += 0.2;
            if (pb_vida.Value >= 100)
            {
                this.dtTime_r.Stop();
                this.im_pocion_roja.Opacity = 0;
            }
        }

        private void usePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime_ama = new DispatcherTimer();
            dtTime_ama.Interval = TimeSpan.FromMilliseconds(100);
            dtTime_ama.Tick += increaseEnergy;
            dtTime_ama.Start();
            this.im_pocion_ama.Opacity = 0.5;
        }
        private void increaseEnergy(object sender, object e)
        {
            this.pb_energia.Value += 0.2;
            if (pb_energia.Value >= 100)
            {
                this.dtTime_ama.Stop();
                this.im_pocion_ama.Opacity = 0;
            }
        }



        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        public void verFondo(bool verFondo)
        {
            if (!verFondo)
            {
                this.im_fondo.Visibility = Visibility.Collapsed;
            }
            else
                this.im_fondo.Visibility = Visibility.Visible;
        }

        public void verFilaVida(bool verFilaVida)
        {
            if (!verFilaVida)
            {
                this.pb_vida.Visibility = Visibility.Collapsed;
            }
            else
                this.pb_vida.Visibility = Visibility.Visible;
        }

        public void verFilaEnergia(bool verFilaEnergia)
        {
            if (!verFilaEnergia)
            {
                this.pb_energia.Visibility = Visibility.Collapsed;
            }
            else
                this.pb_energia.Visibility = Visibility.Visible;

        }

        public void verPocionVida(bool verPocionVida)
        {
            if (!verPocionVida)
            {
                this.im_pocion_roja.Visibility = Visibility.Collapsed;
            }
            else
                this.im_pocion_roja.Visibility = Visibility.Visible;
        }

        public void verPocionEnergia(bool verPocionEnergia)
        {
            if (!verPocionEnergia)
            {
                this.im_pocion_ama.Visibility = Visibility.Collapsed;
            }
            else
                this.im_pocion_ama.Visibility = Visibility.Visible;
        }

        public void verNombre(bool verNombre)
        {
            if (!verNombre)
            {
                this.nombre.Visibility = Visibility.Collapsed;
            }
            else
                this.nombre.Visibility = Visibility.Visible;
        }

        public void activarAniIdle(bool activar)
        {
            throw new NotImplementedException();
        }

        public void animacionAtaqueFlojo()
        {
            Storyboard sb = (Storyboard)this.Resources["colaFerrea"];
            sb.Begin();

        }

        public void animacionAtaqueFuerte()
        {
            Storyboard sb = (Storyboard)this.Resources["surf"];
            sb.Begin();
        }

        public void animacionDefensa()
        {
            Storyboard sb = (Storyboard)this.Resources["escudo"];
            sb.AutoReverse = true;
            sb.Begin();
        }

        public void animacionDescasar()
        {
            Storyboard sb = (Storyboard)this.Resources["descansar"];
            sb.AutoReverse = true;
            sb.Begin();
        }

        public void animacionCansado()
        {
            Storyboard sb = (Storyboard)this.Resources["cansado1"];
            sb.AutoReverse = true;
            sb.Begin();
        }

        public void animacionNoCansado()
        {
            throw new NotImplementedException();
        }

        public void animacionHerido()
        {
            Storyboard sb = (Storyboard)this.Resources["herido1"];
            sb.AutoReverse = true;
            sb.Begin();
        }

        public void animacionNoHerido()
        {
            throw new NotImplementedException();
        }

        public void animacionDerrota()
        {
            // Obtén el Storyboard "desaparecer" y comienza la animación
            Storyboard sb = (Storyboard)this.Resources["muerte"];
            sb.AutoReverse = true;
            sb.Begin();
        }
        public void ejecutarAnimacion(int numeroAnimacion)
        {
            switch (numeroAnimacion)
            {
                case 1:
                    animacionAtaqueFlojo();
                    break;
                case 2:
                    animacionAtaqueFuerte();
                    break;
                case 3:
                    animacionDefensa();
                    break;
                case 4:
                    animacionDescasar();
                    break;
                case 5:
                    animacionCansado();
                    break;
                case 6:
                    animacionHerido();
                    break;
                case 7:
                    animacionDerrota();
                    break;


                default:
                    Console.WriteLine("Número de animación no válido");
                    break;
            }
        }
    }
}

