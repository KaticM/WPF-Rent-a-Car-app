using BespokeFusion;
using PoIS_Rent_a_Car.Forme;
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


namespace PoIS_Rent_a_Car
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            App.Current.Shutdown();
        }

        private void btAdmin_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
        private void btUser_Click(object sender,RoutedEventArgs e)
        {
            var msg = new CustomMaterialMessageBox
            {
                Width = 300,
                Height = 150,
                TxtMessage = { Text = "Please select admin.", Foreground = Brushes.BlueViolet },
                TxtTitle = { Text = "User", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                BtnCancel = { Width = 0, Height = 0, Content = null },
                BtnOk = { Background = Brushes.BlueViolet, },
                TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                BorderBrush = Brushes.BlueViolet
            };
            msg.Show();
        }
        
    }
}
