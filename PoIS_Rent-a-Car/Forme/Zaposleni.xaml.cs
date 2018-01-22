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
using PoIS_Rent_a_Car.Forme;

namespace PoIS_Rent_a_Car.Forme
{
    /// <summary>
    /// Interaction logic for Zaposleni.xaml
    /// </summary>
    public partial class Zaposleni : Window
    {
        public Zaposleni()
        {
            InitializeComponent();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public SqlConnection konekcija=Konekcija.KreirajKonekciju();
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string gender =RadioButtonGender();
                konekcija.Open();
                if (AdminMain.izmeni)
                {
                    DataRowView row = (DataRowView)AdminMain.forma;

                    string upit = @"Update Employee Set Name ='" + txtName.Text + "' , [Last Name] = '" + txtSecond.Text + "', [Birth Date] = '" + dataBirth.Text +
                                    "', City='"+cbCity.Text + "' , [e-mail] ='" + txtEmail.Text + "',Phone='" + txtPhone.Text + "', Gender='" + gender + "',[Job Title]='"+cbTitle.Text+"',[Employment Type]='"+cbType.Text+"' Where Employee_ID=" + row["ID"];

                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                    AdminMain.forma = null;

                }
                else
                {
                    string insert = @"insert into Employee(Name,[Last Name],[Birth Date],Gender,Phone,[e-mail],City,[Job Title],[Employment Type])
                                values ('" + txtName.Text + "','" + txtSecond.Text + "','" + dataBirth.Text + "','" + gender + "','" + txtPhone.Text + "','" + txtEmail.Text + "','" + cbCity.Text + "','" + cbTitle.Text + "','" + cbType.Text + "');";
                    SqlCommand sql = new SqlCommand(insert, konekcija);
                    sql.ExecuteNonQuery();
                    var msg = new CustomMaterialMessageBox
                    {
                        Width = 300,
                        Height = 150,
                        TxtMessage = { Text = "New employee is added to the database.", Foreground = Brushes.BlueViolet },
                        TxtTitle = { Text = "Employee", Foreground = Brushes.White, Background = Brushes.BlueViolet },
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
                    TxtTitle = { Text = "Employee", Foreground = Brushes.White, Background = Brushes.BlueViolet },
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
