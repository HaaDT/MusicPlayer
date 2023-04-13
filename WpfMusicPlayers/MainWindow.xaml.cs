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

namespace WpfMusicPlayers
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //Botão de fechar o Aplicativo
        private void btFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //Botão de voltar uma Música
        private void btVoltarMusica_Click(object sender, RoutedEventArgs e)
        {

        }

        //Botão de avançar uma Música
        private void btAvancarMusica_Click(object sender, RoutedEventArgs e)
        {

        }

        //Botão que alterna entre pausar e tocar as Músics
        private void btPausarETocar_Click(object sender, RoutedEventArgs e)
        {

        }

        //Botão que Toca a música 1
        private void musica1_Selected(object sender, RoutedEventArgs e)
        {

        }

        //Botão que Toca a música 2
        private void musica2_Selected(object sender, RoutedEventArgs e)
        {

        }

        //Botão que Toca a música 3
        private void musica3_Selected(object sender, RoutedEventArgs e)
        {

        }

        //Botão que Toca a música 4
        private void musica4_Selected(object sender, RoutedEventArgs e)
        {

        }

        //Botão que Toca a música 5
        private void musica5_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
