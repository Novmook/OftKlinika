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

namespace OftKlinika
{
    /// <summary>
    /// Логика взаимодействия для Checkinstaff.xaml
    /// </summary>
    public partial class Checkinstaff : Window
    {
        public Checkinstaff()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            OftKlinika.OftKlinDataSet4 oftKlinDataSet4 = ((OftKlinika.OftKlinDataSet4)(this.FindResource("oftKlinDataSet4")));
            // Загрузить данные в таблицу Personal. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet4TableAdapters.PersonalTableAdapter oftKlinDataSet4PersonalTableAdapter = new OftKlinika.OftKlinDataSet4TableAdapters.PersonalTableAdapter();
            oftKlinDataSet4PersonalTableAdapter.Fill(oftKlinDataSet4.Personal);
            System.Windows.Data.CollectionViewSource personalViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personalViewSource")));
            personalViewSource.View.MoveCurrentToFirst();
            //
            if (txtUser.Text == "" || txtPass.Password == "")
                MessageBox.Show("Заполните поля");

            oftKlinDataSet4PersonalTableAdapter.Insert(txtUser.Text, txtPass.Password);
            oftKlinDataSet4PersonalTableAdapter.Update(oftKlinDataSet4.Personal);
            oftKlinDataSet4.AcceptChanges();
            MessageBox.Show("Есть");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OftKlinika.OftKlinDataSet4 oftKlinDataSet4 = ((OftKlinika.OftKlinDataSet4)(this.FindResource("oftKlinDataSet4")));
            // Загрузить данные в таблицу Personal. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet4TableAdapters.PersonalTableAdapter oftKlinDataSet4PersonalTableAdapter = new OftKlinika.OftKlinDataSet4TableAdapters.PersonalTableAdapter();
            oftKlinDataSet4PersonalTableAdapter.Fill(oftKlinDataSet4.Personal);
            System.Windows.Data.CollectionViewSource personalViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personalViewSource")));
            personalViewSource.View.MoveCurrentToFirst();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
