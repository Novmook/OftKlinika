using iTextSharp.text;
using iTextSharp.text.pdf;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Form043_025y.xaml
    /// </summary>
    public partial class Form043_025y : Window
    {
        public Form043_025y()
        {
            InitializeComponent();
        }

        private void Form025y_Click(object sender, RoutedEventArgs e)
        {
            Document myDocument = new Document(PageSize.A3.Rotate());

            try
            {
                PdfWriter.GetInstance(myDocument, new FileStream("Form025y.pdf", FileMode.Create));
                //
                myDocument.Open();
                //
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("Resources/025y.jpg");
                logo.SetAbsolutePosition(5, -40);
                //
                myDocument.Add(logo);
                MessageBox.Show("Форма создана", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }
            myDocument.Close();
    }

        private void Form043y_Click(object sender, RoutedEventArgs e)
        {
            Document myDocument = new Document(PageSize.A4.Rotate());
            try
            {
                PdfWriter.GetInstance(myDocument, new FileStream("Form043y.pdf", FileMode.Create));
                //
                myDocument.Open();
                //
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("Resources/043y.jpg");
                logo.SetAbsolutePosition(40, 10);

                myDocument.Add(logo);
                MessageBox.Show("Форма создана", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }


            myDocument.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
