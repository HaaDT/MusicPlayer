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
        static List<musica> musicasList = new List<musica>();

        bool tocandoMusica = false;
        int musicaAtual = 0;

        WaveOutEvent player = new WaveOutEvent(); //Objeto que toca as músicas

        //Adicionar as Músicas a lista
        void AdicionarMusica(string caminho, string imagem, string nome, string artista)
        {
            musica musica = new musica();

            //Define as informações do objeto música
            musica.caminho = caminho;
            musica.imagem = imagem;
            musica.nome = nome;
            musica.artista = artista;

            musicasList.Add(musica);
        }

        void TocarMusica()
        {
            player.Stop();

            //Mostra as informações da música atual na tela
            imImagemTocando.Source = new BitmapImage(new Uri(@"/Imagens/" + musicasList[musicaAtual - 1].imagem, UriKind.Relative));
            tbArtistaTocando.Text = musicasList[musicaAtual - 1].artista;
            tbMusicaTocando.Text = musicasList[musicaAtual - 1].nome;
            player.Init(new AudioFileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + musicasList[musicaAtual - 1].caminho, UriKind.Relative).ToString()));
            
            //Configura o botão de Pausar e Tocar toda vez que uma música nova toca
            tocandoMusica = true;
            iconPausarETocar.Kind = PackIconKind.Pause;

            player.Play();
        }

        public MainWindow()
        {
            //Define as 5 músicas
            AdicionarMusica("dp.mp3", "iconDp.jpg", "Departure", "Masatoshi Ono");
            AdicionarMusica("esoc.mp3", "iconEsoc.jpg", "Eu Sou o Caos", "Júlio Victor");
            AdicionarMusica("ml.mp3", "iconMl.png", "Megalovania", "Toby Fox");
            AdicionarMusica("ms.mp3", "iconMs.jpeg", "Melissa", "Porno Graffitti");
            AdicionarMusica("uc.mp3", "iconUc.jpg", "Universal Collapse", "DM DOKURO");

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
            if (musicaAtual > 1)
            {
                musicaAtual--;
                TocarMusica();
            }
            else
            {
                musicaAtual = 5;
                TocarMusica();
            }
        }

        //Botão de avançar uma Música
        private void btAvancarMusica_Click(object sender, RoutedEventArgs e)
        {
            if (musicaAtual < 5)
            {
                musicaAtual++;
                TocarMusica();
            }
            else
            {
                musicaAtual = 1;
                TocarMusica();
            }
        }

        //Botão que alterna entre pausar e tocar as Músics
        private void btPausarETocar_Click(object sender, RoutedEventArgs e)
        {
            if (!tocandoMusica)
            {
                //Define a música padrão como a primeira música da lista
                if (musicaAtual == 0)
                {
                    musicaAtual = 1;
                    TocarMusica();
                }

                //Configura o botão de Pausar e Tocar
                tocandoMusica = true;
                iconPausarETocar.Kind = PackIconKind.Pause;

                player.Play();
            }
            else
            {
                // Configura o botão de Pausar e Tocar
                tocandoMusica = false;
                iconPausarETocar.Kind = PackIconKind.Play;

                player.Pause();
            }
        }

        //Botão que Toca a música 1
        private void musica1_Selected(object sender, RoutedEventArgs e)
        {
            musicaAtual = 1;
            TocarMusica();
        }

        //Botão que Toca a música 2
        private void musica2_Selected(object sender, RoutedEventArgs e)
        {
            musicaAtual = 2;
            TocarMusica();
        }

        //Botão que Toca a música 3
        private void musica3_Selected(object sender, RoutedEventArgs e)
        {
            musicaAtual = 3;
            TocarMusica();
        }

        //Botão que Toca a música 4
        private void musica4_Selected(object sender, RoutedEventArgs e)
        {
            musicaAtual = 4;
            TocarMusica();
        }

        //Botão que Toca a música 5
        private void musica5_Selected(object sender, RoutedEventArgs e)
        {
            musicaAtual = 5;
            TocarMusica();
        }

        //mover pela tela
        private void WPFMusicPlayer_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

        private void musica1_Loaded(object sender, RoutedEventArgs e)
        {
            imMusica1.Source = new BitmapImage(new Uri(@"/Imagens/" + musicasList[0].imagem, UriKind.Relative));
            tbArtista1.Text = musicasList[0].artista;
            tbMusica1.Text = musicasList[0].nome;
            duracaoMusica1.Text = 0 + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + musicasList[0].caminho, UriKind.Relative).ToString()).TotalTime.Minutes.ToString() + ":" + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + musicasList[0].caminho, UriKind.Relative).ToString()).TotalTime.Seconds.ToString();
        }

        private void musica2_Loaded(object sender, RoutedEventArgs e)
        {
            imMusica2.Source = new BitmapImage(new Uri(@"/Imagens/" + musicasList[1].imagem, UriKind.Relative));
            tbArtista2.Text = musicasList[1].artista;
            tbMusica2.Text = musicasList[1].nome;
            duracaoMusica2.Text = 0 + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + musicasList[1].caminho, UriKind.Relative).ToString()).TotalTime.Minutes.ToString() + ":" + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + musicasList[1].caminho, UriKind.Relative).ToString()).TotalTime.Seconds.ToString();
        }

        private void musica3_Loaded(object sender, RoutedEventArgs e)
        {
            imMusica3.Source = new BitmapImage(new Uri(@"/Imagens/" + musicasList[2].imagem, UriKind.Relative));
            tbArtista3.Text = musicasList[2].artista;
            tbMusica3.Text = musicasList[2].nome;
            duracaoMusica3.Text = 0 + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + musicasList[2].caminho, UriKind.Relative).ToString()).TotalTime.Minutes.ToString() + ":" + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + musicasList[2].caminho, UriKind.Relative).ToString()).TotalTime.Seconds.ToString();
        }

        private void musica4_Loaded(object sender, RoutedEventArgs e)
        {
            imMusica4.Source = new BitmapImage(new Uri(@"/Imagens/" + musicasList[3].imagem, UriKind.Relative));
            tbArtista4.Text = musicasList[3].artista;
            tbMusica4.Text = musicasList[3].nome;
            duracaoMusica4.Text = 0 + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + musicasList[3].caminho, UriKind.Relative).ToString()).TotalTime.Minutes.ToString() + ":" + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + musicasList[3].caminho, UriKind.Relative).ToString()).TotalTime.Seconds.ToString();
        }

        private void musica5_Loaded(object sender, RoutedEventArgs e)
        {
            imMusica5.Source = new BitmapImage(new Uri(@"/Imagens/" + musicasList[4].imagem, UriKind.Relative));
            tbArtista5.Text = musicasList[4].artista;
            tbMusica5.Text = musicasList[4].nome;
            duracaoMusica5.Text = 0 + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + musicasList[4].caminho, UriKind.Relative).ToString()).TotalTime.Minutes.ToString() + ":" + new Mp3FileReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + new Uri(@"musicas/" + musicasList[4].caminho, UriKind.Relative).ToString()).TotalTime.Seconds.ToString();
        }
    }
}
