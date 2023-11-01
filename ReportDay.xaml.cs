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
    /// Логика взаимодействия для ReportDay.xaml
    /// </summary>
    public partial class ReportDay : Window
    {
        
        public ReportDay()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OftKlinika.OftKlinDataSet8 oftKlinDataSet8 = ((OftKlinika.OftKlinDataSet8)(this.FindResource("oftKlinDataSet8")));
            // Загрузить данные в таблицу Reporting. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet8TableAdapters.ReportingTableAdapter oftKlinDataSet8ReportingTableAdapter = new OftKlinika.OftKlinDataSet8TableAdapters.ReportingTableAdapter();
            oftKlinDataSet8ReportingTableAdapter.Fill(oftKlinDataSet8.Reporting);
            System.Windows.Data.CollectionViewSource reportingViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reportingViewSource")));
            reportingViewSource.View.MoveCurrentToFirst();
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

            for (int i = 0; i < reportingDataGrid.Items.Count; i++)
            {
                DataRowView row = reportingDataGrid.Items[i] as DataRowView;

                for (int j = 0; j < reportingDataGrid.Columns.Count; j++)
                {
                    if (bl)
                    {
                        range = (Excel.Range)sheet1.Cells[1, j + 1];
                        range.Font.Bold = true;
                        range.Value = reportingDataGrid.Columns[j].Header;
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

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            Statistic st = new Statistic();
            st.ShowDialog();
        }
    }
}
