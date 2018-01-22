using BespokeFusion;
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
using System.Windows.Shapes;

namespace PoIS_Rent_a_Car.Forme
{
    /// <summary>
    /// Interaction logic for DodatnaOprema.xaml
    /// </summary>
    public partial class DodatnaOprema : Window
    {
        public DodatnaOprema()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            var msg = new CustomMaterialMessageBox
            {
                Width = 300,
                Height = 150,
                TxtMessage = { Text = "New Optional Extras is added to the database.", Foreground = Brushes.BlueViolet },
                TxtTitle = { Text = "Optional Extras", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                BtnCancel = { Width = 0, Height = 0, Content = null },
                BtnOk = { Background = Brushes.BlueViolet, },
                TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                BorderBrush = Brushes.BlueViolet
            };
            msg.Show();
            this.Close();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
