using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace OftKlinika
{
    /// <summary>
    /// Логика взаимодействия для BDform.xaml
    /// </summary>
    public partial class BDform : System.Windows.Window
    {

        public BDform()
        {
            InitializeComponent();
            binddatagrid();
        }

        private void binddatagrid()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OftKlin.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [Table]";
            cmd.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            da.Fill(dt);

            tableDataGrid.ItemsSource = dt.DefaultView;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OftKlinika.OftKlinDataSet oftKlinDataSet = ((OftKlinika.OftKlinDataSet)(this.FindResource("oftKlinDataSet")));
            // Загрузить данные в таблицу Table. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter oftKlinDataSetTableTableAdapter = new OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter();
            oftKlinDataSetTableTableAdapter.Fill(oftKlinDataSet.Table);
            System.Windows.Data.CollectionViewSource tableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableViewSource")));
            tableViewSource.View.MoveCurrentToFirst();
            OftKlinika.OftKlinDataSet1 oftKlinDataSet1 = ((OftKlinika.OftKlinDataSet1)(this.FindResource("oftKlinDataSet1")));
            // Загрузить данные в таблицу Uslugi. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet1TableAdapters.UslugiTableAdapter oftKlinDataSet1UslugiTableAdapter = new OftKlinika.OftKlinDataSet1TableAdapters.UslugiTableAdapter();
            oftKlinDataSet1UslugiTableAdapter.Fill(oftKlinDataSet1.Uslugi);
            System.Windows.Data.CollectionViewSource uslugiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uslugiViewSource")));
            uslugiViewSource.View.MoveCurrentToFirst();
            OftKlinika.OftKlinDataSet2 oftKlinDataSet2 = ((OftKlinika.OftKlinDataSet2)(this.FindResource("oftKlinDataSet2")));
            // Загрузить данные в таблицу tbl_Login. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet2TableAdapters.tbl_LoginTableAdapter oftKlinDataSet2tbl_LoginTableAdapter = new OftKlinika.OftKlinDataSet2TableAdapters.tbl_LoginTableAdapter();
            oftKlinDataSet2tbl_LoginTableAdapter.Fill(oftKlinDataSet2.tbl_Login);
            System.Windows.Data.CollectionViewSource tbl_LoginViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tbl_LoginViewSource")));
            tbl_LoginViewSource.View.MoveCurrentToFirst();
            OftKlinika.OftKlinDataSet4 oftKlinDataSet4 = ((OftKlinika.OftKlinDataSet4)(this.FindResource("oftKlinDataSet4")));
            // Загрузить данные в таблицу Personal. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet4TableAdapters.PersonalTableAdapter oftKlinDataSet4PersonalTableAdapter = new OftKlinika.OftKlinDataSet4TableAdapters.PersonalTableAdapter();
            oftKlinDataSet4PersonalTableAdapter.Fill(oftKlinDataSet4.Personal);
            System.Windows.Data.CollectionViewSource personalViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personalViewSource")));
            personalViewSource.View.MoveCurrentToFirst();
            //
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void FitToContent()
        {
            // where dg is my data grid name...
            foreach (DataGridColumn column in tableDataGrid.Columns)
            {
                //if you want to size your column as per the cell content
                column.Width = new DataGridLength(1.0, DataGridLengthUnitType.SizeToCells);
                //if you want to size your column as per the column header
                column.Width = new DataGridLength(1.0, DataGridLengthUnitType.SizeToHeader);
                //if you want to size your column as per both header and cell content
                column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
            }
        }

        private void ZapisUsl_Click(object sender, RoutedEventArgs e)
        {
            BDSpisokAdmin bd = new BDSpisokAdmin();
            bd.ShowDialog();
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

            for (int i = 0; i < tableDataGrid.Items.Count; i++)
            {
                DataRowView row = tableDataGrid.Items[i] as DataRowView;

                for (int j = 0; j < tableDataGrid.Columns.Count; j++)
                {
                    if (bl)
                    {
                        range = (Excel.Range)sheet1.Cells[1, j + 1];
                        range.Font.Bold = true;
                        range.Value = tableDataGrid.Columns[j].Header;
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

        private void NewSotr_Click(object sender, RoutedEventArgs e)
        {
            Checkinstaff ch = new Checkinstaff();
            ch.ShowDialog();
        }

        private void ZapisUsl_Copy_Click(object sender, RoutedEventArgs e)
        {
            MedCard md = new MedCard();
            md.ShowDialog();
        }

        private void Excel2Tab_Click(object sender, RoutedEventArgs e)
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

        private void Excel3Tab_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            workbook.Sheets.Add(Type.Missing);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];
            Excel.Range range;
            Excel.Range myRange;
            bool bl = true;

            for (int i = 0; i < tbl_LoginDataGrid.Items.Count; i++)
            {
                DataRowView row = tbl_LoginDataGrid.Items[i] as DataRowView;

                for (int j = 0; j < tbl_LoginDataGrid.Columns.Count; j++)
                {
                    if (bl)
                    {
                        range = (Excel.Range)sheet1.Cells[1, j + 1];
                        range.Font.Bold = true;
                        range.Value = tbl_LoginDataGrid.Columns[j].Header;
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

        private void MouseLeftBtnDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
            //public static class My_DataTable_Extensions
            //{


            //    // Export DataTable into an excel file with field names in the header line
            //    // - Save excel file without ever making it visible if filepath is given
            //    // - Don't save excel file, just make it visible if no filepath is given
            //    public static void ExportToExcel(this System.Data.DataTable tbl, string excelFilePath = @"\" + "Price.xlsx")
            //    {

            //        try
            //        {
            //            if (tbl == null || tbl.Columns.Count == 0)
            //                throw new Exception("ExportToExcel: Null or empty input table!\n");

            //            // load excel, and create a new workbook
            //            var excelApp = new Excel.Application();
            //            excelApp.Workbooks.Add();

            //            // single worksheet
            //            Excel._Worksheet workSheet = excelApp.ActiveSheet;

            //            // column headings
            //            for (var i = 0; i < tbl.Columns.Count; i++)
            //            {
            //                workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
            //            }

            //            // rows
            //            for (var i = 0; i < tbl.Rows.Count; i++)
            //            {
            //                // to do: format datetime values before printing
            //                for (var j = 0; j < tbl.Columns.Count; j++)
            //                {
            //                    workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
            //                }
            //            }

            //            // check file path
            //            if (!string.IsNullOrEmpty(excelFilePath))
            //            {
            //                try
            //                {
            //                    workSheet.SaveAs(excelFilePath);
            //                    excelApp.Quit();
            //                    MessageBox.Show("Excel file saved!");
            //                }
            //                catch (Exception ex)
            //                {
            //                    throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
            //                                        + ex.Message);
            //                }
            //            }

            //        }
            //        catch (Exception ex)
            //        {
            //            throw new Exception("ExportToExcel: \n" + ex.Message);
            //        }
            //    }
            //}
