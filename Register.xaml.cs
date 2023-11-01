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
using Xceed.Wpf.Toolkit;

namespace OftKlinika
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OftKlin.mdf;Integrated Security=True;Connect Timeout=30");
        public Register()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public Boolean isUserExists()
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM tbl_Login WHERE Username='" + txtUser.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    System.Windows.MessageBox.Show("Такой логин уже существует", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }

                else
                    return false;
            }
        }

        private void RegisterLoaded(object sender, RoutedEventArgs e)
        {
            RegisterButton.IsEnabled = false;
            RegisterButton.Background = System.Windows.Media.Brushes.Gray;
            OftKlinika.OftKlinDataSet2 oftKlinDataSet2 = ((OftKlinika.OftKlinDataSet2)(this.FindResource("oftKlinDataSet2")));
            // Загрузить данные в таблицу tbl_Login. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet2TableAdapters.tbl_LoginTableAdapter oftKlinDataSet2tbl_LoginTableAdapter = new OftKlinika.OftKlinDataSet2TableAdapters.tbl_LoginTableAdapter();
            oftKlinDataSet2tbl_LoginTableAdapter.Fill(oftKlinDataSet2.tbl_Login);
            System.Windows.Data.CollectionViewSource tbl_LoginViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tbl_LoginViewSource")));
            tbl_LoginViewSource.View.MoveCurrentToFirst();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            OftKlinika.OftKlinDataSet2 oftKlinDataSet2 = ((OftKlinika.OftKlinDataSet2)(this.FindResource("oftKlinDataSet2")));
            // Загрузить данные в таблицу tbl_Login. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet2TableAdapters.tbl_LoginTableAdapter oftKlinDataSet2tbl_LoginTableAdapter = new OftKlinika.OftKlinDataSet2TableAdapters.tbl_LoginTableAdapter();
            oftKlinDataSet2tbl_LoginTableAdapter.Fill(oftKlinDataSet2.tbl_Login);
            oftKlinDataSet2tbl_LoginTableAdapter.Update(oftKlinDataSet2.tbl_Login);

            System.Windows.Data.CollectionViewSource tbl_LoginViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tbl_LoginViewSource")));
            tbl_LoginViewSource.View.MoveCurrentToFirst();
            oftKlinDataSet2.tbl_Login.AcceptChanges();
            if (txtUser.Text == "" || txtPass.Password == "" || nameText.Text == "" || famText.Text == "")
                System.Windows.MessageBox.Show("Пожалуйста, заполните поля", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            //
            //
            else
            {
                if (isUserExists())
                    return;
                //SqlConnection conn = new SqlConnection(connectionString);
                //conn.Open();
                //
                AccessBox.Text = null;

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("AddUser", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Username", txtUser.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPass.Password.Trim());
                    sqlCmd.Parameters.AddWithValue("@Name", nameText.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Surname", famText.Text.Trim());

                    if (sqlCmd.ExecuteNonQuery() == 1)
                        System.Windows.MessageBox.Show("Аккаунт был создан", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        System.Windows.MessageBox.Show("Аккаунт не был создан", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    //Добавлено ниже 19.12.2022
                    
                    sqlCon.Close();
                    //
                    //oftKlinDataSet2tbl_LoginTableAdapter.Insert(txtUser.Text, txtPass.Password, nameText.Text, famText.Text, AccessBox.Text);
                    //oftKlinDataSet2tbl_LoginTableAdapter.Update(oftKlinDataSet2.tbl_Login);
                    //oftKlinDataSet2.AcceptChanges();
                    //System.Windows.MessageBox.Show("Аккаунт был создан", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    Clear();
                    this.Hide();
                }

                void Clear()
                {
                    txtUser.Text = txtPass.Password = nameText.Text = famText.Text = "";

                }
            }
        }

        private void CheckToggle_Checked(object sender, RoutedEventArgs e)
        {
            if(CheckToggle.IsChecked == true)
            {
                RegisterButton.IsEnabled = true;
                RegisterButton.Background = System.Windows.Media.Brushes.SeaGreen;
            }
        }

        private void CheckToogle_UnChecked(object sender, RoutedEventArgs e)
        {
            if (CheckToggle.IsChecked == false)
            {
                RegisterButton.IsEnabled = false;
                RegisterButton.Background = System.Windows.Media.Brushes.Gray;
            }
        }
    }
}
