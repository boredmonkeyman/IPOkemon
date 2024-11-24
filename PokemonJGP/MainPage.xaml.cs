using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace PokemonJGP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += System_BackRequested;
            fmMain.Navigated += onNavigated;
            UpdateBackButtonVisibility();

            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged+= MainPage_VisibleBoundsChanged;

            //Se inicia la pestaña de inicio sin tocar ningun boton
            fmMain.Navigate(typeof(Inicio));
        }

        private void irInicio(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(Inicio));
        }

        private void irPokemons(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(MisPokemons));
        }

        private void irPokedex(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(Pokedex));
        }

        private void irCombate(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(CombateTipo));
        }

        private void irAcercaDe(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(AcercaDe));
        }

        private void System_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (fmMain.CanGoBack)
            {
                fmMain.GoBack();
                e.Handled = true;
            }
        }

        private void opcionVolver(object sender, RoutedEventArgs e)
        {
            if (fmMain.CanGoBack)
            {
                fmMain.GoBack();
            }
            UpdateBackButtonVisibility();
        }

        private void UpdateBackButtonVisibility()
        {
            //btAtrás.Visibility = fmMain.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void onNavigated(object sender, NavigationEventArgs e)
        {
            UpdateBackButtonVisibility();
        }

        private void Men(object sender, RoutedEventArgs e)
        {

        }

        private void button_Menu(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;

        }

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width =
           Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width >= 720)
            {
                splitView.DisplayMode = SplitViewDisplayMode.CompactInline;
                splitView.IsPaneOpen = true;
            }
            else if (Width >= 360)
            {
                splitView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                splitView.IsPaneOpen = false;
            }
            else
            {
                splitView.DisplayMode = SplitViewDisplayMode.Overlay;
                splitView.IsPaneOpen = false;
            }
        }

    }
}
