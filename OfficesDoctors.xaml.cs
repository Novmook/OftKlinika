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
    /// Логика взаимодействия для OfficesDoctors.xaml
    /// </summary>
    public partial class OfficesDoctors : Window
    {
        public OfficesDoctors()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OftKlinika.OftKlinDataSet oftKlinDataSet = ((OftKlinika.OftKlinDataSet)(this.FindResource("oftKlinDataSet")));
            // Загрузить данные в таблицу Table. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter oftKlinDataSetTableTableAdapter = new OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter();
            oftKlinDataSetTableTableAdapter.Fill(oftKlinDataSet.Table);
            System.Windows.Data.CollectionViewSource tableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableViewSource")));
            tableViewSource.View.MoveCurrentToFirst();
            //
            OftKlinika.OftKlinDataSet6 oftKlinDataSet6 = ((OftKlinika.OftKlinDataSet6)(this.FindResource("oftKlinDataSet6")));
            // Загрузить данные в таблицу ReserveTable. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet6TableAdapters.ReserveTableTableAdapter oftKlinDataSet6ReserveTableTableAdapter = new OftKlinika.OftKlinDataSet6TableAdapters.ReserveTableTableAdapter();
            oftKlinDataSet6ReserveTableTableAdapter.Fill(oftKlinDataSet6.ReserveTable);
            System.Windows.Data.CollectionViewSource reserveTableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reserveTableViewSource")));
            reserveTableViewSource.View.MoveCurrentToFirst();
            //
            консультацияLabel.Content = oftKlinDataSet6.Tables[0].Rows[0][1].ToString();
            провглазногоднаLabel.Content = oftKlinDataSet6.Tables[0].Rows[1][1].ToString();
            проверказренияLabel.Content = oftKlinDataSet6.Tables[0].Rows[2][1].ToString();
            биомикроскопияLabel.Content = oftKlinDataSet6.Tables[0].Rows[3][1].ToString();
            гониоскопияLabel.Content = oftKlinDataSet6.Tables[0].Rows[4][1].ToString();
            инстилляциялекарстваLabel.Content = oftKlinDataSet6.Tables[0].Rows[5][1].ToString();
            определениеостротызренияLabel.Content = oftKlinDataSet6.Tables[0].Rows[6][1].ToString();
            определениеуглакосоглазияLabel.Content = oftKlinDataSet6.Tables[0].Rows[7][1].ToString();
            определениецветоощущенияLabel.Content = oftKlinDataSet6.Tables[0].Rows[8][1].ToString();
            подборочковLabel.Content = oftKlinDataSet6.Tables[0].Rows[9][1].ToString();
        }
    }
}
