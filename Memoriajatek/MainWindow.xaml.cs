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
            tb_Score.Text = "Score: 0";
            if (meret != null && jatek != null)
            {
                string grid_szam = meret.Substring(2);
                Grid_Elhelyezese(int.Parse(grid_szam));

            }
            else
            {
                MessageBox.Show("Kérlek válassz egy játékot és egy méretet!");
            }
        }


        private void Grid_Elhelyezese(int meret)
        {
            
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < meret; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

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
                        Name = "btn_"+szamok[index++].ToString(),
                        Content = "?",
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(3)
                    };

                    btn.Click += Button_Click;

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);

                    GameGrid.Children.Add(btn);
                }
            }
        }
        string elozo_btn = null;
        Button elozo = null;    
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            button.Content = button.Name.Split("_")[1];
            string felirat = button.Content.ToString();

            if (elozo_btn == null) {
                elozo_btn = felirat;
                elozo = button;
                button.Background = Brushes.LightBlue;
                elozo.Background = Brushes.LightBlue;
            }
            else if (elozo_btn == felirat)
            {
                MessageBox.Show("Talált páros!");
                elozo_btn = null;
                button.IsEnabled = false;
                elozo.IsEnabled = false;
                button.Foreground = Brushes.LightGreen;
                elozo.Foreground = Brushes.LightGreen;
                score++;
                tb_Score.Text = "Score: " + score;
            }
            else
            {
                MessageBox.Show("Nem talált páros!");
                elozo_btn = null;
                button.Content = "?";
                elozo.Content = "?";
                button.Background = Brushes.LightGray;
                elozo.Background = Brushes.LightGray;
            }

        }
    }
}