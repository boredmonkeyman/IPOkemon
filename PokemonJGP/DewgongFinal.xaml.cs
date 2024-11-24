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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace pokemonFinalDALF
{
    public sealed partial class MyUserControl1 : UserControl, iPokemon
    {
        private const int V = 1;
        DispatcherTimer dtTime;

        public double Vida 
        { 
            get=>this.pbHealth.Value; set => this.pbHealth.Value = value; 
        }
        public double Energia
        {
            get => this.pbShield.Value; set => this.pbShield.Value = value;
        }

        public String Nombre
        {
            get => "Dewgong"; set => throw new NotImplementedException();
        }
        public string Categoría { get => "León Marino"; set => throw new NotImplementedException(); }
        public string Tipo { get => "Agua"; set => throw new NotImplementedException(); }
        public double Altura { get => 1.7; set => throw new NotImplementedException(); }
        public double Peso { get => 120; set => throw new NotImplementedException(); }
        public string Evolucion { get => "No tiene evolución"; set => throw new NotImplementedException(); }
        public string Descripcion { get => "Duerme en aguas poco profundas durante el día y, por la noche, cuando baja la temperatura del agua, nada en busca de comida."; set => throw new NotImplementedException(); }

        public MyUserControl1()
        {
            this.InitializeComponent();
            this.IsTabStop = true;
            this.InitializeComponent();
            Storyboard sb = (Storyboard)this.Resources["EstadoBase"];
            sb.Begin();
        }
        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.imRPotion.Opacity = 0.5;
        }
        private void increaseHealth(object sender, object e)
        {
            this.pbHealth.Value += 0.2;
            if (pbHealth.Value >= 100)
            {
                this.dtTime.Stop();
                this.imRPotion.Opacity = 1;
            }
        }
        private void usePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseShield;
            dtTime.Start();
            this.imYPotion.Opacity = 0.5;
        }
        private void increaseShield(object sender, object e)
        {
            this.pbShield.Value += 0.2;
            if (pbShield.Value >= 100)
            {
                this.dtTime.Stop();
                this.imRPotion.Opacity = 1;
            }
        }

        private void ControlTeclas(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number1:
                    animacionAtaqueFlojo();
                    break;
                case Windows.System.VirtualKey.Number2:
                    animacionAtaqueFuerte();
                    break;
                case Windows.System.VirtualKey.Number3:
                    animacionDescasar();
                    break;
                case Windows.System.VirtualKey.Number4:
                    animacionDefensa();
                    break;
                case Windows.System.VirtualKey.Number5:
                    animacionDerrota();
                    break;
                case Windows.System.VirtualKey.Number6:
                    animacionHerido();
                    break;
                case Windows.System.VirtualKey.Number7:
                    animacionCansado();
                    break;
                case Windows.System.VirtualKey.Number8:
                    animacionConEscudo();
                    break;
            }
        }
        
        public void verFondo(bool ver)
        {
            if (!ver) { this.imFondo.ImageSource = null; }
            else {
                this.imFondo.ImageSource = new BitmapImage(new Uri("/Assets/Bosque2.jpg" ));
            }
        }

        public void verFilaVida(bool ver)
        {
            if (!ver) { this.pbHealth.Opacity = 0; }
            else
            {
                this.pbHealth.Opacity = 100;
            }
        }

        public void verFilaEnergia(bool ver)
        {
            if (!ver) { this.pbShield.Opacity = 0; }
            else
            {
                this.pbShield.Opacity = 100;
            }

        }

        public void verPocionVida(bool ver)
        {
            if (!ver) { this.imRPotion.Opacity = 0; }
            else
            {
                this.imRPotion.Opacity = 100;
            }
        }

        public void verPocionEnergia(bool ver)
        {
            if (!ver) { this.imYPotion.Opacity = 0; }
            else
            {
                this.imYPotion.Opacity = 100;
            };
        }

        public void verNombre(bool ver)
        {
            if (!ver) { this.nombrePokemon.Opacity = 0; }
            else
            {
                this.nombrePokemon.Opacity = 100;
            }
        }

        public void activarAniIdle(bool activar)
        {
            Storyboard sbaux = (Storyboard)this.Resources["EstadoBase"];
            sbaux.Begin();
        }

        public void animacionAtaqueFlojo()
        {
            Storyboard sbaux = (Storyboard)this.Resources["AtaqueLigero"];
            sbaux.Begin();
        }

        public void animacionAtaqueFuerte()
        {
            Storyboard sbaux = (Storyboard)this.Resources["AtaquePesado"];
            sbaux.Begin();
        }
        public void animacionConEscudo()
        {
            Storyboard sbaux = (Storyboard)this.Resources["ConEscudo"];
            sbaux.Begin();
        }
        public void animacionDefensa()
        {
            Storyboard sbaux = (Storyboard)this.Resources["AniEscudo"];
            sbaux.Begin();
        }

        public void animacionDescasar()
        {
            Storyboard sbaux = (Storyboard)this.Resources["AniDescanso"];
            sbaux.Begin();
        }

        public void animacionCansado()
        {
            Storyboard sbaux = (Storyboard)this.Resources["Cansado"];
            sbaux.Begin();
        }

        public void animacionHerido()
        {
            Storyboard sbaux = (Storyboard)this.Resources["Herido"];
            sbaux.Begin();
        }

        public void animacionDerrota()
        {
            Storyboard sbaux = (Storyboard)this.Resources["Derrotado"];
            sbaux.Begin();
        }

        public void animacionNoCansado()
        {
            Storyboard sbaux = (Storyboard)this.Resources["EstadoBase"];
            sbaux.Begin();
        }


        public void animacionNoHerido()
        {
            Storyboard sbaux = (Storyboard)this.Resources["EstadoBase"];
            sbaux.Begin();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.pbShield.Value -= 10;
            Storyboard atPesado = (Storyboard)this.Resources["AtaquePesado"];
            Storyboard sb = (Storyboard)this.Resources["EstadoBase"];
            sb.Stop();
            atPesado.Begin();

            atPesado.Completed += finAtaqueLigero;
        }
        void finAtaqueLigero(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["EstadoBase"];
            Storyboard atPesado = (Storyboard)sender;
            atPesado.Completed -= finAtaqueLigero;
            atPesado.Stop();
            sb.Begin();
        }

        private void btnEscudo_Click(object sender, RoutedEventArgs e)
        {
            this.pbShield.Value -= 10;
            Storyboard aniEscudo = (Storyboard)this.Resources["AniEscudo"];
            Storyboard sb = (Storyboard)this.Resources["EstadoBase"];
            sb.Stop();
            aniEscudo.Begin();

            aniEscudo.Completed += finEscudo;
        }
        void finEscudo(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["EstadoBase"];
            Storyboard aniEscudo = (Storyboard)sender;
            aniEscudo.Completed -= finEscudo;
            aniEscudo.Stop();
            sb.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.pbShield.Value -= 10;
            Storyboard aniDescanso = (Storyboard)this.Resources["AniDescanso"];
            Storyboard sb = (Storyboard)this.Resources["EstadoBase"];
            sb.Stop();
            aniDescanso.Begin();

            aniDescanso.Completed += finDescanso;
        }
        void finDescanso(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["EstadoBase"];
            Storyboard aniDescanso = (Storyboard)sender;
            aniDescanso.Completed -= finDescanso;
            aniDescanso.Stop();
            sb.Begin();
        }

        private void BtnPlacaje_Click(object sender, RoutedEventArgs e)
        {
            this.pbShield.Value -= 10;
            Storyboard aniAtPesado = (Storyboard)this.Resources["AtaquePesado"];
            Storyboard sb = (Storyboard)this.Resources["EstadoBase"];
            sb.Stop();
            aniAtPesado.Begin();

            aniAtPesado.Completed += finAtaquePesado;
        }
        void finAtaquePesado(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["EstadoBase"];
            Storyboard aniAtPesado = (Storyboard)sender;
            aniAtPesado.Completed -= finAtaquePesado;
            aniAtPesado.Stop();
            sb.Begin();
        }
    }
}
