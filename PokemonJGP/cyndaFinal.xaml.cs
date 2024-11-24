using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace PokemonP4
{
    public sealed partial class cyndaFinal : UserControl, iPokemon
    {
        DispatcherTimer dtTime;

        public double Vida { get => this.pbVida.Value; set => this.pbVida.Value = value; }
        public double Energia { get => this.pbEnergia.Value; set => this.pbEnergia.Value = value; }
        public string Nombre { get => "Cyndaquil"; set => throw new NotImplementedException(); }
        public string Categoría { get => "Ratón"; set => throw new NotImplementedException(); }
        public string Tipo { get => "Fuego"; set => throw new NotImplementedException(); }
        public double Altura { get => 0.5 ; set => throw new NotImplementedException(); }
        public double Peso { get => 7.9; set => throw new NotImplementedException(); }
        public string Evolucion { get => "Quilava"; set => throw new NotImplementedException(); }
        public string Descripcion { get => "Cyndaquil Suele estar encorvado. Si se enfada o se asusta, lanzará llamas por el lomo."; set => throw new NotImplementedException(); }

        public cyndaFinal()
        {
            this.InitializeComponent();
            this.IsTabStop = true;
            Storyboard sb = (Storyboard)this.Resources["SbEstadoBase"];
            sb.Begin();
            pbVida.Value = 10;
            pbEnergia.Value = 70;
            //if (Vida.Value <= 30)
            //{
            //    sb.Completed += estadoHerido;
            //}
            //if (Energia.Value <= 30)
            //{
            //    sb.Completed += estadoCansado;
            //}
            //this.KeyDown += Page_KeyDown;



        }
        public void verFondo(bool verfondo)
        {
            if (!verfondo) { this.imFondo.Source = null; }
            else
            {
                //TODO Poner fondo de nuevo
            }
        }

        //private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        //{
        //    Storyboard sbaux;
        //    switch (e.Key)
        //    {
        //        case Windows.System.VirtualKey.W:
        //            sbaux = (Storyboard)this.Resources["SbAtaque1"];
        //            sbaux.Begin();
        //            sbaux.Completed += estadoBase;
        //            break;
        //        case Windows.System.VirtualKey.Q:
        //            sbaux = (Storyboard)this.Resources["SbDefensa"];
        //            sbaux.Begin();
        //            sbaux.Completed += estadoEscudo;
        //            break;
        //        case Windows.System.VirtualKey.E:
        //            sbaux = (Storyboard)this.Resources["SbAtaque"];
        //            sbaux.Begin();
        //            sbaux.Completed += estadoBase;
        //            break;
        //        case Windows.System.VirtualKey.R:
        //            sbaux = (Storyboard)this.Resources["SbDescanso"];
        //            sbaux.Begin();
        //            sbaux.Completed += estadoBase;
        //            break;
        //        case Windows.System.VirtualKey.T:
        //            sbaux = (Storyboard)this.Resources["SbHerido"];
        //            sbaux.Begin();
        //            sbaux.Completed += estadoBase;
        //            break;
        //        case Windows.System.VirtualKey.Y:
        //            sbaux = (Storyboard)this.Resources["SbCansado"];
        //            sbaux.Begin();
        //            sbaux.Completed += estadoBase;
        //            break;
        //    }


        
        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.Proja.Opacity = 0.5;
        }
        private void increaseHealth(object sender, object e)
        {
            this.pbVida.Value += 0.2;
            if (pbVida.Value >= 100)
            {
                this.dtTime.Stop();
                this.Proja.Opacity = 1;
            }
        }
        private void usePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseSta;
            dtTime.Start();
            this.Pama.Opacity = 0.5;
        }
        private void increaseSta(object sender, object e)
        {
            this.pbEnergia.Value += 0.2;
            if (pbEnergia.Value >= 100)
            {
                this.dtTime.Stop();
                this.Pama.Opacity = 1;
            }
        }

        private void Pama_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            usePotionYellow(sender, e);
        }

        private void Proja_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            usePotionRed(sender, e);
        }
        private void estadoBase(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["SbEstadoBase"];
            sb.Begin();
        }
        private void estadoEscudo(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["SbConEscudo"];
            sb.Begin();
            sb.Completed += estadoBase;

        }
        private void estadoHerido(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["SbHerido"];
            sb.Begin();
            if (pbVida.Value <= 0)
            {
                Storyboard sb2 = (Storyboard)this.Resources["SbDerrotado"];
                sb2.Begin();
            }
            else if (pbVida.Value >= 30)
            {
                sb.Completed += estadoBase;
            }
        }
        private void estadoCansado(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["SbCansado"];
            sb.Begin();
            if (pbEnergia.Value >= 30)
            {
                sb.Completed += estadoBase;
            }
        }
        public void verFilaVida(bool ver)
        {
            if(!ver) { this.pbVida.Opacity = 0; }
            else { this.pbVida.Opacity = 100; }
        }

        public void verFilaEnergia(bool ver)
        {
            if (!ver) { this.pbEnergia.Opacity = 0; }
            else { this.pbEnergia.Opacity = 100; }
        }

        public void verPocionVida(bool ver)
        {
            if (!ver) { this.Proja.Opacity = 0; }
            else { this.Proja.Opacity = 100; }
        }

        public void verPocionEnergia(bool ver)
        {
            if (!ver) { this.Pama.Opacity = 0; }
            else { this.Pama.Opacity = 100; }
        }

        public void verNombre(bool ver)
        {
            if (!ver) { this.nombrePokemon.Opacity = 0; }
            else { this.nombrePokemon.Opacity = 100; }
        }

        public void activarAniIdle(bool activar)
        {
            Storyboard EstadoBase = (Storyboard)this.Resources["SbEstadoBase"];
            EstadoBase.Begin();

        }

        public void animacionAtaqueFlojo()
        {
            Storyboard AtaqueBasico = (Storyboard)this.Resources["SbAtaque1"];
            AtaqueBasico.Begin();

        }

        public void animacionAtaqueFuerte()
        {
            Storyboard sbaux = (Storyboard)this.Resources["SbAtaque"];
            sbaux.Begin();
        }

        public void animacionDefensa()
        {
            Storyboard Defensa = (Storyboard)this.Resources["SbDefensa"];
            Defensa.Begin();
        }

        public void animacionDescasar()
        {
            Storyboard sbaux = (Storyboard)this.Resources["SbDescanso"];
            sbaux.Begin();
        }

        public void animacionCansado()
        {
            Storyboard sbaux = (Storyboard)this.Resources["SbCansado"];
            sbaux.Begin();
        }

        public void animacionNoCansado()
        {
            Storyboard EstadoBase = (Storyboard)this.Resources["SbEstadoBase"];
            EstadoBase.Begin();
        }

        public void animacionHerido()
        {
            Storyboard sbaux = (Storyboard)this.Resources["SbHerido"];
            sbaux.Begin();
        }

        public void animacionNoHerido()
        {
            Storyboard EstadoBase = (Storyboard)this.Resources["SbEstadoBase"];
            EstadoBase.Begin();
        }

        public void animacionDerrota()
        {
            Storyboard sbaux = (Storyboard)this.Resources["SbDerrotado"];
            sbaux.Begin();
        }
    }

    
}
