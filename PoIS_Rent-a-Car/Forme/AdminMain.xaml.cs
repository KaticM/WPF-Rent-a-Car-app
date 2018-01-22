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
using System.Windows.Media.Animation;
using BespokeFusion;
using System.Data;
using System.Data.SqlClient;

namespace PoIS_Rent_a_Car.Forme
{
    /// <summary>
    /// Interaction logic for AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public static bool izmeni;
        public static object forma;
        public AdminMain()
        {
            InitializeComponent();
            beginning(dgAdmin);
        }
        private void beginning(DataGrid dgAdmin)
        {
            try
            {
                string upit = "select Reservation_ID as ID, CONVERT(VARCHAR(10),[Pick Date],101) as [Pick-up Date], [Pick Location] as LocationP, CONVERT(VARCHAR(10),[Return Date],101) as [Drop off Date], [Return Location] as LocationD,Vehicle.Make+' '+Vehicle.Model as Vehicle,Reservation.Price as [Price €], Customer.Name as Customer, Employee.Name as Employee from Reservation " +
                    "inner join Vehicle on Reservation.Vehicle_ID=Vehicle.Vehicle_ID " +
                    "inner join Customer on Reservation.Customer_ID=Customer.Customer_ID " +
                    "inner join Employee on Reservation.Employee_ID=Employee.Employee_ID;";
                SqlDataAdapter puni = new SqlDataAdapter(upit, konekcija);
                
                DataTable data = new DataTable("Rezervacija");
                puni.Fill(data);
                dgAdmin.ItemsSource = data.DefaultView;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            }
            finally
            {
                if(konekcija!=null)
                {
                    konekcija.Close();
                }
               
            }
        }

        private void btRezervacije_Click(object sender, RoutedEventArgs e)
        {
            sakriDugmice("Rezervacija");
            beginning(dgAdmin);
        }

        private void btVozila_Click(object sender, RoutedEventArgs e)
        {
            sakriDugmice("Vozilo");
            try
            {
                string upit = "select Vehicle_ID as ID, Make, Model, Air, Type, GearBox, Seats, Consum, Price as [€ per day] from Vehicle";
                SqlDataAdapter puni = new SqlDataAdapter(upit, konekcija);

                DataTable data = new DataTable("Rezervacija");
                puni.Fill(data);
                dgAdmin.ItemsSource = data.DefaultView;

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

        }

        private void btKorisnici_Click(object sender, RoutedEventArgs e)
        {
            sakriDugmice("Korisnici");
            try
            {
                string upit = "select Customer_ID as ID, Name, [Last Name], CONVERT(VARCHAR(10),[Birth Date],111) as [Birth Date], Gender, Phone, [e-mail], Adress from Customer";
                SqlDataAdapter puni = new SqlDataAdapter(upit, konekcija);

                DataTable data = new DataTable("Rezervacija");
                puni.Fill(data);
                dgAdmin.ItemsSource = data.DefaultView;

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
        }

        private void btZaposleni_Click(object sender, RoutedEventArgs e)
        {
            sakriDugmice("Zaposleni");
            try
            {
                string upit = "select Employee_ID as ID, Name, [Last Name], CONVERT(VARCHAR(10),[Birth Date],111)as [Birth Date], Gender, City, [Job Title], [Employment Type], Phone, [e-mail] from Employee";
                SqlDataAdapter puni = new SqlDataAdapter(upit, konekcija);

                DataTable data = new DataTable("Rezervacija");
                puni.Fill(data);
                dgAdmin.ItemsSource = data.DefaultView;

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
        }

        private void btOsiguranje_Click(object sender, RoutedEventArgs e)
        {
            sakriDugmice("Osiguranje");
            try
            {
                string upit = "select Insurance_ID as ID, Type, Price from Insurance";
                SqlDataAdapter puni = new SqlDataAdapter(upit, konekcija);

                DataTable data = new DataTable("Rezervacija");
                puni.Fill(data);
                dgAdmin.ItemsSource = data.DefaultView;
               
                


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
        }

        private void btDodatnaOprema_Click(object sender, RoutedEventArgs e)
        {
            sakriDugmice("Dodatna");
            try
            {
                
                string upit = "select Reservation_ID as Reservation,Vehicle.Make+' '+Vehicle.Model as Vehicle,Extras.WiFi,Extras.RoofBox,Extras.Booster,Extras.GPS,Extras.BikeRack,Extras.Fuel,Extras.Phone,Extras.BabySeat,Extras.Winter from Reservation " +
                    "inner join Vehicle on Reservation.Vehicle_ID=Vehicle.Vehicle_ID " +
                    "inner join Extras on Reservation.Extras_ID=Extras.Extras_ID;";
                SqlDataAdapter puni = new SqlDataAdapter(upit, konekcija);

                DataTable data = new DataTable("Rezervacija");
                puni.Fill(data);
                dgAdmin.ItemsSource = data.DefaultView;

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

        }

        private void btLogOut_Click(object sender, RoutedEventArgs e)
        {
            var message = new CustomMaterialMessageBox
            {
                Width = 310,Height = 180,
                TxtTitle = { Text = "Confirm Logout", Foreground = Brushes.White },
                TxtMessage = { Text = "Are you sure you want to Logout?" },
                BtnOk = {Background=Brushes.Crimson ,Content = "Yes" },
                BtnCancel = { Background = Brushes.BlueViolet, Content = "No" },
                TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                BorderBrush=Brushes.BlueViolet
            };
            message.Show();
            string result =Convert.ToString(message.Result);
            if(result=="OK")
            {
                this.Close();
            }
         }

        private void btDodajZap_Click(object sender,RoutedEventArgs e)
        {
            Zaposleni zaposleni = new Zaposleni();
            zaposleni.ShowDialog();
            btZaposleni_Click(sender, e);
        }

        private void btDodajOsi_Click(object sender,RoutedEventArgs e)
        {
            Osiguranje osiguranje = new Osiguranje();
            osiguranje.ShowDialog();
            btOsiguranje_Click(sender, e);
        }

        private void btDodajVoz_Click(object sender,RoutedEventArgs e)
        {
            Vozilo vozilo = new Vozilo();
            vozilo.ShowDialog();
            btVozila_Click(sender, e);
        }

        private void btDodajKor_Click(object sender,RoutedEventArgs e)
        {
            Korisnik korisnik = new Korisnik();
            korisnik.ShowDialog();
            btKorisnici_Click(sender, e);
        }

        private void btDodajRez_Click(object sender,RoutedEventArgs e)
        {
            Rezervacija rezervacija = new Rezervacija();
            rezervacija.ShowDialog();
            btRezervacije_Click(sender, e);
        }

        private void btIzmeniRez_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmeni = true;
                Rezervacija rezervacija = new Rezervacija();
                konekcija.Open();
                DataRowView dataRowView = (DataRowView)dgAdmin.SelectedItems[0];
                forma = dataRowView;
                string select = "select * from Reservation where Reservation_ID = " + dataRowView["ID"];
                SqlCommand command = new SqlCommand(select, konekcija);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    rezervacija.dpPickTime.Text = reader["Pick Date"].ToString();
                    rezervacija.dpReturnTime.Text = reader["Return Date"].ToString();
                    rezervacija.cbPickupLoc.Text = reader["Pick Location"].ToString();
                    rezervacija.cbReturnLoc.Text = reader["Return Location"].ToString();
                    rezervacija.cbCustomer.SelectedValue = reader["Customer_ID"].ToString();
                    rezervacija.cbEmployee.SelectedValue = reader["Employee_ID"].ToString();
                    rezervacija.cbVehicle.SelectedValue = reader["Vehicle_ID"].ToString();
                    rezervacija.cbInsurance.SelectedValue = reader["Insurance_ID"].ToString();
                    
                }konekcija.Close();konekcija.Open();
                int index = Convert.ToInt32(rezervacija.cbVehicle.SelectedValue);
                string showVeh = "select Vehicle_ID as ID, Make,Model,Price as [€ per day],Air,Type,Seats,GearBox,Consum from Vehicle where Vehicle_ID=" + index;
                DataTable dataShowVeh = new DataTable();
                SqlDataAdapter sqlShowVeh = new SqlDataAdapter(showVeh, konekcija);
                sqlShowVeh.Fill(dataShowVeh);
                rezervacija.dgVehicle.ItemsSource = dataShowVeh.DefaultView;

                string extras = "select Wifi,RoofBox,Booster,GPS,BikeRack,Fuel,Phone,BabySeat,Winter from Extras where Extras_ID=" + dataRowView["ID"];
                SqlCommand commandExtras = new SqlCommand(extras, konekcija);
                SqlDataReader readerExtras = commandExtras.ExecuteReader();

                while(readerExtras.Read())
                {
                    rezervacija.chWiFi.IsChecked = Convert.ToBoolean(readerExtras["WiFi"]);
                    rezervacija.chRoof.IsChecked = Convert.ToBoolean(readerExtras["RoofBox"]);
                    rezervacija.chBooster.IsChecked = Convert.ToBoolean(readerExtras["Booster"]);
                    rezervacija.chGPS.IsChecked = Convert.ToBoolean(readerExtras["GPS"]);
                    rezervacija.chBike.IsChecked = Convert.ToBoolean(readerExtras["BikeRack"]);
                    rezervacija.chFuel.IsChecked = Convert.ToBoolean(readerExtras["Fuel"]);
                    rezervacija.chPhone.IsChecked = Convert.ToBoolean(readerExtras["Phone"]);
                    rezervacija.chBaby.IsChecked = Convert.ToBoolean(readerExtras["BabySeat"]);
                    rezervacija.chWinter.IsChecked = Convert.ToBoolean(readerExtras["Winter"]);

                }
                rezervacija.ShowDialog();

            }
            catch (ArgumentOutOfRangeException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "You didnt select a row.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Reservation", Foreground = Brushes.White, Background = Brushes.BlueViolet },
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
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btRezervacije_Click(sender, e);
                izmeni = false;
            }
        }

        private void btIzmeniZap_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmeni = true;
                Zaposleni zaposleni= new Zaposleni();
                konekcija.Open();
                DataRowView dataRowView = (DataRowView)dgAdmin.SelectedItems[0];
                forma = dataRowView;
                string select = "select Name,[Last Name],[Birth Date],[Phone],[e-mail],Gender,City,[Job Title],[Employment Type] from Employee where Employee_ID = " + dataRowView["ID"];
                SqlCommand command = new SqlCommand(select, konekcija);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    zaposleni.txtName.Text = reader["Name"].ToString();
                    zaposleni.txtSecond.Text = reader["Last Name"].ToString();
                    zaposleni.dataBirth.Text = reader["Birth Date"].ToString();
                    zaposleni.txtPhone.Text = reader["Phone"].ToString();
                    zaposleni.txtEmail.Text = reader["e-mail"].ToString();
                    zaposleni.cbCity.Text = reader["City"].ToString();
                    zaposleni.cbTitle.Text = reader["Job Title"].ToString();
                    zaposleni.cbType.Text = reader["Employment Type"].ToString();
                    if (reader["Gender"].ToString() == "Male")
                    {
                        zaposleni.rbMale.IsChecked = true;
                    }
                    else
                    {
                        zaposleni.rbFemale.IsChecked = true;
                    }

                }
                zaposleni.ShowDialog();

            }
            catch (ArgumentOutOfRangeException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "You didnt select a row.", Foreground = Brushes.BlueViolet },
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
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btZaposleni_Click(sender, e);
                izmeni = false;
            }
        }

        private void btIzmeniKor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmeni = true;
                Korisnik korisnik = new Korisnik();
                konekcija.Open();
                DataRowView dataRowView = (DataRowView)dgAdmin.SelectedItems[0];
                forma = dataRowView; 
                string select= "select Name,[Last Name],[Birth Date],[Phone],[Adress],[e-mail],Gender from Customer where Customer_ID = " + dataRowView["ID"];
                SqlCommand command = new SqlCommand(select, konekcija);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    korisnik.txtName.Text = reader["Name"].ToString();
                    korisnik.txtSecond.Text = reader["Last Name"].ToString();
                    korisnik.dataBirth.Text = reader["Birth Date"].ToString();
                    korisnik.txtPhone.Text = reader["Phone"].ToString();
                    korisnik.txtAdress.Text = reader["Adress"].ToString();
                    korisnik.txtEmail.Text = reader["e-mail"].ToString();
                    if(reader["Gender"].ToString()=="Male")
                    {
                        korisnik.rbMale.IsChecked = true;
                    }
                    else
                    {
                        korisnik.rbFemale.IsChecked = true;
                    }

                }
                korisnik.ShowDialog();

            }
            catch (ArgumentOutOfRangeException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "You didnt select a row.", Foreground = Brushes.BlueViolet },
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
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btKorisnici_Click(sender, e);
                izmeni= false; 
            }
        }

        private void btIzmeniVoz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmeni = true;
                Vozilo vozilo= new Vozilo();
                konekcija.Open();
                DataRowView dataRowView = (DataRowView)dgAdmin.SelectedItems[0];
                forma = dataRowView;
                string select = "select * from Vehicle where Vehicle_ID = " + dataRowView["ID"];
                SqlCommand command = new SqlCommand(select, konekcija);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    vozilo.cbMake.Text= reader["Make"].ToString();
                    vozilo.txtModel.Text = reader["Model"].ToString();
                    vozilo.chAir.IsChecked= Convert.ToBoolean(reader["Air"]);
                    vozilo.cbType.Text = reader["Type"].ToString();
                    vozilo.cbTransmission.Text = reader["GearBox"].ToString();
                    vozilo.txtFuel.Text = reader["Consum"].ToString();
                    vozilo.txtPrice.Text= reader["Price"].ToString();
                    if(reader["Seats"].ToString()=="2")
                    {
                        vozilo.rbSeats2.IsChecked = true;
                    }else if(reader["Seats"].ToString()=="4")
                    {
                        vozilo.rbSeats4.IsChecked = true;
                    }else
                    {
                        vozilo.rbSeats5.IsChecked = true;
                    }

                
                    
                }
                vozilo.ShowDialog();

            }
            catch (ArgumentOutOfRangeException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "You didnt select a row.", Foreground = Brushes.BlueViolet },
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
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btVozila_Click(sender, e);
                izmeni = false;
            }
        }

        private void btIzmeniOsi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmeni = true;
                Osiguranje osiguranje = new Osiguranje();
                konekcija.Open();
                DataRowView dataRowView = (DataRowView)dgAdmin.SelectedItems[0];
                forma = dataRowView;
                string select = "select Type,Price from Insurance where Insurance_ID = " + dataRowView["ID"];
                SqlCommand command = new SqlCommand(select, konekcija);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    osiguranje.txtType.Text = reader["Type"].ToString();
                    osiguranje.txtCost.Text = reader["Price"].ToString();
                }
                osiguranje.ShowDialog();

            }
            catch (ArgumentOutOfRangeException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "You didnt select a row.", Foreground = Brushes.BlueViolet },
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
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btOsiguranje_Click(sender, e);
                izmeni = false;
            }
        }

        private void btIzbrisiDod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView row = (DataRowView)dgAdmin.SelectedItems[0];
                string delete = @"Delete from Extras Where Extras_ID=" + row["Reservation"];
                var message = new CustomMaterialMessageBox
                {
                    Width = 310,
                    Height = 180,
                    TxtTitle = { Text = "Confirm Delete", Foreground = Brushes.White },
                    TxtMessage = { Text = "Are you sure?\nThis action cannot be undone. " },
                    BtnOk = { Width = 125, Background = Brushes.Crimson, Content = "Yes,Delete It" },
                    BtnCancel = { Width = 90, Background = Brushes.BlueViolet, Content = "Cancel" },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                message.Show();
                string result = Convert.ToString(message.Result);
                if (result == "OK")
                {
                    SqlCommand sql = new SqlCommand(delete, konekcija);
                    sql.ExecuteNonQuery();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "You didnt select a row.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Extras", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                    BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                    BtnCancel = { Width = 0, Height = 0, Content = null },
                    BtnOk = { Background = Brushes.BlueViolet, },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                msg.Show();
            }
            catch (SqlException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "There is a relationship with other tables.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Extras", Foreground = Brushes.White, Background = Brushes.BlueViolet },
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
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btDodatnaOprema_Click(sender, e);
            }
        }

        private void btIzbrisiOsi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView row = (DataRowView)dgAdmin.SelectedItems[0];
                string delete = @"Delete from Insurance Where Insurance_ID=" + row["ID"];
                var message = new CustomMaterialMessageBox
                {
                    Width = 310,
                    Height = 180,
                    TxtTitle = { Text = "Confirm Delete", Foreground = Brushes.White },
                    TxtMessage = { Text = "Are you sure?\nThis action cannot be undone. " },
                    BtnOk = { Width = 125, Background = Brushes.Crimson, Content = "Yes,Delete It" },
                    BtnCancel = { Width=90,Background = Brushes.BlueViolet, Content = "Cancel" },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                message.Show();
                string result = Convert.ToString(message.Result);
                if (result == "OK")
                {
                    SqlCommand sql = new SqlCommand(delete, konekcija);
                    sql.ExecuteNonQuery();
                }
                
            }
            catch (ArgumentOutOfRangeException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "You didnt select a row.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Insurance", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                    BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                    BtnCancel = { Width = 0, Height = 0, Content = null },
                    BtnOk = { Background = Brushes.BlueViolet, },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                msg.Show();
            }
            catch (SqlException)
            {
                var msg=new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "There is a relationship with other tables.", Foreground = Brushes.BlueViolet },
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
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btOsiguranje_Click(sender, e);
            }
        }
        
        private void btIzbrisiKor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView row = (DataRowView)dgAdmin.SelectedItems[0];
                string delete = @"Delete from Customer Where Customer_ID=" + row["ID"];
                var message = new CustomMaterialMessageBox
                {
                    Width = 310,
                    Height = 180,
                    TxtTitle = { Text = "Confirm Delete", Foreground = Brushes.White },
                    TxtMessage = { Text = "Are you sure?\nThis action cannot be undone. " },
                    BtnOk = { Width = 125, Background = Brushes.Crimson, Content = "Yes,Delete It" },
                    BtnCancel = { Width = 90, Background = Brushes.BlueViolet, Content = "Cancel" },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                message.Show();
                string result = Convert.ToString(message.Result);
                if (result == "OK")
                {
                    SqlCommand sql = new SqlCommand(delete, konekcija);
                    sql.ExecuteNonQuery();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "You didnt select a row.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Customer", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                    BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                    BtnCancel = { Width = 0, Height = 0, Content = null },
                    BtnOk = { Background = Brushes.BlueViolet, },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                msg.Show();
            }
            catch (SqlException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "There is a relationship with other tables.", Foreground = Brushes.BlueViolet },
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
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btKorisnici_Click(sender, e);
            }
        }

        private void btIzbrisiRez_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView row = (DataRowView)dgAdmin.SelectedItems[0];
                string delete = @"Delete from Reservation Where Reservation_ID=" + row["ID"];
                var message = new CustomMaterialMessageBox
                {
                    Width = 310,
                    Height = 180,
                    TxtTitle = { Text = "Confirm Delete", Foreground = Brushes.White },
                    TxtMessage = { Text = "Are you sure?\nThis action cannot be undone. " },
                    BtnOk = { Width = 125, Background = Brushes.Crimson, Content = "Yes,Delete It" },
                    BtnCancel = { Width = 90, Background = Brushes.BlueViolet, Content = "Cancel" },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                message.Show();
                string result = Convert.ToString(message.Result);
                if (result == "OK")
                {
                    SqlCommand sql = new SqlCommand(delete, konekcija);
                    sql.ExecuteNonQuery();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "You didnt select a row.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Reservation", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                    BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                    BtnCancel = { Width = 0, Height = 0, Content = null },
                    BtnOk = { Background = Brushes.BlueViolet, },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                msg.Show();
            }
            catch (SqlException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "There is a relationship with other tables.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Reservation", Foreground = Brushes.White, Background = Brushes.BlueViolet },
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
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btRezervacije_Click(sender, e);
            }
        }

        private void btIzbrisiVoz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView row = (DataRowView)dgAdmin.SelectedItems[0];
                string delete = @"Delete from Vehicle Where Vehicle_ID=" + row["ID"];
                var message = new CustomMaterialMessageBox
                {
                    Width = 310,
                    Height = 180,
                    TxtTitle = { Text = "Confirm Delete", Foreground = Brushes.White },
                    TxtMessage = { Text = "Are you sure?\nThis action cannot be undone. " },
                    BtnOk = { Width = 125, Background = Brushes.Crimson, Content = "Yes,Delete It" },
                    BtnCancel = { Width = 90, Background = Brushes.BlueViolet, Content = "Cancel" },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                message.Show();
                string result = Convert.ToString(message.Result);
                if (result == "OK")
                {
                    SqlCommand sql = new SqlCommand(delete, konekcija);
                    sql.ExecuteNonQuery();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "You didnt select a row.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Vehicle", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                    BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                    BtnCancel = { Width = 0, Height = 0, Content = null },
                    BtnOk = { Background = Brushes.BlueViolet, },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                msg.Show();
            }
            catch (SqlException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "There is a relationship with other tables.", Foreground = Brushes.BlueViolet },
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
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btVozila_Click(sender, e);
            }
        }

        private void btIzbrisiZap_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView row = (DataRowView)dgAdmin.SelectedItems[0];
                string delete = @"Delete from Employee Where Employee_ID=" + row["ID"];
                var message = new CustomMaterialMessageBox
                {
                    Width = 310,
                    Height = 180,
                    TxtTitle = { Text = "Confirm Delete", Foreground = Brushes.White },
                    TxtMessage = { Text = "Are you sure?\nThis action cannot be undone. " },
                    BtnOk = { Width = 125, Background = Brushes.Crimson, Content = "Yes,Delete It" },
                    BtnCancel = { Width = 90, Background = Brushes.BlueViolet, Content = "Cancel" },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                message.Show();
                string result = Convert.ToString(message.Result);
                if (result == "OK")
                {
                    SqlCommand sql = new SqlCommand(delete, konekcija);
                    sql.ExecuteNonQuery();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "You didnt select a row.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Employee", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                    BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                    BtnCancel = { Width = 0, Height = 0, Content = null },
                    BtnOk = { Background = Brushes.BlueViolet, },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                msg.Show();
            }
            catch (SqlException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "There is a relationship with other tables.", Foreground = Brushes.BlueViolet },
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
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btZaposleni_Click(sender, e);
            }
        }
        private void sakriDugmice(String button)
        {
            btDodajRez.Visibility = Visibility.Collapsed;
            btIzbrisiRez.Visibility = Visibility.Collapsed;
            btIzmeniRez.Visibility = Visibility.Collapsed;

            btDodajKor.Visibility = Visibility.Collapsed;
            btIzmeniKor.Visibility = Visibility.Collapsed;
            btIzbrisiKor.Visibility = Visibility.Collapsed;

            btIzmeniZap.Visibility = Visibility.Collapsed;
            btIzbrisiZap.Visibility = Visibility.Collapsed;
            btDodajZap.Visibility = Visibility.Collapsed;

            btIzmeniVoz.Visibility = Visibility.Collapsed;
            btIzbrisiVoz.Visibility = Visibility.Collapsed;
            btDodajVoz.Visibility = Visibility.Collapsed;

            btIzbrisiDod.Visibility = Visibility.Collapsed;

            btDodajOsi.Visibility = Visibility.Collapsed;
            btIzmeniOsi.Visibility = Visibility.Collapsed;
            btIzbrisiOsi.Visibility = Visibility.Collapsed;
            
            switch(button)
            {
                case "Rezervacija":
                    {
                        btDodajRez.Visibility = Visibility.Visible;
                        btIzbrisiRez.Visibility = Visibility.Visible;
                        btIzmeniRez.Visibility = Visibility.Visible;
                        break;
                    }
                case "Korisnici":
                    {
                        btDodajKor.Visibility = Visibility.Visible;
                        btIzmeniKor.Visibility = Visibility.Visible;
                        btIzbrisiKor.Visibility = Visibility.Visible;
                        break;
                    }
                case "Zaposleni":
                    {
                        btIzmeniZap.Visibility = Visibility.Visible;
                        btIzbrisiZap.Visibility = Visibility.Visible;
                        btDodajZap.Visibility = Visibility.Visible;
                        break;
                    }
                case "Osiguranje":
                    {
                        btDodajOsi.Visibility = Visibility.Visible;
                        btIzmeniOsi.Visibility = Visibility.Visible;
                        btIzbrisiOsi.Visibility = Visibility.Visible;
                        break;
                    }
                case "Dodatna":
                    {
                        btIzbrisiDod.Visibility = Visibility.Visible;
                        break;
                    }
                case "Vozilo":
                    {
                        btIzmeniVoz.Visibility = Visibility.Visible;
                        btIzbrisiVoz.Visibility = Visibility.Visible;
                        btDodajVoz.Visibility = Visibility.Visible;
                        break;
                    }

            }
            
        }
    }
}
