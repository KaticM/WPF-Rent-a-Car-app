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
    /// Interaction logic for Korisnik.xaml
    /// </summary>
    public partial class Korisnik : Window
    {
        public Korisnik()
        {
            InitializeComponent();
        }
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                string gender = RadioButtonGender();
                if (AdminMain.izmeni)
                {
                    DataRowView row= (DataRowView)AdminMain.forma;

                    string upit = @"Update Customer Set Name ='" + txtName.Text + "' , [Last Name] = '" + txtSecond.Text + "', [Birth Date] = '" + dataBirth.Text +
                                    "', Adress = '" + txtAdress.Text + "' , [e-mail] ='" + txtEmail.Text + "',Phone='" + txtPhone.Text +"', Gender='"+gender+ "' Where Customer_ID=" + row["ID"];

                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                    AdminMain.forma = null;
                    
                }
                else
                {

                    

                    string insert = @"insert into Customer(Name,[Last Name],[Birth Date],Gender,Phone,[e-mail],Adress)
                                values ('" + txtName.Text + "','" + txtSecond.Text + "','" + dataBirth.Text + "','" + gender + "','" + txtPhone.Text + "','" + txtEmail.Text + "','" + txtAdress.Text + "');";
                    SqlCommand sql = new SqlCommand(insert, konekcija);
                    sql.ExecuteNonQuery();

                    var msg = new CustomMaterialMessageBox
                    {
                        Width = 300,
                        Height = 150,
                        TxtMessage = { Text = "New Customer is added to the database.", Foreground = Brushes.BlueViolet },
                        TxtTitle = { Text = "Customer", Foreground = Brushes.White, Background = Brushes.BlueViolet },
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
                    TxtTitle = { Text = "Customer", Foreground = Brushes.White, Background = Brushes.BlueViolet },
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

        public string RadioButtonGender()
        {
            if (rbMale.IsChecked == true)
            {
                return (string)rbMale.Content;
            }
            if (rbFemale.IsChecked == true)
            {
                return (string)rbFemale.Content;
            }
            return null;
        }


    }
}
