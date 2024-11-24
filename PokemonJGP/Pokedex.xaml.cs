using pikachu_AP;
using pokemonFinalDALF;
using PokemonP4;
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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace PokemonJGP
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Pokedex : Page
    {
        public Pokedex()
        {
            this.InitializeComponent();
        }

        private void GrookeyJGPMP(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is GrookeyJGPMP)
            {
                GrookeyJGPMP grookeyControl = border.Child as GrookeyJGPMP;

                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", grookeyControl.Nombre},
                    {"Categoría", grookeyControl.Categoría},
                    {"Tipo", grookeyControl.Tipo},
                    {"Altura", grookeyControl.Altura},
                    {"Peso", grookeyControl.Peso},
                    {"Evolucion", grookeyControl.Evolucion},
                    {"Descripcion", grookeyControl.Descripcion}
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }

        private void CyndaquilTapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is cyndaFinal)
            {
                cyndaFinal cyndaControl = border.Child as cyndaFinal;

                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", cyndaControl.Nombre},
                    {"Categoría", cyndaControl.Categoría},
                    {"Tipo", cyndaControl.Tipo},
                    {"Altura", cyndaControl.Altura},
                    {"Peso", cyndaControl.Peso},
                    {"Evolucion", cyndaControl.Evolucion},
                    {"Descripcion", cyndaControl.Descripcion}
                    
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }

        private void AnotherPokemonTapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is MyUserControl1)
            {
                MyUserControl1 anotherControl = border.Child as MyUserControl1;

                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", anotherControl.Nombre},
                    {"Categoría", anotherControl.Categoría},
                    {"Tipo", anotherControl.Tipo},
                    {"Altura", anotherControl.Altura},
                    {"Peso", anotherControl.Peso},
                    {"Evolucion", anotherControl.Evolucion},
                    {"Descripcion", anotherControl.Descripcion}
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }

        private void GengarTapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is  Sesion4.GengarJCC Gengar)
            {
                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", Gengar.Nombre},
                    {"Categoría", Gengar.Categoría},
                    {"Tipo", Gengar.Tipo},
                    {"Altura", Gengar.Altura},
                    {"Peso", Gengar.Peso},
                    {"Evolucion", Gengar.Evolucion},
                    {"Descripcion",Gengar.Descripcion}
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }

        private void PikachuTapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is pikachu_AP.pikachu_AP pikachu)
            {
                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", pikachu.Nombre},
                    {"Categoría", pikachu.Categoría},
                    {"Tipo", pikachu.Tipo},
                    {"Altura", pikachu.Altura},
                    {"Peso", pikachu.Peso},
                    {"Evolucion", pikachu.Evolucion},
                    {"Descripcion",pikachu.Descripcion}
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }

        private void ButterFreeTapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is ButterFreeACC.ButterFreeACC butterFree)
            {
                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", butterFree.Nombre},
                    {"Categoría",butterFree.Categoría},
                    {"Tipo", butterFree.Tipo},
                    {"Altura", butterFree.Altura},
                    {"Peso", butterFree.Peso},
                    {"Evolucion", butterFree.Evolucion},
                    {"Descripcion",butterFree.Descripcion}
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }

        private void ArticunoTapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is Pokemon_Antonio_Campallo_Gomez.ArticunoACG articuno)
            {
                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", articuno.Nombre},
                    {"Categoría",articuno.Categoría},
                    {"Tipo", articuno.Tipo},
                    {"Altura", articuno.Altura},
                    {"Peso", articuno.Peso},
                    {"Evolucion", articuno.Evolucion},
                    {"Descripcion",articuno.Descripcion}
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }

        private void AronTapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is PokemonAron.AronMCC aron)
            {
                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", aron.Nombre},
                    {"Categoría",aron.Categoría},
                    {"Tipo", aron.Tipo},
                    {"Altura", aron.Altura},
                    {"Peso", aron.Peso},
                    {"Evolucion", aron.Evolucion},
                    {"Descripcion",aron.Descripcion}
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }

        private void AzumarillTapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is Pokemon1.AzumarillACR azu)
            {
                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", azu.Nombre},
                    {"Categoría",azu.Categoría},
                    {"Tipo", azu.Tipo},
                    {"Altura", azu.Altura},
                    {"Peso", azu.Peso},
                    {"Evolucion", azu.Evolucion},
                    {"Descripcion",azu.Descripcion}
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }

        private void CharmanderTapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is CharmanderBueno.CharmanderFJDR charmander)
            {
                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", charmander.Nombre},
                    {"Categoría",charmander.Categoría},
                    {"Tipo", charmander.Tipo},
                    {"Altura", charmander.Altura},
                    {"Peso", charmander.Peso},
                    {"Evolucion", charmander.Evolucion},
                    {"Descripcion",charmander.Descripcion}
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }

        private void DragoniteTapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is ControlUsuario_IPO2.DragoniteCSD dragonite)
            {
                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", dragonite.Nombre},
                    {"Categoría",dragonite.Categoría},
                    {"Tipo", dragonite.Tipo},
                    {"Altura", dragonite.Altura},
                    {"Peso", dragonite.Peso},
                    {"Evolucion", dragonite.Evolucion},
                    {"Descripcion",dragonite.Descripcion}
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }

        private void SnorlaxTapped(object sender, TappedRoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null && border.Child is OrtizCañameroRoberto_Snorlax.SnorlaxROC snorlax)
            {
                var pokemonProperties = new Dictionary<string, object>
                {
                    {"Nombre", snorlax.Nombre2},
                    {"Categoría",snorlax.Categoría},
                    {"Tipo", snorlax.Tipo},
                    {"Altura", snorlax.Altura},
                    {"Peso", snorlax.Peso},
                    {"Evolucion", snorlax.Evolucion},
                    {"Descripcion",snorlax.Descripcion}
                };

                Frame.Navigate(typeof(infoPokemon), pokemonProperties);
            }
        }
    }
}
