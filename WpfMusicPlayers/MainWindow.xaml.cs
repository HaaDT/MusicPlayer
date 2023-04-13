using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfMusicPlayers.cs;

namespace WpfMusicPlayers
{
    public partial class MainWindow : Window
    {

        MediaPlayer player = new MediaPlayer();
        bool ativo = false;
        static List<musica> osts = new List<musica>();
        int numero = 1;
        public void adicionar(string a, string b, string c, string d, string e)
        {
            musica ost = new musica();
            ost.path = a;
            ost.icon = b;
            ost.nome = c;
            ost.artista = d;
            ost.tempo = e;
            osts.Add(ost);
        }

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
            if (numero > 1) numero--;
        }

        //Botão de avançar uma Música
        private void btAvancarMusica_Click(object sender, RoutedEventArgs e)
        {
            if (numero < 5) numero++;
        }

        //Botão que alterna entre pausar e tocar as Músics
        private void btPausarETocar_Click(object sender, RoutedEventArgs e)
        {
            if (!ativo)
            {
                player.Play();
                ativo = true;
            }
            else
            {
                player.Pause();
                ativo = false;
            }
        }

        //Botão que Toca a música 1
        private void musica1_Selected(object sender, RoutedEventArgs e)
        {
            numero = 1;
            imImagemTocando.Source = new BitmapImage(new Uri(@"/Imagens/icons/iconDp.png", UriKind.Relative));
        }

        //Botão que Toca a música 2
        private void musica2_Selected(object sender, RoutedEventArgs e)
        {
            numero = 2;
            imImagemTocando.Source = new BitmapImage(new Uri(@"/Imagens/icons/iconEsoc.jpg", UriKind.Relative));
        }

        //Botão que Toca a música 3
        private void musica3_Selected(object sender, RoutedEventArgs e)
        {
            numero = 3;
            imImagemTocando.Source = new BitmapImage(new Uri(@"/Imagens/icons/iconMl.jpg", UriKind.Relative));
        }

        //Botão que Toca a música 4
        private void musica4_Selected(object sender, RoutedEventArgs e)
        {
            numero = 4;
            imImagemTocando.Source = new BitmapImage(new Uri(@"/Imagens/icons/iconMs.jpeg", UriKind.Relative));
        }

        //Botão que Toca a música 5
        private void musica5_Selected(object sender, RoutedEventArgs e)
        {
            numero = 5;
            imImagemTocando.Source = new BitmapImage(new Uri(@"/Imagens/icons/iconTrodt.jpg", UriKind.Relative));
        }
    }
}
