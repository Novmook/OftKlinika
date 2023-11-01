using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OftKlinika
{
    /// <summary>
    /// Логика взаимодействия для frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
            txtUsername.MaxLength = 7;
            txtPassword.MaxLength = 16;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Password == "")
                System.Windows.MessageBox.Show("Заполните поля", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
            //
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OftKlin.mdf;Integrated Security=True");//Connect Timeout=30
            {                                   //(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Курсовая 0301\OftKlinika\OftKlin.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                string query = "SELECT * FROM tbl_Login WHERE Username='" + txtUsername.Text.Trim() + "'AND Password = '" + txtPassword.Password.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    MainWindow fmMain = new MainWindow();
                    this.Hide();
                    //fmMain.personaIDLabel1.Enabled = false;
                    //fmMain.personaIDLabel1.Visible = false;
                    fmMain.image1.Visibility = Visibility.Hidden;
                    fmMain.image2.Visibility = Visibility.Hidden;
                    fmMain.image1.IsEnabled = false;
                    fmMain.image2.IsEnabled = false;
                    fmMain.image3.Visibility = Visibility.Hidden;
                    fmMain.image3.IsEnabled = false;
                    fmMain.whoIsPersonaLabel1.IsEnabled = false;
                    fmMain.whoIsPersonaLabel1.Visibility = Visibility.Hidden;
                    fmMain.nameAccessLabel1.IsEnabled = false;
                    fmMain.nameAccessLabel1.Visibility = Visibility.Hidden;
                    fmMain.nameAccessLabel2.IsEnabled = false;
                    fmMain.nameAccessLabel2.Visibility = Visibility.Hidden;
                    fmMain.button2.IsEnabled = false;
                    fmMain.button2.Visibility = Visibility.Hidden;
                    fmMain.AdminButton.IsEnabled = false;
                    fmMain.AdminButton.Visibility = Visibility.Hidden;
                    fmMain.ButtonMed.IsEnabled = false;
                    fmMain.ButtonMed.Visibility = Visibility.Hidden;
                    fmMain.button9.IsEnabled = false;
                    fmMain.button9.Visibility = Visibility.Hidden;
                    fmMain.button10.IsEnabled = false;
                    fmMain.button10.Visibility = Visibility.Hidden;
                    fmMain.usernameLabel1.Content = txtUsername.Text.Trim();
                    fmMain.Show();
                }

                else
                {
                    System.Windows.MessageBox.Show("Неверный логин или пароль", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Register rg = new Register();
            rg.ShowDialog();
        }


            private void CloseButton_Click(object sender, RoutedEventArgs e)
            {
            System.Windows.Application.Current.Shutdown();
            }

        private void OuthButton_Click(object sender, RoutedEventArgs e)
        {
            RegAdmin rg = new RegAdmin();
            rg.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }