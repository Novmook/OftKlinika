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
    /// Логика взаимодействия для BDSpisokAdmin.xaml
    /// </summary>
    public partial class BDSpisokAdmin : Window
    {
        public BDSpisokAdmin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OftKlinika.OftKlinDataSet1 oftKlinDataSet1 = ((OftKlinika.OftKlinDataSet1)(this.FindResource("oftKlinDataSet1")));
            // Загрузить данные в таблицу Uslugi. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet1TableAdapters.UslugiTableAdapter oftKlinDataSet1UslugiTableAdapter = new OftKlinika.OftKlinDataSet1TableAdapters.UslugiTableAdapter();
            oftKlinDataSet1UslugiTableAdapter.Fill(oftKlinDataSet1.Uslugi);
            System.Windows.Data.CollectionViewSource uslugiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uslugiViewSource")));
            uslugiViewSource.View.MoveCurrentToFirst();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

            for (int i = 0; i < uslugiDataGrid.Items.Count; i++)
            {
                DataRowView row = uslugiDataGrid.Items[i] as DataRowView;

                for (int j = 0; j < uslugiDataGrid.Columns.Count; j++)
                {
                    if (bl)
                    {
                        range = (Excel.Range)sheet1.Cells[1, j + 1];
                        range.Font.Bold = true;
                        range.Value = uslugiDataGrid.Columns[j].Header;
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

        private void ToHistoryUsl_Click(object sender, RoutedEventArgs e)
        {
            MedCard md = new MedCard();
            md.ShowDialog();
        }

        private void MouseLeftBtnDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
