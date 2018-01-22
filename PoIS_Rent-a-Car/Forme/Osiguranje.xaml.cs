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
using System.Data;
using System.Data.SqlClient;

namespace PoIS_Rent_a_Car.Forme
{
    /// <summary>
    /// Interaction logic for Osiguranje.xaml
    /// </summary>
    public partial class Osiguranje : Window
    {
        public Osiguranje()
        {
            InitializeComponent();
        }
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (AdminMain.izmeni)
                {
                    DataRowView row = (DataRowView)AdminMain.forma;
                    string upit = @"Update Insurance Set Type ='" + txtType.Text + "' , Price = '" + txtCost.Text+"' Where Insurance_ID=" + row["ID"];
                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                    AdminMain.forma = null;

                }
                else
                {
                    string insert = @"insert into Insurance(Type,Price)
                        values ('" + txtType.Text + "','" + txtCost.Text + "');";
                    SqlCommand sql = new SqlCommand(insert, konekcija);
                    sql.ExecuteNonQuery();
                    var msg = new CustomMaterialMessageBox
                    {
                        Width = 300,
                        Height = 150,
                        TxtMessage = { Text = "New insurance is added to the database.", Foreground = Brushes.BlueViolet },
                        TxtTitle = { Text = "Insurance", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                        BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                        BtnCancel = { Width = 0, Height = 0, Content = null },
                        BtnOk = { Background = Brushes.BlueViolet, },
                        TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                        BorderBrush = Brushes.BlueViolet
                    };
                    msg.Show();
                }


            }
            catch (SqlException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "Something went wrong.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Insurance", Foreground = Brushes.White, Background = Brushes.BlueViolet },
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

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
