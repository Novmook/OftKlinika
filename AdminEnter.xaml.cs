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
    /// Логика взаимодействия для AdminEnter.xaml
    /// </summary>
    public partial class AdminEnter : Window
    {
        public AdminEnter()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OftKlin.mdf;Integrated Security=True");
            {
                conn.Open();
                string query = "SELECT * FROM Personal WHERE WhoIsPersona='" + txtUsername.Text.Trim() + "'AND PersonaID = '" + txtPassword.Password.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    BDform bd = new BDform();
                    this.Close();
                    bd.Show();
                }

                else
                {
                    MessageBox.Show("Неправильный логин или пароль", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
