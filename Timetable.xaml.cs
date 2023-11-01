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
    /// Логика взаимодействия для Timetable.xaml
    /// </summary>
    public partial class Timetable : Window
    {
        public Timetable()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OftKlinika.OftKlinDataSet3 oftKlinDataSet3 = ((OftKlinika.OftKlinDataSet3)(this.FindResource("oftKlinDataSet3")));
            // Загрузить данные в таблицу Timetable. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet3TableAdapters.TimetableTableAdapter oftKlinDataSet3TimetableTableAdapter = new OftKlinika.OftKlinDataSet3TableAdapters.TimetableTableAdapter();
            oftKlinDataSet3TimetableTableAdapter.Fill(oftKlinDataSet3.Timetable);
            System.Windows.Data.CollectionViewSource timetableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("timetableViewSource")));
            timetableViewSource.View.MoveCurrentToFirst();
            //
            понедельникLabel.Content = oftKlinDataSet3.Tables[0].Rows[0][0].ToString();
            ВторникLabel.Content = oftKlinDataSet3.Tables[0].Rows[0][1].ToString();
            СредаLabel.Content = oftKlinDataSet3.Tables[0].Rows[0][2].ToString();
            ЧетвергLabel.Content = oftKlinDataSet3.Tables[0].Rows[0][3].ToString();
            ПятницаLabel.Content = oftKlinDataSet3.Tables[0].Rows[0][4].ToString();
            СубботаВоскресеньеLabel.Content = oftKlinDataSet3.Tables[0].Rows[0][5].ToString();
            ОбедаLabel.Content = oftKlinDataSet3.Tables[0].Rows[0][6].ToString();
        }
    }
}
