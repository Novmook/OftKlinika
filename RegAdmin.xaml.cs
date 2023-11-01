using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace OftKlinika
{
    /// <summary>
    /// Логика взаимодействия для RegAdmin.xaml
    /// </summary>
    public partial class RegAdmin : Window
    {
        public RegAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frmLogin fm = new frmLogin();
            fm.Show();
            Close();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e) // ВРАЧ
        {
            if (txtUsername.Text == "" || txtPassword.Password == "")
                MessageBox.Show("Пожалуйста, заполните поля", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            //
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OftKlin.mdf;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM Doctor WHERE NameAccess='" + txtUsername.Text.Trim() + "'AND IDAccess = '" + txtPassword.Password.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    this.Hide();
                    MainWindow us = new MainWindow();
                    us.label8.IsEnabled = false;
                    us.label8.Visibility = Visibility.Hidden;
                    us.usernameLabel1.IsEnabled = false;
                    us.usernameLabel1.Visibility = Visibility.Hidden;
                    //
                    us.whoIsPersonaLabel1.Visibility = Visibility.Hidden;
                    us.whoIsPersonaLabel1.IsEnabled = false;
                    us.nameAccessLabel2.IsEnabled = false;
                    us.nameAccessLabel2.Visibility = Visibility.Hidden;
                    //
                    us.AdminButton.Visibility = Visibility.Hidden;
                    us.AdminButton.IsEnabled = false;
                    us.button7.IsEnabled = false;
                    us.button10.IsEnabled = false;
                    us.button10.Visibility = Visibility.Hidden;
                    us.CovidButton.IsEnabled = false;
                    us.CovidButton.Visibility = Visibility.Hidden;
                    us.welcomeLabel_Copy.Visibility = Visibility.Hidden;
                    Thickness margin = us.welcomeLabel.Margin;
                    margin.Left = 10;
                    us.welcomeLabel.Margin = margin;
                    us.welcomeLabel.Margin = new Thickness(508, 73, 224, 493);
                    us.welcomeLabel.Content = "Добрый день, Врач";
                   // us.personaIDLabel1.Text = txtPassword.Text;
                    us.Show();
                }

                else
                {
                    MessageBox.Show("Проверьте ваш логин или пароль еще раз", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
        }

        private void GlavDoctor_Click(object sender, RoutedEventArgs e) // ГЛАВ ВРАЧ
        {
            if (txtUsername.Text == "" || txtPassword.Password == "")
                MessageBox.Show("Пожалуйста, заполните поля", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OftKlin.mdf;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM GlavDoctor WHERE NameAccess='" + txtUsername.Text.Trim() + "'AND IDAccess = '" + txtPassword.Password.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    this.Hide();
                    MainWindow us = new MainWindow();
                    us.label8.IsEnabled = false;
                    us.label8.Visibility = Visibility.Hidden;
                    us.usernameLabel1.IsEnabled = false;
                    us.usernameLabel1.Visibility = Visibility.Hidden;

                    us.nameAccessLabel1.IsEnabled = false;
                    us.nameAccessLabel1.Visibility = Visibility.Hidden;
                    //
                    //us.yt_Button3.Enabled = false;
                    //us.yt_Button3.Visible = false;
                    us.AdminButton.Visibility = Visibility.Hidden;
                    us.AdminButton.IsEnabled = false;
                    us.button7.IsEnabled = false;
                    us.welcomeLabel_Copy.Visibility = Visibility.Hidden;
                    Thickness margin = us.welcomeLabel.Margin;
                    margin.Left = 10;
                    us.welcomeLabel.Margin = margin;
                    us.welcomeLabel.Margin = new Thickness(508, 73, 224, 493);
                    us.welcomeLabel.Content = "Добрый день, Глав Врач";
                    us.whoIsPersonaLabel1.IsEnabled = false;
                    us.whoIsPersonaLabel1.Visibility = Visibility.Hidden;
                    us.button9.IsEnabled = false;
                    us.button9.Visibility = Visibility.Hidden;


                    //us.personaIDLabel1.Text = txtPassword.Text;
                    us.Show();
                }

                else
                {
                    MessageBox.Show("Проверьте ваш логин или пароль еще раз", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
        }

        private void Admin_Click(object sender, RoutedEventArgs e) // АДМИН
        {
            if (txtUsername.Text == "" || txtPassword.Password == "")
                MessageBox.Show("Пожалуйста, заполните поля");
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OftKlin.mdf;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM Personal WHERE WhoIsPersona='" + txtUsername.Text.Trim() + "'AND PersonaID = '" + txtPassword.Password.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    this.Hide();
                    MainWindow us = new MainWindow();
                    us.label8.IsEnabled = false;
                    us.label8.Visibility = Visibility.Hidden;
                    us.usernameLabel1.IsEnabled = false;
                    us.usernameLabel1.Visibility = Visibility.Hidden;
                    us.nameAccessLabel1.IsEnabled = false;
                    us.nameAccessLabel1.Visibility = Visibility.Hidden;
                    //
                    us.nameAccessLabel2.IsEnabled = false;
                    us.nameAccessLabel2.Visibility = Visibility.Hidden;
                    //
                    us.image1.IsEnabled = false;
                    us.image2.IsEnabled = false;
                    us.image3.IsEnabled = false;
                    us.CovidButton.IsEnabled = false;
                    us.CovidButton.Visibility = Visibility.Hidden;
                    us.button2.IsEnabled = false;
                    us.ButtonMed.IsEnabled = false;
                    us.ButtonMed.Visibility = Visibility.Hidden;
                    us.button9.IsEnabled = false;
                    Thickness margin = us.welcomeLabel.Margin;
                    margin.Left = 10;
                    us.welcomeLabel.Margin = margin;
                    us.welcomeLabel.Margin = new Thickness(508, 73, 224, 493);
                    us.welcomeLabel.Content = "Добрый день, Администратор";
                    us.button10.IsEnabled = false;
                    us.welcomeLabel_Copy.Visibility = Visibility.Hidden;
                    us.button9.IsEnabled = false;
                    us.button9.Visibility = Visibility.Hidden;
                    //us.personaIDLabel1.Text = txtPassword.Text;
                    us.Show();
                }

                else
                {
                    MessageBox.Show("Проверьте ваш логин или пароль еще раз", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
        }
    }
}
