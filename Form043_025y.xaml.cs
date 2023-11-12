using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
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
using PdfSharp.Pdf.Advanced;

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

            string imagePath = "Resources/025y.jpg";

            // Путь для сохранения PDF-файла
            string pdfPath = "Form025y.pdf";

            try
            {
                // Создание нового документа PDF
                PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();

                // Создание страницы в документе
                PdfSharp.Pdf.PdfPage page = document.AddPage();


                // Получение объекта XGraphics для рисования на странице
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Загрузка изображения
                XImage image = XImage.FromFile(imagePath);

                // Определение размера изображения и масштабирование
                double width = page.Width;
                double height = page.Height;
                double imageWidth = image.PixelWidth;
                double imageHeight = image.PixelHeight;

                double scale = width / imageWidth;
                if (imageHeight * scale > height)
                    scale = height / imageHeight;

                double scaledWidth = imageWidth * scale;
                double scaledHeight = imageHeight * scale;

                // Рисование изображения на странице PDF
                gfx.DrawImage(image, (width - scaledWidth) / 5, (height - scaledHeight) / -40, scaledWidth, scaledHeight);

                // Сохранение PDF-файла
                document.Save(pdfPath);

                // Открытие PDF-файла
                System.Diagnostics.Process.Start(pdfPath);

                MessageBox.Show("PDF-файл успешно создан", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    


//Document myDocument = new Document(PageSize.A3.Rotate());

//try
//{
//    PdfWriter.GetInstance(myDocument, new FileStream("Form025y.pdf", FileMode.Create));
//    //
//    myDocument.Open();
//    //
//    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("Resources/025y.jpg");
//    logo.SetAbsolutePosition(5, -40);
//    //
//    myDocument.Add(logo);
//    MessageBox.Show("Форма создана", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
//}
//catch (DocumentException de)
//{
//    Console.Error.WriteLine(de.Message);
//}
//catch (IOException ioe)
//{
//    Console.Error.WriteLine(ioe.Message);
//}
//myDocument.Close();



private void Form043y_Click(object sender, RoutedEventArgs e)
        {

            string imagePath = "Resources/043y.jpg";

            // Путь для сохранения PDF-файла
            string pdfPath = "Form043y.pdf";

            try
            {
                // Создание нового документа PDF
                PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();

                // Создание страницы в документе
                PdfSharp.Pdf.PdfPage page = document.AddPage();


                // Получение объекта XGraphics для рисования на странице
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Загрузка изображения
                XImage image = XImage.FromFile(imagePath);

                // Определение размера изображения и масштабирование
                double width = page.Width;
                double height = page.Height;
                double imageWidth = image.PixelWidth;
                double imageHeight = image.PixelHeight;

                double scale = width / imageWidth;
                if (imageHeight * scale > height)
                    scale = height / imageHeight;

                double scaledWidth = imageWidth * scale;
                double scaledHeight = imageHeight * scale;

                // Рисование изображения на странице PDF
                gfx.DrawImage(image, (width - scaledWidth) / 40, (height - scaledHeight) / 10, scaledWidth, scaledHeight);

                // Сохранение PDF-файла
                document.Save(pdfPath);

                // Открытие PDF-файла
                System.Diagnostics.Process.Start(pdfPath);

                MessageBox.Show("PDF-файл успешно создан", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        //    Document myDocument = new Document(PageSize.A4.Rotate());
        //    try
        //    {
        //        PdfWriter.GetInstance(myDocument, new FileStream("Form043y.pdf", FileMode.Create));
        //        //
        //        myDocument.Open();
        //        //
        //        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("Resources/043y.jpg");
        //        logo.SetAbsolutePosition(40, 10);

        //        myDocument.Add(logo);
        //        MessageBox.Show("Форма создана", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    catch (DocumentException de)
        //    {
        //        Console.Error.WriteLine(de.Message);
        //    }
        //    catch (IOException ioe)
        //    {
        //        Console.Error.WriteLine(ioe.Message);
        //    }


        //    myDocument.Close();
        //}

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
