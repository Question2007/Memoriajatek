using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memoriajatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> meretek = new List<string>() { "2x2", "4x4", "6x6" };
        List<string> jatekok = new List<string>() { "Számok", "Smile-K", "Országok és Fővárosaik" };
        Dictionary<string, string> OrszagVarosok = new Dictionary<string, string>()
                {
                    {"Magyarország","Budapest" },
                    {"Németország","Berlin" },
                    {"Franciaország","Párizs" },
                    {"Olaszország","Róma" },
                    {"Spanyolország","Madrid" },
                    {"Portugália","Lisszabon" },
                    {"Ausztria","Bécs" },
                    {"Svájc","Bern" },
                    {"Lengyelország","Varsó" },
                    {"Csehország","Prága" },
                    {"Szlovákia","Pozsony" },
                    {"Románia","Bukarest" },
                    {"UK","London" },
                    {"USA","Washington D.C." },
                    {"Kanada","Ottawa" },
                    {"Japán","Tokió" },
                    {"Ausztrália","Canberra" },
                    {"Brazília","Brasília" },

                };

        int score;
        public MainWindow()
        {
            InitializeComponent();
            lbox_meret.ItemsSource = meretek;
            lbox_games.ItemsSource = jatekok;
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            string meret = lbox_meret.SelectedItem as string;
            string jatek = lbox_games.SelectedItem as string;

            score = 0;
            tb_Score.Text = "Próbálkozás: 0";
            if (meret != null && jatek != null)
            {
                string grid_szam = meret.Substring(2);
                Grid_Elhelyezese(int.Parse(grid_szam), jatek);

            }
            else
            {
                MessageBox.Show("Kérlek válassz egy játékot és egy méretet!");
            }
        }


        private void Grid_Elhelyezese(int meret, string jatek)
        {
            
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < meret; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            Jatek_Valasztas(jatek, meret);
        }


        private void Jatek_Valasztas(string jatek, int meret)
        {

            if (jatek == "Számok")
            {
                List<int> szamok = new List<int>();
                for (int i = 1; i <= meret * meret / 2; i++)
                {
                    szamok.Add(i);
                    szamok.Add(i);
                }
                szamok = szamok.Shuffle().ToList();
                int index = 0;
                for (int i = 0; i < meret; i++)
                {
                    for (int j = 0; j < meret; j++)
                    {


                        Button btn = new Button
                        {
                            Name = "btn_" + szamok[index++].ToString(),
                            Content = "?",
                            FontSize = 20,
                            FontWeight = FontWeights.Bold,
                            Margin = new Thickness(3),
                            Foreground = Brushes.White,
                            DataContext = null,
                            Background = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.5, 0),
                                EndPoint = new Point(0.5, 1),
                                GradientStops =
                                {
                                    new GradientStop(Color.FromArgb(255, 68, 35, 76), 0),
                                    new GradientStop(Color.FromArgb(255, 201, 62, 234), 1)
                                }
                            }

                        };

                        btn.Click += Button_Click;

                        Grid.SetRow(btn, i);
                        Grid.SetColumn(btn, j);

                        GameGrid.Children.Add(btn);
                    }
                }

            }
            else if (jatek == "Országok és Fővárosaik")
            {
                
                List<string> Cc = new List<string>() { };

                foreach (var item in OrszagVarosok.Take(meret*meret/2))
                {
                    Cc.Add(item.Key);
                    Cc.Add(item.Value);
                }
                Cc = Cc.Shuffle().ToList();
                int index = 0;
                for (int i = 0; i < meret; i++)
                {
                    for (int j = 0; j < meret; j++)
                    {


                        Button btn = new Button
                        {
                            //Name = Cc[index++].ToString(),
                            Content = "?",
                            FontSize = 20,
                            FontWeight = FontWeights.Bold,
                            Margin = new Thickness(3),
                            DataContext = Cc[index++].ToString(),
                            Foreground = Brushes.White,
                            Background = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.5, 0),
                                EndPoint = new Point(0.5, 1),
                                GradientStops =
                                {
                                    new GradientStop(Color.FromArgb(255, 68, 35, 76), 0),
                                    new GradientStop(Color.FromArgb(255, 201, 62, 234), 1)
                                }
                            }
                        };

                        btn.Click += Button_Click;

                        Grid.SetRow(btn, i);
                        Grid.SetColumn(btn, j);

                        GameGrid.Children.Add(btn);
                    }
                }

            }
            else if (jatek == "Smile-K")
            {
                List<string> emojik = new List<string>() { "😀", "😶‍🌫️", "😄", "😁", "😆", "😅", "😂", "🤣", "😍", "😱", "💀", "👽", "🤖", "👾", "💩", "🥸", "🤬", "😎" };
                List<string> smilek = new List<string>() { };

                for (int i = 1; i <= meret * meret / 2; i++)
                {
                    smilek.Add(emojik[i]);
                    smilek.Add(emojik[i]);
                }
                smilek = smilek.Shuffle().ToList();
                int index = 0;
                for (int i = 0; i < meret; i++)
                {
                    for (int j = 0; j < meret; j++)
                    {


                        Button btn = new Button
                        {
                            //Name = "btn_" + index++,
                            Content = "?",
                            FontSize = 20,
                            FontWeight = FontWeights.Bold,
                            Margin = new Thickness(3),
                            DataContext = smilek[index++],
                            Foreground = Brushes.White,
                            Background = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.5, 0),
                                EndPoint = new Point(0.5, 1),
                                GradientStops =
                                {
                                    new GradientStop(Color.FromArgb(255, 68, 35, 76), 0),
                                    new GradientStop(Color.FromArgb(255, 201, 62, 234), 1)
                                }
                            }
                        };

                        btn.Click += Button_Click;

                        Grid.SetRow(btn, i);
                        Grid.SetColumn(btn, j);

                        GameGrid.Children.Add(btn);
                    }
                }

            }

        }
        string elozo_btn = null;
        Button elozo = null;    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbox_games.SelectedItem == "Országok és Fővárosaik")
            {
                Button button = (Button)sender;
                if (button.DataContext == null)
                {
                    button.Content = button.Name.Split("_")[1];
                }
                else
                {
                    button.Content = button.DataContext.ToString();
                }
                //button.Content = button.Name.Split("_")[1];
                //button.Content = button.DataContext.ToString();
                string felirat = button.Content.ToString();
                if (button != null)
                {
                    button.Background = Brushes.LightPink;
                }
                if (elozo_btn == null)
                {
                    elozo_btn = felirat;
                    elozo = button;
                    button.Background = Brushes.LightPink;
                    elozo.Background = Brushes.LightPink;
                }
                else
                {
                    bool talalat = 
                        (OrszagVarosok.ContainsKey(elozo_btn) && OrszagVarosok[elozo_btn] == felirat || OrszagVarosok.ContainsKey(felirat) && OrszagVarosok[felirat] == elozo_btn);
                    if (talalat)
                    {
                        MessageBox.Show("Talált páros!");
                        elozo_btn = null;
                        button.IsEnabled = false;
                        elozo.IsEnabled = false;
                        button.Foreground = Brushes.LightGreen;
                        elozo.Foreground = Brushes.LightGreen;
                        button.Background = Brushes.LightPink;
                        elozo.Background = Brushes.LightPink;
                        score++;
                        tb_Score.Text = "Próbálkozás: " + score;
                    }
                    else
                    {
                        MessageBox.Show("Nem talált páros!");
                        elozo_btn = null;
                        button.Content = "?";
                        elozo.Content = "?";
                        button.Background = Background = new LinearGradientBrush
                        {
                            StartPoint = new Point(0.5, 0),
                            EndPoint = new Point(0.5, 1),
                            GradientStops =
                                {
                                    new GradientStop(Color.FromArgb(255, 68, 35, 76), 0),
                                    new GradientStop(Color.FromArgb(255, 201, 62, 234), 1)
                                }
                        };
                        elozo.Background = Background = new LinearGradientBrush
                        {
                            StartPoint = new Point(0.5, 0),
                            EndPoint = new Point(0.5, 1),
                            GradientStops =
                                {
                                    new GradientStop(Color.FromArgb(255, 68, 35, 76), 0),
                                    new GradientStop(Color.FromArgb(255, 201, 62, 234), 1)
                                }
                        };
                        score++;
                        tb_Score.Text = "Próbálkozás: " + score;
                    }
                }
            }
            else
            {
                Button button = (Button)sender;
                if (button.DataContext == null)
                {
                    button.Content = button.Name.Split("_")[1];
                }
                else
                {
                    button.Content = button.DataContext.ToString();
                }
                //button.Content = button.Name.Split("_")[1];
                //button.Content = button.DataContext.ToString();
                string felirat = button.Content.ToString();
                if (button != null)
                {
                    button.Background = Brushes.LightPink;
                }
                if (elozo_btn == null)
                {
                    elozo_btn = felirat;
                    elozo = button;
                    button.Background = Brushes.LightPink;
                    elozo.Background = Brushes.LightPink;
                }
                else if (elozo_btn == felirat)
                {
                    MessageBox.Show("Talált páros!");
                    elozo_btn = null;
                    button.IsEnabled = false;
                    elozo.IsEnabled = false;
                    button.Foreground = Brushes.LightGreen;
                    elozo.Foreground = Brushes.LightGreen;
                    button.Background = Brushes.LightPink;
                    elozo.Background = Brushes.LightPink;
                    score++;
                    tb_Score.Text = "Próbálkozás: " + score;
                }
                else
                {
                    MessageBox.Show("Nem talált páros!");
                    elozo_btn = null;
                    button.Content = "?";
                    elozo.Content = "?";
                    button.Background = Background = new LinearGradientBrush
                    {
                        StartPoint = new Point(0.5, 0),
                        EndPoint = new Point(0.5, 1),
                        GradientStops =
                                {
                                    new GradientStop(Color.FromArgb(255, 68, 35, 76), 0),
                                    new GradientStop(Color.FromArgb(255, 201, 62, 234), 1)
                                }
                    };
                    elozo.Background = Background = new LinearGradientBrush
                    {
                        StartPoint = new Point(0.5, 0),
                        EndPoint = new Point(0.5, 1),
                        GradientStops =
                                {
                                    new GradientStop(Color.FromArgb(255, 68, 35, 76), 0),
                                    new GradientStop(Color.FromArgb(255, 201, 62, 234), 1)
                                }
                    };
                    score++;
                    tb_Score.Text = "Próbálkozás: " + score;
                }
            }
            

        }
    }
}