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
using BespokeFusion;

namespace PoIS_Rent_a_Car.Forme
{
    /// <summary>
    /// Interaction logic for Rezervacija.xaml
    /// </summary>
    public partial class Rezervacija : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public bool fine = false;
        public Rezervacija()
        {
            InitializeComponent();
            try
            {
                konekcija.Open();
                string backCustomers = "select Customer_ID,Name+' '+[Last Name] as Customer from Customer";
                DataTable data = new DataTable();
                SqlDataAdapter sql = new SqlDataAdapter(backCustomers, konekcija);
                sql.Fill(data);
                cbCustomer.ItemsSource = data.DefaultView;

                string backEmployee = "select Employee_ID,Name+' '+[Last Name] as Employee from Employee";
                DataTable dataEmp = new DataTable();
                SqlDataAdapter sqlEmp = new SqlDataAdapter(backEmployee, konekcija);
                sqlEmp.Fill(dataEmp);
                cbEmployee.ItemsSource = dataEmp.DefaultView;

                string backVehicle = "select Vehicle_ID,Make+' '+ Model as Vehicle from Vehicle";
                DataTable dataVeh = new DataTable();
                SqlDataAdapter sqlVeh = new SqlDataAdapter(backVehicle, konekcija);
                sqlVeh.Fill(dataVeh);
                cbVehicle.ItemsSource = dataVeh.DefaultView;

                string backInsurance = "select Insurance_ID,Type+' '+Cast(Price as nvarchar(10)) as Insurance from Insurance";
                DataTable dataIns = new DataTable();
                SqlDataAdapter sqlIns = new SqlDataAdapter(backInsurance, konekcija);
                sqlIns.Fill(dataIns);
                cbInsurance.ItemsSource = dataIns.DefaultView;
            }
            catch (SqlException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "Something went wrong.", Foreground = Brushes.BlueViolet },
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

            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btAddNewCus_Click(object sender, RoutedEventArgs e)
        {
            Korisnik korisnik = new Korisnik();
            korisnik.Show();
        }


        private void btAddNewEmp_Click(object sender, RoutedEventArgs e)
        {
            Zaposleni zaposleni = new Zaposleni();
            zaposleni.Show();
        }

        private void btAddNewVeh_Click(object sender, RoutedEventArgs e)
        {
            Vozilo vozilo = new Vozilo();
            vozilo.Show();
        }

       
        private void cbVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Convert.ToInt32(cbVehicle.SelectedValue);
            string showVeh= "select Vehicle_ID as ID, Make,Model,Price as [€ per day],Air,Type,Seats,GearBox,Consum from Vehicle where Vehicle_ID=" + index;
            DataTable dataShowVeh = new DataTable();
            SqlDataAdapter sqlShowVeh = new SqlDataAdapter(showVeh, konekcija);
            sqlShowVeh.Fill(dataShowVeh);
            dgVehicle.ItemsSource = dataShowVeh.DefaultView;
        }
        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            Check();

            if (fine == true)
            {
                double total = Total(Price(), Days(), Extras());
                var message = new CustomMaterialMessageBox
                {
                    Width = 360,
                    Height = 280,
                    TxtTitle = { Text = "Total Rent Costs", Foreground = Brushes.White },
                    TxtMessage = { Text = "Customer: "+cbCustomer.Text+"\nSelected Vehicle: "+cbVehicle.Text+"     "+Price()+" € cost per day\nTotal Days: "+Days()+"\nNumber of Extras: "+Extras()+" x 10 € each" +
                "\nInsurance: "+cbInsurance.Text+"€ \n\nTOTAL= "+total+" €" },
                    BtnOk = { Background = Brushes.Crimson, Content = "Rent" },
                    BtnCancel = { Background = Brushes.BlueViolet, Content = "Cancel" },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                message.Show();
                string result = Convert.ToString(message.Result);
                if (result == "OK")
                {
                    ADD(total);
                    this.Close();
                }
            }
        }
        private void ADD(double total)
        {
            
            try
            {
                
                konekcija.Open();
                if (AdminMain.izmeni)
                {
                    DataRowView row = (DataRowView)AdminMain.forma;
                    string select = "select Extras_ID from Reservation where Reservation_ID="+row["ID"];
                    SqlCommand command = new SqlCommand(select, konekcija);
                    SqlDataReader reader = command.ExecuteReader();
                    string idextras = "";
                    while (reader.Read())
                    {
                        idextras = reader[0].ToString();

                    }
                    reader.Close();

                    string extras = @"Update Extras set Wifi='" + Convert.ToString(chWiFi.IsChecked.Value) + "',RoofBox='" + Convert.ToString(chRoof.IsChecked.Value) + "',Booster='" + Convert.ToString(chBooster.IsChecked.Value) + "',GPS='" + Convert.ToString(chGPS.IsChecked.Value) + "',BikeRack='" + Convert.ToString(chBike.IsChecked.Value) + "',Fuel='" + Convert.ToString(chFuel.IsChecked.Value) + "',Phone='" + Convert.ToString(chPhone.IsChecked.Value) + "',BabySeat='" + Convert.ToString(chBaby.IsChecked.Value) + "',Winter='" + Convert.ToString(chWinter.IsChecked.Value) + "' where Extras_ID=" + idextras;
                    SqlCommand sqlextras = new SqlCommand(extras, konekcija);
                    sqlextras.ExecuteNonQuery();
                    string upit = @"Update Reservation Set [Pick Date]='" + dpPickTime.Text + "' , [Pick Location] = '" + cbPickupLoc.Text + "', [Return Date] = '" + dpReturnTime.Text +
                                    "', [Return Location]='" + cbReturnLoc.Text + "' , Price ='" + Convert.ToString(total) + "',Customer_ID='" + cbCustomer.SelectedValue + "', Employee_ID='" + cbEmployee.SelectedValue + "',Vehicle_ID='" + cbVehicle.SelectedValue +"',Insurance_ID='"+cbInsurance.SelectedValue+"' Where Reservation_ID=" + row["ID"];
                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                    AdminMain.forma = null;

                }
                else
                {
                    string extras = @"insert into Extras(WiFi,RoofBox,Booster,GPS,BikeRack,Fuel,Phone,BabySeat,Winter)
                        values ('" + Convert.ToString(chBaby.IsChecked.Value) + "','" + Convert.ToString(chWiFi.IsChecked.Value) + "','" + Convert.ToString(chFuel.IsChecked.Value) + "','" + Convert.ToString(chBike.IsChecked.Value) + "','" + Convert.ToString(chGPS.IsChecked.Value) + "','" + Convert.ToString(chWinter.IsChecked.Value) + "','" + Convert.ToString(chBooster.IsChecked.Value) + "','" + Convert.ToString(chRoof.IsChecked.Value) + "','" + Convert.ToString(chPhone.IsChecked.Value) + "');";
                    SqlCommand sqlextras = new SqlCommand(extras, konekcija);
                    sqlextras.ExecuteNonQuery();
                    
                    string select = "select IDENT_CURRENT('Extras')";
                    SqlCommand command = new SqlCommand(select, konekcija);
                    SqlDataReader reader = command.ExecuteReader();
                    string id = "";
                    while (reader.Read())
                    {
                        id = reader[0].ToString();

                    }
                    reader.Close();
                    string insert = @"insert into Reservation([Pick Date],[Pick Location],[Return Date],[Return Location],Customer_ID,Employee_ID,Vehicle_ID,Insurance_ID,Price,Extras_ID)
                        values ('" + dpPickTime.Text + "','" + cbPickupLoc.Text + "','" + dpReturnTime.Text + "','" + cbReturnLoc.Text + "'," + cbCustomer.SelectedValue + "," + cbEmployee.SelectedValue + "," + cbVehicle.SelectedValue + "," + cbInsurance.SelectedValue +","+Convert.ToString(total)+","+id+ ");";
                    SqlCommand sql = new SqlCommand(insert, konekcija);
                    sql.ExecuteNonQuery();
                    
                    var msg = new CustomMaterialMessageBox
                    {
                        Width = 300,
                        Height = 150,
                        TxtMessage = { Text = "New reservation is added to the database.", Foreground = Brushes.BlueViolet },
                        TxtTitle = { Text = "Reservation", Foreground = Brushes.White, Background = Brushes.BlueViolet },
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
                this.Close();
            }
        }
        public int Days()
        {
            
            DateTime pick = Convert.ToDateTime(dpPickTime.SelectedDate);
            DateTime retu = Convert.ToDateTime(dpReturnTime.SelectedDate);
            double days = (retu - pick).TotalDays;
            return Convert.ToInt32(days);
            
        }
        public int Price()
        {
            string result = "0";
            try
            {
                int index = Convert.ToInt32(cbVehicle.SelectedValue);
                string price = "select Price from Vehicle where Vehicle_ID=" + index;
                SqlCommand cmd = new SqlCommand(price, konekcija);
                konekcija.Open();
                string getValue = cmd.ExecuteScalar().ToString();
                if (getValue != null)
                {
                    result = getValue.ToString();
                    
                }
                konekcija.Close();
                return Convert.ToInt32(result);

            }
            catch (System.NullReferenceException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "Something went wrong.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Reservation", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                    BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                    BtnCancel = { Width = 0, Height = 0, Content = null },
                    BtnOk = { Background = Brushes.BlueViolet, },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                msg.Show();
                return 0;
            }
            catch(InvalidOperationException)
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "Something went wrong.", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Reservation", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                    BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                    BtnCancel = { Width = 0, Height = 0, Content = null },
                    BtnOk = { Background = Brushes.BlueViolet, },
                    TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                    BorderBrush = Brushes.BlueViolet
                };
                msg.Show();
                return 0;
            }
            
            
        }
        public double Total(int price,int days,int extras)
        {
            double total = 0;
            string insurance = cbInsurance.Text;
            string[] ins = insurance.Split(' ');
            total = Convert.ToDouble(ins.Last()) + extras * 10 + price * days;
            return total;
        }
        public int Extras()

        {
            int numext = 0;
            if (chWinter.IsChecked == true)
                numext++;
            if (chWiFi.IsChecked == true)
                numext++;
            if (chRoof.IsChecked == true)
                numext++;
            if (chPhone.IsChecked == true)
                numext++;
            if (chGPS.IsChecked == true)
                numext++;
            if (chBooster.IsChecked == true)
                numext++;
            if (chBike.IsChecked == true)
                numext++;
            if (chBaby.IsChecked == true)
                numext++;
            if (chFuel.IsChecked == true)
                numext++;

            return numext;
        }
        public void Check()
        {
            if (Days() >0)
            {
                if (cbCustomer.SelectedValue == null || cbEmployee.SelectedValue == null || cbInsurance.SelectedValue==null 
                    || cbPickupLoc.SelectedValue==null || cbReturnLoc.SelectedValue==null || cbVehicle.SelectedValue==null )
                {
                    var msg = new CustomMaterialMessageBox
                    {
                        Width = 300,
                        Height = 150,
                        TxtMessage = { Text = "Please complete all fields!", Foreground = Brushes.BlueViolet },
                        TxtTitle = { Text = "Reservation", Foreground = Brushes.White, Background = Brushes.BlueViolet },
                        BtnCopyMessage = { Width = 0, Height = 0, Content = null },
                        BtnCancel = { Width = 0, Height = 0, Content = null },
                        BtnOk = { Background = Brushes.BlueViolet, },
                        TitleBackgroundPanel = { Background = Brushes.BlueViolet },
                        BorderBrush = Brushes.BlueViolet
                    };
                    msg.Show();
                }
                else
                {
                    fine = true;
                }
            }
            else
            {
                var msg = new CustomMaterialMessageBox
                {
                    Width = 300,
                    Height = 150,
                    TxtMessage = { Text = "Select correct dates!", Foreground = Brushes.BlueViolet },
                    TxtTitle = { Text = "Reservation", Foreground = Brushes.White, Background = Brushes.BlueViolet },
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
}
