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
    /// Логика взаимодействия для DoctorDay.xaml
    /// </summary>
    public partial class DoctorDay : Window
    {
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OftKlin.mdf;Integrated Security=True;Connect Timeout=30");
        public DoctorDay()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewSotr_Click(object sender, RoutedEventArgs e)
        {
            if (txtPasients.Text == "" || txtFIO.Text == "" || txtUsluga.Text == "" || txtDate.Text == "")
                MessageBox.Show("Пожалуйста, заполните поля");
            //
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("ReportAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Patients", txtPasients.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Doctor", txtFIO.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Usluga", txtUsluga.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Data", txtDate.Text.Trim());

                if (sqlCmd.ExecuteNonQuery() == 1)
                    MessageBox.Show("Отправлено. Спасибо!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Не удалось отправить отчет. Попробуйте еще раз.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                /*
                reportingTableAdapter.Insert(txtPasients.Text, txtFIO.Text, txtUsluga.Text, txtData.Text);
                this.reportingTableAdapter.Update(this.oftKlinDataSet8.Reporting);
                oftKlinDataSet8.AcceptChanges();
                MessageBox.Show("Спасибо!");*/
                sqlCon.Close();
                Clear();
                this.Hide();
            }
        }

        void Clear()
        {
            txtPasients.Text = txtFIO.Text = txtDate.Text = txtUsluga.Text = "";

        }
    }
}
