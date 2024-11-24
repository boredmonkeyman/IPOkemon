using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace pikachu_AP
{
    public sealed partial class pikachu_AP : UserControl, iPokemon
    {

        private int elapsedTime = 0;
        //private DispatcherTimer dt { get; set; }
        private MediaPlayer mp { get; set; }
        //private Boolean IsTabStop { get; set; }
        private Boolean subirVidaBarra { get; set; }
        private DispatcherTimer dt { get; set; }
        private string name { get; set; }
        private string categoria = "Ratón";
        private string tipo = "Eléctrico";
        private double altura { get; set; }
        private double peso = 6.0;
        private string evolucion = "Raichu";
        private string Habilidad { get; set; }
        private string descripcion { get; set; }
        public double Vida { get => this.pbVida.Value; set => this.pbVida.Value = value; }
        public double Energia { get => this.pbSegundaVida.Value; set => this.pbSegundaVida.Value = value; }
        public string Nombre { get => this.name; set => this.name = value; }
        public string Categoría { get => this.categoria; set => this.categoria = value; }
        public string Tipo { get => this.tipo; set => this.tipo = value; }
        public double Altura { get => this.altura; set => this.altura = value; }
        public double Peso { get => this.peso; set => this.peso = value; }
        public string Evolucion { get => this.evolucion; set => this.evolucion = value; }
        public string Descripcion { get => this.descripcion; set => this.descripcion = value; }
        public string habilidad { get => this.habilidad; set => this.Habilidad = value; }

        public pikachu_AP()
        {

            this.InitializeComponent();
            this.name = "Soy pikachu!";
            this.descripcion = "Cuando se enfada, este Pokémon descarga la energía que almacena en el interior de las bolsas de las mejillas";
            this.habilidad = "Electricidad estática";
            this.altura = 0.4;
            dt = new DispatcherTimer();
            this.IsTabStop = true;
            this.mp = new MediaPlayer();
            this.subirVidaBarra = false;
            //StoryboardManoDcha.Begin();
            //StoryboardManoIzq.Begin();
            //StoryboardOrejaIzq.Begin();
            //StoryboardOrejaDcha.Begin();
            StoryboardMovDefault.Begin();
            //StoryboardCola.Begin();
            // Storyboard sbManoDcha =(Storyboard)this.Resources["StoryboardManoDcha"];
            //sbManoDcha.Begin();
        }




        private void inicioRecuperado(object sender, object e)
        {
            StoryboardRevivir.Begin();
        }

        private void Window_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number1://mover manos
                    mp.Volume = 0;
                    StoryboardManoDcha.Begin();
                    mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/Singing-birds-in-the-valley.mp3"));

                    mp.Play();
                    StoryboardManoDcha.Completed += new EventHandler<object>(inicioManoIzq);
                    mp.Volume = 1;
                    break;
                case Windows.System.VirtualKey.Number2://mover orejas
                    mp.Volume = 0;
                    mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/Singing-birds-in-the-valley.mp3"));

                    mp.Play();
                    mp.Volume = 1;
                    StoryboardOrejaDcha.Begin();
                    StoryboardOrejaDcha.Completed += new EventHandler<object>(inicioOrejaIzq);

                    break;
                case Windows.System.VirtualKey.Number3://huida
                    mp.Volume = 0;
                    mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/warrior_medium-192841.mp3"));
                    mp.PlaybackSession.PlaybackRate = 2;

                    mp.Play();
                    mp.Volume = 1;
                    StoryboardHuida.Begin();

                    StoryboardHuida.Completed += new EventHandler<object>(pausarSonido);
                    break;
                case Windows.System.VirtualKey.Number4://cansado
                    mp.Volume = 0;
                    StoryboardMuerte.Begin();
                    //bajarVida();
                    StoryboardMuerte.Completed += new EventHandler<object>(inicioRecuperado);
                    //subirVida();
                    //this.dt.Stop();
                    mp.Volume = 1;
                    break;
                case Windows.System.VirtualKey.Number5:
                    mp.Volume = 0;
                    StoryboardAtaque.Begin();
                    mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/misc174.mp3"));
                    mp.Play();
                    mp.Volume = 1;
                    StoryboardAtaque.Completed += new EventHandler<object>(pausarSonido);
                    break;
                case Windows.System.VirtualKey.Number6:
                    // mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/people108.mp3"));
                    //mp.PlaybackSession.PlaybackRate = 2;

                    //mp.Play();
                    mp.Volume = 0;
                    StoryboardAtaqueFuerte.Begin();
                    this.cvRayo.Visibility = Visibility.Visible;
                    mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/A-single-peal-of-thunder.wav"));
                    mp.PlaybackSession.PlaybackRate = 3;
                    mp.Play();
                    mp.Volume = 1;
                    StoryboardAtaqueFuerte.Completed += new EventHandler<object>(ocultarRayo);
                    break;
                case Windows.System.VirtualKey.Number7:
                    // mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/people108.mp3"));
                    //mp.PlaybackSession.PlaybackRate = 2;

                    //mp.Play();
                    mp.Volume = 0;
                    StoryboardDesaparecer.Begin();
                    //this.cvRayo.Visibility = Visibility.Visible;
                    mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/Suddenness.mp3"));
                    //mp.PlaybackSession.PlaybackRate = 3;
                    mp.Play();
                    mp.Volume = 1;
                    //StoryboardAtaqueFuerte.Completed += new EventHandler<object>(ocultarRayo);
                    break;
                case Windows.System.VirtualKey.Number8:
                    mp.Volume = 0;
                    //StoryboardManoDcha.Begin();
                    mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/zombie-long-death.mp3"));

                    mp.Play();
                    //StoryboardManoDcha.Completed += new EventHandler<object>(inicioManoIzq);
                    mp.Volume = 1;
                    desaparecer();
                    break;
            }
        }

        private void desaparecer()
        {
            DispatcherTimer dtimer = new DispatcherTimer();
            dtimer.Interval = TimeSpan.FromMilliseconds(100);
            dtimer.Tick += irse;
            dtimer.Start();
            //this.canvas.Opacity = 0.1;
        }
        private void irse(object sender, object e)
        {
            this.pbVida.Value = 0;
            this.canvas.Visibility = Visibility.Collapsed;
        }

        private void ocultarRayo(object sender, object e)
        {
            this.cvRayo.Visibility = Visibility.Collapsed;
            StoryboardAtaqueFuerteInicio.Begin();

        }

        private void subirVida()
        {
            //this.subirVidaBarra = true;
            //DispatcherTimer dtimer = new DispatcherTimer();
            //dtimer.Interval = TimeSpan.FromMilliseconds(50);
            //dt.Interval= TimeSpan.FromMilliseconds(50);
            //if (subirVidaBarra)
            //{

            //    //dtimer.Tick += increseHealth;
            //    this.dt.Tick += increseHealth;
            //    //dtimer.Start();
            //    this.dt.Start();


            //}

            this.subirVidaBarra = true;
            this.dt.Interval = TimeSpan.FromMilliseconds(50);
            if (subirVidaBarra)
            {
                this.dt.Tick += increseHealth;
                this.dt.Start();

                // Crear un temporizador para detener el DispatcherTimer después de 5 segundos
                Timer timer = new Timer((state) =>
                {
                    // this.dt.Stop();
                    // Dispose del temporizador después de su uso
                }, null, 5000, Timeout.Infinite);
            }
        }

        private void bajarVida()
        {
            //DispatcherTimer dtimer = new DispatcherTimer();
            //dtimer.Interval = TimeSpan.FromMilliseconds(50);
            //dtimer.Tick += decreaseHealth;
            //dtimer.Start();
            //dtimer.Stop();
            this.dt = new DispatcherTimer();
            this.dt.Interval = TimeSpan.FromMilliseconds(100);
            this.dt.Tick += decreaseHealth;
            this.dt.Start();

        }

        private void decreaseHealth(object sender, object e)
        {
            this.pbVida.Value -= 2;
            if (this.pbVida.Value <= 10)
            {
                this.dt.Stop();
            }






            //// Incrementa el tiempo transcurrido en cada tick del timer
            //this.elapsedTime += 50; // El intervalo es de 50 milisegundos

            //// Lógica para aumentar la salud aquí
            //// Por ejemplo, incrementar el valor de la barra de vida
            //this.pbVida.Value -= 2;
            //// Verifica si han pasado 2 segundos
            //if (this.elapsedTime >= 3000) // 5 segundos = 5000 milisegundos
            //{
            //    // Detén el timer
            //    this.dt.Stop();
            //    // Restablece el tiempo transcurrido
            //    this.elapsedTime = 0;
            //}

        }





        private void pausarSonido(object sender, object e)
        {
            this.mp.Volume = 0;
        }

        private void inicioRetitada(object sender, object e)
        {
            StoryboardRetirada.Begin();
        }

        private void inicioManoIzq(object sender, object e)
        {
            StoryboardManoIzq.Begin();
        }
        private void inicioOrejaIzq(object sender, object e)
        {
            StoryboardOrejaIzq.Begin();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.tbSaludo.Visibility = Visibility.Visible;
            this.tbSaludo.Text = "Bienvenido!";
        }

        private void imgPocima_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.dt.Interval = TimeSpan.FromMilliseconds(50);
            dt.Tick += increseHealth;
            dt.Start();


        }

        private void increseHealth(object sender, object e)
        {
            this.pbVida.Value += 2;
            if (this.pbVida.Value >= 100)
            {
                this.dt.Stop();
                this.imgPocima.Visibility = Visibility.Collapsed;
            }
        }

        /*private void increseHealth(object sender, Object e)
        {
            
            // Incrementa el tiempo transcurrido en cada tick del timer
            this.elapsedTime += 50; // El intervalo es de 50 milisegundos

            // Lógica para aumentar la salud aquí
            // Por ejemplo, incrementar el valor de la barra de vida
            this.pbVida.Value += 2;
            // Verifica si han pasado 2 segundos
            if (this.elapsedTime >= 3000) // 5 segundos = 5000 milisegundos
            {
                // Detén el timer
                this.dt.Stop();
                // Restablece el tiempo transcurrido
                this.elapsedTime = 0;
            }
        }*/

        public void verFondo(bool ver)
        {
            if (ver)
            {
                this.landscape.Visibility = Visibility.Visible;
            }
            else
            {
                this.landscape.Visibility = Visibility.Collapsed;
            }
        }

        public void verFilaVida(bool ver)
        {
            if (ver)
            {
                this.pbVida.Visibility = Visibility.Visible;
            }
            else
            {
                this.pbVida.Visibility = Visibility.Collapsed;
            }
        }

        public void verFilaEnergia(bool ver)
        {
            if (ver)
            {
                this.pbSegundaVida.Visibility = Visibility.Visible;
            }
            else
            {
                this.pbSegundaVida.Visibility = Visibility.Collapsed;
            }
        }

        public void verPocionVida(bool ver)
        {
            if (ver)
            {
                this.imgPocima.Visibility = Visibility.Visible;
            }
            else
            {
                this.imgPocima.Visibility = Visibility.Collapsed;
            }
        }

        public void verPocionEnergia(bool ver)
        {
            if (ver)
            {
                this.imgPocima2.Visibility = Visibility.Visible;
            }
            else
            {
                this.imgPocima2.Visibility = Visibility.Collapsed;
            }
        }

        public void verNombre(bool ver)
        {
            if (ver)
            {
                Console.WriteLine(this.name);
            }

        }

        public void activarAniIdle(bool activar)
        {
            if (activar)
            {
                StoryboardMovDefault.Begin();
            }
        }

        public void animacionAtaqueFlojo()
        {
            mp.Volume = 0;
            StoryboardAtaque.Begin();
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/misc174.mp3"));
            mp.Play();
            mp.Volume = 1;
            StoryboardAtaque.Completed += new EventHandler<object>(pausarSonido);
        }

        public void animacionAtaqueFuerte()
        {
            mp.Volume = 0;
            StoryboardAtaqueFuerte.Begin();
            this.cvRayo.Visibility = Visibility.Visible;
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/A-single-peal-of-thunder.wav"));
            mp.PlaybackSession.PlaybackRate = 3;
            mp.Play();
            mp.Volume = 1;
            StoryboardAtaqueFuerte.Completed += new EventHandler<object>(ocultarRayo);
        }

        public void animacionDefensa()
        {
            mp.Volume = 0;
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/warrior_medium-192841.mp3"));
            mp.PlaybackSession.PlaybackRate = 2;

            mp.Play();
            mp.Volume = 1;
            StoryboardHuida.Begin();

            StoryboardHuida.Completed += new EventHandler<object>(pausarSonido);
        }

        public void animacionDescasar()
        {
            mp.Volume = 0;
            StoryboardMuerte.Begin();
            //bajarVida();
            StoryboardMuerte.Completed += new EventHandler<object>(inicioRecuperado);
            //subirVida();
            //this.dt.Stop();
            mp.Volume = 1;
        }

        public void animacionCansado()
        {
            mp.Volume = 0;
            StoryboardMuerte.Begin();
            //bajarVida();
            StoryboardMuerte.Completed += new EventHandler<object>(inicioRecuperado);
            //subirVida();
            //this.dt.Stop();
            mp.Volume = 1;
        }

        public void animacionNoCansado()
        {
            mp.Volume = 0;
            StoryboardManoDcha.Begin();
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/Singing-birds-in-the-valley.mp3"));

            mp.Play();
            StoryboardManoDcha.Completed += new EventHandler<object>(inicioManoIzq);
            mp.Volume = 1;






            StoryboardOrejaDcha.Begin();
            StoryboardOrejaDcha.Completed += new EventHandler<object>(inicioOrejaIzq);


        }

        public void animacionHerido()
        {
            // mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/people108.mp3"));
            //mp.PlaybackSession.PlaybackRate = 2;

            //mp.Play();
            mp.Volume = 0;
            StoryboardDesaparecer.Begin();
            //this.cvRayo.Visibility = Visibility.Visible;
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/Suddenness.mp3"));
            //mp.PlaybackSession.PlaybackRate = 3;
            mp.Play();
            mp.Volume = 1;
            //StoryboardAtaqueFuerte.Completed += new EventHandler<object>(ocultarRayo);
        }

        public void animacionNoHerido()
        {
            mp.Volume = 0;
            StoryboardManoDcha.Begin();
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/Singing-birds-in-the-valley.mp3"));

            mp.Play();
            StoryboardManoDcha.Completed += new EventHandler<object>(inicioManoIzq);
            mp.Volume = 1;
        }

        public void animacionDerrota()
        {
            mp.Volume = 0;
            //StoryboardManoDcha.Begin();
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///mp3/zombie-long-death.mp3"));

            mp.Play();
            //StoryboardManoDcha.Completed += new EventHandler<object>(inicioManoIzq);
            mp.Volume = 1;
            desaparecer();
        }
    }

}
