using System.Windows;

namespace Enarmad_Bandit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string name1;
        private static string country;
        private static string securitynr;
        private static string tele;

        public static string Name1 { get => name1; }
        public static string Country { get => country; }
        public static string Securitynr { get => securitynr; }
        public static string Tele { get => tele; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            name1 = txtName.Text;
            country = txtCountry.Text;
            securitynr = txtSecurityNr.Text;
            tele = txtTele.Text;


            new Gameboard().Show();
            this.Close();

        }
    }
}


