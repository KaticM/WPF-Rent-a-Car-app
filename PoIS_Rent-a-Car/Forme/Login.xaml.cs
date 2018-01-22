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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using BespokeFusion;

namespace PoIS_Rent_a_Car.Forme
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        // *** Uncomment ***
        //public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public Boolean getin = false;
        private void btLogin_Click(object sender,RoutedEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            AdminMain adminMain = new AdminMain();
            adminMain.ShowDialog();
        }/* *** Verification code from the database ***
        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                string pass = "select Login_ID from Login where [user]='"+txtUser.Text+"' and pass='"+txtPassword.Password.ToString()+"'";
                SqlCommand command = new SqlCommand(pass, konekcija);
                SqlDataReader reader = command.ExecuteReader();
                string correct = "";
                while (reader.Read())
                {
                    correct = reader[0].ToString();
                    if(reader!=null)
                    {
                        getin = true;
                        break;
                    }
                }
                reader.Close();
                

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                
                if (getin==true)
                {
                    this.Close();
                    MainWindow main = new MainWindow();
                    AdminMain adminMain = new AdminMain();
                    adminMain.ShowDialog();
                }
                else
                {
                    var msg = new CustomMaterialMessageBox
                    {
                        Width = 300,
                        Height = 150,
                        TxtMessage = { Text = "The username or password is incorrect!", Foreground = Brushes.Crimson },
                        TxtTitle = { Text = "Login", Foreground = Brushes.White, Background = Brushes.Crimson },
                        BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                        BtnCancel = { Width = 0, Height = 0, Content = null },
                        BtnOk = { Background = Brushes.Crimson, Content = "Try Again!", Width = 130 },
                        TitleBackgroundPanel = { Background = Brushes.Crimson },
                        BorderBrush = Brushes.Crimson
                    };
                    msg.Show();
                    txtPassword.Clear(); txtUser.Clear();
                }
            }
    }
        */
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void btForgot_Click(object sender, RoutedEventArgs e)
        {/* *** Uncomment ***
            try
            {
                konekcija.Open();
                string login = "select [user],pass from Login";
                SqlCommand command = new SqlCommand(login, konekcija);
                SqlDataReader reader = command.ExecuteReader();
                string user = "";
                string pass = "";
                while (reader.Read())
                {
                    user = reader[0].ToString();
                    pass = reader[1].ToString();
                }
                reader.Close();
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "Username: "+user+"\nPassword: "+pass, Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Login", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                    BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                    BtnCancel = { Width = 0, Height = 0, Content = null },
                    BtnOk = { Background = Brushes.BlueViolet, },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                msg.Show();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
         */   
        }
    }
}
