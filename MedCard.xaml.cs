using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace OftKlinika
{
    /// <summary>
    /// Логика взаимодействия для MedCard.xaml
    /// </summary>
    public partial class MedCard : Window
    {
        public MedCard()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OftKlinika.OftKlinDataSet5 oftKlinDataSet5 = ((OftKlinika.OftKlinDataSet5)(this.FindResource("oftKlinDataSet5")));
            // Загрузить данные в таблицу MedicalCard. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet5TableAdapters.MedicalCardTableAdapter oftKlinDataSet5MedicalCardTableAdapter = new OftKlinika.OftKlinDataSet5TableAdapters.MedicalCardTableAdapter();
            oftKlinDataSet5MedicalCardTableAdapter.Fill(oftKlinDataSet5.MedicalCard);
            System.Windows.Data.CollectionViewSource medicalCardViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("medicalCardViewSource")));
            medicalCardViewSource.View.MoveCurrentToFirst();
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

            for (int i = 0; i < medicalCardDataGrid.Items.Count; i++)
            {
                DataRowView row = medicalCardDataGrid.Items[i] as DataRowView;

                for (int j = 0; j < medicalCardDataGrid.Columns.Count; j++)
                {
                    if (bl)
                    {
                        range = (Excel.Range)sheet1.Cells[1, j + 1];
                        range.Font.Bold = true;
                        range.Value = medicalCardDataGrid.Columns[j].Header;
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
            Close();
        }

        private void MouseLeftBtnDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public bool AllowFiltering { get; set; }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {



            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OftKlin.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT Фамилия FROM MedicalCard WHERE Фамилия='a%'";

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable("Table");
            //da.Fill(dt);

            //medicalCardDataGrid.ItemsSource = dt.DefaultView;
        }
    }
    }
