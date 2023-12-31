﻿using System;
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
    /// Логика взаимодействия для ZapisUsl.xaml
    /// </summary>
    public partial class ZapisUsl : Window
    {
        List<Specialist> spec = new List<Specialist>();
        List<Category> cate = new List<Category>();
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OftKlin.mdf;Integrated Security=True;Connect Timeout=30");
        public ZapisUsl()
        {
            InitializeComponent();
            idTextBox.IsReadOnly = true;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            idTextBox.Text = GenerateUniqueIdentifier();

            dateTimePicker1.DisplayDateStart = DateTime.Now;
            dateTimePicker1.DisplayDateStart = DateTime.Today.AddDays(1);
            dateTimePicker1.DisplayDateEnd = DateTime.Today.AddDays(5);
            dateTimePicker2.Text = DateTime.Now.ToString();


            OftKlinika.OftKlinDataSet oftKlinDataSet = ((OftKlinika.OftKlinDataSet)(this.FindResource("oftKlinDataSet")));
            // Загрузить данные в таблицу Table. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter oftKlinDataSetTableTableAdapter = new OftKlinika.OftKlinDataSetTableAdapters.TableTableAdapter();
            oftKlinDataSetTableTableAdapter.Fill(oftKlinDataSet.Table);
            System.Windows.Data.CollectionViewSource tableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableViewSource")));
            tableViewSource.View.MoveCurrentToFirst();
            //

            //
            OftKlinika.OftKlinDataSet1 oftKlinDataSet1 = ((OftKlinika.OftKlinDataSet1)(this.FindResource("oftKlinDataSet1")));
            // Загрузить данные в таблицу Uslugi. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet1TableAdapters.UslugiTableAdapter oftKlinDataSet1UslugiTableAdapter = new OftKlinika.OftKlinDataSet1TableAdapters.UslugiTableAdapter();
            oftKlinDataSet1UslugiTableAdapter.Fill(oftKlinDataSet1.Uslugi);
            System.Windows.Data.CollectionViewSource uslugiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uslugiViewSource")));
            uslugiViewSource.View.MoveCurrentToFirst();
            OftKlinika.OftKlinDataSet5 oftKlinDataSet5 = ((OftKlinika.OftKlinDataSet5)(this.FindResource("oftKlinDataSet5")));
            // Загрузить данные в таблицу MedicalCard. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet5TableAdapters.MedicalCardTableAdapter oftKlinDataSet5MedicalCardTableAdapter = new OftKlinika.OftKlinDataSet5TableAdapters.MedicalCardTableAdapter();
            oftKlinDataSet5MedicalCardTableAdapter.Fill(oftKlinDataSet5.MedicalCard);
            System.Windows.Data.CollectionViewSource medicalCardViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("medicalCardViewSource")));
            medicalCardViewSource.View.MoveCurrentToFirst();
            OftKlinika.OftKlinDataSet6 oftKlinDataSet6 = ((OftKlinika.OftKlinDataSet6)(this.FindResource("oftKlinDataSet6")));
            // Загрузить данные в таблицу ReserveTable. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet6TableAdapters.ReserveTableTableAdapter oftKlinDataSet6ReserveTableTableAdapter = new OftKlinika.OftKlinDataSet6TableAdapters.ReserveTableTableAdapter();
            oftKlinDataSet6ReserveTableTableAdapter.Fill(oftKlinDataSet6.ReserveTable);
            System.Windows.Data.CollectionViewSource reserveTableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reserveTableViewSource")));
            reserveTableViewSource.View.MoveCurrentToFirst();
            //
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Table]", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                услугиComboBox.Items.Add(dr["Услуги"]);

                cate.Add(new Category()
                {
                    Id = ((int)dr["Id"]),
                    услуги = dr["Услуги"] as string
                });

            }
            conn.Close();
            conn.Open();
            SqlCommand cmdspec = new SqlCommand("SELECT * FROM [ReserveTable]", conn);
            SqlDataReader dr1 = cmdspec.ExecuteReader();
            while (dr1.Read())
            {
                spec.Add(new Specialist()
                {
                    Id = ((int)dr1["Id"]),
                    Специалист = dr1["Специалист"] as string
                });
            }
            conn.Close();
        }

        private int counter = 1;

        private string GenerateUniqueIdentifier()
        {
            string baseId = "OK-" + counter.ToString("D8");

            // Проверяем, существует ли такой идентификатор в базе данных
            if (IsIdExistsInDatabase(baseId))
            {
                // Если существует, увеличиваем счетчик
                counter++;
                // Рекурсивно вызываем этот метод для генерации нового идентификатора
                return GenerateUniqueIdentifier();
            }

            // Увеличиваем счетчик для следующего идентификатора
            counter++;

            return baseId;
        }

        private Boolean IsIdExistsInDatabase(string id)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OftKlin.mdf;Integrated Security=True;Connect Timeout=30");
            {                                  
                conn.Open();
                string query = "SELECT * FROM Uslugi WHERE ID='" + id + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    //MessageBox.Show("Попробуйте еще раз.");
                    return true;
                }

                else
                    return false;
            }
        }



        private void TimePicker_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void DataPicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            dateTimePicker1.DisplayDateStart = DateTime.Today.AddDays(1);
            dateTimePicker1.DisplayDateEnd = DateTime.Now + TimeSpan.FromDays(7);

            var minDate = dateTimePicker1.DisplayDateStart ?? DateTime.MinValue;
            var maxDate = dateTimePicker1.DisplayDateEnd ?? DateTime.MaxValue;

            for (var d = minDate; d <= maxDate && DateTime.MaxValue > d; d = d.AddDays(1))
            {
                if (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday)
                {
                    dateTimePicker1.BlackoutDates.Add(new CalendarDateRange(d));
                }
            }
        }

        private void TimePickerValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DateTime selectedTime = dateTimePicker2.Value ?? DateTime.MinValue;

            // Проверяем, находится ли выбранное время в разрешенном диапазоне
            if (selectedTime.Hour >= 8 && selectedTime.Hour < 12)
            {
                // Время в разрешенном диапазоне
            }
            else if (selectedTime.Hour == 13 && selectedTime.Minute == 0)
            {
                // Время после 13:00
            }
            else
            {
                //MessageBox.Show("Выберите корректное время.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                // Сбрасываем выбранное время
                dateTimePicker2.Value = null;
            }
        }

        private void TimePicker_SelectedDateTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            
        }



        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            OftKlinika.OftKlinDataSet1 oftKlinDataSet1 = ((OftKlinika.OftKlinDataSet1)(this.FindResource("oftKlinDataSet1")));
            // Загрузить данные в таблицу Uslugi. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet1TableAdapters.UslugiTableAdapter oftKlinDataSet1UslugiTableAdapter = new OftKlinika.OftKlinDataSet1TableAdapters.UslugiTableAdapter();
            oftKlinDataSet1UslugiTableAdapter.Fill(oftKlinDataSet1.Uslugi);
            System.Windows.Data.CollectionViewSource uslugiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uslugiViewSource")));
            uslugiViewSource.View.MoveCurrentToFirst();
            //
            OftKlinika.OftKlinDataSet5 oftKlinDataSet5 = ((OftKlinika.OftKlinDataSet5)(this.FindResource("oftKlinDataSet5")));
            // Загрузить данные в таблицу MedicalCard. Можно изменить этот код как требуется.
            OftKlinika.OftKlinDataSet5TableAdapters.MedicalCardTableAdapter oftKlinDataSet5MedicalCardTableAdapter = new OftKlinika.OftKlinDataSet5TableAdapters.MedicalCardTableAdapter();
            oftKlinDataSet5MedicalCardTableAdapter.Fill(oftKlinDataSet5.MedicalCard);
            System.Windows.Data.CollectionViewSource medicalCardViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("medicalCardViewSource")));
            medicalCardViewSource.View.MoveCurrentToFirst();
            //
            //if (isTimeExists())
            //    return;


            if (idTextBox.Text == "" || услугиComboBox.Text == "" || dateTimePicker1.Text == "" || фамилияTextBox.Text == "" || имяTextBox.Text == "" || dateTimePicker2.Text == "" & dateTimePicker2.Text == "Выберите время" || специалистComboBox.Text == "")
                MessageBox.Show("Пожалуйста, заполните поля");
            else
            {
                //
                SqlConnection conn = new SqlConnection(connectionString);
                if (isTimeExists())
                {
                    
                    return;
                }
                conn.Open();
                
                //
                oftKlinDataSet1UslugiTableAdapter.Insert(idTextBox.Text, услугиComboBox.Text, фамилияTextBox.Text, имяTextBox.Text, dateTimePicker1.Text, dateTimePicker2.Text, специалистComboBox.Text);
                oftKlinDataSet1UslugiTableAdapter.Update(oftKlinDataSet1.Uslugi);
                oftKlinDataSet1.AcceptChanges();
                oftKlinDataSet5MedicalCardTableAdapter.Insert(idTextBox.Text, фамилияTextBox.Text, имяTextBox.Text, услугиComboBox.Text, dateTimePicker1.Text, специалистComboBox.Text);
                oftKlinDataSet5MedicalCardTableAdapter.Update(oftKlinDataSet5.MedicalCard);
                oftKlinDataSet5.AcceptChanges();
                MessageBox.Show($"Успешно! Ждем вас с нетерпением в ближайшее время.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                Clear();
                conn.Close();
            }

            void Clear()
            {
                услугиComboBox.Text = dateTimePicker1.Text = имяTextBox.Text = фамилияTextBox.Text = dateTimePicker2.Text = специалистComboBox.Text = "";
                dateTimePicker1.Text = dateTimePicker2.Text = специалистComboBox.Text = null;
            }
        }


        public bool isTimeExists()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Uslugi WHERE Дата=@Date AND Время=@Time AND Услуга=@Service";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Time", dateTimePicker2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Service", услугиComboBox.Text.Trim());

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Запись на такое время уже существует, пожалуйста, выберите другое время");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void GraphicButton_Click(object sender, RoutedEventArgs e)
        {
            Timetable tt = new Timetable();
            tt.Show();
        }

        private string[] GetSpecById(int Id)
        {
            return spec.Where(line => line.Id == Id).Select(I => I.Специалист).ToArray();
        }

        [Serializable]
        class Category
        {
            public int Id { get; set; }
            public string услуги { get; set; }
        }
        [Serializable]
        class Specialist
        {
            public int Id { get; set; }
            public string Специалист { get; set; }
        }

        private void услугиComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Id;
            if (услугиComboBox.SelectedIndex >= 0)
            {
                специалистComboBox.Items.Clear();
                Id = (cate[услугиComboBox.SelectedIndex].Id);
                foreach (string name in GetSpecById(Id))
                {
                    специалистComboBox.Items.Add(name);
                }
            }
            //специалистComboBox.Items.Clear();
            //Id = cate[услугиComboBox.SelectedIndex].Id;
            //услугиComboBox.SelectedIndex
            //foreach (string name in GetSpecById(Id))
            //{
            //    специалистComboBox.Items.Add(name);
            //}
        }

        private void DragZapisUsl(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
