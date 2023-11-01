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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OftKlinika
{
    /// <summary>
    /// Логика взаимодействия для KlinikaAbout.xaml
    /// </summary>
    public partial class KlinikaAbout : UserControl
    {
        public KlinikaAbout()
        {
            InitializeComponent();
        }

        private void GraphicButton_Click(object sender, RoutedEventArgs e)
        {
            Timetable tt = new Timetable();
            tt.ShowDialog();
        }
    }
}
