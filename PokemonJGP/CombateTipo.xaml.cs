﻿using System;
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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace PokemonJGP
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CombateTipo : Page
    {
        public CombateTipo()
        {
            this.InitializeComponent();
        }
        private void irCombate1J(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Combate1J));
        }
        private void irCombate2J(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Combate));
        }

        private void btn_Jugador_Click(object sender, RoutedEventArgs e)
        {
            irCombate1J(sender, e);
        }

        private void btn_Jugadores_Click(object sender, RoutedEventArgs e)
        {
            irCombate2J(sender, e);
        }
    }
}
