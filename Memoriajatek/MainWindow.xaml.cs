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
        List<string> meretek = new List<string>() {"2x2", "4x4", "6x6"};
        List<string> jatekok = new List<string>() { "Számok", "Smile-K", "Országok és Fővárosaik" };
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

            if (meret != null && jatek != null)
            {

            }
            else
            {
                MessageBox.Show("Kérlek válassz egy játékot és egy méretet!");
            }
        }
    }
}