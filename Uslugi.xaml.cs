using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OftKlinika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //SidePanel.Height = button1.Height;
            //SidePanel.Margin = button1.Margin;
            klinikaabout.IsEnabled = false;
            klinikaabout.Visibility = Visibility.Hidden;
        }


        private void Uslugi_Loaded(object sender, RoutedEventArgs e)
        {
            //
            OftKlinika.OftKlinDataSet2 oftKlinDataSet2 = ((OftKlinika.OftKlinDataSet2)(this.FindResource("oftKlinDataSet2")));
            // Загрузить данные в таблицу tbl_Login. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet2TableAdapters.tbl_LoginTableAdapter oftKlinDataSet2tbl_LoginTableAdapter = new OftKlinika.OftKlinDataSet2TableAdapters.tbl_LoginTableAdapter();
            oftKlinDataSet2tbl_LoginTableAdapter.Fill(oftKlinDataSet2.tbl_Login);
            System.Windows.Data.CollectionViewSource tbl_LoginViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tbl_LoginViewSource")));
            tbl_LoginViewSource.View.MoveCurrentToFirst();
            OftKlinika.OftKlinDataSet oftKlinDataSet = ((OftKlinika.OftKlinDataSet)(this.FindResource("oftKlinDataSet")));
            // Загрузить данные в таблицу Table. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter oftKlinDataSetTableTableAdapter = new OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter();
            oftKlinDataSetTableTableAdapter.Fill(oftKlinDataSet.Table);
            System.Windows.Data.CollectionViewSource tableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableViewSource")));
            tableViewSource.View.MoveCurrentToFirst();
            //
            frmLogin fm = new frmLogin();

            услугиLabel2.Content = oftKlinDataSet.Tables[0].Rows[1][1].ToString();
            услугиLabel3.Content = oftKlinDataSet.Tables[0].Rows[2][1].ToString();
            ценаLabel2.Content = oftKlinDataSet.Tables[0].Rows[1][2].ToString();
            ценаLabel3.Content = oftKlinDataSet.Tables[0].Rows[2][2].ToString();
            //

            SetVisibility(Visibility.Hidden, panel8, panel9, panel10, panel11, panel12, panel13, panel14, backuslugibutton, BackButton, BackButton1, NextButton1, NextButton2);

            OftKlinika.OftKlinDataSet4 oftKlinDataSet4 = ((OftKlinika.OftKlinDataSet4)(this.FindResource("oftKlinDataSet4")));
            // Загрузить данные в таблицу Personal. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet4TableAdapters.PersonalTableAdapter oftKlinDataSet4PersonalTableAdapter = new OftKlinika.OftKlinDataSet4TableAdapters.PersonalTableAdapter();
            oftKlinDataSet4PersonalTableAdapter.Fill(oftKlinDataSet4.Personal);
            System.Windows.Data.CollectionViewSource personalViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personalViewSource")));
            personalViewSource.View.MoveCurrentToFirst();
            OftKlinika.OftKlinDataSet7 oftKlinDataSet7 = ((OftKlinika.OftKlinDataSet7)(this.FindResource("oftKlinDataSet7")));
            // Загрузить данные в таблицу Doctor. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet7TableAdapters.DoctorTableAdapter oftKlinDataSet7DoctorTableAdapter = new OftKlinika.OftKlinDataSet7TableAdapters.DoctorTableAdapter();
            oftKlinDataSet7DoctorTableAdapter.Fill(oftKlinDataSet7.Doctor);
            System.Windows.Data.CollectionViewSource doctorViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("doctorViewSource")));
            doctorViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу GlavDoctor. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet7TableAdapters.GlavDoctorTableAdapter oftKlinDataSet7GlavDoctorTableAdapter = new OftKlinika.OftKlinDataSet7TableAdapters.GlavDoctorTableAdapter();
            oftKlinDataSet7GlavDoctorTableAdapter.Fill(oftKlinDataSet7.GlavDoctor);
            System.Windows.Data.CollectionViewSource glavDoctorViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("glavDoctorViewSource")));
            glavDoctorViewSource.View.MoveCurrentToFirst();
        }




        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            frmLogin fm = new frmLogin();
            fm.Show();
            Close();
        }

        private void Uslugi_Load(object sender, RoutedEventArgs e)
        {
            //OftKlinDataSet data = new OftKlinDataSet();
            //DataColumn dataColumn = new DataColumn();
            //DataRowView rowView = tableDataGrid.SelectedValue as DataRowView;
            //услугиLabel2.Content = rowView[2].ToString();
        }

        private void SetVisibility(Visibility visibility, params UIElement[] elements)
        {
            foreach (UIElement element in elements)
            {
                element.Visibility = visibility;
            }
        }

        private void NextButton(object sender, RoutedEventArgs e)
        {
            OftKlinika.OftKlinDataSet oftKlinDataSet = ((OftKlinika.OftKlinDataSet)(this.FindResource("oftKlinDataSet")));
            // Загрузить данные в таблицу Table. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter oftKlinDataSetTableTableAdapter = new OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter();
            oftKlinDataSetTableTableAdapter.Fill(oftKlinDataSet.Table);
            //
            услугиLabel4.Content = oftKlinDataSet.Tables[0].Rows[3][1].ToString();
            услугиLabel5.Content = oftKlinDataSet.Tables[0].Rows[4][1].ToString();
            ценаLabel4.Content = oftKlinDataSet.Tables[0].Rows[3][2].ToString();
            ценаLabel5.Content = oftKlinDataSet.Tables[0].Rows[4][2].ToString();

            SetVisibility(Visibility.Visible, panel8, panel9, backuslugibutton, NextButton1);
            SetVisibility(Visibility.Hidden, NextButton2, услугиLabel2, услугиLabel3, ценаLabel2, ценаLabel3, panel4, panel5, panel6, plabel1, plabel2, plabel3, panel10, panel11, panel12);


        }

        private void NextButtonN2(object sender, RoutedEventArgs e)
        {
            OftKlinika.OftKlinDataSet oftKlinDataSet = ((OftKlinika.OftKlinDataSet)(this.FindResource("oftKlinDataSet")));
            // Загрузить данные в таблицу Table. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter oftKlinDataSetTableTableAdapter = new OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter();
            oftKlinDataSetTableTableAdapter.Fill(oftKlinDataSet.Table);

            SetVisibility(Visibility.Visible, BackButton, NextButton2, backuslugibutton, panel10, panel11, panel12);

            SetVisibility(Visibility.Hidden, NextButtonN, panel4, panel5, panel6, panel8, panel9);

            услугиLabel6.Text = oftKlinDataSet.Tables[0].Rows[5][1].ToString();
            услугиLabel7.Content = oftKlinDataSet.Tables[0].Rows[6][1].ToString();
            услугиLabel8.Content = oftKlinDataSet.Tables[0].Rows[7][1].ToString();
            ценаLabel6.Content = oftKlinDataSet.Tables[0].Rows[5][2].ToString();
            ценаLabel7.Content = oftKlinDataSet.Tables[0].Rows[6][2].ToString();
            ценаLabel8.Content = oftKlinDataSet.Tables[0].Rows[7][2].ToString();
        }

        private void NextButtonN3(object sender, RoutedEventArgs e)
        {
            OftKlinika.OftKlinDataSet oftKlinDataSet = ((OftKlinika.OftKlinDataSet)(this.FindResource("oftKlinDataSet")));
            // Загрузить данные в таблицу Table. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter oftKlinDataSetTableTableAdapter = new OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter();
            oftKlinDataSetTableTableAdapter.Fill(oftKlinDataSet.Table);
            услугиLabel9.Content = oftKlinDataSet.Tables[0].Rows[8][1].ToString();
            услугиLabel10.Content = oftKlinDataSet.Tables[0].Rows[9][1].ToString();
            ценаLabel9.Content = oftKlinDataSet.Tables[0].Rows[8][2].ToString();
            ценаLabel10.Content = oftKlinDataSet.Tables[0].Rows[9][2].ToString();

            // HIDE
            SetVisibility(Visibility.Hidden, NextButton1, NextButton2, NextButtonN, BackButton, panel4, panel5, panel6, panel8, panel9, panel10, panel11, panel12);

            // VISIBLE
            SetVisibility(Visibility.Visible, BackButton1, backuslugibutton, panel13, panel14);
        }

        private void BackButtonN(object sender, RoutedEventArgs e)
        {
            OftKlinika.OftKlinDataSet oftKlinDataSet = ((OftKlinika.OftKlinDataSet)(this.FindResource("oftKlinDataSet")));
            // Загрузить данные в таблицу Table. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter oftKlinDataSetTableTableAdapter = new OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter();
            oftKlinDataSetTableTableAdapter.Fill(oftKlinDataSet.Table);
            услугиLabel4.Content = oftKlinDataSet.Tables[0].Rows[3][1].ToString();
            услугиLabel5.Content = oftKlinDataSet.Tables[0].Rows[4][1].ToString();
            ценаLabel4.Content = oftKlinDataSet.Tables[0].Rows[3][2].ToString();
            ценаLabel5.Content = oftKlinDataSet.Tables[0].Rows[4][2].ToString();

            SetVisibility(Visibility.Visible, NextButton1, panel8, panel9);

            SetVisibility(Visibility.Hidden, BackButton, NextButtonN, NextButton2, услугиLabel2, услугиLabel3, ценаLabel2, ценаLabel3, panel4, panel5, panel6, panel10, panel11, panel12, plabel1, plabel2, plabel3);

        }

        private void BackButtonN1(object sender, RoutedEventArgs e)
        {
            OftKlinika.OftKlinDataSet oftKlinDataSet = ((OftKlinika.OftKlinDataSet)(this.FindResource("oftKlinDataSet")));
            // Загрузить данные в таблицу Table. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter oftKlinDataSetTableTableAdapter = new OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter();
            oftKlinDataSetTableTableAdapter.Fill(oftKlinDataSet.Table);
            услугиLabel6.Text = oftKlinDataSet.Tables[0].Rows[5][1].ToString();
            услугиLabel7.Content = oftKlinDataSet.Tables[0].Rows[6][1].ToString();
            услугиLabel8.Content = oftKlinDataSet.Tables[0].Rows[7][1].ToString();
            ценаLabel6.Content = oftKlinDataSet.Tables[0].Rows[5][2].ToString();
            ценаLabel7.Content = oftKlinDataSet.Tables[0].Rows[6][2].ToString();
            ценаLabel8.Content = oftKlinDataSet.Tables[0].Rows[7][2].ToString();
            // HIDE

            SetVisibility(Visibility.Hidden, NextButton1, NextButtonN, BackButton1, panel13, panel14);

            // VISIBLE
            SetVisibility(Visibility.Visible, NextButton2, NextButton2, BackButton, backuslugibutton, panel10, panel11, panel12);
        }

        private void BackUslugi(object sender, RoutedEventArgs e)
        {
            OftKlinika.OftKlinDataSet oftKlinDataSet = ((OftKlinika.OftKlinDataSet)(this.FindResource("oftKlinDataSet")));
            // Загрузить данные в таблицу Table. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter oftKlinDataSetTableTableAdapter = new OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter();
            oftKlinDataSetTableTableAdapter.Fill(oftKlinDataSet.Table);
            услугиLabel1.Content = oftKlinDataSet.Tables[0].Rows[0][1].ToString();
            услугиLabel2.Content = oftKlinDataSet.Tables[0].Rows[1][1].ToString();
            услугиLabel3.Content = oftKlinDataSet.Tables[0].Rows[2][1].ToString();
            ценаLabel1.Content = oftKlinDataSet.Tables[0].Rows[0][2].ToString();
            ценаLabel2.Content = oftKlinDataSet.Tables[0].Rows[1][2].ToString();
            ценаLabel3.Content = oftKlinDataSet.Tables[0].Rows[2][2].ToString();
            // VISIBLE

            SetVisibility(Visibility.Visible, panel4, panel5, panel6, NextButtonN, услугиLabel2, услугиLabel3, ценаLabel2, ценаLabel3, plabel1, plabel2, plabel3);

            // HIDE
            SetVisibility(Visibility.Hidden, NextButton2, NextButton2, BackButton, BackButton1, NextButton1, NextButton2, panel8, panel9, panel10, panel11, panel12, panel13, panel14);

        }

        private void MinimazeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            //SidePanel.Height = button7.Height;
            
            ZapisUsl zp = new ZapisUsl();
            zp.ShowDialog();
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminEnter ad = new AdminEnter();
            ad.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Form043_025y f025 = new Form043_025y();
            f025.ShowDialog();
        }

        private void CovidButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://yandex.ru/covid19/stat");
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            DoctorDay dd = new DoctorDay();
            dd.ShowDialog();
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            ReportDay rd = new ReportDay();
            rd.ShowDialog();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            OfficesDoctors of = new OfficesDoctors();
            of.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Timetable tt = new Timetable();
            tt.ShowDialog();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            klinikaabout.IsEnabled = true;
            klinikaabout.Visibility = Visibility.Visible;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            klinikaabout.IsEnabled = false;
            klinikaabout.Visibility = Visibility.Hidden;
        }

        private void ButtonMed_Click(object sender, RoutedEventArgs e)
        {
            BDSpisokAdmin bd = new BDSpisokAdmin();
            bd.ShowDialog();
        }

        private void MouseLeftBtnDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void minim(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
