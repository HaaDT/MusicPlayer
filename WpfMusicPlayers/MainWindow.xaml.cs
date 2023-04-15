using MaterialDesignThemes.Wpf;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfMusicPlayers.cs;


namespace WpfMusicPlayers
{
    public partial class MainWindow : Window
    {


        bool ativo = false;
        static List<musica> osts = new List<musica>();
        int numero = 0;
        WaveOutEvent player = new WaveOutEvent();



        //adicionar ost novas
        void adicionar(string a, string b, string c, string d)
        {
            musica ost = new musica();
            ost.path = a;
            ost.icon = b;
            ost.nome = c;
            ost.artista = d;
            osts.Add(ost);
        }

        void musica()
        {
            player.Stop();
            imImagemTocando.Source = new BitmapImage(new Uri(@"/Imagens/" + osts[numero - 1].icon, UriKind.Relative));
            tbArtistaTocando.Text = osts[numero - 1].artista;
            tbMusicaTocando.Text = osts[numero - 1].nome;
            player.Init(new AudioFileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + osts[numero - 1].path, UriKind.Relative).ToString()));
            player.Play();
        }

        public MainWindow()
        {
            adicionar("dp.mp3", "iconDp.jpg", "Departure", "Masatoshi Ono");
            adicionar("esoc.mp3", "iconEsoc.jpg", "Eu Sou o Caos", "Júlio Victor");
            adicionar("ml.mp3", "iconMl.png", "Megalovania", "Toby Fox");
            adicionar("ms.mp3", "iconMs.jpeg", "Melissa", "Porno Graffitti");
            adicionar("uc.mp3", "iconUc.jpg", "Universal Collapse", "DM DOKURO");
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
            if (numero > 1)
            {
                numero--;
                musica();
            }
            else
            {
                numero = 5;
                musica();
            }
        }

        //Botão de avançar uma Música
        private void btAvancarMusica_Click(object sender, RoutedEventArgs e)
        {
            if (numero < 5)
            {
                numero++;
                musica();
            }
            else
            {
                numero = 1;
                musica();
            }
        }

        //Botão que alterna entre pausar e tocar as Músics
        private void btPausarETocar_Click(object sender, RoutedEventArgs e)
        {
            if (!ativo)
            {
                ativo = true;
                iconPausarETocar.Kind = PackIconKind.Pause;
                if (numero == 0)
                {
                    numero = 1;
                    musica();
                }
                player.Play();
            }
            else
            {
                ativo = false;
                player.Pause();
                iconPausarETocar.Kind = PackIconKind.Play;
            }
        }

        //Botão que Toca a música 1
        private void musica1_Selected(object sender, RoutedEventArgs e)
        {
            numero = 1;
            ativo = true;
            musica();
        }

        //Botão que Toca a música 2
        private void musica2_Selected(object sender, RoutedEventArgs e)
        {
            numero = 2;
            ativo = true;
            musica();
        }

        //Botão que Toca a música 3
        private void musica3_Selected(object sender, RoutedEventArgs e)
        {
            numero = 3;
            ativo = true;
            musica();
        }

        //Botão que Toca a música 4
        private void musica4_Selected(object sender, RoutedEventArgs e)
        {
            numero = 4;
            ativo = true;
            musica();
        }

        //Botão que Toca a música 5
        private void musica5_Selected(object sender, RoutedEventArgs e)
        {
            numero = 5;
            ativo = true;
            musica();
        }

        //mover pela tela
        private void WPFMusicPlayer_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

        private void musica1_Loaded(object sender, RoutedEventArgs e)
        {
            imMusica1.Source = new BitmapImage(new Uri(@"/Imagens/" + osts[0].icon, UriKind.Relative));
            tbArtista1.Text = osts[0].artista;
            tbMusica1.Text = osts[0].nome;
            duracaoMusica1.Text = 0 + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + osts[0].path, UriKind.Relative).ToString()).TotalTime.Minutes.ToString() + ":" + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + osts[0].path, UriKind.Relative).ToString()).TotalTime.Seconds.ToString();
        }

        private void musica2_Loaded(object sender, RoutedEventArgs e)
        {
            imMusica2.Source = new BitmapImage(new Uri(@"/Imagens/" + osts[1].icon, UriKind.Relative));
            tbArtista2.Text = osts[1].artista;
            tbMusica2.Text = osts[1].nome;
            duracaoMusica2.Text = 0 + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + osts[1].path, UriKind.Relative).ToString()).TotalTime.Minutes.ToString() + ":" + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + osts[1].path, UriKind.Relative).ToString()).TotalTime.Seconds.ToString();
        }

        private void musica3_Loaded(object sender, RoutedEventArgs e)
        {
            imMusica3.Source = new BitmapImage(new Uri(@"/Imagens/" + osts[2].icon, UriKind.Relative));
            tbArtista3.Text = osts[2].artista;
            tbMusica3.Text = osts[2].nome;
            duracaoMusica3.Text = 0 + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + osts[2].path, UriKind.Relative).ToString()).TotalTime.Minutes.ToString() + ":" + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + osts[2].path, UriKind.Relative).ToString()).TotalTime.Seconds.ToString();
        }

        private void musica4_Loaded(object sender, RoutedEventArgs e)
        {
            imMusica4.Source = new BitmapImage(new Uri(@"/Imagens/" + osts[3].icon, UriKind.Relative));
            tbArtista4.Text = osts[3].artista;
            tbMusica4.Text = osts[3].nome;
            duracaoMusica4.Text = 0 + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + osts[3].path, UriKind.Relative).ToString()).TotalTime.Minutes.ToString() + ":" + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + osts[3].path, UriKind.Relative).ToString()).TotalTime.Seconds.ToString();
        }

        private void musica5_Loaded(object sender, RoutedEventArgs e)
        {
            imMusica5.Source = new BitmapImage(new Uri(@"/Imagens/" + osts[4].icon, UriKind.Relative));
            tbArtista5.Text = osts[4].artista;
            tbMusica5.Text = osts[4].nome;
            duracaoMusica5.Text = 0 + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + osts[4].path, UriKind.Relative).ToString()).TotalTime.Minutes.ToString() + ":" + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + osts[4].path, UriKind.Relative).ToString()).TotalTime.Seconds.ToString();
        }
    }
}
