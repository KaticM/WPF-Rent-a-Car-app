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
using System.Data.SqlClient;
using System.Data;

namespace PoIS_Rent_a_Car.Forme
{
    /// <summary>
    /// Interaction logic for Vozilo.xaml
    /// </summary>
    public partial class Vozilo : Window
    {
        public Vozilo()
        {
            InitializeComponent();
        }
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int seats = Seats();
                konekcija.Open();
                if (AdminMain.izmeni)
                {
                    DataRowView row = (DataRowView)AdminMain.forma;

                    string upit = @"Update Vehicle Set Make ='" + cbMake.Text + "' , Model = '" + txtModel.Text + "', Air = '" + Convert.ToString(chAir.IsChecked.Value) +
                                    "', Type='" + cbType.Text + "' , GearBox ='" + cbTransmission.Text + "',Seats='" + seats.ToString() + "', Consum='" + txtFuel.Text+ "',Price='" + txtPrice.Text+"' Where Vehicle_ID=" + row["ID"];

                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                    AdminMain.forma = null;

                }
                else
                {
                    string insert = @"insert into Vehicle(Make,Model,Air,Type,GearBox,Seats,Consum,Price)
                                values ('" + cbMake.Text + "','" + txtModel.Text + "','" + Convert.ToString(chAir.IsChecked.Value) + "','" + cbType.Text + "','" + cbTransmission.Text  + "','" + seats.ToString() + "','" + txtFuel.Text + "','" + txtPrice.Text + "');";
                    SqlCommand sql = new SqlCommand(insert, konekcija);
                    sql.ExecuteNonQuery();
                    var msg = new CustomMaterialMessageBox
                    {
                        Width = 300,
                        Height = 150,
                        TxtMessage = { Text = "New Vehicle is added to the database.", Foreground = Brushes.BlueViolet },
                        TxtTitle = { Text = "Vehicle", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                        BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                        BtnCancel = { Width = 0, Height = 0, Content = null },
                        BtnOk = { Background = Brushes.BlueViolet, },
                        TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                        BorderBrush = Brushes.BlueViolet
                    };
                    msg.Show();
                }
            }
            catch(SqlException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "Something went wrong.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Vehicle", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                    BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                    BtnCancel = { Width = 0, Height = 0, Content = null },
                    BtnOk = { Background = Brushes.BlueViolet, },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                msg.Show();
            }
            finally
            {
                if(konekcija!=null)
                {
                    konekcija.Close();
                }
                this.Close();
            }
            
            
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private int Seats()
        {
            if(rbSeats2.IsChecked==true)
            {
                return 2;
            }
            else if(rbSeats4.IsChecked==true)
            {
                return 4;
            }
            else if(rbSeats5.IsChecked==true)
            {
                return 6;
            }
            return 0;
        }
    }
}
