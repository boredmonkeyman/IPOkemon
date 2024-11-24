using System;
using Microsoft.Toolkit.Uwp.Notifications;  
using System.Collections.Generic;
using System.IO;
using System.Linq;
using pokemonFinalDALF;
using PokemonP4;
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
using System.Threading.Tasks;
using ClassLibrary1_Prueba;
using CharmanderBueno;
using ControlUsuario_IPO2;
using OrtizCañameroRoberto_Snorlax;
using Pokemon_Antonio_Campallo_Gomez;
using Pokemon1;
using PokemonAron;
using Sesion4;
using System.ComponentModel.Design;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace PokemonJGP
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Combate1J : Page
    {
        iPokemon pokemonElegido;
        iPokemon pokemonElegido1;
        int turno;
        int cont1=0;
        int cont2=0;
        int cont1e=0;
        int cont2e=0;
        bool defensa = false;
        bool defensa1 = false;

        public Combate1J()
        {
            this.InitializeComponent();
        }
        private async void btn_jug1_Click(object sender, RoutedEventArgs e) {
                fv_jugador1.IsEnabled = false;
                if (fv_jugador1.SelectedIndex == 0)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as GrookeyJGPMP;
                }
                else if (fv_jugador1.SelectedIndex == 1)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as MyUserControl1;
                }
                else if (fv_jugador1.SelectedIndex == 2)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as cyndaFinal;
                }
                else if (fv_jugador1.SelectedIndex == 3)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as DragoniteCSD;
                }
                else if (fv_jugador1.SelectedIndex == 4)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as GengarJCC;
                }
                else if (fv_jugador1.SelectedIndex == 5)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as pikachu_AP.pikachu_AP;
                }
                else if (fv_jugador1.SelectedIndex == 6)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as ButterFreeACC.ButterFreeACC;
                }
                else if (fv_jugador1.SelectedIndex == 7)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as ArticunoACG;
                }
                else if (fv_jugador1.SelectedIndex == 8)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as AronMCC;
                }
                else if (fv_jugador1.SelectedIndex == 9)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as AzumarillACR;
                }
                else if (fv_jugador1.SelectedIndex == 10)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as CharmanderFJDR;
                }
                else if (fv_jugador1.SelectedIndex == 11)
                {
                    pokemonElegido = fv_jugador1.SelectedItem as SnorlaxROC;
                }
                btn_jug1.Visibility = Visibility.Collapsed;
                if (fv_jugador1.IsEnabled == false & fv_jugador2.IsEnabled == false)
                {
                    pokemonElegido.Energia = 100;
                    pokemonElegido.Vida = 100;
                    pokemonElegido1.Energia = 100;
                    pokemonElegido1.Vida = 100;
                    pokemonElegido.activarAniIdle(true);
                    pokemonElegido1.activarAniIdle(true);
                    pokemonElegido.verFondo(false);
                    pokemonElegido1.verFondo(false);
                    turno = sorteo_inicio();
                    if (turno == 1)
                    {
                        bloqueo_jug2();
                    }
                    else
                    {
                        bloqueo_jug1();
                    }
                }
            }
            private async void btn_jug2_Click(object sender, RoutedEventArgs e)
            {
                fv_jugador2.IsEnabled = false;
                if (fv_jugador2.SelectedIndex == 0)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as GrookeyJGPMP;
                }
                else if (fv_jugador2.SelectedIndex == 1)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as MyUserControl1;
                }
                else if (fv_jugador2.SelectedIndex == 2)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as cyndaFinal;
                }
                else if (fv_jugador2.SelectedIndex == 3)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as DragoniteCSD;
                }
                else if (fv_jugador2.SelectedIndex == 4)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as GengarJCC;
                }
                else if (fv_jugador2.SelectedIndex == 5)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as pikachu_AP.pikachu_AP;
                }
                else if (fv_jugador2.SelectedIndex == 6)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as ButterFreeACC.ButterFreeACC;
                }
                else if (fv_jugador2.SelectedIndex == 7)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as ArticunoACG;
                }
                else if (fv_jugador2.SelectedIndex == 8)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as AronMCC;
                }
                else if (fv_jugador2.SelectedIndex == 9)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as AzumarillACR;
                }
                else if (fv_jugador2.SelectedIndex == 10)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as CharmanderFJDR;
                }
                else if (fv_jugador2.SelectedIndex == 11)
                {
                    pokemonElegido1 = fv_jugador2.SelectedItem as SnorlaxROC;
                }
                btn_jug2.Visibility = Visibility.Collapsed;
                if (fv_jugador1.IsEnabled == false & fv_jugador2.IsEnabled == false)
                {
                    pokemonElegido1.Energia = 100;
                    pokemonElegido1.Vida = 100;
                    pokemonElegido.Energia = 100;
                    pokemonElegido.Vida = 100;
                    pokemonElegido.activarAniIdle(true);
                    pokemonElegido1.activarAniIdle(true);
                    pokemonElegido1.verFondo(false);
                    pokemonElegido.verFondo(false); 
                    turno = sorteo_inicio();
                    if (turno == 1)
                    {
                        bloqueo_jug2();
                    }
                    else
                    {
                        bloqueo_jug1();
                    }
                }
            }
            public int sorteo_inicio()
        {
            Random r = new Random();
            int num = r.Next(1, 3);
            return num;
        }

        public void bloqueo_jug1()
        {
            controles_jug1.Visibility = Visibility.Collapsed;
            jug1_espera.Text = "Turno de la máquina, espera tu turno.";
            jug1_espera.Visibility = Visibility.Visible;
            jug2_espera.Visibility = Visibility.Collapsed;
            turno_maquina();
        }

        public void bloqueo_jug2()
        {
            jug2_espera.Text = "Turno del jugador 1, espera tu turno.";
            jug2_espera.Visibility = Visibility.Visible;
            jug1_espera.Visibility = Visibility.Collapsed;
            controles_jug1.Visibility = Visibility.Visible;
        }
        public void turno_maquina()
        {
            Random r = new Random();
            int num = r.Next(1, 4);
            if(pokemonElegido1.Vida > 30 & pokemonElegido1.Energia > 30)
            {
                atacar();
            }
            else if (pokemonElegido1.Vida <= 30)
            {
                if (cont2 == 1)
                {
                    if (defensa1 == true)
                    {
                        atacar();
                    }
                    else
                    {
                        defender();
                    }
                }
                else
                {
                    curar2();
                }
            }
            else
            {
                if (cont2e == 1)
                {
                    descansar();
                }
                else
                {
                    subirEnergia2();
                }
            } 
            
            /*switch (num)
            {
                case 1:
                    atacar2();
                    break;
                case 2:
                    curar2();
                    break;
                case 3:
                    subirEnergia2();
                    break;

            }*/
        }
        private async void atacar()
        {
            if (defensa == true)
            {
                if (pokemonElegido1.Energia < 75)
                {
                    pokemonElegido1.animacionAtaqueFuerte();
                    pokemonElegido.Vida -= (calcular_daño()/2);
                    jug2_espera.Text = "La máquina ha decidido atacar.";
                    jug2_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    if (pokemonElegido.Vida <= 0)
                    {
                        fondo_combate.Visibility = Visibility.Visible;
                        mensaje_victoria.Text = "La máquina ha ganado el combate.";
                        mensaje_victoria.Visibility = Visibility.Visible;
                        new ToastContentBuilder()
                            .AddArgument("action")
                            .AddArgument("conversationId", 9813)
                            .AddText("La máquina ha ganado el combate.")
                            .Show();
                    }
                    else
                    {
                        bloqueo_jug2();
                    }
                }
                else if (pokemonElegido1.Energia >= 25)
                {
                    pokemonElegido1.animacionAtaqueFlojo();
                    pokemonElegido.Vida -= (calcular_daño() / 4);
                    jug2_espera.Text = "La máquina ha decidido atacar.";
                    jug2_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    if (pokemonElegido.Vida <= 0)
                    {
                        fondo_combate.Visibility = Visibility.Visible;
                        mensaje_victoria.Text = "La máquina ha ganado el combate.";
                        mensaje_victoria.Visibility = Visibility.Visible;
                        new ToastContentBuilder()
                            .AddArgument("action")
                            .AddArgument("conversationId", 9813)
                            .AddText("La máquina ha ganado el combate.")
                            .Show();
                    }
                    else
                    {
                        bloqueo_jug2();
                    }

                }
                else
                {
                    jug2_espera.Text = "La máquina no tiene suficiente energía.";
                    jug2_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    bloqueo_jug2();
                }
            }
            else {
                if (pokemonElegido1.Energia < 75)
                {
                    pokemonElegido1.animacionAtaqueFuerte();
                    pokemonElegido.Vida -= (calcular_daño());
                    pokemonElegido1.Energia -= 50;
                    jug2_espera.Text = "La máquina ha decidido atacar.";
                    jug2_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    if (pokemonElegido.Vida <= 0)
                    {
                        fondo_combate.Visibility = Visibility.Visible;
                        mensaje_victoria.Text = "La máquina ha ganado el combate.";
                        mensaje_victoria.Visibility = Visibility.Visible;
                        new ToastContentBuilder()
                            .AddArgument("action")
                            .AddArgument("conversationId", 9813)
                            .AddText("La máquina ha ganado el combate.")
                            .Show();
                    }
                    else
                    {
                        bloqueo_jug2();
                    }
                }
                else if (pokemonElegido1.Energia >= 25)
                {
                    pokemonElegido1.animacionAtaqueFlojo();
                    pokemonElegido.Vida -= (calcular_daño() / 2);
                    pokemonElegido1.Energia -= 25;
                    jug2_espera.Text = "La máquina ha decidido atacar.";
                    jug2_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    if (pokemonElegido.Vida <= 0)
                    {
                        fondo_combate.Visibility = Visibility.Visible;
                        mensaje_victoria.Text = "La máquina ha ganado el combate.";
                        mensaje_victoria.Visibility = Visibility.Visible;
                        new ToastContentBuilder()
                            .AddArgument("action")
                            .AddArgument("conversationId", 9813)
                            .AddText("La máquina ha ganado el combate.")
                            .Show();
                    }
                    else
                    {
                        bloqueo_jug2();
                    }

                }
                else
                {
                    jug2_espera.Text = "La máquina no tiene suficiente energía.";
                    jug2_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    bloqueo_jug2();
                }
            }
        }
        public async void curar2()
        {
            if (cont2 == 1)
            {
                jug2_espera.Text = "La máquina no tiene pociones.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();

            }
            else
            {
                if (pokemonElegido1.Vida > 25)
                {
                    pokemonElegido1.Vida = 100;
                }
                else
                {
                    pokemonElegido1.Vida += 75;
                }
                cont2++;
                jug2_espera.Text = "La máquina ha decidido curarse.";
                pokemonElegido1.verPocionVida(false);
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();
            }
        }
        public async void subirEnergia2()
        {
            if (cont2e == 1)
            {
                jug2_espera.Text = "La máquina no tiene pociones.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();
            }
            else
            {
                if (pokemonElegido1.Energia > 25)
                {
                    pokemonElegido1.Energia = 100;
                }
                else
                {
                    pokemonElegido1.Energia += 75;
                }
                jug2_espera.Text = "La máquina ha decidido subir su energía.";
                pokemonElegido1.verPocionEnergia(false);
                cont2e++;
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();
            }
        }
        public int calcular_daño()
        {
            int dano = 0;
            Random r = new Random();
            int num = r.Next(1, 100);
            if (num < 45)
            {
                dano = 20;
            }
            else if (num <= 90)
            {
                dano = (int)Math.Round((double)num / 3);
            }
            else
            {
                dano = 40;
            }
            return dano;
        }
        private async void btn_atacar1_Click(object sender, RoutedEventArgs e)
        {
            if (defensa1 == true)
            {
                if (pokemonElegido.Energia < 25)
                {
                    pokemonElegido.activarAniIdle(false);
                    pokemonElegido.animacionCansado();
                    jug1_espera.Text = "No tienes suficiente energía.";
                    jug1_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    bloqueo_jug1();
                }
                else
                {
                    pokemonElegido.activarAniIdle(true);
                    pokemonElegido.animacionNoCansado();
                    pokemonElegido.animacionAtaqueFlojo();
                    pokemonElegido.Energia -= 25;
                    pokemonElegido1.Vida -= (calcular_daño() / 4);
                    jug2_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    if (pokemonElegido1.Vida <= 0)
                    {
                        pokemonElegido1.activarAniIdle(false);
                        pokemonElegido1.animacionDerrota();
                        fondo_combate.Visibility = Visibility.Visible;
                        mensaje_victoria.Text = "El J1 ha ganado el combate.";
                        mensaje_victoria.Visibility = Visibility.Visible;
                        new ToastContentBuilder()
                            .AddArgument("action")
                            .AddArgument("conversationId", 9813)
                            .AddText("El J1 ha ganado el combate.")
                            .Show();
                    }
                    else
                    {
                        if (pokemonElegido1.Vida <= 30)
                        {
                            pokemonElegido1.activarAniIdle(false);
                            pokemonElegido1.animacionHerido();
                        }
                        else if (pokemonElegido1.Vida > 30)
                        {
                            pokemonElegido1.animacionNoHerido();
                        }
                        bloqueo_jug1();
                    }
                }
            }
            else
            {
                if (pokemonElegido.Energia < 25)
                {
                    pokemonElegido.activarAniIdle(false);
                    pokemonElegido.animacionCansado();
                    jug1_espera.Text = "No tienes suficiente energía.";
                    jug1_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    bloqueo_jug1();
                }
                else
                {
                    pokemonElegido.activarAniIdle(true);
                    pokemonElegido.animacionNoCansado();
                    pokemonElegido.animacionAtaqueFlojo();
                    pokemonElegido.Energia -= 25;
                    pokemonElegido1.Vida -= (calcular_daño() / 2);
                    jug2_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    if (pokemonElegido1.Vida <= 0)
                    {
                        pokemonElegido1.activarAniIdle(false);
                        pokemonElegido1.animacionDerrota();
                        fondo_combate.Visibility = Visibility.Visible;
                        mensaje_victoria.Text = "El J1 ha ganado el combate.";
                        mensaje_victoria.Visibility = Visibility.Visible;
                        new ToastContentBuilder()
                            .AddArgument("action")
                            .AddArgument("conversationId", 9813)
                            .AddText("El J1 ha ganado el combate.")
                            .Show();
                    }
                    else
                    {
                        if (pokemonElegido1.Vida <= 30)
                        {
                            pokemonElegido1.activarAniIdle(false);
                            pokemonElegido1.animacionHerido();
                        }
                        else if (pokemonElegido1.Vida > 30)
                        {
                            pokemonElegido1.animacionNoHerido();
                        }
                        bloqueo_jug1();
                    }
                }
            }
        }
        private async void btn_curar1_Click(object sender, RoutedEventArgs e)
        {
            if (cont1 == 1)
            {
                jug1_espera.Text = "No tienes pociones de vida.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug1();
            }
            else
            {
                if (pokemonElegido.Vida > 25)
                {
                    pokemonElegido.Vida = 100;
                }
                else
                {
                    pokemonElegido.Vida += 75;
                    pokemonElegido.animacionNoHerido();
                }
                cont1++;
                jug1_espera.Text = "El J1 ha decidido curarse.";
                pokemonElegido.verPocionVida(false);
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug1();
            }
        }
        private async void btn_subirEnergia1_Click(object sender, RoutedEventArgs e)
        {
            if (cont1e == 1)
            {
                jug1_espera.Text = "No tienes pociones de energía.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug1();
            }
            else
            {
                if (pokemonElegido.Energia > 25)
                {
                    pokemonElegido.Energia = 100;
                }
                else
                {
                    pokemonElegido.Energia += 75;
                    pokemonElegido.animacionNoCansado();
                }
                cont1e++;
                jug1_espera.Text = "El J1 ha decidido subir su energía.";
                pokemonElegido.verPocionEnergia(false);
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug1();
            }
        }
        private void btn_rendirse1_Click(object sender, RoutedEventArgs e)
        {
            fondo_combate.Visibility = Visibility.Visible;
            mensaje_victoria.Text = "El J2 ha ganado el combate.";
            mensaje_victoria.Visibility = Visibility.Visible;
            new ToastContentBuilder()
                .AddArgument("action")
                .AddArgument("conversationId", 9813)
                .AddText("El J2 ha ganado el combate.")
                .Show();
        }
        private async void btn_descanso_Click(object sender, RoutedEventArgs e)
        {
            if (pokemonElegido.Energia > 75)
            {
                pokemonElegido.Energia = 100;
                pokemonElegido.animacionDescasar();
            }
            else
            {
                pokemonElegido.Energia += 25;
                pokemonElegido.animacionDescasar();
            }
            jug1_espera.Text = "El J1 ha decidido descansar.";
            jug1_espera.Visibility = Visibility.Visible;
            await Task.Delay(2000);
            bloqueo_jug1();
        }
        private async void btn_defensa1_Click(object sender, RoutedEventArgs e)
        {
            if (pokemonElegido.Energia < 20)
            {
                pokemonElegido.activarAniIdle(false);
                pokemonElegido.animacionCansado();
                jug1_espera.Text = "No tienes suficiente energía.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug1();
            }
            else
            {
                pokemonElegido.Energia -= 20;
                pokemonElegido.animacionDefensa();
            }
            defensa = true;
            jug2_espera.Text = "El J1 ha decidido defenderse.";
            jug2_espera.Visibility = Visibility.Visible;
            await Task.Delay(2000);
            bloqueo_jug1();
        }
        private async void btn_atacar_fuerte_Click(object sender, RoutedEventArgs e)
        {
            if (defensa1 == true)
            {
                if (pokemonElegido.Energia < 25)
                {
                    pokemonElegido.activarAniIdle(false);
                    pokemonElegido.animacionCansado();
                    jug1_espera.Text = "No tienes suficiente energía.";
                    jug1_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    bloqueo_jug1();
                }
                else
                {
                    pokemonElegido.activarAniIdle(true);
                    pokemonElegido.animacionNoCansado();
                    pokemonElegido.animacionAtaqueFuerte();
                    pokemonElegido.Energia -= 25;
                    pokemonElegido1.Vida -= (calcular_daño()/2);
                    jug2_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    if (pokemonElegido1.Vida <= 0)
                    {
                        pokemonElegido1.activarAniIdle(false);
                        pokemonElegido1.animacionDerrota();
                        fondo_combate.Visibility = Visibility.Visible;
                        mensaje_victoria.Text = "El J1 ha ganado el combate.";
                        mensaje_victoria.Visibility = Visibility.Visible;
                        new ToastContentBuilder()
                            .AddArgument("action")
                            .AddArgument("conversationId", 9813)
                            .AddText("El J1 ha ganado el combate.")
                            .Show();
                    }
                    else
                    {
                        if (pokemonElegido1.Vida <= 30)
                        {
                            pokemonElegido1.activarAniIdle(false);
                            pokemonElegido1.animacionHerido();
                        }
                        else if (pokemonElegido1.Vida > 30)
                        {
                            pokemonElegido1.animacionNoHerido();
                        }
                        bloqueo_jug1();
                    }
                }
            }
            else
            {
                if (pokemonElegido.Energia < 25)
                {
                    pokemonElegido.activarAniIdle(false);
                    pokemonElegido.animacionCansado();
                    jug1_espera.Text = "No tienes suficiente energía.";
                    jug1_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    bloqueo_jug1();
                }
                else
                {
                    pokemonElegido.activarAniIdle(true);
                    pokemonElegido.animacionNoCansado();
                    pokemonElegido.animacionAtaqueFuerte();
                    pokemonElegido.Energia -= 25;
                    pokemonElegido1.Vida -= (calcular_daño());
                    jug2_espera.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    if (pokemonElegido1.Vida <= 0)
                    {
                        pokemonElegido1.activarAniIdle(false);
                        pokemonElegido1.animacionDerrota();
                        fondo_combate.Visibility = Visibility.Visible;
                        mensaje_victoria.Text = "El J1 ha ganado el combate.";
                        mensaje_victoria.Visibility = Visibility.Visible;
                        new ToastContentBuilder()
                            .AddArgument("action")
                            .AddArgument("conversationId", 9813)
                            .AddText("El J1 ha ganado el combate.")
                            .Show();
                    }
                    else
                    {
                        if (pokemonElegido1.Vida <= 30)
                        {
                            pokemonElegido1.activarAniIdle(false);
                            pokemonElegido1.animacionHerido();
                        }
                        else if (pokemonElegido1.Vida > 30)
                        {
                            pokemonElegido1.animacionNoHerido();
                        }
                        bloqueo_jug1();
                    }
                }

            }
        }
        public async void defender()
        {
            if (pokemonElegido1.Energia < 20)
            {
                pokemonElegido1.animacionCansado();
                jug2_espera.Text = "La máquina no tiene energia.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();
            }
            else
            {
                pokemonElegido1.animacionDefensa();
                defensa1 = true;
                jug2_espera.Text = "La máquina ha decidido defenderse.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();
                
            }
        }
        public async void descansar() {            
            if (pokemonElegido1.Energia > 75)
            {
                pokemonElegido1.Energia = 100;
                pokemonElegido1.animacionDescasar();
            }
            else
            {
                pokemonElegido1.Energia += 25;
                pokemonElegido1.animacionDescasar();
            }
            jug2_espera.Text = "La máquina ha decidido descansar.";
            jug2_espera.Visibility = Visibility.Visible;
            await Task.Delay(2000);
            bloqueo_jug2();
        }   
    }
}
