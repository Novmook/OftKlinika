using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace OftKlinika
{
    /// <summary>
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
    public partial class Statistic : Window
    {
        public Statistic()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OftKlinika.OftKlinDataSet9 oftKlinDataSet9 = ((OftKlinika.OftKlinDataSet9)(this.FindResource("oftKlinDataSet9")));
            // Загрузить данные в таблицу Uslugi. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet9TableAdapters.UslugiTableAdapter oftKlinDataSet9UslugiTableAdapter = new OftKlinika.OftKlinDataSet9TableAdapters.UslugiTableAdapter();
            oftKlinDataSet9UslugiTableAdapter.Fill(oftKlinDataSet9.Uslugi);
            System.Windows.Data.CollectionViewSource uslugiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uslugiViewSource")));
            uslugiViewSource.View.MoveCurrentToFirst();
            OftKlinika.OftKlinDataSet10 oftKlinDataSet10 = ((OftKlinika.OftKlinDataSet10)(this.FindResource("oftKlinDataSet10")));
            // Загрузить данные в таблицу Statistic. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet10TableAdapters.StatisticTableAdapter oftKlinDataSet10StatisticTableAdapter = new OftKlinika.OftKlinDataSet10TableAdapters.StatisticTableAdapter();
            oftKlinDataSet10StatisticTableAdapter.Fill(oftKlinDataSet10.Statistic);
            System.Windows.Data.CollectionViewSource statisticViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("statisticViewSource")));
            statisticViewSource.View.MoveCurrentToFirst();
        }

        private void Excel1Tab_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            workbook.Sheets.Add(Type.Missing);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];
            Excel.Range range;
            Excel.Range myRange;
            bool bl = true;

            for (int i = 0; i < statisticDataGrid.Items.Count; i++)
            {
                DataRowView row = statisticDataGrid.Items[i] as DataRowView;

                for (int j = 0; j < statisticDataGrid.Columns.Count; j++)
                {
                    if (bl)
                    {
                        range = (Excel.Range)sheet1.Cells[1, j + 1];
                        range.Font.Bold = true;
                        range.Value = statisticDataGrid.Columns[j].Header;
                    }
                    if (row != null && row[j] != null)
                    {
                        myRange = sheet1.Cells[i + 2, j + 1];
                        myRange.Value = row[j].ToString();
                    }
                }
                bl = false;
            }
            excel.Visible = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
